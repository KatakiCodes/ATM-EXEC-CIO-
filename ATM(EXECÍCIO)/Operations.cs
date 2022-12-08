using System;
using System.Collections.Generic;

namespace ATM_EXECÍCIO
{
    public class Operations
    {
        public string tipo_de_operacao { get; set; }
        public Conta conta { get; set; }
        public DateTime data_da_operacao { get; set; }

        //Metodos especiais(SETTERS E GETTERS)
        public string gettipo_da_operacao()
        {
            return this.tipo_de_operacao;
        }
        public void settipo_da_operacao(string valor)
        {
            this.tipo_de_operacao = valor;
        }

        public string getcliente()
        {
            return this.conta.proprietario;
        }

        public long getnumero_da_conta()
        {
            return this.conta.numero_da_Conta;
        }

        public DateTime getdata_da_operacao()
        {
            return this.data_da_operacao;
        }
        public void setdata_da_operacao(DateTime data)
        {
            this.data_da_operacao = data;
        }

        public int getsenha()
        {
            return this.conta.getsenha();
        }
        public void setsenha(int pin)
        {
            this.conta.setsenha(pin);
        }

        //Construtor
        public Operations(string tipo_de_operacao, Conta conta, DateTime data_da_operacao)
        {
            this.tipo_de_operacao = tipo_de_operacao;
            this.conta = conta;
            this.data_da_operacao = data_da_operacao;
        }

        public Operations()
        {
        }


        //Outros metodos

        public void criarConta()
        {
            Console.WriteLine("Crie a sua conta: \n\n");

            Console.WriteLine("Digite seu nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Cria uma senha segura: ");
            int pin = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Especifica o seu banco: ");
            string banco = Console.ReadLine();
            this.conta = new Conta(nome, 1000010020002, 0, pin, new Banco(banco));
            Console.Clear();
            Console.WriteLine($"Conta criada com sucesso!\n\n");
            Console.WriteLine($"PROPRIETÁRIO: {this.conta.getproprietario()}\n" +
                $"NUMERO DA CONTA: {this.conta.getnumero_da_conta()}\n" +
                $"BANCO: {this.conta.banco.banco}");
            Console.WriteLine($"*************\n\n SALDO ATUAL: {this.conta.getslado_atual()} KZ");
            this.conta = new Conta(nome, 1000010020002, 0, pin, new Banco(banco));
        }
        public void gerarOutrasContas()
        {
            conta.banco.contas.Add(new Conta("Marcio ventura", 2000010020002, 0, 0, new Banco("Atlântico")));
            conta.banco.contas.Add(new Conta("Lucia Cabral", 23000010020002, 0, 0, new Banco("Atlântico")));
            conta.banco.contas.Add(new Conta("Pedro Marcos", 0000610020002, 0, 0, new Banco("BFA")));
        }
        public void Consulta(int pin)
        {
            Console.WriteLine("***CONSULTAR***\n\n");
            Console.WriteLine("insere o seu pin: ");
            pin = Int16.Parse(Console.ReadLine());
            if (pin != this.conta.senha)
            {
                Console.WriteLine("A sua senha está incorreta!");
                Console.ReadKey();
            }
            else
            {
                this.conta.banco.operacoes.Add(new Operations("consulta", conta, DateTime.Now));

                Console.WriteLine("******\n\n");
                Console.WriteLine($"BANCO: {conta.banco.getbanco()}\n" +
                    $"SALDO: {conta.consultar()} KZ\nDATA: {DateTime.Now} \n\n");
                Console.ReadKey();
            }
        }
        public void Deposito(int pin)
        {
            Console.WriteLine("***DEPOSITAR***\n\n");
            Console.WriteLine("insere o seu pin: ");
            pin = Int16.Parse(Console.ReadLine());
            if (pin != this.conta.senha)
            {
                Console.WriteLine("A sua senha está incorreta!");
                Console.ReadKey();
            }
            else
            {

                Console.WriteLine("******\n\n");
                Console.WriteLine("Isere o valor a para depósito: ");
                double valor = double.Parse(Console.ReadLine());
                this.conta.depositar(valor);
                Console.Clear();

                Console.WriteLine("Depósito efecutuado com sucesso!");
                this.conta.banco.operacoes.Add(new Operations("Depositar", conta, DateTime.Now));
                Console.ReadKey();
            }
        }
        public void levantamento(int pin)
        {
            Console.WriteLine("***LEVANTAMENTO***\n\n");
            Console.WriteLine("insere o seu pin: ");
            pin = Int16.Parse(Console.ReadLine());
            if (pin != this.conta.senha)
            {
                Console.WriteLine("A sua senha está incorreta!");
                Console.ReadKey();
            }
            else
            {

                Console.WriteLine("******\n\n");
                Console.WriteLine("Isere o valor a levantar: ");
                double valor = double.Parse(Console.ReadLine());
                if (this.conta.levantamento(valor) == false)
                {
                    Console.WriteLine("Não foi possível realizar o seu levantamento");
                    Console.ReadKey();
                }
                else
                {

                    Console.WriteLine("Levantamento efecutuado com sucesso!");
                    this.conta.banco.operacoes.Add(new Operations("Levantamento", conta, DateTime.Now));
                    Console.ReadKey();
                }

            }
        }
        public void Transferencia(int pin)
        {
            Console.WriteLine("***TRANFERÊNCIA***\n\n");
            Console.WriteLine("insere o seu pin: ");
            pin = Int16.Parse(Console.ReadLine());
            if (pin != this.conta.senha)
            {
                Console.WriteLine("A sua senha está incorreta!");
                Console.ReadKey();
            }
            else
            {

                Console.WriteLine("******\n\n");
                Console.WriteLine("Informa o número da conta para transferir: ");
                long num_conta = long.Parse(Console.ReadLine());
                Console.WriteLine("Informa o valor para transferir: ");
                double valor = double.Parse(Console.ReadLine());
                if (conta.transferencia(num_conta, valor) == true)
                {
                    Console.Clear();
                    Console.WriteLine("transferência efectuada!");
                    this.conta.banco.operacoes.Add(new Operations("tranferência", conta, DateTime.Now));
                    Console.ReadKey();
                }
                else
                {
                    return;
                }
            }
        }
        menu menu = new menu();
        public void Extrato()
        {
            menu.menuExtrato();
            int option = Int16.Parse(Console.ReadLine());

            switch (option)
            {
                case (1):
                    foreach (Operations operations in this.conta.banco.operacoes)
                    {
                        Console.WriteLine($"OPERAÇÃO: {operations.gettipo_da_operacao()} \n" +
                            $"DATA: {operations.getdata_da_operacao()} \n\n");
                    }
                    Console.ReadKey();
                    break;
            }

        }
    }
}
