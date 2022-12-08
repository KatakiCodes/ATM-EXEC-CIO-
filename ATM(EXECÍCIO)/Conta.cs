using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_EXECÍCIO
{
    public class Conta
    {
        public Banco banco{ get; set; }
        public long numero_da_Conta { get; set; }
        public double saldo_atual { get; set; }
        public string proprietario { get; set; }
        public int senha { get; set; }

        //Metodos especiais (SETTERS e GETTERS)

        //banco
        public Banco getbanco()
        {
            return this.banco;
        }
        public void setbanco(Banco banco)
        {
            this.banco = banco;
        }

        //Numero da conta
        public long getnumero_da_conta()
        {
            return this.numero_da_Conta;
        }
        public void setnumero_da_conta(long value)
        {
            this.numero_da_Conta = value;
        }
        //Saldo atual
        public double getslado_atual()
        {
            return this.saldo_atual;
        }
        public void setsaldo_atual(double value)
        {
            this.saldo_atual = value;
        }
        //Senha
        public int getsenha()
        {
            return this.senha;
        }
        public void setsenha(int value)
        {
            this.senha = value;
        }

        //Proprietario
        public string getproprietario()
        {
            return this.proprietario;
        }
        public void setproprietario(string value)
        {
            this.proprietario = value;
        }

        //Construtor
        public Conta(string proprietario, long numero_da_Conta,double saldo, int senha, Banco banco)
        {
            this.setproprietario(proprietario);
            this.setnumero_da_conta(numero_da_Conta);
            this.setsaldo_atual(0);
            this.setsenha(senha);
            this.setbanco(banco);
            this.setsaldo_atual(saldo);
        }

        public Conta()
        {

        }

        //Movimentações
        public double consultar()
        {
            return getslado_atual();
        }
        public void depositar(double valor)
        {
            double saldo_atual = this.getslado_atual();
            double total = saldo_atual + valor;
            this.setsaldo_atual(total);
        }
        public bool levantamento(double valor)
        {
            double saldo_atual = this.getslado_atual();
            double restante = (saldo_atual - valor);
            if(restante < 0 || valor >30000)
            {
                return false;
            }
            else
            {    
            this.setsaldo_atual(restante);
                return true;
            }
        }
        public bool transferencia(long numero_da_conta, double valor)
        {
            if((this.banco.contas.Find(x => x.getnumero_da_conta() == numero_da_conta) != null))
            {
                string nomeReceptor = banco.contas.Find(x => x.getnumero_da_conta() == numero_da_conta).getproprietario();
                Console.WriteLine($"PROPRIETÁRIO: {nomeReceptor}");
                Console.WriteLine("Desejas confirmar a tranferência? \n\n1 - Sim\n\n2 - Não");
                int option = Int16.Parse(Console.ReadLine());

                if(option == 1)
                {
                double saldo_atual = this.getslado_atual();
                double restante = (saldo_atual - valor);
                    if(restante < 0)
                    {
                        Console.WriteLine("Não foi possível realizar a sua tranferência");
                        Console.ReadKey();
                        return false;
                    }
                    else
                    {
                        this.setsaldo_atual(restante);
                        return true;
                    }                }
                else if(option == 2)
                {
                    Console.WriteLine("Transferência cancelada...");
                    Console.ReadKey();
                    return false;
                }
                else
                {
                    Console.WriteLine("Opção inválida");
                    Console.ReadKey();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
