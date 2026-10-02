using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace telasSCAI
{
    public partial class logar : Form
    {
        public logar()
        {
            InitializeComponent();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void logar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {

                Usuario user = new Usuario();

                user.Email = Email.Text;
                user.Senha = Senha.Text;

                string mensagemErro;


                bool loginValido = Validador.ValidarLogin(user, out mensagemErro);

                if (!loginValido)
                {
                    MessageBox.Show(mensagemErro, "Erro de Preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                PesquisaEventonoBanco verificauser = new PesquisaEventonoBanco();

                bool usuarioExiste = verificauser.BuscarUsuario(user);
                if (usuarioExiste)
                {
                    UsuarioLogado.Idusuario = user.Idusuario;
                    UsuarioLogado.Nome = user.Nome;
                    UsuarioLogado.Email = user.Email;

                    CadUsuario registra = new CadUsuario();
                    registra.registrarLogin(user.Idusuario);

                    MessageBox.Show("Login realizado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    menuUsuario menu = new menuUsuario();

                    

                    this.DialogResult = DialogResult.OK;
                    this.Close();


                }
                else
                {
                    MessageBox.Show("E-mail ou senha incorretos!", "Falha no Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Senha.Text = "";
                    Senha.Focus();
                }


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro no MySQL:" + ex.Message);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao conectar com o banco de dados!" + ex.Message);

            }

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (RecuperarSenha recupera = new RecuperarSenha())
            {
                recupera.ShowDialog();
            }
            this.Show();
        }
    }
}
