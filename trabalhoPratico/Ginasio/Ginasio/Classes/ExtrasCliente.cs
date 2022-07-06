using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ginasio.DatabaseControllers;

namespace Ginasio.Classes {
    internal class ExtrasCliente {
        private int _idCliente;
        private int _idExtra;
        private int _quantidade;
        private Cliente _cliente;
        private Extra _extra;

        public ExtrasCliente(int idCliente, int idExtra, int quantidade) {
            this._idCliente = idCliente;
            this._idExtra = idExtra;
            this._quantidade = quantidade;
        }

        public int idCliente {
            get { return this._idCliente; }
        }

        public int idExtra {
            get { return this._idExtra; }
        }

        public int quantidade {
            get { return this._quantidade; }
            set { this._quantidade = value; }
        }

        public Cliente cliente {
            get { return this._cliente; }
        }

        public Extra extra {
            get { return this._extra; }
        }

        public bool getClienteData() {
            bool status = true;

            try {
                this._cliente = new ClienteDBController().getById(this._idCliente);
            } catch {
                status = false;
            }

            return status;
        }

        public bool getExtraData() {
            bool status = true;

            try {
                this._extra = new ExtraDBController().getById(this._idExtra);
            } catch {
                status = false;
            }

            return status;
        }

        public bool inserir() {
            return new ExtrasClienteDBController().inserir(this);
        }

        public bool alterar() {
            return new ExtrasClienteDBController().alterar(this);
        }

        public bool remover() {
            return new ExtrasClienteDBController().remover(this._idCliente, this._idExtra);
        }
    }
}
