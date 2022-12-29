using FluentAssertions;
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
    public class LoginAdminControllerTest
    {
        //[Fact]
        [Fact(Skip = "SkipNow")]
        public async void LoginAdminController_AdminToLogin_Returnok()
        {
            var inmem = new InMemDbs();
            var dbcontext = await inmem.GetDbContext();
            var log = new LoginAdminController(dbcontext);


            //arrange
            AdminDetails adn = new AdminDetails()
            {
                //AdminId = 1,
                //AdminName = "Meadmin",
                AdminEmail = "Meadmin@gmail.com",
                AdminPassword = "password",
            };

            //act
            var res= log.AdminToLogin(adn);

            //assert
            res.Should().NotBeNull();
        }

        [Fact]
        //[Fact(Skip = "SkipNow")]

        public async void LoginAdminController_AdminToRegister_Returnok()
        {
            var inmem = new InMemDbs();
            var dbcontext = await inmem.GetDbContext();
            var log = new LoginAdminController(dbcontext);


            //arrange
            AdminDetails adn = new AdminDetails()
            {
                AdminId = 2,
                AdminName = "Meadmin",
                AdminEmail = "Meadmin@gmail.com",
                AdminPassword = "password",
            };

            //act
            var res = log.AdminToRegister(adn);

            //assert
            res.Should().NotBeNull();
            dbcontext.adminDetails.Should().NotBeNull();
            dbcontext.adminDetails.Should().OnlyHaveUniqueItems();
            dbcontext.adminDetails.Should().HaveCount(2);
        }

        //[Fact]
        [Fact(Skip = "Contains static function")]
        public async void LoginAdminController_Logout_ReturrnOk()
        {
            var inmem = new InMemDbs();
            var dbcontext = await inmem.GetDbContext();
            var log = new LoginAdminController(dbcontext);

            //arrange
            //act
            var result = log.Logout();
            result.Should().NotBeNull();
        }



    }
}
