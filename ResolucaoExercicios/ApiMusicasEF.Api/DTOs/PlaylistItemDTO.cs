using System.ComponentModel.DataAnnotations;

namespace ApiMusicasEF.DTOs;

public class PlaylistItemDTO
{
    [Range(1, int.MaxValue, ErrorMessage = "O campo musicaId é obrigatório.")]
    public int MusicaId { get; set; }
}