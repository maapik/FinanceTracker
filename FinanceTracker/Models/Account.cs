namespace FinanceTracker.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; } = new();
    }
}