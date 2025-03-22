using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoginCadastroMVC.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
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

        // GET: patients/Index
        public async Task<ActionResult> Index()
        {
            return View(await _db.Patients.ToListAsync());
        }

        // GET: patients/Create
        public ActionResult Create()
        {
            // Prepara a lista de especialidades para o formulário de criação
            ViewBag.SpecialtiesList = Enum.GetValues(typeof(SpecialtyEnum))
                                          .Cast<SpecialtyEnum>()
                                          .Select(s => new { Value = s.ToString(), Text = s.ToString() })
                                          .ToList();

            return View();
        }

        // POST: patients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                // Garante que o SpecialtiesString está atualizado com as especialidades selecionadas
                patient.SpecialtiesString = string.Join(",", patient.Specialties.Select(s => s.ToString()));

                await _db.Patients.AddAsync(patient);
                await _db.SaveChangesAsync();
                TempData["SuccessMessage"] = "Paciente cadastrado com sucesso!";
                return RedirectToAction(nameof(Index));
            }

            // Em caso de erro, prepara a lista de especialidades e exibe novamente o formulário
            ViewBag.SpecialtiesList = Enum.GetValues(typeof(SpecialtyEnum))
                                          .Cast<SpecialtyEnum>()
                                          .Select(s => new { Value = s.ToString(), Text = s.ToString() })
                                          .ToList();

            return View(patient);
        }

        // GET: patients/Edit/1
        public async Task<ActionResult> Edit(int id)
        {
            // Busca o paciente pelo ID
            var patient = await _db.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            // Converte SpecialtiesString para a lista Specialties
            if (!string.IsNullOrEmpty(patient.SpecialtiesString))
            {
                patient.Specialties = patient.SpecialtiesString
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => Enum.Parse<SpecialtyEnum>(s))
                    .ToList();
            }

            // Prepara a lista de especialidades para o formulário de edição
            ViewBag.SpecialtiesList = Enum.GetValues(typeof(SpecialtyEnum))
                                          .Cast<SpecialtyEnum>()
                                          .Select(s => new { Value = s.ToString(), Text = s.ToString() })
                                          .ToList();

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
                    // Busca o paciente existente para evitar problemas de tracking
                    var existingPatient = await _db.Patients.FindAsync(id);
                    if (existingPatient == null)
                    {
                        return NotFound();
                    }

                    // Atualiza as propriedades
                    existingPatient.Name = patient.Name;
                    existingPatient.DateOfBirth = patient.DateOfBirth;
                    existingPatient.Address = patient.Address;
                    existingPatient.Email = patient.Email;
                    existingPatient.Phone = patient.Phone;
                    existingPatient.Complaint = patient.Complaint;
                    existingPatient.AppointmentDate = patient.AppointmentDate;
                    existingPatient.AppointmentTime = patient.AppointmentTime;

                    // Converte Specialties para SpecialtiesString
                    existingPatient.SpecialtiesString = string.Join(",", patient.Specialties.Select(s => s.ToString()));

                    await _db.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Paciente atualizado com sucesso!";
                    return RedirectToAction(nameof(Index));
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
            }

            // Em caso de erro, prepara a lista de especialidades e exibe novamente o formulário
            ViewBag.SpecialtiesList = Enum.GetValues(typeof(SpecialtyEnum))
                                          .Cast<SpecialtyEnum>()
                                          .Select(s => new { Value = s.ToString(), Text = s.ToString() })
                                          .ToList();

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
                TempData["SuccessMessage"] = "Paciente excluído com sucesso!";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}