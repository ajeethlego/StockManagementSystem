using CalcApiLocal.Models;
using Microsoft.EntityFrameworkCore;

namespace CalcApiLocal.Data
{
    public class CalcContext:DbContext
    {
        public CalcContext() { }
        public CalcContext(DbContextOptions<CalcContext> options) : base(options) { }
        public DbSet<CalcRes> calcRes { get; set; }
    }
}
