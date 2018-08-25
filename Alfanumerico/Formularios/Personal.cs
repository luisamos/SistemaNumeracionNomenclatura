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
    internal partial class Personal : SubFicha
    {
        internal Personal()
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
            descripcion_txt.KeyDown += new KeyEventHandler(base.enter_KeyDown);
            apaterno_txt.KeyDown += new KeyEventHandler(base.enter_KeyDown);
            amaterno_txt.KeyDown += new KeyEventHandler(base.enter_KeyDown);
        }

        #region Propiedades
        bool Habilitar
        {
            get { return descripcion_txt.Enabled; }
            set
            {
                codigo_txt.Enabled = value;
                descripcion_txt.Enabled = value;
                apaterno_txt.Enabled = value;
                amaterno_txt.Enabled = value;
                cargo_cbo.Enabled = value;
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
            cargo_cbo.SelectedIndex = 0;
        }
        void listar()
        {
            FICHA_ds = (new cPersonal()).listar();
            base.refrescar();
            SUBFICHA_bs.DataSource = FICHA_ds;
            SUBFICHA_bs.DataMember = "VS_LISTAR_PERSONAL";
        }
        void guardar()
        {
            if (codigo_txt.Text.Length == 8 )
            {
                if (descripcion_txt.Text.Length > 0)
                {
                    cPersonal personal = new cPersonal();
                    personal.DNI = codigo_txt.Text;
                    personal.Nombre = descripcion_txt.Text;
                    personal.Apellido_Paterno = apaterno_txt.Text;
                    personal.Apellido_Materno = amaterno_txt.Text;
                    personal.Cargo = cargo_cbo.Text;
                    personal.Usuario = Usuario;
                    i = personal.guardar();
                    if (i > 0) MessageBox.Show("Se a Insertando Correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else MessageBox.Show("Error, el personal : '" + codigo_txt.Text + "', ya existe en el base de datos.", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    iniciar();
                }
            }
            else
            {
                MessageBox.Show("Error, el Nro. DNI : '" + codigo_txt.Text + "', no es valido, ingrese un dni de 8 digitos.", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        void modificar()
        {
            if (codigo_txt.Text.Length == 8)
            {
                if (descripcion_txt.Text.Length > 0)
                {
                    cPersonal personal = new cPersonal();
                    personal.DNI = codigo_txt.Text;
                    personal.Nombre = descripcion_txt.Text;
                    personal.Apellido_Paterno = apaterno_txt.Text;
                    personal.Apellido_Materno = amaterno_txt.Text;
                    personal.Cargo = cargo_cbo.Text;
                    personal.Usuario = Usuario;
                    i = personal.modificar();
                    if (i > 0) MessageBox.Show("Se a Modificado Correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else MessageBox.Show("Error, no se a Modificado Correctamente, , el personal esta en uso y/o esta Desabilitada.", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    iniciar();
                }
            }
            else
            {
                MessageBox.Show("Error, el Nro. DNI : '" + codigo_txt.Text + "', no es valido, ingrese un dni de 8 digitos.", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void eliminar()
        {
            cPersonal personal = new cPersonal();
            personal.DNI = codigo_txt.Text;
            personal.Usuario = Usuario;
            i = personal.eliminar();
            if (i >= 2) MessageBox.Show("Se a eliminado el Registro.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Error, No se puede eliminar, el personal esta en uso y/o esta Desabilitada.", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                base.listar_busqueda();
                codigo_txt.DataBindings.Add(new Binding("Text", SUBFICHA_bs, "DNI", true));
                descripcion_txt.DataBindings.Add(new Binding("Text", SUBFICHA_bs, "NOMBRE", true));
                apaterno_txt.DataBindings.Add(new Binding("Text", SUBFICHA_bs, "PATERNO", true));
                amaterno_txt.DataBindings.Add(new Binding("Text", SUBFICHA_bs, "MATERNO", true));
                cargo_cbo.DataBindings.Add(new Binding("SelectedItem", SUBFICHA_bs, "CARGO", true));
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
                        codigo_txt.Enabled = false;
                        principal_tc.SelectedTab = formulario_tp;
                    }
                    else if (aceptar_tsb.Text == "&Aceptar")modificar();                    
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
                if (SUBFICHA_dgv.Rows.Count > 0)eliminar();                
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
                DataView vista = FICHA_ds.VS_LISTAR_PERSONAL.DefaultView;
                vista.RowFilter = query;
                DataTable tabla = vista.ToTable();
                Reporte reporte;
                if (tabla.Rows.Count > 0) reporte = new Reporte(new personal(), tabla);
                else reporte = new Reporte(new personal(), FICHA_ds);
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
        #endregion
    }
}