using SystemGestionHR.Data.DTO;
using SystemGestionHR.Data.Models;
using SystemGestionHR.Mappers.Interfaces;
using SystemGestionHR.Data.Interfaces;
using SystemGestionHR.Services.Interfaces;

namespace SystemGestionHR.Services
{
    public class EmployeService : IEmployeService
    {
        private readonly IEmployeRepository _employeRepository;
        private readonly IDemandeDeCongeRepository _demandeDeCongeRepository;
        private readonly IEmployeMapper _employeMapper;
        private readonly ITypeCongeRepository _typeCongeRepository;
        public EmployeService(IEmployeRepository employeRepository, IEmployeMapper employeMapper, ITypeCongeRepository typeConge)
        {
            _employeRepository = employeRepository;
            _employeMapper = employeMapper;
            _typeCongeRepository = typeConge;
        }
        /// <summary>
        /// Soumettre Employe to DB
        /// </summary>
        /// <param name="employe"></param>
        /// <returns></returns>
        public Employe SoumettreEmploye(EmployeDTO employe)
        {
            Employe employeEntity = _employeMapper.MapToEmploye(employe);
            List<TypeConge> typesConge = _typeCongeRepository.ObtenirTout();

            Employe addEmploye = _employeMapper.MapToEmploye(employe);

            return addEmploye;
        }

        /// <summary>
        /// Supprimer employe pour id
        /// </summary>
        /// <param name="employeId"></param>
        /// <returns></returns>
        public bool SupprimerEmploye(int employeId)
        {
            Employe? employe = _employeRepository.ObtenirParId(employeId); ;
            if (employe == null)
            {
                return false;
            }
            employe.DemandesConge.ForEach(demandeDeConge =>
            {
                _demandeDeCongeRepository.SupprimerDemandeDeConge(demandeDeConge);
            });

            _employeRepository.SupprimerEmploye(employe);
            return true;
        }

        /// <summary>
        /// Modifier Employe data
        /// </summary>
        /// <param name="employeId"></param>
        /// <param name="employeDTO"></param>
        public bool ModifierEmploye(int employeId, EmployeDTO employeDTO)
        {
            Employe employeEntity = _employeMapper.MapToEmploye(employeDTO);
            return _employeRepository.ModifierEmploye(employeId, employeEntity);
        }

        /// <summary>
        /// Obtenir tout employes DTO
        /// </summary>
        /// <returns></returns>
        public List<EmployeDTO> ObtenirTout()
        {
            List<EmployeDTO> employes = new List<EmployeDTO>();

            List<Employe> employeEntities = _employeRepository.ObtenirTout();
            employeEntities.ForEach(employeEntity =>
            {
                //call mapper 
                EmployeDTO userDTO = _employeMapper.MapToEmployeDTO(employeEntity);
                employes.Add(userDTO);
            });

            return employes;
        }

        /// <summary>
        /// Obtenir Employe DTO pour id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EmployeDTO? ObtenirParId(int id)
        {
            EmployeDTO? employe = _employeRepository.ObtenirEmployeFullDetailsParId(id);
            return employe;

        }
    }
}
