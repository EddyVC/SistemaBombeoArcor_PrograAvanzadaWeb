using FE.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FE.Models;


namespace FE.Controllers
{
    public class DetalleventaController : Controller
    {
        private readonly IVentasServices VentaServices;
        private readonly IProductosServices ProductoServices;
        private readonly IDetalleventasServices DetalleventaServices;

        public DetalleventaController(IDetalleventasServices DetalleventaServices, IVentasServices ventaServices, IProductosServices productoServices)
        {
            this.DetalleventaServices = DetalleventaServices;
            this.VentaServices = ventaServices;
            this.ProductoServices = productoServices;

        }

        // GET: Detalleventa
        public async Task<IActionResult> Index()
        {
            //var bombeoPruebaContext = _context.Detalleventa.Include(i => i.IdVentaNavigation);
            return View(await DetalleventaServices.GetAllAsync());
        }

        // GET: Detalleventa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleventa = await DetalleventaServices.GetOneByIdAsync((int)id);


            if (detalleventa == null)
            {
                return NotFound();
            }

            return View(detalleventa);
        }

        // GET: Detalleventa/Create
        public IActionResult Create()
        {
            ViewData["Idproducto"] = new SelectList(ProductoServices.GetAll(), "Iddetalleventa", "Idproducto");
            ViewData["Idventa"] = new SelectList(VentaServices.GetAll(), "Iddetalleventa", "Idventa");

            return View();
        }

        // POST: Detalleventa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Iddetalleventa,Idventa,Idproducto,Cantidad,Preciounidad,Importetotal,Descuento,Activo,Fecharegistro")] Detalleventa detalleventa)
        {
            if (ModelState.IsValid)
            {
                DetalleventaServices.Insert(detalleventa);
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idproducto"] = new SelectList(ProductoServices.GetAll(), "Iddetalleventa", "Idproducto", detalleventa.Idproducto);
            ViewData["Idventa"] = new SelectList(VentaServices.GetAll(), "Iddetalleventa", "Idventa", detalleventa.Idventa);

            return View(detalleventa);
        }

        // GET: Detalleventa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleventa = DetalleventaServices.GetOneById((int)id);
            if (detalleventa == null)
            {
                return NotFound();
            }
            ViewData["Idproducto"] = new SelectList(ProductoServices.GetAll(), "Iddetalleventa", "Idproducto", detalleventa.Idproducto);
            ViewData["Idventa"] = new SelectList(VentaServices.GetAll(), "Iddetalleventa", "Idventa", detalleventa.Idventa);
            return View(detalleventa);
        }

        // POST: Detalleventa/Edit/5
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
                    DetalleventaServices.Update(detalleventa);
                }
                catch (Exception ee)
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

            ViewData["Idproducto"] = new SelectList(ProductoServices.GetAll(), "Iddetalleventa", "Idproducto", detalleventa.Idproducto);
            ViewData["Idventa"] = new SelectList(VentaServices.GetAll(), "Iddetalleventa", "Idventa", detalleventa.Idventa);
            return View(detalleventa);
        }

        // GET: Detalleventa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleventa = await DetalleventaServices.GetOneByIdAsync((int)id);
            if (detalleventa == null)
            {
                return NotFound();
            }

            return View(detalleventa);
        }

        // POST: Detalleventa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleventa = DetalleventaServices.GetOneById((int)id);
            DetalleventaServices.Delete(detalleventa);
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleventaExists(int id)
        {
            return (DetalleventaServices.GetOneById((int)id) != null);
        }
    }
}