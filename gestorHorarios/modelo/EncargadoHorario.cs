using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using gestorHorarios.conex;

namespace gestorHorarios.modelo
{
    public class EncargadoHorario
    {
        Conexion con;
        private SqlCommand com;
        private SqlDataReader dr;
        private bool ok;

        private string eh_rut;

        public string Eh_rut
        {
            get { return eh_rut; }
            set { eh_rut = value; }
        }
        private string eh_nombre;

        public string Eh_nombre
        {
            get { return eh_nombre; }
            set { eh_nombre = value; }
        }
        private string eh_usuario;

        public string Eh_usuario
        {
            get { return eh_usuario; }
            set { eh_usuario = value; }
        }
        private string eh_clave;

        public string Eh_clave
        {
            get { return eh_clave; }
            set { eh_clave = value; }
        }

        public EncargadoHorario() { }

        public bool loginUsuario(EncargadoHorario eh)
        {
            ok = false;
            con = Conexion.Instance();
            try
            {
                con.abrirConex();
                com = new SqlCommand("SELECT * FROM encargado_horarios WHERE eh_usuario ='" + eh.Eh_usuario + "' AND eh_clave='" + eh.Eh_clave + "'");
                com.Connection = con.permitirConexion();
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    EncargadoHorario e_h = new EncargadoHorario();
                    e_h.Eh_rut = dr[0].ToString();
                    e_h.Eh_nombre = dr[1].ToString();
                    e_h.Eh_usuario = dr[2].ToString();
                    e_h.Eh_clave = dr[3].ToString();
                    ok = true;
                }
            }
            catch (Exception ex) { }
            finally { con.cerrarConex(); }
            return ok;
        }
    }
}