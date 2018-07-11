<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homeTrabajador.aspx.cs" Inherits="gestorHorarios.vista.homeTrabajador" %>

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
            Session.Remove("mensaje");
        %>
        <a align="left" href="login.aspx">Cerrar Sesión</a>
    </header>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
