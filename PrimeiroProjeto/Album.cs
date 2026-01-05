using PrimeiroProjeto;

public class Album
{
    // Lista de Músicas do Álbum
    private List<Musica> musicas = new List<Musica>();
    public double DuracaoTotal => musicas.Sum(m => m.Duracao);
    public String NomeDoAlbum { get; set; }

    // Construtor do Album
    public Album(string nome)
    {
        NomeDoAlbum = nome;
    }

    // Metodo para Adicionar Musica ao Album
    public void AdicionarMusica(Musica musica)
    {
        musicas.Add(musica);
    }

    // Metodo para Exibir as Musicas do Album
    public void ExibirMusicasDoAlbum()
    {
        Console.WriteLine($"Musicas do Álbum: {NomeDoAlbum}\n");
        foreach (var musica in musicas)
        {
            Console.WriteLine($"Música: {musica.NomeDaMusica}");
        }
        Console.WriteLine($"Duração Total do Álbum: {DuracaoTotal}\n");
    }
    
    // fim da classe Album

}