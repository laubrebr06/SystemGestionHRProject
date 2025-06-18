using SystemGestionHR.Data.Models;
using SystemGestionHR.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SystemGestionHR.Data.Repositories
{
    public class RoleRepository : BaseRepository, IRoleRepository
    {
        private EmployeDB _EmployeeDB;
        public RoleRepository(EmployeDB employeeDB) : base(employeeDB)
        {
            _EmployeeDB = employeeDB;
        }

        /// <summary>
        /// Obtenir Tout roles 
        /// </summary>
        /// <returns></returns>
        public List<Role> ObtenirTout()
        {
            List<Role> roles = (from role in _EmployeeDB.Roles select role).ToList();
            return roles;
        }

        /// <summary>
        /// get role by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Role ObtenirParId(int id)
        {
            Role role = new Role();
            role = (from g in _EmployeeDB.Roles where g.RoleId == id select g).FirstOrDefault();
            return role;
        }

        /// <summary>
        /// Supprimer role
        /// </summary>
        /// <param name="role"></param>
        public void SupprimerRole(Role role)
        {
            _EmployeeDB.Remove(role);
        }

        /// <summary>
        /// add role to database
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public Role SoumettreRole(Role role)
        {
            EntityEntry<Role> x = _EmployeeDB.Roles.Add(role);
            return x.Entity;

        }

        /// <summary>
        /// Modifier role data
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="role"></param>
        public bool ModifierRole(int roleId, Role role)
        {
            Role? existingEntity = _EmployeeDB.Roles.Find(roleId);
            if (existingEntity == null)
            {
                return false;
            }
            else
            {
                _EmployeeDB.Entry(existingEntity).State = EntityState.Detached;
            }
            _EmployeeDB.Attach(role);
            _EmployeeDB.Entry(role).State = EntityState.Modified;
            return true;

        }
    }
}
