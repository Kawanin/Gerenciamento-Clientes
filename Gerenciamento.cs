public class Gerenciamento
{

    public int Id { get; set; }
    public string? Empreendimento { get; set; }
    public string? Manutencao { get; set; }
    public bool Concluida { get; set; }

    public Gerenciamento(string Empreendimento, string Manutencao, bool Concluida)
    {

        this.Empreendimento = Empreendimento;
        this.Concluida = Concluida;
    }
}