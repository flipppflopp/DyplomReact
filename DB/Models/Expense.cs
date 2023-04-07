using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public class Expense
    {
        [Key]
        public int ID { get; set; }
        
        public int Amount { get; set; }
        
        public int VolonteerInfoID { get; set; }
        
        public string Name { get; set; } = null!;
    }
}