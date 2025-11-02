using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MusicStreaming.Context;
using MusicStreaming.Models;

namespace MusicStreaming.Pages.Musicas
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        public IList<Musica> Musicas { get; set; } = new List<Musica>();

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Musicas = await _context.Musicas.Include(m => m.Artista).ToListAsync();
        }
    }
}
