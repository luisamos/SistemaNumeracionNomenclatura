using System;
using System.Linq;
using System.Data;

namespace Componentes
{
    /// <summary>
    /// Clase: Usos 
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    public class cUsos : cSubFicha
    {
        string sub_codigo;
        /// <summary>
        /// Sub_Codigo
        /// </summary>
        public string Sub_codigo
        {
            get { return sub_codigo; }
            set { sub_codigo = value; }
        }

        #region Propiedades
       

        /* lista de usos para fichas*/

        /// <summary>
        /// listar los usos
        /// </summary>
        /// <returns></returns>
        /// 

        public FICHA_ds listar()
        {
            try
            {
                tabla = server.ejecutar_vs("VS_LISTAR_USOS", tabla);
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar, Usos. ", ex);
            }
            return tabla;
        }

        /// <summary>
        /// LISTAR USOS
        /// </summary>
        /// <returns></returns>


        public FICHA_ds listar1()
        {
            try
            {
                tabla = server.ejecutar_vs("VS_LISTAR_USO_CODIGO ", tabla);
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar, Usos. ", ex);
            }
            return tabla;
        }
        /// <summary>
        /// listar usos para la tabla usos
        /// </summary>
        /// <returns></returns>


        public FICHA_ds listar_uso()
        {
            try
            {
                tabla = server.ejecutar_vs("VS_LISTAR_USOS", tabla);
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar, Usos. ", ex);
            }
            return tabla;
        }

        /// <summary>
        /// listar uso 1
        /// </summary>
        /// <returns></returns>
         public FICHA_ds listar_uso1()
        {
            try
            {
                tabla = server.ejecutar_vs("VS_LISTAR_USO_CODIGO", tabla);
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar, Usos. ", ex);
            }
            return tabla;
        }
        /// <summary>
        /// Lista todos los datos en formato de arreglo unidimencional 
        /// </summary>        
        /// <returns>Un arreglo de datos</returns>
        /// 
        public string[] listar_arreglo()
        {
            string[] arreglo = null;
            try
            {
                if (tabla.VS_LISTAR_USO_CODIGO.Rows.Count == 0) listar();
                arreglo = tabla.VS_LISTAR_USOS.Select(a => a.LISTA).ToArray();                
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar Arreglo, Usos.",ex);
            }
            return arreglo;
        }

        /// <summary>
        /// LISTAR ARREGLO1
        /// </summary>
        /// <returns></returns>
        
       public string[] listar_arreglo1()
        {
            string[] arreglo = null;
            try
            {
                if (tabla.VS_LISTAR_USO_CODIGO.Rows.Count == 0) listar1();
                arreglo = tabla.VS_LISTAR_USO_CODIGO.Select(a => a.LISTA).ToArray();                
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar Arreglo, Usos.",ex);
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
                if (tabla.VS_LISTAR_USO_CODIGO.Rows.Count == 0) listar();
                valor = (tabla.VS_LISTAR_USO_CODIGO.FindByCODIGO(elemento) != null) ? true : false;                
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Buscar, Usos.",ex);
            }
            return valor;
        }

        /// <summary>
        /// Busca un registro especificado
        /// </summary>
        /// <param name="elemento">El código del elemento a buscar</param>
        /// <returns>Si existe en la tabla</returns>
        public DataRow Buscar(string elemento)
        {
            DataRow filas = null;
            try
            {
                if (tabla.VS_LISTAR_USO_CODIGO.Rows.Count == 0) listar();
                filas = tabla.VS_LISTAR_USO_CODIGO.Rows.Find(elemento);
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Buscar, Usos.",ex);
            }
            return filas;
        } 

        /// <summary>
        /// guardar
        /// </summary>
        /// <returns></returns>
        public int guardar()
        {
            try
            {
                i = server.ejecutar("GUARDAR_USO_CODIGO",
                    server.parametro("@CODIGO", SqlDbType.VarChar, 6, Codigo),
                    server.parametro("@DESCRIPCION", SqlDbType.VarChar, 50, Descripcion),
                    server.parametro("@SUB_CODIGO", SqlDbType.VarChar, 4, Sub_codigo),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Guardar, Usos. ", ex);
            }
            return i;
        }

        /// <summary>
            /// modificar usos
            /// </summary>
            /// <returns></returns>
        public int modificar()
        {
            try
            {
                i = server.ejecutar("MODIFICAR_USO_CODIGO",
                    server.parametro("@CODIGO", SqlDbType.VarChar, 6, Codigo),
                    server.parametro("@DESCRIPCION", SqlDbType.VarChar, 50, Descripcion),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Modificar, Usos. ", ex);
            }
            return i;
        }

        /// <summary>
        /// eliminar los usos
        /// </summary>
        /// <returns></returns>
        public int eliminar()
        {
            try
            {
                i = server.ejecutar("ELIMINAR_USO_CODIGO",
                    server.parametro("@CODIGO", SqlDbType.VarChar, 6, Codigo),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Eliminar, Usos. ", ex);
            }
            return i;
        }

        #endregion
    }
}
