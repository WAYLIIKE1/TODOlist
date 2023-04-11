using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Todolist.Data.Models;
using Task = Todolist.Data.Models.Task;

namespace Todolist.Data;

public partial class TodolistContext : DbContext
{
    public TodolistContext()
    {
    }

    public TodolistContext(DbContextOptions<TodolistContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-GE9TOPT;Initial Catalog=todolist;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCat).HasName("PK__categori__D54686DE462B2C2E");

            entity.ToTable("categories");

            entity.Property(e => e.IdCat).HasColumnName("id_cat");
            entity.Property(e => e.NameCat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name_cat");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tasks__3213E83F30C20160");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DueDate)
                .HasColumnType("date")
                .HasColumnName("due_date");
            entity.Property(e => e.IdCat).HasColumnName("id_cat");
            entity.Property(e => e.IsCompleted).HasColumnName("is_completed");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.IdCatNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.IdCat)
                .HasConstraintName("FK__Tasks__id_cat__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
