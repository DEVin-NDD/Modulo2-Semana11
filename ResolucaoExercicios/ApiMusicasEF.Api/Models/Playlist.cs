namespace ApiMusicasEF.Api.Models;

public class Playlist
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public virtual List<PlaylistMusica> Musicas { get; set; }
}