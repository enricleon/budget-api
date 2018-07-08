using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using BudgetApi.Application.Models;
using BudgetApi.Application.Repositories;
using BudgetApi.Domain.Commands;

namespace BudgetApi.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyController : ControllerBase
    {
        private readonly MoneyCommands _moneyCommands;
        public MoneyController()
        {
            string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            _moneyCommands = new MoneyCommands(connectionString);
        }

        // POST api/money/add
        [HttpPost]
        public void Add([FromBody] double amount, [FromBody] int userId)
        {
            _moneyCommands.AddFunds(userId, amount);
        }

        // POST api/money/transfer
        [HttpPost]
        public void Transfer([FromBody] double amount, [FromBody] int userId, [FromBody] int targetUserId)
        {
            _moneyCommands.TransferFunds(userId, targetUserId, amount);
        }
    }
}
