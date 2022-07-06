using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Ginasio.Classes;

namespace Ginasio.DatabaseControllers {
    internal class EquipamentoDBController : BaseDBController {
        public int inserir(Equipamento equipamento) {
            int id;

            try {
                connection = DBConn();

                sql = "INSERT INTO equipamento(nome, quantidade, idTipoEquipamento, idFuncionario) VALUES(@nome, @quantidade, @idTipoEquipamento, @idFuncionario)";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@nome", equipamento.nome);
                command.Parameters.AddWithValue("@quantidade", equipamento.quantidade);
                command.Parameters.AddWithValue("@idTipoEquipamento", equipamento.idTipoEquipamento);
                command.Parameters.AddWithValue("@idFuncionario", equipamento.idFuncionario);

                connection.Open();

                if (command.ExecuteNonQuery() == 1) {
                    command = null;

                    sql = "SELECT LAST_INSERT_ID() as `id` FROM `equipamento` LIMIT 1";

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

        public bool alterar(Equipamento equipamento) {
            bool status;

            try {
                connection = DBConn();

                sql = "UPDATE equipamento SET nome = @nome, quantidade = @quantidade, idTipoEquipamento = @idTipoEquipamento, idFuncionario = @idFuncionario WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@nome", equipamento.nome);
                command.Parameters.AddWithValue("@quantidade", equipamento.quantidade);
                command.Parameters.AddWithValue("@idTipoEquipamento", equipamento.idTipoEquipamento);
                command.Parameters.AddWithValue("@idFuncionario", equipamento.idFuncionario);
                command.Parameters.AddWithValue("@id", equipamento.id);

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

        public bool remover(int idEquipamento) {
            bool status;

            try {
                connection = DBConn();

                sql = "DELETE FROM equipamento WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idEquipamento);

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

        public Equipamento getById(int idEquipamento) {
            Equipamento equipamento = null;

            try {
                connection = DBConn();

                sql = "SELECT * FROM equipamento WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idEquipamento);

                connection.Open();

                reader = command.ExecuteReader();

                if (reader != null && reader.HasRows && reader.Read()) {
                    int id, quantidade, idTipoEquipamento, idFuncionario;
                    string nome;

                    id = Convert.ToInt32(reader["id"]);
                    nome = Convert.ToString(reader["nome"]);
                    quantidade = Convert.ToInt32(reader["quantidade"]);
                    idTipoEquipamento = Convert.ToInt32(reader["idTipoEquipamento"]);
                    idFuncionario = Convert.ToInt32(reader["idFuncionario"]);

                    equipamento = new Equipamento(id, nome, quantidade, idTipoEquipamento, idFuncionario);
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return equipamento;
        }

        public Equipamento[] getAll() {
            Equipamento[] equipamentos = null;
            int nRows = getNumRegistosDB("equipamento"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT * FROM equipamento";

                command = new MySqlCommand(sql, connection);

                connection.Open();

                reader = command.ExecuteReader();

                equipamentos = new Equipamento[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id, quantidade, idTipoEquipamento, idFuncionario;
                        string nome;

                        id = Convert.ToInt32(reader["id"]);
                        nome = Convert.ToString(reader["nome"]);
                        quantidade = Convert.ToInt32(reader["quantidade"]);
                        idTipoEquipamento = Convert.ToInt32(reader["idTipoEquipamento"]);
                        idFuncionario = Convert.ToInt32(reader["idFuncionario"]);

                        equipamentos[i] = new Equipamento(id, nome, quantidade, idTipoEquipamento, idFuncionario);
                        id++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return equipamentos;
        }

        public Equipamento[] getByTipoEquipamento(int tipoEquipamento) {
            Equipamento[] equipamentos = null;
            int nRows = getNumRegistosDB("equipamento"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT * FROM equipamento WHERE idTipoEquipamento = @idTipoEquipamento";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idtipoEquipamento", tipoEquipamento);

                connection.Open();

                reader = command.ExecuteReader();

                equipamentos = new Equipamento[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id, quantidade, idTipoEquipamento, idFuncionario;
                        string nome;

                        id = Convert.ToInt32(reader["id"]);
                        nome = Convert.ToString(reader["nome"]);
                        quantidade = Convert.ToInt32(reader["quantidade"]);
                        idTipoEquipamento = Convert.ToInt32(reader["idTipoEquipamento"]);
                        idFuncionario = Convert.ToInt32(reader["idFuncionario"]);

                        equipamentos[i] = new Equipamento(id, nome, quantidade, idTipoEquipamento, idFuncionario);
                        id++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return equipamentos;
        }

        public Equipamento[] getByFuncionario(int funcionarioID) {
            Equipamento[] equipamentos = null;
            int nRows = getNumRegistosDB("equipamento"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT * FROM equipamento WHERE idFuncionario = @idFuncionario";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idFuncionario", funcionarioID);

                connection.Open();

                reader = command.ExecuteReader();

                equipamentos = new Equipamento[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id, quantidade, idTipoEquipamento, idFuncionario;
                        string nome;

                        id = Convert.ToInt32(reader["id"]);
                        nome = Convert.ToString(reader["nome"]);
                        quantidade = Convert.ToInt32(reader["quantidade"]);
                        idTipoEquipamento = Convert.ToInt32(reader["idTipoEquipamento"]);
                        idFuncionario = Convert.ToInt32(reader["idFuncionario"]);

                        equipamentos[i] = new Equipamento(id, nome, quantidade, idTipoEquipamento, idFuncionario);
                        id++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return equipamentos;
        }
    }
}
