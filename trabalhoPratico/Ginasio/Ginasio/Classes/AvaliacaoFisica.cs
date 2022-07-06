using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ginasio.DatabaseControllers;

namespace Ginasio.Classes {
    internal class AvaliacaoFisica {
        private int _id;
        private int _idCliente;
        private float _peso;
        private int _tamanho;
        private float _gordura;
        private float _massaMuscular;
        private DateTime _data;
        private Cliente _cliente;

        public AvaliacaoFisica(int idCliente, float peso, int tamanho, float gordura, float massaMuscular, DateTime data) {
            this._idCliente = idCliente;
            this._peso = peso;
            this._tamanho = tamanho;
            this._gordura = gordura;
            this._massaMuscular = massaMuscular;
            this._data = data;
        }

        public AvaliacaoFisica(int id, int idCliente, float peso, int tamanho, float gordura, float massaMuscular, DateTime data) {
            this._id = id;
            this._idCliente = idCliente;
            this._peso = peso;
            this._tamanho = tamanho;
            this._gordura = gordura;
            this._massaMuscular = massaMuscular;
            this._data = data;
        }

        public int id {
            get { return this._id; }
        }

        public int idCliente {
            get { return this._idCliente; }
        }

        public float peso {
            get { return this._peso; }
            set { this._peso = value; }
        }

        public int tamanho {
            get { return this._tamanho; }
            set { this._tamanho = value; }
        }
        
        public float gordura {
            get { return this._gordura; }
            set { this._gordura = value; }
        }

        public float massaMuscular {
            get { return this._massaMuscular; }
            set { this._massaMuscular = value; }
        }

        public DateTime data {
            get { return this._data; }
            set { this._data = value; }
        }

        public Cliente cliente {
            get { return this._cliente; }
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

        public bool inserir() {
            int id = new AvaliacaoFisicaDBController().insere(this);

            if (id == -1) return false;

            this._id = id;

            return true;
        }

        public bool alterar() {
            return new AvaliacaoFisicaDBController().alterar(this);
        }

        public bool remover() {
            return new AvaliacaoFisicaDBController().remover(this._id);
        }
    }
}
