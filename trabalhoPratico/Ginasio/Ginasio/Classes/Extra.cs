using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ginasio.DatabaseControllers;

namespace Ginasio.Classes {
    internal class Extra {
        private int _id;
        private string _nome;
        private float _preco;
        private ExtrasCliente[] _clientesExtra;

        public Extra(string nome, float preco) {
            this._nome = nome;
            this._preco = preco;
        }

        public Extra(int id, string nome, float preco) {
            this._id = id;
            this._nome = nome;
            this._preco = preco;
        }

        public int id {
            get { return this._id; }
        }

        public string nome {
            get { return this._nome; }
            set { this._nome = value; }
        }

        public float preco {
            get { return this._preco; }
            set { this._preco = value; }
        }

        public ExtrasCliente[] clientesExtra {
            get { return this._clientesExtra; }
        }

        public bool getClientesExtra() {
            bool status = true;

            try {
                this._clientesExtra = new ExtrasClienteDBController().getExtrasClienteByExtraId(this._id);
            } catch {
                status = false;
            }

            return status;
        }

        public bool inserir() {
            int id = new ExtraDBController().inserir(this);

            if (id == -1) return false;

            this._id = id;

            return true;
        }

        public bool alterar() {
            return new ExtraDBController().alterar(this);
        }

        public bool remover() {
            return new ExtraDBController().remover(this._id);
        }
    }
}
