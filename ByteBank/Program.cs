﻿using bytebank.Modelos.Conta;
using ByteBank.bytebank.Util;
using System.Numerics;
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

void TestaArrDeContasCorrentesUtil()
{
    ListaDeContasCorrentes listaCC = new(); // Posição default 5
    listaCC.Adicionar(new ContaCorrente(111));
    listaCC.Adicionar(new ContaCorrente(222));
    listaCC.Adicionar(new ContaCorrente(333));
    listaCC.Adicionar(new ContaCorrente(444));
    listaCC.Adicionar(new ContaCorrente(555));
    listaCC.Adicionar(new ContaCorrente(666));
}
TestaArrDeContasCorrentesUtil();