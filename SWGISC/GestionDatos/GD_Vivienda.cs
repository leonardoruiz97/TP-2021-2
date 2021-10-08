﻿using Dominio;
using System;
using System.Data;
using System.Data.SqlClient;

namespace GestionDatos
{
   public class GD_Vivienda
    {


        SqlConnection sqlc;
        private SqlDataAdapter dat;
        private SqlCommand cmd;
        private DataSet ds;
        public GD_Vivienda()
        {
            sqlc = new SqlConnection(GD_ConexionBD.CadenaConexion);
        }

        public DataTable listar_Vivienda()
        {
            try
            {
                dat = new SqlDataAdapter("SP_Listar_Tipo_Vivienda_ddl", sqlc);
                dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                dat.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
