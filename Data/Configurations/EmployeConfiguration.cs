using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemGestionHR.Data.Models;


namespace SystemGestionHR.Data.Configurations
{
    public class EmployeConfiguration : IEntityTypeConfiguration<Employe>
    {
        public void Configure(EntityTypeBuilder<Employe> builder)
        {
            builder.Property(a => a.NomComplet).HasMaxLength(100);
            builder.Property(a => a.Email).HasMaxLength(100);

        }
    }
}
