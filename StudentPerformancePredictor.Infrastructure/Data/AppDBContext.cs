using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using StudentPerformancePredictor.Infrastructure.Entities;

namespace StudentPerformancePredictor.Infrastructure.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<PredictionHistory> PredictionHistories => Set<PredictionHistory>();

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
    }
}
