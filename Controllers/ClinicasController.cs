
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using opsaver.Models;
using opsaver.Data;

public class ClinicasController : Controller
{
    private readonly OpsaverDbContext _context;

    public ClinicasController(OpsaverDbContext context)
    {
        _context = context;
    }

    // GET: CLINICAS
    public async Task<IActionResult> Index()
    {
        return View(await _context.Clinicas
            .Include(c => c.Medicos)
            .ToListAsync());
    }

    // GET: CLINICAS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var clinica = await _context.Clinicas
        .Include(c => c.Medicos)
        .FirstOrDefaultAsync(c => c.Id == id);
        if (clinica == null)
        {
            return NotFound();
        }

        return View(clinica);
    }

    // GET: CLINICAS/Create
    public async Task<IActionResult> Create()
    {
        await CargarMedicos();
        return View();
    }

    private async Task CargarMedicos(IEnumerable<int>? medicosSeleccionados = null)
    {
        ViewBag.ListaMedicos = new MultiSelectList(
            await _context.Medicos
                .OrderBy(m => m.NombreCompleto)
                .ToListAsync(),
            "Id",
            "NombreCompleto",
            medicosSeleccionados
        );
    }

    // POST: CLINICAS/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Nombre,Direccion,Telefono,Correo")] Clinica clinica,
        int[] medicosSeleccionados)
    {
        if (ModelState.IsValid)
        {
            if (medicosSeleccionados != null)
            {
                clinica.Medicos = await _context.Medicos
                    .Where(m => medicosSeleccionados.Contains(m.Id))
                    .ToListAsync();
            }

            _context.Clinicas.Add(clinica);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        await CargarMedicos();
        return View(clinica);
    }

    // GET: CLINICAS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var clinica = await _context.Clinicas
            .Include(c => c.Medicos)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (clinica == null)
        {
            return NotFound();
        }

        await CargarMedicos(clinica.Medicos.Select(m => m.Id));

        return View(clinica);
    }

    // POST: CLINICAS/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        int? id,
        [Bind("Id,Nombre,Direccion,Telefono,Correo")] Clinica clinica,
        int[] medicosSeleccionados)
    {
        if (id != clinica.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var clinicaExistente = await _context.Clinicas
                .Include(c => c.Medicos)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (clinicaExistente == null)
            {
                return NotFound();
            }

            clinicaExistente.Nombre = clinica.Nombre;
            clinicaExistente.Direccion = clinica.Direccion;
            clinicaExistente.Telefono = clinica.Telefono;
            clinicaExistente.Correo = clinica.Correo;

            clinicaExistente.Medicos = await _context.Medicos
                .Where(m => medicosSeleccionados.Contains(m.Id))
                .ToListAsync();

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        await CargarMedicos(medicosSeleccionados);
        return View(clinica);
    }

    // GET: CLINICAS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var clinica = await _context.Clinicas
       .Include(c => c.Medicos)
       .FirstOrDefaultAsync(c => c.Id == id);
        if (clinica == null)
        {
            return NotFound();
        }

        return View(clinica);
    }

    // POST: CLINICAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var clinica = await _context.Clinicas.FindAsync(id);
        if (clinica != null)
        {
            _context.Clinicas.Remove(clinica);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ClinicaExists(int? id)
    {
        return _context.Clinicas.Any(e => e.Id == id);
    }
}
