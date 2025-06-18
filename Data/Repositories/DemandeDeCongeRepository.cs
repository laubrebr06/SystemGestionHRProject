using SystemGestionHR.Data.DTO;
using SystemGestionHR.Data.Models;
using SystemGestionHR.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SystemGestionHR.Data.Repositories
{
    public class DemandeDeCongeRepository : BaseRepository, IDemandeDeCongeRepository
    {
        private EmployeDB _EmployeeDB;
        public DemandeDeCongeRepository(EmployeDB employeeDB) : base(employeeDB)
        {
            _EmployeeDB = employeeDB;
        }

        /// <summary>
        /// Soumettre Demande de Conge to DB
        /// </summary>
        /// <param name="demandeDeConge></param>
        /// <returns></returns>
        public DemandeDeConge SoumettreDemandeDeConge(DemandeDeConge demandeDeConge)
        {
            try
            {
                EntityEntry<DemandeDeConge> x = _EmployeeDB.DemandeDeConge.Add(demandeDeConge);
                return x.Entity;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// SupprimerDemande de Conge
        /// </summary>
        /// <param name="demandeDeConge"></param>
        public void SupprimerDemandeDeConge(DemandeDeConge demandeDeConge)
        {
            try
            {
                _EmployeeDB.Remove(demandeDeConge);
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Modifier demande data
        /// </summary>
        /// <param name="demandeDeCongeId"></param>
        /// <param name="demandeDeConge"></param>
        /// <returns></returns>
        public bool ModifierDemandeDeConge(int demandeDeCongeId, DemandeDeConge demandeDeConge)
        {
            try
            {
                DemandeDeConge? existingEntity = _EmployeeDB.DemandeDeConge.Find(demandeDeConge);
                if (existingEntity == null)
                {
                    return false;
                }
                else
                {
                    _EmployeeDB.Entry(existingEntity).State = EntityState.Detached;
                }
                _EmployeeDB.Attach(demandeDeConge);
                _EmployeeDB.Entry(demandeDeConge).State = EntityState.Modified;
                return true;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtenir Demande De Conge pour id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DemandeDeCongeDTO ObtenirDemandeDeCongeParId(int id)
        {
            try 
            { 
                DemandeDeCongeDTO? demandeDeCongeDto = (from demandeDeConge in _EmployeeDB.DemandeDeConge

                                                        join employe in _EmployeeDB.Employes
                                                          on demandeDeConge.EmployeId equals employe.EmployeId

                                                        join typeConge in _EmployeeDB.TypeConge
                                                          on demandeDeConge.TypeConge.TypeCongeId equals typeConge.TypeCongeId

                                                    where demandeDeConge.DemandeDeCongeId == id
                                                          select new DemandeDeCongeDTO
                                                          {
                                                              DemandeDeCongeId = demandeDeConge.DemandeDeCongeId,
                                                              TypeCongeId = demandeDeConge.TypeCongeId,
                                                              EmployeId = employe.EmployeId,
                                                              Status = demandeDeConge.Status,
                                                              DateFin = demandeDeConge.DateFin,
                                                              DateDebut = demandeDeConge.DateDebut,
                                                              CommentaireEmploye = demandeDeConge.CommentaireEmploye,
                                                              CommentaireManager = demandeDeConge.CommentaireManager,
                                                              TypeConge = typeConge != null ? typeConge.Nom : String.Empty
                                                          }
                                                         ).FirstOrDefault();
                return demandeDeCongeDto;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// get demande entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DemandeDeConge? GetEntityById(int id)
        { 
            try
            { 
                DemandeDeConge? demandeDeConge = _EmployeeDB.DemandeDeConge.FirstOrDefault(x => x.DemandeDeCongeId == id);
                return demandeDeConge;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }

    }
}
