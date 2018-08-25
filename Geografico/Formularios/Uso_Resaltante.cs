using System;
using System.Drawing;
using System.Windows.Forms;
using Componentes;

namespace Formularios
{
    internal partial class Uso_Resaltante : Form
    {
        /// <summary>
        /// Autor                   : Luis Amos
        /// Fecha de Creación       : 01 - 02 - 2011
        /// Fecha de Modificación   : 21 - 02 - 2012
        /// </summary>
        internal Uso_Resaltante()
        {
            InitializeComponent();
        }

        #region Variables Globales
        cTipo_Uso_Resaltante tipo_uso_resaltante = new cTipo_Uso_Resaltante();
        cClasificacion_Uso_Resaltante clasificacion_uso_resaltante = new cClasificacion_Uso_Resaltante();
        internal string Usuario;
        internal string Capa="";
        #endregion

        #region Metodos
        void listar_tipo_uso_resaltante()
        {
            tipoUsoResaltante_txt.AutoCompleteCustomSource.AddRange(tipo_uso_resaltante.listar_arreglo());
        }
        void listar_clasificacion_uso_resaltante()
        {
            clasificacionUsoResaltante_txt.AutoCompleteCustomSource.Clear();
            clasificacionUsoResaltante_txt.Text = "";
            clasificacionUsoResaltante_txt.AutoCompleteCustomSource.AddRange(clasificacion_uso_resaltante.listar_arreglo(tipoUsoResaltante_txt.Text));
            clasificacionUsoResaltante_txt.Enabled = (clasificacionUsoResaltante_txt.AutoCompleteCustomSource.Count > 0) ? true: false;
            if (clasificacionUsoResaltante_txt.Enabled) clasificacionUsoResaltante_txt.Focus();
            else direccion_txt.Focus();
        }
        bool buscar_tipo_uso_resaltante()
        {
            return tipo_uso_resaltante.buscar(tipoUsoResaltante_txt.Text);
        }
        bool buscar_clasificacion_uso_resaltante()
        {
            return clasificacion_uso_resaltante.buscar(tipoUsoResaltante_txt.Text,clasificacionUsoResaltante_txt.Text);
        }
        #endregion

        #region Eventos
        private void uso_resaltante_Load(object sender, EventArgs e)
        {
            switch (Capa)
            {
                case "0":
                    codigoVia_manzana_lbl.Text = "CODIGO DE VIA";
                    cuadra_lote_lbl.Text = "CUADRA";
                    cuadra_lote_txt.Enabled = false;
                    break;
                case "1":
                    codigoVia_manzana_lbl.Text = "MANZANA";
                    cuadra_lote_lbl.Text = "LOTE";
                    cuadra_lote_txt.Enabled = true;                    
                    break; 
            }
            usuario_lbl.Text = Usuario;
            baseDatos_lbl.Text = cConexion.BaseDatos;
            listar_tipo_uso_resaltante();
            if (cuadra_lote_txt.Enabled) cuadra_lote_txt.Focus();
            else direccion_txt.Focus();
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

        private void cuadra_lote_txt_Leave(object sender, EventArgs e)
        {
            if (!cuadra_lote_txt.Enabled)
            {
                if (cuadra_lote_txt.Text.Length == 3 || cuadra_lote_txt.Text.Length == 0)
                {
                    cuadra_lote_lbl.BackColor = Color.LemonChiffon;
                    cuadra_lote_txt.ForeColor = Color.Black;
                }
                else
                {
                    cuadra_lote_lbl.BackColor = Color.Red;
                    cuadra_lote_txt.ForeColor = Color.Red;
                    cuadra_lote_txt.Focus();
                    cuadra_lote_txt.SelectAll();
                    
                }
            }
        }
                
        private void tipoUsoResaltante_txt_Leave(object sender, EventArgs e)
        {
            tipoUsoResaltante_txt.Text = (tipoUsoResaltante_txt.Text.Length >= 2) ? tipoUsoResaltante_txt.Text.Substring(0, 2) : "";
            if (!buscar_tipo_uso_resaltante())
            {
                tipoUsoResaltante_lbl.BackColor = Color.Red;
                tipoUsoResaltante_txt.ForeColor = Color.Red;
                tipoUsoResaltante_txt.Focus();
                tipoUsoResaltante_txt.SelectAll();                
            }
            else
            {
                tipoUsoResaltante_lbl.BackColor = Color.LemonChiffon;
                tipoUsoResaltante_txt.ForeColor = Color.Black;
                listar_clasificacion_uso_resaltante();
            }
        }

        private void clasificacionUsoResaltante_txt_Leave(object sender, EventArgs e)
        {
            if (clasificacionUsoResaltante_txt.AutoCompleteCustomSource.Count > 0)
            {
                clasificacionUsoResaltante_txt.Text = (clasificacionUsoResaltante_txt.Text.Length >= 2) ? clasificacionUsoResaltante_txt.Text.Substring(0, 2) : "";
                if (!buscar_clasificacion_uso_resaltante())
                {
                    clasificacionUsoResaltante_lbl.BackColor = Color.Red;
                    clasificacionUsoResaltante_txt.ForeColor = Color.Red;
                    clasificacionUsoResaltante_txt.Focus();
                    clasificacionUsoResaltante_txt.SelectAll();
                    
                }
                else
                {
                    clasificacionUsoResaltante_lbl.BackColor = Color.LemonChiffon;
                    clasificacionUsoResaltante_txt.ForeColor = Color.Black;
                }
            }
        }

        private void direccion_txt_Leave(object sender, EventArgs e)
        {
            if (direccion_txt.Text.Length == 0)
            {
                direccion_txt.ForeColor = Color.Red;
                direccion_lbl.BackColor = Color.Red;
                direccion_txt.Focus();
            }
            else
            {                
                direccion_lbl.BackColor = Color.LemonChiffon;
                direccion_txt.ForeColor = Color.Black;
            }
        }

        private void especificaciones_txt_Leave(object sender, EventArgs e)
        {
            if (especificaciones_txt.Text.Length == 0)
            {
                especificaciones_txt.ForeColor = Color.Red;
                especificaciones_lbl.BackColor = Color.Red;
                especificaciones_txt.Focus();
            }
            else
            {
                especificaciones_lbl.BackColor = Color.LemonChiffon;
                especificaciones_txt.ForeColor = Color.Black;
            }
        }

        private void guardar_btn_Click(object sender, EventArgs e)
        {
            if ((cuadra_lote_txt.Text.Length == 0 || cuadra_lote_txt.Text.Length == 2 || cuadra_lote_txt.Text.Length == 3) && cuadra_lote_lbl.BackColor != Color.Red)
                if (tipoUsoResaltante_txt.Text.Length > 0)
                    if (clasificacionUsoResaltante_lbl.BackColor != Color.Red)
                        if (direccion_txt.Text.Length > 0)
                            if (especificaciones_txt.Text.Length > 0) this.DialogResult = DialogResult.OK;
                            else especificaciones_txt.Focus();
                        else direccion_txt.Focus();
                    else clasificacionUsoResaltante_txt.Focus();
                else tipoUsoResaltante_txt.Focus();
            else cuadra_lote_txt.Focus();
        }
        #endregion
    }
}
