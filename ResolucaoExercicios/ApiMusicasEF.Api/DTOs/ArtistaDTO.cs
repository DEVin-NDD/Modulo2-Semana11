using System.ComponentModel.DataAnnotations;

namespace ApiMusicasEF.DTOs;

public class ArtistaDTO
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Nome { get; set; }
    public string NomeArtistico { get; set; }
    public string FotoUrl { get; set; }
}