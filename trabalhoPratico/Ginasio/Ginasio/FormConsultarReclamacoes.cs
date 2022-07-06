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
    public partial class FormConsultarReclamacoes : Form
    {
        public FormConsultarReclamacoes()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Queres mesmo terminar o programa?", "Sair do Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void FormConsultarReclamacoes_Load(object sender, EventArgs e) {
            LivroReclamacao[] reclamacoes = null;

            try {
                reclamacoes = new LivroReclamacoesDBController().getAll();
            } catch {
                MessageBox.Show("Ocorreu algum erro, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
            }

            dgvReclamacoes.Columns.Add("id", "Id");
            dgvReclamacoes.Columns.Add("descricao", "Descrição");
            dgvReclamacoes.Columns.Add("cliente", "Cliente");
            dgvReclamacoes.Columns.Add("tipoReclamacao", "Tipo Reclamação");

            foreach (LivroReclamacao reclamacao in reclamacoes) {
                string cliente = "Não encontrado", tipoReclamao = "Não encontrado";

                if (reclamacao.getTipoReclamacao()) tipoReclamao = reclamacao.tipoReclamacao.nome;
                if (reclamacao.getCliente()) cliente = reclamacao.cliente.primNome + " " + reclamacao.cliente.ultNome;

                dgvReclamacoes.Rows.Add(reclamacao.id, reclamacao.descricao, cliente, tipoReclamao);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            this.Hide();
            FormMenuFuncionario formMenuFuncionario = new FormMenuFuncionario();
            formMenuFuncionario.Closed += (s, args) => this.Close();
            formMenuFuncionario.Show();
        }
    }
}
