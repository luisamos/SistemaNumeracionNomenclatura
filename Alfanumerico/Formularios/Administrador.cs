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
    internal partial class Administrador : SubFicha
    {
        internal Administrador()
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
            direccion_txt.KeyDown += new KeyEventHandler(base.enter_KeyDown);
            celular_txt.KeyDown += new KeyEventHandler(base.enter_KeyDown);
            correoElectronico_txt.KeyDown += new KeyEventHandler(base.enter_KeyDown);
            contraseña_txt.KeyDown += new KeyEventHandler(base.enter_KeyDown);
        }

        #region Propiedades
        bool Habilitar
        {
            get { return descripcion_txt.Enabled; }
            set
            {
                codigo_txt.Enabled = value;                
                descripcion_txt.Enabled = value;
                direccion_txt.Enabled = value;
                celular_txt.Enabled = value;
                correoElectronico_txt.Enabled = value;
                contraseña_txt.Enabled = value;
                contraseña_ckb.Enabled = value;
                habilitado_ckb.Enabled = (codigo_txt.Text == "ADMIN")?false: value;
                administrador_ckb.Enabled = (codigo_txt.Text == "ADMIN") ? false : value;                
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
        void listar()
        {
            FICHA_ds = (new cUsuario()).listar();
            base.refrescar();
            SUBFICHA_bs.DataSource = FICHA_ds;
            SUBFICHA_bs.DataMember = "VS_LISTAR_USUARIO";
            DataTable tabla_temporal = FICHA_ds.VS_LISTAR_USUARIO.DefaultView.ToTable();
            DataRow[] fila = tabla_temporal.Select(string.Format("USUARIO = '{0}'", Usuario));
            int posicion= -1;
            if (fila.Length > 0) posicion = tabla_temporal.Rows.IndexOf(fila[0]);
            SUBFICHA_dgv["USUARIO", posicion].Selected = true;
        }
        void guardar()
        {
            if (codigo_txt.Text.Length >0)
            {
                if (descripcion_txt.Text.Length > 3)
                {
                    if (contraseña_txt.Text.Length > 0)
                    {
                        cUsuario usuario = new cUsuario();
                        usuario.Login = codigo_txt.Text.Trim();
                        usuario.Apellidos_nombres = descripcion_txt.Text.Trim();
                        usuario.Direccion = direccion_txt.Text.Trim();
                        usuario.Celular = celular_txt.Text.Trim();
                        usuario.Correo_Electronico = correoElectronico_txt.Text.Trim();
                        usuario.Contraseña = contraseña_txt.Text.Trim();
                        usuario.Habilitado = habilitado_ckb.Checked;
                        usuario.Administrador = administrador_ckb.Checked;
                        usuario.Usuario = Usuario;
                        i = usuario.guardar();
                        if (i > 0) MessageBox.Show("Se a Insertando Correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else MessageBox.Show("Error, El Usuario : '" + codigo_txt.Text + "', ya existe en el base de datos.", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        iniciar();
                    }
                    else
                    {
                        MessageBox.Show("Contraseña es campo obligado a ingresear", "Error Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        contraseña_txt.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Apellidos y Nombres es campo obligado a ingresear", "Error Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    descripcion_txt.Focus();
                }
            }
            else
            {
                MessageBox.Show("Usuario es campo obligado a ingresear", "Error Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                codigo_txt.Focus();
            }
        }
        void modificar()
        {
            if (descripcion_txt.Text.Length > 0)
            {
                if (contraseña_txt.Text.Length > 0)
                {
                    cUsuario usuario = new cUsuario();
                    usuario.Login = codigo_txt.Text.Trim();
                    usuario.Apellidos_nombres = descripcion_txt.Text.Trim();
                    usuario.Direccion = direccion_txt.Text.Trim();
                    usuario.Celular = celular_txt.Text.Trim();
                    usuario.Correo_Electronico = correoElectronico_txt.Text.Trim();
                    usuario.Contraseña = contraseña_txt.Text.Trim();
                    usuario.Habilitado = habilitado_ckb.Checked;
                    usuario.Administrador = administrador_ckb.Checked;
                    usuario.Usuario = Usuario;
                    i = usuario.modificar();
                    if (i > 0) MessageBox.Show("Se a Modificado Correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else MessageBox.Show("Error, no se a Modificado Correctamente, el Usuario esta en uso y/o esta Desabilitada.", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    iniciar();
                }
                else
                {
                    MessageBox.Show("Contraseña es campo obligado a ingresear", "Error Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    contraseña_txt.Focus();
                }
            }
            else
            {
                MessageBox.Show("Apellidos y Nombres es campo obligado a ingresear", "Error Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                descripcion_txt.Focus();
            }
        }
        void eliminar()
        {
            cUsuario usuario = new cUsuario();
            usuario.Login = codigo_txt.Text.Trim();            
            usuario.Usuario = Usuario;
            i = usuario.eliminar();
            if (i >= 2) MessageBox.Show("Se a eliminado el Registro", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Error, No se puede eliminar, el Usuario esta en uso y/o esta Desabilitada.", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                SUBFICHA_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                codigo_txt.DataBindings.Add(new Binding("Text", SUBFICHA_bs, "USUARIO", true));                
                descripcion_txt.DataBindings.Add(new Binding("Text", SUBFICHA_bs, "APELLIDOS Y NOMBRES", true));
                celular_txt.DataBindings.Add(new Binding("Text", SUBFICHA_bs, "CELULAR", true));             
                direccion_txt.DataBindings.Add(new Binding("Text", SUBFICHA_bs, "DIRECCION", true));                
                correoElectronico_txt.DataBindings.Add(new Binding("Text", SUBFICHA_bs, "CORREO ELECTRONICO", true));                
                contraseña_txt.DataBindings.Add(new Binding("Text", SUBFICHA_bs, "CONTRASEÑA", true));
                habilitado_ckb.DataBindings.Add(new Binding("Checked", SUBFICHA_bs, "HABILITADO", true));
                administrador_ckb.DataBindings.Add(new Binding("Checked", SUBFICHA_bs, "ADMINISTRADOR", true));
                categoria_tsc.SelectedIndex = 1;
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
            if (Habilitar)
            {
                Habilitar = false;
                base.controles = true;
            }
        }

        private void vistaPrevia_tsb_Click(object sender, EventArgs e)
        {
            DataView vista = FICHA_ds.VS_LISTAR_USUARIO.DefaultView;
            vista.RowFilter = query;
            DataTable tabla = vista.ToTable();
            Reporte reporte;
            if (tabla.Rows.Count > 0) reporte = new Reporte(new usuario(), tabla);
            else reporte = new Reporte(new usuario(), FICHA_ds);
            reporte.Text = "Vista Previa, " + this.Text;
            reporte.ShowDialog();
        }

        private void cerrar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (i != 0) this.DialogResult = DialogResult.OK;
        }

        private void contraseña_ckb_CheckedChanged(object sender, EventArgs e)
        {
            contraseña_txt.PasswordChar = (contraseña_ckb.Checked) ? (char)Keys.None : '*';
            contraseña_txt.Focus();
        }
        #endregion        
    }
}
