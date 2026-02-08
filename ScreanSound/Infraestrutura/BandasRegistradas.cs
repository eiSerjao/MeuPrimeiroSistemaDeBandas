using System.ComponentModel;
using ScreanSound.Dominio;
using ScreanSound.Menu;
using ScreanSound.Infraestrutura;
using ScreanSound.Consulta;
using ScreanSound.Cadastro;

namespace ScreanSound.Infraestrutura;

public class BandasRegistradas
{
    // Dicionario para Armazenar as Bandas
    private Dictionary<string, Banda> bandasRegistradas = new();
    
    // Dicionrario para Armazenar Generos Musicais no Sistema
    private Dictionary<string, Genero> _generos = new Dictionary<string, Genero>();
    
    // Metodo para Registrar uma Banda
    public void RegistrarBanda(Banda banda)
    {
        if (!bandasRegistradas.ContainsKey(banda.NomeDaBanda))
        {
            bandasRegistradas.Add(banda.NomeDaBanda, banda);
        }
    }
    
    //Metodo para Registra um Genero
    public bool RegistrarGenero(Genero genero, string chave)
    {
        if (!VerificarGenero(chave))
        {
            _generos.Add(chave, genero);
            Console.WriteLine($"O Genero: {chave} foi adicionado ao sistema!");
            Thread.Sleep(2000);
            return true;
        }
        else
        {
            Console.WriteLine($"Já existe {chave} em nosso sistema!");
            Thread.Sleep(2000);
            return false;
        }
    }
    
    // Verificar se o Genero estar Registrado no Sistema.
    public bool VerificarGenero(string chave)
    {
        return _generos.ContainsKey(chave);
    }

    // Metodo para Verificar se a Banda Existe no Dicionario
    public bool VerificaBanda(Banda banda)
    {
        // estar com erro aqui
        return bandasRegistradas.ContainsKey(banda.NomeDaBanda);
    }

    // Metodo para Adicionar uma Nota a Banda
    public void AdicionarNota(Banda banda)
    {
        //Verifica se a banda existe no dicionário
        if (VerificaBanda(banda))
        {
            // Se a banda existe, adiciona a tupla da banda na variável registro
            var registro = bandasRegistradas[banda.NomeDaBanda];

            // O progama encerrar quando a nota for valida entre 0 e 10
            bool notaValida = false;

            // Loop para validar a nota
            while (!notaValida)
            {
                Console.WriteLine("Digite a nota (0-10)");
                string notaInput = Console.ReadLine()!;
                int nota = int.Parse(notaInput);

                // Verifica se a nota está entre 0 e 10
                if (nota >= 0 && nota <= 10)
                {
                    // se a nota for valida, adiciona a nota na lista de notas da banda
                    registro.AdicionarNota(banda, nota);
                    Console.WriteLine($"Nota {nota} registrada para a banda {banda.NomeDaBanda}");

                    // Atualiza a variável notaValida para sair do loop
                    notaValida = true;
                }
                else
                {
                    // Se a nota não for valida, exibe uma mensagem de erro e reinicia o loop
                    Console.WriteLine("Nota inválida. Deve ser entre 0 e 10.");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
        }


    }

    
    public void ExibirMédiaNotas(Banda banda)
    {
        if (VerificaBanda(banda))
        {
            var registro = bandasRegistradas[banda.NomeDaBanda];
            int quantidadeNotas = registro.ObterQuantidadeNotas();

            if (quantidadeNotas == 0)
            {
                Console.WriteLine($"A banda {banda.NomeDaBanda} ainda não possui notas registradas.");
            }
            else
            {
                // Calcula a média das notas
                int somaNotas = 0;
                for (int i = 0; i < quantidadeNotas; i++)
                {
                    somaNotas += registro.Notas[i];
                }
                double media = (double)somaNotas / quantidadeNotas;

                Console.WriteLine($"A média das notas da banda {banda.NomeDaBanda} é: {media:F2}");
            }
        }
    }

    // Metodo para Listar as Bandas Registradas
    public void ExibirBandasRegistradas()
    {
        foreach (var banda in bandasRegistradas.Values)
        {
            Console.WriteLine($"- {banda.NomeDaBanda}");
        }
        Console.WriteLine();
    }
    // Metodo para Retornar uma Banda pelo Nome
    public Banda RetornarBanda(string nomeDaBanda)
    {
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            return bandasRegistradas[nomeDaBanda];
        }
        return null!;
    }
    
    // Método para Retornar um Genero pelo Nome
    public Genero RetornarGenero(string nomeDoGenero)
    {
        if (_generos.ContainsKey(nomeDoGenero))
        {
            return _generos[nomeDoGenero];
        }
        return null!;
    }
    
    

}
