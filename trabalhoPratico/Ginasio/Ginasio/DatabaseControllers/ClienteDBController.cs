using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Ginasio.Classes;

namespace Ginasio.DatabaseControllers {
    internal class ClienteDBController : BaseDBController {
        public int inserir(Cliente cliente) {
            int id;

            try {
                connection = DBConn();

                sql = "INSERT INTO cliente(primNome, ultNome, dataNascimento, nif, genero, telefone, email, morada, isActive, foto, subscricao, inicioSubscricao, fimSubscricao) VALUES(@primNome, @ultNome, @dataNascimento, @nif, @genero, @telefone, @email, @morada, @isActive, @foto, @subscricao, @inicioSubscricao, @fimSubscricao)";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@primNome", cliente.primNome);
                command.Parameters.AddWithValue("@ultNome", cliente.ultNome);
                command.Parameters.AddWithValue("@dataNascimento", convertDateTimeToDateDb(cliente.dataNascimento));
                command.Parameters.AddWithValue("@nif", cliente.nif);
                command.Parameters.AddWithValue("@genero", cliente.genero);
                command.Parameters.AddWithValue("@telefone", cliente.telefone);
                command.Parameters.AddWithValue("@email", cliente.email);
                command.Parameters.AddWithValue("@morada", cliente.morada);
                command.Parameters.AddWithValue("@isActive", cliente.isActive);
                command.Parameters.AddWithValue("@foto", cliente.foto);
                command.Parameters.AddWithValue("@subscricao", cliente.idSubscricao);
                command.Parameters.AddWithValue("@inicioSubscricao", convertDateTimeToDateDb(cliente.inicioSubscricao));
                command.Parameters.AddWithValue("@fimSubscricao", convertDateTimeToDateDb(cliente.fimSubscricao));

                connection.Open();

                if (command.ExecuteNonQuery() == 1) {
                    command = null;

                    sql = "SELECT LAST_INSERT_ID() as `id` FROM `cliente` LIMIT 1";

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

        public bool subscreverAula(int idCliente, int idAula) {
            bool status;

            try {
                connection = DBConn();

                sql = "INSERT INTO aulasCliente(idAula, idCliente) VALUES(@idAula, @idCliente)";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idAula", idAula);
                command.Parameters.AddWithValue("@idCliente", idCliente);

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

        public bool unsubscreverAula(int idCliente, int idAula) {
            bool status;

            try {
                connection = DBConn();

                sql = "DELETE FROM aulasCliente WHERE idAula = @idAula and idCliente = @idCliente";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idAula", idAula);
                command.Parameters.AddWithValue("@idCliente", idCliente);

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

        public bool alterar(Cliente cliente) {
            bool status;

            try {
                connection = DBConn();

                sql = "UPDATE cliente SET primNome = @primNome, ultNome = @ultNome, dataNascimento = @dataNascimento, nif = @nif, genero = @genero, telefone = @telefone, email = @email, morada = @morada, isActive = @isActive, foto = @foto, subscricao = @subscricao, inicioSubscricao = @inicioSubscricao, fimSubscricao = @fimSubscricao WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@primNome", cliente.primNome);
                command.Parameters.AddWithValue("@ultNome", cliente.ultNome);
                command.Parameters.AddWithValue("@dataNascimento", convertDateTimeToDateDb(cliente.dataNascimento));
                command.Parameters.AddWithValue("@nif", cliente.nif);
                command.Parameters.AddWithValue("@genero", cliente.genero);
                command.Parameters.AddWithValue("@telefone", cliente.telefone);
                command.Parameters.AddWithValue("@email", cliente.email);
                command.Parameters.AddWithValue("@morada", cliente.morada);
                command.Parameters.AddWithValue("@isActive", cliente.isActive);
                command.Parameters.AddWithValue("@foto", cliente.foto);
                command.Parameters.AddWithValue("@subscricao", cliente.idSubscricao);
                command.Parameters.AddWithValue("@inicioSubscricao", convertDateTimeToDateDb(cliente.inicioSubscricao));
                command.Parameters.AddWithValue("@fimSubscricao", convertDateTimeToDateDb(cliente.fimSubscricao));
                command.Parameters.AddWithValue("@id", cliente.id);

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

        public Cliente getById(int idCliente) {
            Cliente cliente = null;

            try {
                connection = DBConn();

                sql = "SELECT * FROM cliente WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idCliente);

                connection.Open();

                reader = command.ExecuteReader();

                if (reader != null && reader.HasRows && reader.Read()) {
                    int id, nif, telefone, isActive, subscricao;
                    string primNome, ultNome, genero, email, morada, foto;
                    DateTime dataNascimento, inicioSubscricao, fimSubscricao;

                    id = Convert.ToInt32(reader["id"]);
                    primNome = Convert.ToString(reader["primNome"]);
                    ultNome = Convert.ToString(reader["ultNome"]);
                    dataNascimento = converteDataDBToDateTime(Convert.ToString(reader["dataNascimento"]));
                    nif = Convert.ToInt32(reader["nif"]);
                    genero = Convert.ToString(reader["genero"]);
                    telefone = Convert.ToInt32(reader["telefone"]);
                    email = Convert.ToString(reader["email"]);
                    morada = Convert.ToString(reader["morada"]);
                    isActive = Convert.ToInt32(reader["isActive"]);
                    foto = Convert.ToString(reader["foto"]);
                    subscricao = Convert.ToInt32(reader["subscricao"]);
                    inicioSubscricao = converteDataDBToDateTime(Convert.ToString(reader["inicioSubscricao"]));
                    fimSubscricao = converteDataDBToDateTime(Convert.ToString(reader["fimSubscricao"]));

                    cliente = new Cliente(id, primNome, ultNome, dataNascimento, nif, genero, telefone, email, morada, isActive, foto, subscricao, inicioSubscricao, fimSubscricao);
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return cliente;
        }

        public Cliente[] getAll() {
            Cliente[] clientes = null;
            int nRows = getNumRegistosDB("cliente"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT * FROM cliente";

                command = new MySqlCommand(sql, connection);

                connection.Open();

                reader = command.ExecuteReader();

                clientes = new Cliente[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id, nif, telefone, isActive, subscricao;
                        string primNome, ultNome, genero, email, morada, foto;
                        DateTime dataNascimento, inicioSubscricao, fimSubscricao;

                        id = Convert.ToInt32(reader["id"]);
                        primNome = Convert.ToString(reader["primNome"]);
                        ultNome = Convert.ToString(reader["ultNome"]);
                        dataNascimento = converteDataDBToDateTime(Convert.ToString(reader["dataNascimento"]));
                        nif = Convert.ToInt32(reader["nif"]);
                        genero = Convert.ToString(reader["genero"]);
                        telefone = Convert.ToInt32(reader["telefone"]);
                        email = Convert.ToString(reader["email"]);
                        morada = Convert.ToString(reader["morada"]);
                        isActive = Convert.ToInt32(reader["isActive"]);
                        foto = Convert.ToString(reader["foto"]);
                        subscricao = Convert.ToInt32(reader["subscricao"]);
                        inicioSubscricao = converteDataDBToDateTime(Convert.ToString(reader["inicioSubscricao"]));
                        fimSubscricao = converteDataDBToDateTime(Convert.ToString(reader["fimSubscricao"]));

                        clientes[i] = new Cliente(id, primNome, ultNome, dataNascimento, nif, genero, telefone, email, morada, isActive, foto, subscricao, inicioSubscricao, fimSubscricao);
                        i++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return clientes;
        }

        public Cliente[] getClientesSubscricao(int idSubscricao) {
            Cliente[] clientes = null;
            int nRows = getNumRegistosDB("cliente"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT * FROM cliente WHERE subscricao = @subscricao";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@subscricao", idSubscricao);

                connection.Open();

                reader = command.ExecuteReader();

                clientes = new Cliente[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id, nif, telefone, isActive, subscricao;
                        string primNome, ultNome, genero, email, morada, foto;
                        DateTime dataNascimento, inicioSubscricao, fimSubscricao;

                        id = Convert.ToInt32(reader["id"]);
                        primNome = Convert.ToString(reader["primNome"]);
                        ultNome = Convert.ToString(reader["ultNome"]);
                        dataNascimento = converteDataDBToDateTime(Convert.ToString(reader["dataNascimento"]));
                        nif = Convert.ToInt32(reader["nif"]);
                        genero = Convert.ToString(reader["genero"]);
                        telefone = Convert.ToInt32(reader["telefone"]);
                        email = Convert.ToString(reader["email"]);
                        morada = Convert.ToString(reader["morada"]);
                        isActive = Convert.ToInt32(reader["isActive"]);
                        foto = Convert.ToString(reader["foto"]);
                        subscricao = Convert.ToInt32(reader["subscricao"]);
                        inicioSubscricao = converteDataDBToDateTime(Convert.ToString(reader["inicioSubscricao"]));
                        fimSubscricao = converteDataDBToDateTime(Convert.ToString(reader["fimSubscricao"]));

                        clientes[i] = new Cliente(id, primNome, ultNome, dataNascimento, nif, genero, telefone, email, morada, isActive, foto, subscricao, inicioSubscricao, fimSubscricao);
                        i++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return clientes;
        }
    }
}
