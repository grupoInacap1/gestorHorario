<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="verHorario.aspx.cs" Inherits="gestorHorarios.vista.verHorario" %>

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
        <a align="left" href="login.aspx">Cerrar Sesión</a>
        <a align="left" href="homeTrabajador.aspx">Volver</a>
    </header>
    <form id="form1" runat="server">
        <table align="center" border="1">
            <tr>
                <td>Rut trabajador</td>
                <td>Fecha</td>
                <td>Hora Inicio</td>
                <td>Hora Fin</td>
            </tr>
        
        <%
            List<gestorHorarios.modelo.Turno> listaTurno = new List<gestorHorarios.modelo.Turno>();
            gestorHorarios.modelo.Turno tur = new gestorHorarios.modelo.Turno();
            string rut = Convert.ToString(Session["rut"]);
            tur.Tur_rut_trabajador = rut;
            listaTurno = tur.listaTurnoTra(tur);
            Response.Write("<tr>");
            foreach (gestorHorarios.modelo.Turno cont in listaTurno)
            {
                
                Response.Write("<td><label>"+cont.Tur_rut_trabajador+"</labe></td>"+
                    "<td><label>"+cont.Tur_fecha+"</labe></td>"+
                    "<td><label>" + cont.Tur_hora_ingreso+ "</labe></td>" +
                    "<td><label>" + cont.Tur_hora_salida + "</labe></td>" +
                    "</tr>");
            }
        %>
        </table>
    </form>
</body>
</html>
