
namespace BudgetApi.Domain.Model.MoneyTransfer
{
    public class FundsAddedEvent
    {
        public FundsAddedEvent()
        {
        }

        public FundsAddedEvent(int userId, double amount)
        {
            UserId = userId;
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