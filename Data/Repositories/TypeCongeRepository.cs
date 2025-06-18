using SystemGestionHR.Data.Models;
using SystemGestionHR.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SystemGestionHR.Data.Repositories
{
    public class TypeCongeRepository : BaseRepository, ITypeCongeRepository
    {
        private EmployeDB _EmployeeDB;
        public TypeCongeRepository(EmployeDB employeeDB) : base(employeeDB)
        {
            _EmployeeDB = employeeDB;
        }

        /// <summary>
        /// add type Conge
        /// </summary>
        /// <param name="typeConge"></param>
        /// <returns></returns>
        public TypeConge SoumettreTypeConge(TypeConge typeConge)
        {
            EntityEntry<TypeConge> x = _EmployeeDB.TypeConge.Add(typeConge);
            return x.Entity;

        }

        /// <summary>
        /// Supprimer Type Conge
        /// </summary>
        /// <param name="typeConge"></param>
        public void SupprimerTypeConge(TypeConge typeConge)
        {
            _EmployeeDB.Remove(typeConge);
        }

        /// <summary>
        /// Modifier type Conge data
        /// </summary>
        /// <param name="typeCongeId"></param>
        /// <param name="typeConge"></param>
        /// <returns></returns>
        public bool ModifierTypeConge(int typeCongeId, TypeConge typeConge)
        {
            TypeConge? existingEntity = _EmployeeDB.TypeConge.Find(typeConge);

            if (existingEntity == null)
            {
                return false;
            }
            else
            {
                _EmployeeDB.Entry(existingEntity).State = EntityState.Detached;
            }
            _EmployeeDB.Attach(typeConge);
            _EmployeeDB.Entry(typeConge).State = EntityState.Modified;
            return true;
        }

        /// <summary>
        /// Obtenir Tout types Conge
        /// </summary>
        /// <returns></returns>
        public List<TypeConge> ObtenirTout()
        {
            List<TypeConge> vacationTypes = new List<TypeConge>();
            vacationTypes = _EmployeeDB.TypeConge.ToList();
            return vacationTypes;
        }

        /// <summary>
        /// get type conge by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TypeConge? ObtenirParId(int id)
        {
            TypeConge? typeCongeEntity = _EmployeeDB.TypeConge.Where(u => u.TypeCongeId == id).FirstOrDefault();
            return typeCongeEntity;
        }
    }
}
