using System;
using System.Data;

namespace Componentes
{
    /// <summary>
    /// Clase: Ficha Catastral Específica
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    public class cFicha_Catastral_Especifica : cFicha
    {
        #region Atributos y Propiedades
        string sector;

        /// <summary>
        /// Sector
        /// </summary>
        public string Sector
        {
            get { return sector; }
            set { sector = value; }
        }
        cVias vias;

        /// <summary>
        /// Clase: Vías
        /// </summary>
        public cVias Vias
        {
            get { return vias; }
            set { vias = value; }
        }
        string cuadra;

        /// <summary>
        /// Cuadra
        /// </summary>
        public string Cuadra
        {
            get { return cuadra; }
            set { cuadra = value; }
        }
        string manzana;

        /// <summary>
        /// Manzana
        /// </summary>
        public string Manzana
        {
            get { return manzana; }
            set { manzana = value; }
        }
        string lote;

        /// <summary>
        /// Lote
        /// </summary>
        public string Lote
        {
            get { return lote; }
            set { lote = value; }
        }        
        #endregion

        #region Metodos
        /// <summary>
        /// Asinga un Código Nuevo 
        /// </summary>
        /// <returns>El Código Siguiente de la Ficha Especificada</returns>
        public string nuevo_codigo()
        {
            string c = "";
            try
            {
                c = server.ejecutar_sp("GENERAR_SIGUIENTE_CODIGO",
                    server.parametro("@DOCUMENTO", SqlDbType.VarChar, 20, "ESPECIFICA"),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, "ADMIN")).ToString();
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Nuevo Código, Ficha Catastral de Específica.", ex);
            }
            return c;
        }

        /// <summary>
        /// Lista todos los registros
        /// </summary>
        /// <returns>Un conjunto de datos</returns>
        public FICHA_ds listar()
        {
            try
            {
                tabla = server.ejecutar_vs("VS_LISTAR_FICHA_CATASTRAL_ESPECIFICA", tabla, "NUMERO DE FICHA", true);
                tabla = server.ejecutar_vs("VS_LISTAR_FICHA_CATASTRAL_ESPECIFICA_USO_RESALTANTE", tabla);
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar, Ficha Catastral Específica. ", ex);
            }
            return tabla;
        }
        
        /// <summary>
        /// Guarda un Registro
        /// </summary>
        /// <returns>El número de Filas Afectadas</returns>
        public int guardar()
        {
            try
            {
                i = server.ejecutar("GUARDAR_FICHA_CATASTRAL_ESPECIFICA",
                    server.parametro("@FICHA", SqlDbType.VarChar, 10, Ficha),
                    server.parametro("@PARCIAL_FICHAS", SqlDbType.BigInt, Parcial_Ficha),
                    server.parametro("@TOTAL_FICHAS", SqlDbType.Int, Total_Fichas),
                    server.parametro("@DEPARTAMENTO", SqlDbType.VarChar, 2, Departamento),
                    server.parametro("@PROVINCIA", SqlDbType.VarChar, 2, Provincia),
                    server.parametro("@DISTRITO", SqlDbType.VarChar, 2, Distrito),
                    server.parametro("@SECTOR", SqlDbType.VarChar, 2, Sector),
                    server.parametro("@CODIGO_VIA", SqlDbType.VarChar, 3, Vias.Codigo),
                    server.parametro("@CUADRA", SqlDbType.VarChar, 2, Cuadra),
                    server.parametro("@MANZANA", SqlDbType.VarChar, 3, Manzana),
                    server.parametro("@LOTE", SqlDbType.VarChar, 3, Lote),
                    server.parametro("@OBSERVACIONES", SqlDbType.Text, Observaciones),
                    server.parametro("@ESTADO_LLENADO_FICHA", SqlDbType.VarChar, 2, Estado_Llenado_Ficha.Codigo),
                    server.parametro("@SUPERVISOR", SqlDbType.VarChar, 8, Supervisor.DNI),
                    server.parametro("@FECHA_SUPERVISOR", SqlDbType.DateTime, Fecha_Supervisor),
                    server.parametro("@TECNICO_CATASTRAL", SqlDbType.VarChar, 8, Tecnico_Catastral.DNI),
                    server.parametro("@FECHA_TECNICO_CATASTRAL", SqlDbType.DateTime, Fecha_Tecnico_Catastral),
                    server.parametro("@VB_DIGITACION", SqlDbType.VarChar, 8, Digitacion.DNI),
                    server.parametro("@FECHA_VB_DIGITACION", SqlDbType.DateTime, Fecha_Digitacion),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Guardar, Ficha Catastral de Específica. ", ex);
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
                i = server.ejecutar("MODIFICAR_FICHA_CATASTRAL_ESPECIFICA",
                    server.parametro("@FICHA", SqlDbType.VarChar, 10, Ficha),
                    server.parametro("@PARCIAL_FICHAS", SqlDbType.BigInt, Parcial_Ficha),
                    server.parametro("@TOTAL_FICHAS", SqlDbType.Int, Total_Fichas),
                    server.parametro("@DEPARTAMENTO", SqlDbType.VarChar, 2, Departamento),
                    server.parametro("@PROVINCIA", SqlDbType.VarChar, 2, Provincia),
                    server.parametro("@DISTRITO", SqlDbType.VarChar, 2, Distrito),
                    server.parametro("@SECTOR", SqlDbType.VarChar, 2, Sector),
                    server.parametro("@CODIGO_VIA", SqlDbType.VarChar, 3, Vias.Codigo),
                    server.parametro("@CUADRA", SqlDbType.VarChar, 2, Cuadra),
                    server.parametro("@MANZANA", SqlDbType.VarChar, 3, Manzana),
                    server.parametro("@LOTE", SqlDbType.VarChar, 3, Lote),
                    server.parametro("@OBSERVACIONES", SqlDbType.Text, Observaciones),
                    server.parametro("@ESTADO_LLENADO_FICHA", SqlDbType.VarChar, 2, Estado_Llenado_Ficha.Codigo),
                    server.parametro("@SUPERVISOR", SqlDbType.VarChar, 8, Supervisor.DNI),
                    server.parametro("@FECHA_SUPERVISOR", SqlDbType.DateTime, Fecha_Supervisor),
                    server.parametro("@TECNICO_CATASTRAL", SqlDbType.VarChar, 8, Tecnico_Catastral.DNI),
                    server.parametro("@FECHA_TECNICO_CATASTRAL", SqlDbType.DateTime, Fecha_Tecnico_Catastral),
                    server.parametro("@VB_DIGITACION", SqlDbType.VarChar, 8, Digitacion.DNI),
                    server.parametro("@FECHA_VB_DIGITACION", SqlDbType.DateTime, Fecha_Digitacion),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Modificar, Ficha Catastral de Específica. ", ex);
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
                i = server.ejecutar("ELIMINAR_FICHA_CATASTRAL_ESPECIFICA",
                    server.parametro("@FICHA", SqlDbType.VarChar, 10, Ficha),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Eliminar, Ficha Catastral Específica. ", ex);

            }
            return i;
        }

        /// <summary>
        /// Reporte
        /// </summary>
        /// <returns>Un conjunto de datos</returns>
        public FICHA_ds reporte()
        {
            try
            {                
                tabla = server.ejecutar_vs("VS_REPORTE_FICHA_CATASTRAL_ESPECIFICA", tabla, "FICHA", true);
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Reporte, Ficha Catastral Específica.", ex);
            }
            return tabla;
        }
        #endregion
    }
}
