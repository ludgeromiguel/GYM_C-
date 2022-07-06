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
    public partial class FormAdicionarEquipamentos : Form
    {
        public FormAdicionarEquipamentos()
        {
            InitializeComponent();
        }

        private void FormAdicionarEquipamentos_Load(object sender, EventArgs e) {
            TipoEquipamento[] tiposEquipamento = null;
            Funcionario[] funcionarios = null;

            try {
                tiposEquipamento = new TipoEquipamentoDBController().getAll();

                if (tiposEquipamento == null) throw new Exception();
            } catch {
                MessageBox.Show("Não existe nenhum tipo de equipamento, então não podes introduzir um equipamento", "Erro", MessageBoxButtons.OK);

                this.Hide();
                FormConsultarEquipamentos formConsultarEquipamentos = new FormConsultarEquipamentos();
                formConsultarEquipamentos.Closed += (s, args) => this.Close();
                formConsultarEquipamentos.Show();
            }

            try {
                funcionarios = new FuncionarioDBController().getAll();
                if (funcionarios == null) throw new Exception();
            } catch {
                MessageBox.Show("Não existe nenhum funcionario, então não podes introduzir um equipamento", "Erro", MessageBoxButtons.OK);

                this.Hide();
                FormConsultarEquipamentos formConsultarEquipamentos = new FormConsultarEquipamentos();
                formConsultarEquipamentos.Closed += (s, args) => this.Close();
                formConsultarEquipamentos.Show();
            }

            foreach (TipoEquipamento tipoEquipamento in tiposEquipamento) {
                string nomeTipoEquipamento = "Id: " + tipoEquipamento.id + "-Nome: " + tipoEquipamento.nome;

                comboBoxTipoEquipamento.Items.Add(nomeTipoEquipamento);
            }

            foreach (Funcionario funcionario in funcionarios) {
                string nomeFuncionario = "Id: " + funcionario.id + "-Nome: " + funcionario.primNome + " " + funcionario.ultNome;

                comboBoxFuncionario.Items.Add(nomeFuncionario);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormConsultarEquipamentos formConsultarEquipamentos = new FormConsultarEquipamentos();
            formConsultarEquipamentos.Closed += (s, args) => this.Close();
            formConsultarEquipamentos.Show();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            int quantidade;

            if (txtNome.Text == String.Empty) {
                MessageBox.Show("Tens de preencher o nome do equipamento", "Aviso", MessageBoxButtons.OK);
                txtNome.Focus();
                return;
            }

            if (txtQuantidade.Text == String.Empty || !int.TryParse(txtQuantidade.Text, out quantidade) || quantidade < 0) {
                MessageBox.Show("A quantidade tem de ser um número igual ou superior a 0", "Aviso", MessageBoxButtons.OK);
                txtQuantidade.Focus();
                return;
            } 

            if (comboBoxFuncionario.SelectedIndex == -1) {
                MessageBox.Show("Tens de selecionar um funcionario para o equipamento", "Aviso", MessageBoxButtons.OK);
                comboBoxFuncionario.Focus();
                return;
            }

            int idFuncionario = Convert.ToInt32(comboBoxFuncionario.SelectedItem.ToString().Split('-')[0].Split(':')[1]);

            if (comboBoxTipoEquipamento.SelectedIndex == -1) {
                MessageBox.Show("Tens de selecionar um tipo de equipamento", "Aviso", MessageBoxButtons.OK);
                comboBoxTipoEquipamento.Focus();
                return;
            }

            int idTipoEquipamento = Convert.ToInt32(comboBoxTipoEquipamento.SelectedItem.ToString().Split('-')[0].Split(':')[1]);

            Equipamento equipamento = new Equipamento(txtNome.Text, quantidade, idTipoEquipamento, idFuncionario);

            if (equipamento.inserir()) {
                MessageBox.Show("Equipamento introduzido com sucesso", "Informação", MessageBoxButtons.OK);

                txtNome.Text = String.Empty;
                txtQuantidade.Text = String.Empty;
                comboBoxFuncionario.SelectedIndex = -1;
                comboBoxTipoEquipamento.SelectedIndex = -1;
            } else {
                MessageBox.Show("Ocorreu algum erro a introduzir o equipamento", "Erro", MessageBoxButtons.OK);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Queres mesmo terminar o programa?", "Sair do Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Application.Exit();
            }
        }
    }
}
