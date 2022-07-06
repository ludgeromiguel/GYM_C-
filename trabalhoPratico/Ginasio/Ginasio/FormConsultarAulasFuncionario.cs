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
    public partial class FormConsultarAulasFuncionario : Form
    {
        public FormConsultarAulasFuncionario() {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Queres mesmo terminar o programa?", "Sair do Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void FormConsultarAulasFuncionario_Load(object sender, EventArgs e) {
            Aula[] aulas = null;

            try {
                aulas = new AulaDBController().getAll();
            } catch {
                MessageBox.Show("Ocorreu algum erro, tenta novamente mais tarde");
                this.Hide();
                FormMenuCliente formMenuCliente = new FormMenuCliente();
                formMenuCliente.Closed += (s, args) => this.Close();
                formMenuCliente.Show();
                return;
            }

            dgvAulas.Columns.Add("id", "Id");
            dgvAulas.Columns.Add("modalidade", "Modalidade");
            dgvAulas.Columns.Add("nSala", "Nº Sala");
            dgvAulas.Columns.Add("maxAlunos", "Maximo Alunos");
            dgvAulas.Columns.Add("diaSemana", "Dia semana");
            dgvAulas.Columns.Add("hora", "Hora");
            dgvAulas.Columns.Add("professor", "Professor");

            foreach (Aula aula in aulas) {
                string modalidade = "Não encontrada", professor = "Não encontrado";

                if (aula.getModalidadeAula()) modalidade = aula.modalidade.nome;
                if (aula.getProfessorModalidade()) professor = aula.professor.primNome + " " + aula.professor.ultNome;

                dgvAulas.Rows.Add(aula.id, modalidade, aula.nSala, aula.maxAlunos, Program.convertDiaSemanaToString(aula.diaSemana), aula.hora, professor);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            this.Hide();
            FormMenuFuncionario formMenuFuncionario = new FormMenuFuncionario();
            formMenuFuncionario.Closed += (s, args) => this.Close();
            formMenuFuncionario.Show();
        }

        private void btnAdicionar_Click(object sender, EventArgs e) {
            this.Hide();
            FormAdicionarAulas formAdicionarAulas = new FormAdicionarAulas();
            formAdicionarAulas.Closed += (s, args) => this.Close();
            formAdicionarAulas.Show();
        }
    }
}
