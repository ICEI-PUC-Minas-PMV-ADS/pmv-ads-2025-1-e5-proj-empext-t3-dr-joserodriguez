using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        // GET: patients/Index
        public async Task<ActionResult> Index()
        {
            var patients = await _db.Patients.ToListAsync();
            return View(patients);
        }

        // GET: Patient/Management
        public IActionResult Management()
        {
            return View();
        }

        // GET: Patient/GetByDate
        [HttpGet]
        public async Task<IActionResult> GetByDate(DateTime date)
        {
            var patients = await _db.Patients
                .Where(p => p.AppointmentDate.HasValue && p.AppointmentDate.Value.Date == date.Date)
                .OrderBy(p => p.AppointmentTime)
                .ToListAsync();

            var result = patients.Select(p => new
            {
                id = p.ID,
                name = p.Name,
                time = p.AppointmentTime.HasValue ? p.AppointmentTime.Value.ToString(@"hh\:mm") : ""
            });

            return Json(result);
        }

        // GET: Patient/GetPatientDetails
        [HttpGet]
        public async Task<IActionResult> GetPatientDetails(int id)
        {
            var patient = await _db.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Json(new
            {
                id = patient.ID,
                name = patient.Name,
                dateOfBirth = patient.DateOfBirth,
                address = patient.Address,
                email = patient.Email,
                phone = patient.Phone,
                specialty = patient.SpecialtiesString,
                complaint = patient.Complaint
            });
        }

        // GET: patients/Create
        public ActionResult Create()
        {
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
                if (patient.AppointmentDate.HasValue && patient.AppointmentTime.HasValue)
                {
                    patient.AppointmentDate = patient.AppointmentDate.Value.Date.Add(patient.AppointmentTime.Value);
                }

                if (patient.Specialties != null && patient.Specialties.Any())
                {
                    patient.SpecialtiesString = string.Join(",", patient.Specialties.Select(s => s.ToString()));
                }

                await _db.Patients.AddAsync(patient);
                await _db.SaveChangesAsync();
                TempData["SuccessMessage"] = "Paciente cadastrado com sucesso!";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.SpecialtiesList = Enum.GetValues(typeof(SpecialtyEnum))
                                          .Cast<SpecialtyEnum>()
                                          .Select(s => new { Value = s.ToString(), Text = s.ToString() })
                                          .ToList();
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

            if (!string.IsNullOrEmpty(patient.SpecialtiesString))
            {
                patient.Specialties = patient.SpecialtiesString
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => Enum.Parse<SpecialtyEnum>(s))
                    .ToList();
            }

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
                    var existingPatient = await _db.Patients.FindAsync(id);
                    if (existingPatient == null)
                    {
                        return NotFound();
                    }

                    existingPatient.Name = patient.Name;
                    existingPatient.DateOfBirth = patient.DateOfBirth;
                    existingPatient.Address = patient.Address;
                    existingPatient.Email = patient.Email;
                    existingPatient.Phone = patient.Phone;
                    existingPatient.Complaint = patient.Complaint;
                    existingPatient.AppointmentDate = patient.AppointmentDate;
                    existingPatient.AppointmentTime = patient.AppointmentTime;

                    if (patient.Specialties != null && patient.Specialties.Any())
                    {
                        existingPatient.SpecialtiesString = string.Join(",", patient.Specialties.Select(s => s.ToString()));
                    }

                    await _db.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Paciente atualizado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            ViewBag.SpecialtiesList = Enum.GetValues(typeof(SpecialtyEnum))
                                          .Cast<SpecialtyEnum>()
                                          .Select(s => new { Value = s.ToString(), Text = s.ToString() })
                                          .ToList();
            return View(patient);
        }

        // POST: Patient/Update (para chamadas AJAX da página de gerenciamento)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromBody] Patient patient)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingPatient = await _db.Patients.FindAsync(patient.ID);
                    if (existingPatient == null)
                    {
                        return Json(new { success = false, message = "Paciente não encontrado." });
                    }

                    existingPatient.Name = patient.Name;
                    existingPatient.Address = patient.Address;
                    existingPatient.Email = patient.Email;
                    existingPatient.Phone = patient.Phone;
                    existingPatient.Complaint = patient.Complaint;
                    existingPatient.SpecialtiesString = patient.SpecialtiesString;

                    await _db.SaveChangesAsync();
                    return Json(new { success = true, message = "Paciente atualizado com sucesso!" });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.ID))
                    {
                        return Json(new { success = false, message = "Paciente não encontrado." });
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return Json(new { success = false, message = "Erro ao atualizar paciente." });
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

        // POST: Patient/DeleteAjax/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAjax(int id)
        {
            var patient = await _db.Patients.FindAsync(id);
            if (patient != null)
            {
                _db.Patients.Remove(patient);
                await _db.SaveChangesAsync();
                return Json(new { success = true, message = "Paciente excluído com sucesso!" });
            }

            return Json(new { success = false, message = "Paciente não encontrado." });
        }

        private bool PatientExists(int id)
        {
            return _db.Patients.Any(e => e.ID == id);
        }
    }
}
