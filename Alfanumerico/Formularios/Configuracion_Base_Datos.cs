using System;
using System.Windows.Forms;
using Componentes;

namespace Formularios
{
    /// <summary>
    /// Autor                   : Luis Amos - Dunia
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    internal partial class Configuracion_Base_Datos : Form
    {
        internal Configuracion_Base_Datos()
        {
            InitializeComponent();
        }

        #region Eventos
        private void Configuracion_Base_Datos_Load(object sender, EventArgs e)
        {
            cConexion.cargar_configuracion();
            servidor_txt.Text = cConexion.Servidor_Base_Datos;
            baseDatos_txt.Text = cConexion.BaseDatos;
            usuario_txt.Text = cConexion.User;
            contraseña_txt.Text = cConexion.Password;
        }

        private void aceptar_btn_Click(object sender, System.EventArgs e)
        {
            cConexion.Servidor_Base_Datos = servidor_txt.Text;
            cConexion.BaseDatos = baseDatos_txt.Text;
            cConexion.User = usuario_txt.Text;
            cConexion.Password = contraseña_txt.Text;            
            MessageBox.Show("Se a modificado la configuración a la base de datos. cierre el Programa e inicie de nuevo.","Correcto",MessageBoxButtons.OK,MessageBoxIcon.Information);
            cConfiguracion.actualizar();
            Close();
        }
        #endregion
    }
}
