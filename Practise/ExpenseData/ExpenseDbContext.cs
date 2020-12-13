using ExpenseModels;
using Microsoft.EntityFrameworkCore;


namespace ExpenseData
{
    public class ExpenseDbContext :DbContext
    {
        public DbSet<Expense> Expenses { get; set; }

        public DbSet<Spender> Spenders { get; set; }

    }
}
