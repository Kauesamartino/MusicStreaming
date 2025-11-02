using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicStreaming.Context;
using MusicStreaming.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicStreaming.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistasController : Controller
    {
        private readonly AppDbContext _context;

        public ArtistasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artista>>> GetArtistas()
        {
            return await _context.Artistas
                .Include(a => a.Musicas)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Artista>> GetArtista(int id)
        {
            var artista = await _context.Artistas
                .Include(a => a.Musicas)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (artista == null)
                return NotFound();

            return artista;
        }

        [HttpPost]
        public async Task<ActionResult<Artista>> PostArtista(Artista artista)
        {
            _context.Artistas.Add(artista);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetArtista), new { id = artista.Id }, artista);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtista(int id)
        {
            var artista = await _context.Artistas.FindAsync(id);
            if (artista == null)
                return NotFound();

            _context.Artistas.Remove(artista);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
