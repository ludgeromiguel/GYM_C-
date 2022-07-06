using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ginasio.DatabaseControllers;

namespace Ginasio.Classes {
    internal class Subscricao {
        private int _id;
        private string _nome;
        private float _preco;
        private int _isActive;
        private Cliente[] _clientes;

        public Subscricao(string nome, float preco, int isActive) {
            this._nome = nome;
            this._preco = preco;
            this._isActive = isActive;
        }

        public Subscricao(int id, string nome, float preco, int isActive) {
            this._id = id;
            this._nome = nome;
            this._preco = preco;
            this._isActive = isActive;
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

        public int isActive {
            get { return this._isActive; }
            set { this._isActive = value; }
        }

        public Cliente[] clientes {
            get { return this._clientes; }
        }

        public bool getClientesSubscricao() {
            bool status = true;

            try {
                this._clientes = new ClienteDBController().getClientesSubscricao(this._id);
            } catch {
                status = false;
            }

            return status;
        }

        public bool inserir() {
            int id = new SubscricaoDBController().inserir(this);

            if (id == -1) return false;
            
            this._id = id;

            return true;
        }

        public bool alterar() {
            return new SubscricaoDBController().alterar(this);
        }

        public bool remover() {
            return new SubscricaoDBController().remover(this._id);
        }
    }
}
