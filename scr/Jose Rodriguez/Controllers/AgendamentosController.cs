using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginCadastroMVC.Models;
using SeuProjeto.Services;
using SeuProjeto.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace LoginCadastroMVC.Controllers
{
    public class AgendamentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Removido EmailService já que não vamos mais enviar emails
        public AgendamentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new AgendamentoViewModel();
            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> GetHorariosOcupados(string? data)
        {
            if (string.IsNullOrEmpty(data))
                return Json(new List<string>());

            try
            {
                // Converter string para DateTime (formato: dd/MM/yyyy)
                if (DateTime.TryParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataAgendamento))
                {
                    // Buscar horários já agendados na tabela Agendamentos (pendentes)
                    var horariosAgendamentos = await _context.Agendamentos
                        .Where(a => a.Data.Date == dataAgendamento.Date)
                        .Select(a => a.Hora)
                        .ToListAsync();

                    // Buscar horários já confirmados na tabela Patients (confirmados)
                    var horariosPacientes = await _context.Patients
                        .Where(p => p.AppointmentDate.HasValue &&
                                   p.AppointmentDate.Value.Date == dataAgendamento.Date &&
                                   p.AppointmentTime.HasValue)
                        .Select(p => p.AppointmentTime.Value.ToString(@"hh\:mm"))
                        .ToListAsync();

                    // Combinar ambas as listas (horários ocupados = pendentes + confirmados)
                    var todosHorariosOcupados = horariosAgendamentos
                        .Concat(horariosPacientes)
                        .Distinct()
                        .ToList();

                    return Json(todosHorariosOcupados);
                }

                return Json(new List<string>());
            }
            catch
            {
                return Json(new List<string>());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Enviar(AgendamentoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Converter string de data e hora para objetos DateTime e string de hora
                    string[] partes = model.DataHora.Split(" - ");
                    if (partes.Length != 2)
                    {
                        ModelState.AddModelError(string.Empty, "Formato de data e hora inválido.");
                        return View("Index", model);
                    }

                    string dataString = partes[0]; // formato: dd/MM/yyyy
                    string hora = partes[1]; // formato: HH:mm

                    if (!DateTime.TryParseExact(dataString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data))
                    {
                        ModelState.AddModelError(string.Empty, "Formato de data inválido.");
                        return View("Index", model);
                    }

                    // Verificar se o horário já está ocupado
                    bool horarioOcupado = await _context.Agendamentos
                        .AnyAsync(a => a.Data.Date == data.Date && a.Hora == hora);

                    if (horarioOcupado)
                    {
                        TempData["ErrorMessage"] = "Este horário já está ocupado. Por favor, selecione outro horário.";
                        return View("Index", model);
                    }

                    // Criar e salvar o novo agendamento (SEM enviar email)
                    var agendamento = new Agendamento
                    {
                        Nome = model.Nome,
                        Email = model.Email,
                        Telefone = model.Telefone,
                        Especialidade = model.Especialidade,
                        Data = data,
                        Hora = hora,
                        Mensagem = model.Mensagem,
                        Confirmado = false // Inicialmente não confirmado - aguarda ação da recepcionista
                    };

                    _context.Agendamentos.Add(agendamento);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Agendamento realizado com sucesso! Em breve entraremos em contato.";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Erro ao enviar o agendamento: {ex.Message}");
                }
            }

            return View("Index", model);
        }

        // Método para cancelar/deletar agendamento (libera horário)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelarAgendamento(int id)
        {
            try
            {
                // Buscar o agendamento pendente
                var agendamento = await _context.Agendamentos.FindAsync(id);

                if (agendamento != null)
                {
                    // Deletar o agendamento pendente (libera horário)
                    _context.Agendamentos.Remove(agendamento);
                    await _context.SaveChangesAsync();
                    return Json(new { success = true, message = "Agendamento cancelado com sucesso! Horário liberado." });
                }

                return Json(new { success = false, message = "Agendamento não encontrado." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Erro ao cancelar agendamento: {ex.Message}" });
            }
        }

        // Novo método para cancelar paciente já confirmado
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelarPaciente(int id)
        {
            try
            {
                var patient = await _context.Patients.FindAsync(id);

                if (patient != null)
                {
                    _context.Patients.Remove(patient);
                    await _context.SaveChangesAsync();
                    return Json(new { success = true, message = "Consulta cancelada com sucesso! Horário liberado." });
                }

                return Json(new { success = false, message = "Paciente não encontrado." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Erro ao cancelar consulta: {ex.Message}" });
            }
        }

        // Método para confirmar agendamento e transferir para Patient
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarAgendamento(int id)
        {
            try
            {
                var agendamento = await _context.Agendamentos.FindAsync(id);
                if (agendamento == null)
                {
                    return Json(new { success = false, message = "Agendamento não encontrado." });
                }

                // Verificar se já existe um paciente com esse horário
                var existePaciente = await _context.Patients
                    .AnyAsync(p => p.AppointmentDate.HasValue &&
                                   p.AppointmentDate.Value.Date == agendamento.Data.Date &&
                                   p.AppointmentTime.HasValue &&
                                   p.AppointmentTime.Value == TimeSpan.Parse(agendamento.Hora));

                if (existePaciente)
                {
                    return Json(new { success = false, message = "Já existe um paciente confirmado para este horário." });
                }

                // Criar paciente baseado no agendamento
                var patient = new Patient
                {
                    Name = agendamento.Nome,
                    Email = agendamento.Email,
                    Phone = agendamento.Telefone,
                    AppointmentDate = agendamento.Data,
                    AppointmentTime = TimeSpan.Parse(agendamento.Hora),
                    SpecialtiesString = agendamento.Especialidade,
                    Complaint = agendamento.Mensagem ?? "",
                    DateOfBirth = DateTime.Now.AddYears(-30), // Valor padrão - será editado depois
                    Address = "A definir" // Valor padrão - será editado depois
                };

                // Adicionar paciente (MANTÉM o horário bloqueado)
                _context.Patients.Add(patient);

                // Remover agendamento original (já que foi confirmado)
                _context.Agendamentos.Remove(agendamento);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Agendamento confirmado! Paciente adicionado ao sistema e horário mantido bloqueado." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Erro ao confirmar agendamento: {ex.Message}" });
            }
        }

        // Método para buscar agendamentos por data
        [HttpGet]
        public async Task<JsonResult> GetAgendamentosPorData(string? data)
        {
            if (string.IsNullOrEmpty(data))
                return Json(new List<object>());

            try
            {
                if (DateTime.TryParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataAgendamento))
                {
                    var agendamentos = await _context.Agendamentos
                        .Where(a => a.Data.Date == dataAgendamento.Date)
                        .OrderBy(a => a.Hora)
                        .Select(a => new {
                            id = a.Id,
                            nome = a.Nome,
                            email = a.Email,
                            telefone = a.Telefone,
                            especialidade = a.Especialidade,
                            hora = a.Hora,
                            mensagem = a.Mensagem ?? "",
                            confirmado = a.Confirmado
                        })
                        .ToListAsync();

                    return Json(agendamentos);
                }

                return Json(new List<object>());
            }
            catch
            {
                return Json(new List<object>());
            }
        }
    }
}