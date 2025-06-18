using SystemGestionHR.Data.Models;
using SystemGestionHR.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SystemGestionHR.Data.Repositories
{
    public class GenreRepository : BaseRepository, IGenreRepository
    {
        private EmployeDB _EmployeeDB;
        public GenreRepository(EmployeDB employeeDB) : base(employeeDB)
        {
            _EmployeeDB = employeeDB;
        }
        /// <summary>
        ///Obtenir Tout genres
        /// </summary>
        /// <returns></returns>
        public List<Genre> ObtenirTout()
        {
            return _EmployeeDB.Genres.ToList();
        }

        /// <summary>
        ///  Obtenir genre pour id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Genre? ObtenirParId(int id)
        {
            return _EmployeeDB.Genres.FirstOrDefault(g => g.GenreId == id);
        }
        /// <summary>
        /// Supprimer genre
        /// </summary>
        /// <param name="genre"></param>
        public void SupprimerGenre(Genre genre)
        {
            _EmployeeDB.Remove(genre);
        }

        /// <summary>
        /// Modifier genre data
        /// </summary>
        /// <param name="genreId"></param>
        /// <param name="genre"></param>
        public bool ModifierGenre(int genreId, Genre genre)
        {
            Genre? existingEntity = _EmployeeDB.Genres.Find(genreId);
            if (existingEntity == null)
            {
                return false;
            }
            else
            {
                _EmployeeDB.Entry(existingEntity).State = EntityState.Detached;
            }
            _EmployeeDB.Attach(genre);
            _EmployeeDB.Entry(genre).State = EntityState.Modified;
            return true;

        }

        /// <summary>
        /// Soumettre genre to database
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        public Genre SoumettreGenre(Genre genre)
        {
            EntityEntry<Genre> x = _EmployeeDB.Genres.Add(genre);
            return x.Entity;

        }
    }
}
