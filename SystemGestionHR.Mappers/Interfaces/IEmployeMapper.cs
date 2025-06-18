using SystemGestionHR.Data.DTO;
using SystemGestionHR.Data.Models;

namespace SystemGestionHR.Mappers.Interfaces
{
    public interface IEmployeMapper
    {
        public Employe MapToEmploye(EmployeDTO employeDTO);
        public EmployeDTO MapToEmployeDTO(Employe employe);

    }
}
