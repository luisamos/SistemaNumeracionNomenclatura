using System;
using System.Windows.Forms;

namespace Alfanumerico
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.        
        /// Autor                   : Luis Amos
        /// Fecha de Creación       : 01 - 02 - 2011
        /// Fecha de Modificación   : 21 - 02 - 2012
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Formularios.Principal());
        }
    }
}
