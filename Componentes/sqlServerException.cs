using System;
using System.Text;

namespace Componentes
{
    /// <summary>
    /// Representa un error de acceso a la base de datos Sql Server.
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    public class sqlServerException : ApplicationException
    {
        /// <summary>
        /// Construye una instancia en base a un mensaje de error y la una excepción original.
        /// </summary>        
        /// <param name="original">La Excepción Original.</param>
        public sqlServerException(Exception original) : base(string.Format("Error: {0}", original.Message)) { } 

        /// <summary>
        /// Construye una instancia en base a un mensaje de error y la una excepción original.
        /// </summary>
        /// <param name="mensaje">El Mensaje de Error.</param>
        /// <param name="original">La Excepción Original.</param>
        public sqlServerException(string mensaje, Exception original) : base(string.Format("{0}\n{1}",mensaje, original.Message)) { }       
    }
}
