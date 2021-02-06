using CrudOperationEFCodeFirst0502.Entities.HumanResources;
using CrudOperationEFCodeFirst0502.Entities.Pers;
using Microsoft.EntityFrameworkCore;

namespace CrudOperationEFCodeFirst0502.DataContext
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public ApplicationContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-7QBD7T4;Database=EfCodeFirst;Trusted_Connection=True");
            //Server=DESKTOP-7QBD7T4;Database=EfCodeFirst;Trusted_Connection=True;MultipleActiveResultSets=true
            //Server=DESKTOP-7QBD7T4;DatabaseEfCodeFirst;User Id=DESKTOP-7QBD7T4/zhend;Password=
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasKey(x => x.PersonID);
            modelBuilder.Entity<Employee>().HasKey(x => x.BusinessEntityID);
        }
    }

}
