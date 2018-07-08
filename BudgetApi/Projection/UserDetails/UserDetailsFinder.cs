using BudgetApi.Application.Models;
using BudgetApi.Application.Repositories;
using Marten;

namespace BudgetApi.Projection.UserDetails
{
    public class UserDetailsFinder
    {
        public DocumentStore _store { get; }
        public UsersRepository _usersRepository { get; set; }
        public UserDetailsFinder(string connectionString)
        {
            _store = DocumentStore.For(connectionString);
            _usersRepository = new UsersRepository(connectionString);
        }

        public UserDetailsProjection GetUserDetails(int userId)
        {
            User user = _usersRepository.GetUserById(userId);

            using (var session = _store.OpenSession())
            {
                // questId is the id of the stream
                var userDetails = session.Events.AggregateStream<UserDetailsProjection>(user.Account);
                return userDetails;
            }
        }
    }
}