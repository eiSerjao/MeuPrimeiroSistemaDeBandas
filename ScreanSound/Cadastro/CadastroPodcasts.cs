namespace ScreanSound.Cadastro;

using ScreanSound.Dominio;
using ScreanSound.Menu;
using ScreanSound.Infraestrutura;
using ScreanSound.Consulta;
using ScreanSound.Cadastro;
using ScreanSound.Utilitários;
public class CadastroPodcasts
{
    void RegistrarPodcast()
    {
        Console.Clear();
        ExibirTituloDaOpção("Registro de Podcast");
        Console.Write("Digite o nome do Podcast: ");
        string nomeDoPodcast = Console.ReadLine()!;
        Console.Write("Digite o nome do Host do Podcast: ");
        string nomeDoHost = Console.ReadLine()!;

        Podcast novoPodcast = new Podcast(nomeDoPodcast, nomeDoHost);
        sistemaPodcasts.RegistrarPodcast(novoPodcast);

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
        ExibirOpcoesDePodcast();
    }

    void AdicionarEpisodio()
    {
        Console.Clear();
        ExibirTituloDaOpção("Adicionar Episódio a um Podcast");

        //1. Achar o Podcast
        Console.Write("Digite o nome do Podcast onde deseja adicionar episódio: ");
        string nomeDoPodcast = Console.ReadLine()!;

        Podcast podcastRecuperado = sistemaPodcasts.RetornarPodcastPeloNome(nomeDoPodcast);

        if (podcastRecuperado == null)
        {
            Console.WriteLine($"\nPodcast '{nomeDoPodcast}' não encontrado.");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
            ExibirOpcoesDePodcast();
            return; // Sai do método
        }

        // 2. Criar o Episódio
        Console.WriteLine($"\n Adicionando episódio ao podcast '{nomeDoPodcast}'");

        Console.Write("Digite o número do episódio: ");
        int numeroDoEpisodio = int.Parse(Console.ReadLine()!);

        Console.Write("Digite o título do episódio: ");
        string tituloDoEpisodio = Console.ReadLine()!;

        Console.Write("Digite a duração do episódio em minutos (formato mm:ss): ");
        string duracaoString = Console.ReadLine()!;

        int duracaoEmSegundos = ConverterTempoParaSegundos(duracaoString);


        // Criando o objeto Episódio
        Episodio novoEpisodio = new Episodio
        {
            Numero = numeroDoEpisodio,
            Titulo = tituloDoEpisodio,
            Duracao = duracaoEmSegundos / 60 // Convertendo segundos para minutos
        };

        // 3. Adicionar Convidados (opcional)
        Console.Write("Deseja adicionar convidados? (S/N): ");
        string resposta = Console.ReadLine()!.Trim().ToUpper();

        if (resposta == "S")
        {
            Console.Clear();
            Console.Write("Quantos convidados deseja adicionar?: ");
            int quantidadeConvidados = int.Parse(Console.ReadLine()!);

            for (int i = 0; i < quantidadeConvidados; i++)
            {
                Console.Write($"Digite o nome do convidado {i + 1}: ");
                string nomeDoConvidado = Console.ReadLine()!;
                novoEpisodio.AdicionarConvidado(nomeDoConvidado);
            }
        }

        // 4. Salvar no Podcast
        podcastRecuperado.AdicionarEpisodio(novoEpisodio);

        Console.WriteLine($"\nEpisódio '{tituloDoEpisodio}' adicionado com sucesso ao podcast '{nomeDoPodcast}'!");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
        ExibirOpcoesDePodcast();
    }
}
