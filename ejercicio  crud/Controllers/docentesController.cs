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
    public class docentesController : Controller
    {
        private readonly crudDBcontext _context;

        public docentesController(crudDBcontext context)
        {
            _context = context;
        }

        // GET: docentes
        public async Task<IActionResult> Index()
        {
              return _context.docentes != null ? 
                          View(await _context.docentes.ToListAsync()) :
                          Problem("Entity set 'crudDBcontext.docentes'  is null.");
        }

        // GET: docentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.docentes == null)
            {
                return NotFound();
            }

            var docentes = await _context.docentes
                .FirstOrDefaultAsync(m => m.cedula == id);
            if (docentes == null)
            {
                return NotFound();
            }

            return View(docentes);
        }

        // GET: docentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: docentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cedula,nombres,apellidos,titulo,numero")] docentes docentes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(docentes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(docentes);
        }

        // GET: docentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.docentes == null)
            {
                return NotFound();
            }

            var docentes = await _context.docentes.FindAsync(id);
            if (docentes == null)
            {
                return NotFound();
            }
            return View(docentes);
        }

        // POST: docentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cedula,nombres,apellidos,titulo,numero")] docentes docentes)
        {
            if (id != docentes.cedula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(docentes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!docentesExists(docentes.cedula))
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
            return View(docentes);
        }

        // GET: docentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.docentes == null)
            {
                return NotFound();
            }

            var docentes = await _context.docentes
                .FirstOrDefaultAsync(m => m.cedula == id);
            if (docentes == null)
            {
                return NotFound();
            }

            return View(docentes);
        }

        // POST: docentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.docentes == null)
            {
                return Problem("Entity set 'crudDBcontext.docentes'  is null.");
            }
            var docentes = await _context.docentes.FindAsync(id);
            if (docentes != null)
            {
                _context.docentes.Remove(docentes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool docentesExists(int id)
        {
          return (_context.docentes?.Any(e => e.cedula == id)).GetValueOrDefault();
        }
    }
}
