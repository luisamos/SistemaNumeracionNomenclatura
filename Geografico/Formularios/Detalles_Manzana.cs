using System;
using System.Windows.Forms;
using System.Linq;

namespace Formularios
{
    /// <summary>
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    internal partial class Detalles_Manzana : Detalles
    {
        internal Detalles_Manzana()
        {
            InitializeComponent();            
            this.detalles_dgv.Size = new System.Drawing.Size(1062, 297);
        }       

        #region Eventos
        private void Detalles_Manzana_Load(object sender, EventArgs e)
        {
            base.listar_busqueda();

            var x = from DataGridViewColumn i in detalles_dgv.Columns
                   select new { Nombre = i.HeaderText, Tipo = string.Format("{0}|{1}", i.DataPropertyName, i.DataPropertyName.GetType().FullName) };

            categoria2_cbo.DataSource = x.ToArray();
            categoria2_cbo.DisplayMember = "Nombre";
            categoria2_cbo.ValueMember = "Tipo";
            categoria2_cbo.SelectedIndex = 2;
            buscar1_txt.Focus();
        }

        private void categoria2_cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            buscar2_txt.Focus();
        }      

        private void buscar2_txt_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string query = "";
                    string valor1 = categoria1_cbo.SelectedValue.ToString();
                    string valor2 = categoria2_cbo.SelectedValue.ToString();
                    if (valor2.IndexOf("System.String") != -1) query = string.Format("[{0}] = '{1}' AND [{2}] LIKE('%{3}%')", valor1.Substring(0, valor1.IndexOf("|")), buscar1_txt.Text.Trim(), valor2.Substring(0, valor2.IndexOf("|")), buscar2_txt.Text.Trim());                    
                    GEODB_bs.Filter = query;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Buscar, Detalles", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   
        #endregion
    }
}