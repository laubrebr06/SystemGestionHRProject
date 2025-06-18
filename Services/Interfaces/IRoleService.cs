using SystemGestionHR.Data.DTO;
using SystemGestionHR.Data.Models;

namespace SystemGestionHR.Services.Interfaces
{
    public interface IRoleService
    {
        public List<RoleDTO> ObtenirTout();
        public RoleDTO? ObtenirParId(int id);
        public bool ModifierRole(int roleId, RoleDTO roleDTO);
        public bool SupprimerRole(int id);
        public Role SoumettreRole(RoleDTO role);

    }
}
