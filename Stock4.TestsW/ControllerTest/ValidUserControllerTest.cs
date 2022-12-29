using FluentAssertions;
using NuGet.Protocol;
using Stock4.Controllers;
using Stock4.Models;
using Stock4.TestsW.InMemDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock4.TestsW.ControllerTest
{
    public class ValidUserControllerTest
    {
        //[Fact]
        [Fact(Skip = "ignore")]
        public async void ValidUserController_ValidUserHomePage_returnNotNull()
        {
            var inmem = new InMemDbs();
            var dbcontext = await inmem.GetDbContext();
            var validuserdata = new ValidUserController(dbcontext);

            //arrange
            //act
            var res = validuserdata.ValidUserHomePage();
            //assert

            res.Should().NotBeNull();


        }

        [Fact]
        public async void ValidUserController_ValidUserIndex_returnNotNull()
        {
            var inmem = new InMemDbs();
            var dbcontext = await inmem.GetDbContext();
            var validuserdata = new ValidUserController(dbcontext);

            //arrange
            //act
            var res= validuserdata.ValidUserIndex();
            //assert
            res.Should().NotBeNull();
            dbcontext.stockLists.Should().NotBeNull();
            dbcontext.stockLists.Should().HaveCount(2);
        }

       // [Fact]
        [Fact(Skip ="Contains static variable")]
        public async void ValidUserController_ValidUserDetails_returnNotNull()
        {
            var inmem = new InMemDbs();
            var dbcontext = await inmem.GetDbContext();
            var validuserdata = new ValidUserController(dbcontext);

            //arrange
            StockList dataa = new StockList()
            {
                StockId = 22,
                StockName = "SAIL",
                StockPrice = 85,
            };
            //act
            var ress = await validuserdata.VUStockDetails(dataa.StockId);

            
            //assert
            ress.Should().NotBeNull();
        }












    }
}
