using System;
using System.Data;

namespace Componentes
{
    /// <summary>
    /// Clase: Ficha Catastral Específica - Uso Resaltante
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    public class cFicha_Catastral_Especifica_Uso_Resaltante : cFicha
    {
        #region Atributos y Propiedades
        cFicha_Catastral_Especifica ficha_catastral_especifica;

        /// <summary>
        /// Clase: Ficha Catastral Específica
        /// </summary>
        public cFicha_Catastral_Especifica Ficha_catastral_especifica
        {
            get { return ficha_catastral_especifica; }
            set { ficha_catastral_especifica = value; }
        }
        cTipo_Uso_Resaltante tipo_uso_resaltante;

        /// <summary>
        /// Clase: Tipo de Uso Resaltante
        /// </summary>
        public cTipo_Uso_Resaltante Tipo_uso_resaltante
        {
            get { return tipo_uso_resaltante; }
            set { tipo_uso_resaltante = value; }
        }
        cClasificacion_Uso_Resaltante clasificacion_uso_resaltante;

        /// <summary>
        /// Clase: Clasificación de Uso Resaltante
        /// </summary>
        public cClasificacion_Uso_Resaltante Clasificacion_uso_resaltante
        {
            get { return clasificacion_uso_resaltante; }
            set { clasificacion_uso_resaltante = value; }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Ficha Catastral Específica - Uso Resaltante
        /// </summary>
        public cFicha_Catastral_Especifica_Uso_Resaltante()
        {
            try
            {
                server.agregar_table_mapping("VS_LISTAR_FICHA_CATASTRAL_ESPECIFICA_USO_RESALTANTE",
                server.parametro("ID"),
                server.parametro("ORDEN"),
                server.parametro("FOTOGRAFIA DIGITAL"),
                server.parametro("SECTOR"),
                server.parametro("CODIGO DE VIA / MANZANA"),
                server.parametro("CUADRA / LOTE"),
                server.parametro("AÑO"),
                server.parametro("TUR"),   
                server.parametro("TIPO USO RESALTANTE"),
                server.parametro("CUR"),
                server.parametro("CLASIFICACION USO RESALTANTE"),
                server.parametro("PUNTO X"),
                server.parametro("PUNTO Y"),
                server.parametro("PUNTO Z"),
                server.parametro("ESPECIFICACIONES"),
                server.parametro("ESTADO"),
                server.parametro("USUARIO CREA"),
                server.parametro("FECHA DE CREACION"),
                server.parametro("USUARIO MODIFICA"),
                server.parametro("FECHA DE MODIFICACION"),
                server.parametro("FICHA"));                

                server.agregar_sp("GUARDAR_FICHA_CATASTRAL_ESPECIFICA_USO_RESALTANTE", 'G',
                server.parametro(),                
                server.parametro("@FOTOGRAFIA_DIGITAL",SqlDbType.VarBinary,"FOTOGRAFIA DIGITAL",null),
                server.parametro("@SECTOR", SqlDbType.VarChar, 2, "SECTOR", null),
                server.parametro("@CODIGO_VIA_MANZANA",SqlDbType.VarChar,3,"CODIGO DE VIA / MANZANA",null),
                server.parametro("@CUADRA_LOTE",SqlDbType.VarChar,3,"CUADRA / LOTE",null), 
                server.parametro("@AÑO",SqlDbType.VarChar,4,"AÑO",null), 
                server.parametro("@DIRECCION",SqlDbType.VarChar,8000,"DIRECCION",null),
                server.parametro("@TIPO_USO_RESALTANTE", SqlDbType.VarChar, 2, "TUR", null),
                server.parametro("@CLASIFICACION_USO_RESALTANTE", SqlDbType.VarChar, 2, "CUR", null),
                server.parametro("@PUNTO_X", SqlDbType.Float, "PUNTO X", null),
                server.parametro("@PUNTO_Y", SqlDbType.Float, "PUNTO Y", null),
                server.parametro("@PUNTO_Z", SqlDbType.Float, "PUNTO Z", null),
                server.parametro("@ESPECIFICACIONES", SqlDbType.VarChar, 8000, "ESPECIFICACIONES", null),
                server.parametro("@FICHA", SqlDbType.VarChar, 10, "FICHA", null),
                server.parametro("@USUARIO", SqlDbType.VarChar, 10,"USUARIO CREA",null));

                server.agregar_sp("MODIFICAR_FICHA_CATASTRAL_ESPECIFICA_USO_RESALTANTE", 'M',
                server.parametro(),
                server.parametro("@ID", SqlDbType.BigInt, "ID", null),               
                server.parametro("@FOTOGRAFIA_DIGITAL", SqlDbType.VarBinary, "FOTOGRAFIA DIGITAL", null),
                server.parametro("@SECTOR", SqlDbType.VarChar, 2, "SECTOR", null),
                server.parametro("@CODIGO_VIA_MANZANA", SqlDbType.VarChar, 3, "CODIGO DE VIA / MANZANA", null),
                server.parametro("@CUADRA_LOTE", SqlDbType.VarChar, 3, "CUADRA / LOTE", null),
                server.parametro("@AÑO", SqlDbType.VarChar, 4, "AÑO", null),
                server.parametro("@DIRECCION", SqlDbType.VarChar, 8000, "DIRECCION", null),
                server.parametro("@TIPO_USO_RESALTANTE", SqlDbType.VarChar, 2, "TUR", null),
                server.parametro("@CLASIFICACION_USO_RESALTANTE", SqlDbType.VarChar, 2, "CUR", null),
                server.parametro("@PUNTO_X", SqlDbType.Float, "PUNTO X", null),
                server.parametro("@PUNTO_Y", SqlDbType.Float, "PUNTO Y", null),
                server.parametro("@PUNTO_Z", SqlDbType.Float, "PUNTO Z", null),
                server.parametro("@ESPECIFICACIONES", SqlDbType.VarChar, 8000, "ESPECIFICACIONES", null),                
                server.parametro("@USUARIO", SqlDbType.VarChar, 10, "USUARIO MODIFICA", null));

                server.agregar_sp("ELIMINAR_FICHA_CATASTRAL_ESPECIFICA_USO_RESALTANTE", 'E',
                server.parametro(),
                server.parametro("@ID", SqlDbType.BigInt, "ID", null),
                server.parametro("@USUARIO", SqlDbType.VarChar, 10, "USUARIO MODIFICA",null));
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Iniciar el Objeto, Ficha Catastral de Específica - Uso Resaltante. ", ex);
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
                i = server.actualizar(tabla, "VS_LISTAR_FICHA_CATASTRAL_ESPECIFICA_USO_RESALTANTE");
            }
            catch (Exception ex)
            {
                i = -2;
                throw new sqlServerException("Error Actualizar, Ficha Catastral de Específica - Uso Resaltante. ", ex); 
            }
            return i;
        }
        #endregion
    }
}
