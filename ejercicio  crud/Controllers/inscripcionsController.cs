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
    public class inscripcionsController : Controller
    {
        private readonly crudDBcontext _context;

        public inscripcionsController(crudDBcontext context)
        {
            _context = context;
        }

        // GET: inscripcions
        public async Task<IActionResult> Index()
        {
              return _context.inscripcion != null ? 
                          View(await _context.inscripcion.ToListAsync()) :
                          Problem("Entity set 'crudDBcontext.inscripcion'  is null.");
        }

        // GET: inscripcions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.inscripcion == null)
            {
                return NotFound();
            }

            var inscripcion = await _context.inscripcion
                .FirstOrDefaultAsync(m => m.Nro_inscripcion == id);
            if (inscripcion == null)
            {
                return NotFound();
            }

            return View(inscripcion);
        }

        // GET: inscripcions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: inscripcions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nro_inscripcion,codigo,Nro_id,periodo")] inscripcion inscripcion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inscripcion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inscripcion);
        }

        // GET: inscripcions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.inscripcion == null)
            {
                return NotFound();
            }

            var inscripcion = await _context.inscripcion.FindAsync(id);
            if (inscripcion == null)
            {
                return NotFound();
            }
            return View(inscripcion);
        }

        // POST: inscripcions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nro_inscripcion,codigo,Nro_id,periodo")] inscripcion inscripcion)
        {
            if (id != inscripcion.Nro_inscripcion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscripcion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!inscripcionExists(inscripcion.Nro_inscripcion))
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
            return View(inscripcion);
        }

        // GET: inscripcions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.inscripcion == null)
            {
                return NotFound();
            }

            var inscripcion = await _context.inscripcion
                .FirstOrDefaultAsync(m => m.Nro_inscripcion == id);
            if (inscripcion == null)
            {
                return NotFound();
            }

            return View(inscripcion);
        }

        // POST: inscripcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.inscripcion == null)
            {
                return Problem("Entity set 'crudDBcontext.inscripcion'  is null.");
            }
            var inscripcion = await _context.inscripcion.FindAsync(id);
            if (inscripcion != null)
            {
                _context.inscripcion.Remove(inscripcion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool inscripcionExists(int id)
        {
          return (_context.inscripcion?.Any(e => e.Nro_inscripcion == id)).GetValueOrDefault();
        }
    }
}
