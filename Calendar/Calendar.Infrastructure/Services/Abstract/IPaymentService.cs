using Calendar.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calendar.Infrastructure.Services.Abstract
{
    public interface IPaymentService
    {
        Task Add(Payments payment);
        Task Delete(Payments payment);
        Task Update(Payments payment);
        Task<Payments> Get(Guid id);
        Task<IEnumerable<Payments>> GetAll();
        Task Save();
        void Dispose();
    }
}
