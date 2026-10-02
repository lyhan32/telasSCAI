using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace telasSCAI
{
    public static class Validador
    {
        public static bool ValidarCadastroEvento(Evento dados, out string mensagemErro)
        {
            mensagemErro = string.Empty;

            if (string.IsNullOrWhiteSpace(dados.Nome) ||
                string.IsNullOrWhiteSpace(dados.Descricao) ||
                string.IsNullOrWhiteSpace(dados.Tipo) ||
                string.IsNullOrWhiteSpace(dados.Frequencia) ||
                string.IsNullOrWhiteSpace(dados.NomeLocal) ||
                string.IsNullOrWhiteSpace(dados.Endereco) ||
                string.IsNullOrWhiteSpace(dados.Cidade) ||
                string.IsNullOrWhiteSpace(dados.Estado))
            {
                mensagemErro = "Por favor, preencha todos os campos obrigatórios do cadastro!";
                return false;
            }
            if (dados.Numero <= 0)
            {
                mensagemErro = "Por favor, insira um número de endereço válido (maior que zero)!";
                return false;
            }

            if (dados.CapacidadePessoa <= 0)
            {
                mensagemErro = "Por favor, informe a capacidade de pessoas (deve ser maior que zero)!";
                return false;
            }

            if (dados.Preco < 0)
            {
                mensagemErro = "O preço do evento não pode ser um valor negativo!";
                return false;
            }


            return true;
        }

        public static bool ValidarLogin(Usuario dados, out string mensagemErro)
        {
            mensagemErro = string.Empty;
           
            if (string.IsNullOrWhiteSpace(dados.Email) || !dados.Email.Contains("@"))
            {
                mensagemErro = "Por favor, insira um e-mail válido!";
                
                return false;
            }
            if (string.IsNullOrWhiteSpace(dados.Senha))
            {
                mensagemErro = "O campo 'Senha' não pode ficar vazio!";
                
                return false;
            }
            return true;
        }
        public static bool ValidarCadastroUsuario(Usuario dados, out string mensagemErro, out string campoFoco)
        {
            mensagemErro = string.Empty;
            campoFoco = string.Empty;


            if (string.IsNullOrWhiteSpace(dados.Nome))
            {
                mensagemErro = "O campo 'Nome' é obrigatório!";
                campoFoco = "txtnome";
                return false;
            }
            if (string.IsNullOrWhiteSpace(dados.Email) || !dados.Email.Contains("@"))
            {
                mensagemErro = "Por favor, insira um e-mail válido!";
                campoFoco = "txtemail";
                return false;
            }
            if (string.IsNullOrWhiteSpace(dados.Senha))
            {
                mensagemErro = "O campo 'Senha' não pode ficar vazio!";
                campoFoco = "txtsenha";
                return false;
            }



            if (dados.Senha.Length > 8)
            {
                mensagemErro = "A senha é muito longa! Ela deve ter no máximo 8 caracteres.";
                campoFoco = "txtsenha";
                return false;
            }


            if (!Regex.IsMatch(dados.Senha, @"[a-zA-Z]"))
            {
                mensagemErro = "A senha deve conter pelo menos uma letra!";
                campoFoco = "txtsenha";
                return false;
            }


            if (!Regex.IsMatch(dados.Senha, @"[^\w\s]"))
            {
                mensagemErro = "A senha deve conter pelo menos um símbolo ou caractere especial (ex: @, #, $, !, *).";
                campoFoco = "txtsenha";
                return false;
            }


            return true;
        }
    }
}
