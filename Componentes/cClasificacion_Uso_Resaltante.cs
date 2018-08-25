using System;
using System.Linq;
using System.Data;

namespace Componentes
{
    /// <summary>
    /// Clase: Clasificación de Uso Resaltante
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    public class cClasificacion_Uso_Resaltante : cSubFicha
    {
        #region Atributos y Propiedades
        cTipo_Uso_Resaltante tipo_uso_resaltante;

        /// <summary>
        /// Clase: Tipo de Uso Resaltante
        /// </summary>
        public cTipo_Uso_Resaltante Tipo_Uso_Resaltante
        {
            get { return tipo_uso_resaltante; }
            set { tipo_uso_resaltante = value; }
        }
        string clasificacion;

        /// <summary>
        /// Código de clasificación del Uso Resaltante
        /// </summary>
        public string Clasificacion
        {
            get { return clasificacion; }
            set { clasificacion = value; }
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
                tabla = server.ejecutar_vs("VS_LISTAR_CLASIFICACION_USO_RESALTANTE",tabla);
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar, Clasificación de Uso Resaltante. ",ex);
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
                i = server.ejecutar("GUARDAR_CLASIFICACION_USO_RESALTANTE",
                    server.parametro("@TIPO_USO_RESALTANTE", SqlDbType.VarChar, 2, tipo_uso_resaltante.Codigo),
                    server.parametro("@CLASIFICACION_USO_RESALTANTE", SqlDbType.VarChar, 2, clasificacion),
                    server.parametro("@DESCRIPCION", SqlDbType.VarChar, 50, Descripcion),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Guardar, Clasificación de Uso Resaltante. ", ex);
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
                i = server.ejecutar("MODIFICAR_CLASIFICACION_USO_RESALTANTE",
                    server.parametro("CODIGO",SqlDbType.Int,Codigo),
                    server.parametro("@TIPO_USO_RESALTANTE", SqlDbType.VarChar, 2, tipo_uso_resaltante.Codigo),
                    server.parametro("@CLASIFICACION_USO_RESALTANTE", SqlDbType.VarChar, 2, clasificacion),
                    server.parametro("@DESCRIPCION", SqlDbType.VarChar, 50, Descripcion),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Modificar, Clasificación de Uso Resaltante. ", ex);
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
                i = server.ejecutar("ELIMINAR_CLASIFICACION_USO_RESALTANTE",
                    server.parametro("CODIGO", SqlDbType.Int, Codigo),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Eliminar, Clasificación de Uso Resaltante. ", ex);
            }
            return i;
        }

        /// <summary>
        /// Lista todos los datos en formato de arreglo unidimencional 
        /// </summary> 
        /// <param name="tipo">Tipo de Uso Resaltante</param>
        /// <returns>Un arreglo de datos</returns>
        public string[] listar_arreglo(string tipo)
        {
            string[] arreglo = null;
            try
            {
                if (tabla.VS_LISTAR_CLASIFICACION_USO_RESALTANTE.Rows.Count == 0) listar();
                    EnumerableRowCollection<FICHA_ds.VS_LISTAR_CLASIFICACION_USO_RESALTANTERow> query = from c in tabla.VS_LISTAR_CLASIFICACION_USO_RESALTANTE.AsEnumerable()
                                                                                            where c.TUR == tipo
                                                                                            select c;
                    arreglo = query.Select(a => a.LISTA).ToArray();
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar Arreglo, Clasificación de Uso Resaltante. ", ex);
            }
            return arreglo;
        }

        /// <summary>
        /// Busca un registro especificado
        /// </summary>
        /// <param name="tipo">El código del Tipo de Uso Resaltante</param>
        /// <param name="clasificacion">El código de la Clasificación de Uso Resaltante</param>
        /// <returns>Si existe en la tabla</returns>
        public bool buscar(string tipo, string clasificacion)
        {
            bool valor = false;
            try
            {
                if (tabla.VS_LISTAR_CLASIFICACION_USO_RESALTANTE.Rows.Count == 0) listar();
                    EnumerableRowCollection<FICHA_ds.VS_LISTAR_CLASIFICACION_USO_RESALTANTERow> query = from c in tabla.VS_LISTAR_CLASIFICACION_USO_RESALTANTE.AsEnumerable()
                                                                                            where c.TUR == tipo && c.CUR == clasificacion
                                                                                            select c;
                  valor= (query.ToList().Count > 0) ? true : false; 
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Buscar, Clasificación de Uso Resaltante. ", ex);
            }
            return valor;
        }

        /// <summary>
        /// Busca un registro especificado
        /// </summary>
        /// <param name="tipo">El código del Tipo de Uso Resaltante</param>
        /// <param name="clasificacion">El código de la Clasificación de Uso Resaltante</param>
        /// <returns>Si existe en la tabla</returns>
        public string[] Buscar(string tipo, string clasificacion)
        {
            string[] arreglo = null;            
            try
            {
                if (tabla.VS_LISTAR_CLASIFICACION_USO_RESALTANTE.Rows.Count == 0) listar();
                    EnumerableRowCollection<FICHA_ds.VS_LISTAR_CLASIFICACION_USO_RESALTANTERow> query = from c in tabla.VS_LISTAR_CLASIFICACION_USO_RESALTANTE.AsEnumerable()
                                                                                                        where c.TUR == tipo && c.CUR == clasificacion
                                                                                                        select c;
                    arreglo = query.Select(a => a.LISTA).ToArray();
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Buscar, Clasificación de Uso Resaltante. ", ex);
            }
            return arreglo;
        }
        #endregion
    }
}
