

using Microsoft.EntityFrameworkCore;
class BancodeDados : DbContext
{
    public DbSet<ClienteResidencial> Clientes { get; set; }
    public DbSet<Condominio> Condominios { get; set; }
    public DbSet<Edificio> Edificios { get; set; }
    public DbSet<Empreiteiro> Empreiteiros { get; set; }
    public DbSet<EquipeManutencao> Equipes { get; set; }
    public DbSet<LiderEquipe> Lider { get; set; }
    public DbSet<Obra> Obras { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseMySQL("server=localhost;port=3306;database=projeto;user=root;password=positivo");
    }
}