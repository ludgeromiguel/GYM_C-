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
    public partial class FormConsultarModalidadesAulas : Form
    {
        public FormConsultarModalidadesAulas()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Queres mesmo terminar o programa?", "Sair do Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void FormConsultarModalidadesAulas_Load(object sender, EventArgs e) {
            Modalidade[] modalidades = null;

            try {
                modalidades = new ModalidadeDBController().getAll();
            } catch {
                MessageBox.Show("Ocorreu algum erro, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
            }

            dgvModalidadesAula.Columns.Add("id", "Id");
            dgvModalidadesAula.Columns.Add("nome", "Nome");

            foreach (Modalidade modalidade in modalidades) {
                dgvModalidadesAula.Rows.Add(modalidade.id, modalidade.nome);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            this.Hide();
            FormMenuFuncionario formMenuFuncionario = new FormMenuFuncionario();
            formMenuFuncionario.Closed += (s, args) => this.Close();
            formMenuFuncionario.Show();
        }

        private void btnAdicionar_Click(object sender, EventArgs e) {
            this.Hide();
            FormAdicionarModalidadesAulas formAdicionarModalidades = new FormAdicionarModalidadesAulas();
            formAdicionarModalidades.Closed += (s, args) => this.Close();
            formAdicionarModalidades.Show();
        }
    }
}
