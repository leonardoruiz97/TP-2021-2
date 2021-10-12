<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WF_Olvidar_Contraseña.aspx.cs" Inherits="WF_Olvidar_Contraseña" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <meta charset="UTF-8">
  <title></title>
  <meta name="viewport" content="width=device-width, initial-scale=1"><link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css">
<link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.2.3/animate.min.css'>
    <link rel="stylesheet" href="dist/style_login1.css">
</head>
<body>
   <form id="LOGIN" runat="server">

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
    </form>
</body>
</html>
