using System;
using System.Data;
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
    internal partial class Equipamiento_Urbano : Inicio
    {
        internal Equipamiento_Urbano()
        {
            InitializeComponent();
        }

        #region Variables Globales
        cTipo_Equipamiento_Urbano Tipo_Equipamiento_Urbano = new cTipo_Equipamiento_Urbano();
        cUsos Usos = new cUsos();
        internal string Usuario;
        #endregion

        #region Eventos
        private void equipamiento_urbano_Load(object sender, EventArgs e)
        {
            try
            {
                usuario_lbl.Text = Usuario;
                mensaje_lbl.Text = "Ingresar datos:";
                tipoEquipamientoUrbano_txt.AutoCompleteCustomSource.AddRange(Tipo_Equipamiento_Urbano.listar_arreglo());
                codigoUsos_txt.AutoCompleteCustomSource.AddRange(Usos.listar_arreglo());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error:  Equipamiento Urbano", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       

        private void validar_TextChanged(object sender, EventArgs e)
        {
            guardar_btn.Enabled = nombreEquipamientoUrbano_lbl.BackColor != Color.Red && nombreEquipamientoUrbano_txt.Text.Length > 0 && tipoEquipamientoUrbano_lbl.BackColor != Color.Red && tipoEquipamientoUrbano_txt.Text.Length == 2 && codigoUsos_lbl.BackColor != Color.Red && codigoUsos_txt.Text.Length>0;
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

        private void guardar_btn_Click(object sender, EventArgs e)
        {
            if (nombreEquipamientoUrbano_txt.Text.Length == 0)
            {
                nombreEquipamientoUrbano_txt_Leave(sender, e);
                return;
            }
            if (tipoEquipamientoUrbano_txt.Text.Length == 0)
            {
                tipoEquipamientoUrbano_txt_Leave(sender, e);
                return;
            }
            if (codigoUsos_txt.Text.Length == 0)
            {
                codigoUsos_txt_Leave(sender, e);
                return;
            }

            if(nombreEquipamientoUrbano_lbl.BackColor != Color.Red && tipoEquipamientoUrbano_lbl.BackColor != Color.Red && codigoUsos_lbl.BackColor != Color.Red)
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void lote_txt_Leave(object sender, EventArgs e)
        {
            if (lote_txt.Text.Length == 3 || lote_txt.Text.Length == 0)
            {
                lote_lbl.BackColor = Color.White;
                lote_txt.ForeColor = Color.Black;
            }
            else
            {
                lote_lbl.BackColor = Color.Red;
                lote_txt.Focus();
                lote_txt.SelectAll();
                lote_txt.ForeColor = Color.Red;
            }
        }

        private void edifica_Leave(object sender, EventArgs e)
        {
            if (edifica_txt.Text.Length == 2 || edifica_txt.Text.Length == 0)
            {
                edifica_lbl.BackColor = Color.White;
                edifica_txt.ForeColor = Color.Black;
            }
            else
            {
                edifica_lbl.BackColor = Color.Red;
                edifica_txt.Focus();
                edifica_txt.SelectAll();
                edifica_txt.ForeColor = Color.Red;
            }
        }

        private void nombreEquipamientoUrbano_txt_Leave(object sender, EventArgs e)
        {
            if (nombreEquipamientoUrbano_txt.Text.Length == 0)
            {
                nombreEquipamientoUrbano_lbl.BackColor = Color.Red;
                nombreEquipamientoUrbano_txt.ForeColor = Color.Red;
                nombreEquipamientoUrbano_txt.Focus();                
            }
            else
            {
                nombreEquipamientoUrbano_lbl.BackColor = Color.White;
                nombreEquipamientoUrbano_txt.ForeColor = Color.Black;
            }
            validar_TextChanged(sender, e);
        }

        private void tipoEquipamientoUrbano_txt_Leave(object sender, EventArgs e)
        {
            tipoEquipamientoUrbano_txt.Text = (tipoEquipamientoUrbano_txt.Text.Length > 2) ? tipoEquipamientoUrbano_txt.Text.Substring(0, 2) : tipoEquipamientoUrbano_txt.Text;
            if (Tipo_Equipamiento_Urbano.buscar(tipoEquipamientoUrbano_txt.Text))
            {
                tipoEquipamientoUrbano_lbl.BackColor = Color.White;
                tipoEquipamientoUrbano_txt.ForeColor = Color.Black;
            }
            else
            {
                tipoEquipamientoUrbano_lbl.BackColor = Color.Red;
                tipoEquipamientoUrbano_txt.Focus();
                tipoEquipamientoUrbano_txt.SelectAll();
                tipoEquipamientoUrbano_txt.ForeColor = Color.Red;
            }
            validar_TextChanged(sender, e);
        }

        private void codigoUsos_txt_Leave(object sender, EventArgs e)
        {
                int i = (codigoUsos_txt.Text.IndexOf('-') != -1) ? codigoUsos_txt.Text.IndexOf('-') : codigoUsos_txt.Text.Length + 1;
                codigoUsos_txt.Text = (codigoUsos_txt.Text.Length > 0) ? codigoUsos_txt.Text.Substring(0, i - 1) : "";
                DataRow fila = Usos.Buscar(codigoUsos_txt.Text.Trim());
                if (fila == null)
                {
                    codigoUsos_lbl.BackColor = Color.Red;
                    codigoUsos_txt.Focus();
                    codigoUsos_txt.SelectAll();
                    codigoUsos_txt.ForeColor = Color.Red;
                    descripcionUsos_lbl.Text = "";                    
                }
                else
                {
                    codigoUsos_lbl.BackColor = Color.White;
                    codigoUsos_txt.ForeColor = Color.Black;
                    descripcionUsos_lbl.Text = fila["LISTA"].ToString();
                }           
            validar_TextChanged(sender, e);
        }
        #endregion
    }
}
