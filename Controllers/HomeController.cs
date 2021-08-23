using AuthSystem.Areas.Identity.Data;
using AuthSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace AuthSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            Debug.WriteLine("Index called.");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult VolunteerOpportunityMatches()
        {

            var volunteers = _db.VolunteerList.ToList();


            var opportunities = _db.OpportunityList.ToList();

            string[] vAvailability;
            string[] oAvailability;

            // Dictionary with volunteer as key, list of opportunities as value
           //Dictionary<VolunteerList, List<OpportunityList>> vMatches = new Dictionary<VolunteerList, List<OpportunityList>>();
           Dictionary<VolunteerList, List<string>> vMatches = new Dictionary<VolunteerList, List<string>>();
            

            foreach (var volunteer in volunteers) {
                vAvailability = volunteer.Availability.Split(',');
                //List<OpportunityList> oMatches = new List<OpportunityList>();
                List<string> oMatches = new List<string>();
                    foreach (var opportunity in opportunities)
                {
                    oAvailability = opportunity.Availability.Split(',');

                    // Checks if there's any overlap between the volunteer and opportunity availability
                    if (vAvailability.Where(oAvailability.Contains).Count() > 0)
                    {
                        oMatches.Add(opportunity.OpportunityTitle);
                    }

                }
                vMatches.Add(volunteer, oMatches);
            }

            ViewBag.Keys = vMatches.Keys.ToList();
            ViewBag.Values = vMatches.Values;

            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
