namespace ApiMusicasEF.Api.Models
{
    public class PlaylistMusica
    {
        public int PlaylistId { get; set; }
        public int MusicaId { get; set; }
        public virtual Musica Musica { get; set; }
        public virtual Playlist Playlist { get; set; }
    }
}
