using ScreanSound.Dominio;
using ScreanSound.Menu;
using ScreanSound.Infraestrutura;
using ScreanSound.Consulta;
using ScreanSound.Cadastro;

// --- CONFIGURAÇÃO INICIAL E VARIÁVEIS GLOBAIS ---
string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";
BandasRegistradas sistemaBandas = new BandasRegistradas();
PodcastsRegistrados sistemaPodcasts = new PodcastsRegistrados();

// Carrega os dados de teste (Mock) antes de iniciar
CarregarDadosInicias();

// --- NOVO: Teste do Desafio Podcast
// TestarDesafioPodcast();

//Inicia o progama

MenuExibirOpcoes menuExibirOpcoes = new MenuExibirOpcoes();
menuExibirOpcoes.ExibirOpcoesDeConsulta();


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
    banda1.AdicionarNota(banda1, 10);
    banda1.AdicionarNota(banda1, 8);
    banda1.AdicionarNota(banda1, 9);

    Album album1 = new Album("Abbey Road");
    Musica musica1 = new Musica(banda1, "Come Together", 259, true, new Genero("Rock"));
    Musica musica2 = new Musica(banda1, "Something", 182, true, new Genero("Rock"));
    album1.AdicionarMusica(musica1);
    album1.AdicionarMusica(musica2);
    banda1.AdicionarAlbum(album1);
    sistemaBandas.RegistrarBanda(banda1);

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
    banda2.AdicionarNota(banda2, 9); // Nota depois
    banda2.AdicionarNota(banda2, 10);

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
    banda3.AdicionarNota(banda3, 10); // Nota depois
    banda3.AdicionarNota(banda3, 10); // Oficina merece 10 rsrs

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

