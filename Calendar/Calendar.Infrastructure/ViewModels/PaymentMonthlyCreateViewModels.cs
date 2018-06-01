using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Infrastructure.ViewModels
{
    public class PaymentMonthlyCreateViewModels
    {
        public string Name { get; set; }
        public string MonthName { get; set; }
        public decimal Price { get; set; }
        public bool Check { get; set; }
    }
}
