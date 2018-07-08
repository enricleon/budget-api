using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using BudgetApi.Application.Models;
using BudgetApi.Application.Repositories;
using BudgetApi.Projection.UserDetails;

namespace BudgetApi.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersRepository _usersRepository;
        private readonly UserDetailsFinder _userDetailsFinder;
        public UsersController()
        {
            string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            _usersRepository = new UsersRepository(connectionString);
            _userDetailsFinder = new UserDetailsFinder(connectionString);
        }

        // GET api/users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _usersRepository.GetAllUsers()?.ToArray();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _usersRepository.GetUserById(id);
        }

        // POST api/users/5/balance
        [HttpGet("{id}/balance")]
        public UserDetailsProjection Balance(int id)
        {
            return _userDetailsFinder.GetUserDetails(id);
        }

        // POST api/users
        [HttpPost]
        public int Post([FromBody] string name)
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
