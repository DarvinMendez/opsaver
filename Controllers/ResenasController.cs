using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using opsaver.Data;
using opsaver.Models;

namespace opsaver.Controllers
{
    public class ResenasController : Controller
    {
        private readonly OpsaverDbContext _contexto;

        public ResenasController(OpsaverDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            var resenas = await _contexto.Resenas
                .Include(r => r.Medico)
                .Include(r => r.Paciente)
                .ToListAsync();

            return View(resenas);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var resena = await _contexto.Resenas
                .Include(r => r.Medico)
                .Include(r => r.Paciente)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (resena == null)
                return NotFound();

            return View(resena);
        }

        public async Task<IActionResult> Create()
        {
            await CargarListasAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Calificacion,Comentario,Fecha,MedicoId,PacienteId")] Resena resena)
        {

            if (ModelState.IsValid)
            {
                _contexto.Add(resena);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

          
            await CargarListasAsync(resena.MedicoId, resena.PacienteId);
            return View(resena);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var resena = await _contexto.Resenas.FindAsync(id);

            if (resena == null)
                return NotFound();

            await CargarListasAsync(resena.MedicoId, resena.PacienteId);
            return View(resena);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Id,Calificacion,Comentario,Fecha,MedicoId,PacienteId")] Resena resena)
        {

            if (id != resena.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _contexto.Update(resena);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            await CargarListasAsync(resena.MedicoId, resena.PacienteId);
            return View(resena);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var resena = await _contexto.Resenas
                .Include(r => r.Medico)
                .Include(r => r.Paciente)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (resena == null)
                return NotFound();

            return View(resena);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resena = await _contexto.Resenas.FindAsync(id);

            if (resena != null)
            {
                _contexto.Resenas.Remove(resena);
                await _contexto.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task CargarListasAsync(
            int? medicoId = null,
            int? pacienteId = null)
        {
            ViewData["MedicoId"] = new SelectList(
                await _contexto.Medicos.OrderBy(m => m.NombreCompleto).ToListAsync(),
                "Id",
                "NombreCompleto",
                medicoId);

            ViewData["PacienteId"] = new SelectList(
                await _contexto.Pacientes.OrderBy(p => p.NombreCompleto).ToListAsync(),
                "Id",
                "NombreCompleto",
                pacienteId);
        }
    }
}