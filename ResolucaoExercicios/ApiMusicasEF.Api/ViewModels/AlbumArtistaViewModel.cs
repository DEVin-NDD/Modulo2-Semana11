using ApiMusicasEF.Api.Models;
using ApiMusicasEF.Api.ViewModels;

namespace ApiMusicasEF.ViewModels;

public class AlbumArtistaViewModel
{

    public AlbumArtistaViewModel(Album album)
    {
        Id = album.Id;
        Nome = album.Nome;
        AnoLancamento = album.AnoLancamento;
        CapaUrl = album.CapaUrl;
        Artista = new ArtistaViewModel(album.Artista);
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public int AnoLancamento { get; set; }
    public string CapaUrl { get; set; }
    public ArtistaViewModel Artista { get; set; }
}