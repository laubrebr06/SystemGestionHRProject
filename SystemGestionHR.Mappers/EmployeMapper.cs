using SystemGestionHR.Mappers.Interfaces;
using SystemGestionHR.Data.DTO;
using SystemGestionHR.Data.Models;

namespace SystemGestionHR.Mappers
{
    public class EmployeMapper : IEmployeMapper
    {
        public EmployeDTO MapToEmployeDTO(Employe user)
        {
            EmployeDTO employeDTO = new EmployeDTO();

            employeDTO.EmployeId = user.EmployeId;
            employeDTO.GenreId = user.GenreId;
            employeDTO.Genre = user.Genre != null ? user.Genre?.Nom : "";
            employeDTO.Role = user.Role != null ? user.Role?.Nom : "";
            employeDTO.DateNaissante = user.DateNaissance;
            employeDTO.NomComplet = user.NomComplet;
            employeDTO.Email = user.Email;
            employeDTO.RoleId = user.RoleId;
            return employeDTO;
        }

        public Employe MapToEmploye(EmployeDTO employeDTO)
        {
            Employe employe = new Employe();

            employe.EmployeId = employeDTO.EmployeId;
            employe.GenreId = employeDTO.GenreId;
            employe.DateNaissance = employeDTO.DateNaissante;
            employe.NomComplet = employeDTO.NomComplet;
            employe.Email = employeDTO.Email;
            employe.RoleId = employeDTO.RoleId;

            return employe;
        }
    }
}
