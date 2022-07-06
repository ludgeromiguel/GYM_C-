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
    public partial class FormAdicionarSubscricao : Form
    {
        public FormAdicionarSubscricao()
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
            FormConsultarSubscricoes formConsultarSubscricoes = new FormConsultarSubscricoes();
            formConsultarSubscricoes.Closed += (s, args) => this.Close();
            formConsultarSubscricoes.Show();
        }

        private void btnAdicionar_Click(object sender, EventArgs e) {
            float preco;

            if (txtNome.Text == String.Empty) {
                MessageBox.Show("Tens de preencher o nome da subscrição", "Aviso", MessageBoxButtons.OK);
                txtNome.Focus();
                return;
            }

            if (txtPreco.Text == String.Empty || !float.TryParse(txtPreco.Text, out preco) || preco <= 0) {
                MessageBox.Show("O preço tem de ser um número maior que 0", "Aviso", MessageBoxButtons.OK);
                txtPreco.Focus();
                return;
            }

            Subscricao subscricao = new Subscricao(txtNome.Text, preco, 1);

            if (subscricao.inserir()) {
                MessageBox.Show("Subscrição criada com sucesso!", "Informação", MessageBoxButtons.OK);

                txtNome.Text = String.Empty;
                txtPreco.Text = String.Empty;
            } else {
                MessageBox.Show("Ocorreu algum erro a criar a subscrição", "Erro", MessageBoxButtons.OK);
            }
        }
    }
}
