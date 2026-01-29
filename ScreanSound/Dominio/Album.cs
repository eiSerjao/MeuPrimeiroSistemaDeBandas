
namespace ScreanSound.Dominio;

public class Album
{
    // Lista de Músicas do Álbum
    private List<Musica> musicas = new List<Musica>();
    public String NomeDoAlbum { get; set; }
    
    // Soma a duração (assumindo que Musica.Duracao. Duracao é um int representando segundos)
    public int DuracaoTotal => musicas.Sum(m => m.Duracao);
    

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

    // --- NOVO: Método para Exibir Músicas do Álbum com Detalhes do Tempo ---
    public void ExibirMusicasDoAlbum()
    {
        Console.WriteLine($"Listando músicas do álbum: {NomeDoAlbum}");
        Console.WriteLine("-------------------------------------");
        
        //Formatação: {musica.Duracao /60} pegas os minutos
        // {musica.Duracao % 60:D2} pega os resto (segundos) e formata com 2 digitos 
        foreach (var musica in musicas)
        {
            Console.WriteLine($"Musica: {musica.NomeDaMusica} - Duração: {musica.Duracao / 60}:{musica.Duracao % 60:D2}");
        }
        
        Console.WriteLine("-------------------------------------");
        // Aqui usamos a mesma logica para formatar a duração total
        Console.WriteLine($"Duração Total do Álbum: {DuracaoTotal / 60}:{DuracaoTotal % 60:D2} \n");
        Console.WriteLine("\n"); 
        Console.WriteLine("--- Fim da Lista de Músicas do Álbum ---");   
    }

        // fim da classe Album

}