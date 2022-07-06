using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Ginasio.Classes;

namespace Ginasio.DatabaseControllers {
    internal class SubscricaoDBController : BaseDBController {
        public int inserir(Subscricao subscricao) {
            int id;

            try {
                connection = DBConn();

                sql = "INSERT INTO subscricao(nome, preco, isActive) VALUES(@nome, @preco, @isActive)";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@nome", subscricao.nome);
                command.Parameters.AddWithValue("@preco", subscricao.preco);
                command.Parameters.AddWithValue("@isActive", subscricao.isActive);

                connection.Open();

                if (command.ExecuteNonQuery() == 1) {
                    command = null;

                    sql = "SELECT LAST_INSERT_ID() as `id` FROM `subscricao` LIMIT 1";

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

        public bool alterar(Subscricao subscricao) {
            bool status;

            try {
                connection = DBConn();

                sql = "UPDATE subscricao SET nome = @nome, preco = @preco, isActive = @isActive WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@nome", subscricao.nome);
                command.Parameters.AddWithValue("@preco", subscricao.preco);
                command.Parameters.AddWithValue("@isActive", subscricao.isActive);
                command.Parameters.AddWithValue("@id", subscricao.id);

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

                sql = "DELETE FROM subscricao WHERE id = @id";

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

        public Subscricao getById(int idSubscricao) {
            Subscricao subscricao = null;

            try {
                connection = DBConn();

                sql = "SELECT * FROM subscricao WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idSubscricao);

                connection.Open();

                reader = command.ExecuteReader();

                if (reader != null && reader.HasRows && reader.Read()) {
                    int id, isActive;
                    string nome;
                    float preco;

                    id = Convert.ToInt32(reader["id"]);
                    nome = Convert.ToString(reader["nome"]);
                    preco = float.Parse(reader["preco"].ToString());
                    isActive = Convert.ToInt32(reader["isActive"]);

                    subscricao = new Subscricao(id, nome, preco, isActive);
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return subscricao;
        }

        public Subscricao[] getAll() {
            Subscricao[] subscricoes = null;
            int nRows = getNumRegistosDB("subscricao"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT * FROM subscricao";

                command = new MySqlCommand(sql, connection);

                connection.Open();
                
                reader = command.ExecuteReader();

                subscricoes = new Subscricao[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id, isActive;
                        string nome;
                        float preco;

                        id = Convert.ToInt32(reader["id"]);
                        nome = Convert.ToString(reader["nome"]);
                        preco = float.Parse(reader["preco"].ToString());
                        isActive = Convert.ToInt32(reader["isActive"]);

                        subscricoes[i] = new Subscricao(id, nome, preco, isActive);
                        i++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return subscricoes;
        }
    }
}
