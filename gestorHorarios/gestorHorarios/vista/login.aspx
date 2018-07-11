<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="gestorHorarios.vista.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" method="post" action="../controlador/ctrlLogin.aspx">
        <table align="center">
            <tr>
                <td>Usuario:</td>
                <td><input type="text" name="txtUser"/></td>
            </tr>
            <tr>
                <td>Contraseña:</td>
                <td><input type="password" name="txtPass"/></td>
            </tr>
            <tr>
                <td></td>
                <td><input type="submit" value="Iniciar Sesión"/></td>
            </tr>
        </table>
    </form>
</body>
</html>
