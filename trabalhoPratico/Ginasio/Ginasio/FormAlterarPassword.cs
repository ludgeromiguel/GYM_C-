using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ginasio
{
    public partial class FormAlterarPassword : Form
    {
        public FormAlterarPassword()
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
            if (Program.tipoConta == "cliente") {
                FormMenuCliente formMenuCliente = new FormMenuCliente();
                formMenuCliente.Closed += (s, args) => this.Close();
                formMenuCliente.Show();
            } else {
                FormMenuFuncionario formMenuFuncionario = new FormMenuFuncionario();
                formMenuFuncionario.Closed += (s, args) => this.Close();
                formMenuFuncionario.Show();
            }
        }

        private void btnAlterarPassword_Click(object sender, EventArgs e) {
            if (txtPassword.Text == String.Empty) {
                MessageBox.Show("Preenche a password", "Aviso", MessageBoxButtons.OK);
                txtPassword.Focus();
                return;
            }

            if (txtRepetPassword.Text == String.Empty) {
                MessageBox.Show("Preenche a repetição da password", "Aviso", MessageBoxButtons.OK);
                txtRepetPassword.Focus();
                return;
            }

            if (txtPassword.Text != txtRepetPassword.Text) {
                MessageBox.Show("As password não são iguais, por favor verifica", "Erro", MessageBoxButtons.OK);
                return;
            }

            Program.loginData.password = Program.loginData.encryptPassword(txtPassword.Text);

            if (Program.loginData.alterar()) {
                MessageBox.Show("Password Alterada com sucesso", "Informação", MessageBoxButtons.OK);

                this.Hide();
                if (Program.tipoConta == "cliente") {
                    FormMenuCliente formMenuCliente = new FormMenuCliente();
                    formMenuCliente.Closed += (s, args) => this.Close();
                    formMenuCliente.Show();
                } else {
                    FormMenuFuncionario formMenuFuncionario = new FormMenuFuncionario();
                    formMenuFuncionario.Closed += (s, args) => this.Close();
                    formMenuFuncionario.Show();
                }
            } else {
                MessageBox.Show("Ocorreu algum erro a alterar a password, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
            }
        }
    }
}
