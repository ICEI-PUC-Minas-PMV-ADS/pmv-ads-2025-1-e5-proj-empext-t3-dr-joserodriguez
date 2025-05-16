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

        // GET: Patient/GetByMonth
        [HttpGet]
        public async Task<IActionResult> GetByMonth(string month, string year)
        {
            if (!int.TryParse(month, out int monthInt) || !int.TryParse(year, out int yearInt))
            {
                return BadRequest("Mês ou ano inválidos");
            }

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

        // GET: Patient/GetById
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
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

        // GET: Patient/GetAllPatients
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

        // GET: Patient/GetAvailableTimes
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

        // GET: Patient/CheckTimeAvailability
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

        // ✅ POST: Patient/Reschedule
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

        // (outros métodos como Create, Edit, Delete seguem aqui – mantidos do seu código anterior)
        // Posso completá-los também, caso queira incluir tudo em um só lugar.
    }
}
