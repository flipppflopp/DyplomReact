using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public class Advertisement
    {
        [Key]
        public int ID { get; set; }
        
        public string Category { get; set; }

        public string Header { get; set; }

        public string Text { get; set; }

        public double CollectedSum { get; set; }

        public double GoalSum { get; set; }

        public int VolonteerInfoID { get; set; }
    }
}