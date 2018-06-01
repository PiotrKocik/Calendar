using Calendar.Core.Models;
using Calendar.Core.Repository.Abstract;
using Calendar.Infrastructure.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calendar.Infrastructure.Services
{
    public class MonthsService : IMonthsService
    {
        private IMonthsRepository monthsRepository;
        public MonthsService(IMonthsRepository monthsRepository)
        {
            this.monthsRepository = monthsRepository;
        }
        public async Task Delete(Months months)
        {
            await this.monthsRepository.Delete(months);
        }

        public async Task<Months> Get(int id)
        {
            return await this.monthsRepository.Get(id);
        }

        public async Task<Months> GetByName(string name)
        {
            return await this.monthsRepository.GetByName(name);
        }

        public async Task<IEnumerable<Months>> GetAll()
        {
            return await this.monthsRepository.GetAll();
        }

        public async Task SaveChanges()
        {
            await this.monthsRepository.SaveChanges();
        }

        public async Task Update(Months months)
        {
            var original = this.monthsRepository.Get(months.Id);

            if (original != null)
            {
               await this.monthsRepository.Update(months);
            }
        }
    }
}
