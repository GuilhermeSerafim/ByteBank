using ByteBank.bytebank.Exceptions;
using bytebank.Modelos.Conta;

namespace ByteBank;

public class ByteBankAtendimento
{
    private List<ContaCorrente> _contas = new() {
    new ContaCorrente(93) { Numero_agencia=2, Saldo=100, Titular = new Cliente{Cpf = "11111", Nome = "Gui", Profissao = "Empreendedor"} },
    new ContaCorrente(95) { Numero_agencia=2, Saldo=60, Titular = new Cliente{Cpf = "22222", Nome = "Isa", Profissao = "Programador"} },
    new ContaCorrente(94) { Numero_agencia=3, Saldo =200, Titular = new Cliente{Cpf = "33333", Nome = "Miguel", Profissao = "Engenheiro de Segurança" } },
};

    public void AtendimentoCliente()
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

    private void ListarContas()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===     LISTA DE CONTAS     ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");
        if (_contas.Count <= 0)
        {
            Console.WriteLine("... Não há contas cadastradas! ...");
            Console.ReadKey();
            Console.ReadKey();
            return;
        }
        foreach (ContaCorrente item in _contas)
        {
            Console.WriteLine("===  Dados da Conta  ===");

            Console.WriteLine(item.ToString());
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.ReadKey();
        }
    }

    private void CadastrarConta()
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

        _contas.Add(conta);
        //_listaDeContas.Add("sdjda"); // Não irá funcionar, pois tipamos a lista
        Console.WriteLine("... Conta cadastrada com sucesso! ...");
        Console.ReadKey();
    }

    private void RemoverContas()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===      REMOVER CONTAS     ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");
        Console.Write("Informe o número da Conta: ");
        string numeroConta = Console.ReadLine();
        ContaCorrente conta = null;
        foreach (var ccASerRemovida in _contas)
        {
            if (ccASerRemovida.Conta.Equals(numeroConta))
            {
                conta = ccASerRemovida;
            }
        }
        if (conta != null)
        {
            _contas.Remove(conta);
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
        _contas.Sort();
        Console.WriteLine("... Lista de contas ordenada ...");
        Console.ReadKey();
    }

    private void PesquisarContas()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===    PESQUISAR CONTAS     ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");
        Console.Write("Deseja pesquisar por (1) NUMERO DA CONTA ou (2)CPF TITULAR ou (3) Nº AGÊNCIA ou (4) PROFISSÃO DO TITULAR ");
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
                    ExibirListaContasFiltradas(contasPorAgencia);
                    Console.ReadKey();
                    break;
                }
            case 4:
                {
                    Console.WriteLine("Informe a profissão dos clientes, que quer consultar");
                    string profissao = Console.ReadLine()!;
                    var contasPorProfissao = ConsultaPorProfissao(profissao);
                    ExibirListaContasFiltradas(contasPorProfissao);
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
    private ContaCorrente? ConsultaPorCpfTitular(string cpf) => _contas.Where(conta => conta.Titular.Cpf == cpf).FirstOrDefault();
    private ContaCorrente? ConsultaPorNumeroConta(string? nConta) => _contas.Where(conta => conta.Conta == nConta).FirstOrDefault();
    private List<ContaCorrente> ConsultaPorProfissao(string profissao) => (
        from conta in _contas
        where conta.Titular.Profissao.Equals(profissao)
        select conta
    ).ToList();
    private List<ContaCorrente> ConsultaPorAgencia(int nAgencia)
    {
        //  LINQ(Language Integrated Query) é uma funcionalidade do C# para realizar consultas e manipulações de dados
        return (
                    from conta in _contas
                    where conta.Numero_agencia == nAgencia
                    select conta
                ).ToList();
    }
    private void ExibirListaContasFiltradas(List<ContaCorrente> contasFiltradas)
    {
        if (contasFiltradas == null)
        {
            Console.WriteLine("Não há contas para serem exibidas...");
            return;
        }
        foreach (var item in contasFiltradas)
        {
            Console.WriteLine(item.ToString());
        }
    }
}
