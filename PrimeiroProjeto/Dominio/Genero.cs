namespace PrimeiroProjeto.Dominio;

public class Genero
{
    
    // Propriedade TipoDeGenero
    public string TipoDeGenero { get; set; }

    // Construtor do Gênero Musical
    public Genero(string nome)
    {
        TipoDeGenero = nome;
    }
    // fim da classe Genero
}
