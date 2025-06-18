using SystemGestionHR.Mappers.Interfaces;
using SystemGestionHR.Data.Interfaces;
using SystemGestionHR.Services.Interfaces;
using SystemGestionHR.Data.DTO;
using SystemGestionHR.Data.Models;

namespace SystemGestionHR.Services
{
    public class DemandeDeCongeService : IDemandeDeCongeService
    {
        private readonly IDemandeDeCongeRepository _demandeDeCongeRepository;
        private readonly IDemandeDeCongeMapper _demandeDeCongeMapper;
        public DemandeDeCongeService(IDemandeDeCongeRepository demandeDeCongeRepository, IDemandeDeCongeMapper demandeDeCongeMapper, ITypeCongeRepository typeConge)
        {
            _demandeDeCongeRepository = demandeDeCongeRepository;
            _demandeDeCongeMapper = demandeDeCongeMapper;
        }

        /// <summary>
        /// Soumettre demande De Conge
        /// </summary>
        /// <param name="dtoDemandeDeConge"></param>
        /// <returns></returns>
        public DemandeDeConge SoumettreDemandeDeConge(DemandeDeCongeDTO dtoDemandeDeConge)
        {
            // Aquí podrías aplicar más lógica, validaciones externas o consultar un repositorio
            DemandeDeConge demandeDeCongeEntity = _demandeDeCongeMapper.MapToDemandeDeConge(dtoDemandeDeConge);
            DemandeDeConge demandeDeCongeAdded = _demandeDeCongeRepository.SoumettreDemandeDeConge(demandeDeCongeEntity);

            // Lógica para persistencia iría aquí (por ejemplo, guardar en base de datos)

            return demandeDeCongeAdded;
        }

        /// <summary>
        /// Obtenir demande De Conge pour id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DemandeDeCongeDTO ObtenirDemandeDeCongeParId(int id)
        {
            DemandeDeCongeDTO demandeDeConge = _demandeDeCongeRepository.ObtenirDemandeDeCongeParId(id);

            return demandeDeConge;
        }

        /// <summary>
        /// approuver demandeDeConge
        /// </summary>
        /// <param name="demandeDeConge"></param>
        /// <returns></returns>
        public bool ApprouverDemandeDeConge(int id, string? comentarioManagerHR)
        {
            DemandeDeCongeDTO dtoDemandeDeConge = _demandeDeCongeRepository.ObtenirDemandeDeCongeParId(id);
            dtoDemandeDeConge.Status = true;
            DemandeDeConge demandeDeCongeEntity = _demandeDeCongeMapper.MapToDemandeDeConge(dtoDemandeDeConge);
            var result = _demandeDeCongeRepository.ModifierDemandeDeConge(demandeDeCongeEntity.DemandeDeCongeId, demandeDeCongeEntity);
            return result;
        }

        /// <summary>
        /// rejecter demande De Conge
        /// </summary>
        /// <param name="demandeDeConge"></param>
        /// <returns></returns>
        public bool RejeterDemandeDeConge(int id, string? comentarioManagerHR)
        {
            DemandeDeCongeDTO dtoDemandeDeConge = _demandeDeCongeRepository.ObtenirDemandeDeCongeParId(id);
            dtoDemandeDeConge.Status = false;
            DemandeDeConge demandeDeCongeEntity = _demandeDeCongeMapper.MapToDemandeDeConge(dtoDemandeDeConge);
            var result = _demandeDeCongeRepository.ModifierDemandeDeConge(demandeDeCongeEntity.DemandeDeCongeId, demandeDeCongeEntity);
            return result;
        }

        /// <summary>
        /// vérifier the demand De Conge est en attente
        /// </summary>
        /// <param name="demandeDeConge"></param>
        /// <returns></returns>
        public string VerifierEnAttenteDemandeDeConge(DemandeDeConge demandeDeConge)
        {
            if (demandeDeConge == null)
            {
                return "Aucune Demande de Congé Trouvée";
            }
            else if (demandeDeConge.Status != null)
            {
                return "Le statut de la Demande de Congé est En Attente!!!!!!";
            }
            return string.Empty;
        }

        /// <summary>
        /// Supprimer demande De Conge
        /// </summary>
        /// <param name="demandeDeCongeId"></param>
        /// <returns></returns>
        public bool SupprimerDemandeDeConge(int demandeDeCongeId)
        {
            DemandeDeConge? demandeDeConge = _demandeDeCongeRepository.GetEntityById(demandeDeCongeId);
            if (demandeDeConge == null)
            {
                return false;
            }

            _demandeDeCongeRepository.SupprimerDemandeDeConge(demandeDeConge);
            return true;
        }

        /// <summary>
        /// Modifier demande De Conge data 
        /// </summary>
        /// <param name="demandeDeCongeId"></param>
        /// <param name="demandeDeCongeDTO"></param>
        public bool ModifierDemandeDeConge(int demandeDeCongeId, DemandeDeCongeDTO demandeDeCongeDTO)
        {
            DemandeDeConge demandeDeCongeEntity = _demandeDeCongeMapper.MapToDemandeDeConge(demandeDeCongeDTO);
            return _demandeDeCongeRepository.ModifierDemandeDeConge(demandeDeCongeId, demandeDeCongeEntity);
        }
    }
}
