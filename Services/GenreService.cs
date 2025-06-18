using SystemGestionHR.Mappers.Interfaces;
using SystemGestionHR.Data.DTO;
using SystemGestionHR.Data.Models;
using SystemGestionHR.Data.Interfaces;
using SystemGestionHR.Services.Interfaces;

namespace SystemGestionHR.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IGenreMapper _genreMapper;
        public GenreService(IGenreRepository genreRepository, IGenreMapper genreMapper)
        {
            _genreRepository = genreRepository;
            _genreMapper = genreMapper;
        }


        /// <summary>
        /// Obtenir Tout of genres DTO
        /// </summary>
        /// <returns></returns>
        public List<GenreDTO> ObtenirTout()
        {
            List<GenreDTO> genres = new List<GenreDTO>();
            genres = _genreRepository.ObtenirTout().Select(g => _genreMapper.MapToGenreDTO(g)).ToList();
            return genres;
        }

        /// <summary>
        /// Obtenir genreDTO pour genre Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GenreDTO? ObtenirParId(int id)
        {
            Genre? genre = _genreRepository.ObtenirParId(id);
            if (genre == null)
            {
                return null;
            }
            GenreDTO genreDTO = _genreMapper.MapToGenreDTO(genre);
            return genreDTO;
        }

        /// <summary>
        /// Soumettre genre to db
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        public Genre SoumettreGenre(GenreDTO genre)
        {
            Genre genreEntity = _genreMapper.MapToGenre(genre);
            return _genreRepository.SoumettreGenre(genreEntity);
        }

        /// <summary>
        /// Supprimer genre 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool SupprimerGenre(int id)
        {
            Genre? genre = _genreRepository.ObtenirParId(id); ;
            if (genre == null)
            {
                return false;
            }
            _genreRepository.SupprimerGenre(genre);
            return true;

        }

        /// <summary>
        /// Modifier genre data 
        /// </summary>
        /// <param name="genreId"></param>
        /// <param name="genreDTO"></param>
        /// <returns></returns>
        public bool ModifierGenre(int genreId, GenreDTO genreDTO)
        {
            Genre genreEntity = _genreMapper.MapToGenre(genreDTO);
            return _genreRepository.ModifierGenre(genreId, genreEntity);
        }

    }
}
