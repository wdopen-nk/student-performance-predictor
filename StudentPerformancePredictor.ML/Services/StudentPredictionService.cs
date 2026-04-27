using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.ML;
using StudentPerformancePredictor.Core.Models;


namespace StudentPerformancePredictor.ML.Services
{
    public class StudentPredictionService
    {
        private readonly PredictionEngine<StudentData, StudentPrediction> _predictionEngine;

        public StudentPredictionService(string modelPath)
        {
            var mlContext = new MLContext();

            var model = mlContext.Model.Load(modelPath, out _);

            _predictionEngine = mlContext.Model.CreatePredictionEngine<StudentData, StudentPrediction>(model);
        }

        public StudentPrediction Predict(StudentData studentData)
        {
            return _predictionEngine.Predict(studentData);
        }
    }
}
