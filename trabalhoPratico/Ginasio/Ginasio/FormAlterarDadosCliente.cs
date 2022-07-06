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
    public partial class FormAlterarDadosCliente : Form
    {
        public FormAlterarDadosCliente()
        {
            InitializeComponent();
        }

        private void FormAlterarDadosCliente_Load(object sender, EventArgs e) {
            if (Program.clienteData == null) {
                MessageBox.Show("Ocorreu algum erro, tenta novamente mais tarde");
                this.Hide();
                FormMenuCliente formMenuCliente = new FormMenuCliente();
                formMenuCliente.Closed += (s, args) => this.Close();
                formMenuCliente.Show();
                return;
            }

            txtPrimNome.Text = Program.clienteData.primNome;
            txtUltNome.Text = Program.clienteData.ultNome;
            datePickerDataNascimento.Value = Program.clienteData.dataNascimento;
            txtNif.Text = Program.clienteData.nif.ToString();
            txtTelefone.Text = Program.clienteData.telefone.ToString();
            txtEmail.Text = Program.clienteData.email;
            txtMorada.Text = Program.clienteData.morada;
            
            if (Program.clienteData.genero == "m") {
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
            FormMenuCliente formMenuCliente = new FormMenuCliente();
            formMenuCliente.Closed += (s, args) => this.Close();
            formMenuCliente.Show();
        }

        private void btnAlterar_Click(object sender, EventArgs e) {
            int telefone, nif;
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

            if (datePickerDataNascimento.Value >= DateTime.Now || Program.calcultateAge(datePickerDataNascimento.Value) < 16) {
                MessageBox.Show("A data de nascimento tem de ser menor que a data de hoje, e o cliente tem de ter pelo menos 16 anos", "Aviso", MessageBoxButtons.OK);
                datePickerDataNascimento.Focus();
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

            Program.clienteData.primNome = txtPrimNome.Text;
            Program.clienteData.ultNome = txtUltNome.Text;
            Program.clienteData.dataNascimento = datePickerDataNascimento.Value;
            Program.clienteData.nif = nif;
            Program.clienteData.genero = genero;
            Program.clienteData.telefone = telefone;
            Program.clienteData.email = txtEmail.Text;
            Program.clienteData.morada = txtMorada.Text;

            if (Program.clienteData.alterar()) {
                MessageBox.Show("Dados alterados com sucesso", "Informação", MessageBoxButtons.OK);

                this.Hide();
                FormMenuCliente formMenuCliente = new FormMenuCliente();
                formMenuCliente.Closed += (s, args) => this.Close();
                formMenuCliente.Show();
            } else {
                MessageBox.Show("Ocorreu algum erro a alterar as informações, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
            }
        }
    }
}
