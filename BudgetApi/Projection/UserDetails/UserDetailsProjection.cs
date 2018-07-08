using System;
using BudgetApi.Domain.Model.MoneyTransfer;

public class UserDetailsProjection
{
    public UserDetailsProjection()
    {
        this.Balance = 0;
    }
    public void Apply(FundsAddedEvent fundsAdded)
    {
        this.Balance = this.Balance + fundsAdded.Amount;
    }

    public void Apply(FundsRemovedEvent FundsRemovedEvent)
    {
        this.Balance = this.Balance - FundsRemovedEvent.Amount;
    }

    public double Balance { get; set; }

    public Guid Id { get; set; }


    public override string ToString()
    {
        return $"Account '{Id}' has balance of {Balance}";
    }
}