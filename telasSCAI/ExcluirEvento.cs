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
    public partial class ExcluirEvento : Form
    {
        Evento eventoSelecionado;
        public ExcluirEvento()
        {
            InitializeComponent();
        }
        public ExcluirEvento(Evento evento)
        {
            InitializeComponent();
            this.eventoSelecionado = evento;
            PreencherCamposDaTela();
        }

        public void PreencherCamposDaTela()
        {
            if (this.eventoSelecionado != null)
            {
                textnome.Text = eventoSelecionado.Nome;
                data.Text = eventoSelecionado.Data.ToString("dd/MM/yyyy");
                hora.Text = eventoSelecionado.Hora.ToString(@"hh\:mm");
                tipo.Text = eventoSelecionado.Tipo;
                nomelocal.Text = eventoSelecionado.NomeLocal;
                end.Text = eventoSelecionado.Endereco;
                num.Text = eventoSelecionado.Numero.ToString();
                fre.Text = eventoSelecionado.Frequencia;
                preco.Text = eventoSelecionado.Preco.ToString("C");
                capcarro.Text = eventoSelecionado.CapacidadeCarro.ToString();
                cappessoa.Text = eventoSelecionado.CapacidadePessoa.ToString();
                estado.Text = eventoSelecionado.Estado;
                cid.Text = eventoSelecionado.Cidade;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.eventoSelecionado == null)
                {
                    MessageBox.Show("Nenhum evento selecionado para exclusão.");
                    return;
                }

                DialogResult resposta = MessageBox.Show($"Tem certeza absoluta que deseja excluir o evento '{this.eventoSelecionado.Nome}'?\nEsta ação não poderá ser desfeita.","Confirmar Exclusão",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

                if(resposta == DialogResult.No)
                {
                    return;
                }

                Alterar_Excluir alterarExcluir = new Alterar_Excluir();
                PesquisaEventonoBanco pesq = new PesquisaEventonoBanco();
                int idDono = pesq.BuscarDonoDoEvento(this.eventoSelecionado.Nome);

                if (idDono == -1)
                {

                    MessageBox.Show("Aviso!\n\nEste evento não foi encontrado no sistema. Ele pode já ter sido excluído.", "Não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (idDono != UsuarioLogado.Idusuario)
                {
                   
                    MessageBox.Show("Acesso Negado!\n\nVocê não tem permissão para excluir este evento porque ele pertence a outro usuário.", "Erro de Permissão", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    bool deletadoSucesso = alterarExcluir.excluirEvento(this.eventoSelecionado.Nome, UsuarioLogado.Idusuario);


                    if (deletadoSucesso)
                    {
                        MessageBox.Show("Evento excluído com sucesso do sistema!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }

                }
                   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao tentar excluir: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
