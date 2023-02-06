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
    public class MotosController : Controller
    {
        private readonly AgenciaAutomotrizContext _context;

        public MotosController(AgenciaAutomotrizContext context)
        {
            _context = context;
        }

        // GET: Motos
        public async Task<IActionResult> Index()
        {
              return View(await _context.Motos.ToListAsync());
        }

        // GET: Motos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Motos == null)
            {
                return NotFound();
            }

            var moto = await _context.Motos
                .FirstOrDefaultAsync(m => m.IdMoto == id);
            if (moto == null)
            {
                return NotFound();
            }

            return View(moto);
        }

        // GET: Motos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Motos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMoto,Modelo,Color,Precio,Cantidad")] Moto moto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moto);
        }

        // GET: Motos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Motos == null)
            {
                return NotFound();
            }

            var moto = await _context.Motos.FindAsync(id);
            if (moto == null)
            {
                return NotFound();
            }
            return View(moto);
        }

        // POST: Motos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMoto,Modelo,Color,Precio,Cantidad")] Moto moto)
        {
            if (id != moto.IdMoto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotoExists(moto.IdMoto))
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
            return View(moto);
        }

        // GET: Motos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Motos == null)
            {
                return NotFound();
            }

            var moto = await _context.Motos
                .FirstOrDefaultAsync(m => m.IdMoto == id);
            if (moto == null)
            {
                return NotFound();
            }

            return View(moto);
        }

        // POST: Motos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Motos == null)
            {
                return Problem("Entity set 'AgenciaAutomotrizContext.Motos'  is null.");
            }
            var moto = await _context.Motos.FindAsync(id);
            if (moto != null)
            {
                _context.Motos.Remove(moto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotoExists(int id)
        {
          return _context.Motos.Any(e => e.IdMoto == id);
        }
    }
}
