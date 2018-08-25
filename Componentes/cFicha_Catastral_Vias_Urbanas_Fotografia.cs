using System;
using System.Data;

namespace Componentes
{
    /// <summary>
    /// Clase: Ficha Catastral de Vías Urbanas - Fotografía
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    public class cFicha_Catastral_Vias_Urbanas_Fotografia : cFicha
    {
        #region Atributos y Propiedades
        cFicha_Catastral_Vias_Urbanas ficha_catastral_vias_urbanas;

        /// <summary>
        /// Clase: Ficha Catastral de Vías Urbanas
        /// </summary>
        public cFicha_Catastral_Vias_Urbanas Ficha_Catastral_Vias_Urbanas
        {
            get { return ficha_catastral_vias_urbanas; }
            set { ficha_catastral_vias_urbanas = value; }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Clase: Ficha Catastral de Vías Urbanas - Fotografía
        /// </summary>
        public cFicha_Catastral_Vias_Urbanas_Fotografia()
        {
            try
            {
                server.agregar_table_mapping("VS_LISTAR_FICHA_CATASTRAL_VIAS_URBANAS_FOTOGRAFIA",
                server.parametro("ID"),
                server.parametro("PLANO DE VIA"),                
                server.parametro("AÑO PLANO DE VIA"),
                server.parametro("SECCION TIPICA DE VIA"),
                server.parametro("SECCION FOTOGRAFIA DIGITAL"),                
                server.parametro("AÑO FOTOGRAFIA DIGITAL"),
                server.parametro("SECTOR"),
                server.parametro("CODIGO DE VIA"),
                server.parametro("CUADRA"),
                server.parametro("ESTADO"),
                server.parametro("USUARIO CREA"),
                server.parametro("FECHA DE CREACION"),
                server.parametro("USUARIO MODIFICA"),
                server.parametro("FECHA DE MODIFICACION"),
                server.parametro("FICHA")); 

                server.agregar_sp("GUARDAR_FICHA_CATASTRAL_VIAS_URBANAS_FOTOGRAFIA", 'G',
                server.parametro(),
                server.parametro("@PLANO_VIA", SqlDbType.VarBinary, "PLANO DE VIA", null),
                server.parametro("@AÑO_PLANO_VIA", SqlDbType.VarChar, 4, "AÑO PLANO DE VIA", null),
                server.parametro("@SECCION_TIPICA_VIA", SqlDbType.VarBinary, "SECCION TIPICA DE VIA", null),
                server.parametro("@SECCION", SqlDbType.VarChar, 50, "SECCION", null),
                server.parametro("@FOTOGRAFIA_DIGITAL", SqlDbType.VarBinary, "FOTOGRAFIA DIGITAL", null),
                server.parametro("@AÑO_FOTOGRAFIA_DIGITAL", SqlDbType.VarChar, 4, "AÑO FOTOGRAFIA DIGITAL", null),
                server.parametro("@SECTOR", SqlDbType.VarChar, 2, "SECTOR", null),
                server.parametro("@CODIGO_VIA", SqlDbType.VarChar, 3, "CODIGO DE VIA", null),
                server.parametro("@CUADRA", SqlDbType.VarChar, 2, "CUADRA", null),
                server.parametro("@FICHA", SqlDbType.VarChar, 10, "FICHA", null),
                server.parametro("@USUARIO", SqlDbType.VarChar, 10, "USUARIO CREA", null));

                server.agregar_sp("MODIFICAR_FICHA_CATASTRAL_VIAS_URBANAS_FOTOGRAFIA", 'M',
                server.parametro(),
                server.parametro("@ID", SqlDbType.BigInt, "ID", null),
                server.parametro("@PLANO_VIA", SqlDbType.VarBinary, "PLANO DE VIA", null),
                server.parametro("@AÑO_PLANO_VIA", SqlDbType.VarChar, 4, "AÑO PLANO DE VIA", null),
                server.parametro("@SECCION_TIPICA_VIA", SqlDbType.VarBinary, "SECCION TIPICA DE VIA", null),
                server.parametro("@SECCION", SqlDbType.VarChar, 50, "SECCION", null),
                server.parametro("@FOTOGRAFIA_DIGITAL", SqlDbType.VarBinary, "FOTOGRAFIA DIGITAL", null),
                server.parametro("@AÑO_FOTOGRAFIA_DIGITAL", SqlDbType.VarChar, 4, "AÑO FOTOGRAFIA DIGITAL", null),
                server.parametro("@SECTOR", SqlDbType.VarChar, 2, "SECTOR", null),
                server.parametro("@CODIGO_VIA", SqlDbType.VarChar, 3, "CODIGO DE VIA", null),
                server.parametro("@CUADRA", SqlDbType.VarChar, 2, "CUADRA", null),                
                server.parametro("@USUARIO", SqlDbType.VarChar, 10, "USUARIO MODIFICA", null));

                server.agregar_sp("ELIMINAR_FICHA_CATASTRAL_VIAS_URBANAS_FOTOGRAFIA", 'E',
                server.parametro(),
                server.parametro("@ID", SqlDbType.BigInt, "ID", null),
                server.parametro("@USUARIO", SqlDbType.VarChar, 10, "USUARIO MODIFICA",null));
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Iniciar el Objeto, Ficha Catastral de Vías Urbanas - Fotografía. ", ex);
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
                i = server.actualizar(tabla, "VS_LISTAR_FICHA_CATASTRAL_VIAS_URBANAS_FOTOGRAFIA");
            }
            catch (Exception ex)
            {
                i = -2;
                throw new sqlServerException("Error Actualizar, Ficha Catastral de Vías Urbanas - Fotografía. ", ex);
            }
            return i;
        }
        #endregion
    }
}

