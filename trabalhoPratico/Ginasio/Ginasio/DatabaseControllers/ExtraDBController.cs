using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Ginasio.Classes;

namespace Ginasio.DatabaseControllers {
    internal class ExtraDBController : BaseDBController {
        public int inserir(Extra extra) {
            int id;

            try {
                connection = DBConn();

                sql = "INSERT INTO extra(nome, preco) VALUES(@nome, @preco)";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@nome", extra.nome);
                command.Parameters.AddWithValue("@preco", extra.preco);

                connection.Open();

                if (command.ExecuteNonQuery() == 1) {
                    command = null;

                    sql = "SELECT LAST_INSERT_ID() as `id` FROM `extra` LIMIT 1";

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

        public bool alterar(Extra extra) {
            bool status;

            try {
                connection = DBConn();

                sql = "UPDATE extra SET nome = @nome, preco = @preco WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@nome", extra.nome);
                command.Parameters.AddWithValue("@preco", extra.preco);
                command.Parameters.AddWithValue("@id", extra.id);

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

        public bool remover(int idExtra) {
            bool status;

            try {
                connection = DBConn();

                sql = "DELETE FROM extra WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idExtra);

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

        public Extra getById(int idExtra) {
            Extra extra = null;

            try {
                connection = DBConn();

                sql = "SELECT * FROM extra WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idExtra);

                connection.Open();

                reader = command.ExecuteReader();

                if (reader != null && reader.HasRows && reader.Read()) {
                    int id;
                    string nome;
                    float preco;

                    id = Convert.ToInt32(reader["id"]);
                    nome = Convert.ToString(reader["nome"]);
                    preco = float.Parse(reader["preco"].ToString());

                    extra = new Extra(id, nome, preco);
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return extra;
        }

        public Extra[] getAll() {
            Extra[] extras = null;
            int nRows = getNumRegistosDB("extra"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT * FROM extra";

                command = new MySqlCommand(sql, connection);

                connection.Open();

                reader = command.ExecuteReader();

                extras = new Extra[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id;
                        string nome;
                        float preco;

                        id = Convert.ToInt32(reader["id"]);
                        nome = Convert.ToString(reader["nome"]);
                        preco = float.Parse(reader["preco"].ToString());

                        extras[i] = new Extra(id, nome, preco);
                        i++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return extras;
        }
    }
}
