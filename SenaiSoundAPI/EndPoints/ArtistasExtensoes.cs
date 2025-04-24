using Microsoft.AspNetCore.Mvc;
using SenaiSoundAPI.Requests;
using SenaiSoundSql.Banco;
using SenaiSoundSql.Modelos;

namespace SenaiSoundAPI.EndPoints
{
    public static class ArtistasExtensoes
    {
        public static void AddEndPointsArtistas(this WebApplication app)
        {
            app.MapGet("/Artistas", ([FromServices] DAL<Artista> dal) =>
            {
                var artistas = dal.Listar();
                return Results.Ok(artistas);
            });

            app.MapGet("/Artistas/{nome}", ([FromServices] DAL < Artista > dal, string nome) =>
            {
                var artistas = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
                if (artistas is null)
                {
                    return Results.NotFound("Artista não encontrado!");
                }
                return Results.Ok(artistas);

            });

            app.MapPost("/Artistas", ([FromServices] DAL<Artista> dal, [FromBody] ArtistaRequiest artistaRequest) =>
            {
                var artista = new Artista(artistaRequest.nome, artistaRequest.bio);
                dal.AdicionarObjeto(artista);
                return Results.Created($"/Artistas/{artistaRequest.nome}", artistaRequest);
            });

            app.MapPut("/Artistas/", ([FromServices] DAL<Artista> dal, [FromBody] ArtistaRequiestEdit artistaRequestEdit) =>
            {
                var ArtistaAAtualizar = dal.RecuperarPor(a => a.Id.Equals(artistaRequestEdit.id));
                if (ArtistaAAtualizar is null)
                {
                    return Results.NotFound("Artista não encontrado!");
                }
                ArtistaAAtualizar.Nome = artistaRequestEdit.nome;
                ArtistaAAtualizar.Bio = artistaRequestEdit.bio;
                dal.AtualizarObjeto(ArtistaAAtualizar);
                return Results.Ok($"{ArtistaAAtualizar}, atualizado com sucesso!!");
            });

            app.MapDelete("/Artistas/{nome}", ([FromServices] DAL<Artista> dal, string nome) =>
            {
                var artista = dal.RecuperarPor(a => a.Nome.Equals(nome));
                if (artista is null)
                {
                    return Results.NotFound("Artista não encontrado!");
                }
                dal.AtualizarObjeto(artista);
                return Results.Content($"{artista}, deletado com sucesso!!");
            });
        
        }

    }
}
