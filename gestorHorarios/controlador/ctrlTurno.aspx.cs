using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gestorHorarios.modelo;

namespace gestorHorarios.controlador
{
    public partial class ctrlTurno : System.Web.UI.Page
    {

        Trabajador tra;
        Turno tur;
        PermisoTrabajo pt;
        private List<Trabajador> listaRut;
        private List<PermisoTrabajo> listaPT2;
        private int hrs;

        protected void Page_Load(object sender, EventArgs e)
        {
            //obtener rut Trabajadores
            tra = new Trabajador();
            listaRut = new List<Trabajador>();
            listaRut = tra.obtenerRuts();

            int dia = DateTime.Today.Day;
            int dia2 = DateTime.Today.Day;
            int mes = DateTime.Today.Month;
            int anio = DateTime.Today.Year;

            foreach (Trabajador tra2 in listaRut)
            {
                //realizar accion por cada rut

                //ver si el trabajador posee permisos

                //pt = new PermisoTrabajo();
                //listaPT2 = new List<PermisoTrabajo>();
                //listaPT2 = pt.ultimoPermiso(tra2.Tra_rut);
                /*if(listaPT2 != null)
                {
                    foreach(PermisoTrabajo pt2 in listaPT2)
                    {
                        if(pt2.Pt_fecha_inicio == pt2.Pt_fecha_termino)
                        {

                        }
                        else if()
                        {
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            if (hrs < 45)
                            {
                                tur = new Turno();
                                tur.Tur_fecha = dia + "-" + mes + "-" + anio;
                                tur.Tur_hora_ingreso = "9:00";
                                tur.Tur_hora_salida = "18:00";
                                tur.Tur_rut_trabajador = tra2.Tra_rut;
                                tur.crearTurno(tur);
                                dia += 1;
                                hrs += 9;
                            }
                        }
                    }
                }
                else
                {*/
                    for (int i = 0; i < 7; i++)
                    {
                        if (hrs < 45)
                        {
                            tur = new Turno();
                            tur.Tur_fecha = dia + "-" + mes + "-" + anio;
                            tur.Tur_hora_ingreso = "9:00";
                            tur.Tur_hora_salida = "18:00";
                            tur.Tur_rut_trabajador = tra2.Tra_rut;
                            tur.crearTurno(tur);
                            dia += 1;
                            hrs += 9;
                        }
                    }
                    hrs = 0;
                    dia = DateTime.Today.Day;
                }
                
            //}
            Session["mensaje"] = "Horario creado, fecha '" + dia + "-" + mes + "-" + anio+"'";
            Response.Redirect("../vista/creaHorario.aspx");
            /*for (int i = 0; i < 1; i++)
            {
                for (int j = 0; i < 7; )
                {
                    if(hrs < 45)
                    {
                        tur = new Turno();
                        tur.Tur_fecha = dia + "-" + mes + "-" + anio;
                        tur.Tur_hora_ingreso = "9:00";
                        tur.Tur_hora_salida = "18:00";
                        tur.Tur_rut_trabajador = "19561999-9";
                        tur.crearTurno(tur);
                        j++;
                        dia += 1;
                        hrs += 9;
                    }
                }
            }*/
        }
    }
}