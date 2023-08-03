using Glossario.Aplicacao;
using Glossario.Infraestrutura;
using Projeto.Infra;

var builder = WebApplication.CreateBuilder(args);
GerenciadorMigracao.ConfigurarMigracao();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
NhibernateRegistry.ObterSessionFactory(builder.Services);

builder.Services.AddScoped<ITermoRepositorio, TermoRepositorio>();
builder.Services.AddScoped<ITermoService, TermoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Add CORS middleware
app.UseCors(builder => builder.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader());

app.MapControllers();

app.Run();
