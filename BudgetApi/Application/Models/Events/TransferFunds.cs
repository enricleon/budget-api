namespace BudgetApi.Application.Models.Events {
    public class TransferFunds {
        public TransferFunds()
        {
            
        }

        public int UserId { get; set; }
        public int TargetUserId { get; set; }
        public double Amount { get; set; }
    }
}