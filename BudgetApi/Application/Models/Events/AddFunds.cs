namespace BudgetApi.Application.Models.Events {
    public class AddFunds {
        public AddFunds()
        {
            
        }

        public int UserId { get; set; }
        public double Amount { get; set; }
    }
}