using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_EXECÍCIO
{
    public class Banco
    {
        public string banco { get; set; }
        public List<Operations> operacoes = new List<Operations>();
        public List<Conta> contas = new List<Conta>();

        //Metodos especias(SETTERS GETTERS)
        public string getbanco()
        {
            return this.banco;
        }
        public void setbanco(string value)
        {
            this.banco = value;
        }

        //Construtor
        public Banco(string banco)
        {
            this.setbanco(banco);
        }

        //Outros metodos
        public void adicionar_operacoes(Operations operacoes)
        {
            this.operacoes.Add(operacoes);
        }
    }
}
