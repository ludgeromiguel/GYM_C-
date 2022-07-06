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
    public partial class FormMenuConsultarTiposReclamacao : Form
    {
        public FormMenuConsultarTiposReclamacao()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Queres mesmo terminar o programa?", "Sair do Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void FormMenuConsultarTiposReclamacao_Load(object sender, EventArgs e) {
            TipoReclamacao[] tiposReclamacao = null;

            try {
                tiposReclamacao = new TipoReclamacaoDBController().getAll();
            } catch {
                MessageBox.Show("Ocorreu algum erro, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
            }

            dgvTipoReclamacao.Columns.Add("id", "Id");
            dgvTipoReclamacao.Columns.Add("nome", "Nome");

            foreach (TipoReclamacao tipoReclamacao in tiposReclamacao) {
                dgvTipoReclamacao.Rows.Add(tipoReclamacao.id, tipoReclamacao.nome);
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
            FormAdicionarTiposReclamacoes formAdicionarTiposReclamacoes = new FormAdicionarTiposReclamacoes();
            formAdicionarTiposReclamacoes.Closed += (s, args) => this.Close();
            formAdicionarTiposReclamacoes.Show();
        }
    }
}
