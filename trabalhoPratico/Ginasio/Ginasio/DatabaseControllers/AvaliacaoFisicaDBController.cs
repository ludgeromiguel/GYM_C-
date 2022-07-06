using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Ginasio.Classes;

namespace Ginasio.DatabaseControllers {
    internal class AvaliacaoFisicaDBController : BaseDBController {
        public int insere(AvaliacaoFisica avaliacaoFisica) {
            int id;

            try {
                connection = DBConn();

                sql = "INSERT INTO avaliacaoFisica(idCliente, peso, tamanho, gordura, massaMuscular, data) VALUES(@idCliente, @peso, @tamanho, @gordura, @massaMuscular, @data)";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idCliente", avaliacaoFisica.idCliente);
                command.Parameters.AddWithValue("@peso", avaliacaoFisica.peso);
                command.Parameters.AddWithValue("@tamanho", avaliacaoFisica.tamanho);
                command.Parameters.AddWithValue("@gordura", avaliacaoFisica.gordura);
                command.Parameters.AddWithValue("@massaMuscular", avaliacaoFisica.massaMuscular);
                command.Parameters.AddWithValue("@data", convertDateTimeToDateDb(avaliacaoFisica.data));

                connection.Open();

                if (command.ExecuteNonQuery() == 1) {
                    command = null;

                    sql = "SELECT LAST_INSERT_ID() as `id` FROM `avaliacaoFisica` LIMIT 1";

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

        public bool alterar(AvaliacaoFisica avaliacaoFisica) {
            bool status;

            try {
                connection = DBConn();

                sql = "UPDATE avaliacaoFisica SET peso = @peso, tamanho = @tamanho, gordura = @gordura, massaMuscula = @massaMuscular, data = @data WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@peso", avaliacaoFisica.peso);
                command.Parameters.AddWithValue("@tamanho", avaliacaoFisica.tamanho);
                command.Parameters.AddWithValue("@gordura", avaliacaoFisica.gordura);
                command.Parameters.AddWithValue("@massaMuscular", avaliacaoFisica.massaMuscular);
                command.Parameters.AddWithValue("@data", convertDateTimeToDateDb(avaliacaoFisica.data));
                command.Parameters.AddWithValue("@id", avaliacaoFisica.id);

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

        public bool remover(int id) {
            bool status;

            try {
                connection = DBConn();

                sql = "DELETE FROM avaliacaoFisica WHERE id = @id";

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

        public AvaliacaoFisica getById(int idAvaliacaoFisica) {
            AvaliacaoFisica avaliacaoFisica = null;

            try {
                connection = DBConn();

                sql = "SELECT * FROM avaliacaoFisica WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idAvaliacaoFisica);

                connection.Open();

                reader = command.ExecuteReader();

                if (reader != null && reader.HasRows && reader.Read()) {
                    int id, idCliente, tamanho;
                    float peso, gordura, massaMuscular;
                    DateTime data;

                    id = Convert.ToInt32(reader["id"]);
                    idCliente = Convert.ToInt32(reader["idCliente"]);
                    peso = float.Parse(reader["peso"].ToString());
                    tamanho = Convert.ToInt32(reader["tamanho"]);
                    gordura = float.Parse(reader["gordura"].ToString());
                    massaMuscular = float.Parse(reader["massaMuscular"].ToString());
                    data = converteDataDBToDateTime(Convert.ToString(reader["data"]));

                    avaliacaoFisica = new AvaliacaoFisica(id, idCliente, peso, tamanho, gordura, massaMuscular, data);
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return avaliacaoFisica;
        }

        public AvaliacaoFisica[] getAll() {
            AvaliacaoFisica[] avaliacoesFisicas = null;
            int nRows = getNumRegistosDB("avaliacaoFisica"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT * FROM avaliacaoFisica";

                command = new MySqlCommand(sql, connection);

                connection.Open();

                reader = command.ExecuteReader();

                avaliacoesFisicas = new AvaliacaoFisica[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id, idCliente, tamanho;
                        float peso, gordura, massaMuscular;
                        DateTime data;

                        id = Convert.ToInt32(reader["id"]);
                        idCliente = Convert.ToInt32(reader["idCliente"]);
                        peso = float.Parse(reader["peso"].ToString());
                        tamanho = Convert.ToInt32(reader["tamanho"]);
                        gordura = float.Parse(reader["gordura"].ToString());
                        massaMuscular = float.Parse(reader["massaMuscular"].ToString());
                        data = converteDataDBToDateTime(Convert.ToString(reader["data"]));

                        avaliacoesFisicas[i] = new AvaliacaoFisica(id, idCliente, peso, tamanho, gordura, massaMuscular, data);
                        i++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return avaliacoesFisicas;
        }

        public AvaliacaoFisica[] getAvaliacoesCliente(int clientID) {
            AvaliacaoFisica[] avaliacoesFisicas = null;
            int nRows = getNumRegistosDB("avaliacaoFisica"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT * FROM avaliacaoFisica WHERE idCliente = @idCliente";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idCliente", clientID);

                connection.Open();

                reader = command.ExecuteReader();

                avaliacoesFisicas = new AvaliacaoFisica[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id, idCliente, tamanho;
                        float peso, gordura, massaMuscular;
                        DateTime data;

                        id = Convert.ToInt32(reader["id"]);
                        idCliente = Convert.ToInt32(reader["idCliente"]);
                        peso = float.Parse(reader["peso"].ToString());
                        tamanho = Convert.ToInt32(reader["tamanho"]);
                        gordura = float.Parse(reader["gordura"].ToString());
                        massaMuscular = float.Parse(reader["massaMuscular"].ToString());
                        data = converteDataDBToDateTime(Convert.ToString(reader["data"]));

                        avaliacoesFisicas[i] = new AvaliacaoFisica(id, idCliente, peso, tamanho, gordura, massaMuscular, data);
                        i++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return avaliacoesFisicas;
        }
    }
}
