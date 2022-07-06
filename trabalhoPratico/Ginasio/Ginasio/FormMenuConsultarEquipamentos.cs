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
    public partial class FormMenuConsultarEquipamentos : Form
    {
        public FormMenuConsultarEquipamentos()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Queres mesmo terminar o programa?", "Sair do Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void FormMenuConsultarEquipamentos_Load(object sender, EventArgs e) {
            Equipamento[] equipamentos = null;

            try {
                equipamentos = new EquipamentoDBController().getAll();
            } catch {
                MessageBox.Show("Ocorreu algum erro, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
            }

            dgvEquipamento.Columns.Add("id", "Id");
            dgvEquipamento.Columns.Add("nome", "Nome");
            dgvEquipamento.Columns.Add("quantidade", "Quantidade");
            dgvEquipamento.Columns.Add("tipoEquipamento", "Tipo Equipamento");
            dgvEquipamento.Columns.Add("funcionario", "Funcionario");

            foreach (Equipamento equipamento in equipamentos) {
                string tipoEquipamento = "Não encontrado", funcionario = "Não encontrado";

                if (equipamento.getFuncionario()) funcionario = equipamento.funcionario.primNome + " " + equipamento.funcionario.ultNome;
                if (equipamento.getTipoEquipamento()) tipoEquipamento = equipamento.tipoEquipamento.nome;

                dgvEquipamento.Rows.Add(equipamento.id, equipamento.nome, equipamento.quantidade, tipoEquipamento, funcionario);
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
            FormAdicionarEquipamentos formAdicionarEquipamentos = new FormAdicionarEquipamentos();
            formAdicionarEquipamentos.Closed += (s, args) => this.Close();
            formAdicionarEquipamentos.Show();
        }
    }
}
