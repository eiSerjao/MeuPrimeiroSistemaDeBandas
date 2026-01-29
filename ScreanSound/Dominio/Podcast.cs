namespace ScreanSound.Dominio;

public class Podcast
{ 
  // Propriedades
  public String Nome { get; set; }
  public String Host { get; set; }
  
  // Lista Privada de Episodios
  private List<Episodio> Episodios = new List<Episodio>();
  
  // Propriedade TotalEpisodios utilizando expressão lambda para retornar a contagem de episódios
  public int TotalEpisodios => Episodios.Count;

  // Construtor
  public Podcast(string nome, string host){
    Nome = nome;
    Host = host;
  }

  // Método para adicionar episódios
  public void AdicionarEpisodio(Episodio episodio)
  {
    Episodios.Add(episodio);  
  }

  // Método para Exibir detalhes do podcast
  public void ExibirDetalhes()
  {
    Console.WriteLine($"Podcast: {Nome} apresentado por {Host}\n");

    // Ordenar episódios por número antes de exibir
    foreach (Episodio episodio in Episodios.OrderBy(e => e.Numero))
    {
      Console.WriteLine(episodio.Resumo);
    }

    Console.WriteLine($"\nEsse podcast tem um total de {TotalEpisodios} episódios.");
  }

}
