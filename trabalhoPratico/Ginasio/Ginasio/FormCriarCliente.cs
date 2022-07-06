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

namespace Ginasio {
    public partial class FormCriarCliente : Form
    {
        public int createdByAdmin;
        public FormCriarCliente()
        {
            InitializeComponent();
        }

        private void lblFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Escolha a imagem(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                lblFoto.Text = opf.FileName;
            }
        }

        private void FormCriarCliente_Load(object sender, EventArgs e)
        {
            Subscricao[] subscricoes = null;

            lblFoto.Text = Program.defaultPhoto;

            try
            {
                subscricoes = new SubscricaoDBController().getAll();

                if (subscricoes == null) throw new Exception("Não existe subscrições");

                int contador = 0;

                foreach (Subscricao subscricao in subscricoes)
                {
                    if (subscricao.isActive == 1) contador++;
                }

                if (contador == 0) throw new Exception("Não existe nenhuma subscrição valida");
            }
            catch
            {
                MessageBox.Show("Não é possivel abrir o menu de criar cliente pois não existe nenhum plano", "Erro", MessageBoxButtons.OK);

                this.Hide();
                if (createdByAdmin == 1)
                {
                    FormConsultarClientes formConsultarClientes = new FormConsultarClientes();
                    formConsultarClientes.Closed += (s, args) => this.Close();
                }
                else
                {
                    FormLogin formLogin = new FormLogin();
                    formLogin.Closed += (s, args) => this.Close();
                    formLogin.Show();
                }
            }

            foreach (Subscricao subscricao in subscricoes)
            {
                if (subscricao.isActive == 0) continue;

                string subscricaoName = "Id: " + subscricao.id + "-Nome: " + subscricao.nome + "-Preço: " + subscricao.preco;

                comboBoxSubscricoes.Items.Add(subscricaoName);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            this.Hide();
            if (createdByAdmin == 1)
            {
                FormConsultarClientes formConsultarClientes = new FormConsultarClientes();
                formConsultarClientes.Closed += (s, args) => this.Close();
                formConsultarClientes.Show();
            }
            else
            {
                FormLogin formLogin = new FormLogin();
                formLogin.Closed += (s, args) => this.Close();
                formLogin.Show();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            
            int nif, telefone, subscricao;
            string genero;

            if (txtPrimNome.Text == String.Empty)
            {
                MessageBox.Show("Preenche o primeiro nome", "Aviso", MessageBoxButtons.OK);
                txtPrimNome.Focus();
                return;
            }

            if (txtUltNome.Text == String.Empty)
            {
                MessageBox.Show("Preenche o ultimo nome", "Aviso", MessageBoxButtons.OK);
                txtUltNome.Focus();
                return;
            }

            if (datePickerDataNascimento.Value >= DateTime.Now || Program.calcultateAge(datePickerDataNascimento.Value) < 16)
            {
                MessageBox.Show("A data de nascimento tem de ser menor que a data de hoje, e o cliente tem de ter pelo menos 16 anos", "Aviso", MessageBoxButtons.OK);
                datePickerDataNascimento.Focus();
                return;
            }

            if (txtNif.Text == String.Empty || txtNif.Text.Length != 9 || !int.TryParse(txtNif.Text, out nif))
            {
                MessageBox.Show("O nif deve ser apenas números com comprimento de 9 números", "Aviso", MessageBoxButtons.OK);
                txtNif.Focus();
                return;
            }

            if (rdBtnMasculino.Checked)
            {
                genero = "m";
            }
            else
            {
                genero = "f";
            }

            if (txtTelefone.Text == String.Empty || txtTelefone.Text.Length != 9 || !int.TryParse(txtTelefone.Text, out telefone))
            {
                MessageBox.Show("O número de telefone deve ser apenas números com comprimento de 9 números", "Aviso", MessageBoxButtons.OK);
                txtTelefone.Focus();
                return;
            }

            if (txtEmail.Text == String.Empty)
            {
                MessageBox.Show("Preenche o email", "Aviso", MessageBoxButtons.OK);
                txtEmail.Focus();
                return;
            }

            if (txtMorada.Text == String.Empty)
            {
                MessageBox.Show("Preenche a morada", "Aviso", MessageBoxButtons.OK);
                txtMorada.Focus();
                return;
            }

            if (comboBoxSubscricoes.SelectedIndex == -1)
            {
                MessageBox.Show("Escolhe uma subscrição", "Aviso", MessageBoxButtons.OK);
                comboBoxSubscricoes.Focus();
                return;
            }
            else
            {
                subscricao = Convert.ToInt32(comboBoxSubscricoes.SelectedItem.ToString().Split('-')[0].Split(':')[1]);
            }

            if (dataPickerFimSubscricao.Value <= DateTime.Now)
            {
                MessageBox.Show("A data de subscrição tem de ser superior a de hoje", "Aviso", MessageBoxButtons.OK);
                dataPickerFimSubscricao.Focus();
                return;
            }

            if (txtUsername.Text == String.Empty)
            {
                MessageBox.Show("Preenche o username", "Aviso", MessageBoxButtons.OK);
                txtUsername.Focus();
                return;
            }

            if (txtPassword.Text == String.Empty)
            {
                MessageBox.Show("Preenche a password", "Aviso", MessageBoxButtons.OK);
                txtPassword.Focus();
                return;
            }

            Login loginTemp = null;

            try
            {
                loginTemp = new LoginDBController().getByUsername(txtUsername.Text);
            }
            catch
            {
                MessageBox.Show("Ocorreu algum erro, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
                return;
            }

            if (loginTemp != null)
            {
                MessageBox.Show("Ja existe uma conta com esse username, escolhe outro", "Aviso", MessageBoxButtons.OK);
                txtUsername.Text = String.Empty;
                txtUsername.Focus();
                return;
            }

            Cliente cliente = new Cliente(txtPrimNome.Text, txtUltNome.Text, datePickerDataNascimento.Value, nif, genero, telefone,
                                                      txtEmail.Text, txtMorada.Text, 1, Program.defaultPhoto, subscricao, DateTime.Now, dataPickerFimSubscricao.Value);

            if (!cliente.inserir())
            {
                MessageBox.Show("Ocorreu algum erro a criar a conta, tente novamente mais tarde", "Erro", MessageBoxButtons.OK);
                return;
            }


            if (lblFoto.Text != Program.defaultPhoto)
            {
                string photoExtension = lblFoto.Text.Split('.').Last();
                if (cliente.saveImage(lblFoto.Text, "clientes", "cliente_" + cliente.id + "." + photoExtension)) cliente.alterar();
            }

            Login login = new Login(txtUsername.Text, txtPassword.Text, "cliente_" + cliente.id, createdByAdmin, 1);

            login.password = login.encryptPassword(login.password);

            if (!login.inserir())
            {
                MessageBox.Show("Ocorreu algum erro a criar a conta, tente novamente mais tarde", "Erro", MessageBoxButtons.OK);
                return;
            }

            MessageBox.Show("Conta criada com sucesso", "Sucesso", MessageBoxButtons.OK);
            this.Hide();
            if (createdByAdmin == 1)
            {
                FormConsultarClientes formConsultarClientes = new FormConsultarClientes();
                formConsultarClientes.Closed += (s, args) => this.Close();
                formConsultarClientes.Show();
            }
            else
            {
                Program.loginData = login;
                Program.clienteData = cliente;
                Program.tipoConta = "cliente";

                FormMenuCliente formMenuCliente = new FormMenuCliente();
                formMenuCliente.Closed += (s, args) => this.Close();
                formMenuCliente.Show();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Queres mesmo terminar o programa?", "Sair do Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Application.Exit();
            }
        }
    }
}
