using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationBiavler.Data;
using WebApplicationBiavler.Models;

namespace WebApplicationBiavler.Controllers
{
    public class VarromidesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VarromidesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Varromides
        public async Task<IActionResult> Index()
        {
            return View(await _context.Varromides.ToListAsync());
        }

        // GET: Varromides/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var varromide = await _context.Varromides
                .SingleOrDefaultAsync(m => m.Bistade == id);
            if (varromide == null)
            {
                return NotFound();
            }

            return View(varromide);
        }

        // GET: Varromides/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Varromides/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Bistade,Date,VarromidCount,Days,Text")] Varromide varromide)
        {
            if (ModelState.IsValid)
            {
                _context.Add(varromide);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(varromide);
        }

        // GET: Varromides/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var varromide = await _context.Varromides.SingleOrDefaultAsync(m => m.Bistade == id);
            if (varromide == null)
            {
                return NotFound();
            }
            return View(varromide);
        }

        // POST: Varromides/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Bistade,Date,VarromidCount,Days,Text")] Varromide varromide)
        {
            if (id != varromide.Bistade)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(varromide);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VarromideExists(varromide.Bistade))
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
            return View(varromide);
        }

        // GET: Varromides/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var varromide = await _context.Varromides
                .SingleOrDefaultAsync(m => m.Bistade == id);
            if (varromide == null)
            {
                return NotFound();
            }

            return View(varromide);
        }

        // POST: Varromides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var varromide = await _context.Varromides.SingleOrDefaultAsync(m => m.Bistade == id);
            _context.Varromides.Remove(varromide);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VarromideExists(string id)
        {
            return _context.Varromides.Any(e => e.Bistade == id);
        }
    }
}
