using bytebank.Modelos.Conta;

namespace ByteBank.bytebank.Util;

public class ListaDeContasCorrentes
{
    private ContaCorrente[] _itens = null;
    public ListaDeContasCorrentes(int tamanhoInicial)
    {
        _itens = new ContaCorrente[tamanhoInicial];
    }
    public void Adicionar(ContaCorrente item, int indice)
    {
        try
        {
            if (_itens[indice] != null)
            {
                Console.WriteLine($"Adicionando item na posicao {indice}");
                _itens[indice] = item;
            }
            else
            {
                Console.WriteLine($"Indice {indice} não encontrado");
            }

        }
        catch (IndexOutOfRangeException ex)
        {

            throw new ArgumentOutOfRangeException(nameof(indice), "Índice fora do intervalo da lista.");
        }

    }
}
