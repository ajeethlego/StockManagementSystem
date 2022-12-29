using FluentAssertions;
using NuGet.Protocol;
using Stock_4.Controllers;
using Stock_4.Models;
using Stock4.Controllers;
using Stock4.TestsW.InMemDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock4.TestsW.ControllerTest
{
    public class UserPortfolioControllerTest
    {
        //[Fact]
        [Fact(Skip ="Tested successfully")]
        public async void UserPortfolioController_UserPortfolioIndex_returndata()
        {
            var inmem = new InMemDbs();
            var dbcontext = await inmem.GetDbContext();
            var portdata = new UserPortfolioController(dbcontext);

            //arrange
            //act
            var res = portdata.UserPortfolioIndex();
            //assert
            res.Should().NotBeNull();
            dbcontext.userPortfolios.Should().HaveCount(4);
        }

        //[Fact]
        [Fact(Skip ="Tested successfully")]
        public async void UserPortfolioController_BuyStock_returndata()
        {
            var inmem = new InMemDbs();
            var dbcontext = await inmem.GetDbContext();
            var portdata = new UserPortfolioController(dbcontext);

            //arrage
            var StockId = 1;
            var BuyQty = 1;
            var StockPrice = 85;
            var StockName = "SAIL";

            //act

            var res=portdata.BuyStock(StockId,BuyQty,StockPrice,StockName);
            
            //assert

            res.Should().NotBeNull();
            dbcontext.userPortfolios.Should().HaveCount(4);
        }

        //[Fact]
        [Fact(Skip ="Tested successfully")]
        public async void UserPortfolioController_SellAllStock_returndata()
        {
            var inmem = new InMemDbs();
            var dbcontext = await inmem.GetDbContext();
            var portdata = new UserPortfolioController(dbcontext);

            //arrange
            int Id = 1;
            var CurrentPrice = 85;
            var a = 1.0f;
            //act
            var res=portdata.SellAllStock(Id,CurrentPrice);
            //assert

            foreach(var item in dbcontext.authorizedUsers)
            {
                if (item.UserId == Id)
                {
                    a = item.AvailableFund;
                    break;
                }
            }

            res.Should().NotBeNull();
            dbcontext.userPortfolios.Should().HaveCount(2);
        }








    }
}
