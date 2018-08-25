using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using WinControls.ListView;

namespace Componentes
{
    /// <summary>
    /// Clase: Vías
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    public class cVias : cSubFicha
    {
        #region Atributos y Propiedades
        cTipo_Vias tipo_via;

        /// <summary>
        /// Tipo de Via
        /// </summary>
        public cTipo_Vias Tipo_Via
        {
            get { return tipo_via; }
            set { tipo_via = value; }
        }
        string nombre_via;

        /// <summary>
        /// Nombre de la Via
        /// </summary>
        public string Nombre_Via
        {
            get { return nombre_via; }
            set { nombre_via = value; }
        }
        string toponimo;

        /// <summary>
        /// Toponimo
        /// </summary>
        public string Toponimo
        {
            get { return toponimo; }
            set { toponimo = value; }
        }
        cCondicion_Nombre_Via condicion_nombre_via;

        /// <summary>
        /// Clase: Condición de Nombre de la Via
        /// </summary>
        public cCondicion_Nombre_Via Condicion_Nombre_Via
        {
            get { return condicion_nombre_via; }
            set { condicion_nombre_via = value; }
        }
        string numero_acuerdo;

        /// <summary>
        /// Número de Acuerdo
        /// </summary>
        public string Numero_Acuerdo
        {
            get { return numero_acuerdo; }
            set { numero_acuerdo = value; }
        }
        cClasificacion_Via clasificacion_via;

        /// <summary>
        /// Clase: Clasificación de la Vía
        /// </summary>
        public cClasificacion_Via Clasificacion_Via
        {
            get { return clasificacion_via; }
            set { clasificacion_via = value; }
        }
        string codigo_via_mtc;

        /// <summary>
        /// Código de Via - Ministerio de Transportes y Comunicaciones
        /// </summary>
        public string Codigo_via_mtc
        {
            get { return codigo_via_mtc; }
            set { codigo_via_mtc = value; }
        }
        cUbicacion_Geografica ubicacion_geografica;

        /// <summary>
        /// Clase: Ubicación Geográfica
        /// </summary>
        public cUbicacion_Geografica Ubicacion_Geografica
        {
            get { return ubicacion_geografica; }
            set { ubicacion_geografica = value; }
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
                tabla = server.ejecutar_vs("VS_LISTAR_VIAS",tabla);
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar, vias. ", ex);
            }
            return tabla;
        }

        /// <summary>
        /// Guarda un Registro
        /// </summary>
        /// <returns>El número de filas Afectadas</returns>
        public int guardar()
        {
            try
            {
                i = server.ejecutar("GUARDAR_VIAS",
                    server.parametro("@CODIGO_VIA", SqlDbType.VarChar, 3, Codigo),
                    server.parametro("@TIPO_VIA",SqlDbType.VarChar,4,tipo_via.Codigo),
                    server.parametro("@NOMBRE_VIA",SqlDbType.VarChar,100,nombre_via),
                    server.parametro("@TOPONIMO",SqlDbType.VarChar,100,toponimo),
                    server.parametro("@CONDICION_NOMBRE_VIA",SqlDbType.VarChar,2,condicion_nombre_via.Codigo),
                    server.parametro("@NUMERO_ACUERDO",SqlDbType.VarChar,100,numero_acuerdo),
                    server.parametro("@CLASIFICACION_VIA",SqlDbType.VarChar,2,clasificacion_via.Codigo),
                    server.parametro("@CODIGO_VIA_MTC",SqlDbType.VarChar,100,codigo_via_mtc),
                    server.parametro("@UBIGEO",SqlDbType.VarChar,6,cUbicacion_Geografica.Ubigeo),
                    server.parametro("@OBSERVACIONES", SqlDbType.Text, Descripcion),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Guardar, vias. ", ex);
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
                i = server.ejecutar("MODIFICAR_VIAS",
                    server.parametro("@CODIGO_VIA", SqlDbType.VarChar, 3, Codigo),
                    server.parametro("@TIPO_VIA", SqlDbType.VarChar, 4, tipo_via.Codigo),
                    server.parametro("@NOMBRE_VIA", SqlDbType.VarChar, 100, nombre_via),
                    server.parametro("@TOPONIMO", SqlDbType.VarChar, 100, toponimo),
                    server.parametro("@CONDICION_NOMBRE_VIA", SqlDbType.VarChar, 2, condicion_nombre_via.Codigo),
                    server.parametro("@NUMERO_ACUERDO", SqlDbType.VarChar, 100, numero_acuerdo),
                    server.parametro("@CLASIFICACION_VIA", SqlDbType.VarChar, 2, clasificacion_via.Codigo),
                    server.parametro("@CODIGO_VIA_MTC", SqlDbType.VarChar, 100, codigo_via_mtc),
                    server.parametro("@UBIGEO", SqlDbType.VarChar, 6, cUbicacion_Geografica.Ubigeo),
                    server.parametro("@OBSERVACIONES",SqlDbType.Text,Descripcion),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Modificar, vias. ", ex);
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
                i = server.ejecutar("ELIMINAR_VIAS",
                    server.parametro("@CODIGO_VIA", SqlDbType.VarChar, 6, Codigo),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Eliminar, vias. ", ex);
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
                if (tabla.VS_LISTAR_VIAS.Rows.Count == 0) listar();
                arreglo= tabla.VS_LISTAR_VIAS.Select(b => b.LISTA).ToArray();  
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar Arreglo, vias.", ex);
            }
            return arreglo;
        }

        TreeListNode nuevo_arbol(string nombre, string tag)
        {
            TreeListNode a = new TreeListNode();
            a.Text = nombre;
            a.Tag = tag;
            return a;
        }

        void cargar()
        {
            try
            {
                tabla = server.ejecutar_vs("VS_CARGAR_EJE_VIAS",tabla);
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Cargar, eje de via. ", ex);
            }
        }

        /// <summary>
        /// >Carga un conjunto de Datos
        /// </summary>
        /// <returns>UN agrego de tipo de Control TreListNode</returns>
        public TreeListNode[] cargar_eje_vias_arreglo()
        {
            TreeListNode[] arreglo = null;
            try
            {
                if (tabla.VS_CARGAR_EJE_VIAS.Rows.Count == 0) cargar();
                IEnumerable<TreeListNode> query = from v in tabla.VS_CARGAR_EJE_VIAS                                                      
                                                      select nuevo_arbol(v.DESCRIPCION,v.ID.ToString());
                arreglo = query.Select(a => a).ToArray();                
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Cargar Arreglo, vias.", ex);
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
                if (tabla.VS_LISTAR_VIAS.Rows.Count == 0) listar();
                valor = (tabla.VS_LISTAR_VIAS.FindByCODIGO_DE_VIA(elemento) != null) ? true : false;                
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Buscar, vias.",ex);
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
                if (tabla.VS_LISTAR_VIAS.Rows.Count == 0) listar();
                filas = tabla.VS_LISTAR_VIAS.Rows.Find(elemento);
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Buscar, vias.",ex);
            }
            return filas;
        }        
        #endregion
    }    
}
