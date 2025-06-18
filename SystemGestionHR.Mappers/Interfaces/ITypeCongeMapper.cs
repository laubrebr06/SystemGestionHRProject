using SystemGestionHR.Data.DTO;
using SystemGestionHR.Data.Models;

namespace SystemGestionHR.Mappers.Interfaces
{
    public interface ITypeCongeMapper
    {
        public TypeConge MapToTypeConge(TypeCongeDTO typeCongeDTO);
        public TypeCongeDTO MapToTypeCongeDTO(TypeConge typeConge);

    }
}
