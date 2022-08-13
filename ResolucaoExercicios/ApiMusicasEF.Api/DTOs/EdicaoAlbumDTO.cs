using System.ComponentModel.DataAnnotations;

namespace ApiMusicasEF.DTOs;

public class EdicaoAlbumDTO
{
    [Required(ErrorMessage = "O nome � obrigat�rio.")]
    public string Nome { get; set; }
    [Range(1700, 3000, ErrorMessage = "O ano de lan�amento � obrigat�rio.")]
    public int AnoLancamento { get; set; }
    public string CapaUrl { get; set; }
}