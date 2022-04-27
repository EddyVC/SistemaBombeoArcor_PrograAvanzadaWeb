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
    public class InstaladorController : Controller
    {
        private readonly IProvinciasServices provinciaServices;
        private readonly IInstaladorsServices InstaladorServices;

        public InstaladorController(IInstaladorsServices InstaladorServices, IProvinciasServices provinciaServices)
        {
            this.InstaladorServices = InstaladorServices;
            this.provinciaServices = provinciaServices;
        }

        // GET: Instalador
        public async Task<IActionResult> Index()
        {
            //var bombeoPruebaContext = _context.Instalador.Include(i => i.IdProvinciaNavigation);
            return View(await InstaladorServices.GetAllAsync());
        }

        // GET: Instalador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instalador = await InstaladorServices.GetOneByIdAsync((int)id);


            if (instalador == null)
            {
                return NotFound();
            }

            return View(instalador);
        }

        // GET: Instalador/Create
        public IActionResult Create()
        {
            ViewData["IdProvincia"] = new SelectList(provinciaServices.GetAll(), "IdInstalador", "IdProvincia");
            return View();
        }

        // POST: Instalador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInstalador,Nombre,FechaRegistro,IdProvincia")] Instalador instalador)
        {
            if (ModelState.IsValid)
            {
                InstaladorServices.Insert(instalador);
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProvincia"] = new SelectList(provinciaServices.GetAll(), "IdInstalador", "IdProvincia", instalador.IdProvincia);
            return View(instalador);
        }

        // GET: Instalador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instalador = InstaladorServices.GetOneById((int)id);
            if (instalador == null)
            {
                return NotFound();
            }
            ViewData["IdProvincia"] = new SelectList(provinciaServices.GetAll(), "IdInstalador", "IdProvincia", instalador.IdProvincia);
            return View(instalador);
        }

        // POST: Instalador/Edit/5
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
                    InstaladorServices.Update(instalador);
                }
                catch (Exception ee)
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
            ViewData["IdProvincia"] = new SelectList(provinciaServices.GetAll(), "IdInstalador" , "IdProvincia", instalador.IdProvincia);
            return View(instalador);
        }

        // GET: Instalador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instalador = await InstaladorServices.GetOneByIdAsync((int)id);
            if (instalador == null)
            {
                return NotFound();
            }

            return View(instalador);
        }

        // POST: Instalador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instalador = InstaladorServices.GetOneById((int)id);
            InstaladorServices.Delete(instalador);
            return RedirectToAction(nameof(Index));
        }

        private bool InstaladorExists(int id)
        {
            return (InstaladorServices.GetOneById((int)id) != null);
        }
    }
}