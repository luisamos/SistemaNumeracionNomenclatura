using System;
using System.Drawing;
using System.IO;
using System.Diagnostics;

namespace Componentes
{
    /// <summary>
    /// Clase: Configuración
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    public class cConfiguracion : cConexion
    {
        #region Propiedades
        /// <summary>
        /// Nombre de la Municipalidad
        /// </summary>
        public static string Municipalidad
        {
            set { asignar("Municipio", value); }
            get { return retornar("Municipio"); }
        }

        /// <summary>
        /// Logotipo de la Municipalidad
        /// </summary>
        public static string Logo
        {
            set { asignar("Logo", value); }
            get { return retornar("Logo"); }
        }

        /// <summary>
        /// Nombre del Alcalde
        /// </summary>
        public static string Alcalde
        {
            set { asignar("Alcalde", value); }
            get { return retornar("Alcalde"); }
        }

        /// <summary>
        /// Dirección de la Municipalidad
        /// </summary>
        public static string Direccion
        {
            set { asignar("Direccion", value); }
            get { return retornar("Direccion"); }
        }

        /// <summary>
        /// R.U.C de la Municipalidad
        /// </summary>
        public static string Ruc
        {
            set { asignar("Ruc", value); }
            get { return retornar("Ruc"); }
        }

        /// <summary>
        /// Teléfono de la Municipalidad
        /// </summary>
        public static string Telefono
        {
            set { asignar("Telefono", value); }
            get { return retornar("Telefono"); }
        }

        /// <summary>
        /// Correo Electrónico
        /// </summary>
        public static string Correo_Electronico
        {
            set { asignar("CorreoElectronico", value); }
            get { return retornar("CorreoElectronico"); }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Convierte un arrego Byte a formato de Imagen
        /// </summary>
        /// <param name="value"> Byte code Imagen</param>
        /// <returns>Image</returns>
        public static Image toImage(Byte[] value)
        {
            try
            {
                MemoryStream ms = new MemoryStream(value);
                Bitmap bm = null;
                bm = new Bitmap(ms);
                return bm;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Convierte una imagen a un arreglo de byte
        /// </summary>
        /// <param name="imagen">Imagen que desea convertir</param>
        /// <returns>Un arreglo de byte</returns>
        public static byte[] toBytes(Image imagen)
        {
            string sTemp = Path.GetTempFileName();
            FileStream fs = new FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            imagen.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
            fs.Position = 0;
            //
            int imgLength = Convert.ToInt32(fs.Length);
            byte[] bytes = new byte[imgLength];
            fs.Read(bytes, 0, imgLength);
            fs.Close();
            return bytes;
        }

        /// <summary>
        /// Abre un archivo específico
        /// </summary>
        /// <param name="ruta">La ruta del archivo</param>
        public static void abrir(string ruta)
        {
            if(File.Exists(ruta))
            {    
                Process proceso = new Process();
                proceso.StartInfo.FileName = ruta;
                proceso.Start();
                proceso.Close();
            }
        }
        #endregion
    }
}
