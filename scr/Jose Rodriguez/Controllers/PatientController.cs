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

        // GET: patients/Index - LISTAGEM E PESQUISA
        public async Task<ActionResult> Index(string searchString)
        {
            ViewBag.CurrentFilter = searchString;

            var patientsQuery = _db.Patients.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                patientsQuery = patientsQuery.Where(p => p.Name.Contains(searchString));
            }

            var patients = await patientsQuery.ToListAsync();
            return View(patients);
        }

        // -----------------------------
        // CRUD DE PACIENTES
        // -----------------------------

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _db.Add(patient);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var patient = await _db.Patients.FindAsync(id);
            if (patient == null) return NotFound();
            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Patient patient)
        {
            if (id != patient.ID) return NotFound();

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
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var patient = await _db.Patients.FirstOrDefaultAsync(m => m.ID == id);
            if (patient == null) return NotFound();

            return View(patient);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await _db.Patients.FindAsync(id);
            if (patient != null)
            {
                _db.Patients.Remove(patient);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // -----------------------------
        // AGENDAMENTO / GERENCIAMENTO
        // -----------------------------

        public IActionResult Management() => View();

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
                email = p.Email,
                phone = p.Phone,
                dateOfBirth = p.DateOfBirth,
                address = p.Address,
                specialtiesString = p.SpecialtiesString,
                procedure = p.SpecialtiesString,
                complaint = p.Complaint,
                appointmentDate = p.AppointmentDate,
                appointmentTime = p.AppointmentTime.HasValue ? p.AppointmentTime.Value.ToString(@"hh\:mm") : ""
            });

            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetByMonth(string month, string year)
        {
            if (!int.TryParse(month, out int monthInt) || !int.TryParse(year, out int yearInt))
                return BadRequest("Mês ou ano inválidos");

            var firstDay = new DateTime(yearInt, monthInt, 1);
            var lastDay = firstDay.AddMonths(1).AddDays(-1);

            var appointments = await _db.Patients
                .Where(p => p.AppointmentDate.HasValue &&
                            p.AppointmentDate.Value.Date >= firstDay.Date &&
                            p.AppointmentDate.Value.Date <= lastDay.Date)
                .Select(p => new
                {
                    id = p.ID,
                    name = p.Name,
                    appointmentDate = p.AppointmentDate,
                    appointmentTime = p.AppointmentTime.HasValue ? p.AppointmentTime.Value.ToString(@"hh\:mm") : ""
                })
                .ToListAsync();

            return Json(appointments);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var patient = await _db.Patients.FindAsync(id);
            if (patient == null) return NotFound();

            return Json(new
            {
                id = patient.ID,
                name = patient.Name,
                email = patient.Email,
                phone = patient.Phone,
                dateOfBirth = patient.DateOfBirth,
                address = patient.Address,
                specialtiesString = patient.SpecialtiesString,
                procedure = patient.SpecialtiesString,
                complaint = patient.Complaint,
                appointmentDate = patient.AppointmentDate,
                appointmentTime = patient.AppointmentTime.HasValue ? patient.AppointmentTime.Value.ToString(@"hh\:mm") : ""
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _db.Patients
                .Select(p => new
                {
                    id = p.ID,
                    name = p.Name
                })
                .ToListAsync();

            return Json(patients);
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailableTimes(DateTime date)
        {
            var allTimeSlots = new List<TimeSpan>();
            for (int hour = 8; hour < 18; hour++)
            {
                allTimeSlots.Add(new TimeSpan(hour, 0, 0));
                allTimeSlots.Add(new TimeSpan(hour, 30, 0));
            }

            var booked = await _db.Patients
                .Where(p => p.AppointmentDate.HasValue && p.AppointmentDate.Value.Date == date.Date && p.AppointmentTime.HasValue)
                .Select(p => p.AppointmentTime.Value)
                .ToListAsync();

            var available = allTimeSlots
                .Where(t => !booked.Contains(t))
                .OrderBy(t => t)
                .Select(t => t.ToString(@"hh\:mm"))
                .ToList();

            return Json(available);
        }

        [HttpGet]
        public async Task<IActionResult> CheckTimeAvailability(DateTime date, string time)
        {
            if (!TimeSpan.TryParse(time, out TimeSpan timeSpan))
            {
                return Json(new { isAvailable = false, message = "Formato de hora inválido." });
            }

            bool isAvailable = !await _db.Patients
                .AnyAsync(p => p.AppointmentDate.HasValue &&
                               p.AppointmentDate.Value.Date == date.Date &&
                               p.AppointmentTime.HasValue &&
                               p.AppointmentTime.Value == timeSpan);

            return Json(new
            {
                isAvailable,
                message = isAvailable ? "Horário disponível." : "Horário já ocupado. Por favor, escolha outro horário."
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reschedule(int id, DateTime appointmentDate, string appointmentTime, string? procedure, string? complaint)
        {
            var patient = await _db.Patients.FindAsync(id);
            if (patient == null)
            {
                return Json(new { success = false, message = "Paciente não encontrado." });
            }

            if (!TimeSpan.TryParse(appointmentTime, out TimeSpan timeSpan))
            {
                return Json(new { success = false, message = "Formato de hora inválido." });
            }

            bool isAvailable = !await _db.Patients
                .AnyAsync(p => p.ID != id &&
                               p.AppointmentDate.HasValue &&
                               p.AppointmentDate.Value.Date == appointmentDate.Date &&
                               p.AppointmentTime.HasValue &&
                               p.AppointmentTime.Value == timeSpan);

            if (!isAvailable)
            {
                return Json(new { success = false, message = "Horário já ocupado. Escolha outro horário." });
            }

            patient.AppointmentDate = appointmentDate;
            patient.AppointmentTime = timeSpan;
            if (!string.IsNullOrEmpty(procedure)) patient.SpecialtiesString = procedure;
            if (!string.IsNullOrEmpty(complaint)) patient.Complaint = complaint;

            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Consulta reagendada com sucesso!" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ScheduleAppointment(int patientId, DateTime appointmentDate, string appointmentTime, string? procedure, string? complaint)
        {
            var patient = await _db.Patients.FindAsync(patientId);
            if (patient == null)
            {
                return Json(new { success = false, message = "Paciente não encontrado." });
            }

            if (!TimeSpan.TryParse(appointmentTime, out TimeSpan timeSpan))
            {
                return Json(new { success = false, message = "Formato de hora inválido." });
            }

            bool isAvailable = !await _db.Patients
                .AnyAsync(p => p.AppointmentDate.HasValue &&
                               p.AppointmentDate.Value.Date == appointmentDate.Date &&
                               p.AppointmentTime.HasValue &&
                               p.AppointmentTime.Value == timeSpan);

            if (!isAvailable)
            {
                return Json(new { success = false, message = "Horário já ocupado. Escolha outro horário." });
            }

            patient.AppointmentDate = appointmentDate;
            patient.AppointmentTime = timeSpan;
            patient.SpecialtiesString = procedure;
            patient.Complaint = complaint;

            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Consulta agendada com sucesso!" });
        }

        [HttpGet]
        public async Task<IActionResult> SearchPatients(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return Json(new List<object>());

            var patients = await _db.Patients
                .Where(p => p.Name.Contains(query))
                .Select(p => new
                {
                    id = p.ID,
                    name = p.Name,
                    email = p.Email,
                    phone = p.Phone
                })
                .ToListAsync();

            return Json(patients);
        }
    }
}
