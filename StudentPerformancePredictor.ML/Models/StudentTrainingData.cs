using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPerformancePredictor.ML.Models;

public class StudentTrainingData
{
    [LoadColumn(0)]
    public float StudyHoursPerWeek { get; set; }

    [LoadColumn(1)]
    public float AttendanceRate { get; set; }

    [LoadColumn(2)]
    public float PreviousGrade { get; set; }

    [LoadColumn(3)]
    public float AssignmentsCompleted { get; set; }

    [LoadColumn(4)]
    public bool Passed { get; set; }
}
