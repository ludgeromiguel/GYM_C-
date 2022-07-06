using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Ginasio.Classes;

namespace Ginasio.DatabaseControllers {
    internal class LivroReclamacoesDBController : BaseDBController {
        public int insere(LivroReclamacao livroReclamacao) {
            int id;

            try {
                connection = DBConn();

                sql = "INSERT INTO livroReclamacao(descricao, idCliente, idTipoReclamacao) VALUES(@descricao, @idCliente, @idTipoReclamacao)";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@descricao", livroReclamacao.descricao);
                command.Parameters.AddWithValue("@idCliente", livroReclamacao.idCliente);
                command.Parameters.AddWithValue("@idTipoReclamacao", livroReclamacao.idTipoReclamacao);

                connection.Open();

                if (command.ExecuteNonQuery() == 1) {
                    command = null;

                    sql = "SELECT LAST_INSERT_ID() as `id` FROM `livroReclamacao` LIMIT 1";

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

        public bool aterar(LivroReclamacao livroReclamacao) {
            bool status;

            try {
                connection = DBConn();

                sql = "UPDATE livroReclamacao SET descricao = @descricao, idTipoReclamcao = @idTipoReclamacao WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@descricao", livroReclamacao.descricao);
                command.Parameters.AddWithValue("@idTipoReclamacao", livroReclamacao.idTipoReclamacao);
                command.Parameters.AddWithValue("@id", livroReclamacao.id);

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

        public bool remover(int idReclamacao) {
            bool status;

            try {
                connection = DBConn();

                sql = "DELETE FROM livroReclamacao WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idReclamacao);

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

        public LivroReclamacao getById(int idReclamacao) {
            LivroReclamacao livroReclamacao = null;

            try {
                connection = DBConn();

                sql = "SELECT * FROM livroReclamacao WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idReclamacao);

                connection.Open();

                reader = command.ExecuteReader();

                if (reader != null && reader.HasRows && reader.Read()) {
                    int id, idCliente, idTipoReclamacao;
                    string descricao;

                    id = Convert.ToInt32(reader["id"]);
                    descricao = Convert.ToString(reader["descricao"]);
                    idCliente = Convert.ToInt32(reader["idCliente"]);
                    idTipoReclamacao = Convert.ToInt32(reader["idTipoReclamacao"]);

                    livroReclamacao = new LivroReclamacao(id, descricao, idCliente, idTipoReclamacao);
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return livroReclamacao;
        }

        public LivroReclamacao[] getAll() {
            LivroReclamacao[] livroReclamacoes = null;
            int nRows = getNumRegistosDB("livroReclamacao"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT * FROM livroReclamacao";

                command = new MySqlCommand(sql, connection);

                connection.Open();

                reader = command.ExecuteReader();

                livroReclamacoes = new LivroReclamacao[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id, idCliente, idTipoReclamacao;
                        string descricao;

                        id = Convert.ToInt32(reader["id"]);
                        descricao = Convert.ToString(reader["descricao"]);
                        idCliente = Convert.ToInt32(reader["idCliente"]);
                        idTipoReclamacao = Convert.ToInt32(reader["idTipoReclamacao"]);

                        livroReclamacoes[i] = new LivroReclamacao(id, descricao, idCliente, idTipoReclamacao);
                        i++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return livroReclamacoes;
        }

        public LivroReclamacao[] getReclamacoesCliente(int clienteID) {
            LivroReclamacao[] livroReclamacoes = null;
            int nRows = getNumRegistosDB("livroReclamacao"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT * FROM livroReclamacao WHERE idCliente = @idCliente";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idCliente", clienteID);

                connection.Open();

                reader = command.ExecuteReader();

                livroReclamacoes = new LivroReclamacao[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id, idCliente, idTipoReclamacao;
                        string descricao;

                        id = Convert.ToInt32(reader["id"]);
                        descricao = Convert.ToString(reader["descricao"]);
                        idCliente = Convert.ToInt32(reader["idCliente"]);
                        idTipoReclamacao = Convert.ToInt32(reader["idTipoReclamacao"]);

                        livroReclamacoes[i] = new LivroReclamacao(id, descricao, idCliente, idTipoReclamacao);
                        i++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return livroReclamacoes;
        }

        public LivroReclamacao[] getReclamacoesTipo(int tipoID) {
            LivroReclamacao[] livroReclamacoes = null;
            int nRows = getNumRegistosDB("livroReclamacao"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT * FROM livroReclamacao WHERE idTipoReclamacao = @idTipoReclamacao";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idTipoReclamacao", tipoID);

                connection.Open();

                reader = command.ExecuteReader();

                livroReclamacoes = new LivroReclamacao[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id, idCliente, idTipoReclamacao;
                        string descricao;

                        id = Convert.ToInt32(reader["id"]);
                        descricao = Convert.ToString(reader["descricao"]);
                        idCliente = Convert.ToInt32(reader["idCliente"]);
                        idTipoReclamacao = Convert.ToInt32(reader["idTipoReclamacao"]);

                        livroReclamacoes[i] = new LivroReclamacao(id, descricao, idCliente, idTipoReclamacao);
                        i++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return livroReclamacoes;
        }
    }
}
