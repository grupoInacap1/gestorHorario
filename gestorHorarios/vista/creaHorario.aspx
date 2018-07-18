<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="creaHorario.aspx.cs" Inherits="gestorHorarios.vista.creaHorario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
        <a href="homeEncargado.aspx">Volver</a>
        <a align="left" href="login.aspx">Cerrar Sesión</a>
    </header>
    <form id="form1" runat="server" method="post" action="../controlador/ctrlTurno.aspx">
    <div>
        <input type="submit" value="Crea horario"/>
    </div>
    </form>
</body>
</html>
