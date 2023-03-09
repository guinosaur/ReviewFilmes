using Microsoft.EntityFrameworkCore;
using ReviewFilmes.Classes;
using ReviewFilmes.Models;

namespace ReviewFilmes.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
