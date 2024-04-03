

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
}