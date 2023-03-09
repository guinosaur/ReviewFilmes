using ReviewFilmes.Classes;

namespace ReviewFilmes.Interfaces
{
    public interface IFilmeRepository
    {
        ICollection<Filme> GetFilmes();
        Filme GetFilme(int id);
        Filme GetFilme(string nome);
        decimal GetNotaFilme(int id);
        bool ExisteFilme(int id);
        bool ExisteFilme(string nome);
        bool CreateFilme(string nome, string genero);
        bool DeleteFilme(Filme filme);
        bool Save();
    }
}
