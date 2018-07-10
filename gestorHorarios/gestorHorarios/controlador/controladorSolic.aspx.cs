using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gestorHorarios.modelo;

namespace gestorHorarios.controlador
{
    public partial class controladorSolic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Se recibe el valor de la fecha de cambio del trabajador
            String fechaC = Request["fechaCambio"].ToString();

            //Se llama a la clase para instanciar el metodo ingresarSolicitud
            SolicitudCambioTurno sct = new SolicitudCambioTurno();
            //booleano para confirmar que se registro correctamente en la bd, enviando el valor de la fecha
            bool ok = sct.ingresarSolicitud(DateTime.Parse(fechaC));

            //Si el registro fue correcto se envia al home del usuario con un mensaje de aprobacion
            if (ok == true)
            {
                Session["mensaje"] = "Solicitud enviada";
                Response.Redirect("../vista/homeTrabajador.aspx");
            }
            //de lo contrario vuelve al menu anterior con un mensaje de error
            else
            {
                Session["mensaje"] = "Error al enviar solicitud";
                Response.Redirect("../vista/homeTrabajador.aspx");   
            }

        }
    }
}