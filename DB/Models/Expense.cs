using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public class Expense
    {
        [Key]
        public int ID { get; set; }
        
        public double Amount { get; set; }

        public DateTime Date { get; set; }
        
        public int UserId { get; set; }

        public int AdId { get; set; }
    }
}