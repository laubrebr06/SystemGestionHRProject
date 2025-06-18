using SystemGestionHR.Mappers.Interfaces;
using SystemGestionHR.Data.DTO;
using SystemGestionHR.Data.Models;

namespace SystemGestionHR.Mappers
{
    public class TypeCongeMapper : ITypeCongeMapper
    {
        public TypeCongeDTO MapToTypeCongeDTO(TypeConge typeConge)
        {
            TypeCongeDTO typeCongeDTO = new TypeCongeDTO();
            typeCongeDTO.ValeurInitiale = typeConge.ValeurInitiale;
            typeCongeDTO.TypeCongeId = (int)typeConge.TypeCongeId;
            typeCongeDTO.Nom = typeConge.Nom;
            return typeCongeDTO;
        }

        public TypeConge MapToTypeConge(TypeCongeDTO typeCongeDTO)
        {
            TypeConge typeConge = new TypeConge();
            typeConge.ValeurInitiale = typeCongeDTO.ValeurInitiale;
            typeConge.TypeCongeId = typeCongeDTO.TypeCongeId;
            typeConge.Nom = typeCongeDTO.Nom;
            return typeConge;
        }
    }
}
