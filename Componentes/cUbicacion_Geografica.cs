using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace Componentes
{
    /// <summary>
    /// Clase: Ubicación Geográfica
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    public class cUbicacion_Geografica : cConexion
    {
        #region Variables Globales
        List<IGrouping<string, string>> dist = null;
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el Código del Departamento
        /// </summary>
        public static string Codigo_Departamento
        {
            get { return retornar("Departamento"); }
            set { asignar("Departamento",value); }
        }

        /// <summary>
        /// Obtiene el Código de la Provincia
        /// </summary>
        public static string Codigo_Provincia
        {
            get { return retornar("Provincia"); }
            set { asignar("Provincia", value); }
        }

        /// <summary>
        /// Obtiene el Código del Distrito
        /// </summary>
        public static string Codigo_Distrito
        {
            get { return retornar("Distrito"); }
            set { asignar("Distrito",value); }
        }

        /// <summary>
        /// Retorna el Ubigeo del Departamento, Provincia, Distrito
        /// </summary>
        public static string Ubigeo
        {
            get { return Codigo_Departamento + Codigo_Provincia + Codigo_Distrito; }
        }        
        #endregion

        #region Metodos
        /// <summary>
        /// Crea un nuevo objeto a utilizar para la ubicación cartogrAfica.
        /// </summary>
        public cUbicacion_Geografica()
        {
            listar();
        }

        /// <summary>
        /// Carga toda las información 
        /// </summary>
        void listar()
        {
            try
            {
                tabla = server.ejecutar_vs("VS_LISTAR_UBICACION_GEOGRAFICA",tabla);
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar, Ubicación geográfica.",ex);
            }
        }

        /// <summary>
        /// Lista todos los 24 Departamento y 1 Provincia Constitucional del Callao.
        /// </summary>
        /// <returns>Retorna una lista de Nombres de los Departamentos</returns>
        public List<IGrouping<string, string>> listar_departamento()
        {
            List<IGrouping<string, string>> arreglo = null;
            try
            {
                if (tabla.VS_LISTAR_UBICACION_GEOGRAFICA != null)
                {
                    EnumerableRowCollection<FICHA_ds.VS_LISTAR_UBICACION_GEOGRAFICARow> query = from departamento in this.tabla.VS_LISTAR_UBICACION_GEOGRAFICA.AsEnumerable()
                                                                                        select departamento;
                    arreglo= query.GroupBy(a => a.DEPARTAMENTO, b => b.UBIGEO.Substring(0, 2)).ToList();                    
                }            
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar Arreglo, Ubicación Geográfica - Departamento.",ex);
            }
            return arreglo;
        }

        /// <summary>
        /// Lista todas las provincias de un departamento elegido
        /// </summary>
        /// <param name="departamento">Nombre del Departamento</param>
        /// <returns>Retorna una lista de Nombres de Provincias</returns>
        public List<IGrouping<string, string>> listar_provincia(string departamento)
        {
            List<IGrouping<string, string>> arreglo = null;
            try
            {
                if (tabla.VS_LISTAR_UBICACION_GEOGRAFICA != null)
                {
                    EnumerableRowCollection<FICHA_ds.VS_LISTAR_UBICACION_GEOGRAFICARow> query = from provincia in this.tabla.VS_LISTAR_UBICACION_GEOGRAFICA.AsEnumerable()
                                                                                        where provincia.DEPARTAMENTO == departamento
                                                                                        select provincia;
                    arreglo = query.GroupBy(a => a.PROVINCIA, b => b.UBIGEO.Substring(0, 4)).ToList();                                     
                }            
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar Arreglo, Ubicación Geográfica - Provincia.",ex);
            }
            return arreglo;
        } 

        /// <summary>
        /// Lista todos los distrito de una provincia especificada.
        /// </summary>
        /// <param name="provincia">Nombre de la Provincia</param>
        /// <returns>Retorna una lista de Nombres de Distritos</returns>
        public List<IGrouping<string,string>> listar_distrito(string provincia)
        {            
            try
            {
                if (tabla.VS_LISTAR_UBICACION_GEOGRAFICA != null)
                {
                    EnumerableRowCollection<FICHA_ds.VS_LISTAR_UBICACION_GEOGRAFICARow> query = from distrito in this.tabla.VS_LISTAR_UBICACION_GEOGRAFICA.AsEnumerable()
                                                                                        where distrito.PROVINCIA == provincia
                                                                                        select distrito;
                    dist = query.GroupBy(a => a.DISTRITO, b => b.UBIGEO).ToList();                                      
                }            
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar Arreglo, Ubicación Geográfica - Distrito ",ex);
            }
            return dist;
        }

        /// <summary>
        /// Busca el distrito, provincia y Departamento del ubigeo especificado.
        /// </summary>
        /// <param name="ubigeo">Biene a ser la Unión del Código del Departamento, Código de la Provincia , Código del Distrito</param>
        /// <returns>Retorna la lista indicada.</returns>
        public IGrouping<string, string> buscar(string ubigeo)
        {
            IGrouping<string,string> item = null;
            try
            {
                if (tabla.VS_LISTAR_UBICACION_GEOGRAFICA != null) item = dist.Find(f => f.Key == ubigeo);                
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Buscar Arreglo, Ubicación Geográfica. ",ex);
            }
            return item;            
        }
        #endregion
    }
}
