using Mysqlx;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace telasSCAI
{
    public partial class PesquisarEventos : Form
    {
        public PesquisarEventos()
        {
            InitializeComponent();
        }

        public PesquisarEventos(Evento evento)
        {
            try
            {
                InitializeComponent();
                textNome.Text = evento.Nome;
                richdescri.Text = evento.Descricao;
                textpreco.Text = evento.Preco.ToString("C");
                texttipo.Text = evento.Tipo;
                textlocal.Text = evento.NomeLocal;
                textfre.Text = evento.Frequencia;
                data.Text = evento.Data.ToString("dd/MM/yyyy");
                hora.Text = evento.Hora.ToString(@"hh\:mm");
                textend.Text = evento.Endereco;
                textnum.Text = evento.Numero.ToString();
                textcid.Text = evento.Cidade;
                textestado.Text = evento.Estado;
                capcarro.Text = evento.CapacidadeCarro.ToString();
                cappessoa.Text = evento.CapacidadePessoa.ToString();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PesquisarEventos_Load(object sender, EventArgs e)
        {

        }
    }
}
