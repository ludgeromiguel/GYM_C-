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
    public partial class FormAlterarDadosFuncionario : Form
    {
        public FormAlterarDadosFuncionario()
        {
            InitializeComponent();
        }

        private void FormAlterarDadosFuncionario_Load(object sender, EventArgs e)
        {
            txtPrimNome.Text = Program.funcionarioData.primNome;
            txtUltNome.Text = Program.funcionarioData.ultNome;
            dateTimePickerDataNascimento.Value = Program.funcionarioData.dataNascimento;
            txtNif.Text = Program.funcionarioData.nif.ToString();
            txtTelefone.Text = Program.funcionarioData.telefone.ToString();
            txtEmail.Text = Program.funcionarioData.email;
            txtMorada.Text = Program.funcionarioData.morada;

            if (Program.funcionarioData.genero == "m") {
                rdBtnMasculino.Checked = true;
                rdBtnFemenino.Checked = false;
            } else {
                rdBtnFemenino.Checked = true;
                rdBtnMasculino.Checked = false;
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

        private void btnAlterar_Click(object sender, EventArgs e) {
            int nif, telefone;
            string genero;

            if (txtPrimNome.Text == String.Empty) {
                MessageBox.Show("Preenche o primeiro nome", "Aviso", MessageBoxButtons.OK);
                txtPrimNome.Focus();
                return;
            }

            if (txtUltNome.Text == String.Empty) {
                MessageBox.Show("Preenche o ultimo nome", "Aviso", MessageBoxButtons.OK);
                txtUltNome.Focus();
                return;
            }

            if (dateTimePickerDataNascimento.Value >= DateTime.Now || Program.calcultateAge(dateTimePickerDataNascimento.Value) < 18) {
                MessageBox.Show("A data de nascimento tem de ser menor que a data de hoje, e o cliente tem de ter pelo menos 18 anos", "Aviso", MessageBoxButtons.OK);
                dateTimePickerDataNascimento.Focus();
                return;
            }

            if (txtNif.Text == String.Empty || txtNif.Text.Length != 9 || !int.TryParse(txtNif.Text, out nif)) {
                MessageBox.Show("O nif deve ser apenas números com comprimento de 9 números", "Aviso", MessageBoxButtons.OK);
                txtNif.Focus();
                return;
            }

            if (rdBtnMasculino.Checked) {
                genero = "m";
            } else {
                genero = "f";
            }

            if (txtTelefone.Text == String.Empty || txtTelefone.Text.Length != 9 || !int.TryParse(txtTelefone.Text, out telefone)) {
                MessageBox.Show("O número de telefone deve ser apenas números com comprimento de 9 números", "Aviso", MessageBoxButtons.OK);
                txtTelefone.Focus();
                return;
            }

            if (txtEmail.Text == String.Empty) {
                MessageBox.Show("Preenche o email", "Aviso", MessageBoxButtons.OK);
                txtEmail.Focus();
                return;
            }

            if (txtMorada.Text == String.Empty) {
                MessageBox.Show("Preenche a morada", "Aviso", MessageBoxButtons.OK);
                txtMorada.Focus();
                return;
            }

            Program.funcionarioData.primNome = txtPrimNome.Text;
            Program.funcionarioData.ultNome = txtUltNome.Text;
            Program.funcionarioData.dataNascimento = dateTimePickerDataNascimento.Value;
            Program.funcionarioData.nif = nif;
            Program.funcionarioData.telefone = telefone;
            Program.funcionarioData.email = txtEmail.Text;
            Program.funcionarioData.morada = txtMorada.Text;
            Program.funcionarioData.genero = genero;

            if (Program.funcionarioData.alterar()) {
                MessageBox.Show("Dados alterados com sucesso", "Informação", MessageBoxButtons.OK);

                this.Hide();
                FormMenuFuncionario formMenuFuncionario = new FormMenuFuncionario();
                formMenuFuncionario.Closed += (s, args) => this.Close();
                formMenuFuncionario.Show();
            } else {
                MessageBox.Show("Ocorreu algum erro, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
            }
        }
    }
}
