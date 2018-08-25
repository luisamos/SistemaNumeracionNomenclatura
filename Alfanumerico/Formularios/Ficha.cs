using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Componentes;
using TextBoxConFormato;

namespace Formularios
{
    /// <summary>
    /// Autor                   : Luis Amos - Dunia
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    internal partial class Ficha : Form
    {
        internal Ficha()
        {
            InitializeComponent();
            refrescar();
        }

        #region Variables Globales
        ComponentResourceManager resources = new ComponentResourceManager(typeof(Ficha));        
        List<Control> lista_controles = new List<Control>();
        internal FICHA_ds FICHA_ds = new FICHA_ds();
        internal int i = 0;
        internal string Usuario ="VIP_ADMIN";
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
        #endregion

        #region Metodos
        void activar_eventos(Control c)
        {
            c.GotFocus += new EventHandler(activo_GotFocus);
            c.LostFocus += new EventHandler(desactivo_GotFocus);
            c.KeyDown += new KeyEventHandler(enter_KeyDown);
        }
        void tab_controles(Control controles)
        {
            IEnumerable<Control> elementos = from Control c in controles.Controls
                                             where c is TabPage || c.Tag != null
                                             select c;
            foreach (Control item in elementos)
            {
                if (item is TabPage)
                {                    
                    TabPage paginas = (TabPage)item;
                    IEnumerable<Control> texto = from Control c1 in paginas.Controls
                                                 where c1 is TextBox || c1 is FormattedTextBox || c1 is DateTimePicker
                                                 select c1;
                    lista_controles.AddRange(texto.ToList());                    

                    IEnumerable<Control> tab_control = from Control c2 in paginas.Controls
                                                       where c2 is TabControl
                                                       select c2;
                    foreach (Control c in tab_control)
                    {
                        tab_controles(c);
                    }
                }
            }
        }
        internal void refrescar()
        {                        
            controles_bn.BindingSource = FICHA_bs;
            FICHA_dgv.DataSource = FICHA_bs;            
        }
        internal void listar_busqueda()
        {         
            FICHA_dgv.Columns["FICHA"].Visible = false;
            FICHA_dgv.Columns["DPTO"].Visible = false;
            FICHA_dgv.Columns["PROV"].Visible = false;
            FICHA_dgv.Columns["DIST"].Visible = false;         
            FICHA_dgv.Columns["DNI SUPERVISOR"].Visible = false;
            FICHA_dgv.Columns["LISTA SUPERVISOR"].Visible = false;
            FICHA_dgv.Columns["DNI TECNICO CATASTRAL"].Visible = false;
            FICHA_dgv.Columns["LISTA TECNICO CATASTRAL"].Visible = false;
            FICHA_dgv.Columns["DNI VB DIGITACION"].Visible = false;
            FICHA_dgv.Columns["LISTA VB DIGITACION"].Visible = false;
            FICHA_dgv.Columns["USUARIO CREA"].Visible = false;
            FICHA_dgv.Columns["FECHA DE CREACION"].Visible = false;
            FICHA_dgv.Columns["USUARIO MODIFICA"].Visible = false;
            FICHA_dgv.Columns["FECHA DE MODIFICACION"].Visible = false;
            
            var x = from DataGridViewColumn i in FICHA_dgv.Columns
                    where i.Visible != false && i.HeaderText != "DEPARTAMENTO" && i.HeaderText != "PROVINCIA" && i.HeaderText != "DISTRITO" && i.HeaderText != "OBSERVACIONES" && i.HeaderText != "SUPERVISOR" && i.HeaderText != "TECNICO CATASTRAL" && i.HeaderText != "VB DIGITACION" && i.HeaderText != "ESTADO"
                    && i.HeaderText != "CALZADA CARRIL 1 MATERIAL" && i.HeaderText != "CALZADA CARRIL 1 ECS" && i.HeaderText != "CALZADA CARRIL 1 ESPECIFICACIONES"
                    && i.HeaderText != "CALZADA CARRIL 2 MATERIAL" && i.HeaderText != "CALZADA CARRIL 2 ECS" && i.HeaderText != "CALZADA CARRIL 2 ESPECIFICACIONES"
                    && i.HeaderText != "CALZADA CARRIL 3 MATERIAL" && i.HeaderText != "CALZADA CARRIL 3 ECS" && i.HeaderText != "CALZADA CARRIL 3 ESPECIFICACIONES"
                    && i.HeaderText != "CALZADA CARRIL 4 MATERIAL" && i.HeaderText != "CALZADA CARRIL 4 ECS" && i.HeaderText != "CALZADA CARRIL 4 ESPECIFICACIONES"
                    && i.HeaderText != "VEREDAS DERECHA MATERIAL" && i.HeaderText != "VEREDAS DERECHA ECS" && i.HeaderText != "VEREDAS DERECHA ESPECIFICACIONES"
                    && i.HeaderText != "VEREDAS IZQUIERDA MATERIAL" && i.HeaderText != "VEREDAS IZQUIERDA ECS" && i.HeaderText != "VEREDAS IZQUIERDA ESPECIFICACIONES"
                    && i.HeaderText != "VEREDAS CENTRAL MATERIAL" && i.HeaderText != "VEREDAS CENTRAL ECS" && i.HeaderText != "VEREDAS CENTRAL ESPECIFICACIONES"
                    && i.HeaderText != "CICLO VIA DERECHA MATERIAL" && i.HeaderText != "CICLO VIA DERECHA ECS" && i.HeaderText != "CICLO VIA DERECHA ESPECIFICACIONES"
                    && i.HeaderText != "CICLO VIA IZQUIERDA MATERIAL" && i.HeaderText != "CICLO VIA IZQUIERDA ECS" && i.HeaderText != "CICLO VIA IZQUIERDA ESPECIFICACIONES"
                    && i.HeaderText != "CICLO VIA CENTRAL MATERIAL" && i.HeaderText != "CICLO VIA CENTRAL ECS" && i.HeaderText != "CICLO VIA CENTRAL ESPECIFICACIONES"
                    && i.HeaderText != "VIA FERREA DERECHA MATERIAL" && i.HeaderText != "VIA FERREA DERECHA ECS" && i.HeaderText != "VIA FERREA DERECHA ESPECIFICACIONES"
                    && i.HeaderText != "VIA FERREA IZQUIERDA MATERIAL" && i.HeaderText != "VIA FERREA IZQUIERDA ECS" && i.HeaderText != "VIA FERREA IZQUIERDA ESPECIFICACIONES"
                    && i.HeaderText != "VIA FERREA CENTRAL MATERIAL" && i.HeaderText != "VIA FERREA CENTRAL ECS" && i.HeaderText != "VIA FERREA CENTRAL ESPECIFICACIONES"
                    && i.HeaderText != "BERMA DERECHA ECS" && i.HeaderText != "BERMA DERECHA ESPECIFICACIONES"
                    && i.HeaderText != "BERMA IZQUIERDA ECS" && i.HeaderText != "BERMA IZQUIERDA ESPECIFICACIONES"
                    && i.HeaderText != "BERMA CENTRAL ECS" && i.HeaderText != "BERMA CENTRAL ESPECIFICACIONES"                    
                    && i.ValueType.FullName != "System.Decimal" && i.ValueType.FullName != "System.Double"  && i.ValueType.FullName != "System.Int32" && (i.ValueType.FullName != "System.Int64"  || i.HeaderText == "NUMERO DE FICHA") && i.ValueType.FullName != "System.DateTime"
                    select new { Nombre = i.HeaderText, Tipo = string.Format("{0}|{1}", i.HeaderText, i.ValueType.FullName)};
            categoria_tsc.ComboBox.DataSource = x.ToArray();
            categoria_tsc.ComboBox.DisplayMember = "Nombre";
            categoria_tsc.ComboBox.ValueMember = "Tipo";
            
            if (formulario_tp.Controls.Count > 0)
            {
                TabControl controles = (TabControl)formulario_tp.Controls["secundario_tc"];
                tab_controles(controles);
                lista_controles.ForEach(a => activar_eventos(a));
                PictureBox logo = (PictureBox)formulario_tp.Controls["secundario_tc"].Controls["tabPage1"].Controls["logoMunicipal_pb"];
                logo.ImageLocation = cConfiguracion.Logo;                
            }
        }
        internal void actualizar_datos_ubicacion_geografica()
        {
            formulario_tp.Controls["secundario_tc"].Controls["tabPage1"].Controls["departamento_lbl"].Text = Componentes.cUbicacion_Geografica.Codigo_Departamento;
            formulario_tp.Controls["secundario_tc"].Controls["tabPage1"].Controls["provincia_lbl"].Text = Componentes.cUbicacion_Geografica.Codigo_Provincia;
            formulario_tp.Controls["secundario_tc"].Controls["tabPage1"].Controls["distrito_lbl"].Text = Componentes.cUbicacion_Geografica.Codigo_Distrito;
        }
        #endregion

        #region Eventos
        private void ficha_Load(object sender, EventArgs e)
        {            
            nuevo_tsb.Enabled = true;
            aceptar_tsb.Text = "&Modificar";
            aceptar_tsb.Image = null;
            principal_tc.SelectedTab = formulario_tp;
            FICHA_dgv.ScrollBars = ScrollBars.Both;
            label1.Text = this.Text;            
        }

        private void nuevo_tsb_Click(object sender, EventArgs e)
        {
            aceptar_tsb.Image = ((Image)(resources.GetObject("aceptar_tsb.Image")));
            aceptar_tsb.Text = "&Guardar";
            nuevo_tsb.Enabled = false;
            eliminar_tsb.Enabled = false;            
        }

        private void cancelar_tsb_Click(object sender, EventArgs e)
        {
            aceptar_tsb.Text = "&Modificar";
            aceptar_tsb.Image = null;
            nuevo_tsb.Enabled = true;
            eliminar_tsb.Enabled = true;
            FICHA_bs.CancelEdit();
            buscar_tst.Text = "";
            FICHA_bs.Filter = "";
            principal_tc.SelectedTab = formulario_tp;
        }

        private void salir_tsb_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ayuda_tsb_Click(object sender, EventArgs e)
        {
            cConfiguracion.abrir(string.Format(@"{0}\Manuales\m04.pdf", cConfiguracion.Ruta));
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
                    if (principal_tc.SelectedTab != tabla_tp)
                    {
                        ((TabControl)formulario_tp.Controls["secundario_tc"]).SelectedTab = (TabPage)formulario_tp.Controls["secundario_tc"].Controls["tabPage1"];                        
                        principal_tc.SelectedTab = tabla_tp;
                    }                    
                    string valor = categoria_tsc.ComboBox.SelectedValue.ToString();                    
                    if (valor.IndexOf("System.String") != -1) query = string.Format("[{0}] LIKE('%{1}%')", valor.Substring(0, valor.IndexOf("|")), buscar_tst.Text.Trim());
                    else if (valor.IndexOf("System.Int32") != -1 || valor.IndexOf("System.Int64") != -1 || valor.IndexOf("System.Double") != -1) query = string.Format("[{0}]={1}", valor.Substring(0, valor.IndexOf("|")),(buscar_tst.Text.Length>0)?buscar_tst.Text.Trim():"0 OR 1=1");
                    else if (valor.IndexOf("System.DateTime") != -1)
                    {
                        string fecha = (buscar_tst.Text != "") ? buscar_tst.Text : DateTime.Now.ToString();
                        DateTime fecha1 = DateTime.Parse(fecha).AddDays(-1);
                        DateTime fecha2 = DateTime.Parse(fecha).AddDays(1);
                        query = string.Format("[{0}]>='{1}' AND [{0}]<'{2}'", valor.Substring(0, valor.IndexOf("|")), fecha1, fecha2);
                    }
                    FICHA_bs.Filter = query;
                    if (FICHA_dgv.RowCount == 0)
                    {
                        aceptar_tsb.Image = ((Image)(resources.GetObject("aceptar_tsb.Image")));
                        aceptar_tsb.Text = "&Guardar";
                        aceptar_tsb.Enabled = false;
                        eliminar_tsb.Enabled = false;
                    }
                    else
                    {
                        aceptar_tsb.Image = null;
                        aceptar_tsb.Text = "&Modificar";
                        aceptar_tsb.Enabled = true;
                        eliminar_tsb.Enabled = true;
                    }
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
            c.BackColor = Color.FromArgb(224, 224, 244);
        }

        private void desactivo_GotFocus(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            c.BackColor = Color.White;
        }
        #endregion
    }
}