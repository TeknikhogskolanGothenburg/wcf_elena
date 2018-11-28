using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;

namespace CarRentalServiceDL
{
    public class CarRentalServicesDBContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasKey(m => new { m.Id });
            modelBuilder.Entity<Car>().Property(m => m.Regnumber)
                .IsRequired()
                .HasMaxLength(6)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                                    new IndexAnnotation(
                                        new System.ComponentModel.DataAnnotations.Schema.IndexAttribute("Unique Regnumber", 1) { IsUnique = true }));
            modelBuilder.Entity<Customer>().HasKey(m => new { m.Id });
            modelBuilder.Entity<Customer>().Property(m => m.Email)
                .HasMaxLength(40)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                                     new IndexAnnotation(
                                         new System.ComponentModel.DataAnnotations.Schema.IndexAttribute("Unique email", 1) { IsUnique = true }));
            modelBuilder.Entity<Reservation>().HasKey(m => new { m.Id });

        }

        public CarRentalServicesDBContext() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CarRentalServices;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {

        }
    }
}
