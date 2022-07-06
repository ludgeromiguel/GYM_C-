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

namespace Ginasio {
    public partial class FormMenuCliente : Form {
        public FormMenuCliente() {
            InitializeComponent();
        }

        private void FormMenuCliente_Load(object sender, EventArgs e) {
            if (!Program.clienteData.getExtrasCliente()) {
                MessageBox.Show("Ocorreu agum erro a obeter os seus extras", "Erro", MessageBoxButtons.OK);
            }

            dgvExtras.Columns.Add("nome", "Nome");
            dgvExtras.Columns.Add("preco", "Preço");
            dgvExtras.Columns.Add("quantidade", "Quantidade");
            dgvExtras.Columns.Add("precoTotal", "Preço Total");

            foreach (ExtrasCliente extracliente in Program.clienteData.extras) {
                if (extracliente == null) continue;

                string nome = "Não encontrado";
                float preco = 0;

                if (extracliente.getExtraData()) {
                    nome = extracliente.extra.nome;
                    preco = extracliente.extra.preco;
                }

                dgvExtras.Rows.Add(nome, preco, extracliente.quantidade, extracliente.quantidade * preco);
            }

            if (!Program.clienteData.getAulasCliente()) {
                MessageBox.Show("Ocorreu algum erro a obeter as aulas em que está inscrito", "Erro", MessageBoxButtons.OK);
            }

            dgvAulas.Columns.Add("modalidade", "Modalidade");
            dgvAulas.Columns.Add("nSala", "Nº Sala");
            dgvAulas.Columns.Add("maxAlunos", "Maximos de alunos");
            dgvAulas.Columns.Add("diaSemana", "Dia da semana");
            dgvAulas.Columns.Add("hora", "Hora");
            dgvAulas.Columns.Add("professor", "Professor");

            foreach (Aula aula in Program.clienteData.aulas) {
                if (aula == null) continue;

                string modalidade = "Não encontrada", professor = "Não encontrado";

                if (aula.getModalidadeAula()) modalidade = aula.modalidade.nome;
                if (aula.getProfessorModalidade()) professor = aula.professor.primNome + " " + aula.professor.ultNome;

                dgvAulas.Rows.Add(modalidade, aula.nSala, aula.maxAlunos, Program.convertDiaSemanaToString(aula.diaSemana), aula.hora, professor);
            }

            if (!Program.clienteData.getPlanoNutricional()) {
                MessageBox.Show("Ocorreu algum erro a obeter o seu plano nutricional");
            }

            dgvPlanoNutricional.Columns.Add("diaSemana", "Dia Semana");
            dgvPlanoNutricional.Columns.Add("pequenoAlmoco", "Pequeno Almoço");
            dgvPlanoNutricional.Columns.Add("lancheManha", "Lanche da Manha");
            dgvPlanoNutricional.Columns.Add("almoco", "Almoço");
            dgvPlanoNutricional.Columns.Add("lancheTarde", "Lanche da Tarde");
            dgvPlanoNutricional.Columns.Add("jantar", "Jantar");
            dgvPlanoNutricional.Columns.Add("ceia", "Ceia");

            foreach (PlanoNutricional planoNutricional in Program.clienteData.planoNutricional) {
                if (planoNutricional == null) continue;

                dgvPlanoNutricional.Rows.Add(Program.convertDiaSemanaToString(planoNutricional.diaSemana), planoNutricional.pequenoAlomoco, planoNutricional.pequenoAlomoco
                                             , planoNutricional.almoco, planoNutricional.lancheTarde, planoNutricional.jantar, planoNutricional.ceia);
            }
        }

        private void btnConsultarExtras_Click(object sender, EventArgs e) {
            this.Hide();
            FormConsultarExtrasCliente formConsultarExtrasCliente = new FormConsultarExtrasCliente();
            formConsultarExtrasCliente.Closed += (s, args) => this.Close();
            formConsultarExtrasCliente.Show();
        }

        private void btnAlterarSubscricao_Click(object sender, EventArgs e) {
            this.Hide();
            FormAlterarSubscricao formAlterarSubscricao = new FormAlterarSubscricao();
            formAlterarSubscricao.Closed += (s, args) => this.Close();
            formAlterarSubscricao.Show();
        }

        private void btnReclamacoes_Click(object sender, EventArgs e) {
            this.Hide();
            FormReclamacoes formReclamacoes = new FormReclamacoes();
            formReclamacoes.Closed += (s, args) => this.Close();
            formReclamacoes.Show();
        }

        private void btnConsultarAulas_Click(object sender, EventArgs e) {
            this.Hide();
            FormConsultarAulasCliente formConsultarAulasCliente = new FormConsultarAulasCliente();
            formConsultarAulasCliente.Closed += (s, args) => this.Close();
            formConsultarAulasCliente.Show();
        }

        private void btnAlterarDados_Click(object sender, EventArgs e) {
            this.Hide();
            FormAlterarDadosCliente formAlterarDadosCliente = new FormAlterarDadosCliente();
            formAlterarDadosCliente.Closed += (s, args) => this.Close();
            formAlterarDadosCliente.Show();
        }

        private void btnAlterarPassword_Click(object sender, EventArgs e) {
            this.Hide();
            FormAlterarPassword formAlterarPassword = new FormAlterarPassword();
            formAlterarPassword.Closed += (s, args) => this.Close();
            formAlterarPassword.Show();
        }

        private void btnTerminarSessao_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Queres mesmo sair da conta?", "Terminar Sessão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Program.loginData = null;
                Program.clienteData = null;
                Program.tipoConta = null;

                this.Hide();
                FormLogin formLogin = new FormLogin();
                formLogin.Closed += (s, args) => this.Close();
                formLogin.Show();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Queres mesmo terminar o programa?", "Sair do Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Application.Exit();
            }
        }
    }
}
