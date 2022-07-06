using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ginasio.Classes;
using Ginasio.DatabaseControllers;

namespace Ginasio
{
    internal static class Program {
        public static Login loginData = null;
        public static Cliente clienteData = null;
        public static Funcionario funcionarioData = null;
        public static string tipoConta = null;

        public static readonly string cargoPrincipal = "Recursos Humanos";
        public static readonly string defaultPhoto = "default";

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!checkSystemConfigs()) {
                MessageBox.Show("Não foi possível fazer as configurações iniciais para o programa", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            Application.Run(new FormLogin());
        }

        // Função para verificar se tem o cargo "recursos humanos" e algum funcionario com esse cargo
        static bool checkSystemConfigs() {
            string username, password = "passwordAdmin";
            int i = 0;

            Cargo cargo = null;
            Funcionario funcionario = null;
            Login login = null;

            try {
                Cargo[] cargos = new CargoDBController().searchByNomeSistema(cargoPrincipal.ToLower().Replace(" ", "_"));

                if (cargos.Length != 0) cargo = cargos.FirstOrDefault();
            } catch {
                return false;
            }

            if (cargo == null) {
                try {
                    cargo = new Cargo(cargoPrincipal);

                    if (!cargo.inserir()) return false;
                } catch {
                    return false;
                }
            } else return true;

            try {
                Funcionario[] funcionarios = new FuncionarioDBController().getFuncionariosCargo(cargo.id);

                if (funcionarios.Length != 0) funcionario = funcionarios[0];
            } catch {
                return false;
            }

            if (funcionario == null) {
                DateTime dataFimContrato = new DateTime().AddYears(10);
                funcionario = new Funcionario("Admin", "System", new DateTime(2003, 10, 10), 999999999, "m", 999999999, "admin@system.com", "System", 1, Program.defaultPhoto, 10000, DateTime.Now, dataFimContrato, "09:00", "18:00", cargo.id);

                if (!funcionario.inserir()) return false;

                try {
                    login = new LoginDBController().getByUsername("admin");
                } catch {
                    return false;
                }

                if (login == null) {
                    username = "admin";
                } else {
                    while (login != null) {
                        i++;
                        login = new LoginDBController().getByUsername("admin" + i);
                    }

                    username = "admin" + i;
                }

                login = new Login(username, password, "funcionario_" + funcionario.id, 1, 1);

                login.password = login.encryptPassword(password);

                if (!login.inserir()) return false;

                MessageBox.Show("Conta " + username + " criada", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            } else return true;
        }

        public static string convertDateToString(DateTime date) {
            return date.Day + "/" + date.Month + "/" + date.Year;
        }

        public static string convertDiaSemanaToString(int diaSemana) {
            string[] diasSemana = { "Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sabado" };

            return diasSemana[diaSemana - 1];
        }

        public static int convertStringToDiaSemana(string str) {
            int diaSemana;

            switch (str.ToLower()) {
                case "domingo":
                    diaSemana = 1;
                    break;
                case "segunda":
                    diaSemana = 2;
                    break;
                case "terça":
                    diaSemana = 3;
                    break;
                case "quarta":
                    diaSemana = 4;
                    break;
                case "quinta":
                    diaSemana = 5;
                    break;
                case "sexta":
                    diaSemana = 6;
                    break;
                case "sabado":
                    diaSemana = 7;
                    break;
                default:
                    diaSemana = 0;
                    break;
            }

            return diaSemana;
        }

        public static int calcultateAge(DateTime data) {
            int age = DateTime.Now.Year - data.Year;
            if (DateTime.Now.DayOfYear < data.DayOfYear) age--;

            return age;
        }
    }
}
