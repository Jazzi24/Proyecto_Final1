using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Models;

namespace Proyecto_Final.Controllers
{
    public class RefaccionesController : Controller
    {
        private readonly AgenciaAutomotrizContext _context;

        public RefaccionesController(AgenciaAutomotrizContext context)
        {
            _context = context;
        }

        // GET: Refacciones
        public async Task<IActionResult> Index()
        {
              return View(await _context.Refacciones.ToListAsync());
        }

        // GET: Refacciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Refacciones == null)
            {
                return NotFound();
            }

            var refaccione = await _context.Refacciones
                .FirstOrDefaultAsync(m => m.IdRefaccion == id);
            if (refaccione == null)
            {
                return NotFound();
            }

            return View(refaccione);
        }

        // GET: Refacciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Refacciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRefaccion,Nombre,Marca,Precio,Descripcion,Cantidad")] Refaccione refaccione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refaccione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(refaccione);
        }

        // GET: Refacciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Refacciones == null)
            {
                return NotFound();
            }

            var refaccione = await _context.Refacciones.FindAsync(id);
            if (refaccione == null)
            {
                return NotFound();
            }
            return View(refaccione);
        }

        // POST: Refacciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRefaccion,Nombre,Marca,Precio,Descripcion,Cantidad")] Refaccione refaccione)
        {
            if (id != refaccione.IdRefaccion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refaccione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefaccioneExists(refaccione.IdRefaccion))
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
            return View(refaccione);
        }

        // GET: Refacciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Refacciones == null)
            {
                return NotFound();
            }

            var refaccione = await _context.Refacciones
                .FirstOrDefaultAsync(m => m.IdRefaccion == id);
            if (refaccione == null)
            {
                return NotFound();
            }

            return View(refaccione);
        }

        // POST: Refacciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Refacciones == null)
            {
                return Problem("Entity set 'AgenciaAutomotrizContext.Refacciones'  is null.");
            }
            var refaccione = await _context.Refacciones.FindAsync(id);
            if (refaccione != null)
            {
                _context.Refacciones.Remove(refaccione);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefaccioneExists(int id)
        {
          return _context.Refacciones.Any(e => e.IdRefaccion == id);
        }
    }
}
