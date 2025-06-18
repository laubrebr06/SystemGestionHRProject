using SystemGestionHR.Data.DTO;
using SystemGestionHR.Data.Models;

namespace SystemGestionHR.Mappers.Interfaces
{
    public interface IGenreMapper
    {
        public Genre MapToGenre(GenreDTO genreDTO);
        public GenreDTO MapToGenreDTO(Genre genre);
    }
}
