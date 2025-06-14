using PrimeiroProjeto;

string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";
//List<string> listaDasBandas = new List<string> { "U2", "Oficina G3", "Rosa de Saron"};

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Link Park", new List<int> { 10, 8, 7, 6});
bandasRegistradas.Add("Oficina G3", new List<int>());

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
    bandasRegistradas.Add(nomeDaBanda, new   List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep( 2000 );
    ExibirOpcoesDoMenu();
}

// Metodo para Mostrar as Bandas Registradas
void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpção("Exibindo todas as bandas registradas");
    //for (int i = 0; i < listaDasBandas.Count; i++)
    //{
    //    Console.WriteLine($"Banda: {listaDasBandas[i]}");
    //} 

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

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
    bool repetir = true;

    // Loop para repetir o processo de exibir a média
    while (repetir)
    {
        Console.Clear();
        ExibirTituloDaOpção("Exibindo a média de uma banda");

        // Variáveis para armazenar o nome da banda e verificar se a banda é válida
        string nomeDaBanda = "";
        bool bandaValida = false;
        bool repostaEhValida = false;


        // Loop para verificar se a banda existe e possui notas
        while (!bandaValida)
        {

            Console.Clear();
            ExibirTituloDaOpção("Exibindo a média de uma banda");
            Console.Write("Digite o nome da banda que deseja ver a média: ");
            nomeDaBanda = Console.ReadLine()!;

            // Verifica se a banda existe no dicionário
            if (bandasRegistradas.ContainsKey(nomeDaBanda))
            {
                // Verifica se a banda possui notas registradas
                if (bandasRegistradas[nomeDaBanda].Count > 0)
                {
                    bandaValida = true;
                    break;
                }
                else if (bandasRegistradas[nomeDaBanda].Count == 0) // Se a banda não possui notas registradas 
                {
                    // Exibe mensagem de erro e pergunta se deseja tentar novamente
                    while (!repostaEhValida)
                    {
                        Console.Clear();
                        Console.WriteLine($"\nA banda {nomeDaBanda} não possui notas registradas! ");
                        Console.WriteLine("Deseja tentar novamente? (s/n)");
                        string resposta = Console.ReadLine()!;
                        if (resposta.ToLower() == "n")
                        {
                            ExibirOpcoesDoMenu();
                            repostaEhValida = true;
                            return;
                        }
                        else if (resposta.ToLower() == "s")
                        {
                            repostaEhValida = false;
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Resposta inválida. Tente novamente.");
                            Thread.Sleep(2000);
                        }
                    }
                }
            }
            else // Se a banda não existe no dicionário
            {
                // Exibe mensagem de erro e pergunta se deseja tentar novamente
                {
                    while (!repostaEhValida)
                    {
                        Console.Clear();
                        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada! ");
                        Console.WriteLine("Deseja tentar novamente? (s/n)");
                        string resposta = Console.ReadLine()!;

                        if (resposta.ToLower() == "n")
                        {
                            ExibirOpcoesDoMenu();
                            repostaEhValida = true;
                            return;
                        }
                        else if (resposta.ToLower() == "s")
                        {
                            repostaEhValida = false;
                            ExibirMediaDaBanda();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Resposta inválida. Tente novamente.");
                            Thread.Sleep(2000);
                        }
                    }
                }



            }
        }

        // Se a banda existe e possui notas registradas
        // Calcula a média das notas
        List<int> notas = bandasRegistradas[nomeDaBanda];
        double media = notas.Average();
        Console.WriteLine($"A média da banda {nomeDaBanda} é {media}");
        Thread.Sleep(4000);
        
        repostaEhValida = false;

        // Pergunta se o usuário deseja ver outra banda
        while (!repostaEhValida)
        {
            Console.Clear();
            Console.WriteLine("Gostaria de ver outra banda? (s/n)");
            string respostaFinal = Console.ReadLine()!;

            if (respostaFinal.ToLower() == "n")
            {
                repetir = false;
                repostaEhValida = true;
                ExibirOpcoesDoMenu();
            }
            else if (respostaFinal.ToLower() == "s")
            {
                repostaEhValida = true;

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Resposta inválida. Tente novamente.");
                Thread.Sleep(2000);
            }
        }
    }
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
    //digite qual banda deseja avaliar
    //se a banda existe no dicionario >> atribuir uma nota
    //senão, volta ao menu principal
    Console.Clear();
    ExibirTituloDaOpção("Avaliar Banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual o nome que a banda {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\n A nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada! ");
        Console.WriteLine("Digite uma tecla para voltar ao menu prinicipal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

// Chama o Método Principal
//ExibirOpcoesDoMenu();


Musica musica1 = new Musica();

musica1.NomeDaMusica = "Roxanne";
musica1.Artista = "The Police";
musica1.Duracao = 200;
musica1.Disponivel = true;

musica1.ExibirFichaTecnica();

Console.WriteLine("-----------------------------------");

Musica musica2 = new Musica();
musica2.NomeDaMusica = "Incondicional";
musica2.Artista = "Oficina G3";
musica2.Duracao = 418;
musica2.Disponivel = false;

musica2.ExibirFichaTecnica();



