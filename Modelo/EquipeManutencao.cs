public class EquipeManutencao
{
    public int ID { get; set; }
    public string Nome { get; set; }
    public virtual ICollection<ChamadoManutencao> ManutencoesAtendidas { get; set; }
    public int LiderEquipeID { get; set; }
    public int EmpreiteiroID { get; set; }
    public virtual LiderEquipe Lider { get; set; }
    public virtual Empreiteiro Empreiteiro { get; set; }
}