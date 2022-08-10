namespace ProjetoSemana11.Models;

public class Exame
{
    public int Id { get; set; }
    public string CodigoTuss { get; set; }
    public DateTime DataAgendamento { get; set; }

    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }
}