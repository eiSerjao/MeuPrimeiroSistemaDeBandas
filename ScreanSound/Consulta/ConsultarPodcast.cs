namespace ScreanSound.Consulta;

using ScreanSound.Dominio;
using ScreanSound.Menu;
using ScreanSound.Infraestrutura;
using ScreanSound.Consulta;
using ScreanSound.Cadastro;
using ScreanSound.Utilitários;

public class ConsultarPodcast
{
    private PodcastsRegistrados sistemaPodcasts;
    private MenuExibirOpcoes menuExibirOpcoes;

    public ConsultarPodcast(PodcastsRegistrados podcasts, MenuExibirOpcoes menu)
    {
        sistemaPodcasts = podcasts;
        menuExibirOpcoes = menu;
    }

    public void MostrarPodcastsRegistrados()
    {
        Console.Clear();
        ExibirTitulos.ExibirTituloDaOpção("Exibindo Podcasts Registrados");

        // 1. Mostrar a lista de podcasts
        sistemaPodcasts.ExibirPodcastsRegistrados();

        // Opcional: Perguntar se quer ver detalhes de algum podcast
        Console.WriteLine("\nDigite o nome do podcast para ver detalhes ou pressione Enter para voltar: ");
        string nomeDoPodcast = Console.ReadLine()!;

        // Se usuario só der ENTER, volta ao menu
        if (string.IsNullOrEmpty(nomeDoPodcast))
        {
            menuExibirOpcoes.ExibirOpcoesDePodcast();
            return; // Sai do método
        }

        Podcast podcastRecuperado = sistemaPodcasts.RetornarPodcastPeloNome(nomeDoPodcast);

        // 2. Verificar se o podcast existe
        if (podcastRecuperado != null)
        {
            Console.WriteLine($"\nPodcast '{nomeDoPodcast}' encontrado.");

            // 3. Opcional: perguntar se quer ver os episodio do podcast
            Console.Write("Deseja ver os detalhes do podcast? (S/N): ");
            string resposta = Console.ReadLine()!.Trim().ToUpper();

            if (resposta == "S")
            {
                Console.Clear();
                ExibirTitulos.ExibirTituloDaOpção($"Detalhes do Podcast: {podcastRecuperado.Nome}");

                // Listar os episódios do podcast
                podcastRecuperado.ExibirDetalhes();

                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
                Console.ReadKey();
                // --------------------------------------
            }
            else
            {
                Console.WriteLine("Ok! Voltando ao menu de podcasts.");
                Thread.Sleep(2000);
            }
        }
        else
        {
            Console.WriteLine($"\nPodcast '{nomeDoPodcast}' não encontrado.");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }
        menuExibirOpcoes.ExibirOpcoesDePodcast();
    }
}
