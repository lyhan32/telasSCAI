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
    public partial class LoginCadastro : Form
    {
        public LoginCadastro()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario novoUsuario = new Usuario();
                novoUsuario.Nome = textnome.Text;
                novoUsuario.Email = textemail.Text;
                novoUsuario.Senha = textsenha.Text;

                string mensagemErro;
                string campoComErro;

                bool cadastroValido = Validador.ValidarCadastroUsuario(novoUsuario, out mensagemErro, out campoComErro);

                if (!cadastroValido)
                {
                    MessageBox.Show(mensagemErro, "Senha Invalida", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    var campo = this.Controls.Find(campoComErro, true).FirstOrDefault();
                    if (campo != null) campo.Focus();
                    return;

                }

                CadUsuario user = new CadUsuario();

                if (user.verificarEmailExistente(novoUsuario.Email))
                {
                    MessageBox.Show("Este endereço de E-mail já esta sendo utilizado! Por favor digite outro E-mail", "Email Existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textemail.Focus();
                    textemail.SelectAll();
                    return;
                }
                
                bool sucessoCadastro = user.cadastrarUsuario(novoUsuario);

                if (sucessoCadastro)
                {
                    MessageBox.Show("Usuario cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Não foi possivel realizar o cadastro do Usuario", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
