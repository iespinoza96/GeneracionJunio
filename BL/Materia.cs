﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                result.Correct =false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al intentar registrar" + result.Ex;
            }

           return result;

        }


        public static int Sumar(int numeroUno, int numeroDos)
        {
            int result = numeroUno + numeroDos;
            return result;
        }
    }
}
