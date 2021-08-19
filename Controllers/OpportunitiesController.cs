using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AuthSystem.Models;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthSystem.Controllers
{
    public class OpportunitiesController : Controller
    {
        private IOpportunityRepository repository;
        public OpportunitiesController(IOpportunityRepository repo)
        {
            repository = repo;
            Debug.WriteLine("OpportunitiesController called");
        }
        /////////

        public ActionResult Opportunities(string sortOrder)
        {
            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            var opportunities = from opportunity in repository.Opportunities
                                select opportunity;
            switch (sortOrder)
            {
                case "title_desc":
                    opportunities = opportunities.OrderByDescending(opportunity => opportunity.Title);
                    break;

                default:
                    opportunities = opportunities.OrderBy(opportunity => opportunity.Title);
                    break;
            }
            return View(opportunities.ToList());
        }




        //public ViewResult List() => View(repository.Opportunities);


        //public IActionResult Opportunities()
        //{
        //    return View(repository.Opportunities);
        //}

    }
}
