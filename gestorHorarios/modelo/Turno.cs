using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using gestorHorarios.conex;

namespace gestorHorarios.modelo
{
    public class Turno
    {
        private SqlCommand com;
        private SqlDataReader dr;
        private bool ok;
        private List<Turno> listaTurno;
        Conexion con;

        private int tur_id_turno;
        private string tur_fecha;

        public string Tur_fecha
        {
            get { return tur_fecha; }
            set { tur_fecha = value; }
        }
        private string tur_hora_ingreso;

        public string Tur_hora_ingreso
        {
            get { return tur_hora_ingreso; }
            set { tur_hora_ingreso = value; }
        }
        private string tur_hora_salida;

        public string Tur_hora_salida
        {
            get { return tur_hora_salida; }
            set { tur_hora_salida = value; }
        }
        private string tur_rut_trabajador;

        public string Tur_rut_trabajador
        {
            get { return tur_rut_trabajador; }
            set { tur_rut_trabajador = value; }
        }

        public Turno() { }

        public bool crearTurno(Turno tur)
        {
            ok = false;
            con = Conexion.Instance();
            try
            {
                con.abrirConex();
                com = new SqlCommand("INSERT INTO turno (tur_fecha, tur_hora_ingreso, tur_hora_salida, tur_rut_trabajador)" +
                    " VALUES('" + tur.Tur_fecha + "', '" + tur.Tur_hora_ingreso + "', '" + tur.Tur_hora_salida + "', '" + tur.Tur_rut_trabajador + "')");
                com.Connection = con.permitirConexion();
                if (com.ExecuteNonQuery() < 0)
                {
                    ok = true;
                }
            }
            catch (Exception ex) { }
            finally { con.cerrarConex(); }
            return ok;
        }

        public List<Turno> listaTurnoTra(Turno tur)
        {
            listaTurno = new List<Turno>();
            con = Conexion.Instance();
            try
            {
                con.abrirConex();
                com = new SqlCommand("SELECT * FROM turno WHERE tur_rut_trabajador='" + tur.Tur_rut_trabajador + "'");
                com.Connection = con.permitirConexion();
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    Turno tur2 = new Turno();
                    tur2.Tur_fecha = dr[1].ToString();
                    tur2.Tur_hora_ingreso = dr[2].ToString();
                    tur2.Tur_hora_salida = dr[3].ToString();
                    tur2.Tur_rut_trabajador = dr[4].ToString();
                    listaTurno.Add(tur2);
                }
            }
            catch (Exception ex) { }
            finally { con.cerrarConex(); }
            return listaTurno;
        }
    }
}