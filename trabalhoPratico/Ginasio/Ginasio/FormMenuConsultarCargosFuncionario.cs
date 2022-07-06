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
    public partial class FormMenuConsultarCargosFuncionario : Form
    {
        public FormMenuConsultarCargosFuncionario()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Queres mesmo terminar o programa?", "Sair do Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void FormMenuConsultarCargosFuncionario_Load(object sender, EventArgs e) {
            Cargo[] cargos = null;

            try {
                cargos = new CargoDBController().getAll();
            } catch {
                MessageBox.Show("Ocorreu algum erro, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
            }

            dgvCargos.Columns.Add("id", "Id");
            dgvCargos.Columns.Add("nome", "Nome");

            foreach (Cargo cargo in cargos) {
                dgvCargos.Rows.Add(cargo.id, cargo.nome);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e) {
            this.Hide();
            FormAdicionarCargoFuncionario formAdicionarCargoFuncionario = new FormAdicionarCargoFuncionario();
            formAdicionarCargoFuncionario.Closed += (s, args) => this.Close();
            formAdicionarCargoFuncionario.Show();
        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            this.Hide();
            FormMenuFuncionario formMenuFuncionario = new FormMenuFuncionario();
            formMenuFuncionario.Closed += (s, args) => this.Close();
            formMenuFuncionario.Show();
        }
    }
}
