namespace PrimeiroProjeto;

public class Episodio
{
  // Propriedades
  public int Numero { get; set; }

  // Atributo required para garantir que o título seja fornecido
  public required string Titulo { get; set; }

  public int Duracao { get; set; }

  // Lista de convidados
  public List<string> convidados = new List<string>();

  // Propiedade Resumo
  public string Resumo => $"Episódio {Numero}: {Titulo} - Duração: {Duracao} minutos - Convidados: {string.Join(", ", convidados)}";

  // Método para adicionar convidados
  public void AdicionarConvidado(string nome)
  {
    convidados.Add(nome);
  }

}
