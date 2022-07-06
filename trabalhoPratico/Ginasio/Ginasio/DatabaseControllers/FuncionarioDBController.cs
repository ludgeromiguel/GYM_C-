using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Ginasio.Classes;

namespace Ginasio.DatabaseControllers {
    internal class FuncionarioDBController : BaseDBController {
        public int inserir(Funcionario funcionario) {
            int id;

            try {
                connection = DBConn();

                sql = "INSERT INTO funcionario(primNome, ultNome, dataNascimento, nif, genero, telefone, email, morada, isActive, foto, salario, inicioContrato, fimContrato, turnoInicio, turnoFim, idTipoCargo) VALUES(@primNome, @ultNome, @dataNascimento, @nif, @genero, @telefone, @email, @morada, @isActive, @foto, @salario, @inicioContrato, @fimContrato, @turnoInicio, @turnoFim, @idTipoCargo)";
            
                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@primNome", funcionario.primNome);
                command.Parameters.AddWithValue("@ultNome", funcionario.ultNome);
                command.Parameters.AddWithValue("@dataNascimento", convertDateTimeToDateDb(funcionario.dataNascimento));
                command.Parameters.AddWithValue("@nif", funcionario.nif);
                command.Parameters.AddWithValue("@genero", funcionario.genero);
                command.Parameters.AddWithValue("@telefone", funcionario.telefone);
                command.Parameters.AddWithValue("@email", funcionario.email);
                command.Parameters.AddWithValue("@morada", funcionario.morada);
                command.Parameters.AddWithValue("@isActive", funcionario.isActive);
                command.Parameters.AddWithValue("@foto", funcionario.foto);
                command.Parameters.AddWithValue("@salario", funcionario.salario);
                command.Parameters.AddWithValue("@inicioContrato", convertDateTimeToDateDb(funcionario.inicioContrato));
                command.Parameters.AddWithValue("@fimContrato", convertDateTimeToDateDb(funcionario.fimContrato));
                command.Parameters.AddWithValue("@turnoInicio", funcionario.turnoInicio);
                command.Parameters.AddWithValue("@turnoFim", funcionario.turnoFim);
                command.Parameters.AddWithValue("@idTipoCargo", funcionario.idTipoCargo);

                connection.Open();

                if (command.ExecuteNonQuery() == 1) {
                    command = null;

                    sql = "SELECT LAST_INSERT_ID() as `id` FROM `funcionario` LIMIT 1";

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

        public bool alterar(Funcionario funcionario) {
            bool status;

            try {
                connection = DBConn();

                sql = "UPDATE funcionario SET primNome = @primNome, ultNome = @ultNome, dataNascimento = @dataNascimento, nif = @nif, genero = @genero, telefone = @telefone, email = @email, morada = @morada, isActive = @isActive, foto = @foto, salario = @salario, inicioContrato = @inicioContrato, fimContrato = @fimContrato, turnoInicio = @turnoInicio, turnoFim = @turnoFim, idTipoCargo = @idTipoCargo WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@primNome", funcionario.primNome);
                command.Parameters.AddWithValue("@ultNome", funcionario.ultNome);
                command.Parameters.AddWithValue("@dataNascimento", convertDateTimeToDateDb(funcionario.dataNascimento));
                command.Parameters.AddWithValue("@nif", funcionario.nif);
                command.Parameters.AddWithValue("@genero", funcionario.genero);
                command.Parameters.AddWithValue("@telefone", funcionario.telefone);
                command.Parameters.AddWithValue("@email", funcionario.email);
                command.Parameters.AddWithValue("@morada", funcionario.morada);
                command.Parameters.AddWithValue("@isActive", funcionario.isActive);
                command.Parameters.AddWithValue("@foto", funcionario.foto);
                command.Parameters.AddWithValue("@salario", funcionario.salario);
                command.Parameters.AddWithValue("@inicioContrato", convertDateTimeToDateDb(funcionario.inicioContrato));
                command.Parameters.AddWithValue("@fimContrato", convertDateTimeToDateDb(funcionario.fimContrato));
                command.Parameters.AddWithValue("@turnoInicio", funcionario.turnoInicio);
                command.Parameters.AddWithValue("@turnoFim", funcionario.turnoFim);
                command.Parameters.AddWithValue("@idTipoCargo", funcionario.idTipoCargo);
                command.Parameters.AddWithValue("@id", funcionario.id);

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

        public Funcionario getById(int idFuncionario) {
            Funcionario funcionario = null;

            try {
                connection = DBConn();

                sql = "SELECT * FROM funcionario WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idFuncionario);

                connection.Open();

                reader = command.ExecuteReader();

                if (reader != null && reader.HasRows && reader.Read()) {
                    int id, nif, telefone, isActive, idTipoCargo;
                    string primNome, ultNome, genero, email, morada, foto, turnoInicio, turnoFim;
                    float salario;
                    DateTime dataNascimento, inicioContrato, fimContrato;

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
                    salario = float.Parse(reader["salario"].ToString());
                    inicioContrato = converteDataDBToDateTime(Convert.ToString(reader["inicioContrato"]));
                    fimContrato = converteDataDBToDateTime(Convert.ToString(reader["fimContrato"]));
                    turnoInicio = Convert.ToString(reader["turnoInicio"]);
                    turnoFim = Convert.ToString(reader["turnoFim"]);
                    idTipoCargo = Convert.ToInt32(reader["idTipoCargo"]);

                    funcionario = new Funcionario(id, primNome, ultNome, dataNascimento, nif, genero, telefone, email, morada, isActive, foto, salario, inicioContrato, fimContrato, turnoInicio, turnoFim, idTipoCargo);
                }
            } catch (Exception ex) {
                closeDB();
                Console.WriteLine(ex.Message);
                throw ex;
            } finally {
                closeDB();
            }

            return funcionario;
        }

        public Funcionario[] getAll() {
            Funcionario[] funcionarios = null;
            int nRows = getNumRegistosDB("funcionario"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT * FROM funcionario";

                command = new MySqlCommand(sql, connection);

                connection.Open();

                reader = command.ExecuteReader();

                funcionarios = new Funcionario[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id, nif, telefone, isActive, idTipoCargo;
                        string primNome, ultNome, genero, email, morada, foto, turnoInicio, turnoFim;
                        float salario;
                        DateTime dataNascimento, inicioContrato, fimContrato;

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
                        salario = float.Parse(reader["salario"].ToString());
                        inicioContrato = converteDataDBToDateTime(Convert.ToString(reader["inicioContrato"]));
                        fimContrato = converteDataDBToDateTime(Convert.ToString(reader["fimContrato"]));
                        turnoInicio = Convert.ToString(reader["turnoInicio"]);
                        turnoFim = Convert.ToString(reader["turnoFim"]);
                        idTipoCargo = Convert.ToInt32(reader["idTipoCargo"]);

                        funcionarios[i] = new Funcionario(id, primNome, ultNome, dataNascimento, nif, genero, telefone, email, morada, isActive, foto, salario, inicioContrato, fimContrato, turnoInicio, turnoFim, idTipoCargo);
                        i++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return funcionarios;
        }

        public Funcionario[] getFuncionariosCargo(int idCargo) {
            Funcionario[] funcionarios = null;
            int nRows = getNumRegistosDB("funcionario"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT * FROM funcionario WHERE idTipoCargo = @idTipoCargo";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idTipoCargo", idCargo);

                connection.Open();

                reader = command.ExecuteReader();

                funcionarios = new Funcionario[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id, nif, telefone, isActive, idTipoCargo;
                        string primNome, ultNome, genero, email, morada, foto, turnoInicio, turnoFim;
                        float salario;
                        DateTime dataNascimento, inicioContrato, fimContrato;

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
                        salario = float.Parse(reader["salario"].ToString());
                        inicioContrato = converteDataDBToDateTime(Convert.ToString(reader["inicioContrato"]));
                        fimContrato = converteDataDBToDateTime(Convert.ToString(reader["fimContrato"]));
                        turnoInicio = Convert.ToString(reader["turnoInicio"]);
                        turnoFim = Convert.ToString(reader["turnoFim"]);
                        idTipoCargo = Convert.ToInt32(reader["idTipoCargo"]);

                        funcionarios[i] = new Funcionario(id, primNome, ultNome, dataNascimento, nif, genero, telefone, email, morada, isActive, foto, salario, inicioContrato, fimContrato, turnoInicio, turnoFim, idTipoCargo);
                        i++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return funcionarios;
        }
    }
}
