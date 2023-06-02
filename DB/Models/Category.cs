using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        
        public string Name { get; set; }
    }
}