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
app.MapGet("/Clientes", async (BancodeDados db) =>
{
    var clientes = await db.Clientes.ToListAsync();
    return Results.Ok(clientes);
});

app.MapGet("/Clientes/{id}", async (int id, BancodeDados db) =>
{
    var cliente = await db.Clientes.FindAsync(id);
    if (cliente == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(cliente);
});

app.MapPost("/Clientes", async (ClienteResidencial cliente, BancodeDados db) =>
{
    var novoImovel = new Imovel
    {
        Tipo = "Edificio",
        Nome = "Arte Palladium",
        Endereco = "R Maria Trevisan Tortato 290, AP 21"
    };

    var novoClienteResidencial = new ClienteResidencial
    {
        Nome = "Jefferson",
        Telefone = "41984542918",
        Imovel = novoImovel
    };
    db.Clientes.Add(novoClienteResidencial);

    await db.SaveChangesAsync();

    return Results.Created($"/Clientes/{novoClienteResidencial.ID}", novoClienteResidencial);
});

app.MapPut("/Clientes/{id}", async (int id, ClienteResidencial clienteAlterado, BancodeDados db) =>
{
    var cliente = await db.Clientes.FindAsync(id);
    if (cliente == null)
    {
        return Results.NotFound();
    }

    cliente.Nome = clienteAlterado.Nome;
    cliente.Telefone = clienteAlterado.Telefone;

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


//Manutenções
app.MapGet("/ChamadosManutencao", async (BancodeDados db) =>
{
    var chamados = await db.ChamadosManutencao.ToListAsync();
    return Results.Ok(chamados);
});

app.MapGet("/ChamadosManutencao/{id}", async (int id, BancodeDados db) =>
{
    var chamado = await db.ChamadosManutencao.FindAsync(id);
    if (chamado == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(chamado);
});

app.MapPost("/ChamadosManutencao", async (ChamadoManutencao chamado, BancodeDados db) =>
{
    var novoChamado = new ChamadoManutencao
    {
        UnidadeResidencialID = 1,
        DescricaoProblema = "Problema na rede elétrica",
        DataAbertura = DateTime.Now,
        DataPrimeiroContato = DateTime.Now,
        MotivoNaoRealizacao = null,
        EquipeManutencaoID = 1 
    };

    db.ChamadosManutencao.Add(novoChamado);
    await db.SaveChangesAsync();

    return Results.Created($"/ChamadosManutencao/{novoChamado.ID}", novoChamado);
});

app.MapPut("/ChamadosManutencao/{id}", async (int id, ChamadoManutencao chamadoAtualizado, BancodeDados db) =>
{
    var chamado = await db.ChamadosManutencao.FindAsync(id);
    if (chamado == null)
    {
        return Results.NotFound();
    }

    chamado.DescricaoProblema = chamadoAtualizado.DescricaoProblema;
    chamado.DataPrimeiroContato = chamadoAtualizado.DataPrimeiroContato;
    chamado.MotivoNaoRealizacao = chamadoAtualizado.MotivoNaoRealizacao;
    chamado.EquipeManutencaoID = chamadoAtualizado.EquipeManutencaoID;
    chamado.UnidadeResidencialID = chamadoAtualizado.UnidadeResidencialID;
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/ChamadosManutencao/{id}", async (int id, BancodeDados db) =>
{
    var chamado = await db.ChamadosManutencao.FindAsync(id);
    if (chamado == null)
    {
        return Results.NotFound();
    }

    db.ChamadosManutencao.Remove(chamado);
    await db.SaveChangesAsync();

    return Results.NoContent();
});


//Imóvel
app.MapGet("/Imoveis", async (BancodeDados db) =>
{
    var imoveis = await db.Condominios.ToListAsync();
    return Results.Ok(imoveis);
});

app.MapGet("/Imoveis/{id}", async (int id, BancodeDados db) =>
{
    var imovel = await db.Condominios.FindAsync(id);
    if (imovel == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(imovel);
});

app.MapPost("/Imoveis", async (Imovel imovel, BancodeDados db) =>
{
   var artePalladiumAP21 = new Imovel
    {
        Tipo = "Edificio",
        Nome = "Arte Palladium",
        Endereco = "R Maria Trevisan Tortato 290, AP 21"
    };

    var artePalladiumAP42 = new Imovel
    {
        Tipo = "Edificio",
        Nome = "Arte Palladium",
        Endereco = "R Maria Trevisan Tortato 290, AP 42"
    };

    db.Condominios.Add(artePalladiumAP21);
    db.Condominios.Add(artePalladiumAP42);
    await db.SaveChangesAsync();

    var imoveis = new List<Imovel> { artePalladiumAP21, artePalladiumAP42 };

    return Results.Ok(imoveis);
});

app.MapPut("/Imoveis/{id}", async (int id, Imovel imovelAlterado, BancodeDados db) =>
{
    var imovel = await db.Condominios.FindAsync(id);
    if (imovel == null)
    {
        return Results.NotFound();
    }

    imovel.Nome = imovelAlterado.Nome;
    imovel.Endereco = imovelAlterado.Endereco;

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
    var arteAcqua = new Obra
    {
        Nome = "Arte Acqua",
        Endereco = "R Bento Viana 380"
    };

    db.Obras.Add(arteAcqua);
    await db.SaveChangesAsync();

    return Results.Created($"/Obras/{arteAcqua.ID}", arteAcqua);
});

app.MapPut("/Obras/{id}", async (int id, Obra obraAlterada, BancodeDados db) =>
{
    var obra = await db.Obras.FindAsync(id);
    if (obra == null)
    {
        return Results.NotFound();
    }

    obra.Nome = obraAlterada.Nome;
    obra.Endereco = obraAlterada.Endereco;

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
    var novoEmpreiteiro = new Empreiteiro
    {
        Nome = "Celso Mendes", 
        EquipesManutencao = new List<EquipeManutencao>(), 
        ManutencoesAtendidas = new List<ChamadoManutencao>() 
    };

    db.Empreiteiros.Add(novoEmpreiteiro);
    await db.SaveChangesAsync();

    return Results.Created($"/Empreiteiros/{novoEmpreiteiro.ID}", novoEmpreiteiro);
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


//Líderes da Equipe
app.MapGet("/LideresEquipe", async (BancodeDados db) =>
{
    var lideresEquipe = await db.LiderEquipe.ToListAsync();
    return Results.Ok(lideresEquipe);
});

app.MapPost("/LideresEquipe", async (LiderEquipe lider, BancodeDados db) =>
{
    var novoLider = new LiderEquipe
    {
        Nome = "Leonardo",
        EquipeID = 2,
        EquipesManutencao = new List<EquipeManutencao>()
    };

    db.LiderEquipe.Add(novoLider);
    await db.SaveChangesAsync();

    return Results.Created($"/LideresEquipe/{novoLider.ID}", novoLider);
});

app.MapPut("/LideresEquipe/{id}", async (int id, LiderEquipe liderAlterado, BancodeDados db) =>
{
    var lider = await db.LiderEquipe.FindAsync(id);
    if (lider == null)
    {
        return Results.NotFound();
    }

    lider.Nome = liderAlterado.Nome;
    lider.EquipeID = liderAlterado.EquipeID;
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


//Equipes de Manutenção
app.MapGet("/EquipesManutencao", async (BancodeDados db) =>
{
    var equipesManutencao = await db.EquipeManutencao.ToListAsync();
    return Results.Ok(equipesManutencao);
});

app.MapPost("/EquipesManutencao", async (EquipeManutencao equipe, BancodeDados db) =>
{
    var novaEquipe = new EquipeManutencao
    {
        Nome = equipe.Nome,
        Lider = new LiderEquipe
        {
            Nome = "Leonardo",
            EquipeID = 2
        },
        Empreiteiro = new Empreiteiro 
        {
            Nome = "Celso Mendes" 
        }
    };

    db.EquipeManutencao.Add(novaEquipe);
    await db.SaveChangesAsync();

    return Results.Created($"/EquipesManutencao/{novaEquipe.ID}", novaEquipe);
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

app.Run();