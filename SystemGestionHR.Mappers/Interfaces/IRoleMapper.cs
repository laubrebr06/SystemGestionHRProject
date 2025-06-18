using SystemGestionHR.Data.DTO;
using SystemGestionHR.Data.Models;

namespace SystemGestionHR.Mappers.Interfaces
{
    public interface IRoleMapper
    {
        public Role MapToRole(RoleDTO roleDTO);
        public RoleDTO MapToRoleDTO(Role role);
    }
}
