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
            string ape = Request["txtApellido"];
            string user = nom[0] + ape;
            user = user.ToLower();
            string area = Request["selArea"];
            string grado = Request["txtGrado"];
            DateTime fechaIng = DateTime.Parse(Request["dateFechaIng"]);

            
            Trabajador tra = new Trabajador();
            tra.Tra_rut = rut;
            tra.Tra_nom = nom + ape;
            tra.Tra_user = user;
            tra.Tra_area = area;
            tra.Tra_fecha_ing = fechaIng;

            if (validaRut(rut) == true)
            {
                if (tra.registraTrabajador(tra) == true)
                {
                    Session["mensaje"] = "Registro completado";
                    Response.Redirect("../vista/registrarTrabajador.aspx");
                }
                else
                {
                    Session["mensaje"] = "Registro fallido";
                    Response.Redirect("../vista/registrarTrabajador.aspx");
                }
            }
            else
            {
                Session["mensaje"] = "Rut no válido";
                Response.Redirect("../vista/registrarTrabajador.aspx");
            }
        }

        private bool validaRut(string rut)
        {
            bool ok = false;

            string rutC = rut;

            rutC = rutC.ToUpper();
            rutC = rutC.Replace(".", "");
            rutC = rutC.Replace("-", "");
            int rutAux = int.Parse(rutC.Substring(0, rutC.Length - 1));
            char dv = char.Parse(rutC.Substring(rutC.Length - 1, 1));

            int m = 0;
            int s = 1;
            for (; rutAux != 0; rutAux /= 10)
            {
                s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
            }
            if (dv == (char)(s != 0 ? s + 47 : 75))
            {
                ok = true;
            }
            else
            {
                ok = false;
            }
            return ok;
        }
    }
}