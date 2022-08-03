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
    public class estudiantesController : Controller
    {
        private readonly crudDBcontext _context;

        public estudiantesController(crudDBcontext context)
        {
            _context = context;
        }

        // GET: estudiantes
        public async Task<IActionResult> Index()
        {
              return _context.estudiante != null ? 
                          View(await _context.estudiante.ToListAsync()) :
                          Problem("Entity set 'crudDBcontext.estudiante'  is null.");
        }

        // GET: estudiantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.estudiante == null)
            {
                return NotFound();
            }

            var estudiante = await _context.estudiante
                .FirstOrDefaultAsync(m => m.Nro_id == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // GET: estudiantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: estudiantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nro_id,nombres,apellido,direccion")] estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estudiante);
        }

        // GET: estudiantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.estudiante == null)
            {
                return NotFound();
            }

            var estudiante = await _context.estudiante.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            return View(estudiante);
        }

        // POST: estudiantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nro_id,nombres,apellido,direccion")] estudiante estudiante)
        {
            if (id != estudiante.Nro_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudiante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!estudianteExists(estudiante.Nro_id))
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
            return View(estudiante);
        }

        // GET: estudiantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.estudiante == null)
            {
                return NotFound();
            }

            var estudiante = await _context.estudiante
                .FirstOrDefaultAsync(m => m.Nro_id == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // POST: estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.estudiante == null)
            {
                return Problem("Entity set 'crudDBcontext.estudiante'  is null.");
            }
            var estudiante = await _context.estudiante.FindAsync(id);
            if (estudiante != null)
            {
                _context.estudiante.Remove(estudiante);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool estudianteExists(int id)
        {
          return (_context.estudiante?.Any(e => e.Nro_id == id)).GetValueOrDefault();
        }
    }
}
