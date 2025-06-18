using SystemGestionHR.Mappers.Interfaces;
using SystemGestionHR.Data.DTO;
using SystemGestionHR.Data.Models;

namespace SystemGestionHR.Mappers
{
    public class GenreMapper : IGenreMapper
    {

        public GenreDTO MapToGenreDTO(Genre genre)
        {

            GenreDTO genreDTO = new GenreDTO();
            genreDTO.GenreId = genre.GenreId;
            genreDTO.Nom = genre.Nom;
            return genreDTO;
        }

        public Genre MapToGenre(GenreDTO genreDTO)
        {
            Genre genre = new Genre();
            genre.GenreId = genreDTO.GenreId;
            genre.Nom = genreDTO.Nom;
            return genre;
        }
    }
}
