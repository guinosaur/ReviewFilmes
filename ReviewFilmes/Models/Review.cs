namespace ReviewFilmes.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int FilmeId { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public int Nota { get; set; }
    }
}
