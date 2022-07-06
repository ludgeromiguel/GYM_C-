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
    public partial class FormConsultarFuncionarios : Form
    {
        public FormConsultarFuncionarios()
        {
            InitializeComponent();
        }

        private void FormConsultarFuncionarios_Load(object sender, EventArgs e) {
            Funcionario[] funcionarios = null;

            try {
                funcionarios = new FuncionarioDBController().getAll();
            } catch {
                MessageBox.Show("Ocorreu algum erro, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
            }

            dgvFuncionarios.Columns.Add("id", "Id");
            dgvFuncionarios.Columns.Add("primNome", "Primeiro Nome");
            dgvFuncionarios.Columns.Add("ultNome", "Ultimo Nome");
            dgvFuncionarios.Columns.Add("dataNascimento", "Data de Nascimento");
            dgvFuncionarios.Columns.Add("nif", "Nif");
            dgvFuncionarios.Columns.Add("genero", "Genero");
            dgvFuncionarios.Columns.Add("telefone", "Telefone");
            dgvFuncionarios.Columns.Add("email", "Email");
            dgvFuncionarios.Columns.Add("morada", "Morada");
            dgvFuncionarios.Columns.Add("salario", "Salario");
            dgvFuncionarios.Columns.Add("inicioContrato", "Inicio Contrato");
            dgvFuncionarios.Columns.Add("fimContrato", "Fim Contrato");
            dgvFuncionarios.Columns.Add("turnoInicio", "Turno Inicio");
            dgvFuncionarios.Columns.Add("turnoFim", "Turno Fim");
            dgvFuncionarios.Columns.Add("cargo", "Cargo");

            foreach (Funcionario funcionario in funcionarios) {
                string cargo = "Não encontrado";

                if (funcionario.getCargoData()) cargo = funcionario.cargo.nome;

                dgvFuncionarios.Rows.Add(funcionario.id, funcionario.primNome, funcionario.ultNome, Program.convertDateToString(funcionario.dataNascimento), funcionario.nif
                                        , funcionario.genero == "m" ? "Masculino" : "Femenino", funcionario.telefone, funcionario.email, funcionario.morada, funcionario.salario
                                        , Program.convertDateToString(funcionario.inicioContrato), Program.convertDateToString(funcionario.fimContrato), funcionario.turnoFim
                                        , funcionario.turnoFim, cargo);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Queres mesmo terminar o programa?", "Sair do Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e) {
            this.Hide();
            FormAdicionarFuncionario formAdicionarFuncionario = new FormAdicionarFuncionario();
            formAdicionarFuncionario.Closed += (s, args) => this.Close();
            formAdicionarFuncionario.Show();
        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            this.Hide();
            FormMenuFuncionario formMenuFuncionario = new FormMenuFuncionario();
            formMenuFuncionario.Closed += (s, args) => this.Close();
            formMenuFuncionario.Show();
        }
    }
}
