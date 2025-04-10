using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HygdataHastighetstester;

public partial class HygdataContext : DbContext
{
    public HygdataContext()
    {
    }

    public HygdataContext(DbContextOptions<HygdataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HygdataV3> HygdataV3s { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserStar> UserStars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; AttachDbFilename=C:\\Users\\anton\\Hygdata.mdf");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HygdataV3>(entity =>
        {
            entity.ToTable("hygdata_v3");

            entity.HasIndex(e => new { e.Id, e.Spect }, "IX_hygdata_v3");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Absmag)
                .HasMaxLength(50)
                .HasColumnName("absmag");
            entity.Property(e => e.Base)
                .HasMaxLength(50)
                .HasColumnName("base");
            entity.Property(e => e.Bayer)
                .HasMaxLength(50)
                .HasColumnName("bayer");
            entity.Property(e => e.Bf)
                .HasMaxLength(50)
                .HasColumnName("bf");
            entity.Property(e => e.Ci)
                .HasMaxLength(50)
                .HasColumnName("ci");
            entity.Property(e => e.Comp).HasColumnName("comp");
            entity.Property(e => e.CompPrimary).HasColumnName("comp_primary");
            entity.Property(e => e.Con)
                .HasMaxLength(50)
                .HasColumnName("con");
            entity.Property(e => e.Dec)
                .HasMaxLength(50)
                .HasColumnName("dec");
            entity.Property(e => e.Decrad)
                .HasMaxLength(50)
                .HasColumnName("decrad");
            entity.Property(e => e.Dist)
                .HasMaxLength(50)
                .HasColumnName("dist");
            entity.Property(e => e.Flam)
                .HasMaxLength(50)
                .HasColumnName("flam");
            entity.Property(e => e.Gl)
                .HasMaxLength(50)
                .HasColumnName("gl");
            entity.Property(e => e.Hd)
                .HasMaxLength(50)
                .HasColumnName("hd");
            entity.Property(e => e.Hip).HasColumnName("hip");
            entity.Property(e => e.Hr)
                .HasMaxLength(50)
                .HasColumnName("hr");
            entity.Property(e => e.Lum)
                .HasMaxLength(50)
                .HasColumnName("lum");
            entity.Property(e => e.Mag)
                .HasMaxLength(50)
                .HasColumnName("mag");
            entity.Property(e => e.Pmdec)
                .HasMaxLength(50)
                .HasColumnName("pmdec");
            entity.Property(e => e.Pmdecrad)
                .HasMaxLength(50)
                .HasColumnName("pmdecrad");
            entity.Property(e => e.Pmra)
                .HasMaxLength(50)
                .HasColumnName("pmra");
            entity.Property(e => e.Pmrarad)
                .HasMaxLength(50)
                .HasColumnName("pmrarad");
            entity.Property(e => e.Proper)
                .HasMaxLength(50)
                .HasColumnName("proper");
            entity.Property(e => e.Ra)
                .HasMaxLength(50)
                .HasColumnName("ra");
            entity.Property(e => e.Rarad)
                .HasMaxLength(50)
                .HasColumnName("rarad");
            entity.Property(e => e.Rv)
                .HasMaxLength(50)
                .HasColumnName("rv");
            entity.Property(e => e.Spect)
                .HasMaxLength(50)
                .HasColumnName("spect");
            entity.Property(e => e.Var)
                .HasMaxLength(50)
                .HasColumnName("var");
            entity.Property(e => e.VarMax)
                .HasMaxLength(50)
                .HasColumnName("var_max");
            entity.Property(e => e.VarMin)
                .HasMaxLength(50)
                .HasColumnName("var_min");
            entity.Property(e => e.Vx)
                .HasMaxLength(50)
                .HasColumnName("vx");
            entity.Property(e => e.Vy)
                .HasMaxLength(50)
                .HasColumnName("vy");
            entity.Property(e => e.Vz)
                .HasMaxLength(50)
                .HasColumnName("vz");
            entity.Property(e => e.X)
                .HasMaxLength(50)
                .HasColumnName("x");
            entity.Property(e => e.Y)
                .HasMaxLength(50)
                .HasColumnName("y");
            entity.Property(e => e.Z)
                .HasMaxLength(50)
                .HasColumnName("z");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<UserStar>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Star).WithMany()
                .HasForeignKey(d => d.StarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserStars_Stars");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserStars_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
