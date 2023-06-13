using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML;

namespace BL
{
    public class Materia
    {

        public static ML.Result Add(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "INSERT INTO Materia (Nombre,Creditos) VALUES (@Nombre,@Creditos)";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;


                        SqlParameter[] collection = new SqlParameter[2];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = materia.Nombre;

                        collection[1] = new SqlParameter("Creditos", SqlDbType.TinyInt);
                        collection[1].Value = materia.Creditos;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                            result.Message = "El registro se inserto correctamente";
                        }

                    }
                }


            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al intentar registrar" + result.Ex;
            }

            return result;

        }

        public static ML.Result GetAllSP() //seleccionar datos 
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "MateriaGetAll";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable tableMateria = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableMateria);

                        if (tableMateria.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tableMateria.Rows )
                            {
                                ML.Materia materia = new ML.Materia();
                                materia.IdMateria = int.Parse(row[0].ToString());
                                materia.Nombre = row[1].ToString();
                                materia.Creditos = byte.Parse(row[2].ToString());

                                result.Objects.Add(materia);
                            }

                            result.Correct = true;
                        }
                        else
                        {
                        }

                    }

                }

            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;

                result.Correct = false;
                result.Message = "Ocurrió un error al seleccionar los registros en la tabla Producto" + result.Ex;
            }



            return result;
        }

        public static ML.Result GetByIdSP(int idMateria) //seleccionar datos 
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "MateriaGetById";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdMateria", SqlDbType.Int);
                        collection[0].Value = idMateria;

                        cmd.Parameters.AddRange(collection);

                        DataTable tableMateria = new DataTable();

                        //SqlDataReader dataReader = cmd.ExecuteReader();

                        //if (dataReader.Read())
                        //{
                        //    ML.Materia materia = new ML.Materia();
                        //    materia.IdMateria = dataReader.
                        //    materia.Nombre = row[1].ToString();
                        //    materia.Creditos = byte.Parse(row[2].ToString());

                        //}

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

                        dataAdapter.Fill(tableMateria);

                        if (tableMateria.Rows.Count > 0)
                        {
                            DataRow row = tableMateria.Rows[0];


                            ML.Materia materia = new ML.Materia();
                            materia.IdMateria = int.Parse(row[0].ToString());
                            materia.Nombre = row[1].ToString();
                            materia.Creditos = byte.Parse(row[2].ToString());

                            result.Object = materia; //boxing


                            result.Correct = true;
                        }
        

                    }

                }

            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;

                result.Correct = false;
                result.Message = "Ocurrió un error al seleccionar los registros en la tabla Producto" + result.Ex;
            }



            return result;
        }


    }
}
