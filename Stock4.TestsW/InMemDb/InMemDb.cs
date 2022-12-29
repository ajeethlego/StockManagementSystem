using Microsoft.EntityFrameworkCore;
using Stock_4.Models;
using Stock4.DataT;
using Stock4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock4.TestsW.InMemDb
{
    public class InMemDbs
    {
        public async Task<StockContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<StockContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new StockContext(options);
            databaseContext.Database.EnsureCreated();

            int genId = 1;

            databaseContext.authorizedUsers.Add
                (
                    new Models.AuthorizedUser()
                    {
                        UserId = 1,
                        UserName = "Ajeeth",
                        AvailableFund = 20000,
                        IncomePerAnum = 100000,
                        CityName = "Bangalore",
                        DateOfBirth = new DateTime(2000, 05, 04),
                        EmailId = "Ajeeth@gmail.com",
                        EmploymentType = "IT",
                        PanNumber = "BXZPJ6789J",
                        Password = "password",
                        Pincode = 324454,
                    }
                );

            databaseContext.authorizedUsers.Add
                (
                    new Models.AuthorizedUser()
                    {
                        UserId = 2,
                        UserName = "Legolas",
                        AvailableFund = 30000,
                        IncomePerAnum = 200000,
                        CityName = "Gundabad",
                        DateOfBirth = new DateTime(2000, 06, 05),
                        EmailId = "Lego@gmail.com",
                        EmploymentType = "IT",
                        PanNumber = "BXZPJ6789J",
                        Password = "password",
                        Pincode = 324454,
                    }
                );
            databaseContext.adminDetails.Add(
                new Stock_4.Models.AdminDetails()
                {
                    AdminId = 1,
                    AdminName = "Meadmin",
                    AdminEmail = "Meadmin@gmail.com",
                    AdminPassword = "password",
                });

            databaseContext.stockLists.Add(
                new Models.StockList()
                {
                    StockId = 2,
                    StockName = "SAIL",
                    StockPrice = 85,
                });

            databaseContext.stockLists.Add(
                new Models.StockList()
                {
                    StockId = 22,
                    StockName = "SAIL",
                    StockPrice = 85,
                });
            await databaseContext.SaveChangesAsync();

            //for(int i = 0; i < 10; i++)
            //{
            //    databaseContext.stockLists.Add(
            //    new Models.StockList()
            //    {
            //        StockId = genId+i,
            //        StockName = "GAIL",
            //        StockPrice = 120.4f,
            //    });
            //}


            databaseContext.userWatchlist1s.Add(
                new UserWatchlist1()
                {
                    Id= 1,
                    UserId= 1,
                    StockId= 2,
                });
            databaseContext.userWatchlist1s.Add(
                new UserWatchlist1()
                {
                    Id = 2,
                    UserId = 1,
                    StockId = 22,
                });
            databaseContext.userWatchlist1s.Add(
                new UserWatchlist1()
                {
                    Id = 3,
                    UserId = 2,
                    StockId = 2,
                });

            databaseContext.userPortfolios.Add(
                new UserPortfolio()
                {
                    Id= 1,
                    StockId= 2,
                    UserId= 1,
                    Qty= 1,
                    BoughtAt= 85,
                    BoughtAtTotal= 85,
                    CurrentPrice= 85,
                    CurrentPriceTotal= 85,
                    ProfOrLoss= 0,
                    StockName="SAIL"
                });
           

            databaseContext.userPortfolios.Add(
                new UserPortfolio()
                {
                    Id = 2,
                    StockId = 2,
                    UserId = 2,
                    Qty = 1,
                    BoughtAt = 85,
                    BoughtAtTotal = 85,
                    CurrentPrice = 85,
                    CurrentPriceTotal = 85,
                    ProfOrLoss = 0,
                    StockName = "SAIL"
                });

            databaseContext.userPortfolios.Add(
               new UserPortfolio()
               {
                   Id = 3,
                   StockId = 22,
                   UserId = 1,
                   Qty = 1,
                   BoughtAt = 85,
                   BoughtAtTotal = 85,
                   CurrentPrice = 85,
                   CurrentPriceTotal = 85,
                   ProfOrLoss = 0,
                   StockName = "SAIL"
               });


            await databaseContext.SaveChangesAsync();






            return databaseContext;


        }
        
    }
}
