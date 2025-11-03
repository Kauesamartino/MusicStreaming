using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicStreaming.Context;
using MusicStreaming.Models;

namespace MusicStreaming.Controllers
{
    public class ArtistasController : Controller
    {
        private readonly AppDbContext _context;

        public ArtistasController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string search)
        {
            var artistas = _context.Artistas.Include(a => a.Musicas).AsQueryable();

            if (!string.IsNullOrEmpty(search))
                artistas = artistas.Where(a => a.Nome.Contains(search) || a.Sobrenome.Contains(search));

            ViewData["CurrentFilter"] = search; // <- guarda o valor para a view
            return View(await artistas.ToListAsync());
        }
        public async Task<IActionResult> Details(int id)
        {
            var artista = await _context.Artistas
                                .Include(a => a.Musicas)
                                .FirstOrDefaultAsync(a => a.Id == id);
            if (artista == null) return NotFound();
            return View(artista);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Artista artista)
        {
            if (!ModelState.IsValid) return View(artista);
            _context.Add(artista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var artista = await _context.Artistas.FindAsync(id);
            if (artista == null) return NotFound();
            return View(artista);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Artista artista)
        {
            if (!ModelState.IsValid) return View(artista);
            _context.Update(artista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var artista = await _context.Artistas.FindAsync(id);
            if (artista == null) return NotFound();
            return View(artista);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artista = await _context.Artistas.FindAsync(id);
            if (artista != null)
                _context.Artistas.Remove(artista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
