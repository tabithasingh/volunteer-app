using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AuthSystem.Models;
using System.Diagnostics;

namespace AuthSystem.Controllers
{
    public class OpportunityScaffoldingController : Controller
    {
        private readonly OpportunityModelContext _context;

        public OpportunityScaffoldingController(OpportunityModelContext context)
        {
            _context = context;
        }

        // GET: OpportunityScaffolding
        public async Task<IActionResult> Index(string title, string location, string day_added)
        {
            //var opportunities = from o in _context.Opportunities
            //                    select o;

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    opportunities = opportunities.Where(s => s.Title.Contains(searchString));
            //}

            //return View(await opportunities.ToListAsync());


            DateTime currTime = DateTime.Now;
            DateTime recentDate = DateTime.Now.AddDays(-60);

            // Select dropdown logic
            ViewBag.Location = (from o in _context.Opportunities
                                select o.Location).Distinct();


            if (day_added == "true")
            {
                var filteredOpportunity = from o in _context.Opportunities
                                          orderby o.Day_added
                                          where o.Day_added <= currTime && o.Day_added >= recentDate
                                          select o;
                return View(filteredOpportunity);

            }

            else
            {
                // Filtering logic
                var opportunities = from o in _context.Opportunities
                                    orderby o.Title
                                    where o.Title == title || title == null || title == ""
                                    where o.Location == location || location == null || location == ""
                                    where ((o.Day_added).ToString()) == day_added || day_added == null || day_added == ""
                                    select o;
                return View(opportunities);

            }




            //return View(await _context.Opportunities.ToListAsync());
        }



        // GET: OpportunityScaffolding/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opportunity = await _context.Opportunities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opportunity == null)
            {
                return NotFound();
            }

            return View(opportunity);
        }

        // GET: OpportunityScaffolding/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OpportunityScaffolding/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Day_added,Location")] Opportunity opportunity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(opportunity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(opportunity);
        }

        // GET: OpportunityScaffolding/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opportunity = await _context.Opportunities.FindAsync(id);
            if (opportunity == null)
            {
                return NotFound();
            }
            return View(opportunity);
        }

        // POST: OpportunityScaffolding/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Day_added,Location")] Opportunity opportunity)
        {
            if (id != opportunity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opportunity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpportunityExists(opportunity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(opportunity);
        }

        // GET: OpportunityScaffolding/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opportunity = await _context.Opportunities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opportunity == null)
            {
                return NotFound();
            }

            return View(opportunity);
        }

        // POST: OpportunityScaffolding/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var opportunity = await _context.Opportunities.FindAsync(id);
            _context.Opportunities.Remove(opportunity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpportunityExists(int id)
        {
            return _context.Opportunities.Any(e => e.Id == id);
        }
    }
}
