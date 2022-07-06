using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ginasio.DatabaseControllers;

namespace Ginasio.Classes {
    internal class Cliente : Pessoa {
        private int _idSubscricao;
        private DateTime _inicioSubscricao;
        private DateTime _fimSubscricao;
        private Subscricao _subscricao;
        private LivroReclamacao[] _reclamacoes;
        private AvaliacaoFisica[] _avaliacoesFisicas;
        private PlanoNutricional[] _planoNutricional;
        private ExtrasCliente[] _extras;
        private Aula[] _aulas;

        public Cliente(string primNome, string ultNome, DateTime dataNascimento, int nif, string genero,
                       int telefone, string email, string morada, int isActive, string foto,
                       int idSubscricao, DateTime inicioSubscricao, DateTime fimSubscricao) :
                       base(primNome, ultNome, dataNascimento, nif, genero, telefone, email, morada, isActive, foto) {
            this._idSubscricao = idSubscricao;
            this._inicioSubscricao = inicioSubscricao;
            this._fimSubscricao = fimSubscricao;
        }

        public Cliente(int id, string primNome, string ultNome, DateTime dataNascimento, int nif, string genero,
                       int telefone, string email, string morada, int isActive, string foto,
                       int idSubscricao, DateTime inicioSubscricao, DateTime fimSubscricao) : 
                       base(id, primNome, ultNome, dataNascimento, nif, genero, telefone, email, morada, isActive, foto) {
            this._idSubscricao = idSubscricao;
            this._inicioSubscricao = inicioSubscricao;
            this._fimSubscricao = fimSubscricao;
        }

        public int idSubscricao {
            get { return this._idSubscricao; }
            set { this._idSubscricao = value; }
        }

        public DateTime inicioSubscricao {
            get { return this._inicioSubscricao; }
            set { this._inicioSubscricao = value; }
        }

        public DateTime fimSubscricao {
            get { return this._fimSubscricao; }
            set { this._fimSubscricao = value; }
        }

        public Subscricao subscricao {
            get { return this._subscricao; }
        }

        public LivroReclamacao[] reclamacoes {
            get { return this._reclamacoes; }
        }

        public AvaliacaoFisica[] avaliacoesFisicas {
            get { return this._avaliacoesFisicas; }
        }

        public PlanoNutricional[] planoNutricional {
            get { return this._planoNutricional; }
        }

        public ExtrasCliente[] extras {
            get { return this._extras; }
        }

        public Aula[] aulas {
            get { return this._aulas; }
        }

        public bool getSubscricaoData() {
            bool status = true;

            try {
                this._subscricao = new SubscricaoDBController().getById((int)this._idSubscricao);
            } catch {
                status = false;
            }

            return status;
        }

        public bool getReclamacoesCliente() {
            bool status = true;

            try {
                this._reclamacoes = new LivroReclamacoesDBController().getReclamacoesCliente(this.id);
            } catch {
                status = false;
            }

            return status;
        }

        public bool getAvaliacoesFisicas() {
            bool status = true;

            try {
                this._avaliacoesFisicas = new AvaliacaoFisicaDBController().getAvaliacoesCliente(this.id);
            } catch {
                status = false;
            }

            return status;
        }

        public bool getPlanoNutricional() {
            bool status = true;

            try {
                this._planoNutricional = new PlanoNutrucionalDBController().getPlanoNutricionalCliente(this.id);
            } catch {
                status = false;
            }

            return status;
        }

        public bool getExtrasCliente() {
            bool status = true;

            try {
                this._extras = new ExtrasClienteDBController().getExtrasClienteByClienteId(this.id);
            } catch {
                status = false;
            }

            return status;
        }

        public bool getAulasCliente() {
            bool status = true;

            try {
                this._aulas = new AulaDBController().getAulasByClientID(this.id);
            } catch {
                status = false;
            }

            return status;
        }

        public bool inserir() {
            int id = new ClienteDBController().inserir(this);

            if (id == -1) return false;

            this.id = id;

            return true;
        }

        public bool alterar() {
            return new ClienteDBController().alterar(this);
        }

        public bool subscreverAula(int idAula) {
            return new ClienteDBController().subscreverAula(this.id, idAula);
        }

        public bool unsubscreverAula(int idAula) {
            return new ClienteDBController().unsubscreverAula(this.id, idAula);
        }
    }
}
