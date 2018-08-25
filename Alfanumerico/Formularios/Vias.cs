using System;
using System.Windows.Forms;
using Componentes;
using System.Data;
using Alfanumerico.Rpt;

namespace Formularios
{
    /// <summary>
    /// Autor                   : Luis Amos - Dunia
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    internal partial class Vias : SubFicha
    {
        internal Vias()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.listar_Load);
            nuevo_tsb.Click += new EventHandler(nuevo_tsb_Click);
            aceptar_tsb.Click += new EventHandler(aceptar_tsb_Click);
            eliminar_tsb.Click += new EventHandler(eliminar_tsb_Click);
            cancelar_tsb.Click += new EventHandler(cancelar_tsb_Click);
            vistaPrevia_tsb.Click += new EventHandler(vistaPrevia_tsb_Click);
            this.FormClosing += new FormClosingEventHandler(cerrar_FormClosing);
            codigo_txt.KeyDown += new KeyEventHandler(base.enter_KeyDown);
            tipoVia_cbo.KeyDown += new KeyEventHandler(base.enter_KeyDown);
            descripcion_txt.KeyDown += new KeyEventHandler(base.enter_KeyDown);
            toponimo_txt.KeyDown += new KeyEventHandler(base.enter_KeyDown);
            condicionNombreVia_cbo.KeyDown += new KeyEventHandler(base.enter_KeyDown);
            nroAcuerdo_txt.KeyDown += new KeyEventHandler(base.enter_KeyDown);
            clasificacionVia_cbo.KeyDown += new KeyEventHandler(base.enter_KeyDown);
            codigoViaMTC_txt.KeyDown += new KeyEventHandler(base.enter_KeyDown); 
        }

        #region Variables Globales
        cUbicacion_Geografica ubicacion_geografica = new cUbicacion_Geografica();
        #endregion

        #region Propiedades
        bool Habilitar
        {
            get { return descripcion_txt.Enabled; }
            set
            {
                codigo_txt.Enabled = value;
                tipoVia_cbo.Enabled = value;
                descripcion_txt.Enabled = value;
                toponimo_txt.Enabled = value;
                condicionNombreVia_cbo.Enabled = value;
                nroAcuerdo_txt.Enabled = value;
                clasificacionVia_cbo.Enabled = value;
                codigoViaMTC_txt.Enabled = value;
                observaciones_txt.Enabled = value;
                SUBFICHA_dgv.Enabled = !value;
                categoria_tsc.Enabled = !value;
                buscar_tst.Enabled = !value;
                if (buscar_tst.Text == "") SUBFICHA_bs.Filter = "";                
            }
        }
        #endregion

        #region Metodos
        void iniciar()
        {
            listar();
            aceptar_tsb.Text = "&Modificar";
            aceptar_tsb.Image = null;
            nuevo_tsb.Enabled = true;
            eliminar_tsb.Enabled = true;
            buscar_tst.Text = "";
            Habilitar = false;
        }
        void listar_tipo_via()
        {
            tipoVia_cbo.DataSource = (new cTipo_Vias()).listar().Tables["VS_LISTAR_TIPO_VIA"];
            tipoVia_cbo.DisplayMember = "DESCRIPCION";
            tipoVia_cbo.ValueMember = "TIPO DE VIA";
        }
        void listar_condicion_nombre_via()
        {
            condicionNombreVia_cbo.DataSource = (new cCondicion_Nombre_Via()).listar().Tables["VS_LISTAR_CONDICION_NOMBRE_VIA"];
            condicionNombreVia_cbo.DisplayMember = "DESCRIPCION";
            condicionNombreVia_cbo.ValueMember = "CODIGO";
        }
        void listar_clasificacion_via()
        {
            clasificacionVia_cbo.DataSource = (new cClasificacion_Via()).listar().Tables["VS_LISTAR_CLASIFICACION_VIA"];
            clasificacionVia_cbo.DisplayMember = "DESCRIPCION";
            clasificacionVia_cbo.ValueMember = "CODIGO";
        }
        void listar()
        {
            FICHA_ds = (new cVias()).listar();            
            base.refrescar();
            SUBFICHA_bs.DataSource = FICHA_ds;
            SUBFICHA_bs.DataMember = "VS_LISTAR_VIAS";
            listar_tipo_via();
            listar_condicion_nombre_via();
            listar_clasificacion_via();
        }
        void guardar()
        {
            if (codigo_txt.Text.Length == 3)
            {
                if (descripcion_txt.Text.Length > 0)
                {
                    cVias vias = new cVias();
                    vias.Codigo = codigo_txt.Text;
                    cTipo_Vias tipo_via = new cTipo_Vias();
                    tipo_via.Codigo = tipoVia_cbo.SelectedValue.ToString();
                    vias.Tipo_Via = tipo_via;
                    vias.Nombre_Via = descripcion_txt.Text;
                    vias.Toponimo = toponimo_txt.Text;
                    cCondicion_Nombre_Via condicion_nombre_via = new cCondicion_Nombre_Via();
                    condicion_nombre_via.Codigo = condicionNombreVia_cbo.SelectedValue.ToString();
                    vias.Condicion_Nombre_Via = condicion_nombre_via;
                    vias.Numero_Acuerdo = nroAcuerdo_txt.Text;
                    cClasificacion_Via clasificacion_via = new cClasificacion_Via();
                    clasificacion_via.Codigo = clasificacionVia_cbo.SelectedValue.ToString();                    
                    vias.Clasificacion_Via = clasificacion_via;
                    vias.Codigo_via_mtc = codigoViaMTC_txt.Text;                    
                    vias.Ubicacion_Geografica = ubicacion_geografica;
                    vias.Descripcion = observaciones_txt.Text;
                    vias.Usuario = Usuario;
                    i = vias.guardar();
                    if (i > 0) MessageBox.Show("Se a Insertando Correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else MessageBox.Show("Error, La código de Vía : '" + codigo_txt.Text + "', ya existe en el base de datos.", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    iniciar();
                }
            }
            else
            {
                MessageBox.Show("Código de Vía debe de ser un número de 3 dígitos","Error Guardar",MessageBoxButtons.OK, MessageBoxIcon.Error);
                codigo_txt.Focus();
            }
        }
        void modificar()
        {
            if (descripcion_txt.Text.Length > 0)
            {
                cVias vias = new cVias();
                vias.Codigo = codigo_txt.Text;
                cTipo_Vias tipo_via = new cTipo_Vias();
                tipo_via.Codigo = tipoVia_cbo.SelectedValue.ToString();
                vias.Tipo_Via = tipo_via;
                vias.Nombre_Via = descripcion_txt.Text;
                vias.Toponimo = toponimo_txt.Text;
                cCondicion_Nombre_Via condicion_nombre_via = new cCondicion_Nombre_Via();
                condicion_nombre_via.Codigo = condicionNombreVia_cbo.SelectedValue.ToString();
                vias.Condicion_Nombre_Via = condicion_nombre_via;
                vias.Numero_Acuerdo = nroAcuerdo_txt.Text;
                cClasificacion_Via clasificacion_via = new cClasificacion_Via();
                clasificacion_via.Codigo = clasificacionVia_cbo.SelectedValue.ToString();
                vias.Clasificacion_Via = clasificacion_via;
                vias.Codigo_via_mtc = codigoViaMTC_txt.Text;                
                vias.Ubicacion_Geografica = ubicacion_geografica;
                vias.Descripcion = observaciones_txt.Text;
                vias.Usuario = Usuario;
                i = vias.modificar();
                if (i > 0) MessageBox.Show("Se a Modificado Correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Error, no se a Modificado Correctamente, el código de Vía esta en uso y/o esta Desabilitada.", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                iniciar();
            }
        }
        void eliminar()
        {
            cVias vias = new cVias();
            vias.Codigo = codigo_txt.Text;            
            vias.Usuario = Usuario;
            i = vias.eliminar();
            if (i >= 2) MessageBox.Show("Se a eliminado el Registro", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Error, No se puede eliminar, el código de Vía esta en uso y/o esta Desabilitada.", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            iniciar();
        }
        #endregion

        #region Eventos
        private void listar_Load(object sender, EventArgs e)
        {
            try
            {                
                listar();                
                Habilitar = false;                
                SUBFICHA_dgv.Columns["TV"].Visible = false;
                SUBFICHA_dgv.Columns["CNV"].Visible = false;
                SUBFICHA_dgv.Columns["CV"].Visible = false;
                base.listar_busqueda();
                SUBFICHA_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                codigo_txt.DataBindings.Add(new Binding("Text", SUBFICHA_bs, "CODIGO DE VIA", true));
                tipoVia_cbo.DataBindings.Add(new Binding("SelectedValue", SUBFICHA_bs, "TV", true));
                descripcion_txt.DataBindings.Add(new Binding("Text", SUBFICHA_bs, "NOMBRE DE VIA", true));
                toponimo_txt.DataBindings.Add(new Binding("Text", SUBFICHA_bs, "TOPONIMO", true));
                condicionNombreVia_cbo.DataBindings.Add(new Binding("SelectedValue", SUBFICHA_bs, "CNV", true));
                nroAcuerdo_txt.DataBindings.Add(new Binding("Text", SUBFICHA_bs, "NUMERO DE ACUERDO", true));
                clasificacionVia_cbo.DataBindings.Add(new Binding("SelectedValue", SUBFICHA_bs, "CV", true));
                codigoViaMTC_txt.DataBindings.Add(new Binding("Text", SUBFICHA_bs, "CODIGO VIA MTC", true));
                observaciones_txt.DataBindings.Add(new Binding("Text", SUBFICHA_bs, "OBSERVACIONES", true));
                categoria_tsc.SelectedIndex = 3;
                SUBFICHA_dgv.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error - Listar");
            }
        }

        private void nuevo_tsb_Click(object sender, EventArgs e)
        {
            if (!Habilitar)
            {
                principal_tc.SelectedTab = formulario_tp;
                Habilitar = true;
                base.controles = false;                
                tipoVia_cbo.SelectedIndex = 0;
                condicionNombreVia_cbo.SelectedIndex = 0;
                clasificacionVia_cbo.SelectedIndex = 0;
                codigo_txt.Focus();
            }
        }

        private void aceptar_tsb_Click(object sender, EventArgs e)
        {
            try
            {
                if (SUBFICHA_dgv.Rows.Count > 0)
                {
                    Habilitar = true;
                    codigo_txt.Focus();
                    if (aceptar_tsb.Text == "&Guardar") guardar();
                    else if(aceptar_tsb.Text == "&Modificar")
                    {
                        base.controles = false;
                        aceptar_tsb.Text = "&Aceptar";
                        aceptar_tsb.Image = null;
                        nuevo_tsb.Enabled = false;
                        eliminar_tsb.Enabled = true;
                        codigo_txt.Enabled = false;
                        principal_tc.SelectedTab = formulario_tp;
                    }
                    else if(aceptar_tsb.Text == "&Aceptar") modificar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error - Guardar y/o Modificar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminar_tsb_Click(object sender, EventArgs e)
        {
            try
            {
                if (SUBFICHA_dgv.Rows.Count > 0) eliminar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error - Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       

        private void cancelar_tsb_Click(object sender, EventArgs e)
        {
            if (Habilitar)
            {
                Habilitar = false;
                base.controles = true;
            }
        }

        private void vistaPrevia_tsb_Click(object sender, EventArgs e)
        {
            try
            {
                DataView vista = FICHA_ds.VS_LISTAR_VIAS.DefaultView;
                vista.RowFilter = query;
                DataTable tabla = vista.ToTable();
                Reporte reporte;
                if (tabla.Rows.Count > 0) reporte = new Reporte(new vias(), tabla);
                else reporte = new Reporte(new vias(), FICHA_ds);
                reporte.Text = "Vista Previa, " + this.Text;
                reporte.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error - Reporte");
            }  
        }

        private void cerrar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (i != 0) this.DialogResult = DialogResult.OK;
        }       
        
        private void actualizarTipoVia_btn_Click(object sender, EventArgs e)
        {
            listar_tipo_via();
        }

        private void actualizarCondicionNombreVia_btn_Click(object sender, EventArgs e)
        {
            listar_condicion_nombre_via();
        }

        private void actualizarClasificacionVia_btn_Click(object sender, EventArgs e)
        {
            listar_clasificacion_via();
        }
        #endregion
    }
}
