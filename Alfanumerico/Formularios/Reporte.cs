using System;
using System.Windows.Forms;
using System.Data;
using Componentes;
using CrystalDecisions.ReportAppServer.ReportDefModel;
using CrystalDecisions.ReportAppServer.ClientDoc;
using Alfanumerico.Rpt;

namespace Formularios
{
    /// <summary>
    /// Autor                   : Luis Amos - Dunia
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    internal partial class Reporte : Form
    {
        internal Reporte(CrystalDecisions.CrystalReports.Engine.ReportClass rpt, FICHA_ds FICHA_ds)
        {
            try
            {
                InitializeComponent();
                string url_img = cConfiguracion.Logo;
                rpt.SetDataSource(FICHA_ds);
                ISCDReportClientDocument rpt_cliente_doc = rpt.ReportClientDocument;
                Section seccion = rpt_cliente_doc.ReportDefController.ReportDefinition.ReportHeaderArea.Sections[0];
                rpt_cliente_doc.ReportDefController.ReportObjectController.ImportPicture(url_img, seccion, 50, 50);
                rpt.SetParameterValue("municipalidad", cConfiguracion.Municipalidad);
                rpt.SetParameterValue("direccion", cConfiguracion.Direccion);
                rpt.SetParameterValue("ruc", string.Format("RUC : {0}", cConfiguracion.Ruc));
                rpt.SetParameterValue("telefono", string.Format("Telef. : {0}", cConfiguracion.Telefono));
                this.visor.ReportSource = rpt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error Reporte",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }            
        }

        internal Reporte(CrystalDecisions.CrystalReports.Engine.ReportClass rpt, DataTable tabla)
        {
            try
            {
                InitializeComponent();
                string url_img = cConfiguracion.Logo;
                rpt.SetDataSource(tabla);
                ISCDReportClientDocument rpt_cliente_doc = rpt.ReportClientDocument;
                Section seccion = rpt_cliente_doc.ReportDefController.ReportDefinition.ReportHeaderArea.Sections[0];
                rpt_cliente_doc.ReportDefController.ReportObjectController.ImportPicture(url_img, seccion, 50, 50);
                rpt.SetParameterValue("municipalidad", cConfiguracion.Municipalidad);
                rpt.SetParameterValue("direccion", cConfiguracion.Direccion);
                rpt.SetParameterValue("ruc", string.Format("RUC : {0}", cConfiguracion.Ruc));
                rpt.SetParameterValue("telefono", string.Format("Telef. : {0}", cConfiguracion.Telefono));
                this.visor.ReportSource = rpt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error Reporte",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        internal Reporte(char tipo, FICHA_ds FICHA_ds)
        {
            try
            {
                InitializeComponent();
                CrystalDecisions.CrystalReports.Engine.ReportClass rpt = null;
                switch (tipo)
                {
                    case '1':
                        rpt = new ficha_catastral_vias_urbanas();
                        break;
                    case '2':
                        rpt = new ficha_catastral_especifica();
                        break;
                    case '3':
                        rpt = new ficha_catastral_espacio_recreacion();
                        break;
                    case '4':
                        rpt = new ficha_catastral_equipamiento_urbano();
                        break;
                }
                rpt.SetDataSource(FICHA_ds);
                this.visor.ReportSource = rpt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error Reporte",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        internal Reporte(char tipo,DataTable tabla)
        {
            try
            {
                InitializeComponent();
                CrystalDecisions.CrystalReports.Engine.ReportClass rpt = null;
                switch (tipo)
                {
                    case '1':
                        rpt = new ficha_catastral_vias_urbanas();
                        break;
                    case '2':
                        rpt = new ficha_catastral_especifica();
                        break;
                    case '3':
                        rpt = new ficha_catastral_espacio_recreacion();
                        break;
                    case '4':
                        rpt = new ficha_catastral_equipamiento_urbano();
                        break;
                }
                rpt.SetDataSource(tabla);
                this.visor.ReportSource = rpt;
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message,"Error Reporte",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }           
        }
    }
}
