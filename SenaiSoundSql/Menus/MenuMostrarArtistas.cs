using SenaiSoundSql.Modelos;
using SenaiSoundSql.Banco;

namespace SenaiSoundSql.Menus;

internal class MenuMostrarArtistas : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        base.Executar(artistaDAL);
        ExibirTituloDaOpcao("Exibindo todos os artistas registradas na nossa aplicação");
        var artistaRegistrados = artistaDAL.Listar();
        foreach (var artista in artistaRegistrados)
        {
            Console.WriteLine(artista);
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
