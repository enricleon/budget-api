using BudgetApi.Application.Repositories;
using BudgetApi.Domain.Model.MoneyTransfer;
using Marten;

namespace BudgetApi.Domain.Commands
{
    public class MoneyCommands
    {
        public DocumentStore _store { get; }
        public UsersRepository _usersRepository { get; set; }
        public MoneyCommands(string connectionString)
        {
            _store = DocumentStore.For(connectionString);
            _usersRepository = new UsersRepository(connectionString);
        }

        public void AddFunds(int userId, double amount)
        {
            var user = _usersRepository.GetUserById(userId);

            using (var session = _store.OpenSession())
            {
                var addFunds = new FundsAddedEvent(userId, amount);

                session.Events.Append(user.Account, addFunds);
                session.SaveChanges();
            }
        }

        public void TransferFunds(int userId, int targetUserId, double amount)
        {
            var user = _usersRepository.GetUserById(userId);
            var targetUser = _usersRepository.GetUserById(targetUserId);

            using (var session = _store.OpenSession())
            {
                var addedFunds = new FundsAddedEvent(targetUserId, amount);
                var removedFunds = new FundsRemovedEvent(userId, amount);

                session.Events.Append(targetUser.Account, addedFunds);
                session.Events.Append(user.Account, removedFunds);
                session.SaveChanges();
            }
        }
    }
}