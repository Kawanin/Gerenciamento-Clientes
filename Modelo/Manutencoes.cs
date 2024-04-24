public class Manutencoes
{
    public int Id { get; set; }
    public string chamado { get; set; }
    public DateTime DataAbertura { get; set; }
    public DateTime? DataConclusao { get; set; }
    public string Status { get; set; } // Aqui você pode usar um enum para representar os status
    public int ClienteId { get; set; } // Referência ao cliente que abriu o chamado
}
