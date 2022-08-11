namespace ProjetoSemana11.ViewModels;

public class ClienteViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime? DataNascimento { get; set; }
    public CarteiraTrabalhoViewModel CarteiraTrabalho { get; set; }
}