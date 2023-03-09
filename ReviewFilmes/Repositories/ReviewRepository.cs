using Microsoft.EntityFrameworkCore.Diagnostics;
using ReviewFilmes.Data;
using ReviewFilmes.Interfaces;
using ReviewFilmes.Models;

namespace ReviewFilmes.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;

        public ReviewRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.OrderBy(r => r.Titulo).ToList();
        }

        public ICollection<Review> GetReviewsByFilme(int id)
        {
            return _context.Reviews.Where(r => r.FilmeId == id).ToList();
        }

        public bool ExisteReview(string titulo)
        {
            return _context.Reviews.Where(r => r.Titulo == titulo).Any();
        }

        public bool ExisteReviewFilme(int id)
        {
            return _context.Reviews.Where(r => r.FilmeId == id).Any();
        }

        public bool CreateReview(string titulo, string texto, int filmeId, int nota)
        {
            var review = new Review() {
                Titulo = titulo,
                Texto = texto,
                FilmeId = filmeId,
                Nota = nota
            };

            _context.Reviews.Add(review);

            return Save();
        }

        public bool DeleteReview(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteReview(Review review)
        {
            _context.Remove(review);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0;
        }
    }
}
