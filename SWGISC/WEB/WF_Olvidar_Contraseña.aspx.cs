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

public partial class WF_Olvidar_Contraseña : System.Web.UI.Page
{
    Usuario usu = new Usuario();
    N_Usuario Nusu = new N_Usuario();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }

    } 
    void ValidarDNI()
    {
        if (txtDNI.Text == "")
        { 
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "DNIVacio()", true);
            return;
        }
        usu.IU_Dni = int.Parse(txtDNI.Text);
        Nusu.buscarUsuarioDni(usu);
        txtpkiu.Text = "" + usu.PK_IU_Cod;
        if (int.Parse(txtpkiu.Text) != 0)
        {
            txtdnibus.Text = "" + usu.IU_Dni;
            txtcontraseñabus.Text = "" + usu.VU_Contraseña;
            if (txtDNI.Text == txtdnibus.Text)
            {
                Response.Redirect("WF_Actualizar_Contraseña.aspx");
            }
            else if (txtDNI.Text != txtdnibus.Text)
            {
                ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "DNIincorrecta()", true);
            }
        }
        else if (int.Parse(txtpkiu.Text) == 0)
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "noexisteUsuario()", true);
            txtDNI.Text = "";

        }

    }



    protected void Unnamed_Click(object sender, EventArgs e)
    {
        ValidarDNI();
    }

    protected void Retroceder(object sender, EventArgs e)
    {
        Response.Redirect("WF_Iniciar_Sesion.aspx");
    }

 
}
