using System;
using System.Drawing;
using System.Windows.Forms;
using Componentes;

namespace Formularios
{
    /// <summary>
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    internal partial class Puerta : Inicio
    {
        internal Puerta()
        {
            InitializeComponent();
        }
        
        #region Variables Globales
        cTipo_Puerta tipo_puerta = new cTipo_Puerta();
        internal string Usuario = "";
        #endregion

        #region Metodos
        bool buscar_tipo_puerta()
        {
            return tipo_puerta.buscar(tipoPuerta_txt.Text.Trim());
        }
        #endregion

        #region Eventos
        private void puerta_Load(object sender, EventArgs e)
        {
            mensaje_lbl.Text = "Ingresar datos:";
            usuario_lbl.Text = Usuario;            
            tipoPuerta_txt.AutoCompleteCustomSource.AddRange(tipo_puerta.listar_arreglo());
            tipoPuerta_txt.Focus();
        }       

        private void guardar_btn_Click(object sender, EventArgs e)
        {
            if (tipoPuerta_txt.Text.Length > 0) this.DialogResult = System.Windows.Forms.DialogResult.OK;
            else
            {
                tipoPuerta_txt.Text = "";
                tipoPuerta_txt.Focus();
            }
        }
        
        private void tipoPuerta_txt_Leave(object sender, EventArgs e)
        {
            if (tipoPuerta_txt.Text.Length > 0)
            {
                int i = (tipoPuerta_txt.Text.IndexOf('-') != -1) ? tipoPuerta_txt.Text.IndexOf('-') : tipoPuerta_txt.Text.Length + 1;
                tipoPuerta_txt.Text = (tipoPuerta_txt.Text.Length > 0) ? tipoPuerta_txt.Text.Substring(0, i - 1) : "";
                if (buscar_tipo_puerta())
                {
                    tipoPuerta_lbl.BackColor = Color.White;
                    tipoPuerta_txt.ForeColor = Color.Black;
                }
                else
                {
                    tipoPuerta_lbl.BackColor = Color.Red;
                    tipoPuerta_txt.Focus();
                    tipoPuerta_txt.SelectAll();
                    tipoPuerta_txt.ForeColor = Color.Red;
                }
            }            
        }

        private void tipoPuerta_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) numeroActual_txt.Focus();

        }
        #endregion
    }
}
