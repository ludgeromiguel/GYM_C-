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
    public partial class FormAdicionarModalidadesAulas : Form
    {
        public FormAdicionarModalidadesAulas()
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
            FormConsultarModalidadesAulas formConsultarModalidadesAulas = new FormConsultarModalidadesAulas();
            formConsultarModalidadesAulas.Closed += (s, args) => this.Close();
            formConsultarModalidadesAulas.Show();
        }

        private void btnAdicionar_Click(object sender, EventArgs e) {
            if (txtNome.Text == String.Empty) {
                MessageBox.Show("Tens de preencher o nome da modalidade", "Aviso", MessageBoxButtons.OK);
                txtNome.Focus();
                return;
            }

            Modalidade modalidade = new Modalidade(txtNome.Text);
            Modalidade[] modalidades = null;

            try {
                modalidades = new ModalidadeDBController().searchByNomeSistema(modalidade.nomeSistema);
            } catch {
                MessageBox.Show("Ocorreu algum erro, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
                return;
            }

            if (modalidades != null && modalidades.Length > 0 && modalidades[0] != null) {
                MessageBox.Show("Ja existe uma modalidade com esse nome!", "Erro", MessageBoxButtons.OK);
                txtNome.Text = String.Empty;
                txtNome.Focus();
                return;
            }

            if (modalidade.insere()) {
                MessageBox.Show("Modalidade introduzida com sucesso", "Informação", MessageBoxButtons.OK);

                txtNome.Text = String.Empty;
            } else {
                MessageBox.Show("Ocorreu algum erro a introduzir a modalidade", "Erro", MessageBoxButtons.OK);
            }
        }
    }
}
