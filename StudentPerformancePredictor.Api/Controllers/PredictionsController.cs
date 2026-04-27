using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPerformancePredictor.Api.Dtos;
using StudentPerformancePredictor.Core.Models;
using StudentPerformancePredictor.Infrastructure.Data;
using StudentPerformancePredictor.Infrastructure.Entities;
using StudentPerformancePredictor.ML.Services;

namespace StudentPerformancePredictor.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class PredictionsController : ControllerBase
{
    private readonly StudentPredictionService _predictionService;
    private readonly AppDBContext _dbContext;

    public PredictionsController(
        StudentPredictionService predictionService, 
        AppDBContext dbContext)
    {
        _predictionService = predictionService;
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<ActionResult<StudentPredictionResponse>> Predict(
        StudentPredictionRequest request)
    {
        var input = new StudentData
        {
            StudyHoursPerWeek = request.StudyHoursPerWeek,
            AttendanceRate = request.AttendanceRate,
            PreviousGrade = request.PreviousGrade,
            AssignmentsCompleted = request.AssignmentsCompleted,
        };

        var prediction = _predictionService.Predict(input);

        var history = new PredictionHistory
        {
            StudyHoursPerWeek = request.StudyHoursPerWeek,
            AttendanceRate = request.AttendanceRate,
            PreviousGrade = request.PreviousGrade,
            AssignmentsCompleted = request.AssignmentsCompleted,
            PredictedPassed = prediction.PredictedLabel,
            Probability = prediction.Probability
        };

        _dbContext.PredictionHistories.Add(history);
        await _dbContext.SaveChangesAsync();

        return Ok(new StudentPredictionResponse
        {
            PredictedPassed = prediction.PredictedLabel,
            Probability = prediction.Probability,
            Message = prediction.PredictedLabel
                ? "The student is likely to pass."
                : "The student may need academic support."
        });
    }

    [HttpGet("history")]
    public async Task<ActionResult<List<PredictionHistory>>> GetHistory()
    {
        var history = await _dbContext.PredictionHistories
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();

        return Ok(history);
    }
}