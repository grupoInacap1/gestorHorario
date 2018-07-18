using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

namespace gestorHorarios.conex
{
    public class Conexion
    {
        private SqlConnection con;
        private static Conexion instance;

        private Conexion()
        {
            con = new SqlConnection("Data Source=DESKTOP-OSST4FT\\SQLEXPRESS;Initial Catalog=gestorHorarios;Integrated Security=True");

        }

        public static Conexion Instance()
        {
            if (instance == null)
                instance = new Conexion();
            return instance;
        }

        public void abrirConex()
        {
            con.Open();
        }

        public void cerrarConex()
        {
            con.Close();
        }
        public SqlConnection permitirConexion()
        {
            return con;
        }

    }
}