using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Fees.Models;
using System.Collections.Generic;
using System.Linq;

namespace Student_Fees.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentFeesDbContext StudentFeesDbContext;

        public HomeController(StudentFeesDbContext studentFeesDbContext)
        {
            StudentFeesDbContext = studentFeesDbContext;
        }

        public IActionResult Index()
        {
            // Get the students and their payment history from the StudentFeesDbContext.
            List<Student> students = StudentFeesDbContext.Students.AsNoTracking().Include(r => r.Payments).ToList();

            return View(students);
        }
    }
}