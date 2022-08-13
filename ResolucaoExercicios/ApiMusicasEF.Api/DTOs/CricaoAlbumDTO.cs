using System.ComponentModel.DataAnnotations;

namespace ApiMusicasEF.DTOs;

public class CricaoAlbumDTO
{
    [Required(ErrorMessage = "O nome � obrigat�rio.")]
    public string Nome { get; set; }
    [Range(1700, 3000, ErrorMessage = "O ano de lan�amento � obrigat�rio.")]
    public int AnoLancamento { get; set; }
    public string CapaUrl { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "O artista � obrigat�rio.")]
    public int ArtistaId { get; set; }
    public List<MusicaAlbumDTO> Musicas { get; set; }
}