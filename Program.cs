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
        case -1:
            Console.WriteLine("Você digitou a opção " + opcaoEscolhida);
            Console.WriteLine("Tchau tchau :)");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
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
    // bool repetir = true;

    // // Loop para repetir o processo de exibir a média
    // while (repetir)
    // {
    //     Console.Clear();
    //     ExibirTituloDaOpção("Exibindo a média de uma banda");

    //     // Variáveis para armazenar o nome da banda e verificar se a banda é válida
    //     string nomeDaBanda = "";
    //     bool bandaValida = false;
    //     bool repostaEhValida = false;


    //     // Loop para verificar se a banda existe e possui notas
    //     while (!bandaValida)
    //     {

    //         Console.Clear();
    //         ExibirTituloDaOpção("Exibindo a média de uma banda");
    //         Console.Write("Digite o nome da banda que deseja ver a média: ");
    //         nomeDaBanda = Console.ReadLine()!;

    //         sistemaBandas.BandaExiste(nomeDaBanda);

    //         // Verifica se a banda existe no dicionário
    //         if (bandaEncontrada != null)
    //         {
    //             // Verifica se a banda possui notas registradas
    //             if (sistemaBandas.Bandas[bandaEncontrada].Count > 0)
    //             {
    //                 bandaValida = true;
    //                 break;
    //             }
    //             else if (sistemaBandas.Bandas[bandaEncontrada].Count == 0) // Se a banda não possui notas registradas 
    //             {
    //                 // Exibe mensagem de erro e pergunta se deseja tentar novamente
    //                 while (!repostaEhValida)
    //                 {
    //                     Console.Clear();
    //                     Console.WriteLine($"\nA banda {nomeDaBanda} não possui notas registradas! ");
    //                     Console.WriteLine("Deseja tentar novamente? (s/n)");
    //                     string resposta = Console.ReadLine()!;
    //                     if (resposta.ToLower() == "n")
    //                     {
    //                         ExibirOpcoesDoMenu();
    //                         repostaEhValida = true;
    //                         return;
    //                     }
    //                     else if (resposta.ToLower() == "s")
    //                     {
    //                         repostaEhValida = false;
    //                         break;
    //                     }
    //                     else
    //                     {
    //                         Console.Clear();
    //                         Console.WriteLine("Resposta inválida. Tente novamente.");
    //                         Thread.Sleep(2000);
    //                     }
    //                 }
    //             }
    //         }
    //         else // Se a banda não existe no dicionário
    //         {
    //             // Exibe mensagem de erro e pergunta se deseja tentar novamente
    //             {
    //                 while (!repostaEhValida)
    //                 {
    //                     Console.Clear();
    //                     Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada! ");
    //                     Console.WriteLine("Deseja tentar novamente? (s/n)");
    //                     string resposta = Console.ReadLine()!;

    //                     if (resposta.ToLower() == "n")
    //                     {
    //                         ExibirOpcoesDoMenu();
    //                         repostaEhValida = true;
    //                         return;
    //                     }
    //                     else if (resposta.ToLower() == "s")
    //                     {
    //                         repostaEhValida = false;
    //                         ExibirMediaDaBanda();
    //                         break;
    //                     }
    //                     else
    //                     {
    //                         Console.Clear();
    //                         Console.WriteLine("Resposta inválida. Tente novamente.");
    //                         Thread.Sleep(2000);
    //                     }
    //                 }
    //             }



    //         }
    //     }

    //     // // Se a banda existe e possui notas registradas
    //     // // Calcula a média das notas
    //     // List<int> notas = bandasRegistradas[nomeDaBanda];
    //     // double media = notas.Average();
    //     // Console.WriteLine($"A média da banda {nomeDaBanda} é {media}");
    //     // Thread.Sleep(4000);

    //     repostaEhValida = false;

    //     // Pergunta se o usuário deseja ver outra banda
    //     while (!repostaEhValida)
    //     {
    //         Console.Clear();
    //         Console.WriteLine("Gostaria de ver outra banda? (s/n)");
    //         string respostaFinal = Console.ReadLine()!;

    //         if (respostaFinal.ToLower() == "n")
    //         {
    //             repetir = false;
    //             repostaEhValida = true;
    //             ExibirOpcoesDoMenu();
    //         }
    //         else if (respostaFinal.ToLower() == "s")
    //         {
    //             repostaEhValida = true;

    //         }
    //         else
    //         {
    //             Console.Clear();
    //             Console.WriteLine("Resposta inválida. Tente novamente.");
    //             Thread.Sleep(2000);
    //         }
    //     }
    // }
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