using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Ginasio.Classes;

namespace Ginasio.DatabaseControllers {
    internal class TipoReclamacaoDBController : BaseDBController {
        public int inserir(TipoReclamacao tipoReclamacao) {
            int id;

            try {
                connection = DBConn();

                sql = "INSERT INTO tipoReclamacao(nome, nomeSistema) VALUES(@nome, @nomeSistema)";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@nome", tipoReclamacao.nome);
                command.Parameters.AddWithValue("@nomeSistema", tipoReclamacao.nomeSistema);

                connection.Open();

                if (command.ExecuteNonQuery() == 1) {
                    command = null;

                    sql = "SELECT LAST_INSERT_ID() as `id` FROM `tipoReclamacao` LIMIT 1";

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

                sql = "DELETE FROM tipoReclamacao WHERE id = @id";

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

        public TipoReclamacao getById(int tipoReclamacaoID) {
            TipoReclamacao tipoReclamacao = null;

            try {
                connection = DBConn();

                sql = "SELECT * FROM tipoReclamacao WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", tipoReclamacaoID);

                connection.Open();

                reader = command.ExecuteReader();

                if (reader != null && reader.HasRows && reader.Read()) {
                    int id;
                    string nome, nomeSistema;

                    id = Convert.ToInt32(reader["id"]);
                    nome = Convert.ToString(reader["nome"]);
                    nomeSistema = Convert.ToString(reader["nomeSistema"]);

                    tipoReclamacao = new TipoReclamacao(id, nome, nomeSistema);
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return tipoReclamacao;
        }

        public TipoReclamacao[] getAll() {
            TipoReclamacao[] tiposReclamacao = null;
            int nRows = getNumRegistosDB("tipoReclamacao"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT * FROM tipoReclamacao";

                command = new MySqlCommand(sql, connection);

                connection.Open();

                reader = command.ExecuteReader();

                tiposReclamacao = new TipoReclamacao[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id;
                        string nome, nomeSistema;

                        id = Convert.ToInt32(reader["id"]);
                        nome = Convert.ToString(reader["nome"]);
                        nomeSistema = Convert.ToString(reader["nomeSistema"]);

                        tiposReclamacao[i] = new TipoReclamacao(id, nome, nomeSistema);
                        i++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return tiposReclamacao;
        }

        public TipoReclamacao[] searchByNomeSistema(string nomeSistem) {
            TipoReclamacao[] tiposReclamacao = null;
            int nRows = getNumRegistosDB("tipoReclamacao"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT * FROM tipoReclamacao WHERE nomeSistema LIKE @nomeSistema";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@nomeSistema", nomeSistem + "%");

                connection.Open();

                reader = command.ExecuteReader();

                tiposReclamacao = new TipoReclamacao[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id;
                        string nome, nomeSistema;

                        id = Convert.ToInt32(reader["id"]);
                        nome = Convert.ToString(reader["nome"]);
                        nomeSistema = Convert.ToString(reader["nomeSistema"]);

                        tiposReclamacao[i] = new TipoReclamacao(id, nome, nomeSistema);
                        i++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return tiposReclamacao;
        }
    }
}
