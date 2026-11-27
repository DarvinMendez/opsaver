using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using opsaver.Data;
using opsaver.Models;

namespace opsaver.Controllers
{
    public class PacientesController : Controller
    {
        private readonly OpsaverDbContext _contexto;

        public PacientesController(OpsaverDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Pacientes.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var paciente = await _contexto.Pacientes
                .FirstOrDefaultAsync(p => p.Id == id);

            if (paciente == null)
                return NotFound();

            return View(paciente);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("NombreCompleto,Correo,Telefono")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(paciente);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(paciente);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var paciente = await _contexto.Pacientes.FindAsync(id);

            if (paciente == null)
                return NotFound();

            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Id,NombreCompleto,Correo,Telefono")] Paciente paciente)
        {
            if (id != paciente.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _contexto.Update(paciente);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(paciente);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var paciente = await _contexto.Pacientes
                .FirstOrDefaultAsync(p => p.Id == id);

            if (paciente == null)
                return NotFound();

            return View(paciente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paciente = await _contexto.Pacientes.FindAsync(id);

            if (paciente != null)
            {
                _contexto.Pacientes.Remove(paciente);
                await _contexto.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}