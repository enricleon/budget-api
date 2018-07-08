using System;

namespace BudgetApi.Application.Models
{
    public class User {
        public int Id { get; set; }
        public Guid Account { get; set; }
        public string Name { get; set; }
    }
}