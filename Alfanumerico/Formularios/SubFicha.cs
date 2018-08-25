using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Componentes;
using System.Linq;
using TextBoxConFormato;


namespace Formularios
{
    /// <summary>
    /// Autor                   : Luis Amos - Dunia
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    internal partial class SubFicha : Form
    {
        internal SubFicha()
        {
            InitializeComponent();
            refrescar();           
        }

        #region Variables Globales
        ComponentResourceManager resources = new ComponentResourceManager(typeof(SubFicha));
        protected FICHA_ds FICHA_ds = null;
        internal string Usuario = "";
        internal int i = 0;
        internal string query = "";
        #endregion

        #region Propiedades
        internal bool controles
        {
            set
            {
                inicio.Enabled = (posicion.Text == "1") ? false : value;
                anterior.Enabled = (posicion.Text == "1") ? false : value;
                posicion.Enabled = value;
                siguiente.Enabled = (posicion.Text == contador.Text.Substring(3)) ? false : value;
                fin.Enabled = (posicion.Text == contador.Text.Substring(3)) ? false : value;
                nuevo_tsb.Enabled = value;                
            }
        }
        internal bool habilitar
        {
            get { return descripcion_txt.Enabled; }
            set
            {
                codigo_txt.Enabled = value;
                descripcion_txt.Enabled = value;
                SUBFICHA_dgv.Enabled = !value;
                categoria_tsc.Enabled = !value;
                buscar_tst.Enabled = !value;
                if (buscar_tst.Text == "") SUBFICHA_bs.Filter = "";
            }
        }
        #endregion

        #region Metodos
        internal void refrescar()
        {
            controles_bn.BindingSource = SUBFICHA_bs;
            SUBFICHA_dgv.DataSource = SUBFICHA_bs;
        }
        internal void listar_busqueda()
        {            
            SUBFICHA_dgv.Columns["USUARIO CREA"].Visible = false;
            SUBFICHA_dgv.Columns["FECHA DE CREACION"].Visible = false;
            SUBFICHA_dgv.Columns["USUARIO MODIFICA"].Visible = false;
            SUBFICHA_dgv.Columns["FECHA DE MODIFICACION"].Visible = false;
            SUBFICHA_dgv.Columns["LISTA"].Visible = false;
            var x = from DataGridViewColumn i in SUBFICHA_dgv.Columns
                    where i.Visible != false && i.ValueType.FullName != "System.Boolean"
                    select new { Nombre = i.HeaderText, Tipo = string.Format("{0}|{1}", i.HeaderText, i.ValueType.FullName) };
            categoria_tsc.ComboBox.DataSource = x.ToArray();
            categoria_tsc.ComboBox.DisplayMember = "Nombre";
            categoria_tsc.ComboBox.ValueMember = "Tipo";
            
            foreach (Control item in formulario_tp.Controls)
            {
                if (item is TextBox || item is FormattedTextBox)
                {
                    item.GotFocus += new EventHandler(activo_GotFocus);
                    item.LostFocus +=new EventHandler(desactivo_GotFocus);
                }
            }
        }        
        #endregion

        #region Eventos
        private void subficha_Load(object sender, EventArgs e)
        {
            nuevo_tsb.Enabled = true;
            aceptar_tsb.Text = "&Modificar";
            aceptar_tsb.Image = null;
            principal_tc.SelectedTab = formulario_tp; 
            SUBFICHA_dgv.ScrollBars = ScrollBars.Vertical;
            label1.Text = this.Text.Substring(this.Text.IndexOf('-') + 1);            
        }

        private void nuevo_tsb_Click(object sender, EventArgs e)
        {
            this.aceptar_tsb.Image = ((Image)(resources.GetObject("aceptar_tsb.Image")));
            this.aceptar_tsb.Text = "&Guardar";
            this.nuevo_tsb.Enabled = false;
            this.eliminar_tsb.Enabled = false;
            SUBFICHA_bs.AddNew();            
        }

        private void cancelar_tsb_Click(object sender, EventArgs e)
        {
            aceptar_tsb.Text = "&Modificar";
            this.aceptar_tsb.Image = null;
            nuevo_tsb.Enabled = true;
            this.eliminar_tsb.Enabled = true;
            SUBFICHA_bs.CancelEdit();
            buscar_tst.Text = "";
            SUBFICHA_bs.Filter = "";
            principal_tc.SelectedTab = formulario_tp;            
            
        }

        private void categoria_tsc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!buscar_tst.Focused) buscar_tst.Focus();
        }

        private void buscar_tst_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    query = "";
                    if (principal_tc.SelectedTab != tabla_tp) principal_tc.SelectedTab = tabla_tp;                    
                    string valor = categoria_tsc.ComboBox.SelectedValue.ToString();
                    if (valor.IndexOf("System.String") != -1)query = string.Format("[{0}] LIKE('%{1}%')", valor.Substring(0, valor.IndexOf("|")), buscar_tst.Text.Trim());
                    else if (valor.IndexOf("System.Int32") != -1 || valor.IndexOf("System.Int64") != -1 || valor.IndexOf("System.Double") != -1) query = string.Format("[{0}]={1}", valor.Substring(0, valor.IndexOf("|")), (buscar_tst.Text.Length > 0) ? buscar_tst.Text.Trim() : "0 OR 1=1");
                    else if (valor.IndexOf("System.DateTime") != -1)
                    {
                        string fecha = (buscar_tst.Text != "") ? buscar_tst.Text : DateTime.Now.ToString();
                        DateTime fecha1 = DateTime.Parse(fecha).AddDays(-1);
                        DateTime fecha2 = DateTime.Parse(fecha).AddDays(1);
                        query = string.Format("[{0}]>='{1}' AND [{0}]<'{2}'", valor.Substring(0, valor.IndexOf("|")), fecha1, fecha2);
                    }
                    SUBFICHA_bs.Filter = query;                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error - Buscar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal void enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) SendKeys.Send("{TAB}");            
            if (e.KeyData == Keys.Escape) SendKeys.Send("+{TAB}");
            else base.OnKeyDown(e);
        }

        private void activo_GotFocus(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            c.BackColor = Color.FromArgb(224,224,244);
        }

        private void desactivo_GotFocus(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            c.BackColor = Color.White;
        }       
        
        private void SUBFICHA_dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        } 

        private void codigo_txt_Leave(object sender, EventArgs e)
        {
            if (codigo_txt.Enabled)
            {
                if (this.Name != "Administrador" && this.Name != "Tipo_Via" && this.Name != "Habilitacion_Urbana")
                {
                    //if (codigo_txt.Text.Length != codigo_txt.MaxLength)
                //    {
                //        codigo_txt.BackColor = Color.Red;
                //        codigo_lbl.BackColor = Color.Red;
                //        codigo_txt.Focus();
                //    }
                //    else
                //    {
                        codigo_txt.BackColor = Color.White;
                        codigo_lbl.BackColor = Color.White;
                        descripcion_txt.Focus();
                    //}
                }
                else
                {
                    if (codigo_txt.Text.Length ==0)
                    {
                        codigo_txt.BackColor = Color.Red;
                        codigo_lbl.BackColor = Color.Red;
                        codigo_txt.Focus();
                    }
                    else
                    {
                        codigo_txt.BackColor = Color.White;
                        codigo_lbl.BackColor = Color.White;
                        descripcion_txt.Focus();
                    }
                }
            }
        }

        private void descripcion_txt_Leave(object sender, EventArgs e)
        {
            if (descripcion_txt.Enabled)
            {
                if (descripcion_txt.Text.Length == 0)
                {
                    descripcion_txt.BackColor = Color.Red;
                    descripcion_lbl.BackColor = Color.Red;
                    descripcion_txt.Focus();

                }
                else
                {
                    descripcion_txt.BackColor = Color.White;
                    descripcion_lbl.BackColor = Color.White;

                }
            }
        }

        private void validar_TextChanged(object sender, EventArgs e)
        {
            if ((codigo_txt.Text.Length > 0) || (descripcion_txt.Text.Length > 0))
            {
                aceptar_tsb.Enabled = codigo_txt.Text.Length > 0 && codigo_lbl.BackColor != Color.Red && descripcion_txt.Text.Length > 0 && descripcion_txt.BackColor != Color.Red;
            }
        }       
        #endregion
    }
}
