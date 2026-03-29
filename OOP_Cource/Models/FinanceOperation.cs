using System;

namespace OOP_Cource.Models
{
    public class FinanceOperation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public string Comment { get; set; }
    }
}
