using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ginasio.Classes;
using Ginasio.DatabaseControllers;

namespace Ginasio
{
    public partial class FormAlterarSubscricao : Form
    {
        public FormAlterarSubscricao()
        {
            InitializeComponent();
        }

        private void FormAlterarSubscricao_Load(object sender, EventArgs e) {
            Subscricao[] subscricoes = null;

            try {
                subscricoes = new SubscricaoDBController().getAll();

                if (subscricoes == null) throw new Exception("Não existe subscrições");

                int contador = 0;

                foreach (Subscricao subscricao in subscricoes) {
                    if (subscricao.isActive == 1) contador++;
                }

                if (contador == 0) throw new Exception("Não existe nenhuma subscrição valida");
            } catch {
                MessageBox.Show("Não é possivel abrir o menu de alterar subscrição pois não existe nenhuma subscrição", "Erro", MessageBoxButtons.OK);

                this.Hide();
                FormMenuCliente formMenuCliente = new FormMenuCliente();
                formMenuCliente.Closed += (s, args) => this.Close();
                formMenuCliente.Show();
            }

            foreach (Subscricao subscricao in subscricoes) {
                if (subscricao.isActive == 0) continue;

                string subscricaoName = "Id: " + subscricao.id + "-Nome: " + subscricao.nome + "-Preço: " + subscricao.preco;

                comboBoxSubscricoes.Items.Add(subscricaoName);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e) {
            if (comboBoxSubscricoes.SelectedIndex == -1) {
                MessageBox.Show("Tens de selecionar uma subscrição", "Aviso", MessageBoxButtons.OK);
                comboBoxSubscricoes.Focus();
                return;
            }

            int idSubscricao = Convert.ToInt32(comboBoxSubscricoes.SelectedItem.ToString().Split('-')[0].Split(':')[1]);

            if (dataPickerFimSubscricao.Value <= DateTime.Now) {
                MessageBox.Show("O fim da subscrição não pode ser menor que a data de hoje");
                dataPickerFimSubscricao.Focus();
                return;
            }

            Program.clienteData.idSubscricao = idSubscricao;
            Program.clienteData.inicioSubscricao = DateTime.Now;
            Program.clienteData.fimSubscricao = dataPickerFimSubscricao.Value;

            if (Program.clienteData.alterar()) {
                MessageBox.Show("Subscrição alterada com sucesso", "Informação", MessageBoxButtons.OK);

                this.Hide();
                FormMenuCliente formMenuCliente = new FormMenuCliente();
                formMenuCliente.Closed += (s, args) => this.Close();
                formMenuCliente.Show();
            } else {
                MessageBox.Show("Ocorreu algum erro a alterar a subscrição", "Erro", MessageBoxButtons.OK);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Queres mesmo terminar o programa?", "Sair do Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            this.Hide();
            FormMenuCliente formMenuCliente = new FormMenuCliente();
            formMenuCliente.Closed += (s, args) => this.Close();
            formMenuCliente.Show();
        }
    }
}
