using System.ComponentModel.DataAnnotations;

namespace ApiMusicasEF.DTOs;

public class CriacaoMusicaDTO
{
    [Required(ErrorMessage = "O nome � obrigat�rio.")]
    public string Nome { get; set; }
    public TimeSpan Duracao { get; set; }
    public int? AlbumId { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "O artista � obrigat�rio.")]
    public int ArtistaId { get; set; }
}