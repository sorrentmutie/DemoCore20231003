using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoEFCore.Infrastructure.Movies.Configurations;

public class CommentDbConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder
           .Property(c => c.Text)
           .IsRequired()
           .HasMaxLength(150);
    }
}
