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
    public partial class FormAdicionarReclamacao : Form
    {
        public FormAdicionarReclamacao()
        {
            InitializeComponent();
        }

        private void FormAdicionarReclamacao_Load(object sender, EventArgs e) {
            TipoReclamacao[] tiposReclamacao = null;

            try {
                tiposReclamacao = new TipoReclamacaoDBController().getAll();

                if (tiposReclamacao == null) throw new Exception();
            } catch {
                MessageBox.Show("Não existe nenhum tipo de reclamação, então não é possível fazer uma reclamação");

                this.Hide();
                FormMenuCliente formMenuCliente = new FormMenuCliente();
                formMenuCliente.Closed += (s, args) => this.Close();
                formMenuCliente.Show();
            }

            foreach (TipoReclamacao tipoReclamacao in tiposReclamacao) {
                string nomeReclamacao = "Id: " + tipoReclamacao.id + "-Nome: " + tipoReclamacao.nome;

                comboBoxTipoReclamacao.Items.Add(nomeReclamacao);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Queres mesmo terminar o programa?", "Sair do Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            this.Hide();
            FormReclamacoes formReclamacoes = new FormReclamacoes();
            formReclamacoes.Closed += (s, args) => this.Close();
            formReclamacoes.Show();
        }

        private void btnAdicionar_Click(object sender, EventArgs e) {
            if (txtDescricao.Text == String.Empty) {
                MessageBox.Show("Tens de preencher a descrição da reclamação", "Aviso", MessageBoxButtons.OK);
                txtDescricao.Focus();
                return;
            }

            if (comboBoxTipoReclamacao.SelectedIndex == -1) {
                MessageBox.Show("Tens de selecionar um tipo de reclamação", "Aviso", MessageBoxButtons.OK);
                comboBoxTipoReclamacao.Focus();
                return;
            }

            int idTipoReclamao = Convert.ToInt32(comboBoxTipoReclamacao.SelectedItem.ToString().Split('-')[0].Split(':')[1]);

            LivroReclamacao livroReclamacao = new LivroReclamacao(txtDescricao.Text, Program.clienteData.id, idTipoReclamao);

            if (livroReclamacao.inserir()) {
                MessageBox.Show("Alteração salva com sucesso", "Informação", MessageBoxButtons.OK);

                txtDescricao.Text = String.Empty;
                comboBoxTipoReclamacao.SelectedIndex = -1;
            } else {
                MessageBox.Show("Não foi possivel salvar a reclamação, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
            }
        }
    }
}
