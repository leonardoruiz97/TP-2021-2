using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace GestionDatos
{
   public class GD_Amortizacion
    {
        SqlConnection sqlc;
        private SqlDataAdapter dat;
        private SqlCommand cmd;
        private DataSet ds;
        public GD_Amortizacion()
        {
            sqlc = new SqlConnection(GD_ConexionBD.CadenaConexion);
        }


        public int registrarAmortizacion(Amortizacion amor)
        {

            cmd = new SqlCommand("Sp_RegistraAmortizacion", sqlc);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VAmor_Mes ", amor.VAmor_Mes);
            cmd.Parameters.AddWithValue("@FAmor_Monto_Cuota", amor.FAmor_Monto_Cuota);
            cmd.Parameters.AddWithValue("@DAmor_Fecha_Pago", amor.DAmor_Fecha_Pago);
            cmd.Parameters.AddWithValue("@FK_IPe_Cod", amor.FK_IPe_Cod);
            cmd.Parameters.AddWithValue("@FK_IPre_Cod", amor.FK_IPre_Cod);
            sqlc.Open();
            cmd.ExecuteNonQuery();
            sqlc.Close();
            return 1;
        }

    }
}
