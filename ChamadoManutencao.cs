public class ChamadoManutencao
{
    public int ID { get; set; }
    public int UnidadeResidencialID { get; set; }
    public string DescricaoProblema { get; set; }
    public DateTime DataAbertura { get; set; }
    public DateTime DataPrimeiroContato { get; set; }
    public StatusManutencao Status { get; set; }
    public string MotivoNaoRealizacao { get; set; }
    public string EmpreiteirosNecessarios { get; set; }
}