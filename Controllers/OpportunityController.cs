using AuthSystem.Areas.Identity.Data;
using AuthSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Controllers
{
    public class OpportunityController : Controller
    {
        private readonly ApplicationDbContext _db;

        public OpportunityController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<OpportunityList> OppList = _db.OpportunityList;
            return View(OppList);
        }

        //This method leads you to the page that allows you to add new opportunities
        public IActionResult AddOpportunity() 
        {
            return View();
        }

        //This method will actually add the new opportunity to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOpportunity(OpportunityList opp)
        {
            if (ModelState.IsValid)
            {
                _db.OpportunityList.Add(opp);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(opp);
        }

        //This method leads you to the page that allows you to edit the opportunities
        public IActionResult EditOpportunity(int? Id)
        {
            
            if (Id == 0)
            {
                return NotFound();
            }
            
            var obj = _db.OpportunityList.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
            
        }

        //This method will update the edit made to the opportunity
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditOpportunity(OpportunityList opp)
        {
            if (ModelState.IsValid)
            {
                _db.OpportunityList.Update(opp);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(opp);
        }

        //This method will get the specific entity that needs to be deleted
        public IActionResult DeleteOpportunity(int? Id)
        {

            if (Id == 0)
            {
                return NotFound();
            }

            var obj = _db.OpportunityList.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        //This method will update the database by deleting the entity
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteOpportunityEntity(int? Id)
        {
            var entity = _db.OpportunityList.Find(Id);            
            _db.OpportunityList.Remove(entity);
            _db.SaveChanges();
            return RedirectToAction("Index");           
            
        }

    }
}
