using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace kolokwium.Models
{
    public partial class s20373Context : DbContext
    {
        public s20373Context()
        {
        }

        public s20373Context(DbContextOptions<s20373Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<MusicLabel> MusicLabels { get; set; }
        public virtual DbSet<Musician> Musicians { get; set; }
        public virtual DbSet<MusicianTrack> MusicianTracks { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasKey(e => e.IdAlbum)
                    .HasName("Album_pk");

                entity.ToTable("Album");

                entity.Property(e => e.IdAlbum).ValueGeneratedNever();

                entity.Property(e => e.AlbumName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.PublishDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdMusicLabelNavigation)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.IdMusicLabel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Album_MusicLabel");
            });

            modelBuilder.Entity<MusicLabel>(entity =>
            {
                entity.HasKey(e => e.IdMusicLabel)
                    .HasName("MusicLabel_pk");

                entity.ToTable("MusicLabel");

                entity.Property(e => e.IdMusicLabel).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Musician>(entity =>
            {
                entity.HasKey(e => e.IdMusician)
                    .HasName("IdMusician");

                entity.ToTable("Musician");

                entity.Property(e => e.IdMusician).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nickname).HasMaxLength(20);
            });

            modelBuilder.Entity<MusicianTrack>(entity =>
            {
                entity.HasKey(e => new { e.MusicianIdMusician, e.TrackIdTrack })
                    .HasName("Musician_Track_pk");

                entity.ToTable("Musician_Track");

                entity.Property(e => e.MusicianIdMusician).HasColumnName("Musician_IdMusician");

                entity.Property(e => e.TrackIdTrack).HasColumnName("Track_IdTrack");

                entity.HasOne(d => d.MusicianIdMusicianNavigation)
                    .WithMany(p => p.MusicianTracks)
                    .HasForeignKey(d => d.MusicianIdMusician)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Musician_Track_Musician");

                entity.HasOne(d => d.TrackIdTrackNavigation)
                    .WithMany(p => p.MusicianTracks)
                    .HasForeignKey(d => d.TrackIdTrack)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Musician_Track_Track");
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.HasKey(e => e.IdTrack)
                    .HasName("Track_pk");

                entity.ToTable("Track");

                entity.Property(e => e.IdTrack).ValueGeneratedNever();

                entity.Property(e => e.TrackName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.IdMusicAlbumNavigation)
                    .WithMany(p => p.Tracks)
                    .HasForeignKey(d => d.IdMusicAlbum)
                    .HasConstraintName("Track_Album");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
