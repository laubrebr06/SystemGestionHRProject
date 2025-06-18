using SystemGestionHR.Data.DTO;
using SystemGestionHR.Data.Models;
using SystemGestionHR.Data;

namespace SystemGestionHR.Data.Interfaces
{
    public interface IDemandeDeCongeRepository : IBaseRepository
    {

        public DemandeDeCongeDTO ObtenirDemandeDeCongeParId(int id);
        public DemandeDeConge GetEntityById(int id);
        public DemandeDeConge SoumettreDemandeDeConge(DemandeDeConge demandeDeConge);
        public bool ModifierDemandeDeConge(int requestCongeId, DemandeDeConge demandeDeConge);
        public void SupprimerDemandeDeConge(DemandeDeConge demandeDeConge);
    }
}
