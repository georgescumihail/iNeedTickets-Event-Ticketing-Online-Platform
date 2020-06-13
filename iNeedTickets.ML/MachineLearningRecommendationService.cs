using iNeedTickets.ML.Models;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iNeedTickets.ML
{
    public class MachineLearningRecommendationService : IMachineLearningRecommendationService
    {
        private PredictionEngine<EventPurchaseModel, EventPrediction> engine;

        public MachineLearningRecommendationService()
        {
            engine = null;
        }

        public List<PredictionResult> CreatePrediction(float eventId, IQueryable<int> availableEvents, int size)
        {
            if (engine == null)
            {
                var context = new MLContext();

                var path = "../iNeedTickets.ML/Data/data-sample.txt";

                var data = context.Data.LoadFromTextFile<EventPurchaseModel>(
                    path,
                    hasHeader: true,
                    separatorChar: '\t');

                var partitions = context.Data.TrainTestSplit(data, testFraction: 0.2);

                var options = new MatrixFactorizationTrainer.Options()
                {
                    MatrixColumnIndexColumnName = "EventIdEncoded",
                    MatrixRowIndexColumnName = "CombinedEventIdEncoded",
                    LabelColumnName = "CombinedEventId",
                    LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass,
                    Alpha = 0.01,
                    Lambda = 0.025
                };

                var pipeline = context.Transforms.Conversion.MapValueToKey(
                    inputColumnName: "EventId",
                    outputColumnName: "EventIdEncoded")
                    .Append(context.Transforms.Conversion.MapValueToKey(
                        inputColumnName: "CombinedEventId",
                        outputColumnName: "CombinedEventIdEncoded"))
                    .Append(context.Recommendation().Trainers.MatrixFactorization(options));

                ITransformer model = pipeline.Fit(partitions.TrainSet);

                var predictions = model.Transform(partitions.TestSet);
                var metrics = context.Regression.Evaluate(predictions, labelColumnName: "CombinedEventId", scoreColumnName: "Score");

                engine = context.Model.CreatePredictionEngine<EventPurchaseModel, EventPrediction>(model);
            }

            var scoresList = new List<PredictionResult>();

            foreach(var e in availableEvents)
            {
                var pred = engine.Predict(
                    new EventPurchaseModel()
                    {
                        EventId = eventId,
                        CombinedEventId = e
                    });

                scoresList.Add(new PredictionResult
                {
                    Prediction = pred,
                    EventId = e
                });
            }

            return scoresList.AsQueryable().OrderByDescending(s => s.Prediction.Score).Take(size).ToList();
        }
    }
}
