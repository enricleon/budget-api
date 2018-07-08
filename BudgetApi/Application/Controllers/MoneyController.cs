using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using BudgetApi.Application.Models;
using BudgetApi.Application.Repositories;
using BudgetApi.Application.Models.Events;
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
        [HttpPost("add")]
        public void Add([FromBody] AddFunds addFunds)
        {
            _moneyCommands.AddFunds(addFunds.UserId, addFunds.Amount);
        }

        // POST api/money/transfer
        [HttpPost("transfer")]
        public void Transfer([FromBody] TransferFunds transfer)
        {
            _moneyCommands.TransferFunds(transfer.UserId, transfer.TargetUserId, transfer.Amount);
        }
    }
}
