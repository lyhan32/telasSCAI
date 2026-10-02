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
    public partial class RecuperarSenha : Form
    {
        public RecuperarSenha()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textEM.Text;
            string novasenha = textsenha.Text;
            string confirmarsenha = textconfirma.Text;

            if (novasenha != confirmarsenha)
            {
                MessageBox.Show("As senhas digitadas não são iguais!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Alterar_Excluir rec = new Alterar_Excluir();
            bool mudou = rec.AtualizarSenha(email, novasenha);

            if (mudou)
            {
                MessageBox.Show("Senha alterada com sucesso! Já pode fazer login.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("O e-mail digitado não foi encontrado no sistema.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
