using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FE.W.Models;

namespace FE.W.Controllers
{
    public class InstaladorsController : Controller
    {
        private readonly BombeoPruebaContext _context;

        public InstaladorsController(BombeoPruebaContext context)
        {
            _context = context;
        }

        // GET: Instaladors
        public async Task<IActionResult> Index()
        {
            var bombeoPruebaContext = _context.Instalador.Include(i => i.IdProvinciaNavigation);
            return View(await bombeoPruebaContext.ToListAsync());
        }

        // GET: Instaladors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instalador = await _context.Instalador
                .Include(i => i.IdProvinciaNavigation)
                .FirstOrDefaultAsync(m => m.IdInstalador == id);
            if (instalador == null)
            {
                return NotFound();
            }

            return View(instalador);
        }

        // GET: Instaladors/Create
        public IActionResult Create()
        {
            ViewData["IdProvincia"] = new SelectList(_context.Provincia, "IdProvincia", "Nombre");
            return View();
        }

        // POST: Instaladors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInstalador,Nombre,FechaRegistro,IdProvincia")] Instalador instalador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instalador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProvincia"] = new SelectList(_context.Provincia, "IdProvincia", "Nombre", instalador.IdProvincia);
            return View(instalador);
        }

        // GET: Instaladors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instalador = await _context.Instalador.FindAsync(id);
            if (instalador == null)
            {
                return NotFound();
            }
            ViewData["IdProvincia"] = new SelectList(_context.Provincia, "IdProvincia", "Nombre", instalador.IdProvincia);
            return View(instalador);
        }

        // POST: Instaladors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInstalador,Nombre,FechaRegistro,IdProvincia")] Instalador instalador)
        {
            if (id != instalador.IdInstalador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instalador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstaladorExists(instalador.IdInstalador))
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
            ViewData["IdProvincia"] = new SelectList(_context.Provincia, "IdProvincia", "Nombre", instalador.IdProvincia);
            return View(instalador);
        }

        // GET: Instaladors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instalador = await _context.Instalador
                .Include(i => i.IdProvinciaNavigation)
                .FirstOrDefaultAsync(m => m.IdInstalador == id);
            if (instalador == null)
            {
                return NotFound();
            }

            return View(instalador);
        }

        // POST: Instaladors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instalador = await _context.Instalador.FindAsync(id);
            _context.Instalador.Remove(instalador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstaladorExists(int id)
        {
            return _context.Instalador.Any(e => e.IdInstalador == id);
        }
    }
}
