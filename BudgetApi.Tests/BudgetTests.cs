using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BudgetApi.Tests;
using BudgetApi.Application.Controllers;
using BudgetApi.Application.Models;
using BudgetApi.Application.Models.Events;

namespace BudgetApi.Tests
{
    [TestClass]
    public class ValuesTests : PostgresTestBase
    {
        [TestMethod]
        public void Get_NoUsersCreated_ReturnEmptyList()
        {
            var controller = new UsersController();

            var result = controller.Get();

            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Post_SingleUser_GetByIdReturnsUser()
        {
            var controller = new UsersController();

            var postResult = controller.Post("Enric");
            var result = controller.Get(postResult);

            Assert.AreEqual("Enric", result.Name);
        }

        [TestMethod]
        public void Add_Funds_GetBalanceIsFund()
        {
            var usersController = new UsersController();
            var moneyController = new MoneyController();

            int user1 = usersController.Post("User1");
            int user2 = usersController.Post("User2");

            moneyController.Add(new AddFunds {
                UserId = user1, 
                Amount = 20
            });
            var response = usersController.Balance(user1);

            Assert.AreEqual(20, response.Balance);
        }
    }
}