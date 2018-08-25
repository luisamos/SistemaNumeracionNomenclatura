using System;

namespace Componentes
{
    /// <summary>
    /// Clase Base: Ficha
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    public class cFicha : cConexion
    {
        #region Atributos y Propiedades
        string ficha;

        /// <summary>
        /// Codigo Ficha
        /// </summary>
        public string Ficha
        {
            get { return ficha; }
            set { ficha = value; }
        }
        object numero_ficha;

        /// <summary>
        /// Número de Ficha
        /// </summary>
        public object Numero_Ficha
        {
            get { return (numero_ficha.ToString().Length == 0) ? null : (int?)Convert.ToInt32(numero_ficha); }
            set { numero_ficha = value; }
        }
        object parcial_fichas;

        /// <summary>
        /// Parcial de Ficha
        /// </summary>
        public object Parcial_Ficha
        {
            get { return (parcial_fichas.ToString().Length == 0) ? 1 : (int?)Convert.ToInt32(parcial_fichas); }
            set { parcial_fichas = value; }
        }
        object total_fichas;

        /// <summary>
        /// Total de Ficha
        /// </summary>
        public object Total_Fichas
        {
            get { return (total_fichas.ToString().Length == 0) ? 1 : (int?)Convert.ToInt32(total_fichas); }
            set { total_fichas = value; }
        }
        string codigo_unico_catastral;

        /// <summary>
        /// Código Unico Catastral (CUC)
        /// </summary>
        public string Codigo_Unico_Catastral
        {
            get { return codigo_unico_catastral; }
            set { codigo_unico_catastral = value; }
        }
        string codigo_hoja_catastral;

        /// <summary>
        /// Código de Hoja Catastral
        /// </summary>
        public string Codigo_Hoja_Catastral
        {
            get { return codigo_hoja_catastral; }
            set { codigo_hoja_catastral = value; }
        }
        string departamento;

        /// <summary>
        /// Código del Departamento
        /// </summary>
        public string Departamento
        {
            get { return departamento; }
            set { departamento = value; }
        }
        string provincia;

        /// <summary>
        /// Código de la Provincia
        /// </summary>
        public string Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }
        string distrito;

        /// <summary>
        /// Código del Distrito
        /// </summary>
        public string Distrito
        {
            get { return distrito; }
            set { distrito = value; }
        }
        string observaciones;

        /// <summary>
        /// Observaciones y/o Especificaciones y/o Notas
        /// </summary>
        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }
        cEstado_Llenado_Ficha estado_llenado_ficha;

        /// <summary>
        /// Clase: Estado de Llenado de la Ficha
        /// </summary>
        public cEstado_Llenado_Ficha Estado_Llenado_Ficha
        {
            get { return estado_llenado_ficha; }
            set { estado_llenado_ficha = value; }
        }
        cPersonal supervisor;

        /// <summary>
        /// Clase: Personal, Datos del Supervisor
        /// </summary>
        public cPersonal Supervisor
        {
            get { return supervisor; }
            set { supervisor = value; }
        }
        DateTime fecha_supervisor;

        /// <summary>
        /// Fecha de registro del Supervisor
        /// </summary>
        public DateTime Fecha_Supervisor
        {
            get { return fecha_supervisor; }
            set { fecha_supervisor = value; }
        }
        cPersonal tecnico_catastral;

        /// <summary>
        /// Clase: Personal, Datos del Técnico Catastral
        /// </summary>
        public cPersonal Tecnico_Catastral
        {
            get { return tecnico_catastral; }
            set { tecnico_catastral = value; }
        }
        DateTime fecha_tecnico_catastral;

        /// <summary>
        /// Fecha de registro del Técnico Catastral
        /// </summary>
        public DateTime Fecha_Tecnico_Catastral
        {
            get { return fecha_tecnico_catastral; }
            set { fecha_tecnico_catastral = value; }
        }
        cPersonal digitacion;

        /// <summary>
        /// Clase Personal, Datos VºBº Digitación
        /// </summary>
        public cPersonal Digitacion
        {
            get { return digitacion; }
            set { digitacion = value; }
        }
        DateTime fecha_digitacion;

        /// <summary>
        /// Fecha de registro VºBº Digitación
        /// </summary>
        public DateTime Fecha_Digitacion
        {
            get { return fecha_digitacion; }
            set { fecha_digitacion = value; }
        }
        string hash;

        /// <summary>
        /// Código de enlace de Geográfico - Alfanumérico
        /// </summary>
        public string Hash
        {
            get { return hash; }
            set { hash = value; }
        }
        #endregion
    }
}
