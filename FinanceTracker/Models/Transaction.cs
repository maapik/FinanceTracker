using System;

namespace FinanceTracker.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Description { get; set; } = string.Empty;

        public string CategoryName { get; set; } = string.Empty;
        public string Type { get; set; } = "Expense";

        public int AccountId { get; set; }
        public Account? Account { get; set; }
    }
}