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
    public partial class FormConsultarClientes : Form {
        public FormConsultarClientes() {
            InitializeComponent();
        }

        private void FormConsultarClientes_Load(object sender, EventArgs e) {
            Cliente[] clientes = null;

            try {
                clientes = new ClienteDBController().getAll();
            } catch {
                MessageBox.Show("Ocorreu um erro a obeter os utilizadores", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAdicionar.Enabled = false;
                btnConsultar.Enabled = false;
                return;
            }

            dgvClientes.Columns.Add("id", "Id");
            dgvClientes.Columns.Add("primNome", "Primeiro Nome");
            dgvClientes.Columns.Add("ultNome", "Ultimo Nome");
            dgvClientes.Columns.Add("dataNascimento", "Data de Nascimento");
            dgvClientes.Columns.Add("nif", "Nif");
            dgvClientes.Columns.Add("genero", "Genero");
            dgvClientes.Columns.Add("telefone", "Telefone");
            dgvClientes.Columns.Add("email", "Email");
            dgvClientes.Columns.Add("morada", "Morada");
            dgvClientes.Columns.Add("subscricao", "Subscrição");
            dgvClientes.Columns.Add("inicioSubscricao", "Inicio Subscrição");
            dgvClientes.Columns.Add("fimSubscricao", "Fim Subscrição");

            foreach (Cliente cliente in clientes) {
                string subscricaoNome = "Não encontrada";

                if (cliente.getSubscricaoData()) subscricaoNome = cliente.subscricao.nome;

                dgvClientes.Rows.Add(cliente.id, cliente.primNome, cliente.ultNome, Program.convertDateToString(cliente.dataNascimento), cliente.nif, cliente.genero == "m" ? "Masculino" : "Femenino"
                                     , cliente.telefone, cliente.email, cliente.morada, subscricaoNome, Program.convertDateToString(cliente.inicioSubscricao), Program.convertDateToString(cliente.fimSubscricao));
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e) {
            if (dgvClientes.SelectedRows.Count != 1) {
                MessageBox.Show("Tens de ter um e apenas um registo selecionado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FormConsultarcliente formConsultarcliente = new FormConsultarcliente();
            formConsultarcliente.idCliente = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["id"].Value);
            formConsultarcliente.Show();
        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            this.Hide();
            FormMenuFuncionario formMenuFuncionario = new FormMenuFuncionario();
            formMenuFuncionario.Closed += (s, args) => this.Close();
            formMenuFuncionario.Show();
        }

        private void btnAdicionarAvaliacaoFisica_Click(object sender, EventArgs e) {
            if (dgvClientes.SelectedRows.Count != 1) {
                MessageBox.Show("Tens de ter um e apenas um registo selecionado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Hide();
            FormAdicionarAvaliacaoFisica formAdicionarAvaliacaoFisica = new FormAdicionarAvaliacaoFisica();
            formAdicionarAvaliacaoFisica.idCliente = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["id"].Value);
            formAdicionarAvaliacaoFisica.Closed += (s, args) => this.Close();
            formAdicionarAvaliacaoFisica.Show();
        }

        private void btnAdicionarPlanoNutricional_Click(object sender, EventArgs e) {
            if (dgvClientes.SelectedRows.Count != 1) {
                MessageBox.Show("Tens de ter um e apenas um registo selecionado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Hide();
            FormAdicionarPlanoNutricional formAdicionarPlanoNutricional = new FormAdicionarPlanoNutricional();
            formAdicionarPlanoNutricional.idCliente = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["id"].Value);
            formAdicionarPlanoNutricional.Closed += (s, args) => this.Close();
            formAdicionarPlanoNutricional.Show();
        }

        private void btnAdicionar_Click(object sender, EventArgs e) {
            this.Hide();
            FormCriarCliente formCriarCliente = new FormCriarCliente();
            formCriarCliente.createdByAdmin = 1;
            formCriarCliente.Closed += (s, args) => this.Close();
            formCriarCliente.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Queres mesmo terminar o programa?", "Sair do Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Application.Exit();
            }
        }
    }
}
