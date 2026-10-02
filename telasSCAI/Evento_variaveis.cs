using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telasSCAI
{
    public class Evento
    {
        string nome;
        string tipo;
        string descricao;
        DateTime data;
        TimeSpan hora;
        string frequencia;
        string nomeLocal;
        string endereco;
        string cidade;
        string estado;
        int numero;
        int capacidadeCarro;
        int capacidadePessoa;
        double preco;

        public Evento()
        {
            nome = "";
            tipo = "";
            descricao = "";
            data = DateTime.Now;
            frequencia = "";
            nomeLocal = "";
            endereco = "";
            cidade = "";
            estado = "";
            numero = 0;
            capacidadeCarro = 0;
            capacidadePessoa = 0;
            preco = 0.0;
            hora = TimeSpan.Zero;
        }

        public string Nome { get => nome; set => nome = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public DateTime Data { get => data; set => data = value; }
        public string Frequencia { get => frequencia; set => frequencia = value; }
        public string NomeLocal { get => nomeLocal; set => nomeLocal = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        public string Cidade { get => cidade; set => cidade = value; }
        public string Estado { get => estado; set => estado = value; }
        public int Numero { get => numero; set => numero = value; }
        public int CapacidadeCarro { get => capacidadeCarro; set => capacidadeCarro = value; }
        public int CapacidadePessoa { get => capacidadePessoa; set => capacidadePessoa = value; }
        public double Preco { get => preco; set => preco = value; }
        public TimeSpan Hora { get => hora; set => hora = value; }
    }
}
