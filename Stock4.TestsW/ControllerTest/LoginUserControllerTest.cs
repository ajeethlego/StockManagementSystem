using FluentAssertions;
using Stock_4.Controllers;
using Stock_4.Models;
using Stock4.Models;
using Stock4.TestsW.InMemDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock4.TestsW.ControllerTest
{
    public class LoginUserControllerTest
    {
        //[Fact]
        [Fact(Skip = "Contains static function")]
        public async void LoginUserController_UserToLogin_Returnok()
        {
            var inmem = new InMemDbs();
            var dbcontext = await inmem.GetDbContext();
            var log = new LoginUserController(dbcontext);


            //arrange
            AuthorizedUser adn = new AuthorizedUser()
            {

                EmailId = "Ajeeth@gmail.com",
                Password = "password",

            };

            //act
            var res = log.UserToLogin(adn);

            //assert
            res.Should().NotBeNull();
        }

        [Fact]
        //[Fact(Skip = "SkipNow")]

        public async void LoginUserController_UserToRegister_Returnok()
        {
            var inmem = new InMemDbs();
            var dbcontext = await inmem.GetDbContext();
            var log = new LoginUserController(dbcontext);


            //arrange
            AuthorizedUser adn = new AuthorizedUser()
            {
                UserId = 3,
                UserName = "AjeethLego",
                AvailableFund = 20000,
                IncomePerAnum = 100000,
                CityName = "Bangalore",
                DateOfBirth = new DateTime(2000, 05, 04),
                EmailId = "AjeethLego@gmail.com",
                EmploymentType = "IT",
                PanNumber = "BXZPJ6789J",
                Password = "password",
                Pincode = 324454,

            };

            //act
            var res = log.UserToRegister(adn);

            //assert
            res.Should().NotBeNull();
            dbcontext.authorizedUsers.Should().NotBeNull();
            dbcontext.authorizedUsers.Should().OnlyHaveUniqueItems();
            dbcontext.authorizedUsers.Should().HaveCount(3);
        }

        //[Fact]
        [Fact(Skip = "Contains static function")]
        public async void LoginUserController_Logout_ReturrnOk()
        {
            var inmem = new InMemDbs();
            var dbcontext = await inmem.GetDbContext();
            var log = new LoginUserController(dbcontext);

            //arrange
            //act
            var result = log.Logout();
            result.Should().NotBeNull();
        }
    }
}
