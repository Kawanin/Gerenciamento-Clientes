public class Empreiteiro
{
    public int ID { get; set; }
    public string Nome { get; set; }
    public ICollection<EquipeManutencao> EquipesManutencao { get; set; }
    public virtual ICollection<ChamadoManutencao> ManutencoesAtendidas { get; set; }
}