using System;
using System.Windows.Forms;
using Componentes;

namespace Formularios
{
    /// <summary>
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    internal partial class Autenticarse : Form
    {
        internal Autenticarse()
        {
            InitializeComponent();
        }

        #region Variables Globales
        cUsuario Usuario = new cUsuario();
        internal string user = "";
        int i = 0;        
        #endregion

        #region Metodos
        void limpiar_controles()
        {
            mensaje_lbl.Text = "";
            usuario_txt.Text = "";
            contraseña_txt.Text = "";
            usuario_txt.Focus();
        }
        void salir()
        {
            Close();
        }
        #endregion

        #region Eventos
        private void autenticarse_Load(object sender, EventArgs e)
        {
            limpiar_controles();
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            try
            {                
                if (i == 3) salir();
                user = usuario_txt.Text.Trim();
                string contraseña = contraseña_txt.Text.Trim();
                if (Usuario.autenticar(user, contraseña) != "No Existe")
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    i++;
                    limpiar_controles();
                    mensaje_lbl.Text = " Error:  Usuario y/o Contraseña incorrecto.";
                    usuario_txt.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error, Autenticarse",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error, Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void usuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) contraseña_txt.Focus();
        }

        private void contraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) aceptar_Click(sender, e);            
        }

        private void validar(object sender, EventArgs e)
        {
            aceptar_btn.Enabled = usuario_txt.Text.Length > 0 && contraseña_txt.Text.Length > 0;
        }
        #endregion
    }
}
