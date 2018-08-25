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
    internal partial class Detalles : Form
    {
        internal Detalles()
        {
            InitializeComponent();
            detalles_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        #region Atributos y Propiedades
        private string columna;
        private string valor;
        internal string Columna
        {
            get
            {
                return columna;
            }
            set
            {
                columna = value;
            }
        }
        internal string Valor
        {
            get
            {
                return valor;
            }
            set
            {
                valor = value;
            }
        }
        #endregion

        #region Metodos
        internal void listar_busqueda()
        {
            var x = from DataGridViewColumn i in detalles_dgv.Columns
                    select new { Nombre = i.HeaderText, Tipo = string.Format("{0}|{1}", i.DataPropertyName, i.DataPropertyName.GetType().FullName) };

            categoria1_cbo.DataSource = x.ToArray();
            categoria1_cbo.DisplayMember = "Nombre";
            categoria1_cbo.ValueMember = "Tipo";

            switch (this.Text)
            {
                case "Propiedades - Capa Sectores":
                    categoria1_cbo.SelectedIndex = 1;
                    break;
                case "Propiedades - Capa Manzanas":
                    categoria1_cbo.SelectedIndex = 1;
                    break;
                case "Propiedades - Capa Eje de Via":
                    categoria1_cbo.SelectedIndex = 4;
                    break;
                case "Propiedades - Capa Equipamiento Urbano":
                    categoria1_cbo.SelectedIndex = 1;
                    break;
                case "Propiedades - Capa Puerta":
                    categoria1_cbo.SelectedIndex = 3;
                    break;
                case "Propiedades - Capa Usos Resaltantes":
                    categoria1_cbo.SelectedIndex = 3;
                    break;
            }
        }
        #endregion

        #region Eventos
        private void detalles_Load(object sender, EventArgs e)
        {
            listar_busqueda();
            buscar1_txt.Focus();
        }

        private void categoria1_cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            buscar1_txt.Focus();
        }

        private void buscar1_txt_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string query = "";
                    string valor = categoria1_cbo.SelectedValue.ToString();
                    if (valor.IndexOf("System.String") != -1) query = string.Format("[{0}] LIKE('%{1}%')", valor.Substring(0, valor.IndexOf("|")), buscar1_txt.Text.Trim());                                        
                    GEODB_bs.Filter = query;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Buscar, Detalles GEODB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }     

        private void detalles_dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            if (detalles_dgv.CurrentCell != null)
            {
                if (detalles_dgv.CurrentCell.RowIndex != -1)
                {
                    Columna = detalles_dgv.Columns[0].HeaderText;
                    Valor = detalles_dgv[0, detalles_dgv.CurrentCell.RowIndex].Value.ToString();
                    switch (Columna)
                    {
                        case "CODIGO SECTOR":
                            Columna = "CODIGO_SECTOR";
                            break;
                        case "CODIGO MANZANA":
                            Columna = "CODIGO_MANZANA";
                            break;
                    }
                }
                else
                {
                    Columna = "";
                    Valor = "";                   
                }
            }
            else return;
        }        

        private void zoom_btn_Click(object sender, EventArgs e)
        {            
            if (detalles_dgv.CurrentCell != null) this.DialogResult = System.Windows.Forms.DialogResult.OK;
            else this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        #endregion
    }
}