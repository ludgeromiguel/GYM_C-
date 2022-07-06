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
    public partial class FormAdicionarTiposReclamacoes : Form
    {
        public FormAdicionarTiposReclamacoes()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Queres mesmo terminar o programa?", "Sair do Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            this.Hide();
            FormMenuConsultarTiposReclamacao formMenuConsultarTiposReclamacao = new FormMenuConsultarTiposReclamacao();
            formMenuConsultarTiposReclamacao.Closed += (s, args) => this.Close();
            formMenuConsultarTiposReclamacao.Show();
        }

        private void btnAdicionar_Click(object sender, EventArgs e) {
            if (txtNome.Text == String.Empty) {
                MessageBox.Show("Tens de preencher o nome do tipo de reclamação", "Aviso", MessageBoxButtons.OK);
                txtNome.Focus();
                return;
            }

            TipoReclamacao tipoReclamacao = new TipoReclamacao(txtNome.Text);
            TipoReclamacao[] tiposReclamacao = null;

            try {
                tiposReclamacao = new TipoReclamacaoDBController().searchByNomeSistema(tipoReclamacao.nomeSistema);
            } catch {
                MessageBox.Show("Ocorreu algum erro, por favor tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
                return;
            }

            if (tiposReclamacao != null && tiposReclamacao.Length > 0 && tiposReclamacao[0] != null) {
                MessageBox.Show("Ja existe um tipo de reclamação com esse nome", "Erro", MessageBoxButtons.OK);
                txtNome.Text = String.Empty;
                txtNome.Focus();
                return;
            }

            if (tipoReclamacao.inserir()) {
                MessageBox.Show("Tipo de reclamação introduzida com sucesso", "Informação", MessageBoxButtons.OK);

                txtNome.Text = String.Empty;
            } else {
                MessageBox.Show("Ocorreu algum erro a introfuzir o tipo de reclamação", "Erro", MessageBoxButtons.OK);
            }
        }
    }
}
