using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemGestionHR.Data.Models;
using SystemGestionHR.Data.Enum;

namespace SystemGestionHR.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(a => a.Nom).HasMaxLength(50);

            List<Role> Roles = new List<Role>();
            Roles.Add(new Role
            {
                RoleId = (int)RoleEnum.Employe,
                Nom = "Employe"
            });
            Roles.Add(new Role
            {
                RoleId = (int)RoleEnum.HR_Manger,
                Nom = "HR Manger"
            });
            builder.HasData(Roles);
        }
    }
}
