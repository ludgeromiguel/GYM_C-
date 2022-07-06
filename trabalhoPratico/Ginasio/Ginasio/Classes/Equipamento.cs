using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ginasio.DatabaseControllers;

namespace Ginasio.Classes {
    internal class Equipamento {
        private int _id;
        private string _nome;
        private int _quantidade;
        private int _idTipoEquipamento;
        private int _idFuncionario;
        private TipoEquipamento _tipoEquipamento;
        private Funcionario _funcionario;

        public Equipamento(string nome, int quantidade, int idTipoEquipamento, int idFuncionario) {
            this._nome = nome;
            this._quantidade = quantidade;
            this._idTipoEquipamento = idTipoEquipamento;
            this._idFuncionario = idFuncionario;
        }

        public Equipamento(int id, string nome, int quantidade, int idTipoEquipamento, int idFuncionario) {
            this._id = id;
            this._nome = nome;
            this._quantidade = quantidade;
            this._idTipoEquipamento = idTipoEquipamento;
            this._idFuncionario = idFuncionario;
        }

        public int id {
            get { return this._id; }
        }

        public string nome {
            get { return this._nome; }
            set { this._nome = value; }
        }

        public int quantidade {
            get { return this._quantidade; }
            set { this._quantidade = value; }
        }

        public int idTipoEquipamento {
            get { return this._idTipoEquipamento; }
            set { this._idTipoEquipamento = value; }
        }

        public int idFuncionario {
            get { return this._idFuncionario; }
            set { this._idFuncionario = value; }
        }

        public TipoEquipamento tipoEquipamento {
            get { return this._tipoEquipamento; }
        }

        public Funcionario funcionario {
            get { return this._funcionario; }
        }

        public bool getTipoEquipamento() {
            bool status = true;

            try {
                this._tipoEquipamento = new TipoEquipamentoDBController().getById(this._idTipoEquipamento);
            } catch {
                status = false;
            }

            return status;
        }

        public bool getFuncionario() {
            bool status = true;

            try {
                this._funcionario = new FuncionarioDBController().getById(this._idFuncionario);
            } catch {
                status = false;
            }

            return status;
        }

        public bool inserir() {
            int id = new EquipamentoDBController().inserir(this);

            if (id == -1) return false;

            this._id = id;

            return true;
        }

        public bool alterar() {
            return new EquipamentoDBController().alterar(this);
        }

        public bool remover() {
            return new EquipamentoDBController().remover(this._id);
        }
    }
}
