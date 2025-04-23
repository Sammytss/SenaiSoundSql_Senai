using SenaiSoundSql.Banco;
using SenaiSoundSql.Modelos;

namespace SenaiSoundAPI.EndPoints
{
    public static class MusicasExtensoes
    {
        public static void AddEndPointsMusicas(this WebApplication app)
        {
            app.MapGet("/Musicas", () =>
            {
                var dal = new DAL<Musica>(new SenaiSoundContext());
                var musicas = dal.Listar();
                return Results.Ok(musicas);
            });
            app.MapGet("/Musicas/{nome}", (string nome) =>
            {
                var dal = new DAL<Musica>(new SenaiSoundContext());
                var musicas = dal.RecuperarPor(m => m.Nome.ToUpper().Equals(nome.ToUpper()));
                if (musicas is null)
                {
                    return Results.NotFound("Música não encontrada!");
                }
                return Results.Ok(musicas);
            });
            app.MapPost("/Musicas", (Musica musica) =>
            {
                var dal = new DAL<Musica>(new SenaiSoundContext());
                dal.AdicionarObjeto(musica);
                return Results.Created($"/Musicas/{musica.Nome}", musica);
            });
        }
    }
}
