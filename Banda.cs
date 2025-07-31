namespace PrimeiroProjeto;

public class Banda
{
    private List<Album> albums { get; } = new List<Album>();
    
    public String NomeDaBanda { get; }

    // Construtor
    public Banda(string nome)
    {
        NomeDaBanda = nome;
    }
    
    // Método para adicionar album na lista de album da banda.
    public void AdicionarAlbum(Album album)
    {
        albums.Add(album);
    }

    public void ExibirDiscofrafia()
    {
        Console.WriteLine($"Discografia da Banda: {NomeDaBanda}\n");
        foreach (Album album in albums)
        {
            Console.WriteLine($"Álbum: {album.NomeDoAlbum} ({album.DuracaoTotal} segundos!)");
        }
    }

}
