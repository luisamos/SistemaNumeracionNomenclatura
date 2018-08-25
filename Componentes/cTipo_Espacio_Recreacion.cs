using System;
using System.Linq;
using System.Data;

namespace Componentes 
{
    /// <summary>
    /// Clase: Tipo de Espacio de Recreación
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    public class cTipo_Espacio_Recreacion : cSubFicha
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
                tabla = server.ejecutar_vs("VS_LISTAR_TIPO_ESPACIO_RECREACION", tabla);
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar, Tipo de Espacio de Recreación. ", ex);
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
                i = server.ejecutar("GUARDAR_TIPO_ESPACIO_RECREACION",
                    server.parametro("@CODIGO", SqlDbType.VarChar, 2, Codigo),
                    server.parametro("@DESCRIPCION", SqlDbType.VarChar, 50, Descripcion),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Guardar, Tipo de Espacio de Recreación. ", ex);
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
                i = server.ejecutar("MODIFICAR_TIPO_ESPACIO_RECREACION",
                    server.parametro("@CODIGO", SqlDbType.VarChar, 2, Codigo),
                    server.parametro("@DESCRIPCION", SqlDbType.VarChar, 50, Descripcion),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Modificar, Tipo de Espacio de Recreación. ", ex);
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
                i = server.ejecutar("ELIMINAR_TIPO_ESPACIO_RECREACION",
                    server.parametro("@CODIGO", SqlDbType.VarChar, 2, Codigo),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Eliminar, Tipo de Espacio de Recreación. ", ex);
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
                if (tabla.VS_LISTAR_TIPO_ESPACIO_RECREACION.Rows.Count == 0) listar();
                arreglo = tabla.VS_LISTAR_TIPO_ESPACIO_RECREACION.Select(a => a.LISTA).ToArray();                
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar Arreglo, Tipo de Espacio de Recreación. ", ex);
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
                if (tabla.VS_LISTAR_TIPO_ESPACIO_RECREACION.Rows.Count == 0) listar();
                valor = (tabla.VS_LISTAR_TIPO_ESPACIO_RECREACION.FindByCODIGO(elemento) != null) ? true : false;                
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Buscar, Tipo de Espacio de Recreación. ", ex);
            }
            return valor;
        }
        #endregion
    }
}
