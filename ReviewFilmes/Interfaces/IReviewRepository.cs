using ReviewFilmes.Models;

namespace ReviewFilmes.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        ICollection<Review> GetReviewsByFilme(int id);
        bool ExisteReview(string titulo);
        bool ExisteReviewFilme(int id);
        bool CreateReview(string titulo, string texto, int filmeId, int nota);
        bool DeleteReview(Review review);
        bool Save();
    }
}
