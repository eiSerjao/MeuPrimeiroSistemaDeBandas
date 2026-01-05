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
        string nomeDoAlbum = Console.ReadLine()!;

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