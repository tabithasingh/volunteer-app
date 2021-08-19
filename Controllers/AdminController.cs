using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace volunteer_app.Controllers
{
    public class AdminController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Volunteers()
        //{
        //    return View();
        //}

        //public IActionResult Opportunities()
        //{
        //    return View();
        //}
    }
}
