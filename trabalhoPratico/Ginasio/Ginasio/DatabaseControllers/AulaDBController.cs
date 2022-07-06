using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Ginasio.Classes;

namespace Ginasio.DatabaseControllers {
    internal class AulaDBController : BaseDBController {
        public int inserir(Aula aula) {
            int id;

            try {
                connection = DBConn();

                sql = "INSERT INTO aula(idModalidade, nSala, maxAlunos, diaSemana, hora, idProfessor) VALUES(@idModalidade, @nSala, @maxAlunos, @diaSemana, @hora, @idProfessor)";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idModalidade", aula.idModalidade);
                command.Parameters.AddWithValue("@nSala", aula.nSala);
                command.Parameters.AddWithValue("@maxAlunos", aula.maxAlunos);
                command.Parameters.AddWithValue("@diaSemana", aula.diaSemana);
                command.Parameters.AddWithValue("@hora", aula.hora);
                command.Parameters.AddWithValue("@idProfessor", aula.idProfessor);

                connection.Open();

                if (command.ExecuteNonQuery() == 1) {
                    command = null;

                    sql = "SELECT LAST_INSERT_ID() as `id` FROM `aula` LIMIT 1";

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

        public bool alterar(Aula aula) {
            bool status;

            try {
                connection = DBConn();

                sql = "UPDATE aula SET idModalidade = @idModalidade, nSala = @nSala , maxAlunos = @maxAlunos, diaSemana = @diaSemana, hora = @hora, idProfessor = @idProfessor where id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idModalidade", aula.idModalidade);
                command.Parameters.AddWithValue("@nSala", aula.nSala);
                command.Parameters.AddWithValue("@maxAlunos", aula.maxAlunos);
                command.Parameters.AddWithValue("@diaSemana", aula.diaSemana);
                command.Parameters.AddWithValue("@hora", aula.hora);
                command.Parameters.AddWithValue("@idProfessor", aula.idProfessor);
                command.Parameters.AddWithValue("@id", aula.id);

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

                sql = "DELETE FROM aula WHERE id = @id";

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

        public Aula getById(int idAula) {
            Aula aula = null;

            try {
                connection = DBConn();

                sql = "SELECT * FROM aula WHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idAula);

                connection.Open();

                reader = command.ExecuteReader();

                if (reader != null && reader.HasRows && reader.Read()) {
                    int id, idModalidade, nSala, maxAlunos, diaSemana, idProfessor;
                    string hora;

                    id = Convert.ToInt32(reader["id"]);
                    idModalidade = Convert.ToInt32(reader["idModalidade"]);
                    nSala = Convert.ToInt32(reader["nSala"]);
                    maxAlunos = Convert.ToInt32(reader["maxAlunos"]);
                    diaSemana = Convert.ToInt32(reader["diaSemana"]);
                    idProfessor = Convert.ToInt32(reader["idProfessor"]);
                    hora = Convert.ToString(reader["hora"]);

                    aula = new Aula(id, idModalidade, nSala, maxAlunos, diaSemana, hora, idProfessor);
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return aula;
        }

        public Aula[] getAll() {
            Aula[] aulas = null;
            int nRows = getNumRegistosDB("aula"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT * FROM aula";

                command = new MySqlCommand(sql, connection);

                connection.Open();

                reader = command.ExecuteReader();

                aulas = new Aula[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id, idModalidade, nSala, maxAlunos, diaSemana, idProfessor;
                        string hora;

                        id = Convert.ToInt32(reader["id"]);
                        idModalidade = Convert.ToInt32(reader["idModalidade"]);
                        nSala = Convert.ToInt32(reader["nSala"]);
                        maxAlunos = Convert.ToInt32(reader["maxAlunos"]);
                        diaSemana = Convert.ToInt32(reader["diaSemana"]);
                        idProfessor = Convert.ToInt32(reader["idProfessor"]);
                        hora = Convert.ToString(reader["hora"]);

                        aulas[i] = new Aula(id, idModalidade, nSala, maxAlunos, diaSemana, hora, idProfessor);
                        i++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return aulas;
        }

        public Aula[] getAulasByClientID(int idCliente) {
            Aula[] aulas = null;
            int nRows = getNumRegistosDB("aula"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT aula.* FROM aula, aulasCliente WHERE aula.id = aulasCliente.idAula and aulasCliente.idCliente = @idCliente";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idCliente", idCliente);

                connection.Open();

                reader = command.ExecuteReader();

                aulas = new Aula[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id, idModalidade, nSala, maxAlunos, diaSemana, idProfessor;
                        string hora;

                        id = Convert.ToInt32(reader["id"]);
                        idModalidade = Convert.ToInt32(reader["idModalidade"]);
                        nSala = Convert.ToInt32(reader["nSala"]);
                        maxAlunos = Convert.ToInt32(reader["maxAlunos"]);
                        diaSemana = Convert.ToInt32(reader["diaSemana"]);
                        idProfessor = Convert.ToInt32(reader["idProfessor"]);
                        hora = Convert.ToString(reader["hora"]);

                        aulas[i] = new Aula(id, idModalidade, nSala, maxAlunos, diaSemana, hora, idProfessor);
                        i++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return aulas;
        }

        public Aula[] getAulasByFuncionarioID(int idFuncionario) {
            Aula[] aulas = null;
            int nRows = getNumRegistosDB("aula"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT * FROM aula WHERE idProfessor = @idProfessor";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idProfessor", idFuncionario);

                connection.Open();

                reader = command.ExecuteReader();

                aulas = new Aula[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id, idModalidade, nSala, maxAlunos, diaSemana, idProfessor;
                        string hora;

                        id = Convert.ToInt32(reader["id"]);
                        idModalidade = Convert.ToInt32(reader["idModalidade"]);
                        nSala = Convert.ToInt32(reader["nSala"]);
                        maxAlunos = Convert.ToInt32(reader["maxAlunos"]);
                        diaSemana = Convert.ToInt32(reader["diaSemana"]);
                        idProfessor = Convert.ToInt32(reader["idProfessor"]);
                        hora = Convert.ToString(reader["hora"]);

                        aulas[i] = new Aula(id, idModalidade, nSala, maxAlunos, diaSemana, hora, idProfessor);
                        i++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return aulas;
        }

        public Aula[] getAulasByModalidadeID(int modalidadeID) {
            Aula[] aulas = null;
            int nRows = getNumRegistosDB("aula"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT * FROM aula WHERE idModalidade = @idModalidade";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idModalidade", modalidadeID);

                connection.Open();

                reader = command.ExecuteReader();

                aulas = new Aula[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id, idModalidade, nSala, maxAlunos, diaSemana, idProfessor;
                        string hora;

                        id = Convert.ToInt32(reader["id"]);
                        idModalidade = Convert.ToInt32(reader["idModalidade"]);
                        nSala = Convert.ToInt32(reader["nSala"]);
                        maxAlunos = Convert.ToInt32(reader["maxAlunos"]);
                        diaSemana = Convert.ToInt32(reader["diaSemana"]);
                        idProfessor = Convert.ToInt32(reader["idProfessor"]);
                        hora = Convert.ToString(reader["hora"]);

                        aulas[i] = new Aula(id, idModalidade, nSala, maxAlunos, diaSemana, hora, idProfessor);
                        i++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return aulas;
        }
    }
}
