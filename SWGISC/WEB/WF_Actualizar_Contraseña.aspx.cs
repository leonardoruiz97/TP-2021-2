using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using GestionDatos;
using System.Data;
using System.Text.RegularExpressions;
using System.Text;
using System.Drawing;
using System.Windows;

public partial class WF_Actualizar_Contraseña : System.Web.UI.Page
{
        Usuario usu = new Usuario();
        N_Usuario Nusu = new N_Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

        }
        void ValidarContraseña()
        {
            if (txtContraseña.Text == "") 
            {
                ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "ContraseñaVacia()", true);
                return;
            }
           if (txtContraseña2.Text == "")
           {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "ContraseñaVacia()", true);
            return;
           }
           if(txtContraseña.Text == txtContraseña2.Text)
           {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "ActualizarContraseña()", true);
            return;
           }
        else
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "ContraseñaIncorrecta()", true);
            return;
        }
        
            usu.IU_Dni = int.Parse(txtContraseña.Text);
            Nusu.buscarUsuarioDni(usu);
        
        
            
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            ValidarContraseña();
        } 
}


