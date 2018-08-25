using System;
using System.Data;

namespace Componentes
{
    /// <summary>
    /// Clase: Ficha Catastral de Vías Urbanas - Mobiliario Urbano
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    public class cFicha_Catastral_Vias_Urbanas_Mobiliario_Urbano : cFicha
    {
        #region Atributos y Propiedades
        cFicha_Catastral_Vias_Urbanas ficha_catrastral_vias_urbanas;

        /// <summary>
        /// Clase: Ficha Catastral de Vías Urbanas
        /// </summary>
        public cFicha_Catastral_Vias_Urbanas Ficha_Catrastral_Vias_Urbanas
        {
            get { return ficha_catrastral_vias_urbanas; }
            set { ficha_catrastral_vias_urbanas = value; }
        }
        cTipo_Mobiliario_Urbano tipo_mobiliario_urbano;

        /// <summary>
        /// Clase: Tipo de Mobiliario Urbano
        /// </summary>
        public cTipo_Mobiliario_Urbano Tipo_Mobiliario_Urbano
        {
            get { return tipo_mobiliario_urbano; }
            set { tipo_mobiliario_urbano = value; }
        }
        cMaterial_Componente_Urbano_Mobiliario_Urbano material_componente_urbano_mobiliario_urbano;

        /// <summary>
        /// Clase: Material - Componente Urbano y/o Mobiliario Urbano
        /// </summary>
        public cMaterial_Componente_Urbano_Mobiliario_Urbano Material_Componente_Urbano_Mobiliario_Urbano
        {
            get { return material_componente_urbano_mobiliario_urbano; }
            set { material_componente_urbano_mobiliario_urbano = value; }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Clase: Ficha Catastral de Vías Urbanas - Mobiliario Urbano
        /// </summary>
        public cFicha_Catastral_Vias_Urbanas_Mobiliario_Urbano()
        {
            try
            {
                server.agregar_table_mapping("VS_LISTAR_FICHA_CATASTRAL_VIAS_URBANAS_MOBILIARIO_URBANO",
                server.parametro("ID"),
                server.parametro("ORDEN"),
                server.parametro("FOTOGRAFIA DIGITAL"),
                server.parametro("SECTOR"),
                server.parametro("CODIGO DE VIA"),
                server.parametro("CUADRA"),
                server.parametro("AÑO"),
                server.parametro("TMU"),
                server.parametro("TIPO MOBILIARIO URBANO"),
                server.parametro("CANTIDAD"),
                server.parametro("M"),
                server.parametro("MATERIAL"),
                server.parametro("ECS"),
                server.parametro("ESTADO CONSERVACION"),
                server.parametro("ESPECIFICACIONES"),
                server.parametro("ESTADO"),
                server.parametro("USUARIO CREA"),
                server.parametro("FECHA DE CREACION"),
                server.parametro("USUARIO MODIFICA"),
                server.parametro("FECHA DE MODIFICACION"),
                server.parametro("FICHA"));

                server.agregar_sp("GUARDAR_FICHA_CATASTRAL_VIAS_URBANAS_MOBILIARIO_URBANO", 'G',
                server.parametro(),                
                server.parametro("@FOTOGRAFIA_DIGITAL", SqlDbType.VarBinary,"FOTOGRAFIA DIGITAL",null),
                server.parametro("@SECTOR", SqlDbType.VarChar,2,"SECTOR",null),
                server.parametro("@CODIGO_VIA", SqlDbType.VarChar,3,"CODIGO DE VIA",null),
                server.parametro("@CUADRA", SqlDbType.VarChar,2,"CUADRA",null),
                server.parametro("@AÑO", SqlDbType.VarChar,4,"AÑO",null),
                server.parametro("@TIPO_MOBILIARIO_URBANO", SqlDbType.VarChar,2,"TMU",null),
                server.parametro("@CANTIDAD", SqlDbType.Int,"CANTIDAD",null),
                server.parametro("@MATERIAL", SqlDbType.VarChar,2,"M",null),
                server.parametro("@ESTADO_CONSERVACION", SqlDbType.VarChar,2,"ECS",null),
                server.parametro("@ESPECIFICACIONES", SqlDbType.VarChar,8000,"ESPECIFICACIONES",null),
                server.parametro("@FICHA", SqlDbType.VarChar, 10, "FICHA", null),
                server.parametro("@USUARIO", SqlDbType.VarChar, 10,"USUARIO CREA",null));

                server.agregar_sp("MODIFICAR_FICHA_CATASTRAL_VIAS_URBANAS_MOBILIARIO_URBANO", 'M',
                server.parametro(),
                server.parametro("@ID", SqlDbType.BigInt, "ID", null),                
                server.parametro("@FOTOGRAFIA_DIGITAL", SqlDbType.VarBinary, "FOTOGRAFIA DIGITAL", null),
                server.parametro("@SECTOR", SqlDbType.VarChar, 2, "SECTOR", null),
                server.parametro("@CODIGO_VIA", SqlDbType.VarChar, 3, "CODIGO DE VIA", null),
                server.parametro("@CUADRA", SqlDbType.VarChar, 2, "CUADRA", null),
                server.parametro("@AÑO", SqlDbType.VarChar, 4, "AÑO", null),
                server.parametro("@TIPO_MOBILIARIO_URBANO", SqlDbType.VarChar, 2, "TMU", null),
                server.parametro("@CANTIDAD", SqlDbType.Int, "CANTIDAD", null),
                server.parametro("@MATERIAL", SqlDbType.VarChar, 2, "M", null),
                server.parametro("@ESTADO_CONSERVACION", SqlDbType.VarChar, 2, "ECS", null),
                server.parametro("@ESPECIFICACIONES", SqlDbType.VarChar, 8000, "ESPECIFICACIONES", null),
                server.parametro("@USUARIO", SqlDbType.VarChar, 10,"USUARIO MODIFICA",null));

                server.agregar_sp("ELIMINAR_FICHA_CATASTRAL_VIAS_URBANAS_MOBILIARIO_URBANO", 'E',
                server.parametro(),
                server.parametro("@ID", SqlDbType.BigInt, "ID", null),
                server.parametro("@USUARIO", SqlDbType.VarChar, 10, "USUARIO MODIFICA",null));
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Iniciar el Objeto, Ficha Catastral de Vías Urbanas - Mobiliario Urbano. ", ex);
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
                i = server.actualizar(tabla, "VS_LISTAR_FICHA_CATASTRAL_VIAS_URBANAS_MOBILIARIO_URBANO");
            }
            catch (Exception ex)
            {
                i = -2;
                throw new sqlServerException("Error Actualizar, Ficha Catastral de Vías Urbanas - Mobiliario Urbano. ", ex);
            }
            return i;
        }
        #endregion
    }
}
