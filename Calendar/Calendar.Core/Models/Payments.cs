﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Core.Models
{
    public class Payments
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MonthName { get; set; }
        public decimal Price { get; set; }
        public bool Check { get; set; }
        public int MonthsId { get; set; }
        public virtual Months Months { get; set; }
        //public IEnumerable<Payments> PaymentsList { get; set; }
        //public string Month { get; set; }
        //public int Year { get; set; }
    }
}
