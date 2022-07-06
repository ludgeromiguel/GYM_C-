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
    public partial class FormConsultarTiposEquipamento : Form
    {
        public FormConsultarTiposEquipamento()
        {
            InitializeComponent();
        }

        private void FormConsultarTiposEquipamento_Load(object sender, EventArgs e) {
            TipoEquipamento[] tiposEquipamentos = null;

            try {
                tiposEquipamentos = new TipoEquipamentoDBController().getAll();
            } catch {
                MessageBox.Show("Ocorreu algum erro, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
            }

            dgvTipoEquipamento.Columns.Add("id", "Id");
            dgvTipoEquipamento.Columns.Add("nome", "Nome");

            foreach (TipoEquipamento tipoEquipamento in tiposEquipamentos) {
                dgvTipoEquipamento.Rows.Add(tipoEquipamento.id, tipoEquipamento.nome);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Queres mesmo terminar o programa?", "Sair do Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e) {
            this.Hide();
            FormAdicionarTipoEquipamento formAdicionarTipoEquipamento = new FormAdicionarTipoEquipamento();
            formAdicionarTipoEquipamento.Closed += (s, args) => this.Close();
            formAdicionarTipoEquipamento.Show();
        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            this.Hide();
            FormMenuFuncionario formMenuFuncionario = new FormMenuFuncionario();
            formMenuFuncionario.Closed += (s, args) => this.Close();
            formMenuFuncionario.Show();
        }
    }
}
