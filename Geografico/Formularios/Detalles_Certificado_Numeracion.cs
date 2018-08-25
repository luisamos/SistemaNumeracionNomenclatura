using System;
using System.Windows.Forms;
using Componentes;
using System.Collections.Generic;

namespace Formularios
{
    /// <summary>
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    internal partial class Detalles_Certificado_Numeracion : Inicio
    {
        internal Detalles_Certificado_Numeracion()
        {
            InitializeComponent();
        }

        #region Variables Globales
        internal string Usuario;
        internal int codigo_puerta;
        internal string codigo_via;
        internal string direccion;
        internal string tipo_puerta;
        long id = 0;
        #endregion

        #region Metodos
        void certificado_numeracion(long id_certificado)
        {
            Reporte_Certificado_Numeracion certificado_numeracion = new Reporte_Certificado_Numeracion();
            certificado_numeracion.id_certificado = id_certificado;
            certificado_numeracion.codigo_puerta = codigo_puerta;
            certificado_numeracion.Show();
            Close();
        }
        #endregion

        #region Eventos
        private void detalles_certificado_numeracion_Load(object sender, EventArgs e)
        {
            try
            {
                cCertificado_Numeracion certificado_numeracion = new cCertificado_Numeracion();
                List<FICHA_ds.VS_LISTAR_CERTIFICADO_NUMERACIONRow> lista = certificado_numeracion.buscar(codigo_puerta);
                if (lista.Count>0)
                {
                    FICHA_ds.VS_LISTAR_CERTIFICADO_NUMERACIONRow fila = lista[0];
                    id = fila.ID;                    
                    sigla_txt.Text = fila.SIGLA;
                    numeroExpediente_txt.Text = fila.NUMERO_EXPEDIENTE;
                    fecha_txt.Value = fila.FECHA;
                    fotografiaDigital_pb.Image = (fila.IsFOTOGRAFIA_DIGITALNull()) ? null : cConfiguracion.toImage(fila.FOTOGRAFIA_DIGITAL);
                    añoFotografiaDigital_txt.Text = fila.AÑO_FOTOGRAFIA_DIGITAL;
                    numeroRecibo_txt.Text = fila.NUMERO_RECIBO;
                    cuerpo_txt.Text = fila.CUERPO;
                    propietario_txt.Text = fila.PROPIETARIO;
                    observaciones_txt.Text = fila.OBSERVACIONES;
                    aceptar_btn.Text = "&Actualizar";
                }
                else añoFotografiaDigital_txt.Text = DateTime.Now.Year.ToString();

                codigoVia_txt.Text = codigo_via;
                direccion_txt.Text = direccion;
                tipoPuerta_txt.Text = tipo_puerta;
                usuario_lbl.Text = Usuario;
                mensaje_lbl.Text = "Certificado de Numeración:";
                usuario_lbl.Text = Usuario;
                numeroExpediente_txt.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error, Cargar Certificado de Numeración", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) SendKeys.Send("{TAB}");
            if (e.KeyData == Keys.Escape) SendKeys.Send("+{TAB}");
            else base.OnKeyDown(e);
        }

        private void fotografiaDigital_pb_Click(object sender, EventArgs e)
        {
            DialogResult rpta = abrirFotografia.ShowDialog();
            if (rpta == System.Windows.Forms.DialogResult.OK)
            {
                fotografiaDigital_pb.ImageLocation = abrirFotografia.FileName;                
                añoFotografiaDigital_txt.Focus();
            }
            else
            {
                fotografiaDigital_pb.ImageLocation = null;                
                añoFotografiaDigital_txt.Text = "";
            }
        }

        private void aceptar_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (numeroExpediente_txt.Text.Length > 0)
                {
                    if (fotografiaDigital_pb.Image != null)
                    {
                        if (numeroRecibo_txt.Text.Length > 0)
                        {
                            if (cuerpo_txt.Text.Length > 0)
                            {
                                if (propietario_txt.Text.Length > 0)
                                {
                                    cCertificado_Numeracion Certificado_Numeracion = new cCertificado_Numeracion();
                                    if (aceptar_btn.Text == "&Actualizar")
                                    {
                                        Certificado_Numeracion.Id = id;
                                        Certificado_Numeracion.Sigla = sigla_txt.Text.Trim();
                                        Certificado_Numeracion.Codigo_Puerta = codigo_puerta;
                                        Certificado_Numeracion.Numero_Expediente = numeroExpediente_txt.Text.Trim();
                                        Certificado_Numeracion.Fecha = fecha_txt.Value;
                                        Certificado_Numeracion.Fotografia_Digital = fotografiaDigital_pb.Image;
                                        Certificado_Numeracion.Año_Fotografia_Digital = añoFotografiaDigital_txt.Text;
                                        Certificado_Numeracion.Numero_Recibo = numeroRecibo_txt.Text.Trim();
                                        Certificado_Numeracion.Cuerpo = cuerpo_txt.Text.Trim();
                                        Certificado_Numeracion.Propietario = propietario_txt.Text.Trim();
                                        Certificado_Numeracion.Observaciones = observaciones_txt.Text.Trim();
                                        Certificado_Numeracion.Usuario = Usuario;
                                        int i = Certificado_Numeracion.modificar();
                                        if (i != 0) certificado_numeracion(Certificado_Numeracion.Id);
                                    }
                                    else if(aceptar_btn.Text == "&Guardar")
                                    {
                                        Certificado_Numeracion.Sigla = sigla_txt.Text.Trim();
                                        Certificado_Numeracion.Codigo_Puerta = codigo_puerta;
                                        Certificado_Numeracion.Numero_Expediente = numeroExpediente_txt.Text.Trim();
                                        Certificado_Numeracion.Fecha = fecha_txt.Value;
                                        Certificado_Numeracion.Fotografia_Digital = fotografiaDigital_pb.Image;
                                        Certificado_Numeracion.Año_Fotografia_Digital = añoFotografiaDigital_txt.Text;
                                        Certificado_Numeracion.Numero_Recibo = numeroRecibo_txt.Text.Trim();
                                        Certificado_Numeracion.Cuerpo = cuerpo_txt.Text.Trim();
                                        Certificado_Numeracion.Propietario = propietario_txt.Text.Trim();
                                        Certificado_Numeracion.Observaciones = observaciones_txt.Text.Trim();
                                        Certificado_Numeracion.Usuario = Usuario;
                                        string id_certificado = Certificado_Numeracion.guardar();
                                        if (id_certificado != "") certificado_numeracion(int.Parse(id_certificado));
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Debe de ingresar el Propietario del inmueble.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    propietario_txt.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Debe de ingresar el cuerpo del certificado de numeración.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                cuerpo_txt.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Debe de ingresar el número de recibo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            numeroRecibo_txt.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe de ingresar una fotografía de la propiedad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        fotografiaDigital_pb_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Debe de ingresar el Número de expediente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    numeroExpediente_txt.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error, Guardar y/o Modificar Certificado de Numeración", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        
        #endregion
    }
}
