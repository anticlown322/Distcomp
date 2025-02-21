﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class RepositoryContext : DbContext
{
    public DbSet<Editor> Editors { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Mark> Marks { get; set; }
    
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) 
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Editor>()
            .HasIndex(u => u.Login)
            .IsUnique();

        modelBuilder.Entity<Editor>()
            .ToTable("tbl_editor");
        
        modelBuilder.Entity<Mark>()
            .ToTable("tbl_mark");
        
        modelBuilder.Entity<Article>()
            .ToTable("tbl_article");
        
        modelBuilder.Entity<Post>()
            .ToTable("tbl_post");
        
        modelBuilder.Entity<Article>()
            .HasIndex(s => s.Title)
            .IsUnique();

        modelBuilder.Entity<Mark>()
            .HasIndex(t => t.Name)
            .IsUnique();
    }
}