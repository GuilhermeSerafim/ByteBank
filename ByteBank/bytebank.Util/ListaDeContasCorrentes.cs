using bytebank.Modelos.Conta;

namespace ByteBank.bytebank.Util;

// classe que encapsula as operações sobre uma lista de contas correntes
public class ListaDeContasCorrentes
{
    private ContaCorrente[] _itens = null;
    private int _proxPosicaoArr = 0;
    public int Tamanho
    {
        get
        {
            return _proxPosicaoArr;
        }
    }
    // Indexando
    public ContaCorrente this[int indice]
    {
        get
        {
            return RecuperarContaIndice(indice);
        }
    }
    public ListaDeContasCorrentes(int tamanhoInicial = 5)
    {
        _itens = new ContaCorrente[tamanhoInicial];
    }
    public void Adicionar(ContaCorrente item)
    {
        Console.WriteLine($"Adicionando item na posição {_proxPosicaoArr}");
        VerificaCapacidade(_proxPosicaoArr + 1);
        _itens[_proxPosicaoArr] = item;
        _proxPosicaoArr++; // Esse cara sempre vai ter um à mais de acordo com a posições do nosso array
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

    public void Remover(ContaCorrente contaASerRemovida)
    {
        // Inicializando um variavel no excopo de fora, para usar em outro for
        int indiceItemASerRemovido = -1;
        // Localiza o índice da conta a ser removida
        for (int i = 0; i < _proxPosicaoArr; i++)
        {
            ContaCorrente ccAtual = _itens[i];
            if (ccAtual == contaASerRemovida)
            {
                indiceItemASerRemovido = i; // Atribuindo o indice, para a remoção
                break;
            }
        }

        // Se a conta não for encontrada, exibe uma mensagem e encerra o método (pois o 'indiceItemASerRemovido' não foi atribuido, logicamente não foi encontrado o indice, e ele continua no estado inicial {-1})
        if (indiceItemASerRemovido == -1)
        {
            Console.WriteLine("Conta não encontrada");
            return;
        }


        // Move os elementos à frente da conta removida para uma posição anterior no array
        for (int i = indiceItemASerRemovido; i < _proxPosicaoArr; ++i)
        {
            // Verifica se o próximo índice (i + 1) está dentro do limite atual do array.
            // Se não estiver, define a posição atual como null para limpar o último elemento.
            _itens[i] = (i + 1 >= _proxPosicaoArr) ? null : _itens[i + 1];
        }
        // Atualiza o índice da próxima posição DO ARRAY
        _proxPosicaoArr--;
    }
    public void ExibeLista()
    {
        for (int i = 0; i < _itens.Length; i++)
        {
            if (_itens[i] != null)
            {
                var conta = _itens[i];
                Console.WriteLine($" Indice[{i}] = " +
                    $"Conta: {conta.Conta} - " +
                    $"N° da Agência: {conta.Numero_agencia}");
            }
        }
        foreach (var item in _itens)
        {
            if (item != null)
                Console.WriteLine($"Índice[{item}]");
        }
    }

    public ContaCorrente RecuperarContaIndice(int indice)
    {
        if (indice < 0 || indice >= _proxPosicaoArr)
        {
            throw new ArgumentOutOfRangeException(nameof(indice));
        }
        return _itens[indice];
    }
}
