using System;
using System.Windows.Forms;
using Componentes;

namespace Formularios
{
    internal partial class Reporte_Certificado_Numeracion : Form
    {
        /// <summary>
        /// Autor                   : Luis Amos
        /// Fecha de Creación       : 01 - 02 - 2011
        /// Fecha de Modificación   : 21 - 02 - 2012
        /// </summary>
        internal Reporte_Certificado_Numeracion()
        {
            InitializeComponent();
        }
        #region Variables Globales
        internal long id_certificado=0;
        internal int codigo_puerta =0;
        #endregion

        #region Eventos
        private void certificado_numeracion_Load(object sender, EventArgs e)
        {
            if(id_certificado != 0 && codigo_puerta != 0) web.Url = new System.Uri(string.Format(@"http://{0}:{1}/cat/rpt/reporteCertificadoNumeracion.php?id={2}&codigo={3}", cConexion.Servidor_Web, cConexion.Puerto,id_certificado,codigo_puerta), System.UriKind.Absolute);
        }

        private void imprimir_tsb_Click(object sender, EventArgs e)
        {            
            web.ShowPrintDialog();
        }
        #endregion
    }
}
