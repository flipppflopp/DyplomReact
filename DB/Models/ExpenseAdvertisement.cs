using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class ExpenseAdvertisement
    {
        [Key]
        public int ID { get; set; }

        public int ExpenseID { get; set; }

        public int AdvertisementID { get; set; }
    }
}
