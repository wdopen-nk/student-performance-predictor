using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPerformancePredictor.Core.Models
{
    public class StudentPrediction
    {
        public bool PredictedLabel { get; set; }
        public float Probability { get; set; }
        public float Score { get; set; }
    }
}
