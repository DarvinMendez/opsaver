using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using opsaver.Data;
using opsaver.Models;

namespace opsaver.Controllers
{
    public class MedicosController : Controller
    {
        private readonly OpsaverDbContext _context;

        public MedicosController(OpsaverDbContext context)
        {
            _context = context;
        }

        // GET: Medicos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Medicos.ToListAsync());
        }

        // GET: Medicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var medico = await _context.Medicos
                .FirstOrDefaultAsync(m => m.Id == id);

            if (medico == null)
                return NotFound();

            return View(medico);
        }

        // GET: Medicos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medicos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("NombreCompleto,Especialidad,Correo,Telefono")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medico);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(medico);
        }

        // GET: Medicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var medico = await _context.Medicos.FindAsync(id);

            if (medico == null)
                return NotFound();

            return View(medico);
        }

        // POST: Medicos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Id,NombreCompleto,Especialidad,Correo,Telefono")] Medico medico)
        {
            if (id != medico.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(medico);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(medico);
        }

        // GET: Medicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var medico = await _context.Medicos
                .FirstOrDefaultAsync(m => m.Id == id);

            if (medico == null)
                return NotFound();

            return View(medico);
        }

        // POST: Medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medico = await _context.Medicos.FindAsync(id);

            if (medico != null)
            {
                _context.Medicos.Remove(medico);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
