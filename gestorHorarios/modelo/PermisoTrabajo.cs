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
        private SqlDataReader dr;
        private bool ok;
        private List<PermisoTrabajo> listaPT;
        private List<PermisoTrabajo> listaPT2;
        private List<PermisoTrabajo> listaPT3;
        Conexion con;

        private int pt_id_permiso;

        public int Pt_id_permiso
        {
            get { return pt_id_permiso; }
            set { pt_id_permiso = value; }
        }
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

        private string pt_tipo_permiso;

        public string Pt_tipo_permiso
        {
            get { return pt_tipo_permiso; }
            set { pt_tipo_permiso = value; }
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

        public List<PermisoTrabajo> buscaPermiso(string rut)
        {
            listaPT3 = new List<PermisoTrabajo>();
            con = Conexion.Instance();
            try
            {
                con.abrirConex();
                com = new SqlCommand("SELECT * FROM permiso_trabajo WHERE pt_rut_trabajador='" + rut + "'");
                com.Connection = con.permitirConexion();
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    PermisoTrabajo pt2 = new PermisoTrabajo();
                    pt2.Pt_id_permiso = Convert.ToInt32(dr[0].ToString());
                    pt2.Pt_fecha_inicio = DateTime.Parse(dr[1].ToString());
                    pt2.Pt_id_tipo_permiso = Convert.ToInt32(dr[2].ToString());
                    pt2.Pt_rut_trabajador = dr[3].ToString();
                    pt2.Pt_rut_encargado = dr[4].ToString();
                    pt2.Pt_fecha_termino = DateTime.Parse(dr[5].ToString());
                    listaPT3.Add(pt2);
                }
            }
            catch (Exception ex) { }
            finally { con.cerrarConex(); }
            return listaPT;
        }

        public List<PermisoTrabajo> cargaPermisos()
        {
            listaPT = new List<PermisoTrabajo>();
            con = Conexion.Instance();
            try
            {
                con.abrirConex();
                com = new SqlCommand("SELECT * FROM permiso_trabajo");
                com.Connection = con.permitirConexion();
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    PermisoTrabajo pt = new PermisoTrabajo();
                    pt.Pt_id_permiso = Convert.ToInt32(dr[0].ToString());
                    pt.Pt_fecha_inicio = DateTime.Parse(dr[1].ToString());
                    pt.Pt_id_tipo_permiso = Convert.ToInt32(dr[2].ToString());
                    pt.Pt_rut_trabajador = dr[3].ToString();
                    pt.Pt_rut_encargado = dr[4].ToString();
                    pt.Pt_fecha_termino = DateTime.Parse(dr[5].ToString());
                    listaPT.Add(pt);
                }
            }
            catch (Exception ex) { }
            finally { con.cerrarConex(); }
            return listaPT;
        }

        public bool eliminaPermiso(PermisoTrabajo pt)
        {
            ok = false;
            con = Conexion.Instance();
            try
            {
                con.abrirConex();
                com = new SqlCommand("DELETE FROM permiso_trabajo WHERE pt_id_permiso=" + pt.Pt_id_permiso + "");
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

        public List<PermisoTrabajo> ultimoPermiso(string rut)
        {
            listaPT2 = new List<PermisoTrabajo>();
            con = Conexion.Instance();
            string id_permiso = "";
            try
            {
                con.abrirConex();
                com = new SqlCommand("SELECT MAX(pt_id_permiso) FROM permiso_trabajo WHERE pt_rut_trabajador='" + rut + "'");
                com.Connection = con.permitirConexion();
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    id_permiso = dr[0].ToString();
                }
                com = new SqlCommand("SELECT * FROM permiso_trabajo WHERE pt_id_permiso= "+id_permiso+"");
                com.Connection = con.permitirConexion();
                dr = com.ExecuteReader();
                while(dr.Read())
                {
                    PermisoTrabajo pt2 = new PermisoTrabajo();
                    pt2.Pt_fecha_inicio = DateTime.Parse(dr[1].ToString());
                    pt2.Pt_fecha_termino = DateTime.Parse(dr[5].ToString());
                    listaPT2.Add(pt2);
                }
            }
            catch (Exception ex) { }
            finally { con.cerrarConex(); }
            return listaPT2;
        }
    }
}