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
    public partial class FormConsultarExtrasFuncionarios : Form
    {
        public FormConsultarExtrasFuncionarios()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Queres mesmo terminar o programa?", "Sair do Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void FormConsultarExtrasFuncionarios_Load(object sender, EventArgs e) {
            Extra[] extras = null;

            try {
                extras = new ExtraDBController().getAll();
            } catch {
                MessageBox.Show("Ocorreu algum erro, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
                return;
            }

            dgvExtra.Columns.Add("id", "Id");
            dgvExtra.Columns.Add("nome", "Nome");
            dgvExtra.Columns.Add("preco", "Preço");

            foreach (Extra extra in extras) {
                dgvExtra.Rows.Add(extra.id, extra.nome, extra.preco);
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
            FormAdicionarExtras formAdicionarExtras = new FormAdicionarExtras();
            formAdicionarExtras.Closed += (s, args) => this.Close();
            formAdicionarExtras.Show();
        }
    }
}
