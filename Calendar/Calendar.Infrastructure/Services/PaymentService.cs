using Calendar.Core.Models;
using Calendar.Core.Repository.Abstract;
using Calendar.Infrastructure.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calendar.Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        private IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task Add(Payments payment)
        {
           await _paymentRepository.Add(payment);
        }

        public async Task Delete(Payments payment)
        {
            await _paymentRepository.Delete(payment);
        }

        public void Dispose()
        {
            _paymentRepository.Dispose();
        }

        public async Task<Payments> Get(int id)
        {
            return await _paymentRepository.Get(id);
        }

        public async Task<IEnumerable<Payments>> GetAll()
        {
            return await _paymentRepository.GetAll();
        }

        public async Task<IEnumerable<Payments>> GetFilteredPayments(string name)
        {
            return await _paymentRepository.GetFilteredPayments(name);
        }

        public async Task Save()
        {
           await _paymentRepository.SaveChanges();
        }

        public async Task Update(Payments payment)
        {
            var original = _paymentRepository.Get(payment.Id);

            if (original != null)
            {
               await _paymentRepository.Update(payment);
            }
        }
    }
}
