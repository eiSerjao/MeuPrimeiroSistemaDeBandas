namespace ScreanSound.Cadastro;

using ScreanSound.Dominio;
using ScreanSound.Menu;
using ScreanSound.Infraestrutura;
using ScreanSound.Consulta;
using ScreanSound.Cadastro;
using ScreanSound.Utilitários;
public class CadastroBandas
{
    private BandasRegistradas sistemaBandas;
    private MenuExibirOpcoes menuExibirOpcoes;

    public CadastroBandas(BandasRegistradas bandas, MenuExibirOpcoes menu)
    {
        sistemaBandas = bandas;
        menuExibirOpcoes = menu;
    }

    public void RegistrarBanda()
    {
        Console.Clear();
        ExibirTitulos.ExibirTituloDaOpção("Registros das bandas");
        Console.Write("Digite o nome da banda que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        Banda novaBanda = new Banda(nomeDaBanda);
        sistemaBandas.RegistrarBanda(novaBanda);

        Console.Clear();
        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
        Thread.Sleep(2000);
        menuExibirOpcoes.ExibirOpcoesDeCadastro();
    }

    // Metodo para Registrar um Novo Álbum
    public void RegistrarAlbum()
    {
        Console.Clear();
        ExibirTitulos.ExibirTituloDaOpção("Registrar um Novo Álbum");
        Console.Write("Digite o nome da banda do álbum: ");
        string nomeDaBanda = Console.ReadLine()!;

        // Usamos o novo método para recuperar a banda real de dentro do confre (dicionário)
        Banda bandaRecuperada = sistemaBandas.RetornarBanda(nomeDaBanda);

        if (bandaRecuperada != null) // Se a banda foi encontrada
        {
            Console.Clear();
            Console.Write("Digite o nome do álbum: ");
            string nomeDoAlbum = Console.ReadLine()!.Trim();

            // Criamos o novo álbum
            Album novoAlbum = new Album(nomeDoAlbum);

            // Adicionamos o álbum à banda que foi recuperada
            bandaRecuperada.AdicionarAlbum(novoAlbum);
            Console.Clear();
            Console.WriteLine($"Álbum '{nomeDoAlbum}' registrado com sucesso para a banda '{nomeDaBanda}'!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            menuExibirOpcoes.ExibirOpcoesDeCadastro();
        }
        else
        {
            Console.WriteLine($"Banda '{nomeDaBanda}' não encontrada. Por favor, registre a banda antes de adicionar um álbum.");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            menuExibirOpcoes.ExibirOpcoesDeCadastro();
        }
    }

    // Metodo para Registrar uma Nova Música
    public void RegistrarMusica()
    {
        Console.Clear();
        ExibirTitulos.ExibirTituloDaOpção("Registrar uma Nova Música");

        // 1. Buscar e Validar a Banda
        Console.Write("Digite o nome da banda aonde será registrada a música: ");
        string nomeDaBanda = Console.ReadLine()!;
        Banda bandaRecuperada = sistemaBandas.RetornarBanda(nomeDaBanda);

        // Logica para verificar se a Banda Existe

        if (bandaRecuperada == null) // Se a banda não foi encontrada
        {
            Console.Clear();
            Console.WriteLine($"Banda '{nomeDaBanda}' não encontrada. Por favor, registre a banda antes de adicionar uma música.");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            menuExibirOpcoes.ExibirOpcoesDeCadastro();
            return; // Sai do método se a banda não existir
        }

        // 2. Buscar e Validar o Genero Musical

        Console.Clear();
        Console.Write("Digite o nome do gênero musical da música: ");
        string nomeDoGenero = Console.ReadLine()!;
        Genero generoRecuperado = sistemaBandas.RetornarGenero(nomeDoGenero);

        // Logica para verificar se o Genero Musical Existe

        if (generoRecuperado == null)
        {
            // Se o gênero não foi encontrado, o usuario pode optar por registrar um novo gênero ou sair
            // Aqui vou assumir que o usuário deve registrar o gênero primeiro
            Console.Clear();
            Console.WriteLine($"Gênero '{nomeDoGenero}' não encontrado. Criando um novo....");
            generoRecuperado = new Genero(nomeDoGenero);
            sistemaBandas.RegistrarGenero(generoRecuperado, nomeDoGenero);
            Thread.Sleep(2000);
        }

        // 3. Coletar os Dados da Música
        Console.Clear();
        Console.Write("Digite o nome da música: ");
        string nomeDaMusica = Console.ReadLine()!;

        Console.Write("Digite a duração da música (ex: 2:30 ou 2):  ");
        string duracaoString = Console.ReadLine()!;

        // Chamando o método auxiliar para converter a duração em segundos
        int duracaoEmSegundos = ConverterTempo.ConverterTempoParaSegundos(duracaoString);

        Console.Write("A música está disponível no plano? (S/N): ");
        bool disponivel = Console.ReadLine()!.Trim().ToUpper() == "S";

        // 4. Criar a Música
        Musica novaMusica = new Musica(bandaRecuperada, nomeDaMusica, duracaoEmSegundos, disponivel, generoRecuperado);

        Console.Clear();
        Console.WriteLine($"Música '{nomeDaMusica}' registrada com sucesso para a banda '{nomeDaBanda}'!");
        Thread.Sleep(2000);

        // 5. Perguntar sobre o Álbum (opcional)
        Console.Clear();
        Console.Write("Deseja adicionar essa música a um álbum existente? (S/N): ");
        if (Console.ReadLine()!.Trim().ToUpper() == "S")
        {
            Console.Clear();
            Console.Write("Digite o nome do álbum: ");
            string nomeDoAlbum = Console.ReadLine()!;

            Album albumRecuperado = bandaRecuperada.RetornarAlbumPeloNome(nomeDoAlbum);

            // Verifica se o álbum existe
            if (albumRecuperado != null)
            {
                Console.Clear();
                albumRecuperado.AdicionarMusica(novaMusica);
                Console.WriteLine($"Música '{nomeDaMusica}' adicionada ao álbum '{nomeDoAlbum}' com sucesso!");
            }
            else
            {
                // Se caiu aqui, o álbum não foi encontrado ou foi digitado errado
                Console.Clear();
                Console.WriteLine($"Álbum '{nomeDoAlbum}' não encontrado na banda '{nomeDaBanda}'. Música não adicionada a nenhum álbum.");
                Console.WriteLine("Você pode adicionar a música a um álbum posteriormente.");
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Ok! A musica foi registrada sem álbum");
        }


        Thread.Sleep(2000);
        menuExibirOpcoes.ExibirOpcoesDeCadastro();

        // fim do método RegistrarMusica
    }

    // Registra GêneroMusical
    public void RegistrarGenreroMusical()
    {
        Console.Clear();
        Boolean SistemaEncerrado = false;

        while (!SistemaEncerrado)
        {
            Console.Clear();
            ExibirTitulos.ExibirTituloDaOpção("Registrar um Novo Genero Musical");
            Console.Write("Qual gênero musical você quer adicionar: ");
            String nomeGenero = Console.ReadLine()!;

            Genero novoGeneroMusical = new Genero(nomeGenero);
            SistemaEncerrado = sistemaBandas.RegistrarGenero(novoGeneroMusical, nomeGenero);

            if (!SistemaEncerrado)
            {
                Console.Clear();
                Console.WriteLine($"Gostaria de Tentar Adicionar um Novo Genero? S/N");
                String opcaoEscolhida = Console.ReadLine()!.Trim().ToUpper();

                if (opcaoEscolhida == "S")
                {
                    SistemaEncerrado = false;
                }
                else if (opcaoEscolhida == "N")
                {
                    SistemaEncerrado = true;
                }
            }
        }

        Console.Write("\nDigite uma tecla para voltar ao menu principal: ");
        Console.ReadKey();
        Console.Clear();

        menuExibirOpcoes.ExibirOpcoesDeCadastro();
    }

    // Metodo para Avaliar uma Banda
    public void AvaliarUmaBanda()
    {

        Console.Clear();
        ExibirTitulos.ExibirTituloDaOpção("Avaliar Banda");
        Console.Write("Digite o nome da banda que deseja avaliar: ");
        string nomeDaBanda = Console.ReadLine()!;
        Banda novaBanda = new Banda(nomeDaBanda);

        sistemaBandas.AdicionarNota(novaBanda);

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
        menuExibirOpcoes.ExibirOpcoesDeCadastro()

        ;
    }

}
