using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gestorHorarios.modelo;

namespace gestorHorarios.controlador
{
    public partial class ctrlPermiso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string f = Request["f"];

            if (f == "del")
            {
                int id = Convert.ToInt32(Request["id"]);
                PermisoTrabajo pt = new PermisoTrabajo();
                pt.Pt_id_permiso = id;
                if (pt.eliminaPermiso(pt) == true)
                {
                    Session["mensaje"] = "permiso eliminado";
                    Response.Redirect("../vista/listaPermisos.aspx");
                }

            }
            else
            {
                string rutT = Request["txtRut"];
                int tipoPer = Convert.ToInt32(Request["selTP"]);
                DateTime fechaIni = DateTime.Parse(Request["dtFechaIni"]);
                DateTime fechaFin = DateTime.Parse(Request["dtFechaFin"]);
                string rutEncargado = "12345678-9";

                PermisoTrabajo pt = new PermisoTrabajo();
                pt.Pt_fecha_inicio = fechaIni;
                pt.Pt_id_tipo_permiso = tipoPer;
                pt.Pt_rut_trabajador = rutT;
                pt.Pt_rut_encargado = rutEncargado;
                pt.Pt_fecha_termino = fechaFin;

                if (pt.creaPermiso(pt) == true)
                {
                    Session["mensaje"] = "Permiso creado";
                    Response.Redirect("../vista/listaPermisos.aspx");
                }
                else
                {
                    Session["mensaje"] = "Error al crear permiso";
                    Response.Redirect("../vista/creaPermiso.aspx");
                }
            }
        }

        
    }
}