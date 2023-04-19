using AKOK_BlazorServer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace AKOK_BlazorServer.Data
{
    public class FortuneDbContext : DbContext
    {

        public FortuneDbContext(DbContextOptions<FortuneDbContext> options)
        : base(options)
        {
        }
        public DbSet<ResultText> ResultTexts { get; set; }
    }
}
