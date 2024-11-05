namespace bytebank.Modelos.Conta
{
    public class ContaCorrente : IComparable<ContaCorrente>
    {
        private int _numero_agencia;

        private string _conta;

        private double saldo;

        public Cliente Titular { get; set; }

        public string Nome_Agencia { get; set; }

        public int Numero_agencia
        {
            get
            {
                return _numero_agencia;
            }
            set
            {
                if (value > 0)
                {
                    _numero_agencia = value;
                }
            }
        }

        public string Conta
        {
            get
            {
                return _conta;
            }
            set
            {
                if (value != null)
                {
                    _conta = value;
                }
            }
        }

        public double Saldo
        {
            get
            {
                return saldo;
            }
            set
            {
                if (!(value < 0.0))
                {
                    saldo = value;
                }
            }
        }

        public static int TotalDeContasCriadas { get; set; }

        public bool Sacar(double valor)
        {
            if (saldo < valor)
            {
                return false;
            }
            if (valor < 0.0)
            {
                return false;
            }
            saldo -= valor;
            return true;
        }

        public void Depositar(double valor)
        {
            if (!(valor < 0.0))
            {
                saldo += valor;
            }
        }

        public bool Transferir(double valor, ContaCorrente destino)
        {
            if (saldo < valor)
            {
                return false;
            }
            if (valor < 0.0)
            {
                return false;
            }
            saldo -= valor;
            destino.saldo += valor;
            return true;
        }

        public ContaCorrente(int numero_agencia)
        {
            Numero_agencia = numero_agencia;
            Conta = Guid.NewGuid().ToString().Substring(0, 8); // Gera uma string única de 8 caracteres baseada em um GUID.
            Titular = new Cliente();
            TotalDeContasCriadas++;
        }

        public override string ToString()
        {

            return $" === DADOS DA CONTA === \n" +
                   $"Número da Conta : {this.Conta} \n" +
                   $"Titular da Conta: {this.Titular.Nome} \n" +
                   $"CPF do Titular  : {this.Titular.Cpf} \n" +
                   $"Profissão do Titular: {this.Titular.Profissao}";
        }

        /*
            No método CompareTo da classe ContaCorrente, o retorno de 1 quando other é null serve para indicar que a instância atual (this) é "maior" que o objeto other. 
            Isso segue a convenção do método CompareTo, que retorna:
            Um valor positivo (geralmente 1) quando a instância atual é considerada maior que o objeto passado (other).
            Zero quando ambos os objetos são iguais.
            Um valor negativo (geralmente -1) quando a instância atual é considerada menor que o objeto passado.
         */
        public int CompareTo(ContaCorrente? other)
        {
            // O return 1 indica que a instância atual (this) é "maior" que other quando other é null, seguindo a convenção do CompareTo.
            if (other == null)
            {
                return 1;
            }
            else
            {
                return this.Numero_agencia.CompareTo(other._numero_agencia);
            }
        }
    }

}