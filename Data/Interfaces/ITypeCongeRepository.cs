using SystemGestionHR.Data.Models;
using SystemGestionHR.Data;

namespace SystemGestionHR.Data.Interfaces
{
    public interface ITypeCongeRepository : IBaseRepository
    {
        public List<TypeConge> ObtenirTout();
        public TypeConge? ObtenirParId(int id);
        public TypeConge SoumettreTypeConge(TypeConge typeConge);
        bool ModifierTypeConge(int typeCongeId, TypeConge typeConge);
        public void SupprimerTypeConge(TypeConge typeConge);
    }
}
