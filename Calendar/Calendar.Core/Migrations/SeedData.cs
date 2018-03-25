using Calendar.Core.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calendar.Core.Migrations
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<PaymentDbContext>();
            context.Database.EnsureCreated();
            if (!context.Months.Any())
            {
                context.Months.Add(new Models.Months() { Name = "Styczen" });
                context.Months.Add(new Models.Months() { Name = "Luty" });
                context.Months.Add(new Models.Months() { Name = "Marzec" });
                context.Months.Add(new Models.Months() { Name = "Kwiecien" });
                context.Months.Add(new Models.Months() { Name = "Maj" });
                context.Months.Add(new Models.Months() { Name = "Czerwiec" });
                context.Months.Add(new Models.Months() { Name = "Lipiec" });
                context.Months.Add(new Models.Months() { Name = "Sierpien" });
                context.Months.Add(new Models.Months() { Name = "Wrzesien" });
                context.Months.Add(new Models.Months() { Name = "Pazdziernik" });
                context.Months.Add(new Models.Months() { Name = "Listopad" });
                context.Months.Add(new Models.Months() { Name = "Grudzien" });

                context.SaveChanges();
            }

        }
    }
}
