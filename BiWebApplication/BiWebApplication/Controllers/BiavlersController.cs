using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BiWebApplication.DAL;
using BiWebApplication.Models;

namespace BiWebApplication.Controllers
{
    public class BiavlersController : Controller
    {
        private readonly DbAccess _context;

        public BiavlersController(DbAccess context)
        {
            _context = context;
        }

        // GET: Biavlers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Biavlers.ToListAsync());
        }

        // GET: Biavlers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biavler = await _context.Biavlers
                .SingleOrDefaultAsync(m => m.Name == id);
            if (biavler == null)
            {
                return NotFound();
            }

            return View(biavler);
        }

        // GET: Biavlers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Biavlers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,LastName,DBF,EmailAddress,Address1,Adress2,ZIPCode,City")] Biavler biavler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(biavler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(biavler);
        }

        // GET: Biavlers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biavler = await _context.Biavlers.SingleOrDefaultAsync(m => m.Name == id);
            if (biavler == null)
            {
                return NotFound();
            }
            return View(biavler);
        }

        // POST: Biavlers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,LastName,DBF,EmailAddress,Address1,Adress2,ZIPCode,City")] Biavler biavler)
        {
            if (id != biavler.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(biavler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BiavlerExists(biavler.Name))
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
            return View(biavler);
        }

        // GET: Biavlers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biavler = await _context.Biavlers
                .SingleOrDefaultAsync(m => m.Name == id);
            if (biavler == null)
            {
                return NotFound();
            }

            return View(biavler);
        }

        // POST: Biavlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var biavler = await _context.Biavlers.SingleOrDefaultAsync(m => m.Name == id);
            _context.Biavlers.Remove(biavler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BiavlerExists(string id)
        {
            return _context.Biavlers.Any(e => e.Name == id);
        }
    }
}
