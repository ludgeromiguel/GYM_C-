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
    public partial class FormReclamacoes : Form
    {
        public FormReclamacoes()
        {
            InitializeComponent();
        }

        private void FormReclamacoes_Load(object sender, EventArgs e) {
            if (!Program.clienteData.getReclamacoesCliente()) {
                MessageBox.Show("Ocorreu algum erro, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
            }

            dgvReclamacoes.Columns.Add("id", "Id");
            dgvReclamacoes.Columns.Add("descricao", "Descrição");
            dgvReclamacoes.Columns.Add("cliente", "Cliente");
            dgvReclamacoes.Columns.Add("tipoReclamacao", "Tipo Reclamação");

            foreach (LivroReclamacao reclamacao in Program.clienteData.reclamacoes) {
                string cliente = "Não encontrado", tipoReclamao = "Não encontrado";

                if (reclamacao.getTipoReclamacao()) tipoReclamao = reclamacao.tipoReclamacao.nome;
                if (reclamacao.getCliente()) cliente = reclamacao.cliente.primNome + " " + reclamacao.cliente.ultNome;

                dgvReclamacoes.Rows.Add(reclamacao.id, reclamacao.descricao, cliente, tipoReclamao);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            this.Hide();
            FormMenuCliente formMenuCliente = new FormMenuCliente();
            formMenuCliente.Closed += (s, args) => this.Close();
            formMenuCliente.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Queres mesmo terminar o programa?", "Sair do Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void btnCriarReclamacao_Click(object sender, EventArgs e) {
            this.Hide();
            FormAdicionarReclamacao formAdicionarReclamacao = new FormAdicionarReclamacao();
            formAdicionarReclamacao.Closed += (s, args) => this.Close();
            formAdicionarReclamacao.Show();
        }
    }
}
