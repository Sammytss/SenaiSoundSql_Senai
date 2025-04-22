using SenaiSoundSql.Banco;
using SenaiSoundSql.Modelos;

namespace SenaiSoundSql.Menus;

internal class MenuSair : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}
