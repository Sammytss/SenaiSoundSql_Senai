namespace SenaiSoundAPI.Requests
{
    //•	Cria um tipo chamado ArtistaRequest com duas propriedades:
    //•	O compilador automaticamente:
    //•	Gera um construtor que aceita nome e bio.
    public record ArtistaRequest(string nome, string bio);
    public record ArtistaRequestEdit(int Id, string nome, string bio)
        : ArtistaRequest(nome, bio);

}
