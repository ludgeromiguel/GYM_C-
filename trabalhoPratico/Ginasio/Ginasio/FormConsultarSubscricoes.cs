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
    public partial class FormConsultarSubscricoes : Form
    {
        public FormConsultarSubscricoes()
        {
            InitializeComponent();
        }

        private void FormConsultarSubscricoes_Load(object sender, EventArgs e) {
            Subscricao[] subscricoes = null;

            try {
                subscricoes = new SubscricaoDBController().getAll();
            } catch {
                MessageBox.Show("Ocorreu algum erro, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
            }

            dgvSubscricoes.Columns.Add("id", "ID");
            dgvSubscricoes.Columns.Add("nome", "Nome");
            dgvSubscricoes.Columns.Add("preco", "Preço");

            foreach (Subscricao subscricao in subscricoes) {
                dgvSubscricoes.Rows.Add(subscricao.id, subscricao.nome, subscricao.preco);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Queres mesmo terminar o programa?", "Sair do Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e) {
            this.Hide();
            FormAdicionarSubscricao formAdicionarSubscricao = new FormAdicionarSubscricao();
            formAdicionarSubscricao.Closed += (s, args) => this.Close();
            formAdicionarSubscricao.Show();
        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            this.Hide();
            FormMenuFuncionario formMenuFuncionario = new FormMenuFuncionario();
            formMenuFuncionario.Closed += (s, args) => this.Close();
            formMenuFuncionario.Show();
        }
    }
}
