using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Ginasio.Classes;

namespace Ginasio.DatabaseControllers {
    internal class ExtrasClienteDBController : BaseDBController {
        public bool inserir(ExtrasCliente extrasCliente) {
            bool status;

            try {
                connection = DBConn();

                sql = "INSERT INTO extrasCliente(idCliente, idExtra, quantidade) VALUES(@idCliente, @idExtra, @quantidade)";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idCliente", extrasCliente.idCliente);
                command.Parameters.AddWithValue("@idExtra", extrasCliente.idExtra);
                command.Parameters.AddWithValue("@quantidade", extrasCliente.quantidade);

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

        public bool alterar(ExtrasCliente extrasCliente) {
            bool status;

            try {
                connection = DBConn();

                sql = "UPDATE extrasCliente SET quantidade = @quantidade WHERE idCliente = @idCliente and idExtra = @idExtra";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@quantidade", extrasCliente.quantidade);
                command.Parameters.AddWithValue("@idCliente", extrasCliente.idCliente);
                command.Parameters.AddWithValue("@idExtra", extrasCliente.idExtra);

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

        public bool remover(int idCliente, int idExtra) {
            bool status;

            try {
                connection = DBConn();

                sql = "DELETE FROM extrasCliente WHERE idCliente = @idCliente and idExtra = @idExtra";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idCliente", idCliente);
                command.Parameters.AddWithValue("@idExtra", idExtra);

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

        public ExtrasCliente getByIds(int clienteID, int extraID) {
            ExtrasCliente extrasCliente = null;

            try {
                connection = DBConn();

                sql = "SELECT * FROM extrasCliente WHERE idCliente = @idCliente and idExtra = @idExtra";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idCliente", clienteID);
                command.Parameters.AddWithValue("@idExtra", extraID);

                connection.Open();

                reader = command.ExecuteReader();

                if (reader != null && reader.HasRows && reader.Read()) {
                    int idCliente, idExtra, quantidade;

                    idCliente = Convert.ToInt32(reader["idCliente"]);
                    idExtra = Convert.ToInt32(reader["idExtra"]);
                    quantidade = Convert.ToInt32(reader["quantidade"]);

                    extrasCliente = new ExtrasCliente(idCliente, idExtra, quantidade);
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return extrasCliente;
        }

        public ExtrasCliente[] getAll() {
            ExtrasCliente[] extrasClientes = null;
            int nRows = getNumRegistosDB("extrasCliente"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT * FROM extrasCliente";

                command = new MySqlCommand(sql, connection);

                connection.Open();

                reader = command.ExecuteReader();

                extrasClientes = new ExtrasCliente[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int idCliente, idExtra, quantidade;

                        idCliente = Convert.ToInt32(reader["idCliente"]);
                        idExtra = Convert.ToInt32(reader["idExtra"]);
                        quantidade = Convert.ToInt32(reader["quantidade"]);

                        extrasClientes[i] = new ExtrasCliente(idCliente, idExtra, quantidade);
                        i++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return extrasClientes;
        }

        public ExtrasCliente[] getExtrasClienteByClienteId(int clienteID) {
            ExtrasCliente[] extrasClientes = null;
            int nRows = getNumRegistosDB("extrasCliente"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT * FROM extrasCliente where idCliente = @idCliente";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idCliente", clienteID);

                connection.Open();

                reader = command.ExecuteReader();

                extrasClientes = new ExtrasCliente[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int idCliente, idExtra, quantidade;

                        idCliente = Convert.ToInt32(reader["idCliente"]);
                        idExtra = Convert.ToInt32(reader["idExtra"]);
                        quantidade = Convert.ToInt32(reader["quantidade"]);

                        extrasClientes[i] = new ExtrasCliente(idCliente, idExtra, quantidade);
                        i++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return extrasClientes;
        }

        public ExtrasCliente[] getExtrasClienteByExtraId(int extraId) {
            ExtrasCliente[] extrasClientes = null;
            int nRows = getNumRegistosDB("extrasCliente"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT * FROM extrasCliente where idExtra = @idExtra";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idExtra", extraId);

                connection.Open();

                reader = command.ExecuteReader();

                extrasClientes = new ExtrasCliente[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int idCliente, idExtra, quantidade;

                        idCliente = Convert.ToInt32(reader["idCliente"]);
                        idExtra = Convert.ToInt32(reader["idExtra"]);
                        quantidade = Convert.ToInt32(reader["quantidade"]);

                        extrasClientes[i] = new ExtrasCliente(idCliente, idExtra, quantidade);
                        i++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return extrasClientes;
        }
    }
}
