namespace ScreanSound.Menu;

using ScreanSound;
using ScreanSound.Dominio;
using ScreanSound.Menu;
using ScreanSound.Infraestrutura;
using ScreanSound.Consulta;
using ScreanSound.Cadastro;
using ScreanSound.Utilitários;

public class MenuExibirOpcoes
{
  private BandasRegistradas sistemaBandas;
  private PodcastsRegistrados sistemaPodcasts;

  public MenuExibirOpcoes(BandasRegistradas bandas, PodcastsRegistrados podcasts)
  {
    sistemaBandas = bandas;
    sistemaPodcasts = podcasts;
  }

  // Metodo para Exibir as Opções de Consulta
  public void ExibirOpcoesDeConsulta()
  {
    Console.Clear();
    ExibirTitulos.ExibirLogo();
    ExibirTitulos.ExibirTituloDaOpção("Central de Consultas");
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
          ConsultaBandas consulta1 = new ConsultaBandas(sistemaBandas, this);
          consulta1.MostrarBandasRegistradas();
          break;
        case 2:
          ConsultaBandas consulta2 = new ConsultaBandas(sistemaBandas, this);
          consulta2.ExibirMediaDaBanda();
          break;
        case 3:
          ConsultaBandas consulta3 = new ConsultaBandas(sistemaBandas, this);
          consulta3.ExibirDetalhesDaBanda();
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
    ExibirTitulos.ExibirTituloDaOpção("Central de Cadastros");
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
          CadastroBandas cadastro1 = new CadastroBandas(sistemaBandas, this);
          cadastro1.RegistrarBanda();
          break;
        case 2:
          CadastroBandas cadastro2 = new CadastroBandas(sistemaBandas, this);
          cadastro2.RegistrarAlbum();
          break;
        case 3:
          CadastroBandas cadastro3 = new CadastroBandas(sistemaBandas, this);
          cadastro3.RegistrarMusica();
          break;
        case 4:
          CadastroBandas cadastro4 = new CadastroBandas(sistemaBandas, this);
          cadastro4.RegistrarGenreroMusical();
          break;
        case 5:
          CadastroBandas cadastro5 = new CadastroBandas(sistemaBandas, this);
          cadastro5.AvaliarUmaBanda();
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
    ExibirTitulos.ExibirTituloDaOpção("Central de Podcasts");
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
          CadastroPodcasts podcast1 = new CadastroPodcasts(sistemaPodcasts, this);
          podcast1.RegistrarPodcast();
          break;
        case 2:
          ConsultarPodcast podcast2 = new ConsultarPodcast(sistemaPodcasts, this);
          podcast2.MostrarPodcastsRegistrados();
          break;
        case 3:
          CadastroPodcasts podcast3 = new CadastroPodcasts(sistemaPodcasts, this);
          podcast3.AdicionarEpisodio();
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
