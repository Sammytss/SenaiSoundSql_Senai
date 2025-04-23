namespace SenaiSoundSql.Modelos;

public class Musica
{
    public Musica(string nome/*, Artista artista)*/, int? anoDeLancamento)
    {
        Nome = nome;/*
        Artista = artista;*/
        AnoDeLancamento = anoDeLancamento;
    }

    public string Nome { get; set; }
    public int Id { get; set; }
    public int? AnoDeLancamento { get; set; }
    public Artista? Artista { get; set; }

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");
      
    }

    public override string ToString()
    {
        return @$"Id: {Id}
        Nome: {Nome}";
    }
}