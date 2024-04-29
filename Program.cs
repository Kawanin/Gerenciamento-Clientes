using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Config do BD
builder.Services.AddDbContext<BancodeDados>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

//Padrão
app.MapGet("/", () => "Gerenciamento Manutenções");


//Clientes
app.MapPost("/Clientes", async (ClienteResidencial cliente, BancodeDados db) =>
{
    
    db.Clientes.Add(cliente);
    
    await db.SaveChangesAsync();

    return Results.Created($"/Clientes/{cliente}", cliente);
});

app.MapPut("/Clientes/{id}", async (int id, ClienteResidencial clienteAlterado, BancodeDados db) =>
{
    var cliente = await db.Clientes.FindAsync(id);
    if (cliente == null)
    {
        return Results.NotFound();
    }

    cliente.Nome = clienteAlterado.Nome;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/Clientes/{id}", async (int id, BancodeDados db) =>
{
    var cliente = await db.Clientes.FindAsync(id);
    if (cliente == null)
    {
        return Results.NotFound();
    }

    db.Clientes.Remove(cliente);
    
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapGet("/Clientes", async (BancodeDados db) =>
{
    var clientes = await db.Clientes.ToListAsync();
    return Results.Ok(clientes);
});


//Manutenções
app.MapPost("/ChamadosManutencao", async (Manutencoes chamado, BancodeDados db) =>
{
    
    db.Manutencoes.Add(chamado);
    
    await db.SaveChangesAsync();

    
    return Results.Created($"/ChamadosManutencao/{chamado.ID}", chamado);
});

app.MapPut("/ChamadosManutencao/{id}", async (int id, Manutencoes chamadoAlterado, BancodeDados db) =>
{
    var chamado = await db.Manutencoes.FindAsync(id);
    if (chamado == null)
    {
        return Results.NotFound();
    }

    chamado.Status = chamadoAlterado.Status;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/ChamadosManutencao/{id}", async (int id, BancodeDados db) =>
{
    var chamado = await db.Manutencoes.FindAsync(id);
    if (chamado == null)
    {
        return Results.NotFound();
    }

    db.Manutencoes.Remove(chamado);
    
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapGet("/ChamadosManutencao", async (BancodeDados db) =>
{
    var chamados = await db.Manutencoes.ToListAsync();
    return Results.Ok(chamados);
});


//Imóvel
app.MapGet("/Imoveis", async (BancodeDados db) =>
{
    var imoveis = await db.Condominios.ToListAsync();
    return Results.Ok(imoveis);
});

app.MapPost("/Imoveis", async (Imovel imovel, BancodeDados db) =>
{
    db.Condominios.Add(imovel);
    await db.SaveChangesAsync();
    return Results.Created($"/Imoveis/{imovel.ID}", imovel);
});

app.MapPut("/Imoveis/{id}", async (int id, Imovel imovelAlterado, BancodeDados db) =>
{
    var imovel = await db.Condominios.FindAsync(id);
    if (imovel == null)
    {
        return Results.NotFound();
    }

    imovel.Nome = imovelAlterado.Nome;
    
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/Imoveis/{id}", async (int id, BancodeDados db) =>
{
    var imovel = await db.Condominios.FindAsync(id);
    if (imovel == null)
    {
        return Results.NotFound();
    }

    db.Condominios.Remove(imovel);
    await db.SaveChangesAsync();

    return Results.NoContent();
});


//Obras
app.MapGet("/Obras", async (BancodeDados db) =>
{
    var obras = await db.Obras.ToListAsync();
    return Results.Ok(obras);
});

app.MapPost("/Obras", async (Obra obra, BancodeDados db) =>
{
    db.Obras.Add(obra);
    await db.SaveChangesAsync();
    return Results.Created($"/Obras/{obra.ID}", obra);
});

app.MapPut("/Obras/{id}", async (int id, Obra obraAlterada, BancodeDados db) =>
{
    var obra = await db.Obras.FindAsync(id);
    if (obra == null)
    {
        return Results.NotFound();
    }

    obra.Nome = obraAlterada.Nome;
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/Obras/{id}", async (int id, BancodeDados db) =>
{
    var obra = await db.Obras.FindAsync(id);
    if (obra == null)
    {
        return Results.NotFound();
    }

    db.Obras.Remove(obra);
    await db.SaveChangesAsync();

    return Results.NoContent();
});


//Empreiteiros
app.MapGet("/Empreiteiros", async (BancodeDados db) =>
{
    var empreiteiros = await db.Empreiteiros.ToListAsync();
    return Results.Ok(empreiteiros);
});

app.MapPost("/Empreiteiros", async (Empreiteiro empreiteiro, BancodeDados db) =>
{
    db.Empreiteiros.Add(empreiteiro);
    await db.SaveChangesAsync();
    return Results.Created($"/Empreiteiros/{empreiteiro.ID}", empreiteiro);
});

app.MapPut("/Empreiteiros/{id}", async (int id, Empreiteiro empreiteiroAlterado, BancodeDados db) =>
{
    var empreiteiro = await db.Empreiteiros.FindAsync(id);
    if (empreiteiro == null)
    {
        return Results.NotFound();
    }

    empreiteiro.Nome = empreiteiroAlterado.Nome;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/Empreiteiros/{id}", async (int id, BancodeDados db) =>
{
    var empreiteiro = await db.Empreiteiros.FindAsync(id);
    if (empreiteiro == null)
    {
        return Results.NotFound();
    }

    db.Empreiteiros.Remove(empreiteiro);
    await db.SaveChangesAsync();

    return Results.NoContent();
});



//Equipes de Manutenção
app.MapGet("/EquipesManutencao", async (BancodeDados db) =>
{
    var equipes = await db.EquipeManutencao.ToListAsync();
    return Results.Ok(equipes);
});

app.MapPost("/EquipesManutencao", async (EquipeManutencao equipe, BancodeDados db) =>
{
    db.EquipeManutencao.Add(equipe);
    await db.SaveChangesAsync();
    return Results.Created($"/EquipesManutencao/{equipe.ID}", equipe);
});

app.MapPut("/EquipesManutencao/{id}", async (int id, EquipeManutencao equipeAlterada, BancodeDados db) =>
{
    var equipe = await db.EquipeManutencao.FindAsync(id);
    if (equipe == null)
    {
        return Results.NotFound();
    }

    equipe.Nome = equipeAlterada.Nome;
    
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/EquipesManutencao/{id}", async (int id, BancodeDados db) =>
{
    var equipe = await db.EquipeManutencao.FindAsync(id);
    if (equipe == null)
    {
        return Results.NotFound();
    }

    db.EquipeManutencao.Remove(equipe);
    await db.SaveChangesAsync();

    return Results.NoContent();
});


//Líderes da Equipe
app.MapGet("/LideresEquipe", async (BancodeDados db) =>
{
    var lideres = await db.LiderEquipe.ToListAsync();
    return Results.Ok(lideres);
});

app.MapPost("/LideresEquipe", async (LiderEquipe lider, BancodeDados db) =>
{
    db.LiderEquipe.Add(lider);
    await db.SaveChangesAsync();
    return Results.Created($"/LideresEquipe/{lider.ID}", lider);
});

app.MapPut("/LideresEquipe/{id}", async (int id, LiderEquipe liderAlterado, BancodeDados db) =>
{
    var lider = await db.LiderEquipe.FindAsync(id);
    if (lider == null)
    {
        return Results.NotFound();
    }

    lider.Nome = liderAlterado.Nome;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/LideresEquipe/{id}", async (int id, BancodeDados db) =>
{
    var lider = await db.LiderEquipe.FindAsync(id);
    if (lider == null)
    {
        return Results.NotFound();
    }

    db.LiderEquipe.Remove(lider);
    await db.SaveChangesAsync();

    return Results.NoContent();
});



app.Run();