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

namespace Ginasio {
    public partial class FormAdicionarPlanoNutricional : Form
    {
        public int idCliente;
        Cliente cliente = null;
        public FormAdicionarPlanoNutricional()
        {
            InitializeComponent();
        }

        private void FormAdicionarAvaliacaoFisica_Load(object sender, EventArgs e)
        {
            try
            {
                cliente = new ClienteDBController().getById(idCliente);

                if (cliente == null) throw new Exception();
            }
            catch
            {
                MessageBox.Show("Ocorreu algum erro a obeter as informações do cliente", "Erro", MessageBoxButtons.OK);
                this.Hide();
                FormConsultarClientes formConsultarClientes = new FormConsultarClientes();
                formConsultarClientes.Closed += (s, args) => this.Close();
                formConsultarClientes.Show();
                return;
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormConsultarClientes formConsultarClientes = new FormConsultarClientes();
            formConsultarClientes.Closed += (s, args) => this.Close();
            formConsultarClientes.Show();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (comboBoxDiaSemana.SelectedIndex == -1)
            {
                MessageBox.Show("Tens de escolher um dia da semana", "Aviso", MessageBoxButtons.OK);
                comboBoxDiaSemana.Focus();
                return;
            }

            if (txtLancheManha.Text == String.Empty)
            {
                MessageBox.Show("Tens de preencher os dados do lanche da manhã", "Aviso", MessageBoxButtons.OK);
                txtLancheManha.Focus();
                return;
            }

            if (txtPequenoAlmoco.Text == String.Empty)
            {
                MessageBox.Show("Tens de preencher os dados do pequeno almoço", "Aviso", MessageBoxButtons.OK);
                txtPequenoAlmoco.Focus();
                return;
            }

            if (txtLancheTarde.Text == String.Empty)
            {
                MessageBox.Show("Tens de preencher os dados do lanche da tarde", "Aviso", MessageBoxButtons.OK);
                txtLancheTarde.Focus();
                return;
            }

            if (txtJantar.Text == String.Empty)
            {
                MessageBox.Show("Tens de preencher os dados do jantar", "Aviso", MessageBoxButtons.OK);
                txtJantar.Focus();
                return;
            }

            if (txtCeia.Text == String.Empty)
            {
                MessageBox.Show("Tens de preencher os dados da ceia", "Aviso", MessageBoxButtons.OK);
                txtCeia.Focus();
                return;
            }

            int diaSeman = Program.convertStringToDiaSemana(comboBoxDiaSemana.SelectedItem.ToString());

            if (diaSeman == 0)
            {
                MessageBox.Show("Escolhe um dia da semana valido", "Aviso", MessageBoxButtons.OK);
                comboBoxDiaSemana.Focus();
                return;
            }

            bool alreadyExists = false;

            if (!cliente.getPlanoNutricional())
            {
                MessageBox.Show("Ocorreu um erro a verificar se o cliente ja tem um plano nutricional para esse dia da semana", "Erro", MessageBoxButtons.OK);
                return;
            }

            foreach (PlanoNutricional planoNutricional in cliente.planoNutricional)
            {
                if (planoNutricional.diaSemana == diaSeman) alreadyExists = true;
            }

            if (alreadyExists)
            {
                MessageBox.Show("O cliente ja tem um plano nutricional para esse dia", "Erro", MessageBoxButtons.OK);
                return;
            }

            PlanoNutricional planNutricional = new PlanoNutricional(diaSeman, idCliente, txtPequenoAlmoco.Text, txtLancheManha.Text, txtAlmoco.Text, txtLancheTarde.Text, txtJantar.Text, txtCeia.Text);

            if (planNutricional.inserir())
            {
                MessageBox.Show("Plano nutricional introduzido com sucesso", "Informação", MessageBoxButtons.OK);
                comboBoxDiaSemana.SelectedIndex = -1;
                txtPequenoAlmoco.Text = String.Empty;
                txtLancheManha.Text = String.Empty;
                txtAlmoco.Text = String.Empty;
                txtLancheTarde.Text = String.Empty;
                txtJantar.Text = String.Empty;
                txtCeia.Text = String.Empty;
            }
            else
            {
                MessageBox.Show("Ocorreu algum erro a inserir o plano nutricional, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Queres mesmo terminar o programa?", "Sair do Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Application.Exit();
            }
        }
    }
}
