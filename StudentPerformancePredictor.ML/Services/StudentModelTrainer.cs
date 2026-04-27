using Microsoft.ML;
using StudentPerformancePredictor.Core.Models;
using StudentPerformancePredictor.ML.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPerformancePredictor.ML.Services
{
    public class StudentModelTrainer
    {
        private readonly MLContext _mlContext;

        public StudentModelTrainer()
        {
            _mlContext = new MLContext(seed: 1);
        }

        public void Train(string dataPath, string modelPath)
        {
            IDataView data = _mlContext.Data.LoadFromTextFile<StudentTrainingData>
                (
                    path: dataPath,
                    hasHeader: true,
                    separatorChar: ','
                );

            var split = _mlContext.Data.TrainTestSplit(data, testFraction: 0.2);

            var pipeline = _mlContext.Transforms.Concatenate
                (
                    "Features",
                    nameof(StudentTrainingData.StudyHoursPerWeek),
                    nameof(StudentTrainingData.AttendanceRate),
                    nameof(StudentTrainingData.PreviousGrade),
                    nameof(StudentTrainingData.AssignmentsCompleted))
                    .Append(_mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(
                        labelColumnName: nameof(StudentTrainingData.Passed),
                        featureColumnName: "Features")
                );

            var model = pipeline.Fit(split.TrainSet);

            var predictions = model.Transform(split.TrainSet);

            var metrics = _mlContext.BinaryClassification.Evaluate
                (
                    predictions,
                    labelColumnName: nameof(StudentTrainingData.Passed)
                );

            Console.WriteLine($"Accuracy: {metrics.Accuracy:P2}");
            Console.WriteLine($"AUC: {metrics.AreaUnderRocCurve:P2}");
            Console.WriteLine($"F1 Score: {metrics.F1Score:P2}");

            _mlContext.Model.Save(model, data.Schema, modelPath);
        }
    }
}
