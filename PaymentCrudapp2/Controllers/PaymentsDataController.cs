using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PaymentCrudapp2.Models;

namespace PaymentCrudapp2.Controllers
{
    public class PaymentsDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/PaymentsData/ListPayments
        [HttpGet]
        public IEnumerable<PaymentDto> ListPayments()
        {
            List<Payment> Payments = db.Payments.ToList();
            List<PaymentDto> PaymentDtos = new List<PaymentDto>();

            Payments.ForEach(a => PaymentDtos.Add(new PaymentDto(){
                PaymentId = a.PaymentId,
                PaymentDate = a.PaymentDate,
                Amount = a.Amount,
                Name = a.User.Name,
                Description = a.Transaction.Description
            }));

            return PaymentDtos;
        }

        // GET: api/PaymentsData/FindPayment/5
        [ResponseType(typeof(Payment))]
        [HttpGet]
        public IHttpActionResult FindPayment(int id)
        {
            Payment Payment = db.Payments.Find(id);
            PaymentDto PaymentDto = new PaymentDto() {
                PaymentId = Payment.PaymentId,
                PaymentDate = Payment.PaymentDate,
                Amount = Payment.Amount,
                Name = Payment.User.Name,
                Description = Payment.Transaction.Description

            };

            if (Payment == null)
            {
                return NotFound();
            }

            return Ok(PaymentDto);
        }

        // POST: api/PaymentsData/UpdatePayment/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdatPayment(int id, Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != payment.PaymentId)
            {
                return BadRequest();
            }

            db.Entry(payment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PaymentsData/AddPayment
        [ResponseType(typeof(Payment))]
        [HttpPost]
        public IHttpActionResult AddPayment(Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Payments.Add(payment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = payment.PaymentId }, payment);
        }

        // POST: api/PaymentsData/DeletePayment/5
        [ResponseType(typeof(Payment))]
        [HttpPost]
        public IHttpActionResult DeletePayment(int id)
        {
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return NotFound();
            }

            db.Payments.Remove(payment);
            db.SaveChanges();

            return Ok(payment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaymentExists(int id)
        {
            return db.Payments.Count(e => e.PaymentId == id) > 0;
        }
    }
}