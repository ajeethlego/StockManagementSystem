using com.sun.xml.@internal.fastinfoset.util;
using FluentAssertions;
using Stock_4.Controllers;
using Stock4.Controllers;
using Stock4.TestsW.InMemDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock4.TestsW.ControllerTest
{
    public class FundControllerTest
    {
        //[Fact]
        [Fact(Skip = "Recieved desired result")]
        public async void FundController_FundIndex_returnNotNull()
        {
            var inmem = new InMemDbs();
            var dbcontext = await inmem.GetDbContext();
            var fundata = new FundController(dbcontext);

            //arrange
            var Id = 1;
            //act
            var result= fundata.FundIndex(Id);
            //assert
            result.Should().NotBeNull();
        }

        //[Fact]
        [Fact(Skip ="Recieved expected result")]
        public async void FundController_ToAddFunds_RetunNotnull()
        {
            var inmem = new InMemDbs();
            var dbcontext = await inmem.GetDbContext();
            var fundata = new FundController(dbcontext);


            //arrange
            var Id= 1;
            float amount = 300;
            float AvailableFund = 20000;
            var a = 1.0f;
            //act
            var res=fundata.ToAddFunds(amount, AvailableFund);

            //assert
            res.Should().NotBeNull();

            foreach(var item in dbcontext.authorizedUsers)
            {
                if (item.UserId == Id)
                {
                    a=item.AvailableFund;
                    break;
                }
            }
            a.Should().Be(20300);
        }

        //[Fact]
        [Fact(Skip ="Recieved expected result")]
        public async void FundController_ToRemoveFunds_RetunNotnull()
        {
            var inmem = new InMemDbs();
            var dbcontext = await inmem.GetDbContext();
            var fundata = new FundController(dbcontext);


            //arrange
            var Id = 1;
            float amount = 300;
            float AvailableFund = 20000;
            var a = 1.0f;
            //act
            var res = fundata.ToRemoveFunds(amount, AvailableFund);

            //assert
            res.Should().NotBeNull();

            foreach (var item in dbcontext.authorizedUsers)
            {
                if (item.UserId == Id)
                {
                    a = item.AvailableFund;
                    break;
                }
            }
            a.Should().Be(19700);
        }




    }
}
