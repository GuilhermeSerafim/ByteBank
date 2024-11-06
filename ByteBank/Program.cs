using bytebank.Modelos.Conta;
using ByteBank.bytebank.Exceptions;
using ByteBank.bytebank.Util;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;

#region Aulas e Exemplos
void TestaArrayInt()
{
    int[] idades = new int[5];
    idades[0] = 20;
    idades[1] = 30;
    idades[2] = 40;
    idades[3] = 50;
    idades[4] = 60;

    Console.WriteLine($"Tamanho do Array {idades.Length}");

    int totaldeNotas = 0;
    for (int i = 0; i < idades.Length; i++)
    {
        int idade = idades[i];
        Console.WriteLine($"Índice [{i}] = {idade}");
        totaldeNotas += idade;
    }

    int media = totaldeNotas / idades.Length;
    Console.WriteLine("Média: " + media);
}
void TestaBuscarPalavra()
{
    string[] arrayDePalavras = new string[5];
    for (int i = 0; i < arrayDePalavras.Length; i++)
    {
        Console.WriteLine($"Digite uma palavra");
        arrayDePalavras[i] = Console.ReadLine()!;

    }

    Console.WriteLine("Digite a palavra a ser encontrada: ");
    var busca = Console.ReadLine();
    foreach (string s in arrayDePalavras)
    {
        if (s.Equals(busca))
        {
            Console.WriteLine($"A palavra é {s}");
            break;
        }
        else
        {
            Console.WriteLine("Palavra não encontrada");
        }
    }
}

void TestaMediana(Array arr)
{
    if (arr == null || arr.Length == 0)
    {
        Console.WriteLine("Array para calculo está vazio ou nulo.");
        return;
    }

    double[] numerosOrdenados = (double[])arr.Clone(); // Casting
    Array.Sort(numerosOrdenados);
    int meioArr = numerosOrdenados.Length / 2;
    double mediana = numerosOrdenados.Length % 2 != 0
        ? numerosOrdenados[meioArr]
        : (numerosOrdenados[meioArr] + numerosOrdenados[meioArr - 1]) / 2;
    Console.WriteLine($"Com base na amostra, a mediana é = {mediana}");
}
void TestaArrDeContasCorrentes()
{
    ContaCorrente[] arrContas = new ContaCorrente[]
    {
        new ContaCorrente(111),
        new ContaCorrente(222),
        new ContaCorrente(333)
    };

    for (int i = 0; i < arrContas.Length; i++)
    {
        ContaCorrente cAtual = arrContas[i];
        Console.WriteLine($"Índice {i} - Conta {cAtual.Conta}");
    }
}

void TestaListaDeContasCorrentesUtil()
{
    ListaDeContasCorrentes listaCC = new(); // Posição default 5
    listaCC.Adicionar(new ContaCorrente(111));
    listaCC.Adicionar(new ContaCorrente(222));
    listaCC.Adicionar(new ContaCorrente(333));
    listaCC.Adicionar(new ContaCorrente(444));
    listaCC.Adicionar(new ContaCorrente(555));
    listaCC.Adicionar(new ContaCorrente(666));
    Console.WriteLine(listaCC);
}


void TestaRemoverConta()
{
    ListaDeContasCorrentes listaCC = new(); // Posição default 5
    listaCC.Adicionar(new ContaCorrente(111)
    {
        Saldo = 1100.10,
        Nome_Agencia = "Nubank",
    });
    listaCC.Adicionar(new ContaCorrente(222)
    {
        Saldo = 1200.10,
        Nome_Agencia = "Nubank"
    });
    var contaDoGui = new ContaCorrente(712) { Nome_Agencia = "PagBank" };
    listaCC.Adicionar(contaDoGui);
    listaCC.Adicionar(new ContaCorrente(222)
    {
        Saldo = 1900.10,
        Nome_Agencia = "Nubank"
    });
    listaCC.ExibeLista();
    Console.WriteLine("===========");
    listaCC.Remover(contaDoGui);
    listaCC.ExibeLista();
}

