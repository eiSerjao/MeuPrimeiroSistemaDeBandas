namespace ScreanSound.Utilitários;

using ScreanSound;
using ScreanSound.Dominio;
using ScreanSound.Menu;
using ScreanSound.Infraestrutura;
using ScreanSound.Consulta;
using ScreanSound.Cadastro;
using ScreanSound.Utilitários;

public class VerificadorNulo
{
  // Verifica se a banda existe no sistema de bandas registradas
  public static bool VerificarBandaExiste(BandasRegistradas sistema, string nomeDaBanda)
  {
    Banda bandaEncontrada = sistema.RetornarBanda(nomeDaBanda);
    return bandaEncontrada != null;
  }

  // Verifica se uma string está nula ou vazia
  public static bool VerificarStringNulaOuVazia(string? texto)
  {
    return string.IsNullOrEmpty(texto);
  }
}
