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
    public class cursoesController : Controller
    {
        private readonly crudDBcontext _context;

        public cursoesController(crudDBcontext context)
        {
            _context = context;
        }

        // GET: cursoes
        public async Task<IActionResult> Index()
        {
              return _context.curso != null ? 
                          View(await _context.curso.ToListAsync()) :
                          Problem("Entity set 'crudDBcontext.curso'  is null.");
        }

        // GET: cursoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.curso == null)
            {
                return NotFound();
            }

            var curso = await _context.curso
                .FirstOrDefaultAsync(m => m.Nro_id == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // GET: cursoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cursoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nro_id,cedula,codigo")] curso curso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(curso);
        }

        // GET: cursoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.curso == null)
            {
                return NotFound();
            }

            var curso = await _context.curso.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }

        // POST: cursoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nro_id,cedula,codigo")] curso curso)
        {
            if (id != curso.Nro_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cursoExists(curso.Nro_id))
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
            return View(curso);
        }

        // GET: cursoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.curso == null)
            {
                return NotFound();
            }

            var curso = await _context.curso
                .FirstOrDefaultAsync(m => m.Nro_id == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // POST: cursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.curso == null)
            {
                return Problem("Entity set 'crudDBcontext.curso'  is null.");
            }
            var curso = await _context.curso.FindAsync(id);
            if (curso != null)
            {
                _context.curso.Remove(curso);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cursoExists(int id)
        {
          return (_context.curso?.Any(e => e.Nro_id == id)).GetValueOrDefault();
        }
    }
}
