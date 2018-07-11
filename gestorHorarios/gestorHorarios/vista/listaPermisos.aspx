<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="listaPermisos.aspx.cs" Inherits="gestorHorarios.vista.listaPermisos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="../css/listaPermisos.css"/>
    <title></title>
</head>
<body>
    <header>
        <a href="homeEncargado.aspx">Volver</a>
    </header>
    <form id="form1" runat="server">
    <table align="center" border="2">
        <tr>
            <td>
                <label>Rut trabajador</label>
            </td>
            <td>
                <label>Tipo Permiso</label>
            </td>
            <td>
                <label>Fecha inicio</label>
            </td>
            <td>
                <label>Fecha termino</label>
            </td>
            <td>
                <label>Modificar</label>
            </td>
            <td>
                <label>Eliminar</label>
            </td>
        </tr>
            <%
                List<gestorHorarios.modelo.PermisoTrabajo> listaPT = new List<gestorHorarios.modelo.PermisoTrabajo>();
                gestorHorarios.modelo.PermisoTrabajo pt = new gestorHorarios.modelo.PermisoTrabajo();
                listaPT = pt.cargaPermisos();
                foreach (gestorHorarios.modelo.PermisoTrabajo cont in listaPT)
                {
                    
                    Response.Write("<tr><td><input type='text' readonly='' value='"+cont.Pt_rut_trabajador+"'/></td>"
                        + "<td><input type='text' readonly='' value='" + cont.Pt_id_tipo_permiso+ "'/></td>"
                        + "<td>"+
                        "<input type='text' value='"+cont.Pt_fecha_inicio.ToShortDateString()+"'/></td>"
                        + "<td><input type='text'  value='" + cont.Pt_fecha_termino.ToShortDateString() + "'/></td>"
                        + "<td><a href='#'>Modificar</a></td>"
                        + "<td><a href='../controlador/ctrlPermiso.aspx?id="+cont.Pt_id_permiso+"&f=del'>Eliminar</a></td></tr>");
                }
                    
            %>
    </table>
        <table>
            <tr></tr>
        </table>
    </form>
</body>
</html>
