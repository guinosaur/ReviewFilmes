using ReviewFilmes.Classes;
using ReviewFilmes.Data;
using ReviewFilmes.Interfaces;

namespace ReviewFilmes.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly DataContext _context;

        public FilmeRepository(DataContext context) 
        {
            _context = context;
        }

        public ICollection<Filme> GetFilmes()
        {
            return _context.Filmes.OrderBy(f => f.Nome).ToList();
        }

        public Filme GetFilme(int id)
        {
            return _context.Filmes.Where(f => f.Id == id).FirstOrDefault();
        }

        public decimal GetNotaFilme(int id)
        {
            var review = _context.Reviews.Where(r => r.FilmeId == id).ToList();

            if (!review.Any())
            {
                return 0;
            }

            return (decimal)review.Sum(r => r.Nota) / review.Count();
        }

        public bool ExisteFilme(int id)
        {
            return _context.Filmes.Where(f => f.Id == id).Any();
        }

        public bool ExisteFilme(string nome)
        {
            return _context.Filmes.Any(f => f.Nome == nome);
        }

        public bool CreateFilme(string nome, string genero)
        {
            var filme = new Filme() { 
                Genero = genero,
                Nome = nome 
            };
            
            _context.Filmes.Add(filme);
            
            return Save();
        }

        public bool DeleteFilme(Filme filme)
        {
            _context.Filmes.Remove(filme);
            
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            
            return saved > 0;
        }
    }
}
