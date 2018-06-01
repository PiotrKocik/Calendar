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
    [Authorize]
    public class PaymentsController : Controller
    {
        private IPaymentService paymentService;
        private IMonthsService monthsService;
        private IMapper mapper;

        public PaymentsController(IPaymentService paymentService, IMapper mapper, IMonthsService monthsService)
        {
            this.paymentService = paymentService;
            this.mapper = mapper;
            this.monthsService = monthsService;
        }

        // GET: Payments
        [HttpGet]
        public async Task<IEnumerable<PaymentsViewModels>> GetAll()
        {
            var mappedPayments = mapper.Map<IEnumerable<PaymentsViewModels>>(await paymentService.GetAll());
            
            return mappedPayments;
        }

        // GET: Payments
        [HttpGet]
        public async Task<IEnumerable<string>> GetFilteredPayments()
        {
            var mappedPayments = mapper.Map<IEnumerable<PaymentsViewModels>>(await paymentService.GetAll());

            return mappedPayments.OrderBy(x => x.Name).Select(x => x.Name).Distinct();
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
        public async Task<PaymentsViewModels> Details(int id)
        {
            var mappedPayment = mapper.Map<PaymentsViewModels>(await paymentService.Get(id));
            return mappedPayment;
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
        public async Task<PaymentsAddViewModels> Create([FromBody] PaymentsAddViewModels payments)
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
            }
            return payments;
        }

        [HttpPost]
        public async Task<PaymentMonthlyCreateViewModels> PaymentMonthCreate([FromBody] PaymentMonthlyCreateViewModels payment)
        {
            if (ModelState.IsValid)
            {
                var month = this.monthsService.GetByName(payment.MonthName);
                var toAdd = mapper.Map<Payments>(payment);
                toAdd.MonthsId = month.Result.Id;
                await paymentService.Add(toAdd);

                await paymentService.Save();
            }
            return payment;
        }

        [HttpGet("{name}")]
        public async Task<IEnumerable<PaymentsViewModels>> FilteredPayments(string name)
        {
            return  this.mapper.Map<IEnumerable<PaymentsViewModels>>(await this.paymentService.GetFilteredPayments(name));
        }

        [HttpGet("{id}")]
        public async Task<PaymentsViewModels> GetById(int id)
        {
            var payment = mapper.Map<PaymentsViewModels>(await paymentService.GetOrFail(id));
            return payment;
        }
        // GET: Payments/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var toAdd = mapper.Map<PaymentsViewModels>(await paymentService.GetOrFail(id));
            return View(toAdd);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        public async Task<PaymentsViewModels> Edit([FromBody] PaymentEditViewModels payments)
        {
            var paymentToUpdate = mapper.Map<Payments>(payments);
            await paymentService.Update(paymentToUpdate);
            await paymentService.Save();
            return mapper.Map<PaymentsViewModels>(paymentToUpdate);
        }

        // POST: Payments/Delete/5
        [HttpDelete("{name}")]
        public async Task<bool> Delete(string name)
        {
            var paymentsToDelete = await this.paymentService.GetFilteredPayments(name);
            foreach (var payment in paymentsToDelete)
            {
                await paymentService.Delete(payment);
            }
            await paymentService.Save();
            return true;
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
