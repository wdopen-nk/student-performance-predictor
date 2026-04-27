using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPerformancePredictor.Core.Models
{
    public class StudentData
    {
        public float StudyHoursPerWeek { get; set; }
        public float AttendanceRate { get; set; }
        public float PreviousGrade { get; set; }
        public float AssignmentsCompleted { get; set; }
        public bool Passed { get; set; }
    }
}
