using Microsoft.AspNetCore.Mvc;

namespace Student_Fees.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}