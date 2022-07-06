using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ginasio.Classes {
    internal abstract class Pessoa {
        private int _id;
        private string _primNome;
        private string _ultNome;
        private DateTime _dataNascimento;
        private int _nif;
        private string _genero;
        private int _telefone;
        private string _email;
        private string _morada;
        private int _isActive;
        private string _foto;

        private string _baseDir = Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "images");

        public Pessoa(string primNome, string ultNome, DateTime dataNascimento, int nif, string genero,
                      int telefone, string email, string morada, int isActive, string foto) {
            this._primNome = primNome;
            this._ultNome = ultNome;
            this._dataNascimento = dataNascimento;
            this._nif = nif;
            this._genero = genero;
            this._telefone = telefone;
            this._email = email;
            this._morada = morada;
            this._isActive = isActive;
            this._foto = foto;
        }

        public Pessoa(int id, string primNome, string ultNome, DateTime dataNascimento, int nif, string genero,
                      int telefone, string email, string morada, int isActive, string foto) {
            this._id = id;
            this._primNome = primNome;
            this._ultNome = ultNome;
            this._dataNascimento = dataNascimento;
            this._nif = nif;
            this._genero = genero;
            this._telefone = telefone;
            this._email = email;
            this._morada = morada;
            this._isActive = isActive;
            this._foto = foto;
        }

        public int id {
            get { return this._id; }
            set { this._id = value; }
        }

        public string primNome {
            get { return this._primNome; }
            set { this._primNome = value; }
        }

        public string ultNome {
            get { return this._ultNome; }
            set { this._ultNome = value; }
        }

        public DateTime dataNascimento {
            get { return this._dataNascimento; }
            set { this._dataNascimento = value; }
        }

        public int nif {
            get { return this._nif; }
            set { this._nif = value; }
        }

        public string genero {
            get { return this._genero; }
            set { this._genero = value; }
        }

        public int telefone {
            get { return this._telefone; }
            set { this._telefone = value; }
        }

        public string email {
            get { return this._email; }
            set { this._email = value; }
        }

        public string morada {
            get { return this._morada; }
            set { this._morada = value; }
        }

        public int isActive {
            get { return this._isActive; }
            set { this._isActive = value; }
        }

        public string foto {
            get { return this._foto; }
            set { this._foto = value; }
        }

        public string getFotoPath() {
            if (this._foto == Program.defaultPhoto) return Program.defaultPhoto;
            else return Path.Combine(this._baseDir, this._foto);
        }

        public bool saveImage(string fileDir, string folder, string newFileName) {
            string dir = Path.Combine(this._baseDir, folder);

            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

            string imageDir = Path.Combine(dir, newFileName);

            try {
                File.Copy(fileDir, imageDir, true);

                this._foto = Path.Combine(folder, newFileName);

                return true;
            } catch {
                return false;
            }
        }

        public bool removeImage() {
            if (this._foto == null) return true;

            string dir = Path.Combine(this._baseDir, this._foto);

            if (!Directory.Exists(dir)) return true;

            try {
                File.Delete(dir);

                this._foto = Program.defaultPhoto;

                return true;
            } catch {
                return false;
            }
        }

        public int getAge() {
            int age = DateTime.Now.Year - this._dataNascimento.Year;
            if (DateTime.Now.DayOfYear < this._dataNascimento.DayOfYear) age--;

            return age;
        }
    }
}
