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
    public partial class FormAdicionarAulas : Form
    {
        public FormAdicionarAulas()
        {
            InitializeComponent();
        }

        private void FormAdicionarAulas_Load(object sender, EventArgs e) {
            Modalidade[] modalidades = null;
            Funcionario[] funcionarios = null;

            try {
                modalidades = new ModalidadeDBController().getAll();

                if (modalidades == null || modalidades.Length == 0) throw new Exception();
            } catch {
                MessageBox.Show("Não é possivel adicionar aulas porque não existe modalidades no sistema", "Erro", MessageBoxButtons.OK);

                this.Hide();
                FormConsultarAulasCliente formMenuConsultarModalidadesAula = new FormConsultarAulasCliente();
                formMenuConsultarModalidadesAula.Closed += (s, args) => this.Close();
                formMenuConsultarModalidadesAula.Show();
            }

            try {
                funcionarios = new FuncionarioDBController().getAll();

                if (funcionarios == null || funcionarios.Length == 0) throw new Exception();
            } catch {
                MessageBox.Show("Não é possivel adicionar aulas porque não existe nenhum funcionario no sistema", "Erro", MessageBoxButtons.OK);

                this.Hide();
                FormConsultarAulasCliente formMenuConsultarModalidadesAula = new FormConsultarAulasCliente();
                formMenuConsultarModalidadesAula.Closed += (s, args) => this.Close();
                formMenuConsultarModalidadesAula.Show();
            }

            foreach (Modalidade modalidade in modalidades) {
                string nomeModalidade = "Id: " + modalidade.id + "-Nome: " + modalidade.nome;

                comboBoxModalidade.Items.Add(nomeModalidade);
            }

            foreach (Funcionario funcionario in funcionarios) {
                string nomeFuncionario = "Id: " + funcionario.id + "-Nome: " + funcionario.primNome + " " + funcionario.ultNome;

                comboBoxProfessor.Items.Add(nomeFuncionario);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormConsultarAulasFuncionario formConsultarAulasFuncionario = new FormConsultarAulasFuncionario();
            formConsultarAulasFuncionario.Closed += (s, args) => this.Close();
            formConsultarAulasFuncionario.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Queres mesmo terminar o programa?", "Sair do Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e) {
            int nSala, maxAlunos, horaHH, horaMM, idFuncionario, idModalidade;
            string hora;

            if (comboBoxModalidade.SelectedIndex == -1) {
                MessageBox.Show("Tens de escolher uma modalidade", "Aviso", MessageBoxButtons.OK);
                comboBoxModalidade.Focus();
                return;
            }

            if (comboBoxProfessor.SelectedIndex == -1) {
                MessageBox.Show("Tens de escolher um professor", "Aviso", MessageBoxButtons.OK);
                comboBoxProfessor.Focus();
                return;
            }

            if (txtNSala.Text == String.Empty || !int.TryParse(txtNSala.Text, out nSala)) {
                MessageBox.Show("O número da sala so pode ser números", "Aviso", MessageBoxButtons.OK);
                txtNSala.Focus();
                return;
            }

            if (txtMaxAlunos.Text == String.Empty || !int.TryParse(txtMaxAlunos.Text, out maxAlunos) || maxAlunos <= 0) {
                MessageBox.Show("O número maximo de alunos so pode ser números, e tem de ser maior que 0", "Aviso", MessageBoxButtons.OK);
                txtMaxAlunos.Focus();
                return;
            }

            if (comboBoxDiaSemana.SelectedIndex == -1) {
                MessageBox.Show("Tens de escolher um dia da semana", "Aviso", MessageBoxButtons.OK);
                comboBoxDiaSemana.Focus();
                return;
            }

            int diaSemana = Program.convertStringToDiaSemana(comboBoxDiaSemana.SelectedItem.ToString());

            if (diaSemana == 0) {
                MessageBox.Show("Escolhe um dia da semana valido", "Aviso", MessageBoxButtons.OK);
                comboBoxDiaSemana.SelectedIndex = -1;
                comboBoxDiaSemana.Focus();
                return;
            }

            if (txtHorahh.Text == String.Empty || !int.TryParse(txtHorahh.Text, out horaHH) || horaHH < 0 || horaHH > 24) {
                MessageBox.Show("A hora tem de ser um número entre 0 e 24", "Aviso", MessageBoxButtons.OK);
                txtHorahh.Focus();
                return;
            }

            if (txtHoramm.Text == String.Empty || !int.TryParse(txtHoramm.Text, out horaMM) || horaMM < 0 || horaMM > 60) {
                MessageBox.Show("Os minutos tenhem de ser um número entre 0 e 60");
                txtHoramm.Focus();
                return;
            }

            hora = horaHH + ":" + horaMM;
            idFuncionario = Convert.ToInt32(comboBoxProfessor.SelectedItem.ToString().Split('-')[0].Split(':')[1]);
            idModalidade = Convert.ToInt32(comboBoxModalidade.SelectedItem.ToString().Split('-')[0].Split(':')[1]);

            Aula aula = new Aula(idModalidade, nSala, maxAlunos, diaSemana, hora, idFuncionario);

            if (aula.inserir()) {
                MessageBox.Show("Aula introduzida com sucesso", "Informação", MessageBoxButtons.OK);
                comboBoxDiaSemana.SelectedIndex = -1;
                comboBoxModalidade.SelectedIndex = -1;
                comboBoxProfessor.SelectedIndex = -1;
                txtHorahh.Text = String.Empty;
                txtHoramm.Text = String.Empty;
                txtMaxAlunos.Text = String.Empty;
                txtNSala.Text = String.Empty;
            } else {
                MessageBox.Show("Ocorreu algum erro a introduzir a aula", "Erro", MessageBoxButtons.OK);
            }
        }
    }
}
