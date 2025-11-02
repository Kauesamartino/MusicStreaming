using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MusicStreaming.Context;
using MusicStreaming.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicStreaming.Pages.Artistas
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IList<Artista> Artistas { get; set; } = new List<Artista>();

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Artistas = await _context.Artistas.Include(a => a.Musicas).ToListAsync();
        }
    }
}
