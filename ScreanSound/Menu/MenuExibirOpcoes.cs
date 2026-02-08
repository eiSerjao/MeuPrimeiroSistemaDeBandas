namespace ScreanSound.Menu;

using ScreanSound.Dominio;
using ScreanSound.Menu;
using ScreanSound.Infraestrutura;
using ScreanSound.Consulta;
using ScreanSound.Cadastro;

internal class MenuExibirOpcoes
{


  // Metodo para Exibir as Opções de Consulta
  public void ExibirOpcoesDeConsulta()
  {
    Console.Clear();
    ExibirTituloDaOpção("Central de Consultas");
    Console.WriteLine("Digite 1 para Mostrar as Bandas Registradas");
    Console.WriteLine("Digite 2 para Exibir a Média de uma Banda");
    Console.WriteLine("Digite 3 para Ver Detalhes De Uma Banda (Discografia e Músicas)");
    Console.WriteLine("Digite 0 para Central de Cadastro");
    Console.WriteLine("Digite -1 para Central de Podcasts");

    Console.Write("\nEscolha uma opção: ");
    string opcao = Console.ReadLine()!;

    if (int.TryParse(opcao, out int opcaoEscolhida))
    {
      switch (opcaoEscolhida)
      {
        case 1:
          MostrarBandasRegistradas();
          break;
        case 2:
          ExibirMediaDaBanda();
          break;
        case 3:
          ExibirDetalhesDaBanda();
          break;
        case 0:
          ExibirOpcoesDeCadastro();
          break;
        case -1:
          ExibirOpcoesDePodcast();
          break;
        default:
          Console.WriteLine("Opção inválida. Tente novamente.");
          Thread.Sleep(2000);
          ExibirOpcoesDeConsulta();
          break;
      }
    }
    else
    {
      Console.WriteLine("Opção inválida. Tente novamente.");
      Thread.Sleep(2000);
      ExibirOpcoesDeConsulta();
    }
  }

  // Metodo para Exibir as Opções de Cadastro
  public void ExibirOpcoesDeCadastro()
  {
    Console.Clear();
    ExibirTituloDaOpção("Central de Cadastros");
    Console.WriteLine("Digite 1 para Registrar uma Banda");
    Console.WriteLine("Digite 2 para Registrar um Novo Álbum");
    Console.WriteLine("Digite 3 para Registrar uma Nova Música");
    Console.WriteLine("Digite 4 para Registrar um Novo Gênero Musical");
    Console.WriteLine("Digite 5 para Avaliar uma Banda");
    Console.WriteLine("Digite 0 para Voltar ao Menu de Consultas");

    Console.Write("\nEscolha uma opção: ");
    string opcao = Console.ReadLine()!;

    if (int.TryParse(opcao, out int opcaoEscolhida))
    {
      switch (opcaoEscolhida)
      {
        case 1:
          RegistrarBanda();
          break;
        case 2:
          RegistrarAlbum();
          break;
        case 3:
          RegistrarMusica();
          break;
        case 4:
          RegistrarGenreroMusical();
          break;
        case 5:
          AvaliarUmaBanda();
          break;
        case 0:
          ExibirOpcoesDeConsulta();
          break;
        default:
          Console.WriteLine("Opção inválida. Tente novamente.");
          Thread.Sleep(2000);
          ExibirOpcoesDeCadastro();
          break;
      }
    }
    else
    {
      Console.WriteLine("Opção inválida. Tente novamente.");
      Thread.Sleep(2000);
      ExibirOpcoesDeCadastro();
    }
  }

  // -----------------------------------------------------------------

  // Metodo para Exibir as Opções de Podcast
  public void ExibirOpcoesDePodcast()
  {
    Console.Clear();
    ExibirTituloDaOpção("Central de Podcasts");
    Console.WriteLine("Digite 1 para Registrar um Podcast");
    Console.WriteLine("Digite 2 para Mostrar Podcasts Registrados");
    Console.WriteLine("Digite 3 para Adicionar um Episódio");
    Console.WriteLine("Digite 0 para Voltar a Central de Consultas");

    Console.Write("\nEscolha uma opção: ");
    string opcao = Console.ReadLine()!;

    if (int.TryParse(opcao, out int opcaoEscolhida))
    {
      switch (opcaoEscolhida)
      {
        case 1:
          RegistrarPodcast();
          break;
        case 2:
          MostrarPodcastsRegistrados();
          break;
        case 3:
          AdicionarEpisodio();
          break;
        case 0:
          ExibirOpcoesDeConsulta();
          break;
        default:
          Console.WriteLine("Opção inválida. Tente novamente.");
          Thread.Sleep(2000);
          ExibirOpcoesDePodcast();
          break;
      }
    }
  }
}
