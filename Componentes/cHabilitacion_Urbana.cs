using System;
using System.Linq;
using System.Data;

namespace Componentes
{
    /// <summary>
    /// Clase: Habilitacion Urbana
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    public class cHabilitacion_Urbana : cSubFicha
    {
        #region Metodos
        /// <summary>
        /// Lista todos los registros
        /// </summary>
        /// <returns>Un conjunto de datos</returns>
        public FICHA_ds listar()
        {
            try
            {
                tabla = server.ejecutar_vs("VS_LISTAR_HABILITACION_URBANA",tabla);
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar, Habilitación Urbana. ", ex);
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
                i = server.ejecutar("GUARDAR_HABILITACION_URBANA",
                    server.parametro("@CODIGO", SqlDbType.VarChar, 6, Codigo),
                    server.parametro("@DESCRIPCION", SqlDbType.VarChar, 100, Descripcion),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Guardar, Habilitación Urbana. ", ex);                
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
                i = server.ejecutar("MODIFICAR_HABILITACION_URBANA",
                    server.parametro("@CODIGO", SqlDbType.VarChar, 6, Codigo),
                    server.parametro("@DESCRIPCION", SqlDbType.VarChar, 100, Descripcion),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }

            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Modificar, Habilitación Urbana. ", ex);
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
                i = server.ejecutar("ELIMINAR_HABILITACION_URBANA",
                    server.parametro("@CODIGO", SqlDbType.VarChar, 6, Codigo),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Eliminar, Habilitación Urbana. ", ex);
            }
            return i;
        }

        /// <summary>
        /// Lista todos los datos en formato de arreglo unidimencional 
        /// </summary>        
        /// <returns>Un arreglo de datos</returns>
        public string[] listar_arreglo()
        {
            string[] arreglo = null;
            try
            {
                if (tabla.VS_LISTAR_HABILITACION_URBANA.Rows.Count == 0) listar();
                arreglo = tabla.VS_LISTAR_HABILITACION_URBANA.Select(a => a.LISTA).ToArray();                
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar Arreglo, Habilitación Urbana. ", ex);
            }
            return arreglo;
        }

        /// <summary>
        /// Busca un registro especificado
        /// </summary>
        /// <param name="elemento">El código del elemento a buscar</param>
        /// <returns>Si existe en la tabla</returns>
        public bool buscar(string elemento)
        {
            bool valor = false;
            try
            {
                if (tabla.VS_LISTAR_HABILITACION_URBANA.Rows.Count == 0) listar();
                valor = (tabla.VS_LISTAR_HABILITACION_URBANA.FindByCODIGO(elemento) != null || elemento == "") ? true : false;
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Buscar, Habilitación Urbana. ", ex);
            }
            return valor;
        }

        /// <summary>
        /// Busca un registro especificado
        /// </summary>
        /// <param name="codigo">El código del elemento a buscar</param>
        /// <returns>Si existe en la tabla</returns>
        public DataRow Buscar(string codigo)
        {
            DataRow filas = null;
            try
            {
                if (tabla.VS_LISTAR_HABILITACION_URBANA.Rows.Count == 0) listar();
                filas = tabla.VS_LISTAR_HABILITACION_URBANA.Rows.Find(codigo);                
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Buscar, Habilitación Urbana. ", ex);
            }
            return filas;
        }
        #endregion
    }
}
