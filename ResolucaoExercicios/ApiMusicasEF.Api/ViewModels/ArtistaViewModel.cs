using ApiMusicasEF.Api.Models;

namespace ApiMusicasEF.Api.ViewModels
{
    public class ArtistaViewModel
    {
        public ArtistaViewModel(Artista artista)
        {
            Id = artista.Id;
            Nome = artista.Nome;
            NomeArtistico = artista.NomeArtistico;
            FotoUrl = artista.FotoUrl;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeArtistico { get; set; }
        public string FotoUrl { get; set; }
    }
}
