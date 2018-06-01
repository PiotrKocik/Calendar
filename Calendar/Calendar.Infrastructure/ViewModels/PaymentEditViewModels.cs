using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Infrastructure.ViewModels
{
    public class PaymentEditViewModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Check { get; set; }
    }
}
