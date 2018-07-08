
namespace BudgetApi.Domain.Model.MoneyTransfer
{
    public class FundsRemovedEvent
    {
        public FundsRemovedEvent()
        {
        }

        public FundsRemovedEvent(int userId, double amount)
        {
            UserId = UserId;
            Amount = amount;
        }

        public int UserId { get; set; }
        public double Amount { get; set; }
        public override string ToString()
        {
            return $"User {UserId} has just added {Amount} to the current balance";
        }
    }
}