public class Gerenciamento
{
    public int Id { get; set; }
    public string? Nome { get; set;}
    public string? Empreendimento { get; set; }
    public string? Unidade { get; set; }
    public string? Manutencao { get; set; }
    public bool Concluida { get; set; }

    public Gerenciamento(int Id, string Nome, string Empreendimento, string Unidade, string Manutencao, bool Concluida)
    {
        this.Id = Id;
        this.Nome = Nome;
        this.Empreendimento = Empreendimento;
        this.Manutencao = Manutencao;
        this.Unidade = Unidade;
        this.Concluida = Concluida;
    }
}