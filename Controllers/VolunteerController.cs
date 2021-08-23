using Microsoft.EntityFrameworkCore;
using AuthSystem.Areas.Identity.Data;
using AuthSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;



namespace AuthSystem.Controllers
{
    public class VolunteerController : Controller
    {
        private readonly ApplicationDbContext _db;

        public VolunteerController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(string status, string option, string searchTerm)
        {

            // Sorts results based on search term in the column specified by 'option'
            switch (option)
            {
                case "reset":
                    return View(_db.VolunteerList.ToList());
                case "first-name":
                    return View(_db.VolunteerList.Where(x => x.FirstName == searchTerm || searchTerm == null).ToList());
                case "last-name":
                    return View(_db.VolunteerList.Where(x => x.LastName == searchTerm || searchTerm == null).ToList());
                case "center-preference":
                    return View(_db.VolunteerList.Where(x => x.OpportunityCenterPreference.Contains(searchTerm) || searchTerm == null).ToList());
                default:
                    break;
            }

            // Sorts results based on approval status
            switch (status)
            {
                case "approved-pending":
                    return View(_db.VolunteerList.Where(x => x.ApprovalStatus == "Approved" || x.ApprovalStatus == "Pending").ToList());
                case "approved":
                    return View(_db.VolunteerList.Where(x => x.ApprovalStatus == "Approved").ToList());
                case "pending":
                    return View(_db.VolunteerList.Where(x => x.ApprovalStatus == "Pending").ToList());
                case "disapproved":
                    return View(_db.VolunteerList.Where(x => x.ApprovalStatus == "Disapproved").ToList());
                case "inactive":
                    return View(_db.VolunteerList.Where(x => x.ApprovalStatus == "Inactive").ToList());
                case "all":
                    return View(_db.VolunteerList.ToList());
                default:
                    break;
            }

            return View(_db.VolunteerList.ToList());
               
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
    }
}
