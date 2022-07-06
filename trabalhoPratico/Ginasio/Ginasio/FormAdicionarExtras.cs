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

namespace Ginasio
{
    public partial class FormAdicionarExtras : Form
    {
        public FormAdicionarExtras()
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
            FormConsultarExtrasFuncionarios formConsultarExtras = new FormConsultarExtrasFuncionarios();
            formConsultarExtras.Closed += (s, args) => this.Close();
            formConsultarExtras.Show();
        }

        private void btnAdicionar_Click(object sender, EventArgs e) {
            float preco;

            if (txtNome.Text == String.Empty) {
                MessageBox.Show("Tens de introduzir o nome do extra", "Aviso", MessageBoxButtons.OK);
                txtNome.Focus();
                return;
            }

            if (txtPreco.Text == String.Empty || !float.TryParse(txtPreco.Text, out preco) || preco <= 0) {
                MessageBox.Show("O preço tem de ser um número maior que 0", "Aviso", MessageBoxButtons.OK);
                txtPreco.Focus();
                return;
            }

            Extra extra = new Extra(txtNome.Text, preco);

            if (extra.inserir()) {
                MessageBox.Show("Extra criado com sucesso", "Informação", MessageBoxButtons.OK);

                txtNome.Text = String.Empty;
                txtPreco.Text = String.Empty;
            } else {
                MessageBox.Show("Ocorreu algum erro a criar o extra", "Aviso", MessageBoxButtons.OK);
            }
        }
    }
}
