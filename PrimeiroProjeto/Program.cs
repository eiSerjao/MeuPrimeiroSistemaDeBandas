using PrimeiroProjeto.Dominio;

using PrimeiroProjeto.Infraestrutura;

// --- CONFIGURAÇÃO INICIAL E VARIÁVEIS GLOBAIS ---
string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";
BandasRegistradas sistemaBandas = new BandasRegistradas();
PodcastsRegistrados sistemaPodcasts = new PodcastsRegistrados();

// Carrega os dados de teste (Mock) antes de iniciar
CarregarDadosInicias();

// --- NOVO: Teste do Desafio Podcast
// TestarDesafioPodcast();

//Inicia o progama
ExibirOpcoesDoMenu();

// -----------------------------------------------------------------

#region MENUS DE 3NAVEGAÇÃO
// Responsáveis por mostrar as opções e rotear (Switch Case)

// Metodo Principal para Exibir as Opções do Menu
void ExibirOpcoesDoMenu()
{
    Console.Clear();
    ExibirLogo();
    Console.WriteLine("\n--- MENU PRINCIPAL ---");
    Console.WriteLine("Digite 1 para Acessar a Central de Cadastros");
    Console.WriteLine("Digite 2 para Acessar a Central de Consultas");
    Console.WriteLine("Digite 3 para Acessar a Central de Podcasts");
    Console.WriteLine("Digite 0 para Sair do Sistema");

    Console.Write("\nEscolha uma opção: ");
    string opcao = Console.ReadLine()!;

    if (int.TryParse(opcao, out int opcaoEscolhida))
    {
        switch (opcaoEscolhida)
        {
            case 1:
                Console.Clear();
                ExibirOpcoesDeCadastro();
                break;
            case 2:
                Console.Clear();
                ExibirOpcoesDeConsulta();
                break;
            case 3:
                Console.Clear();
                ExibirOpcoesDePodcast();
                break;
            case 0:
                Console.Clear();
                Console.WriteLine("Encerrando o sistema... Até mais!");
                Thread.Sleep(2000);
                break;
            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                Thread.Sleep(2000);
                ExibirOpcoesDoMenu();
                break;
        }
    }
    else
    {
        Console.WriteLine("Opção inválida. Tente novamente.");
        Thread.Sleep(2000);
        ExibirOpcoesDoMenu();
    }
}

// Metodo para Exibir as Opções de Cadastro
void ExibirOpcoesDeCadastro()
{
    Console.Clear();
    ExibirTituloDaOpção("Central de Cadastros");
    Console.WriteLine("Digite 1 para Registrar uma Banda");
    Console.WriteLine("Digite 2 para Registrar um Novo Álbum");
    Console.WriteLine("Digite 3 para Registrar uma Nova Música");
    Console.WriteLine("Digite 4 para Registrar um Novo Gênero Musical");
    Console.WriteLine("Digite 5 para Avaliar uma Banda");
    Console.WriteLine("Digite 0 para Voltar ao Menu Principal");

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
                ExibirOpcoesDoMenu();
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

// Metodo para Exibir as Opções de Consulta
void ExibirOpcoesDeConsulta()
{
    Console.Clear();
    ExibirTituloDaOpção("Central de Consultas");
    Console.WriteLine("Digite 1 para Mostrar as Bandas Registradas");
    Console.WriteLine("Digite 2 para Exibir a Média de uma Banda");
    Console.WriteLine("Digite 3 para Ver Detalhes De Uma Banda (Discografia e Músicas)");
    Console.WriteLine("Digite 0 para Voltar ao Menu Principal");

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
                ExibirOpcoesDoMenu();
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

#endregion

// -----------------------------------------------------------------

#region MÉTODOS DE CADASTRO
// Responsáveis por criar novos dados

// Metodo para Registrar uma Banda
void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpção("Registros das bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    Banda novaBanda = new Banda(nomeDaBanda);
    sistemaBandas.RegistrarBanda(novaBanda);
    
    Console.Clear();
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep( 2000 );
    ExibirOpcoesDeCadastro();
}

// Metodo para Registrar um Novo Álbum
void RegistrarAlbum()

{
    Console.Clear();
    ExibirTituloDaOpção("Registrar um Novo Álbum");
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
        ExibirOpcoesDeCadastro();
    }
    else
    {
        Console.WriteLine($"Banda '{nomeDaBanda}' não encontrada. Por favor, registre a banda antes de adicionar um álbum.");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDeCadastro();
    }
}

// Metodo para Registrar uma Nova Música
void RegistrarMusica()
{
    Console.Clear();
    ExibirTituloDaOpção("Registrar uma Nova Música");

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
        ExibirOpcoesDeCadastro();
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
    int duracaoEmSegundos = ConverterTempoParaSegundos(duracaoString);

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
    ExibirOpcoesDeCadastro();

    // fim do método RegistrarMusica
}

// Registra GêneroMusical
void RegistrarGenreroMusical()
{
    Console.Clear();
    Boolean SistemaEncerrado = false;

    while (!SistemaEncerrado)
    {
        Console.Clear();
        ExibirTituloDaOpção("Registrar um Novo Genero Musical");
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
            else  if (opcaoEscolhida == "N")
            {
                SistemaEncerrado = true;
            }
        }
    }
    
    Console.Write("\nDigite uma tecla para voltar ao menu principal: ");
    Console.ReadKey();
    Console.Clear();
        
    ExibirOpcoesDeCadastro();
}

