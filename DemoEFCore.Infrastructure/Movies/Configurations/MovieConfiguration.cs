using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoEFCore.Infrastructure.Movies.Configurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.Property(m => m.Title)
            .IsRequired()
            .HasMaxLength(250);
        builder.Property(m => m.ReleaseDate)
            .HasColumnType("date");
        builder.Property(m => m.Description)
            .HasMaxLength(1000);
    }
}
