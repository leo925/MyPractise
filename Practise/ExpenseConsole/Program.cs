using ExpenseData;
using ExpenseModels;
using System;

namespace ExpenseConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            context.Database.EnsureCreated();

            AddExpense();
            Console.WriteLine("Hello World!");
        }
        static ExpenseDbContext context = new ExpenseDbContext();
        static void AddExpense()
        {
            var expense = new Expense()
            {
                SpenderId = 1,
                Amount = 15.50M,
                Comment = "grapes",
                Date = DateTime.Now
            };
            context.Expenses.Add(expense);
            context.SaveChanges();
        }
    }
}
