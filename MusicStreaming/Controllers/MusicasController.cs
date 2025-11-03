using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicStreaming.Context;
using MusicStreaming.Models;

namespace MusicStreaming.Controllers
{
    public class MusicasController : Controller
    {
        private readonly AppDbContext _context;

        public MusicasController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string search)
        {
            var musicas = _context.Musicas.Include(m => m.Artista).AsQueryable();

            if (!string.IsNullOrEmpty(search))
                musicas = musicas.Where(m => m.Titulo.Contains(search));

            ViewData["CurrentFilter"] = search; // <- aqui guardamos o valor
            return View(await musicas.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var musica = await _context.Musicas
                .Include(m => m.Artista)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (musica == null) return NotFound();

            return View(musica);
        }

        public IActionResult Create()
        {
            ViewData["ArtistaId"] = new SelectList(_context.Artistas, "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Musica musica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(musica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ArtistaId"] = new SelectList(_context.Artistas, "Id", "Nome", musica.ArtistaId);
            return View(musica);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var musica = await _context.Musicas.FindAsync(id);
            if (musica == null) return NotFound();

            ViewData["ArtistaId"] = new SelectList(_context.Artistas, "Id", "Nome", musica.ArtistaId);
            return View(musica);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Musica musica)
        {
            if (id != musica.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(musica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ArtistaId"] = new SelectList(_context.Artistas, "Id", "Nome", musica.ArtistaId);
            return View(musica);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var musica = await _context.Musicas
                .Include(m => m.Artista)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (musica == null) return NotFound();

            return View(musica);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var musica = await _context.Musicas.FindAsync(id);
            if (musica != null)
            {
                _context.Musicas.Remove(musica);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var musica = await _context.Musicas
                                .Include(m => m.Artista)
                                .FirstOrDefaultAsync(m => m.Id == id);
            if (musica == null) return NotFound();
            return View(musica);
        }

    }
}
