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
    internal partial class Clasificacion_Uso_Resaltante : SubFicha
    {
        internal Clasificacion_Uso_Resaltante()
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
            tipo_cbo.KeyDown += new KeyEventHandler(base.enter_KeyDown);      
        }

        #region Propiedades
        bool Habilitar
        {
            get { return descripcion_txt.Enabled; }
            set
            {
                codigo_txt.Enabled = value;
                descripcion_txt.Enabled = value;
                tipo_cbo.Enabled = value;
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
        void listar_tipo_uso_resaltante()
        {
            tipo_cbo.DataSource = (new cTipo_Uso_Resaltante()).listar().Tables["VS_LISTAR_TIPO_USO_RESALTANTE"];
            tipo_cbo.DisplayMember = "DESCRIPCION";
            tipo_cbo.ValueMember = "CODIGO";            
        }
        void listar()
        {
            FICHA_ds = (new cClasificacion_Uso_Resaltante()).listar();            
            base.refrescar();
            listar_tipo_uso_resaltante();
            SUBFICHA_bs.DataSource = FICHA_ds;
            SUBFICHA_bs.DataMember = "VS_LISTAR_CLASIFICACION_USO_RESALTANTE";            
        }
        void guardar()
        {
            if (tipo_cbo.SelectedIndex != -1 && codigo_txt.Text.Length > 0 && descripcion_txt.Text.Length > 0)
            {
                cClasificacion_Uso_Resaltante clasificacion_uso_resaltante = new cClasificacion_Uso_Resaltante();
                cTipo_Uso_Resaltante tipo_uso_resaltante = new cTipo_Uso_Resaltante();
                tipo_uso_resaltante.Codigo = tipo_cbo.SelectedValue.ToString();
                clasificacion_uso_resaltante.Tipo_Uso_Resaltante = tipo_uso_resaltante;
                clasificacion_uso_resaltante.Clasificacion = codigo_txt.Text;
                clasificacion_uso_resaltante.Descripcion = descripcion_txt.Text;
                clasificacion_uso_resaltante.Usuario = Usuario;
                i = clasificacion_uso_resaltante.guardar();
                if (i > 0) MessageBox.Show("Se a Insertado Correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                else MessageBox.Show("Error, La clasificacion de uso resaltante : '" + codigo_txt.Text + "', ya existe en el base de datos.", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                iniciar();
            }
        }
        void modificar()
        {
            if (tipo_cbo.SelectedIndex != -1 && codigo_txt.Text.Length > 0 && descripcion_txt.Text.Length > 0)
            {
                cClasificacion_Uso_Resaltante clasificacion_uso_resaltante = new cClasificacion_Uso_Resaltante();
                cTipo_Uso_Resaltante tipo_uso_resaltante = new cTipo_Uso_Resaltante();
                tipo_uso_resaltante.Codigo = tipo_cbo.SelectedValue.ToString();
                clasificacion_uso_resaltante.Codigo = id_lbl.Text;
                clasificacion_uso_resaltante.Clasificacion = codigo_txt.Text;
                clasificacion_uso_resaltante.Tipo_Uso_Resaltante = tipo_uso_resaltante;
                clasificacion_uso_resaltante.Descripcion = descripcion_txt.Text;
                clasificacion_uso_resaltante.Usuario = Usuario;
                i = clasificacion_uso_resaltante.modificar();
                if (i > 0)MessageBox.Show("Se a Modificado Correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Error, no se a Modificado Correctamente, la clasificacion de uso resaltante esta en uso y/o esta Desabilitada.", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                iniciar();
            }
        }
        void eliminar()
        {
            cClasificacion_Uso_Resaltante clasificacion_uso_resaltante = new cClasificacion_Uso_Resaltante();
            clasificacion_uso_resaltante.Codigo = id_lbl.Text;
            clasificacion_uso_resaltante.Usuario = Usuario;
            i = clasificacion_uso_resaltante.eliminar();
            if (i >= 2) MessageBox.Show("Se a eliminado el Registro", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Error, No se puede eliminar, la clasificacion de uso resaltante esta en uso y/o esta Desabilitada.", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                SUBFICHA_dgv.Columns["CODIGO"].Visible = false;
                SUBFICHA_dgv.Columns["TUR"].Visible = false;
                SUBFICHA_dgv.Columns["CUR"].Visible = false;
                base.listar_busqueda();
                id_lbl.DataBindings.Add(new Binding("Text", SUBFICHA_bs, "CODIGO", true));
                codigo_txt.DataBindings.Add(new Binding("Text", SUBFICHA_bs, "CUR", true));
                descripcion_txt.DataBindings.Add(new Binding("Text", SUBFICHA_bs, "CLASIFICACION USO RESALTANTE", true));
                tipo_cbo.DataBindings.Add(new Binding("SelectedValue", SUBFICHA_bs, "TUR", true));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error - Listar");
            }
        }

        private void nuevo_tsb_Click(object sender, EventArgs e)
        {
            if (!habilitar)
            {
                principal_tc.SelectedTab = formulario_tp;
                Habilitar = true;
                base.controles = false;
                tipo_cbo.SelectedIndex = 0;
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
                    else if (aceptar_tsb.Text == "&Modificar")
                    {
                        base.controles = false;
                        aceptar_tsb.Text = "&Aceptar";
                        aceptar_tsb.Image = null;
                        nuevo_tsb.Enabled = false;
                        eliminar_tsb.Enabled = true;                        
                        principal_tc.SelectedTab = formulario_tp;
                    }
                    else if (aceptar_tsb.Text == "&Aceptar") modificar();
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
            if (habilitar)
            {
                Habilitar = false;
                base.controles = true;
            }
        }

        private void vistaPrevia_tsb_Click(object sender, EventArgs e)
        {
            try
            {
                DataView vista = FICHA_ds.VS_LISTAR_CLASIFICACION_USO_RESALTANTE.DefaultView;
                vista.RowFilter = query;
                DataTable tabla = vista.ToTable();
                Reporte reporte;
                if (tabla.Rows.Count > 0) reporte = new Reporte(new clasificacion_uso_resaltante(), tabla);
                else reporte = new Reporte(new clasificacion_uso_resaltante(), FICHA_ds);
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
        
        private void actualizar_btn_Click(object sender, EventArgs e)
        {
            listar_tipo_uso_resaltante();
        }
        #endregion
    }
}
