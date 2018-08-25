using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Componentes;
namespace Formularios
{
    /// <summary>
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    internal partial class Ficha_Catastral_Equipamiento_Urbano : Form
    {
        internal Ficha_Catastral_Equipamiento_Urbano()
        {
            InitializeComponent();
        }

        #region Variables Globales
        cFicha_Catastral_Equipamiento_Urbano ficha_catastral_equipamiento_urbano = new cFicha_Catastral_Equipamiento_Urbano();
        cVias Vias = new cVias();
        internal string Codigo_Distrito = "";
        internal string Usuario = "";
        internal string Hash = "";
        #endregion

        #region Eventos
        private void ficha_equipamiento_urbano_Load(object sender, EventArgs e)
        {
            usuario_lbl.Text = usuario_lbl.Text = Usuario;
            baseDatos_lbl.Text = cConexion.BaseDatos;
            puntoZ_txt.Focus();
        }

        private void guardarFicha_btn_Click(object sender, EventArgs e)
        {
            try
            {
                ficha_catastral_equipamiento_urbano.Departamento = departamento_lbl.Text;
                ficha_catastral_equipamiento_urbano.Provincia = provincia_lbl.Text;
                ficha_catastral_equipamiento_urbano.Distrito = distrito_lbl.Text;
                ficha_catastral_equipamiento_urbano.Sector = sector_lbl.Text;
                ficha_catastral_equipamiento_urbano.Manzana = manzana_lbl.Text;
                ficha_catastral_equipamiento_urbano.Lote = lote_lbl.Text;
                ficha_catastral_equipamiento_urbano.Nombre_Equipamiento_Urbano = nombreEquipamientoUrbano_lbl.Text;
                cTipo_Equipamiento_Urbano Tipo_Equipamiento_Urbano = new cTipo_Equipamiento_Urbano();
                Tipo_Equipamiento_Urbano.Codigo = tipoEquipamientoUrbano_lbl.Text;
                ficha_catastral_equipamiento_urbano.Tipo_Equipamiento_Urbano = Tipo_Equipamiento_Urbano;
                cUsos Usos = new cUsos();
                Usos.Codigo = (usos_lbl.Text.Length>0)?usos_lbl.Text: null;
                ficha_catastral_equipamiento_urbano.Usos = Usos;
                ficha_catastral_equipamiento_urbano.Punto_X = puntoX_lbl.Text;
                ficha_catastral_equipamiento_urbano.Punto_Y = puntoY_lbl.Text;
                ficha_catastral_equipamiento_urbano.Punto_Z = puntoZ_txt.Text;
                ficha_catastral_equipamiento_urbano.Hash = Hash;
                ficha_catastral_equipamiento_urbano.Usuario = Usuario.ToUpper();
                string rpta = ficha_catastral_equipamiento_urbano.guardar(planoUbicacion_pb.Image, añoPlanoUbicacion_txt.Text, (fotografiaDigital_pb.ImageLocation != "" && fotografiaDigital_pb.ImageLocation != null) ? fotografiaDigital_pb.ImageLocation : "", añoFotografiaDigital_txt.Text);
                if (rpta != "")
                {
                    MessageBox.Show("Se ha insertado Correctamente, Código de Registro es: " + rpta, "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else MessageBox.Show("Error:  Intentelo nuevamente.", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (sqlServerException ex)
            {
                MessageBox.Show(ex.Message, "Error Guardar, Ficha Catastral Equipamiento Urbano",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
            if (e.KeyData == Keys.Escape)
            {
                SendKeys.Send("+{TAB}");
            }
            else
            {
                base.OnKeyDown(e);
            }
        }

        private void seleccionarAreaPlanoUbicacion_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            System.Threading.Thread.Sleep(250);
            Fondo Fondo = new Fondo();
            if (Fondo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                planoUbicacion_pb.ImageLocation = string.Format(@"{0}\temp.png", cConexion.Ruta);
                sectorPlanoUbicacion_lbl.Text = sector_lbl.Text;
                manzanaPlanoUbicacion_lbl.Text = manzana_lbl.Text;
                lotePlanoUbicacion_lbl.Text = lote_lbl.Text;
                edificaPlanoUbicacion_lbl.Text = edifica_lbl.Text;
                añoPlanoUbicacion_txt.Text = DateTime.Now.Year.ToString();
                añoPlanoUbicacion_txt.Focus();
            }
            this.Show();
        }        

        private void planoUbicacion_pb_Click(object sender, EventArgs e)
        {
            DialogResult rpta = abrirFotografia.ShowDialog();
            if (rpta == System.Windows.Forms.DialogResult.OK)
            {
                planoUbicacion_pb.ImageLocation = abrirFotografia.FileName;
                sectorPlanoUbicacion_lbl.Text = sector_lbl.Text;
                manzanaPlanoUbicacion_lbl.Text = manzana_lbl.Text;
                lotePlanoUbicacion_lbl.Text = lote_lbl.Text;
                edificaPlanoUbicacion_lbl.Text = edifica_lbl.Text;
                añoPlanoUbicacion_txt.Text = DateTime.Now.Year.ToString();
                añoPlanoUbicacion_txt.Focus();
            }
            else
            {
                fotografiaDigital_pb.ImageLocation = null;
                sectorPlanoUbicacion_lbl.Text = "";
                manzanaPlanoUbicacion_lbl.Text = "";
                lotePlanoUbicacion_lbl.Text = "";
                edificaPlanoUbicacion_lbl.Text = "";
                añoPlanoUbicacion_txt.Text = "";
            }
        }

        private void fotografiaDigital_pb_Click(object sender, EventArgs e)
        {
            DialogResult rpta = abrirFotografia.ShowDialog();
            if (rpta == System.Windows.Forms.DialogResult.OK)
            {
                fotografiaDigital_pb.ImageLocation = abrirFotografia.FileName;
                sectorFotografiaDigital_lbl.Text = sector_lbl.Text;
                manzanaFotografiaDigital_lbl.Text = manzana_lbl.Text;
                loteFotografiaDigital_lbl.Text = lote_lbl.Text;
                edificaFotografiaDigital_lbl.Text = edifica_lbl.Text;
                añoFotografiaDigital_txt.Text = DateTime.Now.Year.ToString();
                añoFotografiaDigital_txt.Focus();
            }
            else
            {
                fotografiaDigital_pb.ImageLocation = null;
                sectorFotografiaDigital_lbl.Text = "";
                manzanaFotografiaDigital_lbl.Text = "";
                loteFotografiaDigital_lbl.Text = "";
                edificaFotografiaDigital_lbl.Text = "";
                añoFotografiaDigital_txt.Text = "";
            }
        }
        #endregion
    }
}