<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homeEncargado.aspx.cs" Inherits="gestorHorarios.vista.homeEncargado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="../css/homeEncargado.css"/>
    <title></title>
    <%
            if (Session["mensaje"] != null)
            {
                Response.Write("<h4 align='center'>"+Session["mensaje"]+"</h4>");
            }
            Session.Remove("mensaje");
        %>
</head>
<body>
    <form id="form1" runat="server">
        <header align="left">
            <a href="login.aspx">Cerrar Sesión</a>
        </header>
        <table align="center">
            <tr>
                <td>Trabajadores</td>
                <td><a href="registrarTrabajador.aspx">Registrar trabajador</a></td>
            </tr>
            <tr>
                <td>Permisos</td>
                <td>
                    <a href="creaPermiso.aspx">Crear Permiso</a>
                    <a href="listaPermisos.aspx">Buscar Permiso</a>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
