using SenaiSoundAPI.EndPoints;
using SenaiSoundSql.Banco;
using SenaiSoundSql.Modelos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SenaiSoundContext>();
builder.Services.AddTransient<DAL<Artista>>();
builder.Services.AddTransient<DAL<Musica>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.AddEndPointsArtistas();
app.AddEndPointsMusicas();

app.UseSwagger();
app.UseSwaggerUI();



app.Run();
