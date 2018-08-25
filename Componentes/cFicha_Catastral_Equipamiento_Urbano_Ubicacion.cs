using System;
using System.Data;

namespace Componentes
{
    /// <summary>
    /// Clase: Ficha Catastral Equipamiento Urbano - Ubicación
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    public class cFicha_Catastral_Equipamiento_Urbano_Ubicacion : cFicha
    {
        #region Atributos y Propiedades
        cFicha_Catastral_Equipamiento_Urbano ficha_catastral_equipamiento_urbano;

        /// <summary>
        /// Clase: Ficha Catastral Equipamiento Urbano
        /// </summary>
        public cFicha_Catastral_Equipamiento_Urbano Ficha_Catastral_Equipamiento_Urbano
        {
            get { return ficha_catastral_equipamiento_urbano; }
            set { ficha_catastral_equipamiento_urbano = value; }
        }
        cVias vias;

        /// <summary>
        /// Clase: Eje de Via
        /// </summary>
        public cVias Vías
        {
            get { return vias; }
            set { vias = value; }
        }
        cTipo_Puerta tipo_puerta;

        /// <summary>
        /// Clase: Tipo de Puerta
        /// </summary>
        public cTipo_Puerta Tipo_Puerta
        {
            get { return tipo_puerta; }
            set { tipo_puerta = value; }
        }
        cCondicion_Numeracion condicion_numeracion;

        /// <summary>
        /// Clase: Condición de Numeración
        /// </summary>
        public cCondicion_Numeracion Condicion_Numeracion
        {
            get { return condicion_numeracion; }
            set { condicion_numeracion = value; }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Ficha Catastral Equipamiento Urbano - Ubicación
        /// </summary>
        public cFicha_Catastral_Equipamiento_Urbano_Ubicacion()
        {
            try
            {
                server.agregar_table_mapping("VS_LISTAR_FICHA_CATASTRAL_EQUIPAMIENTO_URBANO_UBICACION",
                server.parametro("ID"),
                server.parametro("SECTOR"),
                server.parametro("CODIGO DE VIA"),
                server.parametro("CUADRA"),
                server.parametro("TV"),
                server.parametro("TIPO DE VIA"),
                server.parametro("NOMBRE DE VIA"),
                server.parametro("TP"),
                server.parametro("TIPO DE PUERTA"),
                server.parametro("NUMERO MUNICIPAL"),
                server.parametro("CN"),
                server.parametro("CONDICION NUMERACION"),
                server.parametro("NUMERO CERTIFICADO DE NUMERACION"),
                server.parametro("ESTADO"),
                server.parametro("USUARIO CREA"),
                server.parametro("FECHA DE CREACION"),
                server.parametro("USUARIO MODIFICA"),
                server.parametro("FECHA DE MODIFICACION"),
                server.parametro("FICHA"));

                server.agregar_sp("GUARDAR_FICHA_CATASTRAL_EQUIPAMIENTO_URBANO_UBICACION", 'G',
                server.parametro(),
                server.parametro("@SECTOR",SqlDbType.VarChar,2,"SECTOR",null),
                server.parametro("@CODIGO_VIA",SqlDbType.VarChar,3,"CODIGO DE VIA",null),
                server.parametro("@CUADRA",SqlDbType.VarChar,2,"CUADRA",null),
                server.parametro("@TIPO_PUERTA", SqlDbType.VarChar, 1, "TP", null),
                server.parametro("@NUMERO_MUNICIPAL", SqlDbType.Int, "NUMERO MUNICIPAL", null),
                server.parametro("@CONDICION_NUMERACION", SqlDbType.VarChar, 2, "CN", null),
                server.parametro("@NUMERO_CERTIFICADO_NUMERACION", SqlDbType.VarChar, 30, "NUMERO CERTIFICADO DE NUMERACION", null),
                server.parametro("@FICHA", SqlDbType.VarChar, 10, "FICHA", null),
                server.parametro("@USUARIO", SqlDbType.VarChar, 10,"USUARIO CREA",null));

                server.agregar_sp("MODIFICAR_FICHA_CATASTRAL_EQUIPAMIENTO_URBANO_UBICACION", 'M',
                server.parametro(),
                server.parametro("@ID", SqlDbType.BigInt, "ID", null),
                server.parametro("@SECTOR", SqlDbType.VarChar, 2, "SECTOR", null),
                server.parametro("@CODIGO_VIA", SqlDbType.VarChar, 3, "CODIGO DE VIA", null),
                server.parametro("@CUADRA", SqlDbType.VarChar, 2, "CUADRA", null),
                server.parametro("@TIPO_PUERTA", SqlDbType.VarChar, 1, "TP", null),
                server.parametro("@NUMERO_MUNICIPAL", SqlDbType.Int, "NUMERO MUNICIPAL", null),
                server.parametro("@CONDICION_NUMERACION", SqlDbType.VarChar, 2, "CN", null),
                server.parametro("@NUMERO_CERTIFICADO_NUMERACION", SqlDbType.VarChar, 30, "NUMERO CERTIFICADO DE NUMERACION", null),
                server.parametro("@USUARIO", SqlDbType.VarChar, 10,"USUARIO MODIFICA",null));

                server.agregar_sp("ELIMINAR_FICHA_CATASTRAL_EQUIPAMIENTO_URBANO_UBICACION", 'E',
                server.parametro(),
                server.parametro("@ID", SqlDbType.BigInt, "ID", null),
                server.parametro("@USUARIO", SqlDbType.VarChar, 10, "USUARIO MODIFICA",null));
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Iniciar el Objeto, Ficha Catastral de Equipamiento Urbano - Ubicación. ", ex);
            }
        }

        /// <summary>
        /// Actualiza todos los registros de una tabla especificada
        /// </summary>
        /// <param name="tabla">Tabla a Actualizar en la base de datos</param>
        /// <returns>Retorna el número de filas afectadas</returns>
        public int actualizar(FICHA_ds tabla)
        {
            try
            {
                i = server.actualizar(tabla, "VS_LISTAR_FICHA_CATASTRAL_EQUIPAMIENTO_URBANO_UBICACION");
            }
            catch (Exception ex)
            {
                i = -2;
                throw new sqlServerException("Error Actualizar, Ficha Catastral de Equipamiento Urbano - Ubicación. ", ex);
            }
            return i;            
        }
        #endregion
    }
}
