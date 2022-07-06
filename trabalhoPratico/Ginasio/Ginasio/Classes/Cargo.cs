using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ginasio.DatabaseControllers;

namespace Ginasio.Classes {
    internal class Cargo {
        private int _id;
        private string _nome;
        private string _nomeSistema;
        private Funcionario[] _funcionarios;

        public Cargo(string nome) {
            this._nome = nome;
            this._nomeSistema = nome.ToLower().Replace(" ", "_");
        }

        public Cargo(int id, string nome, string nomeSistema) {
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

        public Funcionario[] funcionarios {
            get { return this._funcionarios; }
        }

        public bool getFuncionariosCargo() {
            bool status = true;

            try {
                this._funcionarios = new FuncionarioDBController().getFuncionariosCargo(this._id);
            } catch {
                status = false;
            }

            return status;
        }

        public bool inserir() {
            int id = new CargoDBController().inserir(this);

            if (id == -1) return false;

            this._id = id;

            return true;
        }

        public bool remover() {
            return new CargoDBController().remover(this._id);
        }
    }
}
