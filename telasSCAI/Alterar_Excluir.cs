using MySql.Data;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace telasSCAI
{
    internal class Alterar_Excluir
    {
        Evento dados = new Evento();
        Usuario dadosUser = new Usuario();
       

        public bool excluirEvento(string nomeEvento, int idUsuarioLogado)
        {
            try
            {
                using (MySqlConnection conexao = ConexaoBanco.CriarConexao())
                {
                    conexao.Open();
                    string sqlExcluir = @"delete from eventos where nome = @nomeEvento and idUsuario = @idUser";
                    MySqlCommand cmdExcluir = new MySqlCommand(sqlExcluir, conexao);
                    cmdExcluir.Parameters.AddWithValue("@nomeEvento", nomeEvento);
                    cmdExcluir.Parameters.AddWithValue("@idUser", idUsuarioLogado);
                    int linhasAfetadas = cmdExcluir.ExecuteNonQuery();
                    return linhasAfetadas > 0;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao excluir o evento: " + ex.Message);
                return false;
            }
        }

        public bool alterarEvento(Evento dadosnovos, string nomeAntigo,int idUsuarioLogado)
        {
            try
            {
                using (MySqlConnection conexao = ConexaoBanco.CriarConexao())
                {
                    conexao.Open();

                  
                    int idFrequenciaReal = 1; 
                    string termoBusca = string.IsNullOrEmpty(dadosnovos.Frequencia) ? "" : dadosnovos.Frequencia.Trim();

                    if (!string.IsNullOrEmpty(termoBusca))
                    {
    
                        string sqlBuscarFreq = "SELECT idfrequencia from frequencia where TRIM(descricao) like @freq LIMIT 1";
                        using (MySqlCommand cmdBuscarFreq = new MySqlCommand(sqlBuscarFreq, conexao))
                        {
                            cmdBuscarFreq.Parameters.AddWithValue("@freq", termoBusca);
                            object resFreq = cmdBuscarFreq.ExecuteScalar();
                            if (resFreq != null) idFrequenciaReal = Convert.ToInt32(resFreq);
                        }
                    }

                    
                    int idTipoReal = 0;
                    string sqlBuscaTipo = "SELECT idtipo_evento FROM tipo_evento WHERE TRIM(tipo) = @tipo_eve LIMIT 1";
                    using (MySqlCommand cmdBuscaTipo = new MySqlCommand(sqlBuscaTipo, conexao))
                    {
                        cmdBuscaTipo.Parameters.AddWithValue("@tipo_eve", dadosnovos.Tipo.Trim());
                        object resTipo = cmdBuscaTipo.ExecuteScalar();
                        if (resTipo != null) idTipoReal = Convert.ToInt32(resTipo);
                    }

                   
                    if (idTipoReal == 0)
                    {
                        string sqltipo = @"insert into tipo_evento (tipo) values (@tipo_eve); SELECT LAST_INSERT_ID();";
                        using (MySqlCommand cdmtipo = new MySqlCommand(sqltipo, conexao))
                        {
                            cdmtipo.Parameters.AddWithValue("@tipo_eve", dadosnovos.Tipo.Trim());
                            idTipoReal = Convert.ToInt32(cdmtipo.ExecuteScalar());
                        }
                    }

                  
                    string sqlAlterar = @"UPDATE eventos e 
                                LEFT JOIN agenda a ON e.idEventos = a.idEventos 
                                LEFT JOIN local_eventos l ON e.idlocal = l.idlocal 
                                SET e.nome = @nome, 
                                    e.descricao = @descricao, 
                                    e.preco = @preco, 
                                    e.idtipo_evento = @idtipo,       
                                    e.idfrequencia = @idfrequencia,
                                    a.data = @data, 
                                    a.hora = @hora,
                                    l.numero = @numero, 
                                    l.capacidade_pessoa = @capacidade_pessoa, 
                                    l.endereco = @endereco, 
                                    l.cidade = @cidade, 
                                    l.estado = @estado, 
                                    l.nome_local = @nome_local, 
                                    l.capacidade_carros = @capacidade_carros
                                WHERE TRIM(e.nome) = TRIM(@nomeAntigo) and e.idUsuario = @idUser";

                    using (MySqlCommand cmdAlterar = new MySqlCommand(sqlAlterar, conexao))
                    {
                        cmdAlterar.Parameters.AddWithValue("@nome", dadosnovos.Nome);
                        cmdAlterar.Parameters.AddWithValue("@descricao", dadosnovos.Descricao);
                        cmdAlterar.Parameters.AddWithValue("@preco", dadosnovos.Preco);
                        cmdAlterar.Parameters.AddWithValue("@numero", dadosnovos.Numero);
                        cmdAlterar.Parameters.AddWithValue("@capacidade_pessoa", dadosnovos.CapacidadePessoa);
                        cmdAlterar.Parameters.AddWithValue("@endereco", dadosnovos.Endereco);
                        cmdAlterar.Parameters.AddWithValue("@cidade", dadosnovos.Cidade);
                        cmdAlterar.Parameters.AddWithValue("@estado", dadosnovos.Estado);
                        cmdAlterar.Parameters.AddWithValue("@nome_local", dadosnovos.NomeLocal);
                        cmdAlterar.Parameters.AddWithValue("@capacidade_carros", dadosnovos.CapacidadeCarro);

                        cmdAlterar.Parameters.AddWithValue("@idtipo", idTipoReal);
                        cmdAlterar.Parameters.AddWithValue("@idfrequencia", idFrequenciaReal);

                        
                        cmdAlterar.Parameters.AddWithValue("@data", dadosnovos.Data.ToString("yyyy-MM-dd"));
                        cmdAlterar.Parameters.AddWithValue("@hora", dadosnovos.Hora);
                        cmdAlterar.Parameters.AddWithValue("@nomeAntigo", nomeAntigo.Trim());

                       
                        cmdAlterar.Parameters.AddWithValue("@idUser", idUsuarioLogado > 0 ? idUsuarioLogado : 999);

                        int linhasAfetadas = cmdAlterar.ExecuteNonQuery();
                        return linhasAfetadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao alterar o evento: " + ex.Message);
                return false;
            }

 
        }
        public bool excluirUsuario(int idUsuario,bool apagarEventos)
        {
            int idUsuarioAnonimo = 999;
            MessageBox.Show("O ID que chegou para excluir é: " + idUsuario);
            
            using (MySqlConnection conexao = ConexaoBanco.CriarConexao())
            {
                conexao.Open();
                MySqlTransaction transacao = conexao.BeginTransaction();

                try
                {
                   
                    string sqlLogin = "delete from registro_login where idUsuario =" + idUsuario;
                    MySqlCommand cmdLogin = new MySqlCommand(sqlLogin, conexao, transacao);
                    cmdLogin.ExecuteNonQuery();

                   
                    if (!apagarEventos)
                    {
                        string sqlTransferir = "UPDATE eventos SET idUsuario = " + idUsuarioAnonimo + " WHERE idUsuario = " + idUsuario;
                        MySqlCommand cmdTransferir = new MySqlCommand(sqlTransferir, conexao, transacao);
                        cmdTransferir.ExecuteNonQuery();
                    }

                    
                    string sqlUsuario = "DELETE FROM usuario WHERE idUsuario = "+ idUsuario; 
                    MySqlCommand cmdUsuario = new MySqlCommand(sqlUsuario, conexao, transacao);
                    cmdUsuario.ExecuteNonQuery();
                   
                    transacao.Commit();
                    return true; 


                }
                catch (Exception ex)
                {
                    transacao.Rollback();

                    System.Windows.Forms.MessageBox.Show("Erro real do MySQL: " + ex.Message);

                    return false;
                }

            }

        }
        public bool AtualizarSenha(string emailUsuario, string novasenhalimpa)
        {
            try
            {
                using (MySqlConnection conexao = ConexaoBanco.CriarConexao())
                {
                    conexao.Open();
                    string senhaCriptografada = CadUsuario.CodificarSenha(novasenhalimpa);
                    string sqlAtualizar = @"UPDATE usuario SET senha = @novasenha WHERE email = @Email";
                    using (MySqlCommand cmdAtualizar = new MySqlCommand(sqlAtualizar, conexao))
                    {
                        cmdAtualizar.Parameters.AddWithValue("@novasenha", senhaCriptografada);
                        cmdAtualizar.Parameters.AddWithValue("@Email", emailUsuario);
                        int linhasAfetadas = cmdAtualizar.ExecuteNonQuery();
                        return linhasAfetadas > 0;
                    }


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao atualizar a senha: " + ex.Message);
                return false;
            }
        }
    }
}
