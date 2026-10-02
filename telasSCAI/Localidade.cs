using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telasSCAI
{
    internal class Localidade
    {
        public static class LocalidadeService
        {
          
            private static readonly Dictionary<string, List<string>> cidadesPorEstado = new Dictionary<string, List<string>>()
        {
            { "AC", new List<string> { "Rio Branco", "Cruzeiro do Sul", "Sena Madureira" } },
            { "AL", new List<string> { "Maceió", "Arapiraca", "Palmeira dos Índios" } },
            { "AP", new List<string> { "Macapá", "Santana", "Laranjal do Jari" } },
            { "AM", new List<string> { "Manaus", "Parintins", "Itacoatiara" } },
            { "BA", new List<string> { "Salvador", "Feira de Santana", "Vitória da Conquista", "Porto Seguro" } },
            { "CE", new List<string> { "Fortaleza", "Caucaia", "Juazeiro do Norte" } },
            { "DF", new List<string> { "Brasília" } },
            { "ES", new List<string> { "Vitória", "Vila Velha", "Serra", "Guarapari" } },
            { "GO", new List<string> { "Goiânia", "Aparecida de Goiânia", "Anápolis" } },
            { "MA", new List<string> { "São Luís", "Imperatriz", "Caxias" } },
            { "MT", new List<string> { "Cuiabá", "Várzea Grande", "Rondonópolis" } },
            { "MS", new List<string> { "Campo Grande", "Dourados", "Três Lagoas" } },
            { "MG", new List<string> { "Belo Horizonte", "Uberlândia", "Contagem", "Juiz de Fora" } },
            { "PA", new List<string> { "Belém", "Ananindeua", "Santarém" } },
            { "PB", new List<string> { "João Pessoa", "Campina Grande", "Patos" } },
            { "PR", new List<string> { "Curitiba", "Londrina", "Maringá", "Cascavel" } },
            { "PE", new List<string> { "Recife", "Jaboatão dos Guararapes", "Olinda", "Caruaru" } },
            { "PI", new List<string> { "Teresina", "Parnaíba", "Picos" } },
            { "RJ", new List<string> { "Rio de Janeiro", "São Gonçalo", "Duque de Caxias", "Niterói" } },
            { "RN", new List<string> { "Natal", "Mossoró", "Parnamirim" } },
            { "RS", new List<string> { "Porto Alegre", "Caxias do Sul", "Pelotas", "Canoas" } },
            { "RO", new List<string> { "Porto Velho", "Ji-Paraná", "Ariquemes" } },
            { "RR", new List<string> { "Boa Vista", "Rorainópolis" } },
            { "SC", new List<string> { "Florianópolis", "Joinville", "Blumenau", "Balneário Camboriú" } },
            { "SP", new List<string> { "São Paulo", "Campinas", "Guarulhos", "São Bernardo do Campo", "Santo André" } },
            { "SE", new List<string> { "Aracaju", "Nossa Senhora do Socorro", "Lagarto" } },
            { "TO", new List<string> { "Palmas", "Araguaína", "Gurupi" } }
        };

           
            public static string[] ObterEstados()
            {
                return cidadesPorEstado.Keys.ToArray();
            }

            public static List<string> ObterCidades(string uf)
            {
                if (!string.IsNullOrEmpty(uf) && cidadesPorEstado.ContainsKey(uf))
                {
                    return cidadesPorEstado[uf];
                }
                return new List<string>(); 
            }

            public static string[] ObterTodasAsCidades()
            {
                List<string> todasAsCidades = new List<string>();

               
                foreach (var listaDeCidades in cidadesPorEstado.Values)
                {
                    todasAsCidades.AddRange(listaDeCidades);
                }
                return todasAsCidades.Distinct().ToArray();

            }
        }
    }
}   
