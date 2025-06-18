using SystemGestionHR.Data.DTO;
using SystemGestionHR.Data.Models;

namespace SystemGestionHR.Mappers.Interfaces
{
    public interface IDemandeDeCongeMapper
    {
        public DemandeDeConge MapToDemandeDeConge(DemandeDeCongeDTO demandeDeCongeDTO);
        public DemandeDeCongeDTO MapToDemandeDeCongeDTO(DemandeDeConge demandeDeConge);

    }
}
