using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseModels
{
    public class Expense
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int SpenderId { get; set; }
        public string Comment { get; set; }



    }
}
