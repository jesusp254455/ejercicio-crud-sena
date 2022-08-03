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
    public class asignaturasController : Controller
    {
        private readonly crudDBcontext _context;

        public asignaturasController(crudDBcontext context)
        {
            _context = context;
        }

        // GET: asignaturas
        public async Task<IActionResult> Index()
        {
              return _context.asignatura != null ? 
                          View(await _context.asignatura.ToListAsync()) :
                          Problem("Entity set 'crudDBcontext.asignatura'  is null.");
        }

        // GET: asignaturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.asignatura == null)
            {
                return NotFound();
            }

            var asignatura = await _context.asignatura
                .FirstOrDefaultAsync(m => m.codigo == id);
            if (asignatura == null)
            {
                return NotFound();
            }

            return View(asignatura);
        }

        // GET: asignaturas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: asignaturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("codigo,nombre,Nro_creditos")] asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignatura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(asignatura);
        }

        // GET: asignaturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.asignatura == null)
            {
                return NotFound();
            }

            var asignatura = await _context.asignatura.FindAsync(id);
            if (asignatura == null)
            {
                return NotFound();
            }
            return View(asignatura);
        }

        // POST: asignaturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("codigo,nombre,Nro_creditos")] asignatura asignatura)
        {
            if (id != asignatura.codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignatura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!asignaturaExists(asignatura.codigo))
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
            return View(asignatura);
        }

        // GET: asignaturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.asignatura == null)
            {
                return NotFound();
            }

            var asignatura = await _context.asignatura
                .FirstOrDefaultAsync(m => m.codigo == id);
            if (asignatura == null)
            {
                return NotFound();
            }

            return View(asignatura);
        }

        // POST: asignaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.asignatura == null)
            {
                return Problem("Entity set 'crudDBcontext.asignatura'  is null.");
            }
            var asignatura = await _context.asignatura.FindAsync(id);
            if (asignatura != null)
            {
                _context.asignatura.Remove(asignatura);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool asignaturaExists(int id)
        {
          return (_context.asignatura?.Any(e => e.codigo == id)).GetValueOrDefault();
        }
    }
}
