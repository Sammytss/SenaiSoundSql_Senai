using SenaiSoundSql.Banco;
using SenaiSoundSql.Modelos;

namespace SenaiSoundAPI.EndPoints
{
    public static class ArtistasExtensoes
    {
        public static void AddEndPointsArtistas(this WebApplication app)
        {
            app.MapGet("/Artistas", () =>
            {
                var dal = new DAL<Artista>(new SenaiSoundContext());
                var artistas = dal.Listar();
                return Results.Ok(artistas);
            });

            app.MapGet("/Artistas/{nome}", (string nome) =>
            {
                var dal = new DAL<Artista>(new SenaiSoundContext());
                var artistas = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
                if (artistas is null)
                {
                    return Results.NotFound("Artista não encontrado!");
                }
                return Results.Ok(artistas);

            });

            app.MapPost("/Artistas", (Artista artista) =>
            {
                var dal = new DAL<Artista>(new SenaiSoundContext());
                dal.AdicionarObjeto(artista);
                return Results.Created($"/Artistas/{artista.Nome}", artista);
            });
        }

    }
}
