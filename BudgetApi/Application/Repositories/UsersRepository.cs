using System;
using System.Collections.Generic;
using System.Linq;
using BudgetApi.Application.Models;
using Marten;

namespace BudgetApi.Application.Repositories
{
    public class UsersRepository
    {
        private readonly string _connectionString;

        public UsersRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDocumentStore Store
        {
            get
            {
                var store = DocumentStore.For(_ => { _.Connection(_connectionString); });
                return store;
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            using (var session = Store.QuerySession())
            {
                return session.Query<User>()
                               .ToArray();
            }
        }

        public User GetUserById(int id)
        {
            using (var session = Store.QuerySession())
            {
                return session.Load<User>(id);
            }
        }

        public int AddNewUser(string name)
        {
            var newUser = new User { 
                Name = name,
                Account = Guid.NewGuid()
            };

            using (var session = Store.OpenSession())
            {
                session.Store(newUser);

                session.SaveChanges();
            }

            return newUser.Id;
        }

        public void AddNewUser(User user)
        {
            using (var session = Store.OpenSession())
            {
                session.Store(user);

                session.SaveChanges();
            }
        }

        public void DeleteById(int id)
        {
            using (var session = Store.OpenSession())
            {
                session.Delete<User>(id);

                session.SaveChanges();
            }
        }
    }
}