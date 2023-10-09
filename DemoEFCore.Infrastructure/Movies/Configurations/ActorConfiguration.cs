using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoEFCore.Infrastructure.Movies.Configurations;

public class ActorConfiguration : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
       builder.Property( a => a.Salary)
             .HasColumnType("decimal(18,2)");
        builder.Property(a => a.BirthDate)
              .HasColumnType("date");
    }
}
