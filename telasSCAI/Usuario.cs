using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telasSCAI
{
    public class Usuario
    {
        string email;
        string senha;
        string nome;
        int IdUsuario;

        public Usuario()
        {
            email = "";
            senha = "";
            nome = "";
        }

      public string Email { get => email; set => email = value; }
      public string Senha { get => senha; set => senha = value; }
      public string Nome { get => nome; set => nome = value; }
      public int Idusuario { get => IdUsuario; set => IdUsuario = value; }

       
    }
}
