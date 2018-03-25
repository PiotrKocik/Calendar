using Calendar.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Core.Context
{
    public class PaymentDbContext : IdentityDbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> conn) : base(conn)
        {

        }

        public DbSet<Payments> Payments { get; set; }
        public DbSet<Months> Months { get; set; }

        public static PaymentDbContext Create(DbContextOptions<PaymentDbContext> conn)
        {
            return new PaymentDbContext(conn);
        }
    }
}
