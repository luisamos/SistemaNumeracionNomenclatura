using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using Componentes;

namespace Formularios
{
    /// <summary>
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    internal partial class Modulo_Componente_Urbano_Mobiliario_Urbano : Form
    {
        internal Modulo_Componente_Urbano_Mobiliario_Urbano()
        {
            InitializeComponent();
        }

        #region Variables Globales
        cVias vias = new cVias();        
        #endregion

        #region Eventos
        private void Modulo_Componente_Urbano_Mobiliario_Urbano_Load(object sender, EventArgs e)
        {
            try
            {
                codigoVias_txt.AutoCompleteCustomSource.Clear();
                codigoVias_txt.AutoCompleteCustomSource.AddRange(vias.listar_arreglo());
                codigoVias_txt.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error:  Componente Urbano - Mobiliario Urbano", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void codigoVias_txt_Leave(object sender, EventArgs e)
        {
            int i = (codigoVias_txt.Text.IndexOf('-') != -1) ? codigoVias_txt.Text.IndexOf('-') : codigoVias_txt.Text.Length + 1;
            codigoVias_txt.Text = (codigoVias_txt.Text.Length > 0) ? codigoVias_txt.Text.Substring(0, i - 1) : "";
            DataRow fila = vias.Buscar(codigoVias_txt.Text.Trim());
            if (fila != null)
            {
                codVias_lbl.BackColor = Color.White;
                codigoVias_txt.ForeColor = Color.Black;
                string direccion = fila["LISTA"].ToString();
                direccion_lbl.Text = direccion.Substring(direccion.IndexOf('-') + 1).Replace('-', ' ');
            }
            else
            {
                codVias_lbl.BackColor = Color.Red;
                codigoVias_txt.Focus();
                codigoVias_txt.SelectAll();
                codigoVias_txt.ForeColor = Color.Red;
                direccion_lbl.Text = "";
            }
            validar_TextChanged(sender, e);
        }

        private void cuadra_txt_Leave(object sender, EventArgs e)
        {
            if (cuadra_txt.Text.Length == 2)
            {
                cuadra_lbl.BackColor = Color.White;
                cuadra_txt.ForeColor = Color.Black;
            }
            else
            {
                cuadra_lbl.BackColor = Color.Red;
                cuadra_txt.Focus();
                cuadra_txt.SelectAll();
                cuadra_txt.ForeColor = Color.Red;
            }
            validar_TextChanged(sender, e);
        }

        private void validar_TextChanged(object sender, EventArgs e)
        {
            aceptar_btn.Enabled = codigoVias_txt.Text.Length ==3 && cuadra_txt.Text.Length ==2;
        }

        private void enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
            if (e.KeyData == Keys.Escape)
            {
                SendKeys.Send("+{TAB}");
            }
            else
            {
                base.OnKeyDown(e);
            }
        }

        private void aceptar_btn_Click(object sender, EventArgs e)
        {
            if (codigoVias_txt.Text.Length !=3)
            {
                codigoVias_txt_Leave(sender, e);
                return;
            }
            if (cuadra_txt.Text.Length !=2)
            {
                cuadra_txt_Leave(sender, e);
                return;
            }

            if (codVias_lbl.BackColor != Color.Red && cuadra_lbl.BackColor != Color.Red)
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        #endregion
    }
}
