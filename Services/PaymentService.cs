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
    }
}
