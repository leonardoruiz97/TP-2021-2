using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Amortizacion
    {
        public int PK_IAmor_Cod { get; set; }
        public string VAmor_Mes { get; set; }

        public double FAmor_Monto_Cuota { get; set; }

        public DateTime DAmor_Fecha_Pago { get; set; }
        public int FK_IPe_Cod { get; set; }

        public int FK_IPre_Cod { get; set; }

    }
}
