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
    public partial class FormConsultarcliente : Form {
        public int idCliente;
        Cliente cliente;

        public FormConsultarcliente() {
            InitializeComponent();
        }

        private void FormConsultarcliente_Load(object sender, EventArgs e) {

            try {
                cliente = new ClienteDBController().getById(idCliente);

                if (cliente == null) throw new Exception("Cliente Não existe");
            } catch {
                MessageBox.Show("Ocorreu algum erro a obeter os dados do cliente, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblID.Text = cliente.id.ToString();
            lblNomeCliente.Text = cliente.primNome + " " + cliente.ultNome;
            lblDataNascimento.Text = Program.convertDateToString(cliente.dataNascimento);
            lblNif.Text = cliente.nif.ToString();
            lblGenero.Text = cliente.genero == "m" ? "Masculino" : "Femenino";
            lblTelefone.Text = cliente.telefone.ToString();
            lblEmail.Text = cliente.email;
            lblMorada.Text = cliente.morada;
            
            if (cliente.getSubscricaoData()) {
                groupBoxDadosPlano.Visible = true;
                lblIDPlano.Text = cliente.subscricao.id.ToString();
                lblNomePlano.Text = cliente.subscricao.nome;
                lblPreco.Text = cliente.subscricao.preco.ToString();
            }

            if (cliente.getAulasCliente()) {
                groupBoxAulasCliente.Visible = true;

                dgvAulasCliente.Columns.Add("modalidade", "Modalidade");
                dgvAulasCliente.Columns.Add("nSala", "Nº Sala");
                dgvAulasCliente.Columns.Add("maxAlunos", "Maximos de alunos");
                dgvAulasCliente.Columns.Add("diaSemana", "Dia da semana");
                dgvAulasCliente.Columns.Add("hora", "Hora");
                dgvAulasCliente.Columns.Add("professor", "Professor");

                foreach (Aula aula in cliente.aulas) {
                    if (aula == null) continue;

                    string modalidade = "Não encontrada", professor = "Não encontrado";

                    if (aula.getModalidadeAula()) modalidade = aula.modalidade.nome;
                    if (aula.getProfessorModalidade()) professor = aula.professor.primNome + " " + aula.professor.ultNome;

                    dgvAulasCliente.Rows.Add(modalidade, aula.nSala, aula.maxAlunos, Program.convertDiaSemanaToString(aula.diaSemana), aula.hora, professor);
                }
            }

            if (cliente.getAvaliacoesFisicas()) {
                groupBoxAvaliacoesFisicas.Visible = true;

                dgvAvaliacoesFisica.Columns.Add("id", "Id");
                dgvAvaliacoesFisica.Columns.Add("peso", "Peso");
                dgvAvaliacoesFisica.Columns.Add("tamanho", "Tamanho");
                dgvAvaliacoesFisica.Columns.Add("gordura", "Gordura");
                dgvAvaliacoesFisica.Columns.Add("massaMuscular", "Massa Muscular");
                dgvAvaliacoesFisica.Columns.Add("data", "Data");

                foreach (AvaliacaoFisica avaliacaoFisica in cliente.avaliacoesFisicas) {
                    if (avaliacaoFisica == null) continue;
                    dgvAvaliacoesFisica.Rows.Add(avaliacaoFisica.id, avaliacaoFisica.peso, avaliacaoFisica.tamanho, avaliacaoFisica.gordura, avaliacaoFisica.massaMuscular, Program.convertDateToString(avaliacaoFisica.data));
                }
            }

            if (cliente.getExtrasCliente()) {
                groupBoxExtras.Visible = true;

                dgvExtras.Columns.Add("nome", "Nome");
                dgvExtras.Columns.Add("preco", "Preço");
                dgvExtras.Columns.Add("quantidade", "Quantidade");
                dgvExtras.Columns.Add("precoTotal", "Preço Total");

                foreach (ExtrasCliente extrasCliente in cliente.extras) {
                    if (extrasCliente == null) continue;

                    string nome = "Não encontrado";
                    float preco = 0;

                    if (extrasCliente.getExtraData()) {
                        nome = extrasCliente.extra.nome;
                        preco = extrasCliente.extra.preco;
                    }

                    dgvExtras.Rows.Add(nome, preco, extrasCliente.quantidade, extrasCliente.quantidade * preco);
                }
            }

            if (cliente.getPlanoNutricional()) {
                groupBoxPlanoNutricional.Visible = true;

                dgvPlanoNutricional.Columns.Add("diaSemana", "Dia Semana");
                dgvPlanoNutricional.Columns.Add("pequenoAlmoco", "Pequeno Almoço");
                dgvPlanoNutricional.Columns.Add("lancheManha", "Lanche da Manha");
                dgvPlanoNutricional.Columns.Add("almoco", "Almoço");
                dgvPlanoNutricional.Columns.Add("lancheTarde", "Lanche da Tarde");
                dgvPlanoNutricional.Columns.Add("jantar", "Jantar");
                dgvPlanoNutricional.Columns.Add("ceia", "Ceia");

                foreach (PlanoNutricional planoNutricional in cliente.planoNutricional) {
                    if (planoNutricional == null) continue;

                    dgvPlanoNutricional.Rows.Add(Program.convertDiaSemanaToString(planoNutricional.diaSemana), planoNutricional.pequenoAlomoco, planoNutricional.pequenoAlomoco
                                                 , planoNutricional.almoco, planoNutricional.lancheTarde, planoNutricional.jantar, planoNutricional.ceia);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnRemoverAvaliacaoFisica_Click(object sender, EventArgs e) {
            if (dgvAvaliacoesFisica.SelectedRows.Count != 1) {
                MessageBox.Show("Tens de ter um e apenas um registo selecionado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idAvalicaoFisica = Convert.ToInt32(dgvAvaliacoesFisica.SelectedRows[0].Cells["id"].Value);

            bool status = false;

            if (!cliente.getAvaliacoesFisicas()) {
                MessageBox.Show("Ocorreu algum erro, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
                return;
            }

            foreach (AvaliacaoFisica avaliacaoFisica in cliente.avaliacoesFisicas) {
                if (avaliacaoFisica == null) continue;

                if (avaliacaoFisica.id == idAvalicaoFisica) {
                    status = avaliacaoFisica.remover();
                    break;
                }
            }

            if (status) {
                if (cliente.getAvaliacoesFisicas()) {
                    MessageBox.Show("Avaliação removida com sucesso", "Informação", MessageBoxButtons.OK);
                    dgvAvaliacoesFisica.Rows.Clear();

                    foreach (AvaliacaoFisica avaliacaoFisica in cliente.avaliacoesFisicas) {
                        if (avaliacaoFisica == null) continue;
                        dgvAvaliacoesFisica.Rows.Add(avaliacaoFisica.id, avaliacaoFisica.peso, avaliacaoFisica.tamanho, avaliacaoFisica.gordura, avaliacaoFisica.massaMuscular, Program.convertDateToString(avaliacaoFisica.data));
                    }
                } else {
                    MessageBox.Show("Avaliação removida com sucesso, porem ocorreu algum erro a atualizar as avaliações do cliente", "Erro", MessageBoxButtons.OK);
                }
            } else {
                MessageBox.Show("Ocorreu algum erro a remover a avaliação fisica, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
            }
        }

        private void btnRemoverPlanoNutricional_Click(object sender, EventArgs e) {
            if (dgvPlanoNutricional.SelectedRows.Count != 1) {
                MessageBox.Show("Tens de ter um e apenas um registo selecionado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int diaPlanoNutricional = Program.convertStringToDiaSemana(dgvPlanoNutricional.SelectedRows[0].Cells["diaSemana"].Value.ToString());

            if (diaPlanoNutricional == -1) {
                MessageBox.Show("Ocorreu algum erro, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
                return;
            }

            bool status = false;

            if (!cliente.getPlanoNutricional()) {
                MessageBox.Show("Ocorreu algum erro, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
                return;
            }

            foreach (PlanoNutricional planoNutricional in cliente.planoNutricional) {
                if (planoNutricional == null) continue;

                if (planoNutricional.diaSemana == diaPlanoNutricional) {
                    status = planoNutricional.remover();
                    break;
                }
            }

            if (status) {
                if (cliente.getPlanoNutricional()) {
                    MessageBox.Show("Plano nutricional removido com sucesso", "Informação", MessageBoxButtons.OK);
                    dgvPlanoNutricional.Rows.Clear();

                    foreach (PlanoNutricional planoNutricional in cliente.planoNutricional) {
                        if (planoNutricional == null) continue;

                        dgvPlanoNutricional.Rows.Add(Program.convertDiaSemanaToString(planoNutricional.diaSemana), planoNutricional.pequenoAlomoco, planoNutricional.pequenoAlomoco
                                                     , planoNutricional.almoco, planoNutricional.lancheTarde, planoNutricional.jantar, planoNutricional.ceia);
                    }
                } else {
                    MessageBox.Show("Plano nutricional removido com sucesso, porem ocorreu algum erro a atualizar o plano nutricional do cliente", "Erro", MessageBoxButtons.OK);
                }
            } else {
                MessageBox.Show("Ocorreu algum erro a remover o plano nutricional, tenta novamente mais tarde", "Erro", MessageBoxButtons.OK);
            }
        }
    }
}
