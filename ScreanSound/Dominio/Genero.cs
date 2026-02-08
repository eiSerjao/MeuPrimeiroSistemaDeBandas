namespace ScreanSound.Dominio;

using ScreanSound.Dominio;
using ScreanSound.Menu;
using ScreanSound.Infraestrutura;
using ScreanSound.Consulta;
using ScreanSound.Cadastro;
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
