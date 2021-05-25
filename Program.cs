using System;
using System.Collections.Generic;

namespace TransferenciaBancaria
{
    class Program
    {

        static List<Conta> listaContas = new List<Conta>();

        static void Main(string[] args)
        {
            
            string opcaoUsuario = OpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X"){

                switch (opcaoUsuario){
                    
                    case "1":
                        InserirConta();
                        break;
                    case "2":
                        ListarContas();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }

                opcaoUsuario = OpcaoUsuario();

            }

            Console.WriteLine("Obrigado por utilizar os nossos serviços! Volte sempre!");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.WriteLine("***************Transferência***************");
            Console.WriteLine();
            Console.WriteLine("Informe o identificador da conta de origem: ");
            int identificadorOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Informe o identificador da conta de destino: ");
            int identificadorDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o valor que deseja transferir: ");
            double valorTransferencia= double.Parse(Console.ReadLine());
            Console.WriteLine();

            listaContas[identificadorOrigem].Transferir(valorTransferencia:valorTransferencia,
                                                        contaDestino: listaContas[identificadorDestino]);

            Console.WriteLine("********************************************");
        }

        private static void Depositar()
        {
            Console.WriteLine("***************Depósito***************");
            Console.WriteLine();
            Console.WriteLine("Informe o identificador da conta para depósito: ");
            int identificador = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o valor que deseja depositar: ");
            double valorDeposito= double.Parse(Console.ReadLine());
            Console.WriteLine();
            
            listaContas[identificador].Depositar(valorDeposito);

            Console.WriteLine("**************************************");

        }

        private static void Sacar()
        {
            Console.WriteLine("***************Saque***************");
            Console.WriteLine();
            Console.WriteLine("Informe o identificador da conta para saque: ");
            int identificador = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o valor que deseja sacar: ");
            double valorSaque = double.Parse(Console.ReadLine());
            Console.WriteLine();
            
            listaContas[identificador].Sacar(valorSaque);

            Console.WriteLine("***********************************");
        }

        private static void ListarContas()
        {
            Console.WriteLine("***************Contas***************");

            if (listaContas.Count == 0){
                Console.WriteLine("Não existe nenhuma conta cadastrada para ser exibida. Verifique!");
                return;
            }

            for(int i = 0; i < listaContas.Count; i++){
                Conta conta = listaContas[i];
                Console.Write("#Identificador da conta: {0} - ", i);
                Console.WriteLine(conta);
            }

            Console.WriteLine("************************************");
        }

        private static void InserirConta()
        {
            Console.WriteLine("**********Inserir nova conta**********");
            Console.WriteLine();

            Console.WriteLine("Digite 1 para Pessoa Física ou 2 para Pessoa Jurídica: ");
            int usrTipoConta = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Informe o nome do cliente: ");
            string usrNome = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Informe o saldo inicial: ");
            double usrSaldo = double.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Informe o crédito: ");
            double usrCredito = double.Parse(Console.ReadLine());
            Console.WriteLine();

            Conta novaConta = new Conta(tipoConta: (TipoConta) usrTipoConta,
                                        saldo: usrSaldo,
                                        credito: usrCredito,
                                        nome: usrNome);

            listaContas.Add(novaConta);

            Console.WriteLine("**************************************");
        }

        private static string OpcaoUsuario(){

            Console.WriteLine();
            Console.WriteLine("Lili Bank a seu dispor!");
            Console.WriteLine("Informe a opção deseajda:");

            Console.WriteLine("1- Inserir nova conta");
            Console.WriteLine("2- Listar Contas");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
