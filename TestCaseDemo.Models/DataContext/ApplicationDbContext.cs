using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TestCaseDemo.Models.DataModels;

namespace TestCaseDemo.Models.DataContext;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actor> Actors { get; set; }

    public virtual DbSet<Film> Films { get; set; }

    public virtual DbSet<FilmActor> FilmActors { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("User ID = postgres;Password=Thakkar1003;Server=localhost;Port=5432;Database=FilmDB;Integrated Security=true;Pooling=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>(entity =>
        {
            entity.HasKey(e => e.ActorId).HasName("Actor_pkey");

            entity.Property(e => e.ActorId)
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(3L, null, null, null, null, null);
        });

        modelBuilder.Entity<Film>(entity =>
        {
            entity.HasKey(e => e.FilmId).HasName("Film_pkey");

            entity.Property(e => e.FilmId).UseIdentityAlwaysColumn();
        });

        modelBuilder.Entity<FilmActor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("FilmActor_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Actor).WithMany(p => p.FilmActors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FilmActor_ActorId_fkey");

            entity.HasOne(d => d.Film).WithMany(p => p.FilmActors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FilmId");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.LanguageId).HasName("language_id");

            entity.Property(e => e.LanguageId).UseIdentityAlwaysColumn();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
