using Microsoft.EntityFrameworkCore;
using Movies_Tickets_Ecommerce_App.Models;

namespace Movies_Tickets_Ecommerce_App.Data
{
    public class AppDbContext:DbContext
    {
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Cinema> Cinemas { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Actors_Movies> Actors_Movies { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actors_Movies>().HasKey(AM => new { AM.ActorId, AM.MovieId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
