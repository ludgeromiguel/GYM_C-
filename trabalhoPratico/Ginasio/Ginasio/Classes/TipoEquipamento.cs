using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ginasio.DatabaseControllers;

namespace Ginasio.Classes {
    internal class TipoEquipamento {
        private int _id;
        private string _nome;
        private string _nomeSistema;
        private Equipamento[] _equipamentos;

        public TipoEquipamento(string nome) {
            this._nome = nome;
            this._nomeSistema = nome.ToLower().Replace(" ", "_");
        }

        public TipoEquipamento(int id, string nome, string NomeSistema) {
            this._id = id;
            this._nome = nome;
            this._nomeSistema = NomeSistema;
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

        public Equipamento[] equipamentos {
            get { return this._equipamentos; }
        }

        public bool getEquipamentosTipo() {
            bool status = true;

            try {
                this._equipamentos = new EquipamentoDBController().getByTipoEquipamento(this._id);
            } catch {
                status = false;
            }

            return status;
        }

        public bool inserir() {
            int id = new TipoEquipamentoDBController().inserir(this);

            if (id == -1) return false;

            this._id = id;

            return true;
        }

        public bool remover() {
            return new TipoEquipamentoDBController().remover(this._id);
        }
    }
}
