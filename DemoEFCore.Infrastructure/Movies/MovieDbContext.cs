using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DemoEFCore.Infrastructure.Movies;

public class MovieDbContext: DbContext
{
    public MovieDbContext(DbContextOptions<MovieDbContext> options): base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieDbContext).Assembly);
            
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<MovieActor> MoviesActors { get; set; }
}
