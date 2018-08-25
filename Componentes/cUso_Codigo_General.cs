using System;
using System.Linq;
using System.Data;

namespace Componentes
{
    /// <summary>
    /// Clase : Uso de Codigo General
    /// Autor                   : Dunia
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    public class cUso_Codigo_General: cSubFicha
    {
       #region Metodos
     /// <summary>
     /// listar todos los registros
     /// </summary>
     /// <returns></returns>
        public FICHA_ds listar()
        {
            try
            {
                tabla = server.ejecutar_vs("VS_LISTAR_USO_SUB_CODIGO", tabla);
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar, Usos de Codigo General. ", ex);
            }
            return tabla;
        }

        /// <summary>
        /// Guardar un Registro
        /// </summary>
        /// <returns></returns>
        public int guardar()
        {
            try
            {
                i = server.ejecutar("GUARDAR_USO_CODIGO_GENERAL",
                    server.parametro("@CODIGO", SqlDbType.VarChar, 2, Codigo),
                    server.parametro("@DESCRIPCION", SqlDbType.VarChar, 50, Descripcion),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Guardar,Uso de Codigo General. ", ex);
            }
            return i;
        }

       /// <summary>
       /// Modificar un Registro
       /// </summary>
       /// <returns></returns>
        public int modificar()
        {
            try
            {
                i = server.ejecutar("MODIFICAR_USO_CODIGO_GENERAL",
                    server.parametro("@CODIGO", SqlDbType.VarChar, 2, Codigo),
                    server.parametro("@DESCRIPCION", SqlDbType.VarChar, 50, Descripcion),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Modificar, Uso del Codigo General. ", ex);
            }
            return i;
        }

       /// <summary>
       /// Eleminar un registro
       /// </summary>
       /// <returns></returns>
 

        public int eliminar()
        {
            try
            {
                i = server.ejecutar("ELIMINAR_USO_CODIGO_GENERAL",
                    server.parametro("@CODIGO", SqlDbType.VarChar, 2, Codigo),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Eliminar, Uso de codigo General. ", ex);
            }
            return i;
        }

       /// <summary>
        /// Lista todos los datos en formato de arreglo unidimencional 
       /// </summary>
       /// <returns></returns>
        public string[] listar_arreglo()
        {
            string[] arreglo = null;
            try
            {
                if (tabla.VS_LISTAR_USO_CODIGO_GENERAL.Rows.Count == 0) listar();
                arreglo = tabla.VS_LISTAR_USO_CODIGO_GENERAL.Select(a => a.LISTA).ToArray();
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar Arreglo, Uso de Codigo General. ", ex);
            }
            return arreglo;
        }

      /// <summary>
     /// Busca un registro especificado
      /// </summary>
      /// <param name="elemento"></param>
      /// <returns></returns>
        public bool buscar(string elemento)
        {
            bool valor = false;
            try
            {
                if (tabla.VS_LISTAR_USO_CODIGO_GENERAL.Rows.Count == 0) listar();
                valor = (tabla.VS_LISTAR_USO_CODIGO_GENERAL.FindByCODIGO(elemento) != null) ? true : false;
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Buscar, Listar Uso de Codigo General. ", ex);
            }
            return valor;
        }
        #endregion
    }
}
