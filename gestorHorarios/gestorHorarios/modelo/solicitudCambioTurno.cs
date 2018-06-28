using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Sql;
using gestorHorarios.conex;

namespace gestorHorarios.modelo
{
    public class solicitudCambioTurno
    {
        public DateTime fechaCambio; //parametro de la fecha de cambio
        private bool ok; //booleano de confirmación de registro
        private SqlCommand comnd; //se crea el parametro de comando sql

        public DateTime FechaCambio
        {
            get { return fechaCambio; }
            set { fechaCambio = value; }
        }

        public solicitudCambioTurno()
        {
        }

        public Boolean ingresarSolicitud(DateTime fechaCambio)
        {
            ok = false;
            Conexion con = Conexion.Instance(); //se crea la instancia de la conexion
            try
            {
                con.abrirConex(); //abre la conexion con el servidor de bd
                comnd = new SqlCommand("INSERT INTO solicitudCambioTurno "+
                    "(fecha_cambio, rut_trabajador) values "+
                    "('" + fechaCambio + "', '19561999-9')");

                comnd.Connection = con.permitirConexion();
                //se ejecuta el comando, si el resultado es mayor a 0 es porque el comando
                //se ejecuto correctamente, de lo contrario envia un error de ejecución
                if (comnd.ExecuteNonQuery() > 0)
                {
                    ok = true;
                }
            }
            catch (Exception ex) { }
            finally //cierra la conexion al ejecutar el comando
            {
                con.cerrarConex();
            }
            return ok;//devuelve el valor booleano con 'true' (visto bueno)
        }
        
    }
}