﻿using Calendar.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calendar.Core.Repository.Abstract
{
    public interface IMonthsRepository
    {
        Task<Months> Get(int id);
        Task<Months> GetByName(string name);
        Task SaveChanges();
        Task Delete(Months months);
        Task<IEnumerable<Months>> GetAll();
        Task Update(Months months);
    }
}
