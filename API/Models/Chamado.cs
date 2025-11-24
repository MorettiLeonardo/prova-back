namespace API.Models;

public class Chamado
{
    public string ChamadoId { get; set; } = Guid.NewGuid().ToString();
    public string? Descricao { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.Now;
    public string? Status { get; set; } = "Aberto";
}
