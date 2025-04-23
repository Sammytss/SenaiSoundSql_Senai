using SenaiSoundAPI.EndPoints;
using SenaiSoundSql.Banco;
using SenaiSoundSql.Modelos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SenaiSoundContext>();
builder.Services.AddTransient<DAL<Artista>>();
builder.Services.AddTransient<DAL<Musica>>();

var app = builder.Build();


app.AddEndPointsArtistas();
app.AddEndPointsMusicas();


app.Run();
