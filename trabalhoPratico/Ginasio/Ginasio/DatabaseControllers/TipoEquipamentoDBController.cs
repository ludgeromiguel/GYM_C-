using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Ginasio.Classes;

namespace Ginasio.DatabaseControllers {
    internal class TipoEquipamentoDBController : BaseDBController {
        public int inserir(TipoEquipamento tipoEquipamento) {
            int id;

            try {
                connection = DBConn();

                sql = "INSERT INTO tipoEquipamento(nome, nomeSistema) VALUES(@nome, @nomeSistema)";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@nome", tipoEquipamento.nome);
                command.Parameters.AddWithValue("@nomeSistema", tipoEquipamento.nomeSistema);

                connection.Open();

                if (command.ExecuteNonQuery() == 1) {
                    command = null;

                    sql = "SELECT LAST_INSERT_ID() as `id` FROM `tipoEquipamento` LIMIT 1";

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

        public bool remover(int id) {
            bool status;

            try {
                connection = DBConn();

                sql = "DELETE FROM tipoEquipamento WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);

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

        public TipoEquipamento getById(int tipoEquipamentoId) {
            TipoEquipamento tipoEquipamento = null;

            try {
                connection = DBConn();

                sql = "SELECT * FROM tipoEquipamento WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", tipoEquipamentoId);

                connection.Open();

                reader = command.ExecuteReader();

                if (reader != null && reader.HasRows && reader.Read()) {
                    int id;
                    string nome, nomeSistema;

                    id = Convert.ToInt32(reader["id"]);
                    nome = Convert.ToString(reader["nome"]);
                    nomeSistema = Convert.ToString(reader["nomeSistema"]);

                    tipoEquipamento = new TipoEquipamento(id, nome, nomeSistema);
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return tipoEquipamento;
        }

        public TipoEquipamento[] getAll() {
            TipoEquipamento[] tiposEquipamento = null;
            int nRows = getNumRegistosDB("tipoEquipamento"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT * FROM tipoEquipamento";

                command = new MySqlCommand(sql, connection);

                connection.Open();

                reader = command.ExecuteReader();

                tiposEquipamento = new TipoEquipamento[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id;
                        string nome, nomeSistema;

                        id = Convert.ToInt32(reader["id"]);
                        nome = Convert.ToString(reader["nome"]);
                        nomeSistema = Convert.ToString(reader["nomeSistema"]);

                        tiposEquipamento[i] = new TipoEquipamento(id, nome, nomeSistema);
                        i++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return tiposEquipamento;
        }

        public TipoEquipamento[] searchByNomeSistema(string nomeSistem) {
            TipoEquipamento[] tiposEquipamento = null;
            int nRows = getNumRegistosDB("tipoEquipamento"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT * FROM tipoEquipamento WHERE nomeSistema LIKE @nomeSistema";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@nomeSistema", nomeSistem + "%");

                connection.Open();

                reader = command.ExecuteReader();

                tiposEquipamento = new TipoEquipamento[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id;
                        string nome, nomeSistema;

                        id = Convert.ToInt32(reader["id"]);
                        nome = Convert.ToString(reader["nome"]);
                        nomeSistema = Convert.ToString(reader["nomeSistema"]);

                        tiposEquipamento[i] = new TipoEquipamento(id, nome, nomeSistema);
                        i++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return tiposEquipamento;
        }
    }
}
