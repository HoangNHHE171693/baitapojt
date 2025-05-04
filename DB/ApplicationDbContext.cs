using BaiTapOceanTech.Models;
using Microsoft.EntityFrameworkCore;
using static BaiTapOceanTech.Utility.Status;

namespace BaiTapOceanTech.DB;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Tinh> Tinh { get; set; }
    public DbSet<Huyen> Huyen { get; set; }
    public DbSet<Xa> Xas { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<EmployeeCertificate> EmployeeCertificates { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tinh>(entity =>
        {
            entity.ToTable("Tinh");
            entity.HasKey(t => t.Id);
            entity.Property(t => t.Id).ValueGeneratedOnAdd();
            entity.Property(t => t.Name).IsRequired().HasMaxLength(100);
            entity.Property(t => t.PostalCode).IsRequired().HasMaxLength(100);
            entity.HasIndex(t => t.PostalCode).IsUnique();
            entity.Property(t => t.CreatedDate).IsRequired().HasMaxLength(100);
            entity.Property(t => t.UpdatedDate).HasMaxLength(100);

            entity.Property(t => t.Status).IsRequired().HasMaxLength(100)
            .HasConversion(status => (int)status,
            value => (Statuss)value);

            entity.HasMany(h => h.Huyens)
            .WithOne(t => t.Tinh)
            .HasForeignKey(t => t.IdTinh).OnDelete(DeleteBehavior.Cascade); 

            entity.HasMany(e => e.Employees)
            .WithOne(t => t.Tinh)
            .HasForeignKey(t => t.IdTinh).OnDelete(DeleteBehavior.Cascade); 

            entity.HasMany(c => c.Certificates)
            .WithOne(t => t.Tinh)
            .HasForeignKey(t => t.IdTinh).OnDelete(DeleteBehavior.Cascade); 
        });

        modelBuilder.Entity<Huyen>(entity =>
        {
            entity.ToTable("Huyen");
            entity.HasKey(h => h.Id);
            entity.Property(h => h.Id).ValueGeneratedOnAdd();
            entity.Property(h => h.Name).IsRequired().HasMaxLength(100);
            entity.Property(h => h.PostalCode).IsRequired().HasMaxLength(100);
            entity.HasIndex(h => h.PostalCode).IsUnique();
            entity.Property(h => h.CreatedDate).IsRequired().HasMaxLength(100);
            entity.Property(h => h.UpdatedDate).HasMaxLength(100);

            entity.Property(h => h.Status).IsRequired().HasMaxLength(100)
            .HasConversion(status => (int)status,
            value => (Statuss)value);

            entity.HasOne(t =>t.Tinh)
            .WithMany(h => h.Huyens)
            .HasForeignKey(t => t.IdTinh).OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(x => x.Xas)
            .WithOne(h => h.Huyen)
            .HasForeignKey(h => h.IdHuyen).OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.Employees)
            .WithOne(h => h.Huyen)
            .HasForeignKey(h => h.IdHuyen).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Xa>(entity =>
        {
            entity.ToTable("Xa");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entity.Property(x => x.PostalCode).IsRequired().HasMaxLength(100);
            entity.HasIndex(x => x.PostalCode).IsUnique();
            entity.Property(x => x.CreatedDate).IsRequired().HasMaxLength(100);
            entity.Property(x => x.UpdatedDate).HasMaxLength(100);

            entity.Property(x => x.Status).IsRequired().HasMaxLength(100)
            .HasConversion(status => (int)status,
            value => (Statuss)value);

            entity.HasOne(h => h.Huyen)
            .WithMany(x => x.Xas)
            .HasForeignKey(h => h.IdHuyen).OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.Employees)
            .WithOne(x => x.Xa)
            .HasForeignKey(x => x.IdXa).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employees");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entity.Property(x => x.Code).IsRequired().HasMaxLength(100);
            entity.HasIndex(x => x.Code).IsUnique();
            entity.Property(x => x.CreatedDate).IsRequired().HasMaxLength(100);
            entity.Property(x => x.UpdatedDate).HasMaxLength(100);
            entity.Property(x => x.ActiveCertificateCount).HasMaxLength(10);
            entity.Property(x => x.TotalCertificateCount).HasMaxLength(10);
            entity.Property(x => x.Age).HasMaxLength(100).IsRequired();
            entity.Property(x => x.Phone).HasMaxLength(100).IsRequired();
            entity.Property(x => x.Dob).HasMaxLength(100).IsRequired();
            
            entity.Property(x => x.Status).IsRequired().HasMaxLength(100)
            .HasConversion(status => (int)status,
            value => (EmployeeD)value);

            entity.Property(x => x.Job).IsRequired().HasMaxLength(100)
            .HasConversion(job => (int)job,
            value => (Job)value);

            entity.Property(x => x.Ethnic).IsRequired().HasMaxLength(100)
            .HasConversion(ethnic => (int)ethnic,
            value => (Ethnic)value);

            entity.HasOne(x => x.Xa)
            .WithMany(e => e.Employees)
            .HasForeignKey(x => x.IdXa).OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(h => h.Huyen)
            .WithMany(e => e.Employees)
            .HasForeignKey(h => h.IdHuyen).OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(t => t.Tinh)
            .WithMany(e => e.Employees)
            .HasForeignKey(t => t.IdTinh).OnDelete(DeleteBehavior.Cascade);


            entity.HasMany(c => c.EmployeeCertificates)
            .WithOne(e => e.Employee)
            .HasForeignKey(e => e.EmployeeId).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Certificate>(entity =>
        {
            entity.ToTable("Certificate");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entity.Property(x => x.Description).IsRequired().HasMaxLength(100);


            entity.Property(x => x.Status).IsRequired().HasMaxLength(100)
            .HasConversion(status => (int)status,
            value => (CertificateD)value);

            entity.HasOne(t => t.Tinh)
            .WithMany(c => c.Certificates)
            .HasForeignKey(t => t.IdTinh).OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(ec => ec.EmployeeCertificates)
            .WithOne(c => c.Certificate)
            .HasForeignKey(c => c.CertificateId).OnDelete(DeleteBehavior.Cascade);

        });

        modelBuilder.Entity<EmployeeCertificate>(entity =>
        {
            entity.ToTable("EmployeeCertificates");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.Property(x => x.IssueDate).IsRequired().HasMaxLength(100);
            entity.Property(x => x.ExpiredDate).IsRequired().HasMaxLength(100);
            entity.Property(x => x.Status).IsRequired().HasMaxLength(100)
            .HasConversion(status => (int)status,
            value => (CertificateD)value);

            entity.HasOne(e => e.Employee)
            .WithMany(c => c.EmployeeCertificates)
            .HasForeignKey(e => e.EmployeeId).OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(c => c.Certificate)
            .WithMany(c => c.EmployeeCertificates)
            .HasForeignKey(c => c.CertificateId).OnDelete(DeleteBehavior.Cascade);

        });
    }
}
