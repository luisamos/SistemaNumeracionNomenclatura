using System;
using System.Windows.Forms;

namespace Formularios
{
    /// <summary>
    /// Autor                   : Luis Amos - Dunia
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    internal partial class Autenticarse : Form
    {
        internal Autenticarse()
        {
            InitializeComponent();
        }

        //Metodos
        void limpiar_controles()
        {
            usuario_txt.Text = "";
            contraseña_txt.Text = "";
            usuario_txt.Focus();
        }

        #region Eventos
        private void Autenticarse_Load(object sender, EventArgs e)
        {
            limpiar_controles();
        }

        private void usuario_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)contraseña_txt.Focus();
        }

        private void contraseña_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)this.DialogResult = DialogResult.OK;
        }

        private void validar(object sender, EventArgs e)
        {
            aceptar_btn.Enabled = usuario_txt.Text.Length > 0 && contraseña_txt.Text.Length > 0;
        }
        #endregion        
    }
}
