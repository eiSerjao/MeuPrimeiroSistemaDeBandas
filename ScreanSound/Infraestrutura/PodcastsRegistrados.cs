

using ScreanSound.Dominio;
using ScreanSound.Menu;
using ScreanSound.Infraestrutura;
using ScreanSound.Consulta;
using ScreanSound.Cadastro;
namespace ScreanSound.Infraestrutura;

public class PodcastsRegistrados
{
  // Dicionario para armazenar os podcasts registrados
  private Dictionary<string, Podcast> _podcasts = new Dictionary<string, Podcast>();

// Método para registrar um novo podcast
  public void RegistrarPodcast(Podcast podcast)
  {
    if (!_podcasts.ContainsKey(podcast.Nome))
    {
      _podcasts.Add(podcast.Nome, podcast);
    Console.WriteLine($"Podcast {podcast.Nome} registrado com sucesso!");
    }
    else
    {
      Console.WriteLine($"Podcast {podcast.Nome} já está registrado.");
    }
  }

  // Método para Exibir a Lista de Podcasts Registrados
  public void ExibirPodcastsRegistrados()
  {
    Console.Clear();
    if (_podcasts.Count == 0)
    {
      Console.WriteLine("Nenhum podcast registrado.");
      return;
    }

    Console.WriteLine("\n--- Podcasts Registrados ---");
    foreach (var podcast in _podcasts.Values)
    {
      Console.WriteLine($"Podcast: {podcast.Nome} | Host: {podcast.Host}, Total de Episódios: {podcast.TotalEpisodios}");
    }
  }

  // Método para buscar Podcast pelo nome (para adicionar episódios)
  public Podcast RetornarPodcastPeloNome(string nomeDoPodcast)
  {
    if (_podcasts.ContainsKey(nomeDoPodcast))
    {
      return _podcasts[nomeDoPodcast];
    }
    return null!; // Retorna null se não encontrado

  }

}