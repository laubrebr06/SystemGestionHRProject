using SystemGestionHR.Data.DTO;
using SystemGestionHR.Data.Models;

namespace SystemGestionHR.Services.Interfaces
{
    public interface IEmployeService
    {
        public List<EmployeDTO> ObtenirTout();
        public EmployeDTO? ObtenirParId(int id);
        public Employe SoumettreEmploye(EmployeDTO user);
        public bool ModifierEmploye(int employeId, EmployeDTO employeDTO);
        public bool SupprimerEmploye(int employeId);
    }
}
