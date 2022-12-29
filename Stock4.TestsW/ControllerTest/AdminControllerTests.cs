using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using Stock4.Controllers;
using Stock4.DataT;
using Stock4.Models;
using Stock4.TestsW.InMemDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Stock4.TestsW.ControllerTest
{
    public class AdminControllerTests
    {
        [Fact]
        public async void AdminController_Create_Returnnotnull()
        {

            var inmem = new InMemDbs();
            var dbcontext = await inmem.GetDbContext();
            var adminstock = new AdminController(dbcontext);


            //arrange
            var data = new StockList()
            {
                StockId = 123,
                StockName = "Mphasis",
                StockPrice = 5009,
            };
            //act

            var res=adminstock.Create(data);
            //assert

            res.Should().NotBeNull();
            res.Should().BeOfType<Task<IActionResult>>();
            dbcontext.stockLists.Should().HaveCount(2);

        }

        [Fact]
        public async void AdminController_Details_ReturnData()
        {
            var inmem = new InMemDbs();
            var dbcontext = await inmem.GetDbContext();
            //arrange
            var id = 14;
            var adminstock=new AdminController(dbcontext);

            StockList dataa = new StockList()
            {
                StockId = 22,
                StockName = "SAIL",
                StockPrice = 85,
            };
            //act
            var ress= await adminstock.Details(dataa.StockId);

            var a = ress.ToJson();
            //assert
            ress.Should().NotBeNull();
           // ress.Should().BeOfType<Task<IActionResult>>();
            //res.Should().BeOfType(typeof(StockList));
           
          //  ress.Should().Be(dataa);

            
        }

        [Fact]
        public async void AdminController_ViewCustomers_ReturnData()
        {
            var inmem = new InMemDbs();
            var dbcontext = await inmem.GetDbContext();
            var adminstock = new AdminController(dbcontext);

            //arrange
            //act
            var res=  await adminstock.ViewCustomers();

            //assert

            res.Should().NotBeNull();
            //res.Should().BeOfType<Task<IActionResult>>();
            dbcontext.authorizedUsers.Should().HaveCount(2);
            dbcontext.authorizedUsers.Should().NotContainNulls();
        }


        [Fact]
        public async void AdminController_Edit_returnnotnull()
        {
            var inmem = new InMemDbs();
            var dbcontext = await inmem.GetDbContext();
            var adminstock = new AdminController(dbcontext);

            //arrange
            var id = 6;
            var stockLst = new StockList()
            {
                //StockId = 6,
                StockName = "Sail",
                StockPrice = 145.4f,
            };

           // var data = await dbcontext.stockLists.FindAsync(stockLst.StockId);
            var res = await adminstock.tempaddnameEdit(id,stockLst);

            res.Should().NotBeNull();
            

        }
        [Fact]
        public async Task DeleteTests()
        {
            //Arrange
            var inmemory = new InMemDbs();
            var dbcontext = await inmemory.GetDbContext();
            var adminstock = new AdminController(dbcontext);
            int id = 22;

            //Act
            var result = await adminstock.DeleteConfirmed(id);

            //Assert
            result.Should().NotBeNull();
            //result.Should().BeOfType<ActionResult<BookingTbl>>();
            dbcontext.stockLists.Should().HaveCount(1);
        }







    }
}
