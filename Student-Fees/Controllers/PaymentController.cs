using Microsoft.AspNetCore.Mvc;
using Student_Fees.Models;
using System;

namespace Student_Fees.Controllers
{
    [Route("payment")]
    public class PaymentController : Controller
    {
        private readonly StudentFeesDbContext StudentFeesDbContext;

        public PaymentController(StudentFeesDbContext studentFeesDbContext)
        {
            StudentFeesDbContext = studentFeesDbContext;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromBody] Payment payment)
        {
            // Check that the ModelState is valid.
            if (ModelState.IsValid)
            {
                //payment.Id = 

                // Set the date of the payment.
                payment.Date = DateTime.Now;

                // Add the payment to the StudentFeesDbContext.
                StudentFeesDbContext.Payments.Add(payment);
                StudentFeesDbContext.SaveChanges();

                return Created("", payment.Id);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}