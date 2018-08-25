namespace Componentes
{
    /// <summary>
    /// Clase Base: Sub Ficha
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    public class cSubFicha : cConexion
    {
        #region Atributos y Propioedades
        string codigo;

        /// <summary>
        /// Código 
        /// </summary>
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        string descripcion;

        /// <summary>
        /// Descripción
        /// </summary>
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        #endregion
    }
}
