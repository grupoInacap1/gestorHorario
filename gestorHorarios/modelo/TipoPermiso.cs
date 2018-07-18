using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using gestorHorarios.conex;

namespace gestorHorarios.modelo
{
    public class TipoPermiso
    {
        private SqlCommand com;
        private SqlDataReader dr;
        private List<TipoPermiso> listaTP;
        Conexion con;

        private int tp_id_tipo_permiso;

        public int Tp_id_tipo_permiso
        {
            get { return tp_id_tipo_permiso; }
            set { tp_id_tipo_permiso = value; }
        }
        private string tp_nombre;

        public string Tp_nombre
        {
            get { return tp_nombre; }
            set { tp_nombre = value; }
        }

        public TipoPermiso() { }

        public List<TipoPermiso> cargaTP()
        {
            listaTP = new List<TipoPermiso>();
            con = Conexion.Instance();
            try
            {
                con.abrirConex();
                com = new SqlCommand("SELECT * FROM tipo_permisos");
                com.Connection = con.permitirConexion();
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    TipoPermiso tp = new TipoPermiso();
                    tp.Tp_id_tipo_permiso = Convert.ToInt32(dr[0].ToString());
                    tp.Tp_nombre = dr[1].ToString();
                    listaTP.Add(tp);
                }
            }
            catch (Exception ex) { }
            finally { con.cerrarConex(); }
            return listaTP;
        }
    }
}