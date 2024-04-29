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
        builder.UseMySQL("server=localhost;port=3306;database=projeto;user=root;password="positivo");
    }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
{

    //1 Cliente para 1 imóvel
    modelBuilder.Entity<ClienteResidencial>()
    .HasOne(c => c.Imovel)
    .WithMany(i => i.ClientesResidenciais)
    .HasForeignKey(c => c.ImovelID);

    //1 imóvel para vários clientes
    modelBuilder.Entity<Imovel>()
        .HasMany(i => i.ClientesResidenciais)
        .WithOne(c => c.Imovel)
        .HasForeignKey(c => c.ImovelID);

    //1 Empreiteiro para várias equipes de manutenção
    modelBuilder.Entity<EquipeManutencao>()
        .HasOne(eq => eq.Empreiteiro)
        .WithMany(e => e.EquipesManutencao)
        .HasForeignKey(eq => eq.EmpreiteiroID);

    //1 Equipe de manutenção para várias manutenções
    modelBuilder.Entity<EquipeManutencao>()
        .HasMany(eq => eq.ManutencoesAtendidas)
        .WithOne(m => m.EquipeManutencao)
        .HasForeignKey(m => m.EquipeManutencaoID);
        

    //1 lider de equipe para várias equipes de manutenção
    modelBuilder.Entity<LiderEquipe>()
        .HasMany(le => le.EquipesManutencao)
        .WithOne(eq => eq.Lider)
        .HasForeignKey(eq => eq.LiderEquipeID);

} 
}