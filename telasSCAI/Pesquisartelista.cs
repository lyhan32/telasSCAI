using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace telasSCAI
{
    public partial class fmPesquisar : Form
    {
        string modoAcao;
        public fmPesquisar()
        {
            InitializeComponent();
            this.modoAcao = "PESQUISAR";
        }
        public fmPesquisar(string modo)
        {
            InitializeComponent();
            this.modoAcao = modo.ToUpper();
        }

        public fmPesquisar(bool filtrarHoje)
        {
            InitializeComponent();
            this.modoAcao = "PESQUISAR";

            if (filtrarHoje)
            {
                this.Load += (sender, e) =>
                {
                    checkData.Checked = true;
                    dateEvento.Value = DateTime.Today;
                    button1_Click(button1, EventArgs.Empty);
                };
            }
        }

       
        private void button4_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                PesquisaEventonoBanco evento = new PesquisaEventonoBanco();

                if (checknome.Checked)
                {
                    List<string> listnome = evento.Eventopornome(BoxNome.Text);
                    listBoxPesq.Items.Clear();
                    if (listnome.Count > 0)
                    {
                        foreach (string nome in listnome)
                        {
                            listBoxPesq.Items.Add(nome);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nenhum evento encontrado com esse nome!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }

                }
                if (checkData.Checked)
                {

                    List<string> listdata = evento.EventoporData(dateEvento.Value);
                    listBoxPesq.Items.Clear();

                    if (listdata.Count > 0)
                    {
                        foreach (string nome in listdata)
                        {
                            listBoxPesq.Items.Add(nome);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nenhum evento encontrado com essa data!","Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      
                    }
                }

                if (radiomes.Checked)
                {
                    int mes = dateTimeMes.Value.Month;
                    List<string> listmes = evento.Eventopormes(mes);
                    listBoxPesq.Items.Clear();
                    if (listmes.Count > 0)
                    {
                        foreach (string nome in listmes)
                        {
                            listBoxPesq.Items.Add(nome);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nenhum evento encontrado com esse mês!","Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                    }
                }
                    if(radiotipo.Checked)
                    {
                        string tipo = combotipo.Text;
                    
                        List<string> listtipo = evento.EventoPorTipo(tipo);
                        listBoxPesq.Items.Clear();
                        if (listtipo != null && listtipo.Count > 0)
                        {
                            foreach (string nome in listtipo)
                            {
                                listBoxPesq.Items.Add(nome);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nenhum evento encontrado com esse tipo!","Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           
                        }
                    }
           
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro no MySQL:" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar com o banco de dados!" + ex.Message);

            }
        }
    

        private void checkData_CheckedChanged(object sender, EventArgs e)
        {
            NEvento.Text = "Data do Evento:";
            BoxNome.Visible = false;
            dateEvento.Visible = true;
            dateTimeMes.Visible = false;
            combotipo.Visible = false;
        }

        private void checknome_CheckedChanged(object sender, EventArgs e)
        {
            NEvento.Text = "Nome do Evento:";
            BoxNome.Visible = true;
            dateEvento.Visible = false;
            dateTimeMes.Visible = false;
            combotipo.Visible = false;
        }

        private void radiomes_CheckedChanged(object sender, EventArgs e)
        {
            NEvento.Text = "Mês do Evento:";
            BoxNome.Visible = false;
            dateTimeMes.Visible = true;
            dateEvento.Visible = false;
            combotipo.Visible = false;
           
        }

        private void listBoxPesq_DoubleClick(object sender, EventArgs e)
        {
            try
            {
             
                if (listBoxPesq.SelectedItem == null)

                    return;

                string nomeEvento = listBoxPesq.SelectedItem.ToString().Trim();

                PesquisaEventonoBanco eventoBanco = new PesquisaEventonoBanco();
                Evento eventoEncontrado = eventoBanco.BuscarEvento(nomeEvento);
                if (eventoEncontrado != null)
                {
                    switch (this.modoAcao)
                    {
                        case "ALTERAR":
                            AlterarEventos telaAlterar = new AlterarEventos(eventoEncontrado);
                            telaAlterar.ShowDialog();
                            button1_Click(button1, EventArgs.Empty);
                            break;
                        case "EXCLUIR":
                            ExcluirEvento telaExcluir = new ExcluirEvento(eventoEncontrado);
                            telaExcluir.ShowDialog();
                            button1_Click(button1, EventArgs.Empty);
                            break;
                        case "PESQUISAR":

                            this.Hide();
                            using (PesquisarEventos evento = new PesquisarEventos(eventoEncontrado))
                            {
                                evento.ShowDialog();
                            }
                            this.Show();
                            listBoxPesq.ClearSelected();
                            break;
                    }


                }
                else
                {
                  
                    MessageBox.Show("O evento '" + nomeEvento + "' não foi encontrado no banco de dados.");
                }


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro no MySQL:" + ex.Message);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao conectar com o banco de dados!" + ex.Message);

            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            NEvento.Text = "Tipo do Evento:";
            
            BoxNome.Visible = false;
            dateTimeMes.Visible = false;
            combotipo.Visible = true;
            dateEvento.Visible = false;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EventosPassados passado = new EventosPassados();
            passado.ShowDialog();

        }
        
    }
}
