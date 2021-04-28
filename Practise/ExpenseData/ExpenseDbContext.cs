using ExpenseModels;
using Microsoft.EntityFrameworkCore;


namespace ExpenseData
{
    public class ExpenseDbContext :DbContext
    {
        private readonly string connectionStr = @"Data Source=MYDESKTOP;Initial Catalog=Expense;User ID=leo;Password=123456;" +
            "Connect Timeout=30;";//Application Name = Expense App;
        public DbSet<Expense> Expenses { get; set; }

        public DbSet<Spender> Spenders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionStr);
        }
    }
}
