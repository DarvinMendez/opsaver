using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using opsaver.Data;

namespace opsaver.Controllers
{
    public class ModeracionResenasController : Controller
    {
        private readonly OpsaverDbContext _contexto;

        public ModeracionResenasController(OpsaverDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            var resenas = await _contexto.Resenas
                .Include(r => r.Medico)
                .Include(r => r.Paciente)
                .OrderByDescending(r => r.Fecha)
                .ToListAsync();

            return View(resenas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminar(int id)
        {
            var resena = await _contexto.Resenas.FindAsync(id);

            if (resena != null)
            {
                _contexto.Resenas.Remove(resena);
                await _contexto.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}