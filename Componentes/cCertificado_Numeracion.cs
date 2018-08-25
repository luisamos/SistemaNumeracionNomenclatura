using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace Componentes
{
    /// <summary>
    /// Clase: Certificado de Numeración
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    public class cCertificado_Numeracion : cSubFicha
    {
        #region Atributos y Propiedades
        long id;

        /// <summary>
        /// Identificador del Certificado de Numeración
        /// </summary>
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        int codigo_puerta;

        /// <summary>
        /// C{odigo de la Puerta
        /// </summary>
        public int Codigo_Puerta
        {
            get { return codigo_puerta; }
            set { codigo_puerta = value; }
        }        
        DateTime fecha;

        /// <summary>
        /// Fecha de Certificación
        /// </summary>
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        string sigla;

        /// <summary>
        /// Siglas de la Numeración
        /// </summary>
        public string Sigla
        {
            get { return sigla; }
            set { sigla = value; }
        }
        string numero_expediente;

        /// <summary>
        /// Número de Expediente
        /// </summary>
        public string Numero_Expediente
        {
            get { return numero_expediente; }
            set { numero_expediente = value; }
        }
        Image fotografia_digital;

        /// <summary>
        /// Fotografía Digital
        /// </summary>
        public Image Fotografia_Digital
        {
            get { return fotografia_digital; }
            set { fotografia_digital = value; }
        }
        string año_fotografia_digital;

        /// <summary>
        /// Año de la Fotografía Digital
        /// </summary>
        public string Año_Fotografia_Digital
        {
            get { return año_fotografia_digital; }
            set { año_fotografia_digital = value; }
        }
        string cuerpo;

        /// <summary>
        /// Cuerpo del Certificado de Numeración
        /// </summary>
        public string Cuerpo
        {
            get { return cuerpo; }
            set { cuerpo = value; }
        }
        string propietario;

        /// <summary>
        /// Propietario a quien pertenece el inmueble
        /// </summary>
        public string Propietario
        {
            get { return propietario; }
            set { propietario = value; }
        }
        string numero_recibo;

        /// <summary>
        /// Número de Recibo
        /// </summary>
        public string Numero_Recibo
        {
            get { return numero_recibo; }
            set { numero_recibo = value; }
        }
        string observaciones;        

        /// <summary>
        /// Observaciones
        /// </summary>
        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
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
                tabla = server.ejecutar_vs("VS_LISTAR_CERTIFICADO_NUMERACION", tabla);
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar, Certificado de Numeración. ", ex);
            }
            return tabla;
        }

        /// <summary>
        /// Guardar un Registro
        /// </summary>
        /// <returns>El número de filas Afectadas</returns>
        public string guardar()
        {
            string j = "";
            try
            {
                 j = server.ejecutar_sp("GUARDAR_CERTIFICADO_NUMERACION",
                    server.parametro("@CODIGO_PUERTA",SqlDbType.Int, codigo_puerta),                    
                    server.parametro("@FECHA",SqlDbType.DateTime,fecha),
                    server.parametro("@SIGLA",SqlDbType.VarChar,20,sigla),
                    server.parametro("@NUMERO_EXPEDIENTE",SqlDbType.VarChar,100,numero_expediente), 
                    server.parametro("@FOTOGRAFIA_DIGITAL",SqlDbType.VarBinary,(fotografia_digital != null) ? cConfiguracion.toBytes(fotografia_digital) : null), 
                    server.parametro("@AÑO_FOTOGRAFIA_DIGITAL",SqlDbType.VarChar,4,(año_fotografia_digital.Length ==0)?DateTime.Now.Year.ToString():año_fotografia_digital),
                    server.parametro("@CUERPO",SqlDbType.Text,cuerpo),
                    server.parametro("@PROPIETARIO",SqlDbType.VarChar,100,propietario),
                    server.parametro("@NUMERO_RECIBO",SqlDbType.VarChar,100,numero_recibo),
                    server.parametro("@OBSERVACIONES",SqlDbType.VarChar,300,observaciones),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario)).ToString();
            }
            catch (Exception ex)
            {                
                throw new sqlServerException("Error Guardar, Certificado de Numeración. ", ex);
            }
            return j;
        }

        /// <summary>
        /// Modifica un Registro
        /// </summary>
        /// <returns>El número de filas Afectadas</returns>
        public int modificar()
        {
            try
            {
                i = server.ejecutar("MODIFICAR_CERTIFICADO_NUMERACION",
                    server.parametro("@ID", SqlDbType.BigInt,id),
                    server.parametro("@CODIGO_PUERTA", SqlDbType.Int, codigo_puerta),
                    server.parametro("@FECHA", SqlDbType.DateTime, fecha),
                    server.parametro("@SIGLA", SqlDbType.VarChar, 20, sigla),
                    server.parametro("@NUMERO_EXPEDIENTE", SqlDbType.VarChar, 100, numero_expediente),
                    server.parametro("@FOTOGRAFIA_DIGITAL", SqlDbType.VarBinary, (fotografia_digital != null) ? cConfiguracion.toBytes(fotografia_digital) : null),
                    server.parametro("@AÑO_FOTOGRAFIA_DIGITAL", SqlDbType.VarChar, 4, (año_fotografia_digital.Length == 0) ? DateTime.Now.Year.ToString() : año_fotografia_digital),
                    server.parametro("@CUERPO", SqlDbType.Text, cuerpo),
                    server.parametro("@PROPIETARIO", SqlDbType.VarChar, 100, propietario),
                    server.parametro("@NUMERO_RECIBO", SqlDbType.VarChar, 100, numero_recibo),
                    server.parametro("@OBSERVACIONES", SqlDbType.VarChar, 300, observaciones),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Modificar, Certificado de Numeración. ", ex);
            }
            return i;
        }

        /// <summary>
        /// Busca un registro especificado
        /// </summary>
        /// <param name="pCodigo_Puerta">El código del elemento a buscar</param>
        /// <returns>Si existe en la tabla</returns>
        public List<FICHA_ds.VS_LISTAR_CERTIFICADO_NUMERACIONRow> buscar(int pCodigo_Puerta)
        {
            if (tabla.VS_LISTAR_CERTIFICADO_NUMERACION.Rows.Count == 0) listar();
            EnumerableRowCollection<FICHA_ds.VS_LISTAR_CERTIFICADO_NUMERACIONRow> query = from c in tabla.VS_LISTAR_CERTIFICADO_NUMERACION.AsEnumerable()
                                                                                          where c.CODIGO_PUERTA == pCodigo_Puerta
                                                                                          select c;

            return query.ToList();
        }
        #endregion
    }
}