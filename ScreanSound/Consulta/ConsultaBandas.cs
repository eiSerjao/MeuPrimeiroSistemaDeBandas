namespace ScreanSound.Consulta;

using ScreanSound.Dominio;
using ScreanSound.Menu;
using ScreanSound.Infraestrutura;
using ScreanSound.Consulta;
using ScreanSound.Cadastro;
using ScreanSound.Utilitários;
public class ConsultaBandas
{
    public void MostrarBandasRegistradas()
    {
        Console.Clear();
        ExibirTituloDaOpção("Exibindo todas as bandas registradas");
        sistemaBandas.ExibirBandasRegistradas();
        Console.Write("\nDigite uma tecla para voltar ao menu principal: ");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDeConsulta();
    }

    // Metodo para Exibir a Média da Banda 
    public void ExibirMediaDaBanda()
    {
        Console.Clear();
        ExibirTituloDaOpção("Exibindo a média de uma banda");
        Console.Write("Digite o nome da banda que deseja ver a média: ");
        string nomeDaBanda = Console.ReadLine()!;
        Banda novaBanda = new Banda(nomeDaBanda);

        sistemaBandas.ExibirMédiaNotas(novaBanda);

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
        ExibirOpcoesDeConsulta();
    }

    // Metodo para Exibir os Detalhes da Banda
    public void ExibirDetalhesDaBanda()
    {
        Console.Clear();
        ExibirTituloDaOpção("Exibindo os detalhes de uma banda");
        Console.Write("Digite o nome da banda que deseja ver os detalhes: ");
        string nomeDaBanda = Console.ReadLine()!;

        //1. Buscar a Banda
        Banda bandaRecuperada = sistemaBandas.RetornarBanda(nomeDaBanda);

        // --- GUARDAR 1: Se a banda NÃO existe, avisa e sai.
        if (bandaRecuperada == null)
        {
            Console.WriteLine($"\nBanda '{nomeDaBanda}' não encontrada.");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
            ExibirOpcoesDeConsulta();
            return; // Sai do método
        }

        Console.Clear();

        //2. Exibir a Discografia da Banda
        bandaRecuperada.ExibirDiscofrafia();

        Console.WriteLine("\nDeseja ver as músicas de algum álbum específico? (S/N): ");
        string resposta = Console.ReadLine()!.Trim().ToUpper();

        // --- GUADAR 2: Se a reposta for NÃO, sai.
        if (resposta != "S")
        {
            ExibirOpcoesDeConsulta();
            return; // Sai do método
        }

        //3. Perguntar qual álbum
        Console.Write("Digite o nome do álbum que deseja ver as músicas: ");
        string nomeDoAlbum = Console.ReadLine()!;
        Album albumRecuperado = bandaRecuperada.RetornarAlbumPeloNome(nomeDoAlbum);

        // --- GUARDAR 3: Se o álbum NÃO existe, avisa e sai.
        if (albumRecuperado == null)
        {
            Console.WriteLine($"\nO Álbum '{nomeDoAlbum}' não encontrado.");
            Console.WriteLine("Digite uma tecla para voltar.");
            Console.ReadKey();
            ExibirOpcoesDeConsulta();
            return; // Sai do método
        }

        Console.Clear();

        //4. Exibir as Músicas do Álbum
        albumRecuperado.ExibirMusicasDoAlbum();

        Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
        ExibirOpcoesDeConsulta();
    }

}
