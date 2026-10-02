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
    public partial class Excluir_usuario : Form
    {
        public Excluir_usuario()
        {
            InitializeComponent();
      

            nomeUser.Text = UsuarioLogado.Nome;
            emailuser.Text = UsuarioLogado.Email;
            

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            int idAtual = UsuarioLogado.Idusuario;
            if (idAtual == 0)
            {
                MessageBox.Show("Erro de sessão: Não foi possível identificar o usuário logado. Faça o login novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            MessageBox.Show($"Olá, {UsuarioLogado.Nome}! Esta é a tela de exclusão de conta. Por favor, leia atentamente as opções antes de prosseguir!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            string mensagemAviso = "Como você deseja prosseguir com a exclusão da sua conta?\n\n" +
                           "[SIM] - EXCLUIR MINHA CONTA E DELETAR TODOS OS EVENTOS QUE CADASTREI.\n\n" +
                           "[NÃO] - EXCLUIR APENAS MINHA CONTA (MEUS EVENTOS CONTINUARÃO SALVOS NA AGENDA).\n\n" +
                           "[CANCELAR] - DESISTIR E VOLTAR AO SISTEMA.";

            DialogResult escolha = MessageBox.Show(mensagemAviso, "Opções de Exclusão de Conta",
                                           MessageBoxButtons.YesNoCancel,
                                           MessageBoxIcon.Warning);

            if (escolha == DialogResult.Cancel)
            {
                return;
            }

            bool deletarEventos = false;

            if (escolha == DialogResult.Yes)
            {
                deletarEventos = true;
            }
            else if (escolha == DialogResult.No)
            {
                deletarEventos = false;
            }

            Alterar_Excluir excluir = new Alterar_Excluir();

           
            bool sucesso = excluir.excluirUsuario(idAtual, deletarEventos);


            if (sucesso)
            {
              
                MessageBox.Show("Sua conta foi removida com sucesso.", "Conta Encerrada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                UsuarioLogado.Idusuario = 0;
                UsuarioLogado.Nome = "";
                UsuarioLogado.Email = "";

              
                this.Hide();
                logar telaLogin = new logar();
                telaLogin.ShowDialog(); 
            }
            else
            {
                
                MessageBox.Show("Erro ao tentar encerrar a conta. O banco de dados recusou a operação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
