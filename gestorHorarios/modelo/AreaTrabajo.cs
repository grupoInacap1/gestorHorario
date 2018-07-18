using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using gestorHorarios.conex;

namespace gestorHorarios.modelo
{
    public class AreaTrabajo
    {
        private SqlCommand com;
        private SqlDataReader dr;
        private List<AreaTrabajo> listaAT;
        Conexion con;

        private int at_id_area;

        public int At_id_area
        {
            get { return at_id_area; }
            set { at_id_area = value; }
        }
        private string at_nombre;

        public string At_nombre
        {
            get { return at_nombre; }
            set { at_nombre = value; }
        }
        private string at_grado_conocimiento;

        public string At_grado_conocimiento
        {
            get { return at_grado_conocimiento; }
            set { at_grado_conocimiento = value; }
        }

        public AreaTrabajo() { }

        public List<AreaTrabajo> listaAreas()
        {
            listaAT = new List<AreaTrabajo>();
            con = Conexion.Instance();
            try
            {
                con.abrirConex();
                com = new SqlCommand("SELECT * FROM area_trabajo");
                com.Connection = con.permitirConexion();
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    AreaTrabajo at = new AreaTrabajo();
                    at.At_id_area = Convert.ToInt32(dr[0].ToString());
                    at.At_nombre = dr[1].ToString();
                    at.At_grado_conocimiento = dr[2].ToString();
                    listaAT.Add(at);
                }
            }
            catch (Exception ex) { }
            finally { con.cerrarConex(); }
            return listaAT;
        }
    }
}