using PrimeiroProjeto;

public class Album
{
    private List<Musica> musicas = new List<Musica>();
    public double DuracaoTotal => musicas.Sum(m => m.Duracao);
    public String NomeDoAlbum { get; set; }

    public Album(string nome)
    {
        NomeDoAlbum = nome;
    }
    
    public void AdicionarMusica(Musica musica)
    {
        musicas.Add(musica);
    }

    public void ExibirMusicasDoAlbum()
    {
        Console.WriteLine($"Musicas do Álbum: {NomeDoAlbum}\n");
        foreach (var musica in musicas)
        {
            Console.WriteLine($"Música: {musica.NomeDaMusica}");
        }
        Console.WriteLine($"Duração Total do Álbum: {DuracaoTotal}\n");
    }

}