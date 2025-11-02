using Microsoft.EntityFrameworkCore;
using MusicStreaming.Models;

namespace MusicStreaming.Context
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}
		public DbSet<Musica> Musicas { get; set; }
		public DbSet<Artista> Artistas { get; set; }
	}
}