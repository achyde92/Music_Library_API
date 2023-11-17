using Microsoft.EntityFrameworkCore;
using MusicLibraryAPI.Models;

namespace MusicLibraryAPI.Data
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Song> Songs { get; set; }

		public ApplicationDbContext(DbContextOptions options) : base(options)
		{

		}
	}
}

