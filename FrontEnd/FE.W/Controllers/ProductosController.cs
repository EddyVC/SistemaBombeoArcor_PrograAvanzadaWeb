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
    public class ProductosController : Controller
    {
        private readonly BombeoPruebaContext _context;

        public ProductosController(BombeoPruebaContext context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            var bombeoPruebaContext = _context.Producto.Include(p => p.IdcategoriaNavigation).Include(p => p.IdmarcaNavigation);
            return View(await bombeoPruebaContext.ToListAsync());
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto
                .Include(p => p.IdcategoriaNavigation)
                .Include(p => p.IdmarcaNavigation)
                .FirstOrDefaultAsync(m => m.Idproducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            ViewData["Idcategoria"] = new SelectList(_context.Categoria, "Idcategoria", "Idcategoria");
            ViewData["Idmarca"] = new SelectList(_context.Marca, "IdMarca", "IdMarca");
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idproducto,Codigo,Valorcodigo,Nombre,Descripcion,Idcategoria,Activo,Fecharegistro,Idmarca")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idcategoria"] = new SelectList(_context.Categoria, "Idcategoria", "Idcategoria", producto.Idcategoria);
            ViewData["Idmarca"] = new SelectList(_context.Marca, "IdMarca", "IdMarca", producto.Idmarca);
            return View(producto);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["Idcategoria"] = new SelectList(_context.Categoria, "Idcategoria", "Idcategoria", producto.Idcategoria);
            ViewData["Idmarca"] = new SelectList(_context.Marca, "IdMarca", "IdMarca", producto.Idmarca);
            return View(producto);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idproducto,Codigo,Valorcodigo,Nombre,Descripcion,Idcategoria,Activo,Fecharegistro,Idmarca")] Producto producto)
        {
            if (id != producto.Idproducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.Idproducto))
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
            ViewData["Idcategoria"] = new SelectList(_context.Categoria, "Idcategoria", "Idcategoria", producto.Idcategoria);
            ViewData["Idmarca"] = new SelectList(_context.Marca, "IdMarca", "IdMarca", producto.Idmarca);
            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto
                .Include(p => p.IdcategoriaNavigation)
                .Include(p => p.IdmarcaNavigation)
                .FirstOrDefaultAsync(m => m.Idproducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Producto.FindAsync(id);
            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Producto.Any(e => e.Idproducto == id);
        }
    }
}
