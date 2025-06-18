using SystemGestionHR.Data.DTO;
using SystemGestionHR.Data.Models;

namespace SystemGestionHR.Services.Interfaces
{
    public interface IGenreService
    {
        public List<GenreDTO> ObtenirTout();
        public GenreDTO? ObtenirParId(int id);
        public bool ModifierGenre(int genreId, GenreDTO genreDTO);
        public bool SupprimerGenre(int id);
        public Genre SoumettreGenre(GenreDTO genre);


    }
}
