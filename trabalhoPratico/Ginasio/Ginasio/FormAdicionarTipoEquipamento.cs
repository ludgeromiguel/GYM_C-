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
    public partial class FormAdicionarTipoEquipamento : Form
    {
        public FormAdicionarTipoEquipamento() {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Queres mesmo terminar o programa?", "Sair do Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            this.Hide();
            FormConsultarTiposEquipamento formConsultarTiposEquipamento = new FormConsultarTiposEquipamento();
            formConsultarTiposEquipamento.Closed += (s, args) => this.Close();
            formConsultarTiposEquipamento.Show();
        }

        private void btnAdicionar_Click(object sender, EventArgs e) {
            if (txtNome.Text == String.Empty) {
                MessageBox.Show("Tens de introduzir o nome do tipo do equipamento", "Aviso", MessageBoxButtons.OK);
                txtNome.Focus();
                return;
            }

            TipoEquipamento tipoEquipamento = new TipoEquipamento(txtNome.Text);
            TipoEquipamento[] tiposEquipamento = null;

            try {
                tiposEquipamento = new TipoEquipamentoDBController().searchByNomeSistema(tipoEquipamento.nomeSistema);
            } catch {
                MessageBox.Show("Ocorreu algum erro, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
                return;
            }

            if (tiposEquipamento != null && tiposEquipamento.Length > 0 && tiposEquipamento[0] != null) {
                MessageBox.Show("Ja existe um tipo de equipamento com esse nome", "Erro", MessageBoxButtons.OK);
                txtNome.Text = String.Empty;
                txtNome.Focus();
                return;
            }

            if (tipoEquipamento.inserir()) {
                MessageBox.Show("Tipo de equipamento criado com sucesso!", "Informação", MessageBoxButtons.OK);

                txtNome.Text = String.Empty;
            } else {
                MessageBox.Show("Ocorreu algum erro a criar o tipo de equipamento", "Erro", MessageBoxButtons.OK);
            }
        }
    }
}
