using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemGestionHR.Data.Models;
using SystemGestionHR.Data.Enum;

namespace SystemGestionHR.Data.Configurations
{
    public class TypeCongeConfiguration : IEntityTypeConfiguration<TypeConge>
    {
        public void Configure(EntityTypeBuilder<TypeConge> builder)
        {
            builder.Property(a => a.Nom).HasMaxLength(50);

            List<TypeConge> typesConge = new List<TypeConge>();
            typesConge.Add(new TypeConge
            {
                TypeCongeId = (int)TypeCongeEnum.Vacances,
                Nom = "Vacances",
                ValeurInitiale = 7
            });
            typesConge.Add(new TypeConge
            {
                TypeCongeId = (int)TypeCongeEnum.Maladie,
                Nom = "Maladie",
                ValeurInitiale = 14
            });
            typesConge.Add(new TypeConge
            {
                TypeCongeId = (int)TypeCongeEnum.Personnel,
                Nom = "Personnel",
                ValeurInitiale = 21
            });
            typesConge.Add(new TypeConge
            {
                TypeCongeId = (int)TypeCongeEnum.Schedule,
                Nom = "Schedule",
                ValeurInitiale = 28
            });
            typesConge.Add(new TypeConge
            {
                TypeCongeId = (int)TypeCongeEnum.Autre,
                Nom = "Autre",
                ValeurInitiale = 35
            });
            builder.HasData(typesConge);
        }
    }
}
