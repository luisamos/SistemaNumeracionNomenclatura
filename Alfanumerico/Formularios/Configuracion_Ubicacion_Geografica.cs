using System;
using System.Linq;
using System.Windows.Forms;
using Componentes;

namespace Formularios
{
    /// <summary>
    /// Autor                   : Luis Amos - Dunia
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    internal partial class Configuracion_Ubicacion_Geografica : Form
    {
        internal Configuracion_Ubicacion_Geografica()
        {
            InitializeComponent();
        }

        #region Variables Globales
        cUbicacion_Geografica ubicacionGeografica = new cUbicacion_Geografica();
        #endregion

        #region Metodos
        void listarDepartamento()
        {
            departamento_cbo.DataSource = ubicacionGeografica.listar_departamento();
            departamento_cbo.DisplayMember = "Key";
        }

        void listarProvincia()
        {
            provincia_cbo.DataSource = ubicacionGeografica.listar_provincia(departamento_cbo.Text);
            provincia_cbo.DisplayMember = "Key";
        }

        void listarDistrito()
        {
            distrito_cbo.DataSource = ubicacionGeografica.listar_distrito(provincia_cbo.Text);
            distrito_cbo.DisplayMember = "Key";
        }
        #endregion

        #region Eventos
        private void Configuracion_Ubicacion_Geografica_Load(object sender, EventArgs e)
        {
            listarDepartamento();
            departamento_cbo.SelectedIndex = Convert.ToInt16(cUbicacion_Geografica.Codigo_Departamento) - 1;
            provincia_cbo.SelectedIndex = Convert.ToInt16(cUbicacion_Geografica.Codigo_Provincia) - 1;
            distrito_cbo.SelectedIndex = Convert.ToInt16(cUbicacion_Geografica.Codigo_Distrito) - 1;
        }

        private void departamento_cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            listarProvincia();
        }

        private void provincia_cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            listarDistrito();
        }

        private void aceptar_btn_Click(object sender, EventArgs e)
        {
            try
            {
                IGrouping<string, string> item = ubicacionGeografica.buscar(distrito_cbo.Text);
                if (item != null)
                {
                    cUbicacion_Geografica.Codigo_Departamento = item.ElementAt(0).Substring(0, 2);
                    cUbicacion_Geografica.Codigo_Provincia = item.ElementAt(0).Substring(2, 2);
                    cUbicacion_Geografica.Codigo_Distrito = item.ElementAt(0).Substring(4, 2);
                    string texto = string.Format("Departamento:\t{0}\nProvincia:\t\t{1}\nDistrito:\t\t{2}\n\nSe a actualizado correctamente.", departamento_cbo.Text, provincia_cbo.Text, distrito_cbo.Text);
                    MessageBox.Show(texto,"Correcto",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    cConfiguracion.actualizar();
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error:  Configuración Ubicación Geográfica", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
