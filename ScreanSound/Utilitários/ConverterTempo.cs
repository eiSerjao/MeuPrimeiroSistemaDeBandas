namespace ScreanSound.Utilitários;

using ScreanSound.Dominio;
using ScreanSound.Menu;
using ScreanSound.Infraestrutura;
using ScreanSound.Consulta;
using ScreanSound.Cadastro;

public class ConverterTempo
{
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
}
