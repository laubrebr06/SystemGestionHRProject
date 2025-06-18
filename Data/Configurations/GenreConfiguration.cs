using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemGestionHR.Data.Models;

namespace SystemGestionHR.Data.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(a => a.Nom).HasMaxLength(50);
            List<Genre> genres = new List<Genre>();
            genres.Add(new Genre
            {
                GenreId = 1,
                Nom = "Masculin"
            });
            genres.Add(new Genre
            {
                GenreId = 2,
                Nom = "Féminin"
            });
            builder.HasData(genres);
        }
    }
}
