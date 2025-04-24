namespace SenaiSoundAPI.Requests
{
    public record ArtistaRequiest (string nome, string bio);
    public record ArtistaRequiestEdit(int id, string nome, string bio)
        : ArtistaRequiest(nome, bio);
}
