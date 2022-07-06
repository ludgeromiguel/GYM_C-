using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Ginasio.Classes;

namespace Ginasio.DatabaseControllers {
    internal class ModalidadeDBController : BaseDBController {
        public int inserir(Modalidade modalidade) {
            int id;

            try {
                connection = DBConn();

                sql = "INSERT INTO modalidade(nome, nomeSistema) VALUES(@nome, @nomeSistema)";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@nome", modalidade.nome);
                command.Parameters.AddWithValue("@nomeSistema", modalidade.nomeSistema);

                connection.Open();

                if (command.ExecuteNonQuery() == 1) {
                    command = null;

                    sql = "SELECT LAST_INSERT_ID() as `id` FROM `modalidade` LIMIT 1";

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

        public bool remover(int idModalidade) {
            bool status;

            try {
                connection = DBConn();

                sql = "DELETE FROM modalidade WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idModalidade);

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

        public Modalidade getById(int idModalidade) {
            Modalidade modalidade = null;

            try {
                connection = DBConn();

                sql = "SELECT * FROM modalidade WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idModalidade);

                connection.Open();

                reader = command.ExecuteReader();

                if (reader != null && reader.HasRows && reader.Read()) {
                    int id;
                    string nome, nomeSistema;

                    id = Convert.ToInt32(reader["id"]);
                    nome = Convert.ToString(reader["nome"]);
                    nomeSistema = Convert.ToString(reader["nomeSistema"]);

                    modalidade = new Modalidade(id, nome, nomeSistema);
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return modalidade;
        }

        public Modalidade[] getAll() {
            Modalidade[] modalidades = null;
            int nRows = getNumRegistosDB("modalidade"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT * FROM modalidade";

                command = new MySqlCommand(sql, connection);

                connection.Open();

                reader = command.ExecuteReader();

                modalidades = new Modalidade[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id;
                        string nome, nomeSistema;

                        id = Convert.ToInt32(reader["id"]);
                        nome = Convert.ToString(reader["nome"]);
                        nomeSistema = Convert.ToString(reader["nomeSistema"]);

                        modalidades[i] = new Modalidade(id, nome, nomeSistema);
                        i++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return modalidades;
        }

        public Modalidade[] searchByNomeSistema(string nomeSistem) {
            Modalidade[] modalidades = null;
            int nRows = getNumRegistosDB("modalidade"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT * FROM modalidade WHERE nomeSistema LIKE @nomeSistema";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@nomeSistema", nomeSistem+"%");

                connection.Open();

                reader = command.ExecuteReader();

                modalidades = new Modalidade[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id;
                        string nome, nomeSistema;

                        id = Convert.ToInt32(reader["id"]);
                        nome = Convert.ToString(reader["nome"]);
                        nomeSistema = Convert.ToString(reader["nomeSistema"]);

                        modalidades[i] = new Modalidade(id, nome, nomeSistema);
                        i++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return modalidades;
        }
    }
}
