using System;
using System.Data;

namespace Componentes
{
    /// <summary>
    /// Ficha Catastral de Espacio de Recreación - Veredas
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    public class cFicha_Catastral_Espacio_Recreacion_Veredas : cFicha
    {
        #region Atributos y Propiedades
        cFicha_Catastral_Espacio_Recreacion ficha_Catastral_espacio_recreacion;

        /// <summary>
        /// Clase: Ficha Catastral de Espacio de Recreación
        /// </summary>
        public cFicha_Catastral_Espacio_Recreacion Ficha_Catastral_Espacio_Recreacion
        {
            get { return ficha_Catastral_espacio_recreacion; }
            set { ficha_Catastral_espacio_recreacion = value; }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Ficha Catastral Equipamiento Urbano - Veredas
        /// </summary>
        public cFicha_Catastral_Espacio_Recreacion_Veredas()
        {
            try
            {
                server.agregar_table_mapping("VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACION_VEREDAS",
                server.parametro("ID"),
                server.parametro("DESCRIPCION"),
                server.parametro("AREA"),
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

                server.agregar_sp("GUARDAR_FICHA_CATASTRAL_ESPACIO_RECREACION_VEREDAS", 'G',
                server.parametro(),
                server.parametro("@DESCRIPCION", SqlDbType.VarChar, 50, "DESCRIPCION", null),
                server.parametro("@AREA", SqlDbType.Float, "AREA", null),
                server.parametro("@MATERIAL", SqlDbType.VarChar, 2, "M", null),
                server.parametro("@ESTADO_CONSERVACION", SqlDbType.VarChar, 2, "ECS", null),
                server.parametro("@ESPECIFICACIONES", SqlDbType.VarChar, 8000, "ESPECIFICACIONES", null),
                server.parametro("@FICHA", SqlDbType.VarChar, 10, "FICHA", null),
                server.parametro("@USUARIO", SqlDbType.VarChar, 10,"USUARIO CREA",null));

                server.agregar_sp("MODIFICAR_FICHA_CATASTRAL_ESPACIO_RECREACION_VEREDAS", 'M',
                server.parametro(),
                server.parametro("@ID", SqlDbType.BigInt, "ID", null),
                server.parametro("@DESCRIPCION", SqlDbType.VarChar, 50, "DESCRIPCION", null),
                server.parametro("@AREA", SqlDbType.Float, "AREA", null),
                server.parametro("@MATERIAL", SqlDbType.VarChar, 2, "M", null),
                server.parametro("@ESTADO_CONSERVACION", SqlDbType.VarChar, 2, "ECS", null),
                server.parametro("@ESPECIFICACIONES", SqlDbType.VarChar, 8000, "ESPECIFICACIONES", null),                
                server.parametro("@USUARIO", SqlDbType.VarChar, 10, "USUARIO MODIFICA", null));

                server.agregar_sp("ELIMINAR_FICHA_CATASTRAL_ESPACIO_RECREACION_VEREDAS", 'E',
                server.parametro(),
                server.parametro("@ID", SqlDbType.BigInt, "ID", null),
                server.parametro("@USUARIO", SqlDbType.VarChar, 10, "USUARIO MODIFICA",null));
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Iniciar el Objeto, Ficha Catastral de Espacio de Recreación - Veredas. ", ex);
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
                i = server.actualizar(tabla, "VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACION_VEREDAS");
            }
            catch (Exception ex)
            {
                i = -2;
                throw new sqlServerException("Error Actualizar, Ficha Catastral de Espacio de Recreación - Veredas. ", ex); 
            }
            return i;
        }
        #endregion
    }
}
