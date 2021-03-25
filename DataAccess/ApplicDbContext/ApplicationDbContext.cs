using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Ziekenhuis.Model;
using Ziekenhuis.Model.ConstantsAndEnums;

namespace Ziekenhuis.DataAccess.ApplicDbContext
{
    public class ApplicationDbContext : IdentityDbContext
    // ApplicationDbContext  / DbSet: gebruiken als je tabellen vanuit de code
    // creëert (CODE FIRST, goed bij intake). Let op: Database wel eerst
    // aanmaken in SQL Server. 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Consult> Consults { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

        public DbSet<PrescriptionLine> PrescriptionLines { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }

        public DbSet<NumberRange> NumberRanges { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<LogDebugInfo> LogDebugInfo { get; set; }
        public DbSet<LogWarningError> LogWarningError { get; set; }
        public DbSet<LogApiError> LogApiError { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder
            //    .Entity<Client>()
            //    .Property(c => c.AstrologyZodiacSign)
            //     .HasConversion(
            //         v => v.ToString(),
            //         v => (AstrologyZodiacSign)Enum.Parse(typeof(AstrologyZodiacSign), v));

            // Creatie van een index op Invoice Number en Client Number: 

            modelBuilder.Entity<Invoice>()
                .HasIndex(i => i.InvoiceNumber)
                .HasName("Index_InvoiceNumber")
                .IsUnique();

            modelBuilder.Entity<Client>()
               .HasIndex(c => c.ClientNumber)
               .HasName("Index_ClientNumber")
               .IsUnique();
        }


    }
}
