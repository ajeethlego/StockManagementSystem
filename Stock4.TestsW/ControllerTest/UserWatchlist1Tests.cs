using FluentAssertions;
using Stock4.Controllers;
using Stock4.Models;
using Stock4.Repositories;
using Stock4.TestsW.InMemDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static com.sun.tools.@internal.xjc.reader.xmlschema.bindinfo.BIConversion;

namespace Stock4.TestsW.ControllerTest
{
    public class UserWatchlist1Tests
    {

        [Fact]
        public async void UserWatchlist1Repositiry_GetUserWatchlist1_Userid1()
        {
            var inmem = new InMemDbs();
            var dbcontext = await inmem.GetDbContext();
            var Wlist = new UserWatchlist1Repository(dbcontext);

            //arrange
            var userid = 1;
            //act
            var result = Wlist.GetUserWatchlist1(userid);
            //assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
        }

        [Fact]
        public async void UserWatchlist1Repositiry_GetUserWatchlist1_Userid2()
        {
            var inmem = new InMemDbs();
            var dbcontext = await inmem.GetDbContext();
            var Wlist = new UserWatchlist1Repository(dbcontext);

            //arrange
            var userid = 2;
            //act
            var result = Wlist.GetUserWatchlist1(userid);
            //assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
        }

        [Fact]
        public async void UserWatchlist1Repositiry_GetUserWatchlist1_ReturnEmpty()
        {
            var inmem = new InMemDbs();
            var dbcontext = await inmem.GetDbContext();
            var Wlist = new UserWatchlist1Repository(dbcontext);

            //arrange
            var userid = 4;
            //act
            var result = Wlist.GetUserWatchlist1(userid);
            //assert
            result.Should().BeEmpty();
        }

        //[Fact]
        //public async void UserWatchlist1Repositiry_Create_Returnnotnull()
        //{
        //    var inmem = new InMemDbs();
        //    var dbcontext = await inmem.GetDbContext();
        //    var Wlist = new UserWatchlist1Repository(dbcontext);

        //    //arrange
        //    var Watchlist1 = new UserWatchlist1()
        //    {
        //        StockId = 2,
        //        UserId = 1
        //    };
        //    //act
        //    var result= Wlist.Create(Watchlist1);

        //}

    }
}
