using System.ComponentModel;

namespace PrimeiroProjeto;

public class BandasRegistradas
{
    // Dicionario para Armazenar as Bandas e suas notas
    private Dictionary<string, (Banda banda, List<int> notas)> _bandas = new Dictionary<string, (Banda banda, List<int>)>();
    
    // Dicionrario para Armazenar Generos Musicais no Sistema
    private Dictionary<string, Genero> _generos = new Dictionary<string, Genero>();
    
    // Metodo para Registrar uma Banda
    public void RegistrarBanda(Banda banda)
    {
        if (!_bandas.ContainsKey(banda.NomeDaBanda))
        {
            _bandas.Add(banda.NomeDaBanda, (banda, new List<int>()));
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
        return _bandas.ContainsKey(banda.NomeDaBanda);
    }

    // Metodo para Adicionar uma Nota a Banda
    public void AdicionarNota(Banda banda)
    {
        //Verifica se a banda existe no dicionário
        if (VerificaBanda(banda))
        {
            // Se a banda existe, adiciona a tupla da banda na variável registro
            var registro = _bandas[banda.NomeDaBanda];

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
                    registro.notas.Add(nota);
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

    // Métodos para Fazer a Média de Notas em Uma Banda
    public void ExibirMédiaNotas(Banda banda)
    {
        if (VerificaBanda(banda))
        {
            var registro = _bandas[banda.NomeDaBanda];

            if (registro.notas.Count > 0)
            {
                double media = registro.notas.Average();
                Console.WriteLine($"A média de notas da banda {banda.NomeDaBanda} é: {media:F2}");
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"A banda {banda.NomeDaBanda} não possui notas registradas.");
                Thread.Sleep(2000);
            }
        }
    }

    // Metodo para Listar as Bandas Registradas
    public void ExibirBandasRegistradas()
    {
        foreach (var banda in _bandas.Keys)
        {
            Console.WriteLine(banda);
        }
    }

    // fim da classe BandasRegistradas
    
    
}
