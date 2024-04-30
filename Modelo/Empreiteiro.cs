public class Empreiteiro
{
    public int ID { get; set; }
    public string Nome { get; set; }
    public List<EquipeManutencao> EquipesManutencao { get; set; }
    public List<ChamadoManutencao> ManutencoesAtendidas { get; set; }
}