using System.Windows.Forms;
using Componentes;

namespace Formularios
{
    /// <summary>
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    internal partial class Configuracion_Servidor_Web : Form
    {
        internal Configuracion_Servidor_Web()
        {
            InitializeComponent();
        }

        #region Eventos
        private void configuracion_base_datos_Load(object sender, System.EventArgs e)
        {
            cConexion.cargar_configuracion();
            servidor_txt.Text = cConexion.Servidor_Web;
            puerto_txt.Text = cConexion.Puerto;
            
        }

        private void aceptar_btn_Click(object sender, System.EventArgs e)
        {
            cConexion.Servidor_Web = servidor_txt.Text;
            cConexion.Puerto = puerto_txt.Text;
            
            cConexion.actualizar();
            Close();
        }
        #endregion
    }
}
