using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ginasio.DatabaseControllers;

namespace Ginasio.Classes {
    internal class Funcionario : Pessoa {
        private float _salario;
        private DateTime _inicioContrato;
        private DateTime _fimContrato;
        private string _turnoInicio;
        private string _turnoFim;
        private int _idTipoCargo;
        private Cargo _cargo;
        private Equipamento[] _equipamentos;
        private Aula[] _aulas;

        public Funcionario(string primNome, string ultNome, DateTime dataNascimento, int nif, string genero,
                           int telefone, string email, string morada, int isActive, string foto, float salario,
                           DateTime inicioContrato, DateTime fimContrato, string turnoInicio, string turnoFim, int idTipoCargo) :
                           base(primNome, ultNome, dataNascimento, nif, genero, telefone, email, morada, isActive, foto) {
            this._salario = salario;
            this._inicioContrato = inicioContrato;
            this._fimContrato = fimContrato;
            this._turnoInicio = turnoInicio;
            this._turnoFim = turnoFim;
            this._idTipoCargo = idTipoCargo;
        }

        public Funcionario(int id, string primNome, string ultNome, DateTime dataNascimento, int nif, string genero,
                           int telefone, string email, string morada, int isActive, string foto, float salario,
                           DateTime inicioContrato, DateTime fimContrato, string turnoInicio, string turnoFim, int idTipoCargo) : 
                           base(id, primNome, ultNome, dataNascimento, nif, genero, telefone, email, morada, isActive, foto) {
            this._salario = salario;
            this._inicioContrato = inicioContrato;
            this._fimContrato = fimContrato;
            this._turnoInicio = turnoInicio;
            this._turnoFim = turnoFim;
            this._idTipoCargo = idTipoCargo;
        }

        public float salario {
            get { return this._salario; }
            set { this._salario = value; }
        }

        public DateTime inicioContrato {
            get { return this._inicioContrato; }
            set { this._inicioContrato = value; }
        }

        public DateTime fimContrato {
            get { return this._fimContrato; }
            set { this._fimContrato = value; }
        }

        public string turnoInicio {
            get { return this._turnoInicio; }
            set { this._turnoInicio = value; }
        }

        public string turnoFim {
            get { return this._turnoFim; }
            set { this._turnoFim = value; }
        }

        public int idTipoCargo {
            get { return this._idTipoCargo; }
            set { this._idTipoCargo = value; }
        }

        public Cargo cargo {
            get { return this._cargo; }
        }
        
        public Equipamento[] equipamentos {
            get { return this._equipamentos; }
        }

        public Aula[] aulas {
            get { return this._aulas; }
        }

        public bool getCargoData() {
            bool status = true;

            try {
                this._cargo = new CargoDBController().getById(this._idTipoCargo);
            } catch {
                status = false;
            }

            return status;
        }

        public bool getEquipamentosData() {
            bool status = true;

            try {
                this._equipamentos = new EquipamentoDBController().getByFuncionario(this.id);
            } catch {
                status = false;
            }

            return status;
        }

        public bool getAulasFuncionario() {
            bool status = true;

            try {
                this._aulas = new AulaDBController().getAulasByFuncionarioID(this.id);
            } catch {
                status = false;
            }

            return status;
        }

        public bool inserir() {
            int id = new FuncionarioDBController().inserir(this);

            if (id == -1) return false;

            this.id = id;

            return true;
        }

        public bool alterar() {
            return new FuncionarioDBController().alterar(this);
        }
    }
}
