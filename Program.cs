using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Configuração do banco de dados
builder.Services.AddDbContext<BancodeDados>();


//Config do BD
builder.Services.AddDbContext<BancodeDados>(options => options.UseInMemoryDatabase("gerenciamentos"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


var app = builder.Build();



app.MapGet("/", () => "Gerenciamento Manutenções");

app.MapGet("/empreendimentos", async (BancodeDados db) => await db.Edificio.ToListAsync());

app.MapPost("/Ediicio", async () =>
{
Edificio edificio, BancodeDados db;
{
    DbContext.Pessoas.Add(pessoa);
    //Insert into ...
    await db.SaveChangesAsync();

    return Results.Created($"/pessoas/{pessoa.Id}", pessoa);
});

app.MapPut("/Cliente", async (int id, ClienteResidencial clienteAlterado, BancodeDados db) =>
{
    //select * from pessoa where id = ?
    var pessoa = await db.Pessoas.FindAsync(id);
    if (pessoa is null)
    {
        return Results.NotFound();
    }

    pessoa.Nome = clienteAlterado.Nome;

    //update ...
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/Cliente/{id}", async (int id, BancodeDados db) =>
{
    if (await db.ClienteResidencial.FindAsync(id) is Cliente cliente)
    {
        db.Clientes.Remove(pessoa);
        //delete from ...
        await db.SaveChangesAsync();
        return Results.NoContent();
    }
    return Results.NotFound();

});


//Select * from pessoas


// Método |   SQL  | 
//--------------------------
//C reate | insert | Post   | Incluir
//R ead   | select | Get    | Usar
//U pdate | update | Put    | Atualizar
//D elete | delete | Delete | Excluir
//Processo em cada tabela do BD

//Além do método, precisa da rota (/)


app.Run();