// Metodo para Avaliar uma Banda
void AvaliarUmaBanda()
{

    Console.Clear();
    ExibirTituloDaOpção("Avaliar Banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    Banda novaBanda = new Banda(nomeDaBanda);

    sistemaBandas.AdicionarNota(novaBanda);

    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
    Console.ReadKey();
    
    ExibirOpcoesDeCadastro();
}   

#endregion

// -----------------------------------------------------------------

#region MÉTODOS DE CONSULTA
// Responsáveis por ler e exibir dados já cadastrados

// Metodo para Mostrar as Bandas Registradas
void MostrarBandasRegistradas()
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
void ExibirMediaDaBanda()
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
void ExibirDetalhesDaBanda()
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

#endregion

// --------------------------------------------------------------------

#region MÉTODOS DE PODCASTS

void ExibirOpcoesDePodcast()
{
    Console.Clear();
    ExibirTituloDaOpção("Central de Podcasts");
    Console.WriteLine("Digite 1 para Registrar um Podcast");
    Console.WriteLine("Digite 2 para Mostrar Podcasts Registrados");
    Console.WriteLine("Digite 3 para Adicionar um Episódio");
    Console.WriteLine("Digite 0 para Voltar ao Menu Principal");

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
                ExibirOpcoesDoMenu();
                break;
            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                Thread.Sleep(2000);
                ExibirOpcoesDePodcast();
                break;
        }
    }
}

