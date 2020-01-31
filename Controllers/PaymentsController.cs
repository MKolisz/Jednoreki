using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jednoreki.Entities;
using Jednoreki.Helpers;
using Jednoreki.Models.Payments;
using Jednoreki.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jednoreki.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly PaymentContext _context;
        private IPaymentService _paymentService;
        private IMapper _mapper;

        public PaymentsController(PaymentContext context, IPaymentService paymentService, IMapper mapper)
        {
            _context = context;
            _paymentService = paymentService;
            _mapper = mapper;
        }

        // POST: api/Payments/MakePayment
        [HttpPost("MakePayment")]
        public IActionResult MakePayment([FromBody]PaymentModel model)
        {
            // map model to entity
            var payment = _mapper.Map<Payment>(model);

            try
            {
                // create payment
                _paymentService.Create(payment);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET: api/Payments
        [HttpGet]
        public IActionResult GetAll()
        {
            var payments = _paymentService.GetAll();
            return Ok(payments);
        }

        // GET: api/Payments/5
        [HttpGet("{userId}")]
        public IActionResult GetById(int userId)
        {
            var payments = _paymentService.GetByUserId(userId);
            return Ok(payments);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _paymentService.Delete(id);
            return Ok();
        }
    }
}