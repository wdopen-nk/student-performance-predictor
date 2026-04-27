namespace StudentPerformancePredictor.Api.Dtos
{
    public class StudentPredictionResponse
    {
        public bool PredictedPassed { get; set; }
        public float Probability { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
