using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BussinessObject.Models;

public partial class CartoonFilm2023DbContext : DbContext
{
    public CartoonFilm2023DbContext()
    {
    }

    public CartoonFilm2023DbContext(DbContextOptions<CartoonFilm2023DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CartoonFilmInformation> CartoonFilmInformations { get; set; }

    public virtual DbSet<MemberAccount> MemberAccounts { get; set; }

    public virtual DbSet<Producer> Producers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(GetConnectionString());


    private string GetConnectionString()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        return configuration["ConnectionStrings:CartoonFilm2023DB"];
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CartoonFilmInformation>(entity =>
        {
            entity.HasKey(e => e.CartoonFilmId).HasName("PK__CartoonF__BEE8C0842F29CC27");

            entity.ToTable("CartoonFilmInformation");

            entity.Property(e => e.CartoonFilmId).ValueGeneratedNever();
            entity.Property(e => e.CartoonFilmDescription).HasMaxLength(250);
            entity.Property(e => e.CartoonFilmName).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ProducerId).HasMaxLength(30);

            entity.HasOne(d => d.Producer).WithMany(p => p.CartoonFilmInformations)
                .HasForeignKey(d => d.ProducerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__CartoonFi__Produ__3C69FB99");
        });

        modelBuilder.Entity<MemberAccount>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PK__MemberAc__0CF04B3856DAF975");

            entity.ToTable("MemberAccount");

            entity.HasIndex(e => e.Email, "UQ__MemberAc__A9D105344EE448CB").IsUnique();

            entity.Property(e => e.MemberId)
                .ValueGeneratedNever()
                .HasColumnName("MemberID");
            entity.Property(e => e.Email).HasMaxLength(60);
            entity.Property(e => e.FullName).HasMaxLength(60);
            entity.Property(e => e.Password).HasMaxLength(40);
        });

        modelBuilder.Entity<Producer>(entity =>
        {
            entity.HasKey(e => e.ProducerId).HasName("PK__Producer__1336965285681E63");

            entity.ToTable("Producer");

            entity.Property(e => e.ProducerId).HasMaxLength(30);
            entity.Property(e => e.Country).HasMaxLength(60);
            entity.Property(e => e.ProducerDescription).HasMaxLength(250);
            entity.Property(e => e.ProducerName).HasMaxLength(90);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
