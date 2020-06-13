using iNeedTickets.ML.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iNeedTickets.ML
{
    public interface IMachineLearningRecommendationService
    {
        List<PredictionResult> CreatePrediction(float eventId, IQueryable<int> availableEvents, int size);
    }
}
