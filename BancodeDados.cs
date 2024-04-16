

using Microsoft.EntityFrameworkCore;
class BancodeDados : DbContext
{
    public BancodeDados(DbContextOptions<BancodeDados> options) : base(options)
    {
    }

    //Classe que gera tabela no BD
    public DbSet<Gerenciamento> Gerenciamentos => Set<Gerenciamento>();
    //public DbSet<Livro> Livros => Set<Livro>();
    //public DbSet<Pessoa> Pessoas => Set<Pessoa>();

    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseMySql("server=localhost;port=3306;database=projeto;user=root;password="positivo");
}