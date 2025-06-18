using SystemGestionHR.Data.Models;
using SystemGestionHR.Data;

namespace SystemGestionHR.Data.Interfaces
{
    public interface IRoleRepository : IBaseRepository
    {
        public List<Role> ObtenirTout();
        public Role? ObtenirParId(int id);

        public Role SoumettreRole(Role role);
        bool ModifierRole(int roleId, Role role);
        public void SupprimerRole(Role role);
    }
}
