using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;


namespace telasSCAI
{
    internal class CadUsuario
    {
        
        Usuario dados = new Usuario();
        

        public bool cadastrarUsuario(Usuario dados)
        {
            try
            {
                using (MySqlConnection conexao = ConexaoBanco.CriarConexao())
                {
                    conexao.Open();
                    string senhaCriptografada = CodificarSenha(dados.Senha);
                    string sqlUsuario = @"insert into usuario (nome,email,senha) values (@nome,@email,@senha); SELECT LAST_INSERT_ID();";
                    MySqlCommand cmdUsuario = new MySqlCommand(sqlUsuario, conexao);
                    cmdUsuario.Parameters.AddWithValue("@nome", dados.Nome);
                    cmdUsuario.Parameters.AddWithValue("@email", dados.Email);
                    cmdUsuario.Parameters.AddWithValue("@senha", senhaCriptografada);

                    int idUsuario = Convert.ToInt32(cmdUsuario.ExecuteScalar());
                    
                    
                    return true;
                }
            }
            catch (MySqlException ex)   
            {
                Console.WriteLine("Erro no MySQL:" + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar com o banco de dados!" + ex.Message);
                return false;
            }
        }

        public bool verificarEmailExistente(string email)
        {
            try
            {
                using (MySqlConnection conexao = ConexaoBanco.CriarConexao())
                {
                    conexao.Open();

                    
                    string sql = "select count(*) from usuario where email = @email";
                    MySqlCommand cmd = new MySqlCommand(sql, conexao);
                    cmd.Parameters.AddWithValue("@email", email);

                    int quantidade = Convert.ToInt32(cmd.ExecuteScalar());

                    return quantidade > 0;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao checar e-mail: " + ex.Message);
                return false;
            }
        }

        public void registrarLogin(int idUsuario)
        {
            try
            {
                using(MySqlConnection conexao = ConexaoBanco.CriarConexao())
                {
                    conexao.Open();

                    string sqlregi = "insert into registro_login (data_login,ip_acesso,idUsuario) values (@data,@ip,@id)";
                    MySqlCommand cmdregi = new MySqlCommand(sqlregi, conexao);
                    cmdregi.Parameters.AddWithValue("@data", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmdregi.Parameters.AddWithValue("@ip", "127.0.0.1");
                    cmdregi.Parameters.AddWithValue("@id", idUsuario);

                    cmdregi.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
            
                Console.WriteLine("Erro ao registrar login: " + ex.Message);
            }
        }

        public static string CodificarSenha(string senhaInsegura)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                
                byte[] bytesIniciais = Encoding.UTF8.GetBytes(senhaInsegura);

                byte[] bytesCriptografados = sha256.ComputeHash(bytesIniciais);

              
                StringBuilder resultado = new StringBuilder();
                foreach (byte b in bytesCriptografados)
                {
                    resultado.Append(b.ToString("x2")); 
                }

                return resultado.ToString();
            }
        }


    }
}
