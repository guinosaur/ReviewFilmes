using ReviewFilmes.Models;

namespace ReviewFilmes.Classes
{
    public class Filme
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
