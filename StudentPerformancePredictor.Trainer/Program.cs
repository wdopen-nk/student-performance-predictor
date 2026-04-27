using StudentPerformancePredictor.ML.Services;

namespace StudentPerformancePredictor.Trainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting training...");

            var trainer = new StudentModelTrainer();

            var dataPath = Path.Combine(AppContext.BaseDirectory, "student-data.csv");
            var modelPath = Path.Combine(AppContext.BaseDirectory, "student-model.zip");

            Console.WriteLine($"Data path: {dataPath}");
            Console.WriteLine($"Model path: {modelPath}");

            if (!File.Exists(dataPath))
            {
                Console.WriteLine("CSV file was not found.");
                Console.ReadLine();
                return;
            }

            trainer.Train(dataPath, modelPath);

            Console.WriteLine("Model trained and saved successfully.");
            Console.WriteLine($"Saved at: {modelPath}");

            Console.ReadLine();
        }
    }
}
