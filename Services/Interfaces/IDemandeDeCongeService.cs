using SystemGestionHR.Data.DTO;
using SystemGestionHR.Data.Models;

namespace SystemGestionHR.Services.Interfaces
{
    public interface IDemandeDeCongeService
    {
 
        public DemandeDeConge SoumettreDemandeDeConge(DemandeDeCongeDTO dtoDemandeDeConge);
        public DemandeDeCongeDTO ObtenirDemandeDeCongeParId(int id);
        public bool ApprouverDemandeDeConge(int id, string? comentarioManagerHR);
        public bool RejeterDemandeDeConge(int id, string? comentarioManagerHR);
        public string VerifierEnAttenteDemandeDeConge(DemandeDeConge demandeDeConge);
        public bool ModifierDemandeDeConge(int demandeDeCongeId, DemandeDeCongeDTO demandeDeCongeDTO);
        public bool SupprimerDemandeDeConge(int demandeDeCongeId);
        
    }
}
