using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tv_Shows.Models;

namespace Tv_Shows
{
    public class TvContext : DbContext
    {
        public TvContext(DbContextOptions<TvContext> options)
            : base(options)
        {
            Database.Migrate();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Tvshow> TvShows { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public virtual DbSet<UserTvshow> UserTvshows { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=TvShowsDb;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString)
                .UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTvshow>()
                        .HasKey(bc => new { bc.UserId, bc.TvshowId });
            modelBuilder.Entity<UserTvshow>()
                        .HasOne(b => b.User)
                        .WithMany(bc => bc.UserTvshows)
                        .HasForeignKey(b => b.UserId);
            modelBuilder.Entity<UserTvshow>()
                        .HasOne(c => c.Tvshow)
                        .WithMany(bc => bc.UserTvshows)
                        .HasForeignKey(c => c.TvshowId);
        }


        }
}
   
