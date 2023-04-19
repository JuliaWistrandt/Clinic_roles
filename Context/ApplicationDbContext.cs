using Clinic_IndividualWork_KazanovAlexandr.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clinic_IndividualWork_KazanovAlexandr.Context
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }



        public DbSet<ClinicDepartment> ClinicDepartment { get; set; } = null!;
        public DbSet<Doctor> Doctor { get; set; } = null!;
        public DbSet<OutpatientCard> OutpatientCard { get; set; } = null!;
        public DbSet<Patient> Patient { get; set; } = null!;
        public DbSet<Position> Position { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClinicDepartment>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("ClinicDepartment_PK");
                entity.Property(e => e.Id)
                            .HasColumnName("ID")
                            .IsRequired();
                entity.Property(e => e.Name);
                entity.Property(e => e.Description);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Position_PK");
                entity.Property(e => e.Id)
                            .HasColumnName("ID")
                            .IsRequired();
                entity.Property(e => e.Name);
                entity.Property(e => e.Salary);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Patient_PK");
                entity.Property(e => e.Id)
                            .HasColumnName("ID")
                            .IsRequired();
                entity.Property(e => e.FirstName);
                entity.Property(e => e.SecondName);
                entity.Property(e => e.Complaints);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Doctor_PK");
                entity.Property(e => e.Id)
                            .HasColumnName("ID")
                            .IsRequired();
                entity.Property(e => e.FirstName);
                entity.Property(e => e.SecondName);
                entity.Property(e => e.PositionId).HasColumnName("PositionID");
                entity.HasOne(p => p.Position).WithMany(e => e.Doctor)
                            .HasForeignKey(p => p.PositionId)
                            .HasConstraintName("FK_Doctor_Position");
            });

            modelBuilder.Entity<OutpatientCard>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("OutpatientCard_PK");
                entity.Property(e => e.Id)
                            .HasColumnName("ID")
                            .IsRequired();
                entity.Property(e => e.TreatmentPlan);
                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");
                entity.Property(e => e.PatientId).HasColumnName("PatientID");
                entity.HasOne(p => p.Doctor).WithMany(e => e.OutpatientCard)
                            .HasForeignKey(p => p.DoctorId)
                            .HasConstraintName("FK_Doctor_OutpatientCard");
                entity.HasOne(p => p.Patient).WithMany(e => e.OutpatientCard)
                            .HasForeignKey(p => p.PatientId)
                            .HasConstraintName("FK_Patient_OutpatientCard");
            });
        }
    }
}
