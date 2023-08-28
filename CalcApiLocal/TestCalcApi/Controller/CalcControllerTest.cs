using CalcApiLocal.Models;
using CalcApiLocal.Repos;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCalcApi.Controller
{
    public class CalcControllerTest
    {
        [Fact]
        public async void CalcController_Create_Returnnotnull()
        {

            var inmem = new InMemDb();
            var dbcontext = await inmem.GetDbContext();
            var calc = new CalcRepos(dbcontext);

            //arrange
            var calres = new CalcRes()
            {
                Qty = 1,
                Stockprice = 100
            };

            var calres1 = new CalcRes()
            {
                Qty = 1,
                Stockprice = 100,
                StampDuty= 1,
                Brokerage= 2,
                TotalPrice= 97,
            };
            //act

           // var res=calc.Create(calres);
            //assert
            //res.Should().BeEquivalentTo(calres1);


        }
    }
}
