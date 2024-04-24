public class ClienteResidencial
{
    public int ID { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public virtual Imovel Imovel { get; set; }  
}