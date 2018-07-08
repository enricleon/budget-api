using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using BudgetApi.Models;
using BudgetApi.Repositories;

namespace BudgetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersRepository _usersRepository;
        public UsersController()
        {
            string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            _usersRepository = new UsersRepository(connectionString);
        }

        // GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _usersRepository.GetAllUsers()?.ToArray();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return _usersRepository.GetUserById(id);
        }

        // POST api/users
        [HttpPost]
        public ActionResult<int> Post([FromBody] string name)
        {
            return _usersRepository.AddNewUser(name);
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string name)
        {
            User user = _usersRepository.GetUserById(id);
            user.Name = name;

            _usersRepository.AddNewUser(user);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _usersRepository.DeleteById(id);
        }
    }
}
