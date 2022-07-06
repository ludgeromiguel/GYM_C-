using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ginasio.Classes;
using Ginasio.DatabaseControllers;

namespace Ginasio
{
    public partial class FormLogin: Form
    {
        public FormLogin() {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e) {
           if (txtUsername.Text == String.Empty) {
                MessageBox.Show("Introduza o seu username!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (txtPwd.Text == String.Empty) {
                MessageBox.Show("Introduza a sua password!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPwd.Focus();
                return;
            }

            Login login = null;

            try {
                login = new LoginDBController().getByUsername(txtUsername.Text);
            } catch {
                MessageBox.Show("Ocorreu algum erro no programa, tente novamente mais tarde.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (login == null || !login.verifyPassword(txtPwd.Text)) {
                MessageBox.Show("Dados de login invalidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!login.getDataTypeAccount()) {
                MessageBox.Show("Ocorreu algum erro a fazer login", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Program.loginData = login;
            
            if (login.createdByAdmin == 1) {
                this.Hide();
                FormAlterarPasswordCreatedByAdmin formAlterarPasswordCreatedByAdmin = new FormAlterarPasswordCreatedByAdmin();
                formAlterarPasswordCreatedByAdmin.Closed += (s, args) => this.Close();
                formAlterarPasswordCreatedByAdmin.Show();
            } else if (Program.tipoConta == "cliente") {
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
        }
        
        private void pictureBox5_Click(object sender, EventArgs e) {
            olhoAberto.Visible = true;
            olhoFechado.Visible = false;
            if (txtPwd.UseSystemPasswordChar == false) {
                txtPwd.UseSystemPasswordChar = true;
                olhoAberto.Visible = false;
                olhoFechado.Visible = true;
            } else {
                txtPwd.UseSystemPasswordChar = false;
                olhoAberto.Visible = true;
                olhoFechado.Visible = false;
            }
        }

        private void olhoFechado_Click(object sender, EventArgs e) {
            if (txtPwd.UseSystemPasswordChar == false) {
                txtPwd.UseSystemPasswordChar = true;
                olhoAberto.Visible = true;
                olhoFechado.Visible = false;
            } else {
                txtPwd.UseSystemPasswordChar = false;
                olhoAberto.Visible = true;
                olhoFechado.Visible = false;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Queres mesmo terminar o programa?", "Sair do Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void linkCriarConta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            this.Hide();
            FormCriarCliente formCriarCliente = new FormCriarCliente();
            formCriarCliente.createdByAdmin = 0;
            formCriarCliente.Closed += (s, args) => this.Close();
            formCriarCliente.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
