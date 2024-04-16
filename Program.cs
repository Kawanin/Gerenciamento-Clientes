using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Configuração do banco de dados
builder.Services.AddDbContext<BancodeDados>();


//Config do BD
builder.Services.AddDbContext<BancodeDados>(options => options.UseInMemoryDatabase("gerenciamentos"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();



app.MapGet("/", () => "Gerenciamento Manutenções");

app.MapGet("/Edificios", async (BancodeDados db) => await db.Edificio.ToListAsync());

app.MapPut("/Cliente", async (int id, ClienteResidencial clienteAlterado, BancodeDados db) =>
{
    //select * from pessoa where id = ?
    var cliente = await db.Clientes.FindAsync(id);
    if (cliente is null)
    {
        return Results.NotFound();
    }

    cliente.Nome = clienteAlterado.Nome;

    //update ...
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/Cliente/{id}", async (int id, BancodeDados db) =>
{
    if (await db.ClienteResidencial.FindAsync(id) is Clientes cliente)
    {
        db.Clientes.Remove(cliente);
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