void TesteClasseIndexada()
{
    ListaDeContasCorrentes listaCC = new(); // Posição default 5
    listaCC.Adicionar(new ContaCorrente(111)
    {
        Saldo = 1100.10,
        Nome_Agencia = "Nubank",
    });
    listaCC.Adicionar(new ContaCorrente(222)
    {
        Saldo = 1200.10,
        Nome_Agencia = "Nubank"
    });
    var contaDoGui = new ContaCorrente(712) { Nome_Agencia = "PagBank" };
    listaCC.Adicionar(contaDoGui);
    listaCC.Adicionar(new ContaCorrente(234)
    {
        Saldo = 1900.10,
        Nome_Agencia = "Nubank"
    });
    listaCC.Adicionar(new ContaCorrente(345)
    {
        Saldo = 1900.10,
        Nome_Agencia = "Nubank"
    });
    listaCC.Adicionar(new ContaCorrente(678)
    {
        Saldo = 1900.10,
        Nome_Agencia = "Nubank"
    });
    listaCC.Adicionar(new ContaCorrente(541)
    {
        Saldo = 1900.10,
        Nome_Agencia = "Nubank"
    });
    listaCC.Adicionar(new ContaCorrente(321)
    {
        Saldo = 1900.10,
        Nome_Agencia = "Nubank"
    });
    for (int i = 0; i < listaCC.Tamanho; i++)
    {
        ContaCorrente conta = listaCC[i];
        Console.WriteLine($"Índice [{i}] = {conta.Conta} | {conta.Numero_agencia}");
    }
}

#endregion

#region Desafios
void Desafio1()
{
    double[] amostra = new double[5];
    for (int i = 0; i < amostra.Length; i++)
    {
        amostra[i] = new Random().Next(1, 11);
    }
    Console.WriteLine("Bem vindo ao Byte Bank");
    double CalcularMedia(double[] numeros)
    {
        if ((numeros == null) || (numeros.Length == 0))
        {
            Console.WriteLine("Amostra de dados nula ou vazia.");
            return 0;
        }
        double media;
        double acc = 0;
        for (int i = 0; i < numeros.Length; i++)
        {
            acc += numeros[i];
        }
        media = acc / numeros.Length;
        return media;
    }
    var media = CalcularMedia(amostra);
    Console.WriteLine("Média: " + media);
}


void Desafio2()
{
    ListaDeContasCorrentes listaCC = new(); // Posição default 5
    listaCC.Adicionar(new ContaCorrente(111) { Saldo = 1100.10 });
    listaCC.Adicionar(new ContaCorrente(222) { Saldo = 1200.10 });
    listaCC.Adicionar(new ContaCorrente(333) { Saldo = 1300.10 });
    listaCC.Adicionar(new ContaCorrente(444) { Saldo = 1400.10 });
    listaCC.Adicionar(new ContaCorrente(555) { Saldo = 1500.10 });
    listaCC.Adicionar(new ContaCorrente(666) { Saldo = 1600.10 });
    var ccMaiorValor = listaCC.RetornaMaiorSaldoContaCorrente();
    if (ccMaiorValor != null)
    {
        Console.WriteLine($"Conta com maior valor: {ccMaiorValor.Conta} - Valor: R$ {ccMaiorValor.Saldo}");
    }
    else
    {
        Console.WriteLine("Informe contas com saldo!");
    }
}

void Desafio3()
{
    List<string> nomesDosEscolhidos = new List<string>()
    {
        "Bruce Wayne",
        "Carlos Vilagran",
        "Richard Grayson",
        "Bob Kane",
        "Will Farrel",
        "Lois Lane",
        "General Welling",
        "Perla Letícia",
        "Uxas",
        "Diana Prince",
        "Elisabeth Romanova",
        "Anakin Wayne"
    };
    for (int i = 0; nomesDosEscolhidos.Count > 0; i++)
    {
        if (nomesDosEscolhidos[i] == "Anakin Wayne")
        {
            Console.WriteLine($"O nome {nomesDosEscolhidos[i]} existe no arr!");
            break;
        }
    }
}
bool Desafio4(List<string> nomesDosEscolhidos, string escolhido)
{
    return nomesDosEscolhidos.Contains(escolhido);
}

void Desafio5()
{
    SortedList<int, string> times = new SortedList<int, string>();
    times.Add(0, "Flamengo");
    times.Add(2, "Santos");
    times.Add(1, "Juventus");

    foreach (var item in times.Values)
    {
        Console.WriteLine(item);
    }
}
#endregion

#region Introduzindo Generics
//Generica<int> teste1 = new();
//teste1.MostrarMensagem(2);
//Generica<string> teste2 = new();
//teste2.MostrarMensagem("Olá, mundo!");
//Generica<bool> teste3 = new();
//teste3.MostrarMensagem(true);
//public class Generica<T>
//{
//    public void MostrarMensagem(T t)
//    {
//        Console.WriteLine($"Exibindo {t}");
//    }
//}
#endregion


