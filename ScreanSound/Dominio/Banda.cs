namespace ScreanSound.Dominio;

using ScreanSound.Dominio;
using ScreanSound.Menu;
using ScreanSound.Infraestrutura;
using ScreanSound.Consulta;
using ScreanSound.Cadastro;
using ScreanSound.Utilitários;

public class Banda
{
    // Lista de álbuns da banda (privada)
    private List<Album> albums { get; } = new List<Album>();
    // Lista privada de notas da banda
    private List<int> notas = new List<int>();
    //Lista de notas da banda publica para acesso externo
    public List<int> Notas => notas;
    
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
        return null!;
    }


    // Método para Adicionar Nota Direto (usado para testes)
    public void AdicionarNota(Banda banda, int nota)
    {
        notas.Add(nota);
    }

    public int ObterQuantidadeNotas() => notas.Count;

}