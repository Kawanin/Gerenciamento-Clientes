var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "API de Gerenciamento de Manutenções"); //Requisição Get

app.MapGet("/gerenciamento", () => 
{
    List<Gerenciamento> gerenciamentos = new();
    gerenciamentos.Add(new Gerenciamento("Palladium 41", "Hidráulico", false));
    gerenciamentos.Add(new Gerenciamento("Palladium 21", "Elétrico", false));
    gerenciamentos.Add(new Gerenciamento("BF20 05", "Hidráulico", true));
    gerenciamentos.Add(new Gerenciamento("Acqua 42", "Hidráulico", false));
    return gerenciamentos;

});
app.MapGet("/gerenciamento/cliente", () => "Clientes"); //Requisição Get
app.MapGet("/gerenciamento/{id}", () => "Empreendimento"); //Requisição Get

app.MapPost("/gerenciamento", () => "INCLUIR"); //Requisição Post

app.MapPut("/gerenciamento/{id}", () => "Alteração protocolo"); //Requisição Put

app.MapDelete("/gerenciamento/{id}", () => "Excluir protocolo"); //Requisição Delete


// Método |   SQL  | 
//--------------------------
//C reate | insert | Post
//R ead   | select | Get
//U pdate | update | Put
//D elete | delete | Delete
//Processo em cada tabela do BD

//Além do método, precisa da rota (/)



app.Run();
