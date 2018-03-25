using AutoMapper;
using Calendar.Core.Models;
using Calendar.Infrastructure.Extensions;
using Calendar.Infrastructure.Services.Abstract;
using Calendar.Infrastructure.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PaymentsController : Controller
    {
        private IPaymentService paymentService;
        private IMonthsService monthsService;
        private IMapper mapper;

        public PaymentsController(IPaymentService paymentService, IMapper mapper, IMonthsService monthsService)
        {
            this. paymentService = paymentService;
            this.mapper = mapper;
            this.monthsService = monthsService;
        }

        // GET: Payments
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var mappedPayments = mapper.Map<IEnumerable<PaymentsViewModels>>(await paymentService.GetAll());

            return View(mappedPayments);
        }
        [HttpPost]
        public async Task<IActionResult> Index([FromBody] IEnumerable<PaymentsViewModels> payments)
        {

            foreach (var payment in payments)
            {
                var paymentsDB = await paymentService.GetOrFail(payment.Id);
                paymentsDB.Check = payment.Check;
            }
            return View();
        }
        // GET: Payments/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            var mappedPayment = mapper.Map<PaymentsViewModels>(await paymentService.Get(id));
            return View(mappedPayment);
        }

        // GET: Payments/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var months = await monthsService.GetAll();
            IEnumerable<SelectListItem> mappedMonths = months
                  .Select(c => new SelectListItem
                  {
                      Value = c.Id.ToString(),
                      Text = c.Name
                  });
            ViewBag.MonthsId = mappedMonths;
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PaymentsAddViewModels payments)
        {
            if (ModelState.IsValid)
            {
                var toAdd = mapper.Map<Payments>(payments);
                var months = await monthsService.GetAll();
                foreach (var month in months)
                {
                    var toAddNew = new Payments();
                    toAddNew.Check = false;
                    toAddNew.MonthName = month.Name;
                    toAddNew.MonthsId = month.Id;
                    toAddNew.Name = toAdd.Name;
                    toAddNew.Price = toAdd.Price;
                    await paymentService.Add(toAddNew);
                }
                await paymentService.Save();
                return RedirectToAction("Create");
            }
            return View(payments);
        }

        // GET: Payments/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var toAdd = mapper.Map<PaymentsViewModels>(await paymentService.GetOrFail(id));
            return View(toAdd);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PaymentsViewModels payments)
        {
            var paymentToUpdate = mapper.Map<Payments>(payments);
            await paymentService.Update(paymentToUpdate);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> IndexInfo()
        {
            var b = mapper.Map<IEnumerable<PaymentsViewModels>>(await paymentService.GetAll());

            return View(b);
        }


        // GET: Payments/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var payments = mapper.Map<PaymentsViewModels>(await paymentService.GetOrFail(id));
            return View(payments);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            Payments payments = await paymentService.GetOrFail(id);
            await paymentService.Delete(payments);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                paymentService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
