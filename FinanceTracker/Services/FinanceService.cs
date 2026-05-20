using FinanceTracker.Data;
using FinanceTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Services
{
    public class FinanceService
    {
        private readonly AppDbContext _context;

        public FinanceService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Account>> GetAccountsAsync() => await _context.Accounts.ToListAsync();

        public async Task<List<Transaction>> GetTransactionsAsync() =>
            await _context.Transactions
                .Include(t => t.Account)
                .OrderByDescending(t => t.Date)
                .ToListAsync();

        public async Task AddTransactionAsync(Transaction transaction)
        {
            var account = await _context.Accounts.FindAsync(transaction.AccountId);

            if (account != null)
            {
                if (transaction.Type == "Income")
                    account.Balance += transaction.Amount;
                else
                    account.Balance -= transaction.Amount;
            }

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task AddAccountAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAccountAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAccountAsync(int id)
        {
            var account = await _context.Accounts.Include(a => a.Transactions).FirstOrDefaultAsync(a => a.Id == id);
            if (account != null)
            {
                _context.Transactions.RemoveRange(account.Transactions);
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SeedDefaultDataAsync()
        {
            if (!_context.Accounts.Any())
            {
                _context.Accounts.Add(new Account { Name = "Основной счет", Balance = 0 });
                await _context.SaveChangesAsync();
            }
        }
    }
}