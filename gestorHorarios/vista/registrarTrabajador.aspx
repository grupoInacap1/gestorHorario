<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registrarTrabajador.aspx.cs" Inherits="gestorHorarios.vista.registrarTrabajador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <%
        if(Session["mensaje"] != null)
        {
            Response.Write("<h4 align='center'>"+Session["mensaje"]+"</h4>");
            Session.Remove("mensaje");
        }
    %>
</head>
<body>
    <header align="left">
        <a href="homeEncargado.aspx">Volver</a>
    </header>
    <form id="form1" runat="server" method="post" action="../controlador/ctrlTrabajador.aspx">
    <table align="center">
        <tr>
            <td><label>Rut:</label></td>
            <td><input type="text" name="txtRut" placeholder="ingrese rut" required=""/></td>
        </tr>
        <tr>
            <td><label>Nombre:</label></td>
            <td><input type="text" name="txtNombre" required=""/></td>
        </tr>
        <tr>
            <td><label>Apellido:</label></td>
            <td><input type="text" name="txtApellido" required=""/></td>
        </tr>
        <tr>
            <td><label>Area Trabajo:</label></td>
            <td>
                <select name="selArea" required="">
                <%
                    List<gestorHorarios.modelo.AreaTrabajo> listaAT = new List<gestorHorarios.modelo.AreaTrabajo>();
                    gestorHorarios.modelo.AreaTrabajo at = new gestorHorarios.modelo.AreaTrabajo();
                    listaAT = at.listaAreas();
                    foreach (gestorHorarios.modelo.AreaTrabajo cont in listaAT)
                    {
                        Response.Write("<option value='"+cont.At_nombre+"'>"+
                            cont.At_nombre+"</option>");
                    }
                %>
                </select></td>
        </tr>
        <tr>
            <td>Grado conocimiento:</td>
            <td><input type="text" name="txtGrado" required=""/></td>
        </tr>
        <tr>
            <td>Fecha ingreso:</td>
            <td><input type="date" name="dateFechaIng" required=""/></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <input type="submit" value="Registrar trabajador" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

