using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gestorHorarios.modelo;

namespace gestorHorarios.controlador
{
    public partial class ctrlLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string user = Request["txtuser"]; 
            string clave = Request["txtpass"];

            trabajador tra = new trabajador();
            tra.Tra_user = user;
            tra.Tra_clave = clave;

            if (tra.loginUsuario(tra) == true)
            {
                Session["mensaje"] = "";
                Response.Redirect("../vista/homeTrabajador.aspx");

            }
            else {

                EncargadoHorario eh = new EncargadoHorario();
                eh.Eh_usuario = user;
                eh.Eh_clave = clave;

                if (eh.loginUsuario(eh) == true)
                {
                    Session["mensaje"] = "";
                    Response.Redirect("../vista/homeEncargado.aspx");

                }
                else {
                    Session["mensaje"] = "Usuario o clave incorrectos";
                    Response.Redirect("../vista/login.aspx");
                
                }
            }

        }
    }
}