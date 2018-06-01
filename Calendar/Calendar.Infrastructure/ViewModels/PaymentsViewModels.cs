using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calendar.Infrastructure.ViewModels
{
    public class PaymentsViewModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MonthName { get; set; }
        public decimal Price { get; set; }
        public bool Check { get; set; }
        public int MonthsId { get; set; }
    }
}