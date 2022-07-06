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
    public partial class FormConsultarAulasCliente : Form
    {
        public FormConsultarAulasCliente() {
            InitializeComponent();
        }

        private void FormConsultarAulasCkiente_Load(object sender, EventArgs e) {
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

            foreach(Aula aula in aulas) {
                string modalidade = "Não encontrada", professor = "Não encontrado";

                if (aula.getModalidadeAula()) modalidade = aula.modalidade.nome;
                if (aula.getProfessorModalidade()) professor = aula.professor.primNome + " " + aula.professor.ultNome;

                dgvAulas.Rows.Add(aula.id, modalidade, aula.nSala, aula.maxAlunos, Program.convertDiaSemanaToString(aula.diaSemana), aula.hora, professor);
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

        private void btnInscreverAula_Click(object sender, EventArgs e) {
            if (dgvAulas.SelectedRows.Count != 1) {
                MessageBox.Show("Tens de ter um e apenas um registo selecionado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idAula = Convert.ToInt32(dgvAulas.SelectedRows[0].Cells["id"].Value);

            bool isInscrito = false;

            if (!Program.clienteData.getAulasCliente()) {
                MessageBox.Show("Ocorreu algum erro, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
                return;
            }

            foreach (Aula aula in Program.clienteData.aulas) {
                if (aula == null) continue;
                if (aula.id == idAula) {
                    isInscrito = true;
                    break;
                }
            }

            if (isInscrito) {
                MessageBox.Show("Tu ja estás inscrito nessa aula", "Aviso", MessageBoxButtons.OK);
                return;
            }

            if (Program.clienteData.subscreverAula(idAula)) {
                MessageBox.Show("Aula inscrita com sucesso", "Informação", MessageBoxButtons.OK);
            } else {
                MessageBox.Show("Ocorreu algum erro a te inscreveres nessa aula", "Erro", MessageBoxButtons.OK);
            }
        }

        private void btnDesinscreverAula_Click(object sender, EventArgs e) {
            if (dgvAulas.SelectedRows.Count != 1) {
                MessageBox.Show("Tens de ter um e apenas um registo selecionado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idAula = Convert.ToInt32(dgvAulas.SelectedRows[0].Cells["id"].Value);

            bool isInscrito = false;

            if (!Program.clienteData.getAulasCliente()) {
                MessageBox.Show("Ocorreu algum erro, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
                return;
            }

            foreach (Aula aula in Program.clienteData.aulas) {
                if (aula == null) continue;
                if (aula.id == idAula) {
                    isInscrito = true;
                    break;
                }
            }

            if (!isInscrito) {
                MessageBox.Show("Tu não estás inscrito nessa aula", "Aviso", MessageBoxButtons.OK);
                return;
            }

            if (Program.clienteData.unsubscreverAula(idAula)) {
                MessageBox.Show("Aula desinscrita com sucesso", "Informação", MessageBoxButtons.OK);
            } else {
                MessageBox.Show("Ocorreu algum erro a te desinscrever essa aula", "Erro", MessageBoxButtons.OK);
            }
        }
    }
}
