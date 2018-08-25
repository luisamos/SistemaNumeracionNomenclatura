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
    internal partial class Ficha_Catastral_Vias_Urbanas : Form
    {
        internal Ficha_Catastral_Vias_Urbanas()
        {
            InitializeComponent();
        }

        #region Variables Globales
        cFicha_Catastral_Vias_Urbanas ficha_catastral_vias_urbanas = new cFicha_Catastral_Vias_Urbanas();
        cVias Vias = new cVias();
        internal string Codigo_Distrito = "";
        internal string Usuario = "";
        internal string Hash = "";
        #endregion

        #region Eventos
        private void ficha_catastral_vias_urbanas_Load(object sender, EventArgs e)
        {
            usuario_lbl.Text = Usuario;
            baseDatos_lbl.Text = cConexion.BaseDatos;
        }

        private void guardarFicha_btn_Click(object sender, EventArgs e)
        {
            try
            {
                ficha_catastral_vias_urbanas.Departamento = departamento_lbl.Text;
                ficha_catastral_vias_urbanas.Provincia = provincia_lbl.Text;
                ficha_catastral_vias_urbanas.Distrito = distrito_lbl.Text;
                ficha_catastral_vias_urbanas.Sector = sector_lbl.Text;
                cVias Vias = new cVias();
                Vias.Codigo = codigoVias_lbl.Text;                
                ficha_catastral_vias_urbanas.Vias = Vias;
                ficha_catastral_vias_urbanas.Cuadra = cuadra_lbl.Text;
                ficha_catastral_vias_urbanas.Punto_Inicial_X= puntoXInicial_lbl.Text;
                ficha_catastral_vias_urbanas.Punto_Inicial_Y = puntoYInicial_lbl.Text;
                ficha_catastral_vias_urbanas.Punto_Inicial_Z = puntoZInicial_txt.Text;
                ficha_catastral_vias_urbanas.Punto_Final_X = puntoXFinal_lbl.Text;
                ficha_catastral_vias_urbanas.Punto_Final_Y = puntoYFinal_lbl.Text;
                ficha_catastral_vias_urbanas.Punto_Final_Z = puntoZFinal_txt.Text;
                ficha_catastral_vias_urbanas.Hash = Hash;
                ficha_catastral_vias_urbanas.Usuario = Usuario.ToUpper();
                string rpta = ficha_catastral_vias_urbanas.guardar(planoVia_pb.Image, añoPlanoVia_txt.Text, seccionTipicaVia_pb.Image, seccionTipicaVia_txt.Text, (fotografiaDigital_pb.ImageLocation != "" && fotografiaDigital_pb.ImageLocation != null) ? fotografiaDigital_pb.ImageLocation : "", añoFotografia_txt.Text);                
                if (rpta != "")
                {
                    MessageBox.Show("Se ha insertado Correctamente, Código de Registro es: " + rpta, "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else MessageBox.Show("Error:  Intentelo nuevamente.", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (sqlServerException ex)
            {
                MessageBox.Show(ex.Message, "Error Guardar, Ficha Catasral Vias Urbanas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void planoVia_pb_Click(object sender, EventArgs e)
        {
            DialogResult rpta = abrirFotografia.ShowDialog();
            if (rpta == System.Windows.Forms.DialogResult.OK)
            {
                planoVia_pb.ImageLocation = abrirFotografia.FileName;
                sectorPlanoVia_lbl.Text = sector_lbl.Text;
                codigoViaPlanoVia_lbl.Text = codigoVias_lbl.Text;
                cuadraPlanoVia_lbl.Text = cuadra_lbl.Text;
                añoPlanoVia_txt.Text = DateTime.Now.Year.ToString();
                añoPlanoVia_txt.Focus();
            }
            else
            {
                fotografiaDigital_pb.ImageLocation = null;
                sectorPlanoVia_lbl.Text = "";
                codigoViaPlanoVia_lbl.Text = "";
                cuadraPlanoVia_lbl.Text = "";
                añoPlanoVia_txt.Text = "";
            }
        }

        private void seccionTipicaVia_lbl_Click(object sender, EventArgs e)
        {
            DialogResult rpta = abrirFotografia.ShowDialog();
            if (rpta == System.Windows.Forms.DialogResult.OK)
            {
                seccionTipicaVia_pb.ImageLocation = abrirFotografia.FileName;
                seccionTipicaVia_txt.Focus();
            }
            else
            {
                seccionTipicaVia_pb.ImageLocation = null;
                seccionTipicaVia_txt.Text = "";
            }
        }

        private void fotografiaDigital_pb_Click(object sender, EventArgs e)
        {
            DialogResult rpta = abrirFotografia.ShowDialog();
            if (rpta == System.Windows.Forms.DialogResult.OK)
            {
                fotografiaDigital_pb.ImageLocation = abrirFotografia.FileName;
                sectorFotografia_lbl.Text = sector_lbl.Text;
                codigoViasFotografia_lbl.Text = codigoVias_lbl.Text;
                cuadraFotografia_lbl.Text = cuadra_lbl.Text;
                añoFotografia_txt.Text = DateTime.Now.Year.ToString();
                añoFotografia_txt.Focus();
            }
            else
            {
                fotografiaDigital_pb.ImageLocation = null;
                sectorFotografia_lbl.Text = "";
                codigoViasFotografia_lbl.Text = "";
                cuadraFotografia_lbl.Text = "";
                añoFotografia_txt.Text = "";
            }
        }

        private void cambiar_btn_Click(object sender, EventArgs e)
        {
            string tempA1, tempA2, tempA3;
            tempA1 = puntoXFinal_lbl.Text;
            tempA2 = puntoYFinal_lbl.Text;
            tempA3 = puntoZFinal_txt.Text;

            puntoXFinal_lbl.Text = puntoXInicial_lbl.Text;
            puntoYFinal_lbl.Text = puntoYInicial_lbl.Text;
            puntoZFinal_txt.Text = puntoZInicial_txt.Text;

            puntoXInicial_lbl.Text = tempA1;
            puntoYInicial_lbl.Text = tempA2;
            puntoZInicial_txt.Text = tempA3;

            cambiar_btn.Text = (cambiar_btn.Text == "<<") ? ">>" : "<<";   
        }        

        private void seleccionarAreaPlanoVia_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            System.Threading.Thread.Sleep(250);
            Fondo Fondo = new Fondo();
            if (Fondo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                planoVia_pb.ImageLocation = string.Format(@"{0}\temp.png", cConexion.Ruta);
                sectorPlanoVia_lbl.Text = sector_lbl.Text;
                codigoViaPlanoVia_lbl.Text = codigoVias_lbl.Text;
                cuadraPlanoVia_lbl.Text = cuadra_lbl.Text;
                añoPlanoVia_txt.Text = DateTime.Now.Year.ToString();
                añoPlanoVia_txt.Focus();
            }
            this.Show();
        }

        private void seleccionarSeccionTipicaVia_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            System.Threading.Thread.Sleep(250);
            Fondo Fondo = new Fondo();
            if (Fondo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                seccionTipicaVia_pb.ImageLocation = string.Format(@"{0}\temp.png", cConexion.Ruta);
                seccionTipicaVia_txt.Focus();
            }
            this.Show();
        }
        #endregion        
    }
}