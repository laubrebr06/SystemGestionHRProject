using SystemGestionHR.Data.DTO;
using SystemGestionHR.Data.Models;

namespace SystemGestionHR.Services.Interfaces
{
    public interface ITypeCongeService
    {
        public List<TypeCongeDTO> ObtenirTout();
        public TypeCongeDTO? ObtenirParId(int id);
        public TypeConge SoumettreTypeConge(TypeCongeDTO typeConge);
        public bool ModifierTypeConge(int typeCongeId, TypeCongeDTO typeCongeDTO);
        public bool SupprimerTypeConge(int typeCongeId);
    }
}
