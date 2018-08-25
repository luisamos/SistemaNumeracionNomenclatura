using System.Windows.Forms;
using Componentes;

namespace Formularios
{
    /// <summary>
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    internal partial class Configuracion_Servidor_Base_Datos : Form
    {
        internal Configuracion_Servidor_Base_Datos()
        {
            InitializeComponent();
        }

        #region Eventos
        private void configuracion_base_datos_Load(object sender, System.EventArgs e)
        {
            cConexion.cargar_configuracion();
            servidor_txt.Text = cConexion.Servidor_Base_Datos;
            baseDatos_txt.Text = cConexion.BaseDatos;
            usuario_txt.Text = cConexion.User;
            contraseña_txt.Text = cConexion.Password;
        }

        private void aceptar_btn_Click(object sender, System.EventArgs e)
        {
            cConexion.Servidor_Base_Datos = servidor_txt.Text;
            cConexion.BaseDatos = baseDatos_txt.Text;
            cConexion.User = usuario_txt.Text;
            cConexion.Password = contraseña_txt.Text;
            cConexion.actualizar();
            Close();
        }
        #endregion
    }
}
