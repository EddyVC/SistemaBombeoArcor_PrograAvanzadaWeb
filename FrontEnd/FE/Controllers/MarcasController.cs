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
    public class MarcasController : Controller
    {
        private readonly IMarcasServices marcasServices;

        public MarcasController(IMarcasServices marcasServices)
        {
            this.marcasServices = marcasServices;
        }

        // GET: Marcas
        public async Task<IActionResult> Index()
        {
            return View(marcasServices.GetAll());
        }

        // GET: Marcas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcas = marcasServices.GetOneById((int)id);
            if (marcas == null)
            {
                return NotFound();
            }

            return View(marcas);
        }

        // GET: Marcas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Marcas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMarca,Descripcion,Activo,FechaRegistro")] Marca marcas)
        {
            if (ModelState.IsValid)
            {
                marcasServices.Insert(marcas);
                return RedirectToAction(nameof(Index));
            }
            return View(marcas);
        }

        // GET: Marcas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcas = marcasServices.GetOneById((int)id);
            if (marcas == null)
            {
                return NotFound();
            }
            return View(marcas);
        }

        // POST: Marcas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMarca,Descripcion,Activo,FechaRegistro")] Marca marcas)
        {
            if (id != marcas.IdMarca)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    marcasServices.Update(marcas);
                }
                catch (Exception ee)
                {
                    if (!MarcasExists(marcas.IdMarca))
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
            return View(marcas);
        }

        // GET: Marcas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcas = marcasServices.GetOneById((int)id);
            if (marcas == null)
            {
                return NotFound();
            }

            return View(marcas);
        }

        // POST: Marcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marcas = marcasServices.GetOneById(id);
            marcasServices.Delete(marcas);
            return RedirectToAction(nameof(Index));
        }

        private bool MarcasExists(int id)
        {
            return (marcasServices.GetOneById(id) != null);
        }
    }
}
