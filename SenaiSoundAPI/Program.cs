using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using SenaiSoundAPI.EndPoints;
using SenaiSound.Banco;
using SenaiSound.Modelos;

var builder = WebApplication.CreateBuilder(args);

// Configuração do contexto para MySQL
builder.Services.AddDbContext<SenaiSoundContext>((options) =>
{
    options
        .UseMySql(
            builder.Configuration["ConnectionStrings:SenaiSoundDb"],
            new MySqlServerVersion(new Version(8, 0, 31))
        );
});

// Configuração para evitar ciclos de referência no JSON
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Configuração do CORS
builder.Services.AddCors();

// Registro dos serviços
builder.Services.AddTransient<DAL<Artista>>();
builder.Services.AddTransient<DAL<Musica>>();
builder.Services.AddTransient<DAL<Genero>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração do CORS para permitir qualquer origem, método e cabeçalho
app.UseCors(options =>
{
    options.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

// Registro dos endpoints
app.AddEndPointsArtistas();
app.AddEndPointsMusicas();
app.AddEndPointsGeneros();

app.UseSwagger();
app.UseSwaggerUI();
app.Run();