using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ginasio.DatabaseControllers;

namespace Ginasio.Classes {
    internal class Aula {
        private int _id;
        private int _idModalidade;
        private int _nSala;
        private int _maxAlunos;
        private int _diaSemana;
        private string _hora;
        private int _idProfessor;
        private Modalidade _modalidade;
        private Funcionario _professor;

        public Aula(int idModalidade, int nSala, int maxAlunos, int diaSemana, string hora, int idProfessor) {
            this._idModalidade = idModalidade;
            this._nSala = nSala;
            this._maxAlunos = maxAlunos;
            this._diaSemana = diaSemana;
            this._hora = hora;
            this._idProfessor = idProfessor;
        }

        public Aula(int id, int idModalidade, int nSala, int maxAlunos, int diaSemana, string hora, int idProfessor) {
            this._id = id;
            this._idModalidade = idModalidade;
            this._nSala = nSala;
            this._maxAlunos = maxAlunos;
            this._diaSemana = diaSemana;
            this._hora = hora;
            this._idProfessor = idProfessor;
        } 

        public int id {
            get { return this._id; }
        }

        public int idModalidade {
            get { return this._idModalidade; }
            set { this._idModalidade = value; }
        }

        public int nSala {
            get { return this._nSala; }
            set { this._nSala = value; }
        }

        public int maxAlunos {
            get { return this._maxAlunos; }
            set { this._maxAlunos = value; }
        }

        public int diaSemana {
            get { return this._diaSemana; }
            set { this._diaSemana = value; }
        }

        public string hora {
            get { return this._hora; }
            set { this._hora = value; }
        }

        public int idProfessor {
            get { return this._idProfessor; }
            set { this._idProfessor = value; }
        }

        public Modalidade modalidade {
            get { return this._modalidade; }
        }

        public Funcionario professor {
            get { return this._professor; }
        }

        public bool getModalidadeAula() {
            bool status = true;

            try {
                this._modalidade = new ModalidadeDBController().getById(this._idModalidade);
            } catch {
                status = false;
            }

            return status;
        }

        public bool getProfessorModalidade() {
            bool status = true;

            try {
                this._professor = new FuncionarioDBController().getById(this._idProfessor);
            } catch {
                status = false;
            }

            return status;
        }

        public bool inserir() {
            int id = new AulaDBController().inserir(this);

            if (id == -1) return false;

            this._id = id;

            return true;
        }

        public bool alterar() {  
            return new AulaDBController().alterar(this);
        }

        public bool remover() {
            return new AulaDBController().remover(this._id);
        }
    }
}
