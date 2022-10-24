using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Information> information { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Information>()
                .HasOne(a => a.AppUser)
                .WithMany(i =>i.Information)
                .HasForeignKey(x=>x.FkAppUser)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
  

        }
    }
}