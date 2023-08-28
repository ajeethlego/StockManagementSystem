using HolidayAPILocal.Models;
using Microsoft.EntityFrameworkCore;

namespace HolidayAPILocal.Data
{
    public class HolidayContext:DbContext
    {
        public HolidayContext() { }
        public HolidayContext(DbContextOptions<HolidayContext> options) : base(options) { }

        public DbSet<Holiday> holidays { get; set; }
    }
}
