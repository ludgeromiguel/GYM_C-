using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ginasio.DatabaseControllers;

namespace Ginasio.Classes {
    internal class TipoReclamacao {
        private int _id;
        private string _nome;
        private string _nomeSistema;
        private LivroReclamacao[] _livroReclamacaos;

        public TipoReclamacao(string nome) {
            this._nome = nome;
            this._nomeSistema = nome.ToLower().Replace(" ", "_");
        }

        public TipoReclamacao(int id, string nome, string nomeSistema) {
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

        public LivroReclamacao[] livroReclamacaos {
            get { return this._livroReclamacaos; }
        }

        public bool getReclamacoesTipo() {
            bool status = true;

            try {
                this._livroReclamacaos = new LivroReclamacoesDBController().getReclamacoesTipo(this._id);
            } catch {
                status = false;
            }

            return status;
        }

        public bool inserir() {
            int id = new TipoReclamacaoDBController().inserir(this);

            if (id == -1) return false;

            this._id = id;

            return true;
        }

        public bool remover() {
            return new TipoReclamacaoDBController().remover(this._id);
        }
    }
}
