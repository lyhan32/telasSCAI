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
    public partial class EventosPassados : Form
    {
        public EventosPassados()
        {
            InitializeComponent();
        }

        private void EventosPassados_Load(object sender, EventArgs e)
        {
            CarregarHistorico();
        }
        void CarregarHistorico()
        {
            PesquisaEventonoBanco bd = new PesquisaEventonoBanco();

            DataTable dadosPassados = bd.obterEventosPassados();

            dgvEventosPassados.DataSource = dadosPassados;
          
            dgvEventosPassados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
