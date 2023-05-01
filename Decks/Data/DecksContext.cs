using System;
using System.Collections.Generic;
using Decks.Models;
using Microsoft.EntityFrameworkCore;

namespace Decks.Data;

public partial class DecksContext : DbContext
{
    public DecksContext()
    {
    }

    public DecksContext(DbContextOptions<DecksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<Deck> Decks { get; set; }

    public virtual DbSet<Progress> Progresses { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CS-02\\SQLEXPRESS01;Initial Catalog=Decks;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Card>(entity =>
        {
            entity.ToTable("Card");

            entity.Property(e => e.Back).HasMaxLength(50);
            entity.Property(e => e.Front).HasMaxLength(50);
            entity.Property(e => e.TimesStudied).HasColumnName("Times_Studied");

            entity.HasOne(d => d.Deck).WithMany(p => p.Cards)
                .HasForeignKey(d => d.DeckId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Card_Deck");
        });

        modelBuilder.Entity<Deck>(entity =>
        {
            entity.ToTable("Deck");

            entity.Property(e => e.DeckId).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Tag).WithMany(p => p.Decks)
                .HasForeignKey(d => d.TagId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Deck_Tag");

            entity.HasOne(d => d.User).WithMany(p => p.Decks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Deck_User");
        });

        modelBuilder.Entity<Progress>(entity =>
        {
            entity.ToTable("Progress");

            entity.Property(e => e.CardsMastered).HasColumnName("Cards_Mastered");
            entity.Property(e => e.CardsStudied).HasColumnName("Cards_Studied");

            entity.HasOne(d => d.User).WithMany(p => p.Progresses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Progress_User");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.ToTable("Tag");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
