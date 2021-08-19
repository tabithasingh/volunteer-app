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

        //static IList<Opportunity> opportunityList = new List<Opportunity> {
        //    new Opportunity() {Id = 1, Title = "Opportunity1"}
        //};

        // GET: Opportunity

        //public IActionResult Opportunities()
        //{
        //    return View(opportunityList);
        //}




        //public ViewResult List() => View(repository.Opportunities);

        // Random copy paste code that probably won't work
        //public ViewResult Items(int id)
        //{
        //    string item = repository.Opportunities();
        //    return View(Items);
        //}


        public IActionResult Opportunities()
        {
            return View(repository.Opportunities);
        }

    }
}
