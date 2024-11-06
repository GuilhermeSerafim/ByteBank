using bytebank.Modelos.Conta;
using ByteBank;
using ByteBank.bytebank.Util;

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


Console.WriteLine("Bem vindo ao ByteBank");
new ByteBankAtendimento().AtendimentoCliente();