void ApredendoSobreList()
{
    // Destrinchando + o List<T>
    List<ContaCorrente> _listaCC = new()
    {
        new ContaCorrente(111) { Numero_agencia = 1, Conta = "AAA" },
        new ContaCorrente(222) { Numero_agencia = 2, Conta = "BBB" },
        new ContaCorrente(333) { Numero_agencia = 3, Conta = "CCC" },
    };
    List<ContaCorrente> _listaCC2 = new()
    {
        new ContaCorrente(444) { Numero_agencia = 4, Conta = "DDD" },
        new ContaCorrente(555) { Numero_agencia = 5, Conta = "EEE" },
        new ContaCorrente(666) { Numero_agencia = 6, Conta = "FFF" },
    };
    List<ContaCorrente> _listaCC3 = new()
    {
        new ContaCorrente(777) { Numero_agencia = 7, Conta = "GGG" },
        new ContaCorrente(888) { Numero_agencia = 8, Conta = "HHH" },
        new ContaCorrente(999) { Numero_agencia = 9, Conta = "III" },
    };
    // Adicionando depois do ultimo elemento, uma collection com novos itens, totalizando 6 itens 
    _listaCC2.AddRange(_listaCC3);
    //for (int i = 0; i < _listaCC2.Count; i++)
    //{
    //    Console.WriteLine($"Indice[{i}] = Conta [{_listaCC2[i].Conta}]");
    //}

    //// Cria outra lista de acordo com o range especificado (i, count)
    //var shadowList = _listaCC.GetRange(0, 2);
    //for(int i = 0; i < shadowList.Count; i++)
    //{
    //    Console.WriteLine($"Indice[{i}] = Conta [{shadowList[i].Conta}]");
    //}


    // Exibindo lista revertida
    _listaCC2.Reverse();
    for (int i = 0; i < _listaCC2.Count; i++)
    {
        Console.WriteLine($"Indice[{i}] = Conta [{_listaCC2[i].Conta}]");
    }

}

// Representa uma lista fortemente tipada de objetos que podem ser acessados pelo índice. Fornece métodos para pesquisar, classificar e manipular listas.
List<ContaCorrente> _listaDeContas = new() {
    new ContaCorrente(93) { Numero_agencia=2, Saldo=100, Titular = new Cliente{Cpf = "11111", Nome = "Gui"} },
    new ContaCorrente(95) { Numero_agencia=2, Saldo=60, Titular = new Cliente{Cpf = "22222", Nome = "Isa"} },
    new ContaCorrente(94) { Numero_agencia=3, Saldo =200, Titular = new Cliente{Cpf = "33333", Nome = "Miguel" } },
};

void ListarContas()
{
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("===     LISTA DE CONTAS     ===");
    Console.WriteLine("===============================");
    Console.WriteLine("\n");
    if (_listaDeContas.Count <= 0)
    {
        Console.WriteLine("... Não há contas cadastradas! ...");
        Console.ReadKey();
        Console.ReadKey();
        return;
    }
    foreach (ContaCorrente item in _listaDeContas)
    {
        Console.WriteLine("===  Dados da Conta  ===");

        Console.WriteLine(item.ToString());
        Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        Console.ReadKey();
    }
}

void CadastrarConta()
{
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("===   CADASTRO DE CONTAS    ===");
    Console.WriteLine("===============================");
    Console.WriteLine("\n");
    Console.WriteLine("=== Informe dados da conta ===");
    Console.Write("Número da conta: ");
    string numeroConta = Console.ReadLine();

    Console.Write("Número da Agência: ");
    int numeroAgencia = int.Parse(Console.ReadLine());

    ContaCorrente conta = new ContaCorrente(numeroAgencia);

    Console.Write("Informe o saldo inicial: ");
    conta.Saldo = double.Parse(Console.ReadLine());

    Console.Write("Informe nome do Titular: ");
    conta.Titular.Nome = Console.ReadLine();

    Console.Write("Informe CPF do Titular: ");
    conta.Titular.Cpf = Console.ReadLine();

    Console.Write("Informe Profissão do Titular: ");
    conta.Titular.Profissao = Console.ReadLine();

    _listaDeContas.Add(conta);
    //_listaDeContas.Add("sdjda"); // Não irá funcionar, pois tipamos a lista
    Console.WriteLine("... Conta cadastrada com sucesso! ...");
    Console.ReadKey();
}


