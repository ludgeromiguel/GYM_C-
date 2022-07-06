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
    public partial class FormAdicionarAvaliacaoFisica : Form
    {
        public int idCliente;
        Cliente cliente = null;

        public FormAdicionarAvaliacaoFisica()
        {
            InitializeComponent();
        }

        private void FormAdicionarAvaliacaoFisica_Load(object sender, EventArgs e) {
            try {
                cliente = new ClienteDBController().getById(idCliente);

                if (cliente == null) throw new Exception();
            } catch {
                MessageBox.Show("Ocorreu algum erro a obeter as informações do cliente", "Erro", MessageBoxButtons.OK);

                this.Hide();
                FormConsultarClientes formConsultarClientes = new FormConsultarClientes();
                formConsultarClientes.Closed += (s, args) => this.Close();
                formConsultarClientes.Show();
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            this.Hide();
            FormConsultarClientes formConsultarClientes = new FormConsultarClientes();
            formConsultarClientes.Closed += (s, args) => this.Close();
            formConsultarClientes.Show();
        }

        private void btnAdicionar_Click(object sender, EventArgs e) {
            float peso, gordura, massaMuscula;
            int tamanho;

            if (txtPeso.Text == String.Empty || !float.TryParse(txtPeso.Text, out peso) || peso <= 0) {
                MessageBox.Show("O peso tem de ser um número maior que 0", "Aviso", MessageBoxButtons.OK);
                txtPeso.Focus();
                return;
            } 

            if (txtGordura.Text == String.Empty || !float.TryParse(txtGordura.Text, out gordura) || gordura <= 0) {
                MessageBox.Show("A gordura tem de ser um número maior que 0", "Aviso", MessageBoxButtons.OK);
                txtGordura.Focus();
                return;
            }

            if (txtMassaMuscular.Text == String.Empty || !float.TryParse(txtMassaMuscular.Text, out massaMuscula) || massaMuscula <= 0) {
                MessageBox.Show("A massa muscular tem de ser um número maior que 0", "Aviso", MessageBoxButtons.OK);
                txtMassaMuscular.Focus();
                return;
            }

            if (txtTamanho.Text == String.Empty || !int.TryParse(txtTamanho.Text, out tamanho) || tamanho <= 0) {
                MessageBox.Show("O tamanho tem de ser um número maior que 0", "Aviso", MessageBoxButtons.OK);
                txtTamanho.Focus();
                return;
            }

            AvaliacaoFisica avaliacaoFisica = new AvaliacaoFisica(idCliente, peso, tamanho, gordura, massaMuscula, DateTime.Now);

            if (avaliacaoFisica.inserir()) {
                MessageBox.Show("Avaliaçõa fisica introduzida com sucesso", "Informação", MessageBoxButtons.OK);

                txtPeso.Text = String.Empty;
                txtTamanho.Text = String.Empty;
                txtGordura.Text = String.Empty;
                txtMassaMuscular.Text = String.Empty;
            } else {
                MessageBox.Show("Ocorreu algum erro a inserir a avaliação fisica, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Queres mesmo terminar o programa?", "Sair do Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Application.Exit();
            }
        }
    }
}

