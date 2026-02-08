namespace ScreanSound.Dominio;
using ScreanSound.Dominio;
using ScreanSound.Menu;
using ScreanSound.Infraestrutura;
using ScreanSound.Consulta;
using ScreanSound.Cadastro;
using ScreanSound.Utilitários;
public class Musica
{
    // Propriedades da classe Musica
    public string NomeDaMusica { get; }
    public Banda Artista { get; }
    public int Duracao { get; set; }
    public bool Disponivel { get; set; }
    public Genero TipoDeGenero { get; set; }
    public string DescricaoResumida =>
        $"A música '{NomeDaMusica}' pertence ao artista {Artista.NomeDaBanda}";

    // Cunstrutor
    public Musica(Banda banda, string nomeDaMusica, int duracao, bool disponivel, Genero genero)
    {
        Artista = banda;
        NomeDaMusica = nomeDaMusica;
        Duracao = duracao;
        Disponivel = disponivel;
        TipoDeGenero = genero;
    }

    // Metodo para exibir a ficha técnica da música
    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome da Musica: {NomeDaMusica}");
        Console.WriteLine($"Artista: {Artista.NomeDaBanda}");
        Console.WriteLine($"Duração: {Duracao} segundos");
        Console.WriteLine($"Disponível: {Disponivel}");
        Console.WriteLine($"Descrição Resumida: {DescricaoResumida}");
        if (Disponivel)
        {
            Console.WriteLine("Diponível no Plano");
        }
        else
        {
            Console.WriteLine("Adquira o Plano Plus+");
        }
    }
    
    // fim da classe Musica
}
