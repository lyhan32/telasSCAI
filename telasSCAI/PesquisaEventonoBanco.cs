
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace telasSCAI
{
 
    internal class PesquisaEventonoBanco
    {
        Evento evento = new Evento();
        Usuario user = new Usuario();
       
        
      
    
        public List<string> Eventopornome (string nome)
        {
            List<string> PesquisarEvento = new List<string>();

            try
            {
                using (MySqlConnection conexao = ConexaoBanco.CriarConexao())
                {
                    conexao.Open();
                    MySqlCommand verifica = new MySqlCommand("Select nome from eventos where trim(eventos.nome) LIKE @nome", conexao);
                    verifica.Parameters.AddWithValue("@nome", "%" + nome + "%");
                    MySqlDataReader ler = verifica.ExecuteReader();

                    while (ler.Read())
                    {

                        PesquisarEvento.Add(ler["nome"].ToString());

                    }

                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            return PesquisarEvento;

        }

        public List<string> EventoporData(DateTime data)
        {
            List<string> PesquisarEvento = new List<string>();
            try
            {
                using (MySqlConnection conexao = ConexaoBanco.CriarConexao())
                {
                    conexao.Open();
                    MySqlCommand verifica = new MySqlCommand("Select eventos.nome, data from eventos inner join agenda on eventos.idEventos = agenda.idEventos where agenda.data = @data", conexao);

                    verifica.Parameters.AddWithValue("@data", data.ToString("yyyy-MM-dd"));
                    MySqlDataReader ler = verifica.ExecuteReader();
                    while (ler.Read())
                    {
                        PesquisarEvento.Add(ler["nome"].ToString());
                    }
                 
                }
                
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            return PesquisarEvento;

        }

        public List<string> Eventopormes(int mes)
        {
            List<string> PesquisarEvento = new List<string>();
            try
            {
                using (MySqlConnection conexao = ConexaoBanco.CriarConexao())
                {
                    conexao.Open();
                    MySqlCommand verifica = new MySqlCommand("Select eventos.nome, MONTH(agenda.data) from eventos inner join agenda on eventos.idEventos = agenda.idEventos where month(agenda.data) = @mes", conexao);

                    verifica.Parameters.AddWithValue("@mes", mes);
                    MySqlDataReader ler = verifica.ExecuteReader();
                    while (ler.Read())
                    {
                        PesquisarEvento.Add(ler["nome"].ToString());
                    }
               
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            return PesquisarEvento;
        }

        public List<string> EventoPorTipo(string tipo)
        {
            List<string> PesquisarEvento = new List<string>();
            try
            {
                using (MySqlConnection conexao = ConexaoBanco.CriarConexao())
                {
                    conexao.Open();

                    string query = "SELECT eventos.nome FROM eventos " +
                            "INNER JOIN tipo_evento ON eventos.idtipo_evento = tipo_evento.idtipo_evento " +
                            "WHERE TRIM(tipo_evento.tipo) LIKE @tipo";

                    using (MySqlCommand verifica = new MySqlCommand(query, conexao))
                    {

                        verifica.Parameters.AddWithValue("@tipo", "%" + tipo.Trim() + "%");

                        using (MySqlDataReader ler = verifica.ExecuteReader())
                        {
                            while (ler.Read())
                            {
                                PesquisarEvento.Add(ler["nome"].ToString());
                            }
                        }
                    }

                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            return PesquisarEvento;
        }

        public Evento BuscarEvento(string nome)
        {
            Evento eventoEncontrado = null;

            try
            {
                using (MySqlConnection conexao = ConexaoBanco.CriarConexao())
                {
                    conexao.Open();
                    string query = "SELECT eventos.nome, eventos.descricao, eventos.preco, agenda.data, agenda.hora, " +
                           "local_eventos.nome_local, local_eventos.endereco, local_eventos.numero, " +
                           "local_eventos.cidade, local_eventos.estado, tipo_evento.tipo AS nome_tipo, " +
                           "frequencia.descricao as descricaofre, local_eventos.capacidade_carros, local_eventos.capacidade_pessoa " +
                           "FROM eventos " +
                           "LEFT JOIN agenda ON eventos.idEventos = agenda.idEventos " +
                           "LEFT JOIN local_eventos ON eventos.idlocal = local_eventos.idlocal " +
                           "LEFT JOIN tipo_evento ON eventos.idtipo_evento = tipo_evento.idtipo_evento " +
                           "LEFT JOIN frequencia ON eventos.idfrequencia = frequencia.idfrequencia " +
                           "WHERE TRIM(eventos.nome) = @nome";

                    using (MySqlCommand comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@nome", nome.Trim());
                        using (MySqlDataReader ler = comando.ExecuteReader())
                        {
                            if (ler.Read())
                            {
                                eventoEncontrado = new Evento();

                               
                                eventoEncontrado.Nome = ler["nome"] != DBNull.Value ? ler["nome"].ToString() : "";
                                eventoEncontrado.Descricao = ler["descricao"] != DBNull.Value ? ler["descricao"].ToString() : "";
                                eventoEncontrado.Preco = ler["preco"] != DBNull.Value ? Convert.ToDouble(ler["preco"]) : 0.0;
                                eventoEncontrado.Data = ler["data"] != DBNull.Value ? Convert.ToDateTime(ler["data"]) : DateTime.MinValue;
                                eventoEncontrado.Hora = ler["hora"] != DBNull.Value ? TimeSpan.Parse(ler["hora"].ToString()) : TimeSpan.Zero;
                                eventoEncontrado.NomeLocal = ler["nome_local"] != DBNull.Value ? ler["nome_local"].ToString() : "";
                                eventoEncontrado.Endereco = ler["endereco"] != DBNull.Value ? ler["endereco"].ToString() : "";
                                eventoEncontrado.Numero = ler["numero"] != DBNull.Value ? Convert.ToInt32(ler["numero"]) : 0;
                                eventoEncontrado.Cidade = ler["cidade"] != DBNull.Value ? ler["cidade"].ToString() : "";
                                eventoEncontrado.Estado = ler["estado"] != DBNull.Value ? ler["estado"].ToString() : "";
                                eventoEncontrado.Tipo = ler["nome_tipo"] != DBNull.Value ? ler["nome_tipo"].ToString() : "";
                                eventoEncontrado.Frequencia = ler["descricaofre"] != DBNull.Value ? ler["descricaofre"].ToString() : "";
                                eventoEncontrado.CapacidadeCarro = ler["capacidade_carros"] != DBNull.Value ? Convert.ToInt32(ler["capacidade_carros"]) : 0;
                                eventoEncontrado.CapacidadePessoa = ler["capacidade_pessoa"] != DBNull.Value ? Convert.ToInt32(ler["capacidade_pessoa"]) : 0;



                            }
                        }
                    }
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            return eventoEncontrado;
        }

        public bool BuscarUsuario(Usuario user)
        {
           
            try
            {
                using (MySqlConnection conexao = ConexaoBanco.CriarConexao())
                {
                    conexao.Open();

                    string senhaVerificacao = CadUsuario.CodificarSenha(user.Senha);
                    string sql = "select * from usuario where email = @email and senha = @senha";
                    MySqlCommand cmduser = new MySqlCommand(sql, conexao);
                    cmduser.Parameters.AddWithValue("@email", user.Email);
                    cmduser.Parameters.AddWithValue("@senha", senhaVerificacao);

                    using (MySqlDataReader ler = cmduser.ExecuteReader())
                    {
                        if (ler.Read())
                        {
                            user.Idusuario = Convert.ToInt32(ler["idUsuario"]);
                            user.Nome = ler["nome"].ToString();
                            user.Email = ler["email"].ToString();

                            UsuarioLogado.Idusuario = user.Idusuario;
                            UsuarioLogado.Nome = user.Nome;
                            UsuarioLogado.Email = user.Email;

                            return true;
                        }

                       
                    }
                    return false;
                   
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro de conexão com o banco: " + ex.Message);
                return false;
            }

        }

        public int BuscarDonoDoEvento(string nomeEvento)
        {
            try
            {
                using (MySqlConnection conexao = ConexaoBanco.CriarConexao())
                {
                    conexao.Open();
                   
                    string sql = "select idUsuario from eventos where nome = @nome";
                    MySqlCommand cmd = new MySqlCommand(sql, conexao);
                    cmd.Parameters.AddWithValue("@nome", nomeEvento);

                    using (MySqlDataReader ler = cmd.ExecuteReader())
                    {
                        if (ler.Read())
                        {
                           
                            return Convert.ToInt32(ler["idUsuario"]);
                        }
                    }
                  
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao buscar evento: " + ex.Message);
                return -1;
            }
        }

        public int contarEventosHoje()
        {
            int quant = 0;
            try
            {
                using (MySqlConnection conexao = ConexaoBanco.CriarConexao())
                {
                    conexao.Open();
                    string cont = "select count(*) from agenda where data = @hoje";

                    using (MySqlCommand cmdContar = new MySqlCommand(cont, conexao))
                    {
                        cmdContar.Parameters.AddWithValue("@hoje", DateTime.Today.ToString("yyyy-MM-dd"));
                        quant = Convert.ToInt32(cmdContar.ExecuteScalar());
                    }
                }
            }catch(Exception erro)
            {
               Console.WriteLine("Erro ao contar eventos de hoje: " + erro.Message);
            }
            return quant;
        }
        public DataTable obterEventosPassados()
        {
            DataTable tabela = new DataTable();

            string sql = @"SELECT e.nome AS 'Nome do Evento', 
                          e.descricao AS 'Descrição', 
                          e.preco AS 'Preço', 
                          a.data AS 'Data', 
                          a.hora AS 'Horário'
                   FROM agenda a
                   INNER JOIN eventos e ON a.idEventos = e.idEventos
                   WHERE a.data < CURDATE()
                   ORDER BY a.data DESC, a.hora DESC;";
            try
            {
                using (MySqlConnection conexao = ConexaoBanco.CriarConexao())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            conexao.Open();
                            adapter.Fill(tabela); 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar eventos passados: " + ex.Message, "Erro", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return tabela;
        }

    }
       
}
