using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using volunteer_app.Models;
using Microsoft.EntityFrameworkCore;



namespace volunteer_app.Controllers
{
    public class VolunteerController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        // Logic to return view with data populated from the database

        //private readonly VolunteerModelContext _context;

        //public VolunteerController(VolunteerModelContext context)
        //{
        //    _context = context;
        //}

        // GET: VolunteerModel2
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.VolunteerModel.ToListAsync());
        //}
    }
}