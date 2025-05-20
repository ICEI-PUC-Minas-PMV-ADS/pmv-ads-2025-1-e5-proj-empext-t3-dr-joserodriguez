using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeuProjeto.Models;

namespace JoseRodriguez.Controllers
{
    public class DentistasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DentistasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dentistas (com pesquisa)
        public async Task<IActionResult> Index(string searchString)
        {
            ViewBag.CurrentFilter = searchString;

            var dentistas = from d in _context.Dentistas
                            select d;

            if (!String.IsNullOrEmpty(searchString))
            {
                dentistas = dentistas.Where(d =>
                    d.Nome.Contains(searchString) ||
                    d.Cedula.Contains(searchString) ||
                    d.Email.Contains(searchString));
            }

            return View(await dentistas.ToListAsync());
        }

        // GET: Dentistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var dentista = await _context.Dentistas
                .FirstOrDefaultAsync(m => m.Id == id);

            if (dentista == null)
                return NotFound();

            return View(dentista);
        }

        // GET: Dentistas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dentistas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cedula,Telefone,Email")] Dentista dentista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dentista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dentista);
        }

        // GET: Dentistas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var dentista = await _context.Dentistas.FindAsync(id);
            if (dentista == null)
                return NotFound();

            return View(dentista);
        }

        // POST: Dentistas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cedula,Telefone,Email")] Dentista dentista)
        {
            if (id != dentista.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dentista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DentistaExists(dentista.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dentista);
        }

        // GET: Dentistas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dentista = await _context.Dentistas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dentista == null)
                return NotFound();

            return View(dentista);
        }

        // POST: Dentistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dentista = await _context.Dentistas.FindAsync(id);
            if (dentista != null)
            {
                _context.Dentistas.Remove(dentista);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool DentistaExists(int id)
        {
            return _context.Dentistas.Any(e => e.Id == id);
        }
    }
}
