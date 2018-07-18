<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homeEncargado.aspx.cs" Inherits="gestorHorarios.vista.homeEncargado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="../css/homeEncargado.css"/>
    <title></title>
</head>
<body>
    <header>
        <%
            if (Session["mensaje"] != null)
            {
                Response.Write("<h4 align='center'>"+Session["mensaje"]+"</h4>");
            }
            if(Session["usuario"] != null)
            {
                Response.Write("<h4 align='center'>" + Session["usuario"] + "</h4>");
            }
            Session.Remove("mensaje");
        %>
        <a align="left" href="login.aspx">Cerrar Sesión</a>
    </header>
    <form id="form1" runat="server">
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
            <tr>
                <td>Horarios</td>
                <td>
                    <a href="creaHorario.aspx">Crear Horario</a>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
