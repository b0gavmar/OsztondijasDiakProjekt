using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OsztondijasDiakProjekt.Models;

public partial class ScholarshipContext : DbContext
{
    public ScholarshipContext()
    {
    }

    public ScholarshipContext(DbContextOptions<ScholarshipContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ScholarshipApplicant> Scholarships { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=scholarship.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ScholarshipApplicant>(entity =>
        {
            entity
                //.HasNoKey()
                .ToTable("scholarship");

            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.ScholarshipAmount)
                .HasColumnType("INT")
                .HasColumnName("scholarship_amount");

            entity.HasKey(entity => entity.Email);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
