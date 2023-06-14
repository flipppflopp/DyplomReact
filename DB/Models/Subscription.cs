﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class Subscription
    {
        [Key]
        public int ID { get; set; }

        public int UserID { get; set; }

        public int VolonteerID { get; set; }
    }
}
