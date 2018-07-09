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
    <form id="form1" runat="server" method="post" action="../controlador/ctrlTrabajador.aspx">
    <table>
        <tr>
            <td><label>Rut:</label></td>
            <td><input type="text" name="txtRut" placeholder="ingrese rut"/></td>
        </tr>
        <tr>
            <td><label>Nombre:</label></td>
            <td><input type="text" name="txtNombre" /></td>
        </tr>
        <tr>
            <td><label>Usuario:</label></td>
            <td><input type="text" name="txtUser"/></td>
        </tr>
        <tr>
            <td><label>Area Trabajo:</label></td>
            <td><select name="selArea">
                <option value="confiteria">Confiteria</option>
                <option value="boleteria">Boleteria</option>
                <option value="piso">Piso</option>
                </select></td>
        </tr>
        <tr>
            <td>Grado conocimiento:</td>
            <td><input type="text" name="txtGrado"/></td>
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
