using ScreanSound.Dominio;
using ScreanSound.Menu;
using ScreanSound.Infraestrutura;
using ScreanSound.Consulta;
using ScreanSound.Cadastro;
using ScreanSound.Utilitários;

// --- CONFIGURAÇÃO INICIAL E VARIÁVEIS GLOBAIS ---
BandasRegistradas sistemaBandas = new BandasRegistradas();
PodcastsRegistrados sistemaPodcasts = new PodcastsRegistrados();

//carregar dados iniciais (mock)
InicializadorDados.CarregarDadosInicias(sistemaBandas, sistemaPodcasts);

// Utilitários


//Infraestrutura

MenuExibirOpcoes menuExibirOpcoes = new MenuExibirOpcoes(sistemaBandas, sistemaPodcasts);
menuExibirOpcoes.ExibirOpcoesDeConsulta();



























































// --------------------------------------------------------------------

