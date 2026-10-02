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
    public partial class menuUsuario : Form
    {
        public menuUsuario()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (Cadastrar cad = new Cadastrar())
            {
                cad.ShowDialog();
            }
            this.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (fmPesquisar frmPesquisa = new fmPesquisar("ALTERAR"))
            {
                frmPesquisa.ShowDialog();
            }
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (fmPesquisar frmPesquisa = new fmPesquisar("EXCLUIR"))
            {
                frmPesquisa.ShowDialog();
            }
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (Excluir_usuario excluir = new Excluir_usuario())
            {
                excluir.ShowDialog();
            }
            this.Show();
        }

        private void menuUsuario_Load(object sender, EventArgs e)
        {
            lblBoasVindas.Text = $"Olá, {UsuarioLogado.Nome}! Bem-vindo(a) de volta.";
        }

        private void menuUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null)
            {
               
                this.Owner.Show();
            }
            else
            {
                
                Application.Exit();
            }
        }
    }
}
