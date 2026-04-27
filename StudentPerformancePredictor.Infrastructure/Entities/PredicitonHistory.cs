using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPerformancePredictor.Infrastructure.Entities
{
    public class PredictionHistory
    {
        public int Id { get; set; }

        public float StudyHoursPerWeek { get; set; }
        public float AttendanceRate { get; set; }
        public float PreviousGrade { get; set; }
        public float AssignmentsCompleted { get; set; }

        public bool PredictedPassed { get; set; }
        public float Probability { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
