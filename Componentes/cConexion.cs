using System.Configuration;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Xml;

namespace Componentes
{
    /// <summary>
    /// Clase: Conexion
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    public class cConexion
    {
        #region Variables Globales
        internal int i;
        static XmlElement nodo = null;        
        internal sqlServer server = new sqlServer();
        internal FICHA_ds tabla = new FICHA_ds();
        internal static Configuration configuracion = null;
        string usuario;

        /// <summary>
        /// Nombre del Usuario
        /// </summary>
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        static XmlDocument xml_doc = null;
        #endregion

        #region  Propiedades Estaticas
        static string ruta = "";
        /// <summary>
        /// Ruta donde se encuentra la Aplicación
        /// </summary>
        public static string Ruta
        {
            get
            {
                if (string.IsNullOrEmpty(ruta))
                {
                    Assembly asm = Assembly.GetExecutingAssembly();
                    FileInfo info = new FileInfo(asm.Location);
                    ruta = info.DirectoryName;
                }
                return ruta;
            }
        }
        
        /// <summary>
        /// Nombre del Servidor de Base de Datos
        /// </summary>
        public static string Servidor_Base_Datos
        {
            set { asignar("ServidorBaseDatos", value);}
            get { return retornar("ServidorBaseDatos"); }
        }

        /// <summary>
        /// Nombre de la Base de Datos
        /// </summary>
        public static string BaseDatos
        {
            set { asignar("BaseDatos", value); }
            get { return retornar("BaseDatos"); }
        }

        /// <summary>
        /// Usuario de la Base de Datos
        /// </summary>
        public static string User
        {
            set { asignar("Usuario", value); }
            get { return retornar("Usuario"); }
        }

        /// <summary>
        /// Contraseña de la Base de Datos
        /// </summary>
        public static string Password
        {
            set { asignar("Contraseña", value); }
            get { return retornar("Contraseña"); }
        }

        /// <summary>
        /// Url de Servidor Web
        /// </summary>
        public static string Servidor_Web
        {
            set { asignar("ServidorWeb", value); }
            get { return retornar("ServidorWeb"); }
        }

        /// <summary>
        ///Puerto del Servidor Web
        /// </summary>
        public static string Puerto
        {
            set { asignar("Puerto", value); }
            get { return retornar("Puerto"); }
        } 
        #endregion

        #region Metodos
        /// <summary>
        /// Carga la Configuración del XML
        /// </summary>
        public static void cargar_configuracion()
        {
            if(File.Exists(string.Format(@"{0}\query.xml", Ruta)))
            {   
                xml_doc = new XmlDocument();
                xml_doc.Load(string.Format(@"{0}\query.xml", Ruta));
                XmlNodeList personas = xml_doc.GetElementsByTagName("gpa");
                nodo = (XmlElement)((XmlElement)personas[0]).GetElementsByTagName("parametros")[0];               
            }
            else configuracion = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);            
        }

        /// <summary>
        /// Retorna un atributo especificado
        /// </summary>
        /// <param name="nombre">Nombre del Atributo</param>
        /// <returns>Retorna el nombre del Atributo</returns>
        public static string retornar(string nombre)
        {
            if (nodo != null) return nodo.GetAttribute(nombre);
            else if (configuracion != null) return configuracion.AppSettings.Settings[nombre].Value;
            else return "";          
        }

        /// <summary>
        /// Asigna el atributo especificado
        /// </summary>
        /// <param name="nombre">Nombre del Atributo</param>
        /// <param name="valor">Valor del Atributo</param>
        public static void asignar(string nombre, string valor)
        {
            if (nodo != null)nodo.Attributes[nombre].InnerText = valor;
            else if (configuracion != null) configuracion.AppSettings.Settings[nombre].Value = valor;            
        }

        /// <summary>
        /// Actualiza todos los registro modificados
        /// </summary>
        public static void actualizar()
        {
            if (xml_doc != null) xml_doc.Save(string.Format(@"{0}\query.xml", Ruta));
            else if(configuracion!= null) configuracion.Save();
        }
        #endregion    
    }
}
