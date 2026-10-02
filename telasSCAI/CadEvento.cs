using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace telasSCAI
{
    internal class CadEvento
    {
        Evento dados = new Evento();
        

        public bool cadastrarEvento(Evento dados)
        {
            try
            {
                using (MySqlConnection conexao = ConexaoBanco.CriarConexao())
                {
                    conexao.Open();
                    int idFrequenciaReal = 1; 
                    string sqlBuscaFreq = "SELECT idfrequencia FROM frequencia WHERE TRIM(descricao) LIKE @freq LIMIT 1";
                    using (MySqlCommand cmdBuscaFreq = new MySqlCommand(sqlBuscaFreq, conexao))
                    {
                        
                        string termoBusca = dados.Frequencia.Trim();
                        

                        cmdBuscaFreq.Parameters.AddWithValue("@freq", termoBusca);
                        object resFreq = cmdBuscaFreq.ExecuteScalar();
                        if (resFreq != null) idFrequenciaReal = Convert.ToInt32(resFreq);
                    }
                    int idTipo = 0;
                    string sqlBuscaTipo = "SELECT idtipo_evento FROM tipo_evento WHERE TRIM(tipo) = @tipo_eve LIMIT 1";
                    using (MySqlCommand cmdBuscaTipo = new MySqlCommand(sqlBuscaTipo, conexao))
                    {
                        cmdBuscaTipo.Parameters.AddWithValue("@tipo_eve", dados.Tipo.Trim());
                        object resTipo = cmdBuscaTipo.ExecuteScalar();
                        if (resTipo != null) idTipo = Convert.ToInt32(resTipo);
                    }

                   
                    if (idTipo == 0)
                    {
                        string sqltipo = @"insert into tipo_evento (tipo) values (@tipo_eve); SELECT LAST_INSERT_ID();";
                        MySqlCommand cdmtipo = new MySqlCommand(sqltipo, conexao);
                        cdmtipo.Parameters.AddWithValue("@tipo_eve", dados.Tipo.Trim());
                        idTipo = Convert.ToInt32(cdmtipo.ExecuteScalar());
                    }
                    string sqlLocal = @"insert into local_eventos (numero,capacidade_pessoa,endereco, cidade,estado,nome_local,capacidade_carros) values (@numero,@capacidade_pessoa,@endereco,@cidade,@estado,@nome_local,@capacidade_carros); SELECT LAST_INSERT_ID();";
                    MySqlCommand cmdLocal = new MySqlCommand(sqlLocal,conexao);
                    cmdLocal.Parameters.AddWithValue("@numero", dados.Numero);
                    cmdLocal.Parameters.AddWithValue("@capacidade_pessoa",dados.CapacidadePessoa);
                    cmdLocal.Parameters.AddWithValue("@endereco", dados.Endereco);
                    cmdLocal.Parameters.AddWithValue("@cidade", dados.Cidade);
                    cmdLocal.Parameters.AddWithValue("@estado", dados.Estado);
                    cmdLocal.Parameters.AddWithValue("@nome_local", dados.NomeLocal);
                    cmdLocal.Parameters.AddWithValue("@capacidade_carros", dados.CapacidadeCarro);

                    int idLocal = Convert.ToInt32(cmdLocal.ExecuteScalar());

                    string sqlEvento = @"insert into eventos (nome, descricao,preco,idlocal,idtipo_evento,idfrequencia,idusuario) values (@nome, @descricao, @preco, @idlocal, @idtipo_evento, @idfrequencia, @idusuario);SELECT LAST_INSERT_ID();";
                    MySqlCommand cmdEvento = new MySqlCommand(sqlEvento, conexao);
                    cmdEvento.Parameters.AddWithValue("@nome", dados.Nome);
                    cmdEvento.Parameters.AddWithValue("@descricao", dados.Descricao);
                    cmdEvento.Parameters.AddWithValue("@preco", dados.Preco);
                    cmdEvento.Parameters.AddWithValue("@idlocal", idLocal);
                    cmdEvento.Parameters.AddWithValue("@idtipo_evento", idTipo);
                    cmdEvento.Parameters.AddWithValue("@idfrequencia", idFrequenciaReal);
                    cmdEvento.Parameters.AddWithValue("@idusuario", UsuarioLogado.Idusuario);

                    int idEvento = Convert.ToInt32(cmdEvento.ExecuteScalar());

                    string sqlAgenda = @"insert into agenda (idEventos,data,hora) values (@idEvento,@data,@hora);";
                    MySqlCommand cmdAgenda = new MySqlCommand(sqlAgenda, conexao);
                    cmdAgenda.Parameters.AddWithValue("@idEvento", idEvento);
                    cmdAgenda.Parameters.AddWithValue("@data", dados.Data);
                    cmdAgenda.Parameters.AddWithValue("@hora", dados.Hora);

                    cmdAgenda.ExecuteNonQuery();
                    return true;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao cadastrar o evento: " + ex.Message);
                return false;
            }

            
        }

        public bool verificarEventoDuplicado(string nomeEvento, DateTime dataEvento, TimeSpan horaEvento, out string mensagemErro)
        {
           mensagemErro = string.Empty;
            try
            {
                using (MySqlConnection conexao = ConexaoBanco.CriarConexao())
                {
                    conexao.Open();

                    string sqlCheck = @"SELECT COUNT(*) FROM agenda a 
                                        INNER JOIN eventos e ON a.idEventos = e.idEventos 
                                        WHERE a.data = @data AND a.hora = @hora;";

                    using (MySqlCommand cmd = new MySqlCommand(sqlCheck, conexao))
                    {
                        cmd.Parameters.AddWithValue("@data", dataEvento.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@hora", horaEvento);

                        int resultado = Convert.ToInt32(cmd.ExecuteScalar());

                        if (resultado > 0)
                        {
                            mensagemErro = "Já existe um evento agendado para esta mesma data e horário!";
                            return true; 
                        }
                    }
                }
                return false; 
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao checar duplicidade no Banco:\n\n" + ex.Message, "Erro Crítico", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }


        }
    }
}