// Metodo Registrar um Podcast
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

    void MostrarPodcastsRegistrados()
    {
        Console.Clear();
        ExibirTituloDaOpção("Exibindo Podcasts Registrados");

        // 1. Mostrar a lista de podcasts
        sistemaPodcasts.ExibirPodcastsRegistrados();

        // Opcional: Perguntar se quer ver detalhes de algum podcast
        Console.WriteLine("\nDigite o nome do podcast para ver detalhes ou pressione Enter para voltar: ");
        string nomeDoPodcast = Console.ReadLine()!;

        // Se usuario só der ENTER, volta ao menu
        if (string.IsNullOrEmpty(nomeDoPodcast))
        {
            ExibirOpcoesDePodcast();
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
                ExibirTituloDaOpção($"Detalhes do Podcast: {podcastRecuperado.Nome}");

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

// --------------------------------------------------------------------

// --- MÉTODOS AUXILIARES E DE TESTE ---

#region UTILITÁRIOS E DADOS INICIAIS
// Ferramentas auxiliares e dados mock para testes

// Metodo para Carregar Dados Iniciais (Mock)
void CarregarDadosInicias()
{
    // --- The Beatles ---
    Banda banda1 = new Banda("The Beatles");
    // Adicionando notas de teste
    sistemaBandas.AdicionarNota(banda1, 10);
    sistemaBandas.AdicionarNota(banda1, 8);
    sistemaBandas.AdicionarNota(banda1, 9);

    Album album1 = new Album("Abbey Road");
    Musica musica1 = new Musica(banda1, "Come Together", 259, true, new Genero("Rock"));
    Musica musica2 = new Musica(banda1, "Something", 182, true, new Genero("Rock"));
    album1.AdicionarMusica(musica1);
    album1.AdicionarMusica(musica2);
    banda1.AdicionarAlbum(album1);
    sistemaBandas.RegistrarBanda(banda1);

    // Adicionando notas de teste
    sistemaBandas.AdicionarNota(banda1, 10);
    sistemaBandas.AdicionarNota(banda1, 8);
    sistemaBandas.AdicionarNota(banda1, 9);

    // ------------------------------------------------------------

    // --- Pink Floyd ---
    Banda banda2 = new Banda("Pink Floyd");
    
    
    Album album2 = new Album("The Dark Side of the Moon");
    Musica musica3 = new Musica(banda2, "Time", 413, true, new Genero("Progressive Rock"));
    Musica musica4 = new Musica(banda2, "Money", 382, true, new Genero("Progressive Rock"));
    album2.AdicionarMusica(musica3);
    album2.AdicionarMusica(musica4);
    banda2.AdicionarAlbum(album2);
    sistemaBandas.RegistrarBanda(banda2);

    // Adicionando notas de teste
    sistemaBandas.AdicionarNota(banda2, 9); // Nota depois
    sistemaBandas.AdicionarNota(banda2, 10);

    // ------------------------------------------------------------

    // --- Oficina G3 ---
    Banda banda3 = new Banda("Oficina G3");
    

    Album album3 = new Album("Depois da Guerra");
    Musica musica5 = new Musica(banda3, "Depois da Guerra", 300, true, new Genero("Rock Cristão"));
    Musica musica6 = new Musica(banda3, "Incondicional", 240, true, new Genero("Rock Cristão"));
    album3.AdicionarMusica(musica5);
    album3.AdicionarMusica(musica6);
    banda3.AdicionarAlbum(album3);
    sistemaBandas.RegistrarBanda(banda3);

    // Adicionando notas de teste
    sistemaBandas.AdicionarNota(banda3, 10); // Nota depois
    sistemaBandas.AdicionarNota(banda3, 10); // Oficina merece 10 rsrs

    // ------------------------------------------------------------

    // --- MOCK DE PODCASTS ---
    
    // 1. Podcast Especial do Paulo
    Podcast podcastPaulo = new Podcast("Podcast do Paulo", "Paulo Sérgio");
    
    Episodio ep1 = new Episodio { Numero = 1, Titulo = "História do Rock", Duracao = 1200 };
    ep1.AdicionarConvidado("João");
    ep1.AdicionarConvidado("Maria");
    
    Episodio ep2 = new Episodio { Numero = 2, Titulo = "Arquitetura Limpa na Prática", Duracao = 2500 };
    ep2.AdicionarConvidado("Tio Bob");

    podcastPaulo.AdicionarEpisodio(ep1);
    podcastPaulo.AdicionarEpisodio(ep2);
    
    sistemaPodcasts.RegistrarPodcast(podcastPaulo);


    // 2. Podcast Hipsters Ponto Tech (Exemplo)
    Podcast podcastHipsters = new Podcast("Hipsters Ponto Tech", "Alura");
    
    Episodio epHipster1 = new Episodio { Numero = 1, Titulo = "Inovação e Tech", Duracao = 1800 };
    epHipster1.AdicionarConvidado("Paulo Silveira");
    
    podcastHipsters.AdicionarEpisodio(epHipster1);
    
    sistemaPodcasts.RegistrarPodcast(podcastHipsters);

}

// Metodo Auxiliar para converter a duração em segundos inteiros
int ConverterTempoParaSegundos(string duracaoString)
{
    {
        // Caso 1: Usuario digita no formato mm:ss
        if (duracaoString.Contains(":"))
        {
            string[] partes = duracaoString.Split(':'); // Quebrando a string em minutos e segundos

            // Tenta converter as duas partes para inteiros
            if (int.TryParse(partes[0], out int minutos) && int.TryParse(partes[1], out int segundos))
            {
                return minutos * 60 + segundos; // Retorna o total em segundos
            }
        }

        // Caso 2: Se não existir ":", tenta converter direto 
        else if (int.TryParse(duracaoString, out int minutosApenas))
        {
            return minutosApenas * 60; // Retorna o total em segundos
        }

        // se ele digitou "banana" ou algo inválido
        return 0;
    }
}

// Metodo para Exibir o Logo
void ExibirLogo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
    Console.WriteLine(mensagemDeBoasVindas); 
}


// Metodo para Exibir o Titulo da Opção
void ExibirTituloDaOpção(string titulol)
{
    int quantidadeDeLetras = titulol.Length;
    string asteristico = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteristico);
    Console.WriteLine(titulol);
    Console.WriteLine(asteristico + "\n");
}



#endregion

// Fim do arquivo Program.cs

#endregion