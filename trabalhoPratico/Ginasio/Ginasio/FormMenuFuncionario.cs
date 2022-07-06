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
    public partial class FormMenuFuncionario : Form {
        public FormMenuFuncionario() {
            InitializeComponent();
        }

        private void FormMenuFuncionario_Load(object sender, EventArgs e) {
            lblBemVindo.Text = "Bem vindo de volta " + Program.funcionarioData.primNome + " " + Program.funcionarioData.ultNome;
        }

        private void btnTerminarSessao_Click(object sender, EventArgs e) {

            if (MessageBox.Show("Queres mesmo sair da conta?", "Terminar Sessão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Program.loginData = null;
                Program.funcionarioData = null;
                Program.tipoConta = null;

                this.Hide();
                FormLogin formLogin = new FormLogin();
                formLogin.Closed += (s, args) => this.Close();
                formLogin.Show();
            }
        }

        private void btnConsultarClientes_Click(object sender, EventArgs e) {
            this.Hide();
            FormConsultarClientes formConsultarClientes = new FormConsultarClientes();
            formConsultarClientes.Closed += (s, args) => this.Close();
            formConsultarClientes.Show();
        }

        private void btnConsultarFuncionarios_Click(object sender, EventArgs e) {
            this.Hide();
            FormConsultarFuncionarios formConsultarFuncionarios = new FormConsultarFuncionarios();
            formConsultarFuncionarios.Closed += (s, args) => this.Close();
            formConsultarFuncionarios.Show();
        }

        private void btnConsultarCargos_Click(object sender, EventArgs e) {
            this.Hide();
            FormMenuConsultarCargosFuncionario formConsultarCargos = new FormMenuConsultarCargosFuncionario();
            formConsultarCargos.Closed += (s, args) => this.Close();
            formConsultarCargos.Show();
        }

        private void btnConsultarEquipamentos_Click(object sender, EventArgs e) {
            this.Hide();
            FormConsultarEquipamentos formConsultarEquipamentos = new FormConsultarEquipamentos();
            formConsultarEquipamentos.Closed += (s, args) => this.Close();
            formConsultarEquipamentos.Show();
        }

        private void btnConsultarTiposEquipamento_Click(object sender, EventArgs e) {
            this.Hide();
            FormConsultarTiposEquipamento formConsultarTiposEquipamentos = new FormConsultarTiposEquipamento();
            formConsultarTiposEquipamentos.Closed += (s, args) => this.Close();
            formConsultarTiposEquipamentos.Show();
        }

        private void btnConsultarAulas_Click(object sender, EventArgs e) {
            this.Hide();
            FormConsultarAulasFuncionario formConsultarAulas = new FormConsultarAulasFuncionario();
            formConsultarAulas.Closed += (s, args) => this.Close();
            formConsultarAulas.Show();
        }

        private void btnConsultarModalidadesAula_Click(object sender, EventArgs e) {
            this.Hide();
            FormConsultarModalidadesAulas formConsultarModalidadesAula = new FormConsultarModalidadesAulas();
            formConsultarModalidadesAula.Closed += (s, args) => this.Close();
            formConsultarModalidadesAula.Show();
        }

        private void btnConsultarSubscricoes_Click(object sender, EventArgs e) {
            this.Hide();
            FormConsultarSubscricoes formConsultarSubscricoes = new FormConsultarSubscricoes();
            formConsultarSubscricoes.Closed += (s, args) => this.Close();
            formConsultarSubscricoes.Show();
        }

        private void btnConsultarReclamacoes_Click(object sender, EventArgs e) {
            this.Hide();
            FormConsultarReclamacoes formConsultarReclamacoes = new FormConsultarReclamacoes();
            formConsultarReclamacoes.Closed += (s, args) => this.Close();
            formConsultarReclamacoes.Show();
        }

        private void btnConsultarTiposReclamacao_Click(object sender, EventArgs e) {
            this.Hide();
            FormMenuConsultarTiposReclamacao formConsultarTiposReclamacao = new FormMenuConsultarTiposReclamacao();
            formConsultarTiposReclamacao.Closed += (s, args) => this.Close();
            formConsultarTiposReclamacao.Show();
        }

        private void btnConsultarExtras_Click(object sender, EventArgs e) {
            this.Hide();
            FormConsultarExtrasFuncionarios formConsultarExtras = new FormConsultarExtrasFuncionarios();
            formConsultarExtras.Closed += (s, args) => this.Close();
            formConsultarExtras.Show();
        }

        private void btnAlterarDados_Click(object sender, EventArgs e) {
            this.Hide();
            FormAlterarDadosFuncionario formAlterarDados = new FormAlterarDadosFuncionario();
            formAlterarDados.Closed += (s, args) => this.Close();
            formAlterarDados.Show();
        }


        private void btnAlterarPassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAlterarPassword formAlterarPassword = new FormAlterarPassword();
            formAlterarPassword.Closed += (s, args) => this.Close();
            formAlterarPassword.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Queres mesmo terminar o programa?", "Sair do Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Application.Exit();
            }
        }
    }
}
