using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Ginasio.Classes;

namespace Ginasio.DatabaseControllers {
    internal class LoginDBController : BaseDBController {
        public int inserir(Login login) {
            int id;

            try {
                connection = DBConn();

                sql = "INSERT INTO login(username, password, typeAccount, createdByAdmin, isActive) VALUES(@username, @password, @typeAccount, @createdByAdmin, @isActive)";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@username", login.username);
                command.Parameters.AddWithValue("@password", login.password);
                command.Parameters.AddWithValue("@typeAccount", login.typeAccount);
                command.Parameters.AddWithValue("@createdByAdmin", login.createdByAdmin);
                command.Parameters.AddWithValue("@isActive", login.isActive);

                connection.Open();

                if (command.ExecuteNonQuery() == 1) {
                    command = null;

                    sql = "SELECT LAST_INSERT_ID() as `id` FROM `login` LIMIT 1";

                    command = new MySqlCommand(sql, connection);

                    reader = command.ExecuteReader();

                    if (reader != null && reader.HasRows && reader.Read()) {
                        id = Convert.ToInt32(reader["id"]);
                    } else {
                        id = -1;
                    }
                } else {
                    id = -1;
                }
            } catch {
                id = -1;
            } finally {
                closeDB();
            }

            return id;
        }

        public bool alterar(Login login) {
            bool status;

            try {
                connection = DBConn();

                sql = "UPDATE login SET password = @password, createdByAdmin = @createdByAdmin, isActive = @isActive WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@password", login.password);
                command.Parameters.AddWithValue("@createdByAdmin", login.createdByAdmin);
                command.Parameters.AddWithValue("@isActive", login.isActive);
                command.Parameters.AddWithValue("@id", login.id);

                connection.Open();

                if (command.ExecuteNonQuery() == 1) status = true;
                else status = false;
            } catch {
                status = false;
            } finally {
                closeDB();
            }

            return status;
        }

        public Login getByUsername(string loginUsername) {
            Login login = null;

            try {
                connection = DBConn();

                sql = "SELECT * FROM login WHERE username = @username";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@username", loginUsername);

                connection.Open();

                reader = command.ExecuteReader();

                if (reader != null && reader.HasRows && reader.Read()) {
                    int id, createdByAdmin, isActive;
                    string username, password, typeAccount;

                    id = Convert.ToInt32(reader["id"]);
                    username = Convert.ToString(reader["username"]);
                    password = Convert.ToString(reader["password"]);
                    typeAccount = Convert.ToString(reader["typeAccount"]);
                    createdByAdmin = Convert.ToInt32(reader["createdByAdmin"]);
                    isActive = Convert.ToInt32(reader["isActive"]);

                    login = new Login(id, username, password, typeAccount, createdByAdmin, isActive);
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return login;
        }

        public Login getByTypeAccount(string typeAccountLogin) {
            Login login = null;

            try {
                connection = DBConn();

                sql = "SELECT * FROM login WHERE typeAccount = @typeAccount";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@typeAccount", typeAccountLogin);

                connection.Open();

                reader = command.ExecuteReader();

                if (reader != null && reader.HasRows && reader.Read()) {
                    int id, createdByAdmin, isActive;
                    string username, password, typeAccount;

                    id = Convert.ToInt32(reader["id"]);
                    username = Convert.ToString(reader["username"]);
                    password = Convert.ToString(reader["password"]);
                    typeAccount = Convert.ToString(reader["typeAccount"]);
                    createdByAdmin = Convert.ToInt32(reader["createdByAdmin"]);
                    isActive = Convert.ToInt32(reader["isActive"]);

                    login = new Login(id, username, password, typeAccount, createdByAdmin, isActive);
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return login;
        } 
    }
}
