using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public class Organization
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Resource { get; set; }
    }
}