using System.Windows.Forms;
using Componentes;

namespace Formularios
{
    /// <summary>
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    internal partial class Inicio : Form
    {        
        /// <summary>
        /// Captura la pantalla del Monitor.
        /// </summary>
        internal Inicio()
        {
            InitializeComponent();
        }

        #region Eventos
        private void inicio_Load(object sender, System.EventArgs e)
        {
            baseDatos_lbl.Text = cConexion.BaseDatos;
        }

        private void salir_btn_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion
    }
}
