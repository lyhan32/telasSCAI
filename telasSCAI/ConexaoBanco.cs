using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telasSCAI
{
    internal static class ConexaoBanco
    {
        private static string conexaoString = "server=localhost;database=agenda_sca;uid=root;pwd=1435";

        public static MySqlConnection CriarConexao()
        {
            return new MySqlConnection(conexaoString);
        }
    }
}
