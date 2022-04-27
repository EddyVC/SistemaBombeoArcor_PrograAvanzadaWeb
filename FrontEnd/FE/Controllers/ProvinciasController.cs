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
    public class ProvinciasController : Controller
    {
        private readonly IProvinciasServices provinciasServices;

        public ProvinciasController(IProvinciasServices provinciasServices)
        {
            this.provinciasServices = provinciasServices;
        }

        // GET: Provincias
        public async Task<IActionResult> Index()
        {
            return View(provinciasServices.GetAll());
        }

        // GET: Provincias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provincias = provinciasServices.GetOneById((int)id);
            if (provincias == null)
            {
                return NotFound();
            }

            return View(provincias);
        }

        // GET: Provincias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Provincias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProvincia,Nombre")] Provincia provincias)
        {
            if (ModelState.IsValid)
            {
                provinciasServices.Insert(provincias);
                return RedirectToAction(nameof(Index));
            }
            return View(provincias);
        }

        // GET: Provincias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provincias = provinciasServices.GetOneById((int)id);
            if (provincias == null)
            {
                return NotFound();
            }
            return View(provincias);
        }

        // POST: Provincias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProvincia,Nombre")] Provincia provincias)
        {
            if (id != provincias.IdProvincia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    provinciasServices.Update(provincias);
                }
                catch (Exception ee)
                {
                    if (!ProvinciasExists(provincias.IdProvincia))
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
            return View(provincias);
        }

        // GET: Provincias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provincias = provinciasServices.GetOneById((int)id);
            if (provincias == null)
            {
                return NotFound();
            }

            return View(provincias);
        }

        // POST: Provincias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var provincias = provinciasServices.GetOneById(id);
            provinciasServices.Delete(provincias);
            return RedirectToAction(nameof(Index));
        }

        private bool ProvinciasExists(int id)
        {
            return (provinciasServices.GetOneById(id) != null);
        }
    }
}