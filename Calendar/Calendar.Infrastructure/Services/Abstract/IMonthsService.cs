using Calendar.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calendar.Infrastructure.Services.Abstract
{
    public interface IMonthsService
    {
        Task Delete(Months months);
        Task Update(Months months);
        Task<Months> Get(int id);
        Task<Months> GetByName(string name);
        Task<IEnumerable<Months>> GetAll();
        Task SaveChanges();
    }
}
