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
    public class ContactosController : Controller
    {
        private readonly IContactosServices contactosServices;

        public ContactosController(IContactosServices contactosServices)
        {
            this.contactosServices = contactosServices;
        }

        // GET: Contactos
        public async Task<IActionResult> Index()
        {
            return View(contactosServices.GetAll());
        }

        // GET: Contactos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactos = contactosServices.GetOneById((int)id);
            if (contactos == null)
            {
                return NotFound();
            }

            return View(contactos);
        }

        // GET: Contactos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contactos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idcontacto,Nombre,Telefono,Correo,Mensaje,Fecha")] Contacto contactos)
        {
            if (ModelState.IsValid)
            {
                contactosServices.Insert(contactos);
                return RedirectToAction(nameof(Index));
            }
            return View(contactos);
        }

        // GET: Contactos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactos = contactosServices.GetOneById((int)id);
            if (contactos == null)
            {
                return NotFound();
            }
            return View(contactos);
        }

        // POST: Contactos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idcontacto,Nombre,Telefono,Correo,Mensaje,Fecha")] Contacto contactos)
        {
            if (id != contactos.Idcontacto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    contactosServices.Update(contactos);
                }
                catch (Exception ee)
                {
                    if (!ContactosExists(contactos.Idcontacto))
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
            return View(contactos);
        }

        // GET: Contactos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactos = contactosServices.GetOneById((int)id);
            if (contactos == null)
            {
                return NotFound();
            }

            return View(contactos);
        }

        // POST: Contactos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactos = contactosServices.GetOneById(id);
            contactosServices.Delete(contactos);
            return RedirectToAction(nameof(Index));
        }

        private bool ContactosExists(int id)
        {
            return (contactosServices.GetOneById(id) != null);
        }
    }
}
