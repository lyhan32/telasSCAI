
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static telasSCAI.Localidade;

namespace telasSCAI
{
    public partial class AlterarEventos : Form
    {
        Evento eventoSelecionado;
        
        public AlterarEventos()
        {
            InitializeComponent();
            ConfigurarLocalidades(); 


        }
        public AlterarEventos(Evento evento)
        {
            InitializeComponent();
            ConfigurarLocalidades();
            this.eventoSelecionado = evento;
            PreencherCamposParaAlterar();

        }
        void ConfigurarLocalidades()
        {
            
            comboest.Items.Clear();
            comboest.Items.AddRange(LocalidadeService.ObterEstados());
            comboest.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboest.AutoCompleteSource = AutoCompleteSource.ListItems;

           
            string[] todasAsCidades = LocalidadeService.ObterTodasAsCidades();
            combocid.Items.Clear();
            combocid.Items.AddRange(todasAsCidades);

            combocid.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combocid.AutoCompleteSource = AutoCompleteSource.CustomSource;
            combocid.AutoCompleteCustomSource.Clear();
            combocid.AutoCompleteCustomSource.AddRange(todasAsCidades);
        }

        void PreencherCamposParaAlterar()
        {
            if(this.eventoSelecionado != null)
            {
                nome.Text = eventoSelecionado.Nome;
                descri.Text = eventoSelecionado.Descricao;
                combotipo.Text = eventoSelecionado.Tipo;
                combofre.Text = eventoSelecionado.Frequencia;
                nomelocal.Text = eventoSelecionado.NomeLocal;
                end.Text = eventoSelecionado.Endereco;
                num.Text = eventoSelecionado.Numero.ToString();
                combocid.Text = eventoSelecionado.Cidade;
                comboest.Text = eventoSelecionado.Estado;
                preco.Text = eventoSelecionado.Preco.ToString();
                capPessoa.Text = eventoSelecionado.CapacidadePessoa.ToString();
                capCarro.Text = eventoSelecionado.CapacidadeCarro.ToString();
                data.Value = eventoSelecionado.Data;
                hora.Value = DateTime.Today.Add(eventoSelecionado.Hora);
            }
           
        }
        private void AlterarEventos_Load(object sender, EventArgs e)
        {
            hora.Format = DateTimePickerFormat.Time;
            hora.ShowUpDown = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.eventoSelecionado == null)
                {
                    MessageBox.Show("Nenhum evento carregado para alteração.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Evento dadosalterados = new Evento();
               
                dadosalterados.Nome = nome.Text;
                dadosalterados.Descricao = descri.Text;
                dadosalterados.Tipo = combotipo.Text;
                dadosalterados.Frequencia = combofre.Text;
                dadosalterados.NomeLocal = nomelocal.Text;
                dadosalterados.Endereco = end.Text;
                dadosalterados.Numero = int.Parse(num.Text);
                dadosalterados.Cidade = combocid.Text;
                dadosalterados.Estado = comboest.Text;
                dadosalterados.Preco = double.Parse(preco.Text);
                dadosalterados.CapacidadePessoa = int.Parse(capPessoa.Text);
                dadosalterados.CapacidadeCarro = int.Parse(capCarro.Text);
                dadosalterados.Data = data.Value.Date;
                dadosalterados.Hora = hora.Value.TimeOfDay;
               

                
                PesquisaEventonoBanco pesq = new PesquisaEventonoBanco();
                string nomeOriginal = this.eventoSelecionado.Nome;
                int idDono = pesq.BuscarDonoDoEvento(nomeOriginal);
                if (idDono == -1)
                {
                    MessageBox.Show("Evento não encontrado no sistema.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (idDono != UsuarioLogado.Idusuario)
                {
                    MessageBox.Show("Acesso Negado!\n\nVocê não pode alterar este evento pois ele pertence a outro usuário.", "Permissão Negada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    Alterar_Excluir editar = new Alterar_Excluir();
                    bool alteradoSucesso = editar.alterarEvento(dadosalterados, nomeOriginal, UsuarioLogado.Idusuario);

                    if (alteradoSucesso)
                    {
                        MessageBox.Show("Evento atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Nenhuma alteração foi realizada no banco de dados.\n\nVerifique se ele ainda existe ou se você possui permissão (é o dono) para excluí-lo.", "Acesso Negado ou Não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, verifique os campos numéricos (Preço, Capacidade, Número).", "Erro de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar salvar alterações: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void data_ValueChanged(object sender, EventArgs e)
        {
            if (data.Value.Date == DateTime.Today)
            {
                if (hora.Value.TimeOfDay < DateTime.Now.TimeOfDay)
                {
                    hora.Value = DateTime.Now;
                }
            }
        }

        private void hora_ValueChanged(object sender, EventArgs e)
        {
            if (data.Value.Date == DateTime.Today)
            {

                if (hora.Value.TimeOfDay < DateTime.Now.TimeOfDay)
                {

                    hora.Value = DateTime.Now;

                    System.Media.SystemSounds.Beep.Play();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboestado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboest.SelectedItem != null)
            {
                string ufSelecionada = comboest.SelectedItem.ToString();
                var cidadesDoEstado = LocalidadeService.ObterCidades(ufSelecionada);

                if (cidadesDoEstado.Count > 0)
                {
                   
                    combocid.AutoCompleteCustomSource.Clear();
                    combocid.AutoCompleteCustomSource.AddRange(cidadesDoEstado.ToArray());
                }
            }

        }
    }
}
