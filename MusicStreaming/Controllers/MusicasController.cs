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
    public class MusicasController : Controller
    {
        private readonly AppDbContext _context;

        public MusicasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Musica>>> GetMusicas()
        {
            return await _context.Musicas
                .Include(m => m.Artista)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Musica>> GetMusica(int id)
        {
            var musica = await _context.Musicas
                .Include(m => m.Artista)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (musica == null)
                return NotFound();

            return musica;
        }

        [HttpPost]
        public async Task<ActionResult<Musica>> PostMusica(Musica musica)
        {
            var artista = await _context.Artistas.FindAsync(musica.ArtistaId);
            if (artista == null)
                return BadRequest("Artista não encontrado.");

            _context.Musicas.Add(musica);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMusica), new { id = musica.Id }, musica);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusica(int id)
        {
            var musica = await _context.Musicas.FindAsync(id);
            if (musica == null)
                return NotFound();

            _context.Musicas.Remove(musica);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
