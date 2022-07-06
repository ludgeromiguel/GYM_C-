using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Ginasio.Classes;

namespace Ginasio.DatabaseControllers {
    internal class PlanoNutrucionalDBController : BaseDBController {
        public bool inserir(PlanoNutricional planoNutricional) {
            bool status;

            try {
                connection = DBConn();

                sql = "INSERT INTO planoNutricional(diaSemana, idCliente, pequenoAlmoco, lancheManha, almoco, lancheTarde, jantar, ceia) VALUES(@diaSemana, @idCliente, @pequenoAlmoco, @lancheManha, @almoco, @lancheTarde, @jantar, @ceia)";
            
                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@diaSemana", planoNutricional.diaSemana);
                command.Parameters.AddWithValue("@idCliente", planoNutricional.idCliente);
                command.Parameters.AddWithValue("@pequenoAlmoco", planoNutricional.pequenoAlomoco);
                command.Parameters.AddWithValue("@lancheManha", planoNutricional.lancheManha);
                command.Parameters.AddWithValue("@almoco", planoNutricional.almoco);
                command.Parameters.AddWithValue("@lancheTarde", planoNutricional.lancheTarde);
                command.Parameters.AddWithValue("@jantar", planoNutricional.jantar);
                command.Parameters.AddWithValue("@ceia", planoNutricional.ceia);

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

        public bool alterar(PlanoNutricional planoNutricional) {
            bool status;

            try {
                connection = DBConn();

                sql = "UPDATE planoNutricional SET pequenoAlmoco = @pequenoAlmoco, lancheManha = @lancheManha, almoco = @almoco, lancheTarde = @lancheTarde, jantar = @jantar, ceia = @ceia WHERE diaSemana = @diaSemana and idCliente = @idCliente";
                
                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@pequenoAlmoco", planoNutricional.pequenoAlomoco);
                command.Parameters.AddWithValue("@lancheManha", planoNutricional.lancheManha);
                command.Parameters.AddWithValue("@almoco", planoNutricional.almoco);
                command.Parameters.AddWithValue("@lancheTarde", planoNutricional.lancheTarde);
                command.Parameters.AddWithValue("@jantar", planoNutricional.jantar);
                command.Parameters.AddWithValue("@ceita", planoNutricional.ceia);
                command.Parameters.AddWithValue("@diaSemana", planoNutricional.diaSemana);
                command.Parameters.AddWithValue("@idCliente", planoNutricional.idCliente);

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

        public bool remover(int diaSemana, int idCliente) {
            bool status;

            try {
                connection = DBConn();

                sql = "DELETE FROM planoNutricional WHERE diaSemana = @diaSemana and idCliente = @idCliente";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@diaSemana", diaSemana);
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

        public PlanoNutricional getByIds(int semanaID, int clienteID) {
            PlanoNutricional planoNutricional = null;

            try {
                connection = DBConn();

                sql = "SELECT * FROM planoNutricional WHERE diaSemana = @diaSemana and idCliente = @idCliente";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@diaSemana", semanaID);
                command.Parameters.AddWithValue("@idCliente", clienteID);

                connection.Open();

                reader = command.ExecuteReader();

                if (reader != null && reader.HasRows && reader.Read()) {
                    int diaSemana, idCliente;
                    string pequenoAlmoco, lancheManha, almoco, lancheTarde, jantar, ceia;

                    diaSemana = Convert.ToInt32(reader["diaSemana"]);
                    idCliente = Convert.ToInt32(reader["idCliente"]);
                    pequenoAlmoco = Convert.ToString(reader["pequenoAlmoco"]);
                    lancheManha = Convert.ToString(reader["lancheManha"]);
                    almoco = Convert.ToString(reader["almoco"]);
                    lancheTarde = Convert.ToString(reader["lancheTarde"]);
                    jantar = Convert.ToString(reader["jantar"]);
                    ceia = Convert.ToString(reader["ceia"]);

                    planoNutricional = new PlanoNutricional(diaSemana, idCliente, pequenoAlmoco, lancheManha, almoco, lancheTarde, jantar, ceia);
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return planoNutricional;
        }

        public PlanoNutricional[] getAll() {
            PlanoNutricional[] planosNutricionais = null;
            int nRows = getNumRegistosDB("planoNutricional"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT * FROM planoNutricional";

                command = new MySqlCommand(sql, connection);

                connection.Open();

                reader = command.ExecuteReader();

                planosNutricionais = new PlanoNutricional[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int diaSemana, idCliente;
                        string pequenoAlmoco, lancheManha, almoco, lancheTarde, jantar, ceia;

                        diaSemana = Convert.ToInt32(reader["diaSemana"]);
                        idCliente = Convert.ToInt32(reader["idCliente"]);
                        pequenoAlmoco = Convert.ToString(reader["pequenoAlmoco"]);
                        lancheManha = Convert.ToString(reader["lancheManha"]);
                        almoco = Convert.ToString(reader["almoco"]);
                        lancheTarde = Convert.ToString(reader["lancheTarde"]);
                        jantar = Convert.ToString(reader["jantar"]);
                        ceia = Convert.ToString(reader["ceia"]);

                        planosNutricionais[i] = new PlanoNutricional(diaSemana, idCliente, pequenoAlmoco, lancheManha, almoco, lancheTarde, jantar, ceia);
                        i++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return planosNutricionais;
        }

        public PlanoNutricional[] getPlanoNutricionalCliente(int clienteID) {
            PlanoNutricional[] planosNutricionais = null;
            int nRows = getNumRegistosDB("planoNutricional"), i = 0;

            try {
                connection = DBConn();

                sql = "SELECT * FROM planoNutricional WHERE idCliente = @idClinete";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idClinete", clienteID);

                connection.Open();

                reader = command.ExecuteReader();

                planosNutricionais = new PlanoNutricional[nRows];

                if (reader.HasRows) {
                    while (reader.Read()) {
                        int diaSemana, idCliente;
                        string pequenoAlmoco, lancheManha, almoco, lancheTarde, jantar, ceia;

                        diaSemana = Convert.ToInt32(reader["diaSemana"]);
                        idCliente = Convert.ToInt32(reader["idCliente"]);
                        pequenoAlmoco = Convert.ToString(reader["pequenoAlmoco"]);
                        lancheManha = Convert.ToString(reader["lancheManha"]);
                        almoco = Convert.ToString(reader["almoco"]);
                        lancheTarde = Convert.ToString(reader["lancheTarde"]);
                        jantar = Convert.ToString(reader["jantar"]);
                        ceia = Convert.ToString(reader["ceia"]);

                        planosNutricionais[i] = new PlanoNutricional(diaSemana, idCliente, pequenoAlmoco, lancheManha, almoco, lancheTarde, jantar, ceia);
                        i++;
                    }
                }
            } catch (Exception ex) {
                closeDB();
                throw ex;
            } finally {
                closeDB();
            }

            return planosNutricionais;
        }
    }
}
