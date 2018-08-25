using System.Windows.Forms;
using Componentes;

namespace Formularios
{
    /// <summary>
    /// Autor                   : Luis Amos - Dunia
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    internal partial class Configuracion_Sistema : Form
    {
        internal Configuracion_Sistema()
        {
            InitializeComponent();
        }

        #region Eventos
        private void Configuracion_Sistema_Load(object sender, System.EventArgs e)
        {
            cConfiguracion.cargar_configuracion();
            logoMunicipal_pb.ImageLocation = cConfiguracion.Logo;
            nombreMunicipio_txt.Text = cConfiguracion.Municipalidad;
            alcalde_txt.Text = cConfiguracion.Alcalde;
            direccion_txt.Text = cConfiguracion.Direccion;
            ruc_txt.Text = cConfiguracion.Ruc;
            telefono_txt.Text = cConfiguracion.Telefono;
            correoElectronico_txt.Text = cConfiguracion.Correo_Electronico;
        }

        private void aceptar_btn_Click(object sender, System.EventArgs e)
        {
            cConfiguracion.Municipalidad = nombreMunicipio_txt.Text;
            cConfiguracion.Alcalde = alcalde_txt.Text;
            cConfiguracion.Direccion = direccion_txt.Text;
            cConfiguracion.Ruc = ruc_txt.Text;
            cConfiguracion.Telefono = telefono_txt.Text;
            cConfiguracion.Correo_Electronico = correoElectronico_txt.Text;
            MessageBox.Show("Se a modificado la configuración del Sistema Correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cConfiguracion.actualizar();
            Close();
        }
        #endregion
    }
}
