namespace ProjetoSemana11.DTOs;

public class ClienteDTO
{
    public string Nome { get; set; }
    public DateTime? DataNascimento { get; set; }
    public CarteiraTrabalhoDTO CarteiraTrabalho { get; set; }
}