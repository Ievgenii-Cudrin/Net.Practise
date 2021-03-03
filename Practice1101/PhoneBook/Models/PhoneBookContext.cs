using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Models
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext(DbContextOptions<PhoneBookContext> options)
            : base(options)
        {

        }

        public DbSet<Record> Records { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users").HasKey(x => x.Id);

            modelBuilder.Entity<Status>().ToTable("Statuses").HasKey(x => x.Id);

            modelBuilder.Entity<Record>().ToTable("Records").HasKey(x => x.Id);

            modelBuilder.Entity<User>()
                .HasMany(c => c.Records)
                .WithOne(e => e.User)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Status>()
                .HasMany(c => c.Records)
                .WithOne(e => e.Status)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
