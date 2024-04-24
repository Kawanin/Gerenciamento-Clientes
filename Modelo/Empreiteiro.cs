public class Empreiteiro
{
    public int ID { get; set; }
    public string Nome { get; set; }
    public virtual ICollection<ChamadoManutencao> ManutencoesAtendidas { get; set; }
}