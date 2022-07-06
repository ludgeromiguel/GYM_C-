using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ginasio {
    public partial class FormAlterarPasswordCreatedByAdmin : Form {
        public FormAlterarPasswordCreatedByAdmin() {
            InitializeComponent();
        }

        private void btnAlterarPassword_Click(object sender, EventArgs e) {
            if (txtPassword.Text == String.Empty) {
                MessageBox.Show("Tens de preencher a password", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (txtRepetPassword.Text == String.Empty) {
                MessageBox.Show("Tens de preencher a repetição da password", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRepetPassword.Focus();
                return;
            }

            if (txtPassword.Text != txtRepetPassword.Text) {
                MessageBox.Show("As passwords tenhem de ser iguais", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Text = String.Empty;
                txtRepetPassword.Text = String.Empty;
                return;
            }

            Program.loginData.password = Program.loginData.encryptPassword(txtPassword.Text);
            Program.loginData.createdByAdmin = 0;

            if (Program.loginData.alterar()) {
                MessageBox.Show("Password alterada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (Program.tipoConta == "cliente") {
                    this.Hide();
                    FormMenuCliente formMenuCliente = new FormMenuCliente();
                    formMenuCliente.Closed += (s, args) => this.Close();
                    formMenuCliente.Show();
                } else if (Program.tipoConta == "funcionario") {
                    this.Hide();
                    FormMenuFuncionario formMenuFuncionario = new FormMenuFuncionario();
                    formMenuFuncionario.Closed += (s, args) => this.Close();
                    formMenuFuncionario.Show();
                }
            } else {
                MessageBox.Show("Ocorreu algum erro a alterar a password, tenta novamente mais tarde.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Queres mesmo terminar o programa?", "Sair do Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Application.Exit();
            }
        }
    }
}
