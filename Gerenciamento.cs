public class Gerenciamento
{
    public int Id { get; set; }
    public ClienteResidencial Cliente { get; set; }
    public Imovel Imovel { get; set; }
    public ChamadoManutencao ChamadoManutencao { get; set; }
    public Empreiteiro Empreiteiro { get; set; }
    public EquipeManutencao EquipeManutencao { get; set; }
    public bool Concluida { get; set; }
}
