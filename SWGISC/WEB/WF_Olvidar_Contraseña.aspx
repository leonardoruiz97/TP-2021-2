<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WF_Olvidar_Contraseña.aspx.cs" Inherits="WF_Olvidar_Contraseña" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <meta charset="UTF-8">
  <title></title>
  <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css">
<link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.2.3/animate.min.css'>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <link rel="stylesheet" href="dist/style_olvidar.css">
</head>
<body>
   <form id="LOGIN" runat="server">
<!--
<div class='box'>
  <div class='box-form'>
    <div class='box-login-tab'></div>
    <div class='box-login-title'>
      <div class='i i-login'></div><h2>Recuperar</h2>
    </div>
    <div class='box-login'>
      <div class='fieldset-body' id='login_form'>
        <button onclick="openLoginInfo();" class='b b-form i i-more' title='Mais Informações'></button>
        	<p class='field'>
                <asp:Label ID="txtcontraseñabus" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:Label ID="txtpkiu" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="txtusu" runat="server" Text="" Visible="false"></asp:Label>
                       <asp:Label ID="txtdnibus" runat="server" Text="" Visible="false"></asp:Label>
                         <asp:Label ID="txtcorreobus" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="txtfkrol" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="txtfksocio" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="txtfkpatrocinador" runat="server" Text="" Visible="false"></asp:Label>

          <img src="img/iconoCosme.png" width="100" height="100">
          <label for='user'>Ingresa tu DNI</label>
           <asp:TextBox ID="txtDNI" minlength="8" MaxLength="8" runat="server" placeholder="DNI"></asp:TextBox>
          <span id='valida' class='i i-warning'></span>
        </p>     	 

           <asp:Button class="btnIniciar" runat="server" Text="SIGUENTE" OnClick="Unnamed_Click"></asp:Button>
           <asp:Button class="btnIniciar" runat="server" Text="ATRAS" OnClick="Retroceder"></asp:Button>
    </div>
  </div>
    -->
       <asp:panel ID="panel1" runat="server">
           <div class='box-login center'>
      <div class='fieldset-body' id='login_form'>
       
        	<p class='field'>
                
                <asp:Label ID="txtcontraseñabus1" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:Label ID="txtpkiu1" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="txtusu1" runat="server" Text="" Visible="false"></asp:Label>
                       <asp:Label ID="txtdnibus1" runat="server" Text="" Visible="false"></asp:Label>
                         <asp:Label ID="txtcorreobus1" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="txtfkrol1" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="txtfksocio1" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="txtfkpatrocinador1" runat="server" Text="" Visible="false"></asp:Label>
                    

          <img src="img/iconoCosme.png" width="100" height="100">
          <label for='user'>Ingresa tu DNI</label>
           <asp:TextBox ID="txtDNI1" minlength="8" MaxLength="8" runat="server" placeholder="DNI"></asp:TextBox>
          <span id='valida' class='i i-warning'></span>
        </p>     	 

           <asp:Button class="btnIniciar" runat="server" Text="SIGUENTE" OnClick="Unnamed_Click"></asp:Button>
           <asp:Button class="btnIniciar" runat="server" Text="ATRAS" OnClick="Retroceder"></asp:Button>
    </div>
              </div>
       </asp:panel>

       <asp:panel ID="panel2" runat="server">
            <div class="formulario" style="background-color:white;">
	<form>
        <fieldset>
        	<legend>Cambio de contraseña</legend>
            <label for="claveActual">Contraseña actual</label>
            <asp:TextBox ID="txtContraseña" MaxLength="8" runat="server" placeholder="Solo 8 Digitos"></asp:TextBox>           
             <asp:Button class="btnIniciar" runat="server" Text="SIGUENTE" OnClick="Actualizar"></asp:Button>
        </fieldset>
    </form>
</div>
<div class="nivelSeguridad" style="background-color:white;">
    <p>Nivel de seguridad de contraseña</p>
    <span id="nivelseguridad">bajo</span>
    <div class="nivelesColores">
      <div class="spanNivelesColores"></div>
    </div>
  
  <div class="NivelesColores"
       ></div>
  
</div>

<h2 class="clavecorrecta oculto">
  ¡¡¡ Enhorabuena, la clave se ha establecido correctamente !!!
</h2>
       </asp:panel>
      

      <script src="../js/sweetalert.js"></script>
                    <script>
                        function DNIVacio() {
                            Swal.fire({
                                position: 'center',
                                icon: 'error',
                                title: 'Ingrese DNI',
                                showConfirmButton: false,
                                timer: 2000
                            })
                        }
                        function ContraseñaVacia() {
                            Swal.fire({
                                position: 'center',
                                icon: 'error',
                                title: 'Ingrese Contraseña',
                                showConfirmButton: false,
                                timer: 2000
                            })
                        } 
                        function DNIincorrepto() {
                            Swal.fire({
                                position: 'center',
                                icon: 'error',
                                title: 'Incorrecto de DNI',
                                showConfirmButton: false,
                                timer: 2000
                            })
                        } 
                        function noexisteUsuario() {
                            Swal.fire({
                                position: 'center',
                                icon: 'error',
                                title: 'Usuario No Existe',
                                showConfirmButton: false,
                                timer: 2000
                            })
                        } 
                    


                    </script>
       <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
       <script src='https://cdnjs.cloudflare.com/ajax/libs/modernizr/2.8.3/modernizr.min.js'>
       </script><script  src="dist/script_olvidar.js"></script>
    </form>
</body>
</html>
