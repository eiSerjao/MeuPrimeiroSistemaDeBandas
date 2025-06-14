namespace PrimeiroProjeto;

public class Musica
{
    // Propriedades da classe Musica
    public string NomeDaMusica { get; set; }
    public string Artista  { get; set;}
    public int Duracao { get; set;} // 
    public bool Disponivel {get; set;}
    public string DescricaoResumida => $"A música '{NomeDaMusica}' pertence ao artista {Artista}";
    
    // Metodo para exibir a ficha técnica da música
    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome da Musica: {NomeDaMusica}");
        Console.WriteLine($"Artista: {Artista}");
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
}
