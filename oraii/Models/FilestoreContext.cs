using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace oraii.Models;

public partial class FilestoreContext : DbContext
{
    public FilestoreContext()
    {
    }

    public FilestoreContext(DbContextOptions<FilestoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<File> Files { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=filestore;user=root;password=password");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<File>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("files");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContentType)
                .HasMaxLength(255)
                .HasColumnName("contentType");
            entity.Property(e => e.FilName)
                .HasMaxLength(255)
                .HasColumnName("filName");
            entity.Property(e => e.FileData).HasColumnName("fileData");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
