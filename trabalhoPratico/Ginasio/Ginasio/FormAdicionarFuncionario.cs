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
    public partial class FormAdicionarFuncionario : Form
    {
        public FormAdicionarFuncionario()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Queres mesmo terminar o programa?", "Sair do Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void FormAdicionarFuncionario_Load(object sender, EventArgs e) {
            Cargo[] cargos = null;

            try {
                cargos = new CargoDBController().getAll();

                if (cargos == null) throw new Exception();
            } catch {
                MessageBox.Show("Não existe nenhum cargo, então não é possíbel criar funcionarios", "Erro", MessageBoxButtons.OK);
                this.Hide();
                FormConsultarFuncionarios formConsultarFuncionarios = new FormConsultarFuncionarios();
                formConsultarFuncionarios.Closed += (s, args) => this.Close();
                formConsultarFuncionarios.Show();
                return;
            }

            foreach (Cargo cargo in cargos) {
                string nomeCargo = "Id: " + cargo.id + "-Nome: " + cargo.nome;

                comboBoxCargo.Items.Add(nomeCargo);
            }
        }

        private void lblFoto_Click(object sender, EventArgs e) {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Escolha a imagem(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK) {
                lblFoto.Text = opf.FileName;
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            this.Hide();
            FormConsultarFuncionarios formConsultarFuncionarios = new FormConsultarFuncionarios();
            formConsultarFuncionarios.Closed += (s, args) => this.Close();
            formConsultarFuncionarios.Show();
        }

        private void btnAdicionar_Click(object sender, EventArgs e) {
            int nif, telefone, turnoInicioHH, turnoFimHH, turnoInicioMM, turnoFimMM;
            float salario;
            string genero, turnoInicio, turnoFim;

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

            if (txtUsername.Text == String.Empty) {
                MessageBox.Show("Preenche o username", "Aviso", MessageBoxButtons.OK);
                txtUsername.Focus();
                return;
            }

            if (txtPassword.Text == String.Empty) {
                MessageBox.Show("Preenche a password", "Aviso", MessageBoxButtons.OK);
                txtPassword.Focus();
                return;
            }

            if (txtInicioTurnohh.Text == String.Empty || !int.TryParse(txtInicioTurnohh.Text, out turnoInicioHH) || turnoInicioHH < 0 || turnoInicioHH > 24) {
                MessageBox.Show("A hora de inicio do turno tem de ser um número entre 0 e 24", "Aviso", MessageBoxButtons.OK);
                txtInicioTurnohh.Focus();
                return;
            }

            if (txtInicioTurnomm.Text == String.Empty || !int.TryParse(txtInicioTurnomm.Text, out turnoInicioMM) || turnoInicioMM < 0 || turnoInicioMM > 60) {
                MessageBox.Show("Os minutos do incio do turno tenhem de ser um número entre 0 e 60");
                txtInicioTurnomm.Focus();
                return;
            }

            turnoInicio = turnoInicioHH + ":" + turnoInicioMM;

            if (txtFimTurnohh.Text == String.Empty || !int.TryParse(txtFimTurnohh.Text, out turnoFimHH) || turnoFimHH < 0 || turnoFimHH > 24) {
                MessageBox.Show("A hora do fim do turno tem de ser um número entre 0 e 24", "Aviso", MessageBoxButtons.OK);
                txtFimTurnohh.Focus();
                return;
            }

            if (txtFimTurnomm.Text == String.Empty || !int.TryParse(txtFimTurnomm.Text, out turnoFimMM) || turnoFimMM < 0 || turnoFimMM > 60) {
                MessageBox.Show("Os minutos do fim do turno tenhem de ser um número entre 0 e 60");
                txtFimTurnomm.Focus();
                return;
            }

            turnoFim = turnoFimHH + ":" + turnoFimMM;

            if (comboBoxCargo.SelectedIndex == -1) {
                MessageBox.Show("Tens de selecionar o cargo do funcionario", "Avios", MessageBoxButtons.OK);
                comboBoxCargo.Focus();
                return;
            }

            int idCargo = Convert.ToInt32(comboBoxCargo.SelectedItem.ToString().Split('-')[0].Split(':')[1]);

            if (dateTimePickerFimContrato.Value <= DateTime.Now) {
                MessageBox.Show("A data do fim do contrato tem de ser maior que a data de hoje", "Aviso", MessageBoxButtons.OK);
                dateTimePickerFimContrato.Focus();
                return;
            }

            if (txtSalario.Text == String.Empty || !float.TryParse(txtSalario.Text, out salario) || salario < 600) {
                MessageBox.Show("O salario tem de ser um número maior que 600", "Aviso", MessageBoxButtons.OK);
                txtSalario.Focus();
                return;
            }

            Login loginTemp = null;

            try {
                loginTemp = new LoginDBController().getByUsername(txtUsername.Text);
            } catch {
                MessageBox.Show("Ocorreu algum erro, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
                return;
            }

            if (loginTemp != null) {
                MessageBox.Show("Ja existe uma conta com esse username, escolhe outro", "Aviso", MessageBoxButtons.OK);
                txtUsername.Text = String.Empty;
                txtUsername.Focus();
                return;
            }

            Funcionario funcionario = new Funcionario(txtPrimNome.Text, txtUltNome.Text, dateTimePickerDataNascimento.Value, nif, genero, telefone,
                                                      txtEmail.Text, txtMorada.Text, 1, Program.defaultPhoto, salario, DateTime.Now, dateTimePickerFimContrato.Value
                                                      , turnoInicio, turnoFim, idCargo);

            if (!funcionario.inserir()) {
                MessageBox.Show("Ocorreu algum erro a criar o funcionario", "Erro", MessageBoxButtons.OK);
                return;
            }

            if (lblFoto.Text != Program.defaultPhoto) {
                string photoExtension = lblFoto.Text.Split('.').Last();
                if (funcionario.saveImage(lblFoto.Text, "funcionarios", "funcionarios_" + funcionario.id + "." + photoExtension)) funcionario.alterar();
            }

            Login login = new Login(txtUsername.Text, txtPassword.Text, "funcionarios_" + funcionario.id, 1, 1);

            login.password = login.encryptPassword(login.password);

            if (!login.inserir()) {
                MessageBox.Show("Ocorreu algum erro a criar a conta, tente novamente mais tarde", "Erro", MessageBoxButtons.OK);
                return;
            }

            MessageBox.Show("Conta criada com sucesso", "Sucesso", MessageBoxButtons.OK);
            this.Hide();
            FormConsultarFuncionarios formConsultarFuncionarios = new FormConsultarFuncionarios();
            formConsultarFuncionarios.Closed += (s, args) => this.Close();
            formConsultarFuncionarios.Show();
        }
    }
}
