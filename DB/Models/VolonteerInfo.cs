using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DB.Models
{
    public class VolonteerInfo
    {
        [Key]
        public int Id { get; set; }
        
        public int UserId { get; set; }
        
        public string Status { get; set; }
    }
}