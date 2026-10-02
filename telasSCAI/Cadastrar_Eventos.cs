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
    public partial class Cadastrar : Form
    {
    
        public Cadastrar()
        {
            InitializeComponent();
            comboestado.Items.AddRange(LocalidadeService.ObterEstados());
            comboestado.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboestado.AutoCompleteSource = AutoCompleteSource.ListItems;

            string[] todasAsCidades = LocalidadeService.ObterTodasAsCidades();

            combocidade.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combocidade.AutoCompleteSource = AutoCompleteSource.CustomSource;
            combocidade.AutoCompleteCustomSource.AddRange(todasAsCidades);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
               

                Evento dados = new Evento();

                dados.Nome = nome.Text.Trim();
                dados.Descricao = descricao.Text.Trim();
                dados.NomeLocal = nomelocal.Text.Trim();
                dados.Endereco = end.Text.Trim();
                dados.Data = data.Value;
                dados.Hora = hora.Value.TimeOfDay;

                dados.Tipo = combotipo.Text.Trim();
                dados.Cidade = combocidade.Text.Trim();
                dados.Estado = comboestado.Text.Trim();
                dados.Frequencia = combofre.SelectedItem.ToString().Trim();

                double.TryParse(preco.Text, out double p); dados.Preco = p;
                int.TryParse(num.Text, out int n); dados.Numero = n;
                int.TryParse(capcarro.Text, out int cc); dados.CapacidadeCarro = cc;
                int.TryParse(capPessoa.Text, out int cp); dados.CapacidadePessoa = cp;

                string mensagemDeErroDoValidador;
                bool dadosValidos = Validador.ValidarCadastroEvento(dados, out mensagemDeErroDoValidador);

                if (!dadosValidos)
                {
                    MessageBox.Show(mensagemDeErroDoValidador, "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                CadEvento cad = new CadEvento();

                string motivoduplicado;
                bool duplicado = cad.verificarEventoDuplicado(dados.Nome, dados.Data, dados.Hora, out motivoduplicado);

                if (duplicado)
                {
                    MessageBox.Show(motivoduplicado, "Conflito de Agenda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                bool resultado = cad.cadastrarEvento(dados);

                if (resultado)
                {
                    MessageBox.Show("Evento cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocorreu algum problema interno no cadastro. O banco rejeitou os dados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no formulário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Cadastrar_Load(object sender, EventArgs e)
        {
            data.MinDate = DateTime.Today;
            hora.Format = DateTimePickerFormat.Time;
            hora.ShowUpDown = true;

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

        private void comboestado_SelectedIndexChanged(object sender, EventArgs e)
        {
             

            if (comboestado.SelectedItem != null)
            {
                string ufSelecionada = comboestado.SelectedItem.ToString();

                var cidades = LocalidadeService.ObterCidades(ufSelecionada);

                if (cidades.Count > 0)
                {
                   
                    string[] arrayCidades = cidades.ToArray();

               
                    combocidade.Items.AddRange(arrayCidades);

             
                    combocidade.AutoCompleteCustomSource.AddRange(arrayCidades);
                }
            }
        }

        private void combocidade_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
