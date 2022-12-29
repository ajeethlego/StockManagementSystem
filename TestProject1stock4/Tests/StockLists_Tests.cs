using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1stock4.DataConTest;
using Stock4.Models;
using javax.tools;


namespace TestProject1stock4.Tests
{
    public class StockLists_Tests
    {
        InMemoryDatabase db = new InMemoryDatabase();

        [Fact]
        public async void Stocklist_AddnewStock_ReturnsStock()
        {
            var Id = 100;
            var StockList = new StockList
            {
                StockId = Id,
                StockName = "RelCap",
                StockPrice = 40090

            };
            var dbContext = await db.GetDatabaseContext();
            var foodProvider = new FoodProvider(dbContext);
            //Act
            var result = await foodProvider.AddNewFood(Food);
            //Assert
            result.Should().NotBeNull();
            var foodList = await foodProvider.GetAll();
            foodList.Should().HaveCount(8);
        }

    }
}
