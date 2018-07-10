using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using gestorHorarios.conex;

namespace gestorHorarios.modelo
{
    public class PermisoTrabajo
    {
        private SqlCommand com;
        private bool ok;
        Conexion con;

        private DateTime pt_fecha_inicio;

        public DateTime Pt_fecha_inicio
        {
            get { return pt_fecha_inicio; }
            set { pt_fecha_inicio = value; }
        }
        private int pt_id_tipo_permiso;

        public int Pt_id_tipo_permiso
        {
            get { return pt_id_tipo_permiso; }
            set { pt_id_tipo_permiso = value; }
        }
        private string pt_rut_trabajador;

        public string Pt_rut_trabajador
        {
            get { return pt_rut_trabajador; }
            set { pt_rut_trabajador = value; }
        }
        private string pt_rut_encargado;

        public string Pt_rut_encargado
        {
            get { return pt_rut_encargado; }
            set { pt_rut_encargado = value; }
        }
        private DateTime pt_fecha_termino;

        public DateTime Pt_fecha_termino
        {
            get { return pt_fecha_termino; }
            set { pt_fecha_termino = value; }
        }

        public PermisoTrabajo() { }

        public bool creaPermiso(PermisoTrabajo pt)
        {
            ok = false;
            con = Conexion.Instance();
            try
            {
                con.abrirConex();
                com = new SqlCommand("INSERT INTO permiso_trabajo (pt_fecha_permiso, " +
                    "pt_id_tipo_permiso, pt_rut_trabajador, pt_rut_encargado, pt_fecha_termino)" +
                "VALUES ('" + pt.Pt_fecha_inicio + "', " + Pt_id_tipo_permiso + ", '" + Pt_rut_trabajador
                + "', '" + Pt_rut_encargado + "', '" + Pt_fecha_termino + "')");
                com.Connection = con.permitirConexion();
                if (com.ExecuteNonQuery() > 0)
                {
                    ok = true;
                }
            }
            catch (Exception ex) { }
            finally { con.cerrarConex(); }
            return ok;
        }
    }
}