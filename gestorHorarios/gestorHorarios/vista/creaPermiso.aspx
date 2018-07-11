<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="creaPermiso.aspx.cs" Inherits="gestorHorarios.vista.creaPermiso" %>

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
    <header>
        <a href="homeEncargado.aspx">Volver</a>
    </header>
    <form id="form1" runat="server" method="post" action="../controlador/ctrlPermiso.aspx">
    <div>
    <table align="center">
        <tr>
            <td><label>Rut:</label></td>
            <td><input type="text" name="txtRut" placeholder="ingrese rut trabajador"</td>
        </tr>
        <tr>
            <td><label>Tipo permiso:</label></td>
            <td>
                <select name="selTP">
                    <%
                        List<gestorHorarios.modelo.TipoPermiso> listaTP = new List<gestorHorarios.modelo.TipoPermiso>();
                        gestorHorarios.modelo.TipoPermiso tp = new gestorHorarios.modelo.TipoPermiso();
                        listaTP = tp.cargaTP();
                        foreach (gestorHorarios.modelo.TipoPermiso cont in listaTP)
                        {
                            Response.Write("<option value='"+cont.Tp_id_tipo_permiso+"'>"
                            +cont.Tp_nombre+"</option>");
                        }
                    %>
                </select>
            </td>
        </tr>
        <tr>
            <td><label>Fecha inicio:</label></td>
            <td><input type="date" name="dtFechaIni"/></td>
        </tr>
        <tr>
            <td><label>Fecha termino:</label></td>
            <td><input type="date" name="dtFechaFin"/></td>
        </tr>
        <tr>
            <td></td>
            <td><input type="submit" value="Crear permiso"/></td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
