<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="solicitarCambio.aspx.cs" Inherits="gestorHorarios.vista.solicitarCambio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" method="post" action="../controlador/controladorSolic.aspx">
    <table align="center" border="2">
        <tr>
            <td><label>Ingresar fecha cambio</label></td>
            <td><input type="date" name="fechaCambio"</td>
        </tr>
        <tr>
            <td></td>
            <td><input type="submit" value="Enviar solicitud"</td>
        </tr>
    </table>
    </form>
</body>
</html>
