using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Stock4.DataT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Stock4.Models;

namespace TestProject1stock4.DataConTest
{
    public class InMemDb
    {
        public async Task<StockContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<StockContext>()
                .UseInMemoryDatabase(databaseName:"InMemoryDb")
                .Options;
            var databaseContext = new StockContext(options);
            databaseContext.Database.EnsureCreated();

            if (await databaseContext.stockLists.CountAsync() <= 0)
            {
                for (int i = 0; i <= 1000; i += 1)
                {
                    databaseContext.stockLists.Add(
                        new StockList()
                        {
                            StockId= i,
                            StockName= "Mphasis",
                            StockPrice=309,
                        });

                }
                databaseContext.SaveChanges();

            }
            return databaseContext;
        }
    }
}
