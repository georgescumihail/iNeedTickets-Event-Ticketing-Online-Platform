using System;
using System.Collections.Generic;
using System.Text;

namespace iNeedTickets.ML.Models
{
    public class PredictionResult
    {
        public EventPrediction Prediction { get; set; }

        public int EventId { get; set; }
    }
}
