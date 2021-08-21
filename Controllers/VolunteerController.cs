using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using volunteer_app.Models;
using Microsoft.EntityFrameworkCore;



namespace volunteer_app.Controllers
{
    public class VolunteerController : Controller
    {
        private readonly ApplicationDbContext _db;
        
        public VolunteerController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<VolunteerList> VolunteerList = _db.VolunteerList;
            return View(VolunteerList);
        }

        //This method leads you to the page that allows you to add new volunteers
        public IActionResult AddVolunteer()
        {
            return View();
        }

        //This method will actually add the new volunteer to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddVolunteer(VolunteerList vol)
        {
            if (ModelState.IsValid)
            {
                _db.VolunteerList.Add(vol);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vol);
        }

        //This method leads you to the page that allows you to edit the volunteers
        public IActionResult EditVolunteer(int? Id)
        {

            if (Id == 0)
            {
                return NotFound();
            }

            var obj = _db.VolunteerList.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        //This method will update the edit made to the volunteer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditVolunteer(VolunteerList vol)
        {
            if (ModelState.IsValid)
            {
                _db.VolunteerList.Update(vol);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vol);
        }

        public IActionResult DeleteVolunteer(int? Id)
        {

            if (Id == 0)
            {
                return NotFound();
            }

            var obj = _db.VolunteerList.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        //This method will update the database by deleting the entity
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteVolunteerEntity(int? Id)
        {
            var entity = _db.VolunteerList.Find(Id);
            _db.VolunteerList.Remove(entity);
            _db.SaveChanges();
            return RedirectToAction("Index");

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
