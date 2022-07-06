using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Ginasio.Classes;

namespace Ginasio.DatabaseControllers {
    internal class CargoDBController : BaseDBController {
        public int inserir(Cargo cargo) {
            int id;

            try {
                connection = DBConn();

                sql = "INSERT INTO cargo(nome, nomeSistema) VALUES(@nome, @nomeSistema)";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@nome", cargo.nome);
                command.Parameters.AddWithValue("@nomeSistema", cargo.nomeSistema);

                connection.Open();

                if (command.ExecuteNonQuery() == 1) {
                    command = null;

                    sql = "SELECT LAST_INSERT_ID() as `id` FROM `cargo` LIMIT 1";

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

        public bool remover(int idCargo) {
            bool status;

            try {
                connection = DBConn();

                sql = "DELETE FROM cargo WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idCargo);

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

        public Cargo getById(int idCargo) {
            Cargo cargo = null;

            try {
                connection = DBConn();

                sql = "SELECT * FROM cargo WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idCargo);

                connection.Open();

                reader = command.ExecuteReader();

                if (reader != null && reader.HasRows && reader.Read()) {
                    int id;
                    string nome, nomeSistema;

                    id = Convert.ToInt32(reader["id"]);
                    nome = Convert.ToString(reader["nome"]);
                    nomeSistema = Convert.ToString(reader["nomeSistema"]);

                    cargo = new Cargo(id, nome, nomeSistema);
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return cargo;
        }

        public Cargo[] getAll() {
            Cargo[] cargos = null;
            int nRows = getNumRegistosDB("cargo"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT * FROM cargo";

                command = new MySqlCommand(sql, connection);

                connection.Open();

                reader = command.ExecuteReader();

                cargos = new Cargo[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id;
                        string nome, nomeSistema;

                        id = Convert.ToInt32(reader["id"]);
                        nome = Convert.ToString(reader["nome"]);
                        nomeSistema = Convert.ToString(reader["nomeSistema"]);

                        cargos[i] = new Cargo(id, nome, nomeSistema);
                        i++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return cargos;
        }

        public Cargo[] searchByNomeSistema(string nomeSistem) {
            Cargo[] cargos = null;
            int nRows = getNumRegistosDB("cargo"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT * FROM cargo WHERE nomeSistema LIKE @nomeSistema";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@nomeSistema", nomeSistem+"%");

                connection.Open();

                reader = command.ExecuteReader();

                cargos = new Cargo[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id;
                        string nome, nomeSistema;

                        id = Convert.ToInt32(reader["id"]);
                        nome = Convert.ToString(reader["nome"]);
                        nomeSistema = Convert.ToString(reader["nomeSistema"]);


                        cargos[i] = new Cargo(id, nome, nomeSistema);
                        i++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return cargos;
        }
    }
}
