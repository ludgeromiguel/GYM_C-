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
    public partial class FormConsultarExtrasCliente : Form
    {
        public FormConsultarExtrasCliente()
        {
            InitializeComponent();
        }

        private void FormConsultarExtrasCliente_Load(object sender, EventArgs e) {
            Extra[] extras = null;

            try {
                extras = new ExtraDBController().getAll();
            } catch {
                MessageBox.Show("Ocorreu algum erro, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
                return;
            }

            dgvExtra.Columns.Add("id", "Id");
            dgvExtra.Columns.Add("nome", "Nome");
            dgvExtra.Columns.Add("preco", "Preço");

            foreach (Extra extra in extras) {
                dgvExtra.Rows.Add(extra.id, extra.nome, extra.preco);
            }
        }

        private void Voltar_Click(object sender, EventArgs e) {
            this.Hide();
            FormMenuCliente formMenuCliente = new FormMenuCliente();
            formMenuCliente.Closed += (s, args) => this.Close();
            formMenuCliente.Show();
        }

        private void btnContrataExtra_Click(object sender, EventArgs e) {
            int quantidade;
            if (dgvExtra.SelectedRows.Count != 1) {
                MessageBox.Show("Tens de ter um e apenas um registo selecionado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idExtra = Convert.ToInt32(dgvExtra.SelectedRows[0].Cells["id"].Value);

            if (txtQuantidadeExtra.Text == String.Empty || !int.TryParse(txtQuantidadeExtra.Text, out quantidade) || quantidade < 0) {
                MessageBox.Show("A quantidade tem de ser um número maior ou igual a 0");
                txtQuantidadeExtra.Focus();
                return;
            } 

            ExtrasCliente extrasCliente = null;
            bool userAlreadyHaveExtra = false;

            if (!Program.clienteData.getExtrasCliente()) {
                MessageBox.Show("Ocorreu algum erro, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
                return;
            }

            foreach (ExtrasCliente extraCliente in Program.clienteData.extras) {
                if (extraCliente.idExtra == idExtra) {
                    userAlreadyHaveExtra = true;
                    extrasCliente = extraCliente;
                    break;
                }
            }

            if (userAlreadyHaveExtra) {
                if (quantidade == 0) {
                    if (MessageBox.Show("Deseja remover esse extra?", "Pergunta", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                        if (extrasCliente.remover()) {
                            MessageBox.Show("Extra removido com sucesso", "Informação", MessageBoxButtons.OK);
                            txtQuantidadeExtra.Text = String.Empty;
                        } else {
                            MessageBox.Show("Ocorreu algum problema a remover o extra", "Erro", MessageBoxButtons.OK);
                        }
                    }
                } else {
                    if (MessageBox.Show("Deseja alterar a quantidade do extra que ja tem ?", "Pergunta", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                        extrasCliente.quantidade = quantidade;

                        if (extrasCliente.alterar()) {
                            MessageBox.Show("Extra alterado com sucesso", "Informação", MessageBoxButtons.OK);
                        } else {
                            MessageBox.Show("Ocorreu algum erro a alterar a quantidade do extra", "Erro", MessageBoxButtons.OK);
                        }
                    }
                }
            } else {
                if (quantidade == 0) {
                    MessageBox.Show("A quantidade tem de ser superior a 0", "Aviso", MessageBoxButtons.OK);
                    txtQuantidadeExtra.Focus();
                    return;
                }

                extrasCliente = new ExtrasCliente(Program.clienteData.id, idExtra, quantidade);

                if (extrasCliente.inserir()) {
                    MessageBox.Show("Extra contratado com sucesso", "Informação", MessageBoxButtons.OK);
                } else {
                    MessageBox.Show("Ocorreu algum erro a contratar o extra", "Erro", MessageBoxButtons.OK);
                }
            }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Queres mesmo terminar o programa?", "Sair do Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Application.Exit();
            }
        }
    }
}
