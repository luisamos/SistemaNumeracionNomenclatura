using System;
using System.Data;
using System.Drawing;
using System.IO;

namespace Componentes
{
    /// <summary>
    /// Ficha Catastral de Equipamiento Urbano
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    public class cFicha_Catastral_Equipamiento_Urbano : cFicha
    {
        #region Atributos y Propiedades
        string sector;

        /// <summary>
        /// Código del Sector
        /// </summary>
        public string Sector
        {
            get { return sector; }
            set { sector = value; }
        }
        string manzana;

        /// <summary>
        /// Código de Manzana
        /// </summary>
        public string Manzana
        {
            get { return manzana; }
            set { manzana = value; }
        }
        string lote;

        /// <summary>
        /// Código de Lote
        /// </summary>
        public string Lote
        {
            get { return lote; }
            set { lote = value; }
        }
        string edifica;

        /// <summary>
        /// Código Edifica
        /// </summary>
        public string Edifica
        {
            get { return edifica; }
            set { edifica = value; }
        }
        string entrada;

        /// <summary>
        /// Código Entrada
        /// </summary>
        public string Entrada
        {
            get { return entrada; }
            set { entrada = value; }
        }
        string piso;

        /// <summary>
        /// Código Piso
        /// </summary>
        public string Piso
        {
            get { return piso; }
            set { piso = value; }
        }
        string unidad;

        /// <summary>
        /// Código Unidad
        /// </summary>
        public string Unidad
        {
            get { return unidad; }
            set { unidad = value; }
        }

        
        /// <summary>
        /// Dígito de Control
        /// </summary>
        public string Digito_Control
        {
            get
            {
                return ((((Departamento.Length > 0) ? Convert.ToInt32(Departamento[0]) + Convert.ToInt32(Departamento[1]) : 0) +
                       ((Provincia.Length > 0) ? Convert.ToInt32(Provincia[0]) + Convert.ToInt32(Provincia[1]) : 0) +
                       ((Distrito.Length > 0) ? Convert.ToInt32(Distrito[0]) + Convert.ToInt32(Distrito[1]) : 0) +
                       ((sector.Length > 0) ? Convert.ToInt32(sector[0]) + Convert.ToInt32(sector[1]) : 0) +
                       ((manzana.Length > 0) ? Convert.ToInt32(manzana[0]) + Convert.ToInt32(manzana[1]) + Convert.ToInt32(manzana[2]) : 0) +
                       ((lote.Length > 0) ? Convert.ToInt32(lote[0]) + Convert.ToInt32(lote[1]) + Convert.ToInt32(lote[2]) : 0) +
                       ((edifica.Length > 0) ? Convert.ToInt32(edifica[0]) + Convert.ToInt32(edifica[1]) : 0) +
                       ((entrada.Length > 0) ? Convert.ToInt32(entrada[0]) + Convert.ToInt32(entrada[1]) : 0) +                       
                       ((piso.Length > 0) ? Convert.ToInt32(piso[0]) + Convert.ToInt32(piso[1]) : 0) +
                       ((unidad.Length > 0) ? Convert.ToInt32(unidad[0]) + Convert.ToInt32(unidad[1]) + Convert.ToInt32(unidad[2]) : 0)) % 9).ToString();
            }  
        }
        string nombre_equipamiento_urbano;

        /// <summary>
        /// Nombre de Equipamiento
        /// </summary>
        public string Nombre_Equipamiento_Urbano
        {
            get { return nombre_equipamiento_urbano; }
            set { nombre_equipamiento_urbano = value; }
        }
        cTipo_Equipamiento_Urbano tipo_equipamiento_urbano;

        /// <summary>
        /// Clase: Tipo Equipamiento Urbano
        /// </summary>
        public cTipo_Equipamiento_Urbano Tipo_Equipamiento_Urbano
        {
            get { return tipo_equipamiento_urbano; }
            set { tipo_equipamiento_urbano = value; }
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
        cHabilitacion_Urbana habilitacion_urbana;

        /// <summary>
        /// Clase: Habilitacion Urbana
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
        string manzana1;

        /// <summary>
        /// Código Sub Manzana
        /// </summary>
        public string Manzana1
        {
            get { return manzana1; }
            set { manzana1 = value; }
        }
        string lote1;

        /// <summary>
        /// Código Sub Lote
        /// </summary>
        public string Lote1
        {
            get { return lote1; }
            set { lote1 = value; }
        }
        string sub_lote;

        /// <summary>
        /// Código de SubLote
        /// </summary>
        public string Sub_Lote
        {
            get { return sub_lote; }
            set { sub_lote = value; }
        }
        cUsos usos;

        /// <summary>
        /// Clase: Usos
        /// </summary>
        public cUsos Usos
        {
            get { return usos; }
            set { usos = value; }
        }        
        #endregion

        #region Metodos
        /// <summary>
        /// Asinga un Código Nuevo 
        /// </summary>
        /// <returns>El Código Siguiente de la Ficha Especificada</returns>
        public string nuevo_codigo()
        {
            string c ="";
            try
            {   
                c = server.ejecutar_sp("GENERAR_SIGUIENTE_CODIGO",
                    server.parametro("@DOCUMENTO", SqlDbType.VarChar, 20, "EQUIPAMIENTO"),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, "ADMIN")).ToString();
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Nuevo Código, ficha Catastral de Equipamiento Urbano.", ex);
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
                tabla = server.ejecutar_vs("VS_LISTAR_FICHA_CATASTRAL_EQUIPAMIENTO_URBANO",tabla, "NUMERO DE FICHA", true);
                tabla = server.ejecutar_vs("VS_LISTAR_FICHA_CATASTRAL_EQUIPAMIENTO_URBANO_UBICACION", tabla);
                tabla = server.ejecutar_vs("VS_LISTAR_FICHA_CATASTRAL_EQUIPAMIENTO_URBANO_FOTOGRAFIA", tabla);
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar, ficha Catastral de Equipamiento Urbano.", ex);
            }
            return tabla;
        }

        /// <summary>
        /// Guarda un Registro
        /// </summary>
        /// <param name="planoUbicacion">Fotografía del Plano de Ubicación</param>
        /// <param name="añoPlanoUbicacion">Año del registro del Plano de Ubicación</param>        
        /// <param name="fotografia">Fotografía de la Via</param>
        /// <param name="añoFotografia">Año del registro de la Fotografía</param>
        /// <returns>El número de Filas Afectadas</returns>
        public string guardar(Image planoUbicacion, string añoPlanoUbicacion, string fotografia, string añoFotografia)
        {
            string rpta;
            try
            {
                rpta = server.ejecutar_sp("GUARDAR_RESUMIDO_FICHA_CATASTRAL_EQUIPAMIENTO_URBANO",                    
                    server.parametro("@DEPARTAMENTO", SqlDbType.VarChar, 2, Departamento),
                    server.parametro("@PROVINCIA", SqlDbType.VarChar, 2, Provincia),
                    server.parametro("@DISTRITO", SqlDbType.VarChar, 2, Distrito),
                    server.parametro("@SECTOR", SqlDbType.VarChar, 2, sector),
                    server.parametro("@MANZANA", SqlDbType.VarChar, 3, manzana),
                    server.parametro("@LOTE", SqlDbType.VarChar, 3, lote),
                    server.parametro("@NOMBRE_EQUIPAMIENTO_URBANO", SqlDbType.Text, nombre_equipamiento_urbano),
                    server.parametro("@TIPO_EQUIPAMIENTO_URBANO", SqlDbType.VarChar, 2, tipo_equipamiento_urbano.Codigo),
                    server.parametro("@USOS", SqlDbType.VarChar, 6, usos.Codigo),
                    server.parametro("@PUNTO_X", SqlDbType.Decimal, Punto_X),
                    server.parametro("@PUNTO_Y", SqlDbType.Decimal, Punto_Y),
                    server.parametro("@PUNTO_Z", SqlDbType.Decimal, Punto_Z),
                    server.parametro("@PLANO_UBICACION", SqlDbType.VarBinary, (planoUbicacion != null) ? cConfiguracion.toBytes(planoUbicacion) : null),
                    server.parametro("@AÑO_PLANO_UBICACION", SqlDbType.VarChar, 4, añoPlanoUbicacion),
                    server.parametro("@FOTOGRAFIA", SqlDbType.VarBinary, (fotografia != "") ? File.ReadAllBytes(fotografia) : null),
                    server.parametro("@AÑO_FOTOGRAFIA", SqlDbType.VarChar, 4, añoFotografia),   
                    server.parametro("@HASH",SqlDbType.VarChar,36,Hash),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario)).ToString();
            }
            catch (Exception ex)
            {
                rpta= "";
                throw new sqlServerException("Error Guardar Resumido, ficha Catastral de Equipamiento Urbano. ", ex);
            }
            return rpta;
        }

