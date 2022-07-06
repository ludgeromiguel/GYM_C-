using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ginasio.DatabaseControllers;

namespace Ginasio.Classes {
    internal class PlanoNutricional {
        private int _diaSemana;
        private int _idCliente;
        private string _pequenoAlmoco;
        private string _lancheManha;
        private string _almoco;
        private string _lancheTarde;
        private string _jantar;
        private string _ceia;
        private Cliente _cliente;

        public PlanoNutricional(int diaSemana, int idCliente, string pequenoAlomoco, string lancheManha, string almoco, string lancheTarde, string jantar, string ceia) {
            this._diaSemana = diaSemana;
            this._idCliente = idCliente;
            this._pequenoAlmoco = pequenoAlomoco;
            this._lancheManha = lancheManha;
            this._almoco = almoco;
            this._lancheTarde = lancheTarde;
            this._jantar = jantar;
            this._ceia = ceia;
        }

        public int diaSemana {
            get { return this._diaSemana; }
        }

        public int idCliente {
            get { return this._idCliente; }
        }

        public string pequenoAlomoco {
            get { return this._pequenoAlmoco; }
            set { this._pequenoAlmoco = value; }
        }

        public string lancheManha {
            get { return this._lancheManha; }
            set { this._lancheManha = value; }
        }

        public string almoco {
            get { return this._almoco; }
            set { this._almoco = value; }
        }

        public string lancheTarde {
            get { return this._lancheTarde; }
            set { this._lancheTarde = value; }
        }

        public string jantar {
            get { return this._jantar; }
            set { this._jantar = value; }
        }

        public string ceia {
            get { return this._ceia; }
            set { this._ceia = value; }
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
            return new PlanoNutrucionalDBController().inserir(this);
        }

        public bool alterar() {
            return new PlanoNutrucionalDBController().alterar(this);
        }

        public bool remover() {
            return new PlanoNutrucionalDBController().remover(this._diaSemana, this._idCliente);
        }
    }
}
