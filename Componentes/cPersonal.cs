using System;
using System.Linq;
using System.Data;

namespace Componentes
{
    /// <summary>
    /// Clase: Personal
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    public class cPersonal : cSubFicha
    {
        #region Atributos y Propiedades
        string dni;

        /// <summary>
        /// Documento Nacional de Identidad - DNI
        /// </summary>
        public string DNI
        {
            get { return dni; }
            set { dni = value; }
        }
        string nombre;

        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        string apellido_paterno;

        /// <summary>
        /// Apellido Paterno
        /// </summary>
        public string Apellido_Paterno
        {
            get { return apellido_paterno; }
            set { apellido_paterno = value; }
        }
        string apellido_materno;

        /// <summary>
        /// Apellido Materno
        /// </summary>
        public string Apellido_Materno
        {
            get { return apellido_materno; }
            set { apellido_materno = value; }
        }
        string cargo;

        /// <summary>
        /// Cargo
        /// </summary>
        public string Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        /// <summary>
        /// DNI del Supervisor
        /// </summary>
        public static string DNI_Supervisor
        {
            get { return retornar("Supervisor"); }
            set { asignar("Supervisor",value); }
        }

        /// <summary>
        /// DNI del Técnico Catastral
        /// </summary>
        public static string DNI_Tecnico_Catastral
        {
            get { return retornar("TecnicoCatastral"); }
            set { asignar("TecnicoCatastral",value); }
        }

        /// <summary>
        /// DNI de Digitación
        /// </summary>
        public static string DNI_Digitacion
        {
            get { return retornar("Digitacion"); }
            set { asignar("Digitacion",value); }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Lista todos los registros
        /// </summary>
        /// <returns>Un conjunto de datos</returns>
        public FICHA_ds listar()
        {
            try
            {
                tabla = server.ejecutar_vs("VS_LISTAR_PERSONAL",tabla);
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar, Personal. ",ex);
            }
            return tabla;
        }

        /// <summary>
        /// Guardar un Registro
        /// </summary>
        /// <returns>El número de filas Afectadas</returns>
        public int guardar()
        {
            try
            {
                i = server.ejecutar("GUARDAR_PERSONAL",
                    server.parametro("@DNI", SqlDbType.VarChar, 8, DNI),
                    server.parametro("@APATERNO", SqlDbType.VarChar, 50, apellido_paterno),
                    server.parametro("@AMATERNO", SqlDbType.VarChar, 50, apellido_materno),
                    server.parametro("@NOMBRE", SqlDbType.VarChar, 50, nombre),
                    server.parametro("@CARGO", SqlDbType.VarChar, 20, cargo),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Guardar, Personal. ",ex);
            }
            return i;
        }

        /// <summary>
        /// Modifica un Registro
        /// </summary>
        /// <returns>El número de filas Afectadas</returns>
        public int modificar()
        {
            try
            {
                i = server.ejecutar("MODIFICAR_PERSONAL",
                    server.parametro("@DNI", SqlDbType.VarChar, 8, DNI),
                    server.parametro("@NOMBRE", SqlDbType.VarChar, 50, nombre),
                    server.parametro("@APATERNO", SqlDbType.VarChar, 50, apellido_paterno),
                    server.parametro("@AMATERNO", SqlDbType.VarChar, 50, apellido_materno),
                    server.parametro("@CARGO", SqlDbType.VarChar, 20, cargo),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Modificar, Personal. ",ex);
            }
            return i;
        }

        /// <summary>
        /// Elimina un Registro
        /// </summary>
        /// <returns>El número de filas Afectadas</returns>
        public int eliminar()
        {
            try
            {
                i = server.ejecutar("ELIMINAR_PERSONAL",
                    server.parametro("@DNI", SqlDbType.VarChar, 8, DNI),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Eliminar, Personal. ",ex);
            }
            return i;
        }

        /// <summary>
        /// Listar todos los Supervisores
        /// </summary>
        /// <returns>Un conjunto de Datos</returns>
        public object listar_arreglo_supervisor()
        {
            object arreglo = null;
            try
            {
                if (tabla.VS_LISTAR_PERSONAL.Rows.Count == 0) listar();
                var x = from DataRow i in tabla.VS_LISTAR_PERSONAL.Rows
                        where i["CARGO"].Equals("SUPERVISOR")
                        select new { ApellidosNombres = i["LISTA"].ToString().Substring(11), DNI = i["DNI"].ToString()};
            arreglo= x.ToArray();
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar Arreglo, Personal - Supervisor. ",ex);
            }
            return arreglo;
        }

        /// <summary>
        /// Lista todos los Técnicos Catastrales
        /// </summary>
        /// <returns>Un conjunto de Datos</returns>
        public object listar_arreglo_tecnico_catastral()
        {
            object arreglo = null;
            try
            {
                if (tabla.VS_LISTAR_PERSONAL.Rows.Count == 0) listar();
                var x = from DataRow i in tabla.VS_LISTAR_PERSONAL.Rows
                        where i["CARGO"].Equals("TECNICO CATASTRAL")
                        select new { ApellidosNombres = i["LISTA"].ToString().Substring(11), DNI = i["DNI"].ToString() };
                arreglo = x.ToArray();
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar Arreglo, Personal - Técnico Catastral. ",ex);
            }
            return arreglo;
        }

        /// <summary>
        /// Lista todos los VB Digitadores
        /// </summary>
        /// <returns>Un conjunto de Datos</returns>
        public object listar_arreglo_digitacion()
        {
            object arreglo = null;
            try
            {
                if (tabla.VS_LISTAR_PERSONAL.Rows.Count == 0) listar();
                var x = from DataRow i in tabla.VS_LISTAR_PERSONAL.Rows
                        where i["CARGO"].Equals("DIGITACION")
                        select new { ApellidosNombres = i["LISTA"].ToString().Substring(11), DNI = i["DNI"].ToString() };
                arreglo = x.ToArray();
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar Arreglo, Personal - Digitación. ",ex);
            }
            return arreglo;
        }        
        #endregion
    }
}
