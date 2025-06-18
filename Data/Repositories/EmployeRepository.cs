using SystemGestionHR.Data.DTO;
using SystemGestionHR.Data.Models;
using SystemGestionHR.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SystemGestionHR.Data.Repositories
{
    public class EmployeRepository : BaseRepository, IEmployeRepository
    {
        private EmployeDB _EmployeeDB;
        public EmployeRepository(EmployeDB employeeDB) : base(employeeDB)
        {
            _EmployeeDB = employeeDB;
        }
        /// <summary>
        /// Soumettre Employe to Database
        /// </summary>
        /// <param name="employe"></param>
        /// <returns></returns>
        public Employe SoumettreEmploye(Employe employe)
        {
            EntityEntry<Employe> x = _EmployeeDB.Employes.Add(employe);
            return x.Entity;

        }
        /// <summary>
        /// Supprimer Employe
        /// </summary>
        /// <param name="employe"></param>
        public void SupprimerEmploye(Employe employe)
        {
            _EmployeeDB.Remove(employe);
        }

        /// <summary>
        /// Modifier Employe data
        /// </summary>
        /// <param name="employeId"></param>
        /// <param name="employe"></param>
        /// <returns></returns>
        public bool ModifierEmploye(int employeId, Employe employe)
        {
            Employe? existingEntity = _EmployeeDB.Employes.Find(employeId);
            if (existingEntity == null)
            {
                return false;
            }
            else
            {
                _EmployeeDB.Entry(existingEntity).State = EntityState.Detached;
            }
            _EmployeeDB.Attach(employe);
            _EmployeeDB.Entry(employe).State = EntityState.Modified;
            return true;
        }
        /// <summary>
        /// Obtenir Tout Employes
        /// </summary>
        /// <returns></returns>
        public List<Employe> ObtenirTout()
        {
            List<Employe> employes = new List<Employe>();
            employes = _EmployeeDB.Employes
                    .Include(u => u.Genre)
                    .Include(u => u.Role)
                    .ToList();
            return employes;
        }

        /// <summary>
        /// Obtenir Employe DTO by Id complet data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EmployeDTO? ObtenirEmployeFullDetailsParId(int id)
        {
            EmployeDTO? employeDto = (from employe in _EmployeeDB.Employes

                                   join genre in _EmployeeDB.Genres
                                on employe.GenreId equals genre.GenreId

                                join role in _EmployeeDB.Roles
                                on employe.RoleId equals role.RoleId

                                where employe.EmployeId == id
                                select new { employe, role, genre })
                                .GroupBy(tuple => new
                                {
                                    EmployeId = tuple.employe.EmployeId,
                                    NomComplet = tuple.employe.NomComplet,
                                    Email = tuple.employe.Email,
                                    DateNaissante = tuple.employe.DateNaissance,
                                    RoleId = tuple.employe.RoleId,
                                    RoleName = tuple.role.Nom,
                                    GenreId = tuple.employe.GenreId,
                                    GenreName = tuple.genre.Nom,

                                })
                                .Select(grp => new EmployeDTO
                                {
                                    EmployeId = grp.Key.EmployeId,
                                    NomComplet = grp.Key.NomComplet,
                                    Email = grp.Key.Email,
                                    DateNaissante = grp.Key.DateNaissante,
                                    RoleId = grp.Key.RoleId,
                                    Role = grp.Key.RoleName,
                                    GenreId = grp.Key.GenreId,
                                    Genre = grp.Key.GenreName
                                }).FirstOrDefault();

            return employeDto;
        }


        /// <summary>
        /// Obtenir employe Pour by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employe? ObtenirParId(int id)
        {
            Employe? employe = _EmployeeDB.Employes
                .Include(u => u.DemandesConge)
                .FirstOrDefault(u => u.EmployeId == id);
            return employe;
        }

    }
}
