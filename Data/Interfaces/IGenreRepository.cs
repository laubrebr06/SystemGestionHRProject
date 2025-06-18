using SystemGestionHR.Data.Models;

namespace SystemGestionHR.Data.Interfaces
{
    public interface IGenreRepository : IBaseRepository
    {
        public List<Genre> ObtenirTout();
        public Genre? ObtenirParId(int id);

        public Genre SoumettreGenre(Genre genre);
        bool ModifierGenre(int genreId, Genre genre);
        public void SupprimerGenre(Genre genre);
    }
}
