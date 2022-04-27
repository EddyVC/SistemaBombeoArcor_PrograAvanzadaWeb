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
    public class ProductoController : Controller
    {
        private readonly IMarcasServices MarcaServices;
        private readonly ICategoriasServices CategoriaServices;
        private readonly IProductosServices ProductoServices;

        public ProductoController(IProductosServices ProductoServices, IMarcasServices marcaServices, ICategoriasServices categoriaServices)
        {
            this.ProductoServices = ProductoServices;
            this.MarcaServices = marcaServices;
            this.CategoriaServices = categoriaServices;

        }

        // GET: Producto
        public async Task<IActionResult> Index()
        {
            //var bombeoPruebaContext = _context.Producto.Include(i => i.IdMarcaNavigation);
            return View(await ProductoServices.GetAllAsync());
        }

        // GET: Producto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await ProductoServices.GetOneByIdAsync((int)id);


            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Producto/Create
        public IActionResult Create()
        {
            ViewData["Idcategoria"] = new SelectList(CategoriaServices.GetAll(), "Idproducto", "Idcategoria");
            ViewData["Idmarca"] = new SelectList(MarcaServices.GetAll(), "Idproducto", "IdMarca");

            return View();
        }

        // POST: Producto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idproducto,Codigo,Valorcodigo,Nombre,Descripcion,Idcategoria,Activo,Fecharegistro,Idmarca")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                ProductoServices.Insert(producto);
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idcategoria"] = new SelectList(CategoriaServices.GetAll(), "Idproducto", "Idcategoria", producto.Idcategoria);
            ViewData["Idmarca"] = new SelectList(MarcaServices.GetAll(), "Idproducto", "IdMarca", producto.Idmarca);

            return View(producto);
        }

        // GET: Producto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = ProductoServices.GetOneById((int)id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["Idcategoria"] = new SelectList(CategoriaServices.GetAll(), "Idproducto", "Idcategoria", producto.Idcategoria);
            ViewData["Idmarca"] = new SelectList(MarcaServices.GetAll(), "Idproducto", "Idmarca", producto.Idmarca);
            return View(producto);
        }

        // POST: Producto/Edit/5
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
                    ProductoServices.Update(producto);
                }
                catch (Exception ee)
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

            ViewData["Idcategoria"] = new SelectList(CategoriaServices.GetAll(), "Idproducto", "Idcategoria", producto.Idcategoria);
            ViewData["Idmarca"] = new SelectList(MarcaServices.GetAll(), "Idproducto", "Idmarca", producto.Idmarca);
            return View(producto);
        }

        // GET: Producto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await ProductoServices.GetOneByIdAsync((int)id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = ProductoServices.GetOneById((int)id);
            ProductoServices.Delete(producto);
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return (ProductoServices.GetOneById((int)id) != null);
        }
    }
}