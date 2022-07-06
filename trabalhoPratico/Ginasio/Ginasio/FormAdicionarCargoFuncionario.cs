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
    public partial class FormAdicionarCargoFuncionario : Form
    {
        public FormAdicionarCargoFuncionario()
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
            FormMenuConsultarCargosFuncionario formMenuConsultarCargosFuncionario = new FormMenuConsultarCargosFuncionario();
            formMenuConsultarCargosFuncionario.Closed += (s, args) => this.Close();
            formMenuConsultarCargosFuncionario.Show();
        }

        private void btnAdicionar_Click(object sender, EventArgs e) {
            if (txtNome.Text == String.Empty) {
                MessageBox.Show("Tens de fornecer o nome do cargo", "Aviso", MessageBoxButtons.OK);
                txtNome.Focus();
                return;
            }

            Cargo cargo = new Cargo(txtNome.Text);
            Cargo[] cargosDB = null;

            try {
                cargosDB = new CargoDBController().searchByNomeSistema(cargo.nomeSistema);
            } catch {
                MessageBox.Show("OCorreu algum erro, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
                return;
            }

            if (cargosDB != null && cargosDB.Length > 0 && cargosDB[0] != null) {
                MessageBox.Show("Ja existe um cargo com esse nome!", "Erro", MessageBoxButtons.OK);
                txtNome.Text = String.Empty;
                txtNome.Focus();
                return;
            }

            if (cargo.inserir()) {
                MessageBox.Show("Cargo criado com sucesso", "Informação", MessageBoxButtons.OK);
                txtNome.Text = String.Empty;
            } else {
                MessageBox.Show("Ocorreu algum erro a criar o cargo, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
            }
        }
    }
}
