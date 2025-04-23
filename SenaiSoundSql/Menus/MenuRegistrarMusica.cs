using SenaiSoundSql.Banco;
using SenaiSoundSql.Modelos;

namespace SenaiSoundSql.Menus;

internal class MenuRegistrarMusica : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        base.Executar(artistaDAL);
        ExibirTituloDaOpcao("Registro de músicas");
        Console.Write("Digite o artista cuja música deseja registrar: ");
        string nomeDoArtista = Console.ReadLine()!;
        var artistasRecuperados = artistaDAL.RecuperarPor(a => a.Id.Equals(nomeDoArtista));
        if (artistasRecuperados is not null)
        {
            Console.Write("Agora digite o título da música: ");
            string tituloDaMusica = Console.ReadLine()!;
            Console.Write("Agora digite o ano de lançamento: ");
            int anoDeLancamento = int.Parse(Console.ReadLine()!);
            artistasRecuperados.AdicionarMusica(new Musica(tituloDaMusica, anoDeLancamento/*, artistasRecuperados*/));
            Console.WriteLine($"A música {tituloDaMusica} de {nomeDoArtista} foi registrada com sucesso!");
            Thread.Sleep(4000);
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nO artista {nomeDoArtista} não foi encontrado!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
