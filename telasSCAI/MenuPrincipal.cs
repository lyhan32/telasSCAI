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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (fmPesquisar pesq = new fmPesquisar())
            {
                pesq.ShowDialog();  
            }
            this.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();

            using (logar login = new logar())
            {
               
                if (login.ShowDialog() == DialogResult.OK)
                {
                   
                    menuUsuario menu = new menuUsuario();
                    menu.Owner = this; 
                    menu.Show();
                }
                else
                {
                  
                    this.Show();
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (LoginCadastro cadlogin = new LoginCadastro())
            {
                cadlogin.ShowDialog();

            }
            this.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AtualizarAviso();
        }
        void AtualizarAviso()
        {
            PesquisaEventonoBanco banco = new PesquisaEventonoBanco();
            int totalEventosHoje = banco.contarEventosHoje();

            lblAviso.Visible = (totalEventosHoje > 0);
           
            if (totalEventosHoje > 0)
            {
                lblAviso.Text = $"⚠️ Você tem {totalEventosHoje} evento(s) hoje! Clique aqui.";
            }
        }
        private void lblAviso_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (fmPesquisar pesq = new fmPesquisar(filtrarHoje: true))
            {
                pesq.ShowDialog();   
                
            }

            this.Show();

        }

        private void MenuPrincipal_Activated(object sender, EventArgs e)
        {
            AtualizarAviso();
        }
    }
}
