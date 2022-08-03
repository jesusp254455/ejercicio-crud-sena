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
    public class facultadsController : Controller
    {
        private readonly crudDBcontext _context;

        public facultadsController(crudDBcontext context)
        {
            _context = context;
        }

        // GET: facultads
        public async Task<IActionResult> Index()
        {
              return _context.facultad != null ? 
                          View(await _context.facultad.ToListAsync()) :
                          Problem("Entity set 'crudDBcontext.facultad'  is null.");
        }

        // GET: facultads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.facultad == null)
            {
                return NotFound();
            }

            var facultad = await _context.facultad
                .FirstOrDefaultAsync(m => m.numero == id);
            if (facultad == null)
            {
                return NotFound();
            }

            return View(facultad);
        }

        // GET: facultads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: facultads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("numero,nombre,ubicacion,cedula")] facultad facultad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facultad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(facultad);
        }

        // GET: facultads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.facultad == null)
            {
                return NotFound();
            }

            var facultad = await _context.facultad.FindAsync(id);
            if (facultad == null)
            {
                return NotFound();
            }
            return View(facultad);
        }

        // POST: facultads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("numero,nombre,ubicacion,cedula")] facultad facultad)
        {
            if (id != facultad.numero)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facultad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!facultadExists(facultad.numero))
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
            return View(facultad);
        }

        // GET: facultads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.facultad == null)
            {
                return NotFound();
            }

            var facultad = await _context.facultad
                .FirstOrDefaultAsync(m => m.numero == id);
            if (facultad == null)
            {
                return NotFound();
            }

            return View(facultad);
        }

        // POST: facultads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.facultad == null)
            {
                return Problem("Entity set 'crudDBcontext.facultad'  is null.");
            }
            var facultad = await _context.facultad.FindAsync(id);
            if (facultad != null)
            {
                _context.facultad.Remove(facultad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool facultadExists(int id)
        {
          return (_context.facultad?.Any(e => e.numero == id)).GetValueOrDefault();
        }
    }
}
