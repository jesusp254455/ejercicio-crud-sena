using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ejercicio__crud;
using ejercicio__crud.Models;

namespace ejercicio__crud.Controllers
{
    public class DecanosController : Controller
    {
        private readonly crudDBcontext _context;

        public DecanosController(crudDBcontext context)
        {
            _context = context;
        }

        // GET: Decanos
        public async Task<IActionResult> Index()
        {
              return _context.Decanos != null ? 
                          View(await _context.Decanos.ToListAsync()) :
                          Problem("Entity set 'crudDBcontext.Decanos'  is null.");
        }

        // GET: Decanos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Decanos == null)
            {
                return NotFound();
            }

            var decanos = await _context.Decanos
                .FirstOrDefaultAsync(m => m.cedula == id);
            if (decanos == null)
            {
                return NotFound();
            }

            return View(decanos);
        }

        // GET: Decanos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Decanos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cedula,nombres,apellidos,celular")] Decanos decanos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(decanos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(decanos);
        }

        // GET: Decanos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Decanos == null)
            {
                return NotFound();
            }

            var decanos = await _context.Decanos.FindAsync(id);
            if (decanos == null)
            {
                return NotFound();
            }
            return View(decanos);
        }

        // POST: Decanos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cedula,nombres,apellidos,celular")] Decanos decanos)
        {
            if (id != decanos.cedula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(decanos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DecanosExists(decanos.cedula))
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
            return View(decanos);
        }

        // GET: Decanos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Decanos == null)
            {
                return NotFound();
            }

            var decanos = await _context.Decanos
                .FirstOrDefaultAsync(m => m.cedula == id);
            if (decanos == null)
            {
                return NotFound();
            }

            return View(decanos);
        }

        // POST: Decanos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Decanos == null)
            {
                return Problem("Entity set 'crudDBcontext.Decanos'  is null.");
            }
            var decanos = await _context.Decanos.FindAsync(id);
            if (decanos != null)
            {
                _context.Decanos.Remove(decanos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DecanosExists(int id)
        {
          return (_context.Decanos?.Any(e => e.cedula == id)).GetValueOrDefault();
        }
    }
}
