using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KeysDemoDb.Models;

public partial class KeysDemoDbContext : DbContext
{
    public KeysDemoDbContext()
    {
    }

    public KeysDemoDbContext(DbContextOptions<KeysDemoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<VCitiesInCountry> VCitiesInCountries { get; set; }

    public virtual DbSet<VStudentInfo> VStudentInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=MSI;Initial Catalog=KeysDemoDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cities__3214EC07C4C5A370");

            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__Cities__CountryI__267ABA7A");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Countrie__3214EC0721BC8918");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Courses__3214EC073B14CA51");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC07C06ECF39");

            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);

            entity.HasMany(d => d.Courses).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentPlan",
                    r => r.HasOne<Course>().WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CourseId_Courses"),
                    l => l.HasOne<Student>().WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_StudentId_Students"),
                    j =>
                    {
                        j.HasKey("StudentId", "CourseId").HasName("PK_StudentPlan");
                    });
        });

        modelBuilder.Entity<VCitiesInCountry>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vCitiesInCountries");

            entity.Property(e => e.CityName).HasMaxLength(100);
            entity.Property(e => e.CountryName).HasMaxLength(100);
            entity.Property(e => e.PartOfTotal).HasMaxLength(4000);
        });

        modelBuilder.Entity<VStudentInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vStudentInfo");

            entity.Property(e => e.FirstName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
