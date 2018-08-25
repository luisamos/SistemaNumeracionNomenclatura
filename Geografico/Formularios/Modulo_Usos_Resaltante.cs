using System;
using System.Windows.Forms;

namespace Formularios
{
    /// <summary>
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    internal partial class Modulo_Usos_Resaltantes : Form
    {
        internal Modulo_Usos_Resaltantes()
        {
            InitializeComponent();
        }

        #region Variables Globales
        internal string capa;
        #endregion

        #region Eventos
        private void modulo_usos_Load(object sender, EventArgs e)
        {
            string[] capas = new string[] { "USOS RESALTANTES DE VIAS URBANAS", "USOS RESALTANTES DE ESPACIOS DE RECREACION" };
            capa_cbo.Items.AddRange(capas);
            capa_cbo.SelectedIndex = 0;
        }

        private void aceptar_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (capa_cbo.SelectedIndex > -1)
                {
                    capa = capa_cbo.SelectedIndex.ToString();
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cancelar_btn_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       
        #endregion
    }
}
