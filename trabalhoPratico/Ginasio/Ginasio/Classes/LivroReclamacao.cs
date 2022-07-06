using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ginasio.DatabaseControllers;

namespace Ginasio.Classes {
    internal class LivroReclamacao {
        private int _id;
        private string _descricao;
        private int _idCliente;
        private int _idTipoReclamacao;
        private Cliente _cliente;
        private TipoReclamacao _tipoReclamacao;

        public LivroReclamacao(string descricao, int idCliente, int idTipoReclamacao) {
            this._descricao = descricao;
            this._idCliente = idCliente;
            this._idTipoReclamacao = idTipoReclamacao;
        }

        public LivroReclamacao(int id, string descricao, int idCliente, int idTipoReclamacao) {
            this._id = id;
            this._descricao = descricao;
            this._idCliente = idCliente;
            this._idTipoReclamacao = idTipoReclamacao;
        }

        public int id {
            get { return this._id; }
        }

        public string descricao {
            get { return this._descricao; }
            set { this._descricao = value; }
        }

        public int idCliente {
            get { return this._idCliente; }
        }

        public int idTipoReclamacao {
            get { return this._idTipoReclamacao; }
            set { this._idTipoReclamacao = value; }
        }

        public Cliente cliente {
            get { return this._cliente;  }
        }

        public TipoReclamacao tipoReclamacao {
            get { return this._tipoReclamacao; }
        }

        public bool getCliente() {
            bool status = true;

            try {
                this._cliente = new ClienteDBController().getById(this._idCliente);
            } catch {
                status = false;
            }

            return status;
        }

        public bool getTipoReclamacao() {
            bool status = true;

            try {
                this._tipoReclamacao = new TipoReclamacaoDBController().getById(this._idTipoReclamacao);
            } catch {
                status = false;
            }

            return status;
        }

        public bool inserir() {
            int id = new LivroReclamacoesDBController().insere(this);

            if (id == -1) return false;

            this._id = id;

            return true;
        }

        public bool alterar() {
            return new LivroReclamacoesDBController().aterar(this);
        }

        public bool remover() {
            return new LivroReclamacoesDBController().remover(this._id);
        }
    }
}
