using SystemGestionHR.Data.DTO;
using SystemGestionHR.Data.Models;
using SystemGestionHR.Data;

namespace SystemGestionHR.Data.Interfaces
{
    public interface IEmployeRepository : IBaseRepository
    {
        public List<Employe> ObtenirTout();
        public Employe? ObtenirParId(int id);
        public EmployeDTO? ObtenirEmployeFullDetailsParId(int id);
        public Employe SoumettreEmploye(Employe employe);
        public bool ModifierEmploye(int employeId, Employe employe);
        public void SupprimerEmploye(Employe employe);
    }
}
