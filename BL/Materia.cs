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
        // 3 query normal (Insert, update , delete)
        // 5 SP (Add,Update,Delete,GetAll y GetById)

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

                            foreach (DataRow row in tableMateria.Rows)
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

        //EF 

        public static ML.Result AddEF(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LEscogidoProgramacionNCapasGJEntities context = new DL_EF.LEscogidoProgramacionNCapasGJEntities())
                {
                    int queryResult = context.MateriaAdd(materia.Nombre, materia.Creditos, materia.Semestre.IdSemestre);

                    if (queryResult > 0)
                    {
                        result.Correct = true;
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
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoProgramacionNCapasGJEntities context = new DL_EF.LEscogidoProgramacionNCapasGJEntities())
                {
                    var query = context.MateriaGetAll().ToList();

                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var resultMateria in query)//iterar sobre listas, colecciones, arreglos
                        {
                            ML.Materia materia = new ML.Materia();
                            materia.Nombre = resultMateria.NombreMateria;
                            materia.Creditos = resultMateria.Creditos.Value;
                            materia.Semestre = new ML.Semestre(); //instancia de la propiedad de navegación, solo se instancia una vez
                            materia.Semestre.IdSemestre = resultMateria.IdSemestre.Value;
                            materia.Semestre.Nombre = resultMateria.NombreSemestre;

                            result.Objects.Add(materia);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public static ML.Result GetByIdEF(int idMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoProgramacionNCapasGJEntities context = new DL_EF.LEscogidoProgramacionNCapasGJEntities())
                {
                    var query = context.MateriaGetById(idMateria).FirstOrDefault();

                    if (query != null)
                    {
                        ML.Materia materia = new ML.Materia();
                        materia.IdMateria = query.IdMateria;
                        materia.Nombre = query.Nombre;
                        materia.Creditos = query.Creditos.Value;
                        

                        materia.Semestre = new ML.Semestre();
                        //materia.Semestre.IdSemestre = query.;


                        result.Object = materia;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        //LINQ

        public static ML.Result GetAllLINQ()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LEscogidoProgramacionNCapasGJEntities context = new DL_EF.LEscogidoProgramacionNCapasGJEntities())
                {
                    var queryList = (from materiaLinq in context.Materias
                                 join semestreLinq in context.Semestres on materiaLinq.IdSemestre equals semestreLinq.IdSemestre
                                 select new {
                                     IdMateria = materiaLinq.IdMateria,
                                     Nombre = materiaLinq.Nombre, 
                                     Creditos = materiaLinq.Creditos, 
                                     IdSemestre = materiaLinq.IdSemestre,
                                     NombreSemestre = semestreLinq.Nombre
                                 });

                    result.Objects = new List<object>();

                    if (queryList != null && queryList.ToList().Count > 0)
                    {
                        foreach (var obj in queryList)
                        {
                            ML.Materia materia = new ML.Materia();
                            materia.IdMateria = obj.IdMateria;
                            materia.Nombre = obj.Nombre;
                            materia.Creditos = obj.Creditos.Value;

                            materia.Semestre = new ML.Semestre();
                            materia.Semestre.IdSemestre = obj.IdSemestre.Value;
                            materia.Semestre.Nombre = obj.NombreSemestre;

                            result.Objects.Add(materia);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se encontraron registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public static ML.Result AddLINQ(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoProgramacionNCapasGJEntities context = new DL_EF.LEscogidoProgramacionNCapasGJEntities())
                {
                    DL_EF.Materia materiaLinq = new DL_EF.Materia();

                    materiaLinq.Nombre = materia.Nombre;
                    materiaLinq.Creditos = materia.Creditos;
                    materiaLinq.IdSemestre = materia.Semestre.IdSemestre;
                    

                    context.Materias.Add(materiaLinq);
                    int rowsAffected = context.SaveChanges();

                    if (rowsAffected > 0 )
                    {
                        result.Correct = true;
                        result.Message = "Registro insertado correctamente";
                    }


                }

                
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }

            return result;
        }


    }
}