void AtendimentoCliente()
{
    try
    {
        for (char opcao = '0'; opcao != '6';)
        {
            Console.WriteLine("Teste");
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===       Atendimento       ===");
            Console.WriteLine("===1 - Cadastrar Conta      ===");
            Console.WriteLine("===2 - Listar Contas        ===");
            Console.WriteLine("===3 - Remover Conta        ===");
            Console.WriteLine("===4 - Ordenar Contas       ===");
            Console.WriteLine("===5 - Pesquisar Conta      ===");
            Console.WriteLine("===6 - Sair do Sistema      ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n\n");
            Console.Write("Digite a opção desejada: ");
            try
            {
                opcao = Console.ReadLine()[0];
            }
            catch (Exception e)
            {
                // Lança uma nova exceção do tipo ByteBankException, usando a mensagem de erro da exceção original.
                throw new ByteBankException(e.Message);
            }
            switch (opcao)
            {
                case '1':
                    CadastrarConta();
                    break;
                case '2':
                    ListarContas();
                    break;
                case '3':
                    RemoverContas();
                    break;
                case '4':
                    OrdenarContas();
                    break;
                case '5':
                    PesquisarContas();
                    break;
                case '6':
                    Console.WriteLine("Encerrando... ");
                    break;

                default:
                    Console.WriteLine("Opção não implementada.");
                    break;
            }
        }

    }
    catch (ByteBankException e)
    {
        Console.WriteLine($"{e.Message}");
    }
}


void RemoverContas()
{
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("===      REMOVER CONTAS     ===");
    Console.WriteLine("===============================");
    Console.WriteLine("\n");
    Console.Write("Informe o número da Conta: ");
    string numeroConta = Console.ReadLine();
    ContaCorrente conta = null;
    foreach (var ccASerRemovida in _listaDeContas)
    {
        if (ccASerRemovida.Conta.Equals(numeroConta))
        {
            conta = ccASerRemovida;
        }
    }
    if (conta != null)
    {
        _listaDeContas.Remove(conta);
        Console.WriteLine("... Conta removida da lista! ...");
    }
    else
    {
        Console.WriteLine(" ... Conta para remoção não encontrada ...");
    }
    Console.ReadKey();
}
void OrdenarContas()
{
    // Aqui vai dar um erro, pois não conseguimos comparar 2 elementos no arr
    _listaDeContas.Sort();
    Console.WriteLine("... Lista de contas ordenada ...");
    Console.ReadKey();
}

void PesquisarContas()
{
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("===    PESQUISAR CONTAS     ===");
    Console.WriteLine("===============================");
    Console.WriteLine("\n");
    Console.Write("Deseja pesquisar por (1) NUMERO DA CONTA ou (2)CPF TITULAR ou (3) Nº AGÊNCIA ");
    switch (int.Parse(Console.ReadLine()))
    {
        case 1:
            {
                do
                {
                    Console.WriteLine("Informe o número da Conta: ");
                    string _nConta = Console.ReadLine();
                    ContaCorrente? consultaConta = ConsultaPorNumeroConta(_nConta);
                    Console.WriteLine(consultaConta != null ? consultaConta.ToString() : "Conta não encontrada");
                    Console.ReadKey();
                    if (_nConta != null && consultaConta != null)
                    {
                        break;
                    }
                } while (true);
                break;
            }
        case 2:
            {
                Console.WriteLine("Informe o CPF titular");
                string _cpf = Console.ReadLine()!;
                ContaCorrente? consultaCpf = ConsultaPorCpfTitular(_cpf);
                Console.WriteLine(consultaCpf != null ? consultaCpf.ToString() : "Conta não encontrada");
                Console.ReadKey();
                break;
            }
        case 3:
            {
                Console.WriteLine("Informe o número da agência");
                int _nAgencia = int.Parse(Console.ReadLine());
                var contasPorAgencia = ConsultaPorAgencia(_nAgencia);
                ExibirListaContas(contasPorAgencia);
                Console.ReadKey();
                break;
            }
        default:
            {
                Console.WriteLine("Opção não implementada");
                break;
            }
    }
}

void ExibirListaContas(List<ContaCorrente> contasPorAgencia)
{
    if (contasPorAgencia == null)
    {
        Console.WriteLine("Não há contas para serem exibidas...");
        return;
    }
    foreach (var item in contasPorAgencia)
    {
        Console.WriteLine(item.ToString());
    }
}

List<ContaCorrente> ConsultaPorAgencia(int nAgencia)
{
  //  LINQ(Language Integrated Query) é uma funcionalidade do C# para realizar consultas e manipulações de dados
    return (
                from conta in _listaDeContas
                where conta.Numero_agencia == nAgencia
                select conta
            ).ToList();
}

ContaCorrente? ConsultaPorCpfTitular(string cpf) => _listaDeContas.Where(conta => conta.Titular.Cpf == cpf).FirstOrDefault();
ContaCorrente? ConsultaPorNumeroConta(string? nConta) => _listaDeContas.Where(conta => conta.Conta == nConta).FirstOrDefault();

AtendimentoCliente();
