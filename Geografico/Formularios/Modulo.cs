using System;
using System.Data;
using System.Windows.Forms;
using Componentes;

namespace Formularios
{
    /// <summary>
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    internal partial class Modulo : Form
    {
        internal Modulo()
        {
            InitializeComponent();
        }

        #region Variables Globales
        internal char t = ' ';
        internal string capa,tipo,material;
        #endregion

        #region Eventos
        private void modulo_Load(object sender, EventArgs e)
        {                       
            switch (t)
            {
                case 'C':
                    this.Text = "Tipo de Componente Urbano";
                    string[] capas1 = new string[] { "TIPO DE COMPONENTE URBANO  - VIAS URBANAS","TIPO DE COMPONENTE DE URBANO - ESPACIO DE RECREACION"};
                    capa_cbo.Items.AddRange(capas1);
                    mensaje_lbl.Text = "Elegir, Tipo de Componente Urbano:";
                    DataTable tabla1 = new cTipo_Componente_Urbano().listar().Tables["VS_LISTAR_TIPO_COMPONENTE_URBANO"];
                    tabla1.Rows.RemoveAt(11);
                    tipo_cbo.DataSource = tabla1;
                    tipo_cbo.DisplayMember = "DESCRIPCION";
                    tipo_cbo.ValueMember = "CODIGO";
                    break;
                case 'M':
                    this.Text = "Tipo de Mobiliario Urbano";
                    string[] capas2 = new string[] { "TIPO DE MOBILIARIO URBANO - VIAS URBANAS", "TIPO DE MOBILIARIO URBANO - ESPACIO DE RECREACION" };
                    capa_cbo.Items.AddRange(capas2);
                    mensaje_lbl.Text = "Elegir, Tipo de Mobiliario Urbano:";
                    DataTable tabla2 = new cTipo_Mobiliario_Urbano().listar().Tables["VS_LISTAR_TIPO_MOBILIARIO_URBANO"];
                    tabla2.Rows.RemoveAt(10);
                    tipo_cbo.DataSource = tabla2; 
                    tipo_cbo.DisplayMember = "DESCRIPCION";
                    tipo_cbo.ValueMember = "CODIGO";
                    break;
            }
            DataTable tabla3 = new cMaterial_Componente_Urbano_Mobiliario_Urbano().listar().Tables["VS_LISTAR_MATERIAL"];
            tabla3.Rows.RemoveAt(7);
            material_cbo.DataSource = tabla3;
            material_cbo.DisplayMember = "DESCRIPCION";
            material_cbo.ValueMember = "CODIGO";
            capa_cbo.SelectedIndex = 0; 
        }        

        private void aceptar_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if(capa_cbo.SelectedIndex != -1 && tipo_cbo.SelectedIndex != -1 && material_cbo.SelectedIndex != -1)
                {
                    capa = capa_cbo.SelectedIndex.ToString();
                    tipo = tipo_cbo.SelectedValue.ToString();
                    material = material_cbo.SelectedValue.ToString();
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
