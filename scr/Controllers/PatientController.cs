using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoginCadastroMVC.Models;
using SeuProjeto.Models;

namespace LoginCadastroMVC.Controllers
{
    public class PatientController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PatientController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: patients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: patients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                await _db.Patients.AddAsync(patient);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redireciona para o Index após o cadastro
            }
            return View(patient);
        }

        // GET: patients/Edit/1
        public async Task<ActionResult> Edit(int id)
        {
            var patient = await _db.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: patients/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Patient patient)
        {
            if (id != patient.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(patient);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_db.Patients.Any(e => e.ID == patient.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index)); // Redireciona para o Index após a edição
            }
            return View(patient);
        }

        // GET: patients/Delete/1
        public async Task<ActionResult> Delete(int id)
        {
            var patient = await _db.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: patients/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var patient = await _db.Patients.FindAsync(id);
            if (patient != null)
            {
                _db.Patients.Remove(patient);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index)); // Redireciona para o Index após a exclusão
        }

        // GET: patients/Index
        public async Task<ActionResult> Index()
        {
            return View(await _db.Patients.ToListAsync());
        }
    }
}
