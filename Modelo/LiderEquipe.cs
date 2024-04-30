public class LiderEquipe
{
    public int ID { get; set; }
    public string Nome {get; set;}
    public int EquipeID { get; set; }
    public ICollection<EquipeManutencao> EquipesManutencao { get; set; }
}