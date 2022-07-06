using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ginasio.DatabaseControllers;

namespace Ginasio.Classes {
    internal class Modalidade {
        private int _id;
        private string _nome;
        private string _nomeSistema;
        private Aula[] _aulas;

        public Modalidade(string nome) {
            this._nome = nome;
            this._nomeSistema = nome.ToLower().Replace(" ", "_");
        }

        public Modalidade(int id, string nome, string nomeSistema) {
            this._id = id;
            this._nome = nome;
            this._nomeSistema = nomeSistema;
        }

        public int id {
            get { return this._id; }
        }

        public string nome {
            get { return this._nome; }
        }

        public string nomeSistema {
            get { return this._nomeSistema; }
        }

        public Aula[] aulas {
            get { return this._aulas; }
        }

        public bool getAulasModalidade() {
            bool status = true;

            try {
                this._aulas = new AulaDBController().getAulasByModalidadeID(this._id);
            } catch {
                status = false;
            }

            return status;
        }

        public bool insere() {
            int id = new ModalidadeDBController().inserir(this);

            if (id == -1) return false;

            this._id = id;

            return true;
        }

        public bool remover() {
            return new ModalidadeDBController().remover(this._id);
        }
    }
}
