// <auto-generated />
using System;
using ApiMusicasEF.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiMusicasEF.Api.Data.Migrations
{
    [DbContext(typeof(MusicasDbContext))]
    partial class MusicasDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApiMusicasEF.Api.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AnoLancamento")
                        .HasColumnType("int");

                    b.Property<int>("ArtistaId")
                        .HasColumnType("int");

                    b.Property<string>("CapaUrl")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id");

                    b.HasIndex("ArtistaId");

                    b.ToTable("Albuns", (string)null);
                });

            modelBuilder.Entity("ApiMusicasEF.Api.Models.Artista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FotoUrl")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("NomeArtistico")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id");

                    b.ToTable("Artistas", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Micheal Jackson",
                            NomeArtistico = "Micheal Jackson"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Elvis Presley",
                            NomeArtistico = "Elvis Presley"
                        });
                });

            modelBuilder.Entity("ApiMusicasEF.Api.Models.Musica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int>("ArtistaId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Duracao")
                        .HasColumnType("time");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("ArtistaId");

                    b.ToTable("Musicas", (string)null);
                });

            modelBuilder.Entity("ApiMusicasEF.Api.Models.Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Playlists", (string)null);
                });

            modelBuilder.Entity("ApiMusicasEF.Api.Models.PlaylistMusica", b =>
                {
                    b.Property<int>("PlaylistId")
                        .HasColumnType("int");

                    b.Property<int>("MusicaId")
                        .HasColumnType("int");

                    b.HasKey("PlaylistId", "MusicaId");

                    b.HasIndex("MusicaId");

                    b.ToTable("PlaylistMusicas", (string)null);
                });

            modelBuilder.Entity("ApiMusicasEF.Api.Models.Album", b =>
                {
                    b.HasOne("ApiMusicasEF.Api.Models.Artista", "Artista")
                        .WithMany("Albuns")
                        .HasForeignKey("ArtistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artista");
                });

            modelBuilder.Entity("ApiMusicasEF.Api.Models.Musica", b =>
                {
                    b.HasOne("ApiMusicasEF.Api.Models.Album", "Album")
                        .WithMany("Musicas")
                        .HasForeignKey("AlbumId");

                    b.HasOne("ApiMusicasEF.Api.Models.Artista", "Artista")
                        .WithMany("Musicas")
                        .HasForeignKey("ArtistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("Artista");
                });

            modelBuilder.Entity("ApiMusicasEF.Api.Models.PlaylistMusica", b =>
                {
                    b.HasOne("ApiMusicasEF.Api.Models.Musica", "Musica")
                        .WithMany()
                        .HasForeignKey("MusicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiMusicasEF.Api.Models.Playlist", "Playlist")
                        .WithMany("Musicas")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Musica");

                    b.Navigation("Playlist");
                });

            modelBuilder.Entity("ApiMusicasEF.Api.Models.Album", b =>
                {
                    b.Navigation("Musicas");
                });

            modelBuilder.Entity("ApiMusicasEF.Api.Models.Artista", b =>
                {
                    b.Navigation("Albuns");

                    b.Navigation("Musicas");
                });

            modelBuilder.Entity("ApiMusicasEF.Api.Models.Playlist", b =>
                {
                    b.Navigation("Musicas");
                });
#pragma warning restore 612, 618
        }
    }
}
