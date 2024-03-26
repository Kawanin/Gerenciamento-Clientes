var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "API de Tarefas");

app.Run();
