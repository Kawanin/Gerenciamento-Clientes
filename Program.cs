using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Config do BD
builder.Services.AddDbContext<BancodeDados>(options => options.UseInMemoryDatabase("gerenciamentos"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


var app = builder.Build();


app.MapGet("/", () => "API de Gerenciamento de Manutenções"); //Requisição Get

app.MapGet("/gerenciamento", async (BancodeDados db) =>
{
    //select * from Gerenciamentos
    return await db.Gerenciamentos.ToListAsync();
});

app.MapGet("/gerenciamento/cliente", () => "Clientes");
app.MapGet("/gerenciamento/{id}", () => "Empreendimento");

app.MapPost("/gerenciamento", async (Gerenciamento gerenciamento, BancodeDados db) =>
{
    db.Gerenciamentos.Add(gerenciamento);
    //insert into gerenciamento
    await db.SaveChangesAsync();

    return Results.Created($"/gerenciamento/{gerenciamento.Id}", gerenciamento);
});


app.MapPut("/gerenciamento/{id}", async (int id, Gerenciamento gerenciamentoAtualizado, BancodeDados db) =>
{
    //select * from Gerenciamentos where id = ?
    var gerenciamento = await db.Gerenciamentos.FindAsync(id);
    if (gerenciamento == null) return Results.NotFound();

    gerenciamento.Manutencao = gerenciamentoAtualizado.Manutencao;
    gerenciamento.Concluida = gerenciamentoAtualizado.Concluida;

    //update manutenções
    await db.SaveChangesAsync();

    return Results.NoContent();
});


app.MapDelete("/gerenciamento/{id}", async (int id, BancodeDados db) =>
{
    if (await db.Gerenciamentos.FindAsync(id) is Gerenciamento gerenciamento)
    {
        db.Gerenciamentos.Remove(gerenciamento);
        //delete from Gerenciamento
        await db.SaveChangesAsync();
        return Results.NoContent();
    }
    return Results.NotFound();
});


// Método |   SQL  | 
//--------------------------
//C reate | insert | Post   | Incluir
//R ead   | select | Get    | Usar
//U pdate | update | Put    | Atualizar
//D elete | delete | Delete | Excluir
//Processo em cada tabela do BD

//Além do método, precisa da rota (/)


app.Run();
