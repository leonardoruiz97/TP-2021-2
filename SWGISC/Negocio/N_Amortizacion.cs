using Dominio;
using GestionDatos;
using System.Data;
namespace Negocio
{
    public class N_Amortizacion
    {
        GD_Amortizacion objAmor;

        public N_Amortizacion()
        {

            objAmor = new GD_Amortizacion();
        }

        public int RegistrarAmortizacion(Amortizacion amor)
        {
            return objAmor.registrarAmortizacion(amor);
        }
    }
}