        /// <summary>
        /// Guardar un Registro
        /// </summary>
        /// <returns>El número de filas Afectadas</returns>
        public int guardar()
        {
            try
            {
                i = server.ejecutar("GUARDAR_FICHA_CATASTRAL_EQUIPAMIENTO_URBANO",
                    server.parametro("@FICHA", SqlDbType.VarChar,10, Ficha),
                    server.parametro("@PARCIAL_FICHAS", SqlDbType.BigInt, Parcial_Ficha),
                    server.parametro("@TOTAL_FICHAS", SqlDbType.Int, Total_Fichas),
                    server.parametro("@CODIGO_UNICO_CATASTRAL", SqlDbType.VarChar, 12, Codigo_Unico_Catastral),
                    server.parametro("@CODIGO_HOJA_CATASTRAL", SqlDbType.VarChar, 10, Codigo_Hoja_Catastral),
                    server.parametro("@DEPARTAMENTO", SqlDbType.VarChar, 2, Departamento),
                    server.parametro("@PROVINCIA", SqlDbType.VarChar, 2, Provincia),
                    server.parametro("@DISTRITO", SqlDbType.VarChar, 2, Distrito),
                    server.parametro("@SECTOR", SqlDbType.VarChar, 2, Sector),
                    server.parametro("@MANZANA", SqlDbType.VarChar, 3, Manzana),
                    server.parametro("@LOTE", SqlDbType.VarChar, 3, Lote),
                    server.parametro("@EDIFICA", SqlDbType.VarChar, 2, Edifica),
                    server.parametro("@ENTRADA", SqlDbType.VarChar, 2, Entrada),
                    server.parametro("@PISO", SqlDbType.VarChar, 2, Piso),
                    server.parametro("@UNIDAD", SqlDbType.VarChar, 3, Unidad),
                    server.parametro("@DIGITO_CONTROL", SqlDbType.VarChar, 2, Digito_Control),
                    server.parametro("@NOMBRE_EQUIPAMIENTO_URBANO", SqlDbType.VarChar,8000, Nombre_Equipamiento_Urbano),
                    server.parametro("@TIPO_EQUIPAMIENTO_URBANO", SqlDbType.VarChar, 2, Tipo_Equipamiento_Urbano.Codigo),
                    server.parametro("@PUNTO_X", SqlDbType.Float, Punto_X),
                    server.parametro("@PUNTO_Y", SqlDbType.Float, Punto_Y),
                    server.parametro("@PUNTO_Z", SqlDbType.Float, Punto_Z),
                    server.parametro("@HABILITACION_URBANA", SqlDbType.VarChar, 6, Habilitacion_Urbana.Codigo),
                    server.parametro("@ZONA_SECTOR_ETAPA", SqlDbType.VarChar, 100, Zona_Sector_Etapa),
                    server.parametro("@MANZANA1", SqlDbType.VarChar, 15, Manzana1),
                    server.parametro("@LOTE1", SqlDbType.VarChar, 15, Lote1),
                    server.parametro("@SUB_LOTE", SqlDbType.VarChar, 15, Sub_Lote),
                    server.parametro("@USOS", SqlDbType.VarChar, 6, Usos.Codigo),
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
                throw new sqlServerException("Error Guardar, Ficha Catastral de Equipamiento Urbano. ",ex);
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
                i = server.ejecutar("MODIFICAR_FICHA_CATASTRAL_EQUIPAMIENTO_URBANO",
                    server.parametro("@FICHA", SqlDbType.VarChar, 10, Ficha),
                    server.parametro("@PARCIAL_FICHAS", SqlDbType.BigInt, Parcial_Ficha),
                    server.parametro("@TOTAL_FICHAS", SqlDbType.Int, Total_Fichas),
                    server.parametro("@CODIGO_UNICO_CATASTRAL", SqlDbType.VarChar, 12, Codigo_Unico_Catastral),
                    server.parametro("@CODIGO_HOJA_CATASTRAL", SqlDbType.VarChar, 10, Codigo_Hoja_Catastral),
                    server.parametro("@DEPARTAMENTO", SqlDbType.VarChar, 2, Departamento),
                    server.parametro("@PROVINCIA", SqlDbType.VarChar, 2, Provincia),
                    server.parametro("@DISTRITO", SqlDbType.VarChar, 2, Distrito),
                    server.parametro("@SECTOR", SqlDbType.VarChar, 2, Sector),
                    server.parametro("@MANZANA", SqlDbType.VarChar, 3, Manzana),
                    server.parametro("@LOTE", SqlDbType.VarChar, 3, Lote),
                    server.parametro("@EDIFICA", SqlDbType.VarChar, 2, Edifica),
                    server.parametro("@ENTRADA", SqlDbType.VarChar, 2, Entrada),
                    server.parametro("@PISO", SqlDbType.VarChar, 2, Piso),
                    server.parametro("@UNIDAD", SqlDbType.VarChar, 3, Unidad),
                    server.parametro("@DIGITO_CONTROL", SqlDbType.VarChar, 2, Digito_Control),
                    server.parametro("@NOMBRE_EQUIPAMIENTO_URBANO", SqlDbType.VarChar, 8000, Nombre_Equipamiento_Urbano),
                    server.parametro("@TIPO_EQUIPAMIENTO_URBANO", SqlDbType.VarChar, 2, Tipo_Equipamiento_Urbano.Codigo),
                    server.parametro("@PUNTO_X", SqlDbType.Float, Punto_X),
                    server.parametro("@PUNTO_Y", SqlDbType.Float, Punto_Y),
                    server.parametro("@PUNTO_Z", SqlDbType.Float, Punto_Z),
                    server.parametro("@HABILITACION_URBANA", SqlDbType.VarChar, 6, Habilitacion_Urbana.Codigo),
                    server.parametro("@ZONA_SECTOR_ETAPA", SqlDbType.VarChar, 100, Zona_Sector_Etapa),
                    server.parametro("@MANZANA1", SqlDbType.VarChar, 15, Manzana1),
                    server.parametro("@LOTE1", SqlDbType.VarChar, 15, Lote1),
                    server.parametro("@SUB_LOTE", SqlDbType.VarChar, 15, Sub_Lote),
                    server.parametro("@USOS", SqlDbType.VarChar, 6, Usos.Codigo),
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
                throw new sqlServerException("Error Modificar, Ficha Catastral de Equipamiento Urbano. ", ex);
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
                i= server.ejecutar("ELIMINAR_FICHA_CATASTRAL_EQUIPAMIENTO_URBANO",
                    server.parametro("@FICHA", SqlDbType.VarChar, 10,Ficha),                  
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Eliminar, Ficha Catastral de Equipamiento Urbano. ", ex);
                
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
                tabla = server.ejecutar_vs("VS_REPORTE_FICHA_CATASTRAL_EQUIPAMIENTO_URBANO", tabla, "FICHA", true);                
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Reporte, Ficha Catastral de Equipamiento Urbano.", ex);
            }
            return tabla;
        }
        #endregion
    }
}
