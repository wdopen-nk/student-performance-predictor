namespace StudentPerformancePredictor.Api.Dtos
{
    public class StudentPredictionRequest
    {
        public float StudyHoursPerWeek { get; set; }
        public float AttendanceRate { get; set; }
        public float PreviousGrade { get; set; }
        public float AssignmentsCompleted { get; set; }
    }
}
