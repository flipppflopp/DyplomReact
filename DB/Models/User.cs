using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DB.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public double Balance { get; set; }

        public bool IsAdmin { get; set; }

        public string Token { get; set; }
    }
}