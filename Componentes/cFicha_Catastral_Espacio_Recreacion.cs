using System;
using System.Data;

namespace Componentes
{
    /// <summary>
    /// Ficha Catastral de Espacio de Recreación
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    public class cFicha_Catastral_Espacio_Recreacion : cFicha
    {
        #region Atributos y Propiedades
        string sector;

        /// <summary>
        /// Sector
        /// </summary>
        public string Sector
        {
            get { return sector; }
            set { sector = value; }
        }
        string manzana;

        /// <summary>
        /// Manzana
        /// </summary>
        public string Manzana
        {
            get { return manzana; }
            set { manzana = value; }
        }
        string lote;

        /// <summary>
        /// Lote
        /// </summary>
        public string Lote
        {
            get { return lote; }
            set { lote = value; }
        }
        string nomenclatura;

        /// <summary>
        /// Nomenclatura
        /// </summary>
        public string Nomenclatura
        {
            get { return nomenclatura; }
            set { nomenclatura = value; }
        }
        string toponimo;

        /// <summary>
        /// Topónimo
        /// </summary>
        public string Toponimo
        {
            get { return toponimo; }
            set { toponimo = value; }
        }
        cHabilitacion_Urbana habilitacion_urbana;

        /// <summary>
        /// Clase: Habilitación Urbana
        /// </summary>
        public cHabilitacion_Urbana Habilitacion_Urbana
        {
            get { return habilitacion_urbana; }
            set { habilitacion_urbana = value; }
        }
        string zona_sector_etapa;

        /// <summary>
        /// Zona - Sector - Etapa
        /// </summary>
        public string Zona_Sector_Etapa
        {
            get { return zona_sector_etapa; }
            set { zona_sector_etapa = value; }
        }
        object punto_x;

        /// <summary>
        /// Punto X
        /// </summary>        
        public object Punto_X
        {
            get { return (punto_x.ToString().Length == 0) ? null : (double?)Convert.ToDouble(punto_x); }
            set { punto_x = value; }
        }
        object punto_y;

        /// <summary>
        /// Punto Y
        /// </summary>
        public object Punto_Y
        {
            get { return (punto_y.ToString().Length == 0) ? null : (double?)Convert.ToDouble(punto_y); }
            set { punto_y = value; }
        }
        object punto_z;

        /// <summary>
        /// Punto Z
        /// </summary>
        public object Punto_Z
        {
            get { return (punto_z.ToString().Length == 0) ? null : (double?)Convert.ToDouble(punto_z); }
            set { punto_z = value; }
        }
        object area_total;

        /// <summary>
        /// Área Total
        /// </summary>
        public object Area_Total
        {
            get { return (area_total.ToString().Length == 0) ? null : (double?)Convert.ToDouble(area_total); }
            set { area_total = value; }
        }
        object area_verde;

        /// <summary>
        /// Área Verde
        /// </summary>
        public object Area_Verde
        {
            get { return (area_verde.ToString().Length == 0) ? null : (double?)Convert.ToDouble(area_verde); }
            set { area_verde = value; }
        }
        cTipo_Espacio_Recreacion tipo_espacio_recreacion;

        /// <summary>
        /// Clase: Tipo de Espacio de Recreación
        /// </summary>
        public cTipo_Espacio_Recreacion Tipo_Espacio_Recreacion
        {
            get { return tipo_espacio_recreacion; }
            set { tipo_espacio_recreacion = value; }
        }
        cEstado_Conservacion estado_conservacion;

        /// <summary>
        /// Clase: Estado de Conservación
        /// </summary>
        public cEstado_Conservacion Estado_Conservacion
        {
            get { return estado_conservacion; }
            set { estado_conservacion = value; }
        }
        string especificaciones;

        /// <summary>
        /// Clase: Especificaciones
        /// </summary>
        public string Especificaciones
        {
            get { return especificaciones; }
            set { especificaciones = value; }
        }        
        #endregion

        #region Metodos
        /// <summary>
        /// Asinga un Código Nuevo 
        /// </summary>
        /// <returns>El Código Siguiente de la Ficha Espacio de Recreación</returns>
        public string nuevo_codigo()
        {
            string c = "";
            try
            {
                c = server.ejecutar_sp("GENERAR_SIGUIENTE_CODIGO",
                    server.parametro("@DOCUMENTO", SqlDbType.VarChar, 20, "RECREACION"),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, "ADMIN")).ToString();
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Nuevo Código, Ficha Catastral de Espacio de Recreación.", ex);
            }
            return c;
        }

