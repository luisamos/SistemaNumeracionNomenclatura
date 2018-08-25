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
    internal partial class Configuracion_Supervisor_Tecnico_Catastral_Digitacion : Form
    {
        internal Configuracion_Supervisor_Tecnico_Catastral_Digitacion()
        {
            InitializeComponent();
        }

        #region Eventos
        private void Configuracion_Supervisor_Tecnico_Catastral_Digitacion_Load(object sender, EventArgs e)
        {
            cPersonal personal = new cPersonal();
            //Supervisor
            supervisor_cbo.DataSource = personal.listar_arreglo_supervisor();
            supervisor_cbo.DisplayMember = "ApellidosNombres";
            supervisor_cbo.ValueMember = "DNI";
            //Técnico Catastral
            tecnico_catastral_cbo.DataSource = personal.listar_arreglo_tecnico_catastral();
            tecnico_catastral_cbo.DisplayMember = "ApellidosNombres";
            tecnico_catastral_cbo.ValueMember = "DNI";
            //Vº.Bº. Digitación
            digitacion_cbo.DataSource = personal.listar_arreglo_digitacion();
            digitacion_cbo.DisplayMember = "ApellidosNombres";
            digitacion_cbo.ValueMember = "DNI";

            supervisor_cbo.SelectedValue = cPersonal.DNI_Supervisor;
            tecnico_catastral_cbo.SelectedValue = cPersonal.DNI_Tecnico_Catastral;
            digitacion_cbo.SelectedValue = cPersonal.DNI_Digitacion;            
        }

        private void aceptar_btn_Click(object sender, EventArgs e)
        {            
            if(supervisor_cbo.DataSource != null) cPersonal.DNI_Supervisor = supervisor_cbo.SelectedValue.ToString();
            if(tecnico_catastral_cbo.DataSource != null) cPersonal.DNI_Tecnico_Catastral =tecnico_catastral_cbo.SelectedValue.ToString();
            if(digitacion_cbo.DataSource != null) cPersonal.DNI_Digitacion= digitacion_cbo.SelectedValue.ToString();
            MessageBox.Show("Se a actualizado el registro correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cConfiguracion.actualizar();
            Close();
        }
        #endregion        
    }
}
