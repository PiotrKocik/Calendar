using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calendar.Infrastructure.ViewModels
{
    public class MonthsViewModels
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        //public int PaymentsId { get; set; }
        // public ICollection<PaymentsViewModels> PaymentsViewModel { get; set; }
    }
}