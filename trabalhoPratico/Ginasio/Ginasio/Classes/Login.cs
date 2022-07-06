using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCryptNet = BCrypt.Net.BCrypt;
using MySql.Data.MySqlClient;
using Ginasio.DatabaseControllers;

namespace Ginasio.Classes {
    internal class Login {
        private int _id;
        private string _username;
        private string _password;
        private string _typeAccount; // "funcionario|cliente_id" Exemplo: "client_1", "funcionario_1"
        private int _createdByAdmin;
        private int _isActive;

        public Login(string username, string password, string typeAccount, int createdByAdmin, int isActive) {
            this._username = username;
            this._password = password;
            this._typeAccount = typeAccount;
            this._createdByAdmin = createdByAdmin;
            this._isActive = isActive;
        }

        public Login(int id, string username, string password, string typeAccount, int createdByAdmin, int isActive) {
            this._id = id;
            this._username = username;
            this._password = password;
            this._typeAccount = typeAccount;
            this._createdByAdmin = createdByAdmin;
            this._isActive = isActive;
        }

        public int id {
            get { return this._id; }
        }

        public string username {
            get { return this._username; }
        }

        public string password {
            get { return this._password; }
            set { this._password = value; }
        }

        public string typeAccount {
            get { return this._typeAccount; }
        }

        public int createdByAdmin {
            get { return this._createdByAdmin; }
            set { this._createdByAdmin = value; }
        }

        public int isActive {
            get { return this._isActive; }
            set { this._isActive = value; }
        }

        private string getRandomSalt() {
            return BCryptNet.GenerateSalt(12);
        }

        public string encryptPassword(string password) {
            return BCryptNet.HashPassword(password, getRandomSalt());
        }

        public bool verifyPassword(string password) {
            return BCryptNet.Verify(password, this._password);
        }

        public bool getDataTypeAccount() {
            bool status = true;

            try {
                string[] dataAccount = this._typeAccount.Split('_');

                if (dataAccount[0] == "cliente") {
                    Program.clienteData = new ClienteDBController().getById(Convert.ToInt32(dataAccount[1]));
                } else if (dataAccount[0] == "funcionario") {
                    Program.funcionarioData = new FuncionarioDBController().getById(Convert.ToInt32(dataAccount[1]));
                } else status = false;

                if (status) Program.tipoConta = dataAccount[0];
            } catch {
                status = false;
            }

            return status;
        }

        public bool inserir() {
            int id = new LoginDBController().inserir(this);

            if (id == -1) return false;

            this._id = id;

            return true;
        }

        public bool alterar() {
            return new LoginDBController().alterar(this);
        }
    }
}
