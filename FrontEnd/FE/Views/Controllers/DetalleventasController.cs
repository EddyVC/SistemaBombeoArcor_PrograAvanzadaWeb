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
    public class DetalleventasController : Controller
    {
        private readonly BombeoPruebaContext _context;

        public DetalleventasController(BombeoPruebaContext context)
        {
            _context = context;
        }

        // GET: Detalleventas
        public async Task<IActionResult> Index()
        {
            var bombeoPruebaContext = _context.Detalleventa.Include(d => d.IdproductoNavigation).Include(d => d.IdventaNavigation);
            return View(await bombeoPruebaContext.ToListAsync());
        }

        // GET: Detalleventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleventa = await _context.Detalleventa
                .Include(d => d.IdproductoNavigation)
                .Include(d => d.IdventaNavigation)
                .FirstOrDefaultAsync(m => m.Iddetalleventa == id);
            if (detalleventa == null)
            {
                return NotFound();
            }

            return View(detalleventa);
        }

        // GET: Detalleventas/Create
        public IActionResult Create()
        {
            ViewData["Idproducto"] = new SelectList(_context.Producto, "Idproducto", "Idproducto");
            ViewData["Idventa"] = new SelectList(_context.Venta, "Idventa", "Idventa");
            return View();
        }

        // POST: Detalleventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Iddetalleventa,Idventa,Idproducto,Cantidad,Preciounidad,Importetotal,Descuento,Activo,Fecharegistro")] Detalleventa detalleventa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleventa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idproducto"] = new SelectList(_context.Producto, "Idproducto", "Idproducto", detalleventa.Idproducto);
            ViewData["Idventa"] = new SelectList(_context.Venta, "Idventa", "Idventa", detalleventa.Idventa);
            return View(detalleventa);
        }

        // GET: Detalleventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleventa = await _context.Detalleventa.FindAsync(id);
            if (detalleventa == null)
            {
                return NotFound();
            }
            ViewData["Idproducto"] = new SelectList(_context.Producto, "Idproducto", "Idproducto", detalleventa.Idproducto);
            ViewData["Idventa"] = new SelectList(_context.Venta, "Idventa", "Idventa", detalleventa.Idventa);
            return View(detalleventa);
        }

        // POST: Detalleventas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Iddetalleventa,Idventa,Idproducto,Cantidad,Preciounidad,Importetotal,Descuento,Activo,Fecharegistro")] Detalleventa detalleventa)
        {
            if (id != detalleventa.Iddetalleventa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleventa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleventaExists(detalleventa.Iddetalleventa))
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
            ViewData["Idproducto"] = new SelectList(_context.Producto, "Idproducto", "Idproducto", detalleventa.Idproducto);
            ViewData["Idventa"] = new SelectList(_context.Venta, "Idventa", "Idventa", detalleventa.Idventa);
            return View(detalleventa);
        }

        // GET: Detalleventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleventa = await _context.Detalleventa
                .Include(d => d.IdproductoNavigation)
                .Include(d => d.IdventaNavigation)
                .FirstOrDefaultAsync(m => m.Iddetalleventa == id);
            if (detalleventa == null)
            {
                return NotFound();
            }

            return View(detalleventa);
        }

        // POST: Detalleventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleventa = await _context.Detalleventa.FindAsync(id);
            _context.Detalleventa.Remove(detalleventa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleventaExists(int id)
        {
            return _context.Detalleventa.Any(e => e.Iddetalleventa == id);
        }
    }
}
