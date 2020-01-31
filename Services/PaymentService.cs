using Jednoreki.Entities;
using Jednoreki.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jednoreki.Services
{
    public interface IPaymentService
    {
        Payment Create(Payment payment);
        IEnumerable<Payment> GetAll();
        IEnumerable<Payment> GetByUserId(int userId);
        void Delete(int id);
    }

    public class PaymentService : IPaymentService
    {
        private PaymentContext _context;
        private UserContext _user_context;
        public PaymentService(PaymentContext context, UserContext userContext)
        {
            _context = context;
            _user_context = userContext;
        }

        public Payment Create(Payment payment)
        {
            payment.Date = System.DateTime.Now;
            _context.Payments.Add(payment);
            _context.SaveChanges();


            //update user balance by payment amount
            var user = _user_context.Users.Find(payment.UserId);
            if (user == null)
                throw new AppException("User not found");

            user.Balance += payment.Amount;
            _user_context.Users.Update(user);
            _user_context.SaveChanges();


            return payment;
        }

        public IEnumerable<Payment> GetAll()
        {
            return _context.Payments;
        }

        public IEnumerable<Payment> GetByUserId(int userId)
        {
            return from payments in _context.Payments
                      where payments.UserId == userId
                      select payments;
        }

        public void Delete(int id)
        {
            var payment = _context.Payments.Find(id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                _context.SaveChanges();
            }
        }
    }
}
