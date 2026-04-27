using Microsoft.EntityFrameworkCore;
using StudentPerformancePredictor.Infrastructure.Data;
using StudentPerformancePredictor.ML.Services;

namespace StudentPerformancePredictor.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDBContext>(options =>
            {
                options.UseSqlite("Data Source=student_predictions.db");
            });

            var modelPath = Path.Combine(
                AppContext.BaseDirectory,
                "student-model.zip");

            builder.Services.AddSingleton(new StudentPredictionService(modelPath));

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            //app.UseHttpsRedirection();

            app.MapControllers();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                dbContext.Database.EnsureCreated();
            }

            app.Run();
        }
    }
}
