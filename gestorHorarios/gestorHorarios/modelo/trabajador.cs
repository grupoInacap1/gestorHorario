﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using gestorHorarios.conex;

namespace gestorHorarios.modelo
{
    public class trabajador
    {
        private bool ok;
        private SqlCommand com;
        private SqlDataReader dr;
        Conexion con;

        private string tra_rut;
        public string Tra_rut
        {
            get { return tra_rut; }
            set { tra_rut = value; }
        }

        private string tra_nom;
        public string Tra_nom
        {
            get { return tra_nom; }
            set { tra_nom = value; }
        }
        private string tra_user;

        public string Tra_user
        {
            get { return tra_user; }
            set { tra_user = value; }
        }
        private string tra_area;

        public string Tra_area
        {
            get { return tra_area; }
            set { tra_area = value; }
        }
        private string tra_grado;

        public string Tra_grado
        {
            get { return tra_grado; }
            set { tra_grado = value; }
        }
        private string tra_fecha_ing;

        public string Tra_fecha_ing
        {
            get { return tra_fecha_ing; }
            set { tra_fecha_ing = value; }
        }
        private string tra_clave;

        public string Tra_clave
        {
            get { return tra_clave; }
            set { tra_clave = value; }
        }
        private string tra_saldo_dom;

        public string Tra_saldo_dom
        {
            get { return tra_saldo_dom; }
            set { tra_saldo_dom = value; }
        }

        public trabajador() { }

        public bool registraTrabajador(trabajador tra)
        {
            ok = false;
            con = Conexion.Instance();
            try
            {
                con.abrirConex();
                com = new SqlCommand("INSERT INTO trabajador (tra_rut_trabajador, " +
                    "tra_nombre, tra_fecha_ingreso, tra_area_trabajo, tra_saldo_domingos," +
                    "tra_usuario, tra_clave) VALUES ('" + tra.Tra_rut + "', '" + tra.Tra_nom +
                    "','09/07/2018', '" + tra.Tra_area + "', 200000,'" + tra.Tra_user +
                    "', '123456')");
                com.Connection = con.permitirConexion();
                if (com.ExecuteNonQuery() > 0)
                {
                    ok = true;
                }
            }
            catch (Exception ex) { }
            finally {con.cerrarConex();}
            return ok;
        }

        public bool loginUsuario(trabajador tra)
        {
            ok = false;
            con = Conexion.Instance();
            try
            {
                con.abrirConex();
                com = new SqlCommand("SELECT * FROM trabajador WHERE tra_usuario ='" + tra.Tra_user + "' AND tra_clave='" + tra.Tra_clave + "'");
                com.Connection = con.permitirConexion();
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    trabajador tra = new trabajador();
                    tra.Tra_rut = dr[0].ToString();
                    tra.Tra_nom = dr[1].ToString();
                    tra.Tra_fecha_ing = dr[2].ToString();
                    tra.Tra_area = dr[3].ToString();
                    tra.Tra_saldo_dom = dr[4].ToString();
                    tra.Tra_user = dr[5].ToString();
                    tra.Tra_clave = dr[6].ToString();
                    ok = true;
                }
            }
            catch (Exception ex) { }
            finally { con.cerrarConex(); }
            return ok;
        }
    }
}