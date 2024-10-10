using bytebank.Modelos.Conta;

namespace ByteBank.bytebank.Util;

// classe que encapsula as operações sobre uma lista de contas correntes
public class ListaDeContasCorrentes
{
    private ContaCorrente[] _itens = null;
    private int _posicaoAtual = 0;
    public ListaDeContasCorrentes(int tamanhoInicial = 5)
    {
        _itens = new ContaCorrente[tamanhoInicial];
    }
    public void Adicionar(ContaCorrente item)
    {
        Console.WriteLine($"Adicionando item na posição {_posicaoAtual}");
        VerificaCapacidade(_posicaoAtual + 1);
        _itens[_posicaoAtual] = item;
        _posicaoAtual++;
    }

    public ContaCorrente? RetornaMaiorSaldoContaCorrente()
    {
        double maiorSaldo = 0;
        ContaCorrente? ccMaiorSaldo = null;

        for (int i = 0; i < _itens.Length; i++)
        {
            if (maiorSaldo < _itens[i].Saldo)
            {
                maiorSaldo = _itens[i].Saldo;
                ccMaiorSaldo = _itens[i];
            }
        }
        return ccMaiorSaldo ?? null;
    }

    private void VerificaCapacidade(int tamanhoNecessario)
    {
        if (_itens.Length >= tamanhoNecessario)
        {
            return; // faço nada
        }
        ContaCorrente[] nvArr = new ContaCorrente[tamanhoNecessario];
        // Clonagem
        for (int i = 0; _itens.Length > i; i++)
        {
            nvArr[i] = _itens[i];
        }
        int accCapacidadeAumentada = 0;
        foreach (var item in nvArr)
        {
            if (item == null)
            {
                accCapacidadeAumentada++;
            }
        }
        Console.WriteLine($"Aumentando capacidade da lista em {accCapacidadeAumentada}");
        _itens = nvArr;
    }
}
