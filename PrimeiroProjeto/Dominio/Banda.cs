namespace PrimeiroProjeto.Dominio;

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
    // Metodo para Exibir a Discografia da Banda
    public void ExibirDiscofrafia()
    {
        Console.WriteLine($"Discografia da Banda: {NomeDaBanda}\n");
        foreach (Album album in albums)
        {
            Console.WriteLine($"Álbum: {album.NomeDoAlbum} ({album.DuracaoTotal} segundos!)");
        }
    }

    // Metodo para retornar album pelo nome
    public Album RetornarAlbumPeloNome(string nomeDoAlbum)
    {
        foreach (var album in albums)
        {
            if (album.NomeDoAlbum.ToUpper() == nomeDoAlbum.ToUpper())
            {
                return album;
            }
        }
        return null;
    }

}