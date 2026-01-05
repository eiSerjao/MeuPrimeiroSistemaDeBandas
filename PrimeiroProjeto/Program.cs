using PrimeiroProjeto;

string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";

BandasRegistradas sistemaBandas = new BandasRegistradas();

// Metodo Principal para Exibir as Opções do Menu
void ExibirOpcoesDoMenu()
{
    Console.Clear();
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite 5 para Registrar um Novo Genero Musical");
    Console.WriteLine("Digite 6 para Registrar um Novo Álbum");
    Console.WriteLine("Digite 7 para Registrar uma Nova Música");
    Console.WriteLine("Digire -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            RegistrarBanda();
            break;
        case 2:
            MostrarBandasRegistradas();
            break;
        case 3:
            AvaliarUmaBanda();
            break;
        case 4:
            ExibirMediaDaBanda();
            break;
        case 5:
            RegistrarGenreroMusical();
            break;
        case 6:
            RegistrarAlbum();
            break;
        case 7:
            RegistrarMusica();
            break;
        case -1:
            Console.WriteLine("Você digitou a opção " + opcaoEscolhida);
            Console.WriteLine("Tchau tchau :)");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
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
        
    ExibirOpcoesDoMenu();
}

// Metodo para Registrar uma Banda
void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpção("Registros das bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    Banda novaBanda = new Banda(nomeDaBanda);
    sistemaBandas.RegistrarBanda(novaBanda);
    
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep( 2000 );
    ExibirOpcoesDoMenu();
}

// Metodo para Mostrar as Bandas Registradas
void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpção("Exibindo todas as bandas registradas");
    sistemaBandas.ExibirBandasRegistradas();
    Console.Write("\nDigite uma tecla para voltar ao menu principal: ");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
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
    ExibirOpcoesDoMenu();
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
    
    ExibirOpcoesDoMenu();
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
        Console.Write("Digite o nome do álbum: ");
        string nomeDoAlbum = Console.ReadLine()!.Trim();

        // Criamos o novo álbum
        Album novoAlbum = new Album(nomeDoAlbum);

        // Adicionamos o álbum à banda que foi recuperada
        bandaRecuperada.AdicionarAlbum(novoAlbum);
        Console.WriteLine($"Álbum '{nomeDoAlbum}' registrado com sucesso para a banda '{nomeDaBanda}'!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"Banda '{nomeDaBanda}' não encontrada. Por favor, registre a banda antes de adicionar um álbum.");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
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
        Console.WriteLine($"Banda '{nomeDaBanda}' não encontrada. Por favor, registre a banda antes de adicionar uma música.");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
        return; // Sai do método se a banda não existir
    }
    
    // 2. Buscar e Validar o Genero Musical

    Console.Write("Digite o nome do gênero musical da música: ");
    string nomeDoGenero = Console.ReadLine()!;
    Genero generoRecuperado = sistemaBandas.RetornarGenero(nomeDoGenero);

    // Logica para verificar se o Genero Musical Existe

    if (generoRecuperado == null) 
    {
        // Se o gênero não foi encontrado, o usuario pode optar por registrar um novo gênero ou sair
        // Aqui vou assumir que o usuário deve registrar o gênero primeiro
        Console.WriteLine($"Gênero '{nomeDoGenero}' não encontrado. Criando um novo....");
        generoRecuperado = new Genero(nomeDoGenero);
        sistemaBandas.RegistrarGenero(generoRecuperado, nomeDoGenero);
        Thread.Sleep(2000);
    }

    // 3. Coletar os Dados da Música

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

    Console.WriteLine($"Música '{nomeDaMusica}' registrada com sucesso para a banda '{nomeDaBanda}'!");
    Thread.Sleep(2000);

    // 5. Perguntar sobre o Álbum (opcional)
    Console.Clear();
    Console.Write("Deseja adicionar essa música a um álbum existente? (S/N): ");
    if (Console.ReadLine()!.Trim().ToUpper() == "S")
    {
        Console.Write("Digite o nome do álbum: ");
        string nomeDoAlbum = Console.ReadLine()!;

        Album albumRecuperado = bandaRecuperada.RetornarAlbumPeloNome(nomeDoAlbum);

        // Verifica se o álbum existe
        if (albumRecuperado != null)
        {
            albumRecuperado.AdicionarMusica(novaMusica);
            Console.WriteLine($"Música '{nomeDaMusica}' adicionada ao álbum '{nomeDoAlbum}' com sucesso!");
        }
        else
        {
            // Se caiu aqui, o álbum não foi encontrado ou foi digitado errado
            Console.WriteLine($"Álbum '{nomeDoAlbum}' não encontrado na banda '{nomeDaBanda}'. Música não adicionada a nenhum álbum.");
            Console.WriteLine("Você pode adicionar a música a um álbum posteriormente.");
        }
    }
    else
    {
        Console.WriteLine("Ok! A musica foi registrada sem álbum");
    }
    

    Thread.Sleep(2000);
    ExibirOpcoesDoMenu();

    // fim do método RegistrarMusica
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
    

// Chama o Método Principal
ExibirOpcoesDoMenu();



// // Criando um Obejto da Classe Banda
// Banda oficinaG3 = new Banda("Oficina G3");
// // Criando um novo objeto da classe Album
// Album albumDoOficinaG3 = new Album("Depois da Guerra");

// Genero Rock = new Genero("Rock");

// // Criando Objetos da Classe Musica
// Musica musica1 = new Musica(oficinaG3, "D.A.G", 62.4, true, Rock);

// Musica musica2 = new Musica(oficinaG3, "Meus Própios Meis", 241.2, false, Rock);


// // Adicionando os Objetos da Classe Musica a uma lista de um Objeto Especifico da Classe Album
//     // Utilizando um Método AdicionarMuscia para adicionar a Lista do Objeto Especifico da Classe Albim
//         albumDoOficinaG3.AdicionarMusica(musica1);
//         albumDoOficinaG3.AdicionarMusica(musica2);



// musica1.ExibirFichaTecnica();
// musica2.ExibirFichaTecnica();

//     // Exibindo as Musica Listada de um Objeto da Classe Album
//         albumDoOficinaG3.ExibirMusicasDoAlbum();



//     // Adicionando um Objeto da Classe Album em uma lista chamada Albums da Classe Banda
//         oficinaG3.AdicionarAlbum(albumDoOficinaG3);

//     // Exibindo a Lista Albums de um Obejto Da Classe Banda
//         oficinaG3.ExibirDiscofrafia();

// fim of Program.cs