using SystemGestionHR.Mappers.Interfaces;
using SystemGestionHR.Data.DTO;
using SystemGestionHR.Data.Models;

namespace SystemGestionHR.Mappers
{
    public class RoleMapper : IRoleMapper
    {

        public RoleDTO MapToRoleDTO(Role role)
        {

            RoleDTO roleDTO = new RoleDTO();
            roleDTO.RoleId = role.RoleId;
            roleDTO.Nom = role.Nom;
            return roleDTO;
        }

        public Role MapToRole(RoleDTO roleDTO)
        {
            Role role = new Role();
            role.RoleId = roleDTO.RoleId;
            role.Nom = roleDTO.Nom;
            return role;
        }
    }
}
