using SystemGestionHR.Mappers.Interfaces;
using SystemGestionHR.Data.DTO;
using SystemGestionHR.Data.Models;

namespace SystemGestionHR.Mappers
{
    public class DemandeDeCongeMapper : IDemandeDeCongeMapper
    {
        public DemandeDeCongeDTO MapToDemandeDeCongeDTO(DemandeDeConge demandeDeConge)
        {
            DemandeDeCongeDTO demandeDeCongeDTO = new DemandeDeCongeDTO();

            demandeDeCongeDTO.DemandeDeCongeId = demandeDeConge.DemandeDeCongeId;
            demandeDeCongeDTO.EmployeId = demandeDeConge.EmployeId;
            demandeDeCongeDTO.Status = demandeDeConge.Status;
            demandeDeCongeDTO.TypeCongeId = demandeDeConge.TypeCongeId;
            demandeDeCongeDTO.NomComplet = demandeDeConge.Employe != null ? demandeDeConge.Employe.NomComplet : "";
            demandeDeCongeDTO.TypeConge = demandeDeConge.TypeConge != null ? demandeDeConge.TypeConge.Nom : "";
            demandeDeCongeDTO.DateDebut = demandeDeConge.DateDebut;
            demandeDeCongeDTO.DateFin = demandeDeConge.DateFin;
            demandeDeCongeDTO.CommentaireEmploye = demandeDeConge.CommentaireEmploye;
            demandeDeCongeDTO.CommentaireManager = demandeDeConge.CommentaireManager;
            return demandeDeCongeDTO;
        }

        public DemandeDeConge MapToDemandeDeConge(DemandeDeCongeDTO demandeDeCongeDTO)
        {
            DemandeDeConge demandeDeConge = new DemandeDeConge();

            demandeDeConge.DemandeDeCongeId = demandeDeCongeDTO.DemandeDeCongeId;
            demandeDeConge.TypeCongeId = demandeDeCongeDTO.TypeCongeId;
            demandeDeConge.EmployeId = demandeDeCongeDTO.EmployeId;
            demandeDeConge.Status = demandeDeCongeDTO.Status;
            demandeDeConge.DateDebut = demandeDeCongeDTO.DateDebut;
            demandeDeConge.DateFin = demandeDeCongeDTO.DateFin;
            demandeDeConge.CommentaireEmploye = demandeDeCongeDTO.CommentaireEmploye;
            demandeDeConge.CommentaireManager = demandeDeCongeDTO.CommentaireManager;
            return demandeDeConge;
        }
    }
}
