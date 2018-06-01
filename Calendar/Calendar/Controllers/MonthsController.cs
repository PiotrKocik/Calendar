using AutoMapper;
using Calendar.Core.Models;
using Calendar.Infrastructure.Services.Abstract;
using Calendar.Infrastructure.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calendar.Controllers
{

    [Authorize]
    [Route("api/[controller]/[action]")]
    public class MonthsController : Controller
    {
        private IMonthsService monthsService;
        private IMapper mapper;

        public MonthsController(IMonthsService monthsService, IMapper mapper)
        {
            this.monthsService = monthsService;
            this.mapper = mapper;
        }

        //GET: Months
        [HttpGet]
        public async Task<IEnumerable<MonthsViewModels>> GetAll()
        {
            IEnumerable<MonthsViewModels> b;
            try
            {
                b = mapper.Map<IEnumerable<MonthsViewModels>>(await monthsService.GetAll());
            }
            catch { b = null; }
            return b;
        }

        //GET: Months/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var mappedMonth = mapper.Map<MonthsViewModels>(await monthsService.Get(id));
            return View(mappedMonth);
        }


        // GET: Months/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var toAdd = mapper.Map<MonthsViewModels>(await monthsService.Get(id));
            return View(toAdd);
        }

        // POST: Months/Edit/5
        [HttpPost]
        public IActionResult Edit([FromBody] Months months)
        {
            var monthToUpdate = mapper.Map<Months>(months);
            monthsService.Update(monthToUpdate);
            return RedirectToAction("Index");
        }

    }
}
