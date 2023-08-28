using CalcApiLocal.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCalcApi.Controller
{
    public class InMemDb
    {
        public async Task<CalcContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<CalcContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new CalcContext(options);
            databaseContext.Database.EnsureCreated();

            databaseContext.calcRes.Add(
                new CalcApiLocal.Models.CalcRes()
                {
                    Qty = 1,
                    Stockprice = 1,
                    StampDuty = 1,
                    Brokerage = 1,
                    TotalPrice = 1
                });

            return databaseContext;
        }
    }
}
