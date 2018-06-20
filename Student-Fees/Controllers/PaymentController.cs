using Microsoft.AspNetCore.Mvc;
using Student_Fees.Models;
using System;

namespace Student_Fees.Controllers
{
    [Route("payment")]
    public class PaymentController : Controller
    {
        private readonly StudentFeesDbContext StudentFeesDbContext;

        /// <summary>
        /// Constructor. Gets the StudentFeesDbContext from Dependency Injection.
        /// </summary>
        /// <param name="studentFeesDbContext"></param>
        public PaymentController(StudentFeesDbContext studentFeesDbContext)
        {
            StudentFeesDbContext = studentFeesDbContext;
        }

        /// <summary>
        /// API Method to create a new payment. Ptoteched from CSRF via ValidateAntiForgeryToken in the request header.
        /// </summary>
        /// <param name="payment">The payment to insert - Includes a populated StudentId and Amount.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromBody] Payment payment)
        {
            try
            {
                // Check that the ModelState is valid.
                if (ModelState.IsValid)
                {
                    // Set the date of the payment.
                    payment.Date = DateTime.Now;

                    // Add the payment to the StudentFeesDbContext.
                    StudentFeesDbContext.Payments.Add(payment);
                    StudentFeesDbContext.SaveChanges();

                    // Return a 201 created response.
                    return Created("", payment.Id);
                }
                else
                {
                    // Return a 400 bad request.
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                // Return a 500 error.
                return StatusCode(500);
            }
        }
    }
}