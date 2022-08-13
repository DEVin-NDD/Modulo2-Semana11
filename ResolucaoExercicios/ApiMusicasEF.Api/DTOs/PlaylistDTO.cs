using System.ComponentModel.DataAnnotations;

namespace ApiMusicasEF.DTOs;

public class PlaylistDTO
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Nome { get; set; }
}