using Microsoft.EntityFrameworkCore;
class BancodeDados : DbContext
{
    public DbSet<ClienteResidencial> Clientes { get; set; }
    public DbSet<Imovel> Condominios { get; set; }
    public DbSet<Empreiteiro> Empreiteiros { get; set; }
    public DbSet<EquipeManutencao> EquipeManutencao { get; set; }
    public DbSet<LiderEquipe> LiderEquipe { get; set; }
    public DbSet<Obra> Obras { get; set; }
    public DbSet<Manutencoes> Manutencoes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseMySQL("server=localhost;port=3306;database=projeto;user=root;password=");
    }
}