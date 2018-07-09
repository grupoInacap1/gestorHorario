using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gestorHorarios.modelo;

namespace gestorHorarios.controlador
{
    public partial class ctrlTrabajador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rut = Request["txtRut"];
            string nom = Request["txtNombre"];
            string user = Request["txtUser"];
            string area = Request["selArea"];
            string grado = Request["txtGrado"];

            trabajador tra = new trabajador();

            tra.Tra_rut = rut;
            tra.Tra_nom = nom;
            tra.Tra_user = user;
            tra.Tra_area = area;
            if (tra.registraTrabajador(tra) == true)
            {
                Session["mensaje"] = "Registro completado";
                Response.Redirect("../vista/registrarTrabajador.aspx");
            }
            else
            {
                Session["mensaje"] = "Registro completado";
                Response.Redirect("../vista/registrarTrabajador.aspx");
            }

        }
    }
}