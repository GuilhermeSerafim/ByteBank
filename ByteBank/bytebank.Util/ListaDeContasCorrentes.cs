using bytebank.Modelos.Conta;

namespace ByteBank.bytebank.Util;

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
            if(item == null)
            {
                accCapacidadeAumentada++;
            }
        }
        Console.WriteLine($"Aumentando capacidade da lista em {accCapacidadeAumentada}");
        _itens = nvArr;
    }
}
