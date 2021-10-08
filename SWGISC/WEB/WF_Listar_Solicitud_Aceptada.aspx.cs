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
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Data.SqlClient;


public partial class WF_Listar_Solicitud_Aceptada : System.Web.UI.Page
{

    Departamento dep = new Departamento();
    N_Departamento Ndep = new N_Departamento();

    Afiliacion afilia = new Afiliacion();
    N_Afiliacion Nafilia = new N_Afiliacion();

    Estado_Civil ecivil = new Estado_Civil();
    N_EstadoCivil Necivil = new N_EstadoCivil();

    Ocupacion ocu = new Ocupacion();
    N_Ocupacion Nocu = new N_Ocupacion();

    Provincia pro = new Provincia();
    N_Provincia Nprovi = new N_Provincia();

    Solicitud sol = new Solicitud();
    N_Solicitud Nsol = new N_Solicitud();

    Socio so = new Socio();
    N_Socio Nso = new N_Socio();

    Usuario usu = new Usuario();
    N_Usuario Nusu = new N_Usuario();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

         
                listarsolicitudAceptada();
            
      
           
        }
    }


    void listarsolicitudAceptada()
    {
        //    txtpkusuario.Text = "" + 2;
        sol.FK_IESol_Cod = 2;
        gv_Tabla_Lista_Solicitud_Aceptada.DataSource = Nsol.listarsolicitudAceptada(sol);
        gv_Tabla_Lista_Solicitud_Aceptada.DataBind();

    }
    protected void gv_Tabla_Lista_Solicitud_Aceptada_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Credenciales")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            string codSol = gv_Tabla_Lista_Solicitud_Aceptada.Rows[index].Cells[0].Text;
            string dni = gv_Tabla_Lista_Solicitud_Aceptada.Rows[index].Cells[1].Text;
            string correo = gv_Tabla_Lista_Solicitud_Aceptada.Rows[index].Cells[8].Text;
            txtFKsol.Text = codSol;
            txtCorreo.Text = correo;
            txtdni.Text = dni;
            txtcodSoliAceptada.Text = codSol;
            buscarSocio();
            registrarUsuario();
            validarCorreo();
        }

        if (e.CommandName == "Ver")//VER 

        {
            int index = Convert.ToInt32(e.CommandArgument);
            txtcodSoliAceptada.Text = gv_Tabla_Lista_Solicitud_Aceptada.Rows[index].Cells[0].Text;
            Session["CodSoliGrid"] = "" + txtcodSoliAceptada.Text;
            Response.Redirect("WF_Detalle_Solicitud.aspx");


        }

    }



    void buscarSocio()
    {
        so.IS_Dni = int.Parse(txtdni.Text);
        Nso.BuscarSocioxdni(so);
        txtfksocio.Text = "" + so.PK_IS_Cod;

    }

    void registrarUsuario()
    {
        usu.VU_Correo = txtCorreo.Text;
        usu.IU_Dni = int.Parse(txtdni.Text);
        usu.FK_IS_Cod =int.Parse(txtfksocio.Text);
        Nusu.RegistrarUsuario(usu);
    }
    void validarCorreo()
    {
        SqlConnection sc = new SqlConnection(GD_ConexionBD.CadenaConexion);
        {
            SqlCommand cmd = new SqlCommand("ValidarCorreo", sc);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@correo", txtCorreo.Text);
            try
            {
                sc.Open();
                SqlDataReader lector = cmd.ExecuteReader();
                if (lector.Read() == true)
                {
                    GenerarNuevaContrasena(txtCorreo.Text);

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "error()", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + "" + ex.Message + "');", true);
            }
        }
    }

    void GenerarNuevaContrasena(string email)
    {
        Random rd = new Random(DateTime.Now.Millisecond);
        int nuevaContrasena = rd.Next(100000, 999999);
        SqlConnection sc = new SqlConnection(GD_ConexionBD.CadenaConexion);
        SqlCommand cmd = new SqlCommand("NuevaContrasena", sc);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@correo", email);
        cmd.Parameters.AddWithValue("@contrasena", nuevaContrasena);
        try
        {
            sc.Open();
            int filasAfectadas = cmd.ExecuteNonQuery();
            if (filasAfectadas != 0)
            {
                enviarCredenciales(nuevaContrasena, email);
            }
        }
        catch
        {

        }
    }

   


    void enviarCredenciales(int contrasenaNueva, string correo)
    {
        string contraseña = this.Contrasena;
        string mensaje = string.Empty;
        //Creando el correo electronico
        string destinatario = correo;
        //ingresar el correo de GOMIVI
        string remitente = "coopacsancosmeltda@gmail.com";
        string asunto = "CREDENCIALES COOPAC SAN COSME";
        string cuerpoDelMesaje = "Su nueva contraseña es" + " " + Convert.ToString(contrasenaNueva);
        MailMessage ms = new MailMessage(remitente, destinatario, asunto, cuerpoDelMesaje);


        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 25);
        smtp.EnableSsl = true;
        //ingresar el correo de san cosme
        smtp.Credentials = new NetworkCredential("coopacsancosmeltda@gmail.com", contraseña);

        try
        {
            Task.Run(() => {
                smtp.Send(ms);
                ms.Dispose();
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "correcto()", true);
            }

            );
            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "temporizador()", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + "Error al enviar correo electronico: " + "');" + ex.Message, true);
        }
    }


    public string Contrasena
    {
        get
        { return "ME12345@"; }
    }










    //igresar la contrtaseña de san cosme


    protected void gv_Tabla_Lista_Solicitud_Aceptada_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_Tabla_Lista_Solicitud_Aceptada.PageIndex = e.NewPageIndex;
        listarsolicitudAceptada();
    }

    protected void gv_Tabla_Lista_Solicitud_Aceptada_DataBound(object sender, EventArgs e)
    {
       
    }

    protected void gv_Tabla_Lista_Solicitud_Aceptada_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType== DataControlRowType.DataRow)
        {
            string estado = DataBinder.Eval(e.Row.DataItem,"VEsol_Estado_Solicitud").ToString();
            if (estado == "Aceptado")
            {
                e.Row.Cells[11].BackColor = System.Drawing.Color.DarkSeaGreen;
                e.Row.Cells[11].ForeColor = System.Drawing.Color.White;
                e.Row.Cells[11].Width = 100;


            }
        }
    }
}