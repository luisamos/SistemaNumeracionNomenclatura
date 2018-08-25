using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Componentes;

namespace Formularios
{
    /// <summary>
    /// Autor                   : Luis Amos - Dunia
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    internal partial class Usuario : Form
    {
        internal Usuario(string usuario)
        {
            InitializeComponent();
            user = usuario;
        }
        #region Variables Globales
        string user;
        #endregion

        #region Eventos
        private void usuario_Load(object sender, EventArgs e)
        {
            try
            {
                cUsuario usuario = new cUsuario();
                List<FICHA_ds.VS_LISTAR_USUARIORow> lista = usuario.buscar(user);
                if (lista.Count > 0)
                {
                    FICHA_ds.VS_LISTAR_USUARIORow fila = lista[0];
                    usuario_lbl.Text = fila.USUARIO;
                    apellidosNombres_txt.Text = fila.APELLIDOS_Y_NOMBRES;
                    direccion_txt.Text = fila.DIRECCION;
                    celular_txt.Text = fila.CELULAR;
                    correoElectronico_txt.Text = fila.CORREO_ELECTRONICO;
                    contraseña_txt.Text = fila.CONTRASEÑA;
                    habilitado_ckb.Checked = fila.HABILITADO;
                    administrador_ckb.Checked = fila.ADMINISTRADOR;                    
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error - Listar");
            }
            
        }

        private void guardar_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (apellidosNombres_txt.Text.Length > 0)
                {
                    if (contraseña_txt.Text.Length > 0)
                    {
                        cUsuario usuario = new cUsuario();
                        usuario.Login = usuario_lbl.Text.Trim();
                        usuario.Apellidos_nombres = apellidosNombres_txt.Text.Trim();
                        usuario.Direccion = direccion_txt.Text.Trim();
                        usuario.Celular = celular_txt.Text.Trim();
                        usuario.Correo_Electronico = correoElectronico_txt.Text.Trim();
                        usuario.Contraseña = contraseña_txt.Text.Trim();
                        usuario.Habilitado = habilitado_ckb.Checked;
                        usuario.Administrador = administrador_ckb.Checked;
                        usuario.Usuario = user;
                        int i = usuario.modificar();
                        if (i > 0)
                        {
                            MessageBox.Show("Se a Modificado Correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                        else MessageBox.Show("Error, no se a Modificado Correctamente, el Usuario esta en uso y/o esta Desabilitada.", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);                        
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
                    apellidosNombres_txt.Focus();
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Error - Guardar");
            }
        }

        private void contraseña_ckb_CheckedChanged(object sender, EventArgs e)
        {
            contraseña_txt.PasswordChar = (contraseña_ckb.Checked) ? (char)Keys.None : '*';
            contraseña_txt.Focus();
        }

        private void enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) SendKeys.Send("{TAB}");
            if (e.KeyData == Keys.Escape) SendKeys.Send("+{TAB}");
            else base.OnKeyDown(e);
        }
        #endregion
    }
}
