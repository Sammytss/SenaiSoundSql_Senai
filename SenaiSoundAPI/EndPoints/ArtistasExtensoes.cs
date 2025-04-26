using Microsoft.AspNetCore.Mvc;
using SenaiSoundAPI.Requests;
using SenaiSound.Banco;
using SenaiSound.Modelos;
using SenaiSoundAPI.Response;

namespace SenaiSoundAPI.EndPoints
{
    public static class ArtistasExtencoes
    {

        public static void AddEndPointsArtistas(this WebApplication app)
        {


            app.MapGet("/Artistas", ([FromServices] DAL<Artista> dal) =>
            {
                var artistas = dal.Listar();
                if (artistas is null)
                {
                    return Results.NotFound();
                }
                var listaDeArtistaResponse = EntityListToResponseList(artistas);
                return Results.Ok(listaDeArtistaResponse);
            });
            app.MapGet("/Artistas/{nome}", ([FromServices] DAL<Artista> dal, string nome) =>
            {
                var artista = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
                if (artista is null)
                {
                    return Results.NotFound("Artista não encontrado!");
                }
                return Results.Ok(EntityToResponse(artista));
            });

            // Post de artista Request
            //•	O atributo [FromServices] indica que o parâmetro dal
            //será injetado pelo Dependency Injection (DI) do ASP.NET Core.

            //•	O atributo [FromBody] indica que o parâmetro
            //artistaRequest será preenchido com os dados enviados no corpo da requisição HTTP.
            app.MapPost("/Artistas", ([FromServices] DAL<Artista> dal, [FromBody] ArtistaRequest artistaRequest) =>
            {
                var artista = new Artista(artistaRequest.nome, artistaRequest.bio);
                if(dal.RecuperarPor(a => a.Nome.Equals(artistaRequest.nome)) is null)
                {
                    dal.AdicionarObjeto(artista);
                    return Results.Created($"/Artistas/{artista.Id}", artista);
                }
                return Results.Conflict($"{artista.Nome} já existe. ");

            });

            app.MapDelete("/Artistas/{Id}", ([FromServices] DAL<Artista> dal, int id) =>
            {
                var artista = dal.RecuperarPor(a => a.Id.Equals(id));
                if (artista is null)
                {
                    return Results.NotFound("Artista não encontrado!");
                }
                dal.RemoverObjeto(artista);
                return Results.NoContent();
            });

            app.MapPut("/Artistas", ([FromServices] DAL<Artista> dal, [FromBody] ArtistaRequestEdit artistaRequestEdit) =>
            {
                var artistaAAtualizar = dal.RecuperarPor(a => a.Id.Equals(artistaRequestEdit.Id));
                if (artistaAAtualizar is null)
                {
                    return Results.NotFound("Artista não encontrado!");
                }
                artistaAAtualizar.Nome = artistaRequestEdit.nome;
                artistaAAtualizar.Bio = artistaRequestEdit.bio;
                dal.AtualizarObjeto(artistaAAtualizar);
                return Results.Ok();

            });
        }
        private static ICollection<ArtistaResponse> EntityListToResponseList(IEnumerable<Artista> artistas)
        {
            return artistas.Select(a => EntityToResponse(a)).ToList();
        }

        private static ArtistaResponse EntityToResponse(Artista artista)
        {
            return new ArtistaResponse(artista.Id, artista.Nome, artista.Bio, artista.FotoPerfil);
        }
    }

}
