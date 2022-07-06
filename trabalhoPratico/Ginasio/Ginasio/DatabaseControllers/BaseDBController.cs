using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Ginasio.DatabaseControllers {
    abstract class BaseDBController {
        protected MySqlConnection connection;
        protected MySqlDataReader reader;
        protected MySqlCommand command;
        protected MySqlDataAdapter adapter;
        protected string sql;

        protected MySqlConnection DBConn() {
            connection = new MySqlConnection("Server=localhost;Database=ginasio;Uid=root;Pwd=;");
            return connection;
        }

        protected void closeDB() {
            connection.Close();
            connection = null;
            command = null;
        }

        protected int getNumRegistosDB(string tableName) {
            int nRegistos;

            try {
                connection = DBConn();

                sql = "select count(1) as nRegistos from " + tableName;

                command = new MySqlCommand(sql, connection);

                connection.Open();

                reader = command.ExecuteReader();

                if (reader != null && reader.HasRows && reader.Read()) {
                    nRegistos = Convert.ToInt32(reader["nRegistos"]);
                } else {
                    nRegistos = 0;
                }
                } catch {
                nRegistos = 0;
            } finally {
                closeDB();
            }

            return nRegistos;
        }

        protected string convertDateTimeToDateDb(DateTime date) {
            return date.Year + "-" + date.Month + "-" + date.Day;
        }

        protected DateTime converteDataDBToDateTime(string date) {
            string[] tempo = date.Split('-');

            tempo[2] = tempo[2].Split(' ')[0];

            return new DateTime(Convert.ToInt32(tempo[2]), Convert.ToInt32(tempo[1]), Convert.ToInt32(tempo[0]));
        }
    }
}
