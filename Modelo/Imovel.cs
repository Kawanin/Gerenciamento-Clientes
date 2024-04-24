public class Imovel
{
    public int ID { get; set; }
    public string Tipo { get; set; } // "Condominio" ou "Edificio"
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public virtual ICollection<ClienteResidencial> ClientesResidenciais { get; set; }
}
