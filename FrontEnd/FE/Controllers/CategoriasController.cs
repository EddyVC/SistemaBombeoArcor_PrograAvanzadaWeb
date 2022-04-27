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
    public class CategoriasController : Controller
    {
        private readonly ICategoriasServices categoriasServices;

        public CategoriasController(ICategoriasServices categoriasServices)
        {
            this.categoriasServices = categoriasServices;
        }

        // GET: Categorias
        public async Task<IActionResult> Index()
        {
            return View(categoriasServices.GetAll());
        }

        // GET: Categorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorias = categoriasServices.GetOneById((int)id);
            if (categorias == null)
            {
                return NotFound();
            }

            return View(categorias);
        }

        // GET: Categorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idcategoria,Descripcion,Activo,Fecharegistro")] Categoria categorias)
        {
            if (ModelState.IsValid)
            {
                categoriasServices.Insert(categorias);
                return RedirectToAction(nameof(Index));
            }
            return View(categorias);
        }

        // GET: Categorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorias = categoriasServices.GetOneById((int)id);
            if (categorias == null)
            {
                return NotFound();
            }
            return View(categorias);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idcategoria,Descripcion,Activo,Fecharegistro")] Categoria categorias)
        {
            if (id != categorias.Idcategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    categoriasServices.Update(categorias);
                }
                catch (Exception ee)
                {
                    if (!CategoriasExists(categorias.Idcategoria))
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
            return View(categorias);
        }

        // GET: Categorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorias = categoriasServices.GetOneById((int)id);
            if (categorias == null)
            {
                return NotFound();
            }

            return View(categorias);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categorias = categoriasServices.GetOneById(id);
            categoriasServices.Delete(categorias);
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriasExists(int id)
        {
            return (categoriasServices.GetOneById(id) != null);
        }
    }
}
