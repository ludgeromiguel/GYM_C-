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
    public partial class FormConsultarEquipamentos : Form
    {
        public FormConsultarEquipamentos()
        {
            InitializeComponent();
        }

        private void FormConsultarEquipamentos_Load(object sender, EventArgs e) {
            Equipamento[] equipamentos = null;

            try {
                equipamentos = new EquipamentoDBController().getAll();
            } catch {
                MessageBox.Show("Ocorreu algum erro, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
                return;
            }

            dgvEquipamentos.Columns.Add("id", "Id");
            dgvEquipamentos.Columns.Add("nome", "Nome");
            dgvEquipamentos.Columns.Add("quantidade", "Quantidade");
            dgvEquipamentos.Columns.Add("tipoEquipamento", "Tipo Equipamento");
            dgvEquipamentos.Columns.Add("funcionario", "Funcionario");

            foreach (Equipamento equipamento in equipamentos) {
                string tipoEquipamento = "Não encontrado", funcionario = "Não encontrado";

                if (equipamento.getTipoEquipamento()) tipoEquipamento = equipamento.tipoEquipamento.nome;
                if (equipamento.getFuncionario()) funcionario = equipamento.funcionario.primNome + " " + equipamento.funcionario.ultNome;

                dgvEquipamentos.Rows.Add(equipamento.id, equipamento.nome, equipamento.quantidade, tipoEquipamento, funcionario);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Queres mesmo terminar o programa?", "Sair do Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Application.Exit();
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

        private void btnRemover_Click(object sender, EventArgs e) {
            if (dgvEquipamentos.SelectedRows.Count != 1) {
                MessageBox.Show("Tens de ter um e apenas um registo selecionado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idEquipamento = Convert.ToInt32(dgvEquipamentos.SelectedRows[0].Cells["id"].Value);

            Equipamento equipamento = null;

            try {
                equipamento = new EquipamentoDBController().getById(idEquipamento);

                if (equipamento == null) throw new Exception();
            } catch {
                MessageBox.Show("Ocorreu algum erro, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
                return;
            }

            if (equipamento.remover()) {
                MessageBox.Show("Equipamento removido com sucesso", "Informação", MessageBoxButtons.OK);

                Equipamento[] equipamentos = null;

                dgvEquipamentos.Rows.Clear();

                try {
                    equipamentos = new EquipamentoDBController().getAll();
                } catch {
                    MessageBox.Show("Ocorreu algum erro, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
                    return;
                }

                foreach (Equipamento equipamento1 in equipamentos) {
                    string tipoEquipamento = "Não encontrado", funcionario = "Não encontrado";

                    if (equipamento1.getTipoEquipamento()) tipoEquipamento = equipamento1.tipoEquipamento.nome;
                    if (equipamento1.getFuncionario()) funcionario = equipamento1.funcionario.primNome + " " + equipamento.funcionario.ultNome;

                    dgvEquipamentos.Rows.Add(equipamento1.id, equipamento1.nome, equipamento1.quantidade, tipoEquipamento, funcionario);
                }
            } else {
                MessageBox.Show("Ocorreu algum erro a remover o equipamento, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
            }
        }
    }
}