        /// <summary>
        /// Lista todos los registros
        /// </summary>
        /// <returns>Un conjunto de datos</returns>
        public FICHA_ds listar()
        {
            try
            {
                tabla = server.ejecutar_vs("VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACION",tabla);
                tabla = server.ejecutar_vs("VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACION_CALZADAS", tabla);
                tabla = server.ejecutar_vs("VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACION_VEREDAS", tabla);
                tabla = server.ejecutar_vs("VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACION_FOTOGRAFIA", tabla);
                tabla = server.ejecutar_vs("VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACION_COMPONENTE_URBANO", tabla);
                tabla = server.ejecutar_vs("VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACION_MOBILIARIO_URBANO", tabla);
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar, Ficha Catastral de Espacio de Recreación.",ex);
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
                i = server.ejecutar("GUARDAR_FICHA_CATASTRAL_ESPACIO_RECREACION",
                    server.parametro("@FICHA", SqlDbType.VarChar,10, Ficha),                    
                    server.parametro("@PARCIAL_FICHAS", SqlDbType.Int, Parcial_Ficha),
                    server.parametro("@TOTAL_FICHAS", SqlDbType.Int, Total_Fichas),
                    server.parametro("@DEPARTAMENTO", SqlDbType.VarChar, 2, Departamento),
                    server.parametro("@PROVINCIA", SqlDbType.VarChar, 2, Provincia),
                    server.parametro("@DISTRITO", SqlDbType.VarChar, 2, Distrito),
                    server.parametro("@SECTOR", SqlDbType.VarChar, 2, Sector),
                    server.parametro("@MANZANA", SqlDbType.VarChar, 3, Manzana),
                    server.parametro("@LOTE", SqlDbType.VarChar, 3, Lote),
                    server.parametro("@NOMENCLATURA", SqlDbType.VarChar, 100, Nomenclatura),
                    server.parametro("@TOPONIMO", SqlDbType.VarChar, 100, Toponimo),
                    server.parametro("@HABILITACION_URBANA", SqlDbType.VarChar, 6, Habilitacion_Urbana.Codigo),
                    server.parametro("@ZONA_SECTOR_ETAPA", SqlDbType.VarChar, 100, Zona_Sector_Etapa),
                    server.parametro("@PUNTO_X", SqlDbType.Float, Punto_X),
                    server.parametro("@PUNTO_Y", SqlDbType.Float, Punto_Y),
                    server.parametro("@PUNTO_Z", SqlDbType.Float, Punto_Z),
                    server.parametro("@AREATOTAL", SqlDbType.Float, Area_Total),
                    server.parametro("@AREAVERDE", SqlDbType.Float, Area_Verde),
                    server.parametro("@TIPO_ESPACIO_RECREACION", SqlDbType.VarChar, 2, Tipo_Espacio_Recreacion.Codigo),
                    server.parametro("@ESTADO_CONSERVACION", SqlDbType.VarChar, 2, estado_conservacion.Codigo),
                    server.parametro("@ESPECIFICACIONES", SqlDbType.Text, Especificaciones),
                    server.parametro("@OBSERVACIONES", SqlDbType.Text, Observaciones),
                    server.parametro("@ESTADO_LLENADO_FICHA", SqlDbType.VarChar, 2, Estado_Llenado_Ficha.Codigo),
                    server.parametro("@SUPERVISOR", SqlDbType.VarChar, 8, Supervisor.DNI),
                    server.parametro("@FECHA_SUPERVISOR", SqlDbType.DateTime, Fecha_Supervisor),
                    server.parametro("@TECNICO_CATASTRAL", SqlDbType.VarChar, 8, Tecnico_Catastral.DNI),
                    server.parametro("@FECHA_TECNICO_CATASTRAL", SqlDbType.DateTime, Fecha_Tecnico_Catastral),
                    server.parametro("@VB_DIGITACION", SqlDbType.VarChar, 8, Digitacion.DNI),
                    server.parametro("@FECHA_VB_DIGITACION", SqlDbType.DateTime, Fecha_Digitacion),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Guardar, Ficha Catastral de Espacio de Recreación.", ex);
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
                i = server.ejecutar("MODIFICAR_FICHA_CATASTRAL_ESPACIO_RECREACION",
                    server.parametro("@FICHA", SqlDbType.VarChar,10, Ficha),
                    server.parametro("@PARCIAL_FICHAS", SqlDbType.Int, Parcial_Ficha),
                    server.parametro("@TOTAL_FICHAS", SqlDbType.Int, Total_Fichas),
                    server.parametro("@DEPARTAMENTO", SqlDbType.VarChar, 2, Departamento),
                    server.parametro("@PROVINCIA", SqlDbType.VarChar, 2, Provincia),
                    server.parametro("@DISTRITO", SqlDbType.VarChar, 2, Distrito),
                    server.parametro("@SECTOR", SqlDbType.VarChar, 2, Sector),
                    server.parametro("@MANZANA", SqlDbType.VarChar, 3, Manzana),
                    server.parametro("@LOTE", SqlDbType.VarChar, 3, Lote),
                    server.parametro("@NOMENCLATURA", SqlDbType.VarChar, 100, Nomenclatura),
                    server.parametro("@TOPONIMO", SqlDbType.VarChar, 100, Toponimo),
                    server.parametro("@HABILITACION_URBANA", SqlDbType.VarChar, 6, Habilitacion_Urbana.Codigo),
                    server.parametro("@ZONA_SECTOR_ETAPA", SqlDbType.VarChar, 100, Zona_Sector_Etapa),
                    server.parametro("@PUNTO_X", SqlDbType.Float, Punto_X),
                    server.parametro("@PUNTO_Y", SqlDbType.Float, Punto_Y),
                    server.parametro("@PUNTO_Z", SqlDbType.Float, Punto_Z),
                    server.parametro("@AREATOTAL", SqlDbType.Float, Area_Total),
                    server.parametro("@AREAVERDE", SqlDbType.Float, Area_Verde),
                    server.parametro("@TIPO_ESPACIO_RECREACION", SqlDbType.VarChar, 2, Tipo_Espacio_Recreacion.Codigo),
                    server.parametro("@ESTADO_CONSERVACION", SqlDbType.VarChar, 2, estado_conservacion.Codigo),
                    server.parametro("@ESPECIFICACIONES", SqlDbType.Text, Especificaciones),
                    server.parametro("@OBSERVACIONES", SqlDbType.Text, Observaciones),
                    server.parametro("@ESTADO_LLENADO_FICHA", SqlDbType.VarChar, 2, Estado_Llenado_Ficha.Codigo),
                    server.parametro("@SUPERVISOR", SqlDbType.VarChar, 8, Supervisor.DNI),
                    server.parametro("@FECHA_SUPERVISOR", SqlDbType.DateTime, Fecha_Supervisor),
                    server.parametro("@TECNICO_CATASTRAL", SqlDbType.VarChar, 8, Tecnico_Catastral.DNI),
                    server.parametro("@FECHA_TECNICO_CATASTRAL", SqlDbType.DateTime, Fecha_Tecnico_Catastral),
                    server.parametro("@VB_DIGITACION", SqlDbType.VarChar, 8, Digitacion.DNI),
                    server.parametro("@FECHA_VB_DIGITACION", SqlDbType.DateTime, Fecha_Digitacion),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Modificar, Ficha Catastral de Espacio de Recreación.", ex);
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
                i = server.ejecutar("ELIMINAR_FICHA_CATASTRAL_ESPACIO_RECREACION",
                    server.parametro("@FICHA", SqlDbType.VarChar,10, Ficha),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Eliminar, Ficha Catastral de Espacio de Recreación.",ex);
            }
            return i;
        }

        /// <summary>
        /// Reporte
        /// </summary>
        /// <returns>Un conjunto de datos</returns>
        public FICHA_ds reporte()
        {
            try
            {
                tabla = server.ejecutar_vs("VS_REPORTE_FICHA_CATASTRAL_ESPACIO_RECREACION", tabla, "FICHA", true);
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Reporte, Ficha Catastral Espacio de Recreación.", ex);
            }
            return tabla;
        }
        #endregion
    }
}
