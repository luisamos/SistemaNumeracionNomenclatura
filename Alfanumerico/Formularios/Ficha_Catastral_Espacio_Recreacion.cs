using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Componentes;
using TextBoxConFormato;
using System.IO;
using Alfanumerico.Rpt;

namespace Formularios
{
    /// <summary>
    /// Autor                   : Luis Amos - Dunia
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    internal partial class Ficha_Catastral_Espacio_Recreacion : Ficha
    {
        internal Ficha_Catastral_Espacio_Recreacion()
        {
            InitializeComponent();
            //Ficha Catastral de Espacio de Recreación
            this.Load += new System.EventHandler(this.listar_Load);
            nuevo_tsb.Click += new EventHandler(nuevo_tsb_Click);
            aceptar_tsb.Click += new EventHandler(aceptar_tsb_Click);
            eliminar_tsb.Click += new EventHandler(eliminar_tsb_Click);
            cancelar_tsb.Click += new EventHandler(cancelar_tsb_Click);
            vistaPrevia_tsb.Click += new EventHandler(vistaPrevia_tsb_Click);
            this.FormClosing += new FormClosingEventHandler(cerrar_FormClosing);
            FICHA_bs.DataSourceChanged += new EventHandler(FICHA_bs_PositionChanged);
            FICHA_bs.PositionChanged += new EventHandler(FICHA_bs_PositionChanged);

            supervisor_lbl.BindingContextChanged += new EventHandler(this.supervisor_lbl_BindingContextChanged);
            tecnicoCatastral_lbl.BindingContextChanged += new EventHandler(tecnicoCatastral_lbl_BindingContextChanged);
            digitalizacion_lbl.BindingContextChanged += new EventHandler(digitalizacion_lbl_BindingContextChanged);
            parcialFichas_txt.Leave += new EventHandler(parcialFichas_txt_Leave);
            totalFichas_txt.Leave += new EventHandler(totalFichas_txt_Leave);
            sector_txt.Leave += new EventHandler(sector_txt_Leave);
            manzana_txt.Leave += new EventHandler(manzana_txt_Leave);
            lote_txt.Leave += new EventHandler(lote_txt_Leave);
            nomenclatura_txt.Leave += new EventHandler(nomenclatura_txt_Leave);
            codigoHabilitacionUrbana_txt.Leave += new EventHandler(codigoHabilitacionUrbana_txt_Leave);
            areaTotalEspacioRecreacion_txt.Leave += new EventHandler(areaTotalEspacioRecreacion_txt_Leave);
            areaVerdeEspacioRecreacion_txt.Leave += new EventHandler(areaVerdeEspacioRecreacion_txt_Leave);
            estadoConservacionEspacioRecreacion_txt.Leave += new EventHandler(estadoConservacionEspacioRecreacion_txt_Leave);
            tipoEspacioRecreacion_txt.Leave += new EventHandler(tipoEspacioRecreacion_txt_Leave);
            estadoLlenadoFicha_txt.Leave += new EventHandler(estadoLlenadoFicha_txt_Leave);

            //Fotografia
            nuevoFotografia.Click += new EventHandler(nuevoFotografia_Click);
            eliminarFotografia.Click += new EventHandler(eliminarFotografia_Click);
            aceptarFotografia.Click += new EventHandler(aceptarFotografia_Click);
            cancelarFotografia.Click += new EventHandler(cancelarFotografia_Click);
            planoUbicacion_pb.Click += new EventHandler(planoUbicacion_pb_Click);
            añoPlanoUbicacion_txt.Leave += new EventHandler(añoPlanoUbicacion_txt_Leave);
            fotografiaDigital_pb.Click += new EventHandler(fotografiaDigital_pb_Click);
            añoFotografiaDigital_txt.Leave += new EventHandler(añoFotografiaDigital_txt_Leave);
            FOTOGRAFIA_dgv.DataError += new DataGridViewDataErrorEventHandler(FOTOGRAFIA_dgv_DataError);

            //Calzada          
            nuevoCalzadas.Click += new EventHandler(nuevoCalzadas_Click);
            eliminarCalzadas.Click += new EventHandler(eliminarCalzadas_Click);
            aceptarCalzadas.Click += new EventHandler(aceptarCalzadas_Click);
            cancelarCalzadas.Click += new EventHandler(cancelarCalzadas_Click);
            sectorCalzadas_txt.Leave += new EventHandler(sectorCalzadas_txt_Leave);
            codigoViaCalzadas_txt.Leave += new EventHandler(codigoViaCalzadas_txt_Leave);
            cuadraCalzadas_txt.Leave += new EventHandler(cuadraCalzadas_txt_Leave);
            largoCalzadas_txt.Leave += new EventHandler(largoCalzadas_txt_Leave);            
            anchoCalzadas_txt.Leave += new EventHandler(anchoCalzadas_txt_Leave);
            materialCalzadas_txt.Leave += new EventHandler(materialCalzadas_txt_Leave);
            estadoConservacionCalzadas_txt.Leave += new EventHandler(estadoConservacionCalzadas_txt_Leave);
            CALZADAS_dgv.DataError += new DataGridViewDataErrorEventHandler(CALZADAS_dgv_DataError);
 
            //Vereda
            nuevoVeredas.Click += new EventHandler(nuevoVeredas_Click);
            eliminarVeredas.Click += new EventHandler(eliminarVeredas_Click);
            aceptarVeredas.Click += new EventHandler(aceptarVeredas_Click);
            cancelarVeredas.Click += new EventHandler(cancelarVeredas_Click);
            descripcionVeredas_txt.Click += new EventHandler(descripcionVeredas_txt_Leave);
            areaVeredas_txt.Leave += new EventHandler(areaVeredas_txt_Leave);
            materialVeredas_txt.Leave += new EventHandler(materialVeredas_txt_Leave);
            estadoConservacionVeredas_txt.Leave += new EventHandler(estadoConservacionVeredas_txt_Leave);            
            VEREDAS_dgv.DataError += new DataGridViewDataErrorEventHandler(VEREDAS_dgv_DataError);

            //Componente Urbano
            nuevoComponenteUrbano.Click += new EventHandler(nuevoComponenteUrbano_Click);
            eliminarComponenteUrbano.Click += new EventHandler(eliminarComponenteUrbano_Click);
            aceptarComponenteUrbano.Click += new EventHandler(aceptarComponenteUrbano_Click);
            cancelarComponenteUrbano.Click += new EventHandler(cancelarComponenteUrbano_Click);            
            fotografiaDigitalComponenteUrbano_pb.Click += new EventHandler(fotografiaDigitalComponenteUrbano_pb_Click);
            añoComponenteUrbano_txt.Leave += new EventHandler(añoComponenteUrbano_txt_Leave);
            tipoComponenteUrbano_txt.Leave += new EventHandler(tipoComponenteUrbano_txt_Leave);
            cantidadComponenteUrbano_txt.Leave += new EventHandler(cantidadComponenteUrbano_txt_Leave);
            materialComponenteUrbano_txt.Leave += new EventHandler(materialComponenteUrbano_txt_Leave);
            estadoConservacionComponenteUrbano_txt.Leave += new EventHandler(estadoConservacionComponenteUrbano_txt_Leave);
            COMPONENTE_URBANO_dgv.DataError += new DataGridViewDataErrorEventHandler(COMPONENTE_URBANO_dgv_DataError);

            //Mobiliario Urbano
            nuevoMobiliarioUrbano.Click += new EventHandler(nuevoMobiliarioUrbano_Click);
            eliminarMobiliarioUrbano.Click += new EventHandler(eliminarMobiliarioUrbano_Click);
            aceptarMobiliarioUrbano.Click += new EventHandler(aceptarMobiliarioUrbano_Click);
            cancelarMobiliarioUrbano.Click += new EventHandler(cancelarMobiliarioUrbano_Click);            
            fotografiaDigitalMobiliarioUrbano_pb.Click += new EventHandler(fotografiaDigitalMobiliarioUrbano_pb_Click);
            añoMobiliarioUrbano_txt.Leave += new EventHandler(añoMobiliarioUrbano_txt_Leave);
            tipoMobiliarioUrbano_txt.Leave += new EventHandler(tipoMobiliarioUrbano_txt_Leave);
            cantidadMobiliarioUrbano_txt.Leave += new EventHandler(cantidadMobiliarioUrbano_txt_Leave);
            materialMobiliarioUrbano_txt.Leave += new EventHandler(materialMobiliarioUrbano_txt_Leave);
            estadoConservacionMobiliarioUrbano_txt.Leave += new EventHandler(estadoConservacionMobiliarioUrbano_txt_Leave);
            MOBILIARIO_URBANO_dgv.DataError += new DataGridViewDataErrorEventHandler(MOBILIARIO_URBANO_dgv_DataError);
        }

        #region Variables Globales
        ComponentResourceManager resources = new ComponentResourceManager(typeof(Ficha_Catastral_Espacio_Recreacion));
        //Ficha Catastral de Espacio de Recreación
        cHabilitacion_Urbana habilitacion_urbana = new cHabilitacion_Urbana();
        cEstado_Conservacion estado_conservacion = new cEstado_Conservacion();
        cTipo_Espacio_Recreacion tipo_espacio_recreacion = new cTipo_Espacio_Recreacion();
        cEstado_Llenado_Ficha estado_llenado_ficha = new cEstado_Llenado_Ficha();
        cPersonal supervisor = new cPersonal();
        cPersonal tecnico_catastral = new cPersonal();
        cPersonal digitacion = new cPersonal();
        //Calzadas - Veredas
        cVias vias = new cVias();
        cMaterial material = new cMaterial();
        //Componente Urbano - Mobiliario Urbano
        cTipo_Componente_Urbano tipo_componente_urbano = new cTipo_Componente_Urbano();
        cTipo_Mobiliario_Urbano tipo_mobiliario_urbano = new cTipo_Mobiliario_Urbano();
        cMaterial_Componente_Urbano_Mobiliario_Urbano material_componente_urbano_mobiliario_urbano = new cMaterial_Componente_Urbano_Mobiliario_Urbano();     
        #endregion

        #region Propiedades
        #region [ PROPIEDADES DE FICHA CATASTRAL DE ESPACIO DE RECREACION ]
        bool habilitar_controles_ficha
        {
            get { return parcialFichas_txt.Enabled; }
            set
            {
                IEnumerable<Control> controles1 = from Control x1 in tabPage1.Controls
                                                  where x1 is FormattedTextBox || x1 is TextBox || x1 is DateTimePicker || (x1 is Label && x1.BackColor == Color.White)
                                                  select x1;
                List<Control> coleccionControles = controles1.ToList();
                IEnumerable<Control> controles3 = from Control x3 in tabPage3.Controls
                                                  where x3 is FormattedTextBox || x3 is TextBox || x3 is DateTimePicker || (x3 is Label && x3.BackColor == Color.White)
                                                  select x3;
                coleccionControles.AddRange(controles3.ToList());
                IEnumerable<Control> controles4 = from Control x4 in tabPage4.Controls
                                                  where x4 is FormattedTextBox || x4 is TextBox || x4 is DateTimePicker || (x4 is Label && x4.BackColor == Color.White)
                                                  select x4;
                coleccionControles.AddRange(controles4.ToList());
                coleccionControles.ForEach(a => a.Enabled = value);

                //Ficha Catastral de Espacio de Recreación
                FICHA_dgv.Enabled = !value;
                categoria_tsc.Enabled = !value;
                buscar_tst.Enabled = !value;               
                //Calzadas             
                iniciar_calzadas = false;
                habilitar_movimiento_calzadas = !value;
                habilitar_controles_calzadas = false;
                //Veredas              
                iniciar_veredas = false;
                habilitar_movimiento_veredas = !value;
                habilitar_controles_veredas = false;
                //Fotografia
                iniciar_fotografia = false;
                habilitar_movimiento_fotografia = !value;
                habilitar_controles_fotografia = false;
                //Componente Urbano
                iniciar_componente_urbano = false;
                habilitar_movimiento_componente_urbano = !value;
                habilitar_controles_componente_urbano = false;
                //Mobiliario Urbano
                iniciar_mobiliario_urbano = false;
                habilitar_movimiento_mobiliario_urbano = !value;
                habilitar_controles_mobiliario_urbano = false;
            }
        }
        bool validar
        {
            get
            {
                IEnumerable<int> labelCantidad1 = from Control x in tabPage1.Controls
                                                  where x is Label && x.BackColor == Color.Red
                                                  select x.Controls.Count;
                IEnumerable<int> labelCantidad3 = from Control x in tabPage3.Controls
                                                  where x is Label && x.BackColor == Color.Red
                                                  select x.Controls.Count;
                IEnumerable<int> labelCantidad4 = from Control x in tabPage4.Controls
                                                  where x is Label && x.BackColor == Color.Red
                                                  select x.Controls.Count;
                int total = labelCantidad1.Count() + labelCantidad3.Count() + labelCantidad4.Count();
                return total == 0 && sector_txt.Text.Length == 2 && manzana_txt.Text.Length == 3 &&
                ((aceptarFotografia.ForeColor != Color.Red) ? true : false) && ((aceptarCalzadas.ForeColor != Color.Red) ? true : false) && ((aceptarVeredas.ForeColor != Color.Red) ? true : false) && ((aceptarComponenteUrbano.ForeColor != Color.Red) ? true : false) && ((aceptarMobiliarioUrbano.ForeColor != Color.Red) ? true : false);
            }
        }
        #endregion

        #region [ PROPIEDADES DE FICHA CATASTRAL DE ESPACIO DE RECREACION - CALZADAS ]
        bool habilitar_movimiento_calzadas
        {
            set
            {
                inicioCalzadas.Enabled = (posicionCalzadas.Text == "0" || posicionCalzadas.Text == "1") ? false : value;
                anteriorCalzadas.Enabled = (posicionCalzadas.Text == "0" || posicionCalzadas.Text == "1") ? false : value;
                posicionCalzadas.Enabled = (CALZADAS_dgv.RowCount == 0) ? false : value;
                siguienteCalzadas.Enabled = (posicionCalzadas.Text == contadorCalzadas.Text.Substring(3)) ? false : value;
                finCalzadas.Enabled = (posicionCalzadas.Text == contadorCalzadas.Text.Substring(3)) ? false : value;
                nuevoCalzadas.Enabled = !value;
                aceptarCalzadas.Enabled = !value;
                eliminarCalzadas.Enabled = !value;
                cancelarCalzadas.Enabled = !value;
            }
        }
        bool habilitar_controles_calzadas
        {
            get { return codigoViaCalzadas_txt.Enabled; }
            set
            {
                sectorCalzadas_txt.Enabled = value;
                codigoViaCalzadas_txt.Enabled = value;
                nombreViasCalzadas_lbl.Enabled = value;
                cuadraCalzadas_txt.Enabled = value;
                largoCalzadas_txt.Enabled = value;
                anchoCalzadas_txt.Enabled = value;
                materialCalzadas_txt.Enabled = value;
                estadoConservacionCalzadas_txt.Enabled = value;
                especificacionesCalzadas_txt.Enabled = value;
                CALZADAS_dgv.Enabled = !value;
            }
        }
        bool iniciar_calzadas
        {
            set
            {
                calzadas_tc.SelectedTab = tabPage14;
                nuevoCalzadas.Enabled = value;
                aceptarCalzadas.ForeColor = Color.Black;
                aceptarCalzadas.Enabled = false;
                eliminarCalzadas.Enabled = false;
                cancelarCalzadas.Enabled = false;
                if (CALZADAS_dgv.RowCount > 0)
                {
                    aceptarCalzadas.Enabled = value;
                    aceptarCalzadas.Text = "Modificar Calzada";
                    aceptarCalzadas.Image = null;
                    eliminarCalzadas.Enabled = value;
                }
            }
        }
        #endregion

        #region [ PROPIEDADES DE FICHA CATASTRAL DE ESPACIO DE RECREACION - VEREDAS ]
        bool habilitar_movimiento_veredas
        {
            set
            {
                inicioVeredas.Enabled = (posicionVeredas.Text == "0" || posicionVeredas.Text == "1") ? false : value;
                anteriorVeredas.Enabled = (posicionVeredas.Text == "0" || posicionVeredas.Text == "1") ? false : value;
                posicionVeredas.Enabled = (VEREDAS_dgv.RowCount == 0) ? false : value;
                siguienteVeredas.Enabled = (posicionVeredas.Text == contadorVeredas.Text.Substring(3)) ? false : value;
                finVeredas.Enabled = (posicionVeredas.Text == contadorVeredas.Text.Substring(3)) ? false : value;
                nuevoVeredas.Enabled = !value;
                aceptarVeredas.Enabled = !value;
                eliminarVeredas.Enabled = !value;
                cancelarVeredas.Enabled = !value;
            }
        }
        bool habilitar_controles_veredas
        {
            get { return descripcionVeredas_txt.Enabled; }
            set
            {
                descripcionVeredas_txt.Enabled = value;
                areaVeredas_txt.Enabled = value;
                materialVeredas_txt.Enabled = value;
                estadoConservacionVeredas_txt.Enabled = value;
                especificacionesVeredas_txt.Enabled = value;
                VEREDAS_dgv.Enabled = !value;
            }
        }
        bool iniciar_veredas
        {
            set
            {
                veredas_tc.SelectedTab = tabPage16;
                nuevoVeredas.Enabled = value;
                aceptarVeredas.ForeColor = Color.Black;
                aceptarVeredas.Enabled = false;
                eliminarVeredas.Enabled = false;
                cancelarVeredas.Enabled = false;
                if (VEREDAS_dgv.RowCount > 0)
                {
                    aceptarVeredas.Enabled = value;
                    aceptarVeredas.Text = "Modificar Vereda";
                    aceptarVeredas.Image = null;
                    eliminarVeredas.Enabled = value;
                }
            }
        }
        #endregion

        #region [ PROPIEDADES DE FICHA CATASTRAL DE ESPACIO DE RECREACION - FOTOGRAFIA  ]
        bool habilitar_movimiento_fotografia
        {
            set
            {
                inicioFotografia.Enabled = (posicionFotografia.Text == "0" || posicionFotografia.Text == "1") ? false : value;
                anteriorFotografia.Enabled = (posicionFotografia.Text == "0" || posicionFotografia.Text == "1") ? false : value;
                posicionFotografia.Enabled = (FOTOGRAFIA_dgv.RowCount == 0) ? false : value;
                siguienteFotografia.Enabled = (posicionFotografia.Text == contadorFotografia.Text.Substring(3)) ? false : value;
                finFotografia.Enabled = (posicionFotografia.Text == contadorFotografia.Text.Substring(3)) ? false : value;
                nuevoFotografia.Enabled = !value;
                aceptarFotografia.Enabled = !value;
                eliminarFotografia.Enabled = !value;
                cancelarFotografia.Enabled = !value;
            }
        }
        bool habilitar_controles_fotografia
        {
            get { return añoPlanoUbicacion_txt.Enabled; }
            set
            {
                planoUbicacion_pb.Enabled = value;
                sectorPlanoUbicacion_lbl.Enabled = value;
                manzanaPlanoUbicacion_lbl.Enabled = value;
                lotePlanoUbicacion_lbl.Enabled = value;                
                añoPlanoUbicacion_txt.Enabled = value;
                fotografiaDigital_pb.Enabled = value;
                sectorFotografiaDigital_lbl.Enabled = value;
                manzanaFotografiaDigital_lbl.Enabled = value;
                loteFotografiaDigital_lbl.Enabled = value;                
                añoFotografiaDigital_txt.Enabled = value;
                FOTOGRAFIA_dgv.Enabled = !value;
            }
        }
        bool iniciar_fotografia
        {
            set
            {
                fotografia_tc.SelectedTab = tabPage8;
                nuevoFotografia.Enabled = value;
                aceptarFotografia.ForeColor = Color.Black;
                aceptarFotografia.Enabled = false;
                eliminarFotografia.Enabled = false;
                cancelarFotografia.Enabled = false;
                if (FOTOGRAFIA_dgv.RowCount > 0)
                {
                    aceptarFotografia.Enabled = value;
                    aceptarFotografia.Text = "Modificar Fotografía";
                    aceptarFotografia.Image = null;
                    eliminarFotografia.Enabled = value;
                }
            }
        }
        #endregion

        #region [ PROPIEDADES DE FICHA CATASTRAL DE ESPACIO DE RECREACION - COMPONENTE URBANO ]
        bool habilitar_movimiento_componente_urbano
        {
            set
            {
                inicioComponenteUrbano.Enabled = (posicionComponenteUrbano.Text == "0" || posicionComponenteUrbano.Text == "1") ? false : value;
                anteriorComponenteUrbano.Enabled = (posicionComponenteUrbano.Text == "0" || posicionComponenteUrbano.Text == "1") ? false : value;
                posicionComponenteUrbano.Enabled = (COMPONENTE_URBANO_dgv.RowCount == 0) ? false : value;
                siguienteComponenteUrbano.Enabled = (posicionComponenteUrbano.Text == contadorComponenteUrbano.Text.Substring(3)) ? false : value;
                finComponenteUrbano.Enabled = (posicionComponenteUrbano.Text == contadorComponenteUrbano.Text.Substring(3)) ? false : value;
                nuevoComponenteUrbano.Enabled = !value;
                aceptarComponenteUrbano.Enabled = !value;
                eliminarComponenteUrbano.Enabled = !value;
                cancelarComponenteUrbano.Enabled = !value;
            }
        }
        bool habilitar_controles_componente_urbano
        {
            get { return añoComponenteUrbano_txt.Enabled; }
            set
            {
                fotografiaDigitalComponenteUrbano_pb.Enabled = value;
                sectorComponenteUrbano_lbl.Enabled = value;
                manzanaComponenteUrbano_lbl.Enabled = value;
                loteComponenteUrbano_lbl.Enabled = value;
                añoComponenteUrbano_txt.Enabled = value;
                tipoComponenteUrbano_txt.Enabled = value;
                cantidadComponenteUrbano_txt.Enabled = value;
                materialComponenteUrbano_txt.Enabled = value;
                estadoConservacionComponenteUrbano_txt.Enabled = value;
                especificacionesComponenteUrbano_txt.Enabled = value;
                COMPONENTE_URBANO_dgv.Enabled = !value;
            }
        }
        bool iniciar_componente_urbano
        {
            set
            {
                componente_urbano_tc.SelectedTab = tabPage10;
                nuevoComponenteUrbano.Enabled = value;
                aceptarComponenteUrbano.ForeColor = Color.Black;
                aceptarComponenteUrbano.Enabled = false;
                eliminarComponenteUrbano.Enabled = false;
                cancelarComponenteUrbano.Enabled = false;
                if (COMPONENTE_URBANO_dgv.RowCount > 0)
                {
                    aceptarComponenteUrbano.Enabled = value;
                    aceptarComponenteUrbano.Text = "Modificar Componente Urbano";
                    aceptarComponenteUrbano.Image = null;
                    eliminarComponenteUrbano.Enabled = value;
                }
            }
        }
        
        #endregion

        #region [ PROPIEDADES DE FICHA CATASTRAL DE ESPACIO DE RECREACION - MOBILIARIO URBANO ]
        bool habilitar_movimiento_mobiliario_urbano
        {
            set
            {
                inicioMobiliarioUrbano.Enabled = (posicionMobiliarioUrbano.Text == "0" || posicionMobiliarioUrbano.Text == "1") ? false : value;
                anteriorMobiliarioUrbano.Enabled = (posicionMobiliarioUrbano.Text == "0" || posicionMobiliarioUrbano.Text == "1") ? false : value;
                posicionMobiliarioUrbano.Enabled = (MOBILIARIO_URBANO_dgv.RowCount == 0) ? false : value;
                siguienteMobiliarioUrbano.Enabled = (posicionMobiliarioUrbano.Text == contadorMobiliarioUrbano.Text.Substring(3)) ? false : value;
                finMobiliarioUrbano.Enabled = (posicionMobiliarioUrbano.Text == contadorMobiliarioUrbano.Text.Substring(3)) ? false : value;
                nuevoMobiliarioUrbano.Enabled = !value;
                aceptarMobiliarioUrbano.Enabled = !value;
                eliminarMobiliarioUrbano.Enabled = !value;
                cancelarMobiliarioUrbano.Enabled = !value;
            }
        }
        bool habilitar_controles_mobiliario_urbano
        {
            get { return añoMobiliarioUrbano_txt.Enabled; }
            set
            {
                fotografiaDigitalMobiliarioUrbano_pb.Enabled = value;
                sectorMobiliarioUrbano_lbl.Enabled = value;
                manzanaMobiliarioUrbano_lbl.Enabled = value;
                loteMobiliarioUrbano_lbl.Enabled = value;
                añoMobiliarioUrbano_txt.Enabled = value;
                tipoMobiliarioUrbano_txt.Enabled = value;
                cantidadMobiliarioUrbano_txt.Enabled = value;
                materialMobiliarioUrbano_txt.Enabled = value;
                estadoConservacionMobiliarioUrbano_txt.Enabled = value;
                especificacionesMobiliarioUrbano_txt.Enabled = value;
                MOBILIARIO_URBANO_dgv.Enabled = !value;
            }
        }
        bool iniciar_mobiliario_urbano
        {
            set
            {
                mobiliario_urbano_tc.SelectedTab = tabPage12;
                nuevoMobiliarioUrbano.Enabled = value;
                aceptarMobiliarioUrbano.ForeColor = Color.Black;
                aceptarMobiliarioUrbano.Enabled = false;
                eliminarMobiliarioUrbano.Enabled = false;
                cancelarMobiliarioUrbano.Enabled = false;
                if (MOBILIARIO_URBANO_dgv.RowCount > 0)
                {
                    aceptarMobiliarioUrbano.Enabled = value;
                    aceptarMobiliarioUrbano.Text = "Modificar Mobiliario Urbano";
                    aceptarMobiliarioUrbano.Image = null;
                    eliminarMobiliarioUrbano.Enabled = value;
                }
            }
        }
        #endregion
        #endregion

        #region Metodos
        #region [ METODOS DE FICHA CATASTRAL DE ESPACIO DE RECREACION ]
        void iniciar()
        {
            listar();
            aceptar_tsb.Text = "&Modificar";
            aceptar_tsb.Image = null;
            nuevo_tsb.Enabled = true;
            eliminar_tsb.Enabled = true;
            buscar_tst.Text = "";
            FICHA_bs.Filter = "";
            habilitar_controles_ficha = false;
            secundario_tc.SelectedTab = tabPage1;
        }
        void listar()
        {
                cFicha_Catastral_Espacio_Recreacion ficha_catastral_espacio_recreacion = new cFicha_Catastral_Espacio_Recreacion();
                FICHA_ds = ficha_catastral_espacio_recreacion.listar();
                base.refrescar();

                this.FICHA_bs.DataMember = "VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACION";
                this.FICHA_bs.DataSource = FICHA_ds;

                this.FOTOGRAFIA_bn.BindingSource = FOTOGRAFIA_bs;
                this.FOTOGRAFIA_dgv.DataSource = FOTOGRAFIA_bs;
                this.FOTOGRAFIA_bs.DataMember = "ESPACIO_RECREACION_FK_FOTOGRAFIA";
                this.FOTOGRAFIA_bs.DataSource = FICHA_bs;

                this.CALZADAS_bn.BindingSource = CALZADAS_bs;
                this.CALZADAS_dgv.DataSource = CALZADAS_bs;
                this.CALZADAS_bs.DataMember = "ESPACIO_RECREACION_FK_CALZADAS";
                this.CALZADAS_bs.DataSource = FICHA_bs;

                this.VEREDAS_bn.BindingSource = VEREDAS_bs;
                this.VEREDAS_dgv.DataSource = VEREDAS_bs;
                this.VEREDAS_bs.DataMember = "ESPACIO_RECREACION_FK_VEREDAS";
                this.VEREDAS_bs.DataSource = FICHA_bs;                

                this.COMPONENTE_URBANO_bn.BindingSource = COMPONENTE_URBANO_bs;
                this.COMPONENTE_URBANO_dgv.DataSource = COMPONENTE_URBANO_bs;
                this.COMPONENTE_URBANO_bs.DataMember = "ESPACIO_RECREACION_FK_COMPONENTE_URBANO";
                this.COMPONENTE_URBANO_bs.DataSource = FICHA_bs;

                this.MOBILIARIO_URBANO_bn.BindingSource = MOBILIARIO_URBANO_bs;
                this.MOBILIARIO_URBANO_dgv.DataSource = MOBILIARIO_URBANO_bs;
                this.MOBILIARIO_URBANO_bs.DataMember = "ESPACIO_RECREACION_FK_MOBILIARIO_URBANO";
                this.MOBILIARIO_URBANO_bs.DataSource = FICHA_bs;                        
        }
        void guardar()
        {
            if (validar)
            {
                cFicha_Catastral_Espacio_Recreacion ficha_catastral_espacio_recreacion = new cFicha_Catastral_Espacio_Recreacion();
                ficha_catastral_espacio_recreacion.Ficha = ficha_lbl.Text.Trim();
                ficha_catastral_espacio_recreacion.Parcial_Ficha = parcialFichas_txt.Text;
                ficha_catastral_espacio_recreacion.Total_Fichas = totalFichas_txt.Text;
                ficha_catastral_espacio_recreacion.Departamento = departamento_lbl.Text;
                ficha_catastral_espacio_recreacion.Provincia = provincia_lbl.Text;
                ficha_catastral_espacio_recreacion.Distrito = distrito_lbl.Text;
                ficha_catastral_espacio_recreacion.Sector = sector_txt.Text;
                ficha_catastral_espacio_recreacion.Manzana = manzana_txt.Text;
                ficha_catastral_espacio_recreacion.Lote = lote_txt.Text;
                ficha_catastral_espacio_recreacion.Nomenclatura = nomenclatura_txt.Text;
                ficha_catastral_espacio_recreacion.Toponimo = toponimo_txt.Text;
                //Habilitación Urbana
                habilitacion_urbana.Codigo = (codigoHabilitacionUrbana_txt.Text.Length > 0) ? codigoHabilitacionUrbana_txt.Text : null;
                ficha_catastral_espacio_recreacion.Habilitacion_Urbana = habilitacion_urbana;
                //
                ficha_catastral_espacio_recreacion.Zona_Sector_Etapa = zonaSectorEtapa_txt.Text;
                //
                ficha_catastral_espacio_recreacion.Punto_X = puntoX_txt.Text;
                ficha_catastral_espacio_recreacion.Punto_Y = puntoY_txt.Text;
                ficha_catastral_espacio_recreacion.Punto_Z = puntoZ_txt.Text;                
                //
                ficha_catastral_espacio_recreacion.Area_Total = areaTotalEspacioRecreacion_txt.Text;
                ficha_catastral_espacio_recreacion.Area_Verde = areaVerdeEspacioRecreacion_txt.Text;
                //
                estado_conservacion.Codigo =( estadoConservacionEspacioRecreacion_txt.Text.Length > 0) ? estadoConservacionEspacioRecreacion_txt.Text : null;
                ficha_catastral_espacio_recreacion.Estado_Conservacion = estado_conservacion;
                //
                tipo_espacio_recreacion.Codigo =( tipoEspacioRecreacion_txt.Text.Length >0) ? tipoEspacioRecreacion_txt.Text : null;
                ficha_catastral_espacio_recreacion.Tipo_Espacio_Recreacion = tipo_espacio_recreacion;
                //
                ficha_catastral_espacio_recreacion.Especificaciones = especificacionesEspacioRecreacion_txt.Text;
                //
                ficha_catastral_espacio_recreacion.Observaciones = observaciones_txt.Text;
                //Estado de Llenado de la Ficha
                estado_llenado_ficha.Codigo = (estadoLlenadoFicha_txt.Text.Length > 0) ? estadoLlenadoFicha_txt.Text : null;
                ficha_catastral_espacio_recreacion.Estado_Llenado_Ficha = estado_llenado_ficha;
                //
                supervisor.DNI = cPersonal.DNI_Supervisor;
                ficha_catastral_espacio_recreacion.Supervisor = supervisor;
                ficha_catastral_espacio_recreacion.Fecha_Supervisor = fechaSupervisor_txt.Value;
                tecnico_catastral.DNI = cPersonal.DNI_Tecnico_Catastral;
                ficha_catastral_espacio_recreacion.Tecnico_Catastral = tecnico_catastral;
                ficha_catastral_espacio_recreacion.Fecha_Tecnico_Catastral = fechaTecnicoCatastral_txt.Value;
                digitacion.DNI = cPersonal.DNI_Digitacion;
                ficha_catastral_espacio_recreacion.Digitacion = digitacion;
                ficha_catastral_espacio_recreacion.Fecha_Digitacion = fechaDigitacion_txt.Value;                
                ficha_catastral_espacio_recreacion.Usuario = Usuario;
                i = ficha_catastral_espacio_recreacion.guardar();                
                if (i > 0)
                {
                    if (FICHA_dgv.RowCount > 0)
                    {
                        (new cFicha_Catastral_Espacio_Recreacion_Calzadas()).actualizar(FICHA_ds);
                        (new cFicha_Catastral_Espacio_Recreacion_Veredas()).actualizar(FICHA_ds);
                        (new cFicha_Catastral_Espacio_Recreacion_Fotografia()).actualizar(FICHA_ds);
                        (new cFicha_Catastral_Espacio_Recreacion_Componente_Urbano()).actualizar(FICHA_ds);
                        (new cFicha_Catastral_Espacio_Recreacion_Mobiliario_Urbano()).actualizar(FICHA_ds);
                        MessageBox.Show("Se a Insertando Correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    }
                }
                else MessageBox.Show("Error Guardar, Ficha Catastral de Espacio de Recreación.", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                iniciar();
            }
        }
        void modificar()
        {

            if (validar)
            {
                cFicha_Catastral_Espacio_Recreacion ficha_catastral_espacio_recreacion = new cFicha_Catastral_Espacio_Recreacion();
                ficha_catastral_espacio_recreacion.Ficha = ficha_lbl.Text.Trim();
                ficha_catastral_espacio_recreacion.Parcial_Ficha = parcialFichas_txt.Text;
                ficha_catastral_espacio_recreacion.Total_Fichas = totalFichas_txt.Text;
                ficha_catastral_espacio_recreacion.Departamento = departamento_lbl.Text;
                ficha_catastral_espacio_recreacion.Provincia = provincia_lbl.Text;
                ficha_catastral_espacio_recreacion.Distrito = distrito_lbl.Text;
                ficha_catastral_espacio_recreacion.Sector = sector_txt.Text;
                ficha_catastral_espacio_recreacion.Manzana = manzana_txt.Text;
                ficha_catastral_espacio_recreacion.Lote = lote_txt.Text;
                ficha_catastral_espacio_recreacion.Nomenclatura = nomenclatura_txt.Text;
                ficha_catastral_espacio_recreacion.Toponimo = toponimo_txt.Text;
                //Habilitación Urbana
                habilitacion_urbana.Codigo = (codigoHabilitacionUrbana_txt.Text.Length > 0) ? codigoHabilitacionUrbana_txt.Text : null;
                ficha_catastral_espacio_recreacion.Habilitacion_Urbana = habilitacion_urbana;
                //
                ficha_catastral_espacio_recreacion.Zona_Sector_Etapa = zonaSectorEtapa_txt.Text;
                //
                ficha_catastral_espacio_recreacion.Punto_X = puntoX_txt.Text;
                ficha_catastral_espacio_recreacion.Punto_Y = puntoY_txt.Text;
                ficha_catastral_espacio_recreacion.Punto_Z = puntoZ_txt.Text;
                //
                ficha_catastral_espacio_recreacion.Area_Total = areaTotalEspacioRecreacion_txt.Text;
                ficha_catastral_espacio_recreacion.Area_Verde = areaVerdeEspacioRecreacion_txt.Text;
                //
                estado_conservacion.Codigo = estadoConservacionEspacioRecreacion_txt.Text;
                ficha_catastral_espacio_recreacion.Estado_Conservacion = estado_conservacion;
                //
                tipo_espacio_recreacion.Codigo = tipoEspacioRecreacion_txt.Text;
                ficha_catastral_espacio_recreacion.Tipo_Espacio_Recreacion = tipo_espacio_recreacion;
                //
                ficha_catastral_espacio_recreacion.Especificaciones = especificacionesEspacioRecreacion_txt.Text;
                //
                ficha_catastral_espacio_recreacion.Observaciones = observaciones_txt.Text;
                //Estado de Llenado de la Ficha
                estado_llenado_ficha.Codigo = (estadoLlenadoFicha_txt.Text.Length > 0) ? estadoLlenadoFicha_txt.Text : null;
                ficha_catastral_espacio_recreacion.Estado_Llenado_Ficha = estado_llenado_ficha;
                //
                supervisor.DNI = cPersonal.DNI_Supervisor;
                ficha_catastral_espacio_recreacion.Supervisor = supervisor;
                ficha_catastral_espacio_recreacion.Fecha_Supervisor = fechaSupervisor_txt.Value;
                tecnico_catastral.DNI = cPersonal.DNI_Tecnico_Catastral;
                ficha_catastral_espacio_recreacion.Tecnico_Catastral = tecnico_catastral;
                ficha_catastral_espacio_recreacion.Fecha_Tecnico_Catastral = fechaTecnicoCatastral_txt.Value;
                digitacion.DNI = cPersonal.DNI_Digitacion;
                ficha_catastral_espacio_recreacion.Digitacion = digitacion;
                ficha_catastral_espacio_recreacion.Fecha_Digitacion = fechaDigitacion_txt.Value;
                ficha_catastral_espacio_recreacion.Hash = "";
                ficha_catastral_espacio_recreacion.Usuario = Usuario;

                i = ficha_catastral_espacio_recreacion.modificar();
                if (i > 0)
                {
                    if (FICHA_dgv.RowCount > 0)
                    {
                        (new cFicha_Catastral_Espacio_Recreacion_Calzadas()).actualizar(FICHA_ds);
                        (new cFicha_Catastral_Espacio_Recreacion_Veredas()).actualizar(FICHA_ds);
                        (new cFicha_Catastral_Espacio_Recreacion_Fotografia()).actualizar(FICHA_ds);
                        (new cFicha_Catastral_Espacio_Recreacion_Componente_Urbano()).actualizar(FICHA_ds);
                        (new cFicha_Catastral_Espacio_Recreacion_Mobiliario_Urbano()).actualizar(FICHA_ds);
                        MessageBox.Show("Se a Modificado Correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    }
                }
                else MessageBox.Show("Error Modificar, Ficha Catastral de Espacio de Recreación.", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                iniciar();
            }
        }
        void eliminar()
        {
            cFicha_Catastral_Espacio_Recreacion ficha_catastral_espacio_recreacion = new cFicha_Catastral_Espacio_Recreacion();
            ficha_catastral_espacio_recreacion.Ficha = ficha_lbl.Text.Trim();
            ficha_catastral_espacio_recreacion.Usuario = Usuario;
            i = ficha_catastral_espacio_recreacion.eliminar();            
            if (i >= 2)
            {
                if (FICHA_dgv.RowCount > 0) MessageBox.Show("Se a Eliminado Correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);                                    
            }
            else MessageBox.Show("Error Eliminar, Ficha Catastral de Espacio de Recreación.", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            iniciar();
        }
        internal void listar_habilitacion_urbana()
        {
            codigoHabilitacionUrbana_txt.AutoCompleteCustomSource.AddRange(habilitacion_urbana.listar_arreglo());
        }
        internal void listar_estado_conservacion()
        {
            estadoConservacionEspacioRecreacion_txt.AutoCompleteCustomSource.AddRange(estado_conservacion.listar_arreglo());
        }
        internal void listar_tipo_espacio_recreacion()
        {
            tipoEspacioRecreacion_txt.AutoCompleteCustomSource.AddRange(tipo_espacio_recreacion.listar_arreglo());
        }
        internal void listar_estado_llenado_ficha()
        {
            estadoLlenadoFicha_txt.AutoCompleteCustomSource.AddRange(estado_llenado_ficha.listar_arreglo());
        }
        bool buscar_estado_conservacion_espacio_recreacion()
        {
            return estado_conservacion.buscar(estadoConservacionEspacioRecreacion_txt.Text);
        }
        bool buscar_tipo_espacio_recreacion()
        {
            return tipo_espacio_recreacion.buscar(tipoEspacioRecreacion_txt.Text);
        }
        bool buscar_estado_llenado_ficha()
        {
            return (estado_llenado_ficha.buscar(estadoLlenadoFicha_txt.Text));
        }
        #endregion

        #region [ METODOS DE FICHA CATASTRAL DE EQUIPAMIENTO URBANO - CALZADAS ]
        internal void listar_vias_calzadas()
        {
            codigoViaCalzadas_txt.AutoCompleteCustomSource.AddRange(vias.listar_arreglo());
        }
        internal void listar_material_calzadas()
        {
            materialCalzadas_txt.AutoCompleteCustomSource.AddRange(material.listar_arreglo());
        }
        internal void listar_estado_conservacion_calzadas()
        {
            estadoConservacionCalzadas_txt.AutoCompleteCustomSource.AddRange(estado_conservacion.listar_arreglo());
        }
        bool buscar_vias_calzadas()
        {
            return vias.buscar(codigoViaCalzadas_txt.Text.Trim());
        }
        bool buscar_material_calzadas()
        {
            return material.buscar(materialCalzadas_txt.Text.Trim());
        }
        bool buscar_estado_conservacion_calzadas()
        {
            return estado_conservacion.buscar(estadoConservacionCalzadas_txt.Text.Trim());
        }
        #endregion

        #region [ METODOS DE FICHA CATASTRAL DE EQUIPAMIENTO URBANO - VEREDAS ]
        internal void listar_material_veredas()
        {
            materialVeredas_txt.AutoCompleteCustomSource.AddRange(material.listar_arreglo());
        }
        internal void listar_estado_conservacion_veredas()
        {
            estadoConservacionVeredas_txt.AutoCompleteCustomSource.AddRange(estado_conservacion.listar_arreglo());
        }
        bool buscar_material_veredas()
        {
            return material.buscar(materialVeredas_txt.Text.Trim());
        }
        bool buscar_estado_conservacion_veredas()
        {
            return estado_conservacion.buscar(estadoConservacionVeredas_txt.Text.Trim());
        }
        #endregion

        #region [ METODOS DE FICHA CATASTRAL DE EQUIPAMIENTO URBANO - COMPONENTE URBANO ]
        internal void listar_tipo_componente_urbano()
        {
            tipoComponenteUrbano_txt.AutoCompleteCustomSource.AddRange(tipo_componente_urbano.listar_arreglo());
        }
        internal void listar_material_componente_urbano()
        {
            materialComponenteUrbano_txt.AutoCompleteCustomSource.AddRange(material_componente_urbano_mobiliario_urbano.listar_arreglo());
        }
        internal void listar_estado_conservacion_componente_urbano()
        {
            estadoConservacionComponenteUrbano_txt.AutoCompleteCustomSource.AddRange(estado_conservacion.listar_arreglo());
        }
        bool buscar_tipo_componente_urbano()
        {
            return tipo_componente_urbano.buscar(tipoComponenteUrbano_txt.Text);
        }
        bool buscar_material_componente_urbano()
        {
            return material_componente_urbano_mobiliario_urbano.buscar(materialComponenteUrbano_txt.Text);
        }
        bool buscar_estado_conservacion_componente_urbano()
        {
            return estado_conservacion.buscar(estadoConservacionComponenteUrbano_txt.Text);
        }
        #endregion

        #region [ METODOS DE FICHA CATASTRAL DE EQUIPAMIENTO URBANO - MOBILIARIO URBANO ]
        internal void listar_tipo_mobiliario_urbano()
        {
            tipoMobiliarioUrbano_txt.AutoCompleteCustomSource.AddRange(tipo_mobiliario_urbano.listar_arreglo());
        }
        internal void listar_material_mobiliario_urbano()
        {
            materialMobiliarioUrbano_txt.AutoCompleteCustomSource.AddRange(material_componente_urbano_mobiliario_urbano.listar_arreglo());
        }
        internal void listar_estado_conservacion_mobiliario_urbano()
        {
            estadoConservacionMobiliarioUrbano_txt.AutoCompleteCustomSource.AddRange(estado_conservacion.listar_arreglo());
        }
        bool buscar_tipo_mobiliario_urbano()
        {
            return tipo_mobiliario_urbano.buscar(tipoMobiliarioUrbano_txt.Text);
        }
        bool buscar_material_mobiliario_urbano()
        {
            return material_componente_urbano_mobiliario_urbano.buscar(materialMobiliarioUrbano_txt.Text);
        }
        bool buscar_estado_conservacion_mobiliario_urbano()
        {
            return estado_conservacion.buscar(estadoConservacionMobiliarioUrbano_txt.Text);
        }
        #endregion
        #endregion        

        #region Eventos
        #region [ EVENTOS DE FICHA CATASTRAL DE ESPACIO DE RECREACION ]
        private void listar_Load(object sender, EventArgs e)
        {
            try
            {
                //Ficha Catastral de Espacio de Recreación
                listar();
                habilitar_controles_ficha = false;

                listar_habilitacion_urbana();
                listar_estado_conservacion();
                listar_tipo_espacio_recreacion();
                listar_estado_llenado_ficha();

                //Calzadas
                listar_vias_calzadas();
                listar_material_calzadas();
                listar_estado_conservacion_calzadas();

                //Veredas
                listar_material_veredas();
                listar_estado_conservacion_veredas();

                //Componente Urbano 
                listar_tipo_componente_urbano();
                listar_material_componente_urbano();
                listar_estado_conservacion_componente_urbano();
                //Mobiliario Urbano
                listar_tipo_mobiliario_urbano();
                listar_material_mobiliario_urbano();
                listar_estado_conservacion_mobiliario_urbano();

                #region Bindings - Ficha Catastral de Equipamiento Urbano
                FICHA_dgv.Columns["ECS"].Visible = false;
                FICHA_dgv.Columns["TER"].Visible = false;
                FICHA_dgv.Columns["ELLF"].Visible = false;
                FICHA_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                ficha_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "FICHA", true));
                numero_ficha_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "NUMERO DE FICHA", true));
                numeroFicha_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "NUMERO DE FICHA", true));
                parcialFichas_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "PARCIAL DE FICHAS", true));
                totalFichas_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "TOTAL DE FICHAS", true));
                departamento_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "DPTO", true));
                provincia_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "PROV", true));
                distrito_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "DIST", true));
                sector_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "SECTOR", true));
                manzana_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "MANZANA", true));
                lote_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "LOTE", true));
                nomenclatura_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "NOMENCLATURA", true));
                toponimo_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "TOPONIMO", true));
                codigoHabilitacionUrbana_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CODIGO HABILITACION URBANA", true));
                nombreHabitacionUrbana_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "NOMBRE DE LA HABILITACION URBANA", true));
                zonaSectorEtapa_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "ZONA / SECTOR / ETAPA", true));
                puntoX_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "PUNTO X", true));
                puntoY_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "PUNTO Y", true));
                puntoZ_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "PUNTO Z", true));
                areaTotalEspacioRecreacion_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "AREA TOTAL", true));
                areaVerdeEspacioRecreacion_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "AREA VERDE", true));
                estadoConservacionEspacioRecreacion_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "ECS", true));
                tipoEspacioRecreacion_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "TER", true));
                especificacionesEspacioRecreacion_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "ESPECIFICACIONES", true));
                observaciones_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "OBSERVACIONES", true));
                estadoLlenadoFicha_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "ELLF", true));
                supervisor_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "LISTA SUPERVISOR", true));
                supervisor_lbl.DataBindings.Add(new Binding("Tag", FICHA_bs, "DNI SUPERVISOR", true));
                fechaSupervisor_txt.DataBindings.Add(new Binding("Value", FICHA_bs, "FECHA SUPERVISOR", true));
                tecnicoCatastral_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "LISTA TECNICO CATASTRAL", true));
                tecnicoCatastral_lbl.DataBindings.Add(new Binding("Tag", FICHA_bs, "DNI TECNICO CATASTRAL", true));
                fechaTecnicoCatastral_txt.DataBindings.Add(new Binding("Value", FICHA_bs, "FECHA TECNICO CATASTRAL", true));
                digitalizacion_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "LISTA VB DIGITACION", true));
                digitalizacion_lbl.DataBindings.Add(new Binding("Tag", FICHA_bs, "DNI VB DIGITACION", true));
                fechaDigitacion_txt.DataBindings.Add(new Binding("Value", FICHA_bs, "FECHA VB DIGITACION", true));
                #endregion

                #region Bindings - Fotografía
                FOTOGRAFIA_dgv.Columns["ID"].Visible = false;
                FOTOGRAFIA_dgv.Columns["ESTADO"].Visible = false;
                FOTOGRAFIA_dgv.Columns["USUARIO CREA"].Visible = false;
                FOTOGRAFIA_dgv.Columns["FECHA DE CREACION"].Visible = false;
                FOTOGRAFIA_dgv.Columns["USUARIO MODIFICA"].Visible = false;
                FOTOGRAFIA_dgv.Columns["FECHA DE MODIFICACION"].Visible = false;
                FOTOGRAFIA_dgv.Columns["FICHA"].Visible = false;
                ((DataGridViewImageColumn)FOTOGRAFIA_dgv.Columns["PLANO DE UBICACION"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                ((DataGridViewImageColumn)FOTOGRAFIA_dgv.Columns["FOTOGRAFIA DIGITAL"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                FOTOGRAFIA_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
                FOTOGRAFIA_dgv.RowTemplate.Height = 100;
                IDFotografia_lbl.DataBindings.Add(new Binding("Text", FOTOGRAFIA_bs, "ID", true));
                planoUbicacion_pb.DataBindings.Add(new Binding("Image", FOTOGRAFIA_bs, "PLANO DE UBICACION", true));
                sectorPlanoUbicacion_lbl.DataBindings.Add(new Binding("Text", FOTOGRAFIA_bs, "SECTOR", true));
                manzanaPlanoUbicacion_lbl.DataBindings.Add(new Binding("Text", FOTOGRAFIA_bs, "MANZANA", true));
                lotePlanoUbicacion_lbl.DataBindings.Add(new Binding("Text", FOTOGRAFIA_bs, "LOTE", true));
                añoPlanoUbicacion_txt.DataBindings.Add(new Binding("Text", FOTOGRAFIA_bs, "AÑO PLANO DE UBICACION", true));
                fotografiaDigital_pb.DataBindings.Add(new Binding("Image", FOTOGRAFIA_bs, "FOTOGRAFIA DIGITAL", true));
                sectorFotografiaDigital_lbl.DataBindings.Add(new Binding("Text", FOTOGRAFIA_bs, "SECTOR", true));
                manzanaFotografiaDigital_lbl.DataBindings.Add(new Binding("Text", FOTOGRAFIA_bs, "MANZANA", true));
                loteFotografiaDigital_lbl.DataBindings.Add(new Binding("Text", FOTOGRAFIA_bs, "LOTE", true));
                añoFotografiaDigital_txt.DataBindings.Add(new Binding("Text", FOTOGRAFIA_bs, "AÑO FOTOGRAFIA DIGITAL", true));
                #endregion

                #region Bindings - Calzadas
                CALZADAS_dgv.Columns["ID"].Visible = false;
                CALZADAS_dgv.Columns["M"].Visible = false;
                CALZADAS_dgv.Columns["ECS"].Visible = false;
                CALZADAS_dgv.Columns["ESTADO"].Visible = false;
                CALZADAS_dgv.Columns["USUARIO CREA"].Visible = false;
                CALZADAS_dgv.Columns["FECHA DE CREACION"].Visible = false;
                CALZADAS_dgv.Columns["USUARIO MODIFICA"].Visible = false;
                CALZADAS_dgv.Columns["FECHA DE MODIFICACION"].Visible = false;
                CALZADAS_dgv.Columns["FICHA"].Visible = false;
                CALZADAS_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                IDCalzadas_lbl.DataBindings.Add(new Binding("Text", CALZADAS_bs, "ID", true));
                sectorCalzadas_txt.DataBindings.Add(new Binding("Text", CALZADAS_bs, "SECTOR", true));
                codigoViaCalzadas_txt.DataBindings.Add(new Binding("Text", CALZADAS_bs, "CODIGO DE VIA", true));
                cuadraCalzadas_txt.DataBindings.Add(new Binding("Text", CALZADAS_bs, "CUADRA", true));
                nombreViasCalzadas_lbl.DataBindings.Add(new Binding("Text", CALZADAS_bs, "NOMBRE DE VIA", true));
                largoCalzadas_txt.DataBindings.Add(new Binding("Text", CALZADAS_bs, "LARGO", true));
                anchoCalzadas_txt.DataBindings.Add(new Binding("Text", CALZADAS_bs, "ANCHO", true));
                materialCalzadas_txt.DataBindings.Add(new Binding("Text", CALZADAS_bs, "M", true));
                estadoConservacionCalzadas_txt.DataBindings.Add(new Binding("Text", CALZADAS_bs, "ECS", true));
                especificacionesCalzadas_txt.DataBindings.Add(new Binding("Text", CALZADAS_bs, "ESPECIFICACIONES", true));
                #endregion

                #region Bindings - Veredas
                VEREDAS_dgv.Columns["ID"].Visible = false;
                VEREDAS_dgv.Columns["M"].Visible = false;
                VEREDAS_dgv.Columns["ECS"].Visible = false;
                VEREDAS_dgv.Columns["ESTADO"].Visible = false;
                VEREDAS_dgv.Columns["USUARIO CREA"].Visible = false;
                VEREDAS_dgv.Columns["FECHA DE CREACION"].Visible = false;
                VEREDAS_dgv.Columns["USUARIO MODIFICA"].Visible = false;
                VEREDAS_dgv.Columns["FECHA DE MODIFICACION"].Visible = false;
                VEREDAS_dgv.Columns["FICHA"].Visible = false;
                VEREDAS_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                IDVeredas_lbl.DataBindings.Add(new Binding("Text", VEREDAS_bs, "ID", true));
                descripcionVeredas_txt.DataBindings.Add(new Binding("Text", VEREDAS_bs, "DESCRIPCION", true));
                areaVeredas_txt.DataBindings.Add(new Binding("Text", VEREDAS_bs, "AREA", true));
                materialVeredas_txt.DataBindings.Add(new Binding("Text", VEREDAS_bs, "M", true));
                estadoConservacionVeredas_txt.DataBindings.Add(new Binding("Text", VEREDAS_bs, "ECS", true));
                especificacionesVeredas_txt.DataBindings.Add(new Binding("Text", VEREDAS_bs, "ESPECIFICACIONES", true));
                #endregion                

                #region Bindings - Componente Urbano
                COMPONENTE_URBANO_dgv.Columns["ID"].Visible = false;
                COMPONENTE_URBANO_dgv.Columns["ORDEN"].Visible = false;
                COMPONENTE_URBANO_dgv.Columns["TCU"].Visible = false;
                COMPONENTE_URBANO_dgv.Columns["M"].Visible = false;
                COMPONENTE_URBANO_dgv.Columns["ECS"].Visible = false;
                COMPONENTE_URBANO_dgv.Columns["ESTADO"].Visible = false;
                COMPONENTE_URBANO_dgv.Columns["USUARIO CREA"].Visible = false;
                COMPONENTE_URBANO_dgv.Columns["FECHA DE CREACION"].Visible = false;
                COMPONENTE_URBANO_dgv.Columns["USUARIO MODIFICA"].Visible = false;
                COMPONENTE_URBANO_dgv.Columns["FECHA DE MODIFICACION"].Visible = false;
                COMPONENTE_URBANO_dgv.Columns["FICHA"].Visible = false;
                ((DataGridViewImageColumn)COMPONENTE_URBANO_dgv.Columns["FOTOGRAFIA DIGITAL"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                COMPONENTE_URBANO_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
                COMPONENTE_URBANO_dgv.RowTemplate.Height = 100;
                IDComponenteUrbano_lbl.DataBindings.Add(new Binding("Text", COMPONENTE_URBANO_bs, "ID", true));
                fotografiaDigitalComponenteUrbano_pb.DataBindings.Add(new Binding("Image", COMPONENTE_URBANO_bs, "FOTOGRAFIA DIGITAL", true));
                sectorComponenteUrbano_lbl.DataBindings.Add(new Binding("Text", COMPONENTE_URBANO_bs, "SECTOR", true));
                manzanaComponenteUrbano_lbl.DataBindings.Add(new Binding("Text", COMPONENTE_URBANO_bs, "MANZANA", true));
                loteComponenteUrbano_lbl.DataBindings.Add(new Binding("Text", COMPONENTE_URBANO_bs, "LOTE", true));
                añoComponenteUrbano_txt.DataBindings.Add(new Binding("Text", COMPONENTE_URBANO_bs, "AÑO", true));
                tipoComponenteUrbano_txt.DataBindings.Add(new Binding("Text", COMPONENTE_URBANO_bs, "TCU", true));
                cantidadComponenteUrbano_txt.DataBindings.Add(new Binding("Text", COMPONENTE_URBANO_bs, "CANTIDAD", true));
                materialComponenteUrbano_txt.DataBindings.Add(new Binding("Text", COMPONENTE_URBANO_bs, "M", true));
                estadoConservacionComponenteUrbano_txt.DataBindings.Add(new Binding("Text", COMPONENTE_URBANO_bs, "ECS", true));
                especificacionesComponenteUrbano_txt.DataBindings.Add(new Binding("Text", COMPONENTE_URBANO_bs, "ESPECIFICACIONES", true));
                #endregion

                #region Bindings - Mobiliario Urbano
                MOBILIARIO_URBANO_dgv.Columns["ID"].Visible = false;
                MOBILIARIO_URBANO_dgv.Columns["ORDEN"].Visible = false;
                MOBILIARIO_URBANO_dgv.Columns["TMU"].Visible = false;
                MOBILIARIO_URBANO_dgv.Columns["M"].Visible = false;
                MOBILIARIO_URBANO_dgv.Columns["ECS"].Visible = false;
                MOBILIARIO_URBANO_dgv.Columns["ESTADO"].Visible = false;
                MOBILIARIO_URBANO_dgv.Columns["USUARIO CREA"].Visible = false;
                MOBILIARIO_URBANO_dgv.Columns["FECHA DE CREACION"].Visible = false;
                MOBILIARIO_URBANO_dgv.Columns["USUARIO MODIFICA"].Visible = false;
                MOBILIARIO_URBANO_dgv.Columns["FECHA DE MODIFICACION"].Visible = false;
                MOBILIARIO_URBANO_dgv.Columns["FICHA"].Visible = false;
                ((DataGridViewImageColumn)COMPONENTE_URBANO_dgv.Columns["FOTOGRAFIA DIGITAL"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                MOBILIARIO_URBANO_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
                MOBILIARIO_URBANO_dgv.RowTemplate.Height = 100;
                IDMobiliarioUrbano_lbl.DataBindings.Add(new Binding("Text", MOBILIARIO_URBANO_bs, "ID", true));
                fotografiaDigitalMobiliarioUrbano_pb.DataBindings.Add(new Binding("Image", MOBILIARIO_URBANO_bs, "FOTOGRAFIA DIGITAL", true));
                sectorMobiliarioUrbano_lbl.DataBindings.Add(new Binding("Text", MOBILIARIO_URBANO_bs, "SECTOR", true));
                manzanaMobiliarioUrbano_lbl.DataBindings.Add(new Binding("Text", MOBILIARIO_URBANO_bs, "MANZANA", true));
                loteMobiliarioUrbano_lbl.DataBindings.Add(new Binding("Text", MOBILIARIO_URBANO_bs, "LOTE", true));
                añoMobiliarioUrbano_txt.DataBindings.Add(new Binding("Text", MOBILIARIO_URBANO_bs, "AÑO", true));
                tipoMobiliarioUrbano_txt.DataBindings.Add(new Binding("Text", MOBILIARIO_URBANO_bs, "TMU", true));
                cantidadMobiliarioUrbano_txt.DataBindings.Add(new Binding("Text", MOBILIARIO_URBANO_bs, "CANTIDAD", true));
                materialMobiliarioUrbano_txt.DataBindings.Add(new Binding("Text", MOBILIARIO_URBANO_bs, "M", true));
                estadoConservacionMobiliarioUrbano_txt.DataBindings.Add(new Binding("Text", MOBILIARIO_URBANO_bs, "ECS", true));
                especificacionesMobiliarioUrbano_txt.DataBindings.Add(new Binding("Text", MOBILIARIO_URBANO_bs, "ESPECIFICACIONES", true));
                #endregion
                base.listar_busqueda();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error - Listar");
            }
        }

        private void nuevo_tsb_Click(object sender, EventArgs e)
        {
            if (!habilitar_controles_ficha)
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage1;
                habilitar_controles_ficha = true;
                base.controles = false;
                actualizar_datos_ubicacion_geografica();
                //Calzadas  
                iniciar_calzadas = true;
                aceptarCalzadas.Enabled = false;
                //Veredas
                iniciar_veredas = true;
                aceptarVeredas.Enabled = false;
                //Fotografía
                iniciar_fotografia = true;
                aceptarFotografia.Enabled = false;
                //Componente Urbano
                iniciar_componente_urbano = true;
                aceptarComponenteUrbano.Enabled = false;
                //Mobiliario Urbano
                iniciar_mobiliario_urbano = true;
                aceptarMobiliarioUrbano.Enabled = false;

                FICHA_bs.EndEdit();
                FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACIONRow datos = FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACION.FindByFICHA("0000000000");
                if (datos != null)
                {
                    datos.BeginEdit();
                    ficha_lbl.Text = (new cFicha_Catastral_Espacio_Recreacion()).nuevo_codigo();
                    datos.FICHA = ficha_lbl.Text.Trim();
                    datos.FECHA_SUPERVISOR = DateTime.Now;
                    datos.FECHA_TECNICO_CATASTRAL = DateTime.Now;
                    datos.FECHA_VB_DIGITACION = DateTime.Now;
                    datos.EndEdit();
                    FICHA_bs.Filter = string.Format("FICHA = {0}", ficha_lbl.Text);                    
                    buscar_tst.Text = "";
                }
                sector_txt.Focus();
            }
        }

        private void aceptar_tsb_Click(object sender, EventArgs e)
        {
            try
            {
                if (areaTotalEspacioRecreacion_txt.Text.Length == 0)
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage3;
                    secundario_tc.SelectedTab = tabPage1;
                }

                if (estadoLlenadoFicha_txt.Text.Length == 0)
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage4;
                    secundario_tc.SelectedTab = tabPage1;
                }

                if (FICHA_dgv.Rows.Count > 0)
                {
                    if (parcialFichas_txt.Text.Length == 0)
                    {
                        parcialFichas_txt_Leave(sender, e);
                        return;
                    }
                    if (totalFichas_txt.Text.Length == 0)
                    {
                        totalFichas_txt_Leave(sender, e);
                        return;
                    }
                    if (sector_txt.Text.Length == 0)
                    {
                        sector_txt_Leave(sender, e);
                        return;
                    }
                    if (manzana_txt.Text.Length == 0)
                    {
                        manzana_txt_Leave(sender, e);
                        return;
                    }
                    if (nomenclatura_txt.Text.Length == 0)
                    {
                        nomenclatura_txt_Leave(sender, e);
                        return;
                    }
                    if (areaTotalEspacioRecreacion_txt.Text.Length == 0)
                    {
                        areaTotalEspacioRecreacion_txt_Leave(sender, e);
                        return;
                    }
                    if (areaVerdeEspacioRecreacion_txt.Text.Length == 0)
                    {
                        areaVerdeEspacioRecreacion_txt_Leave(sender, e);
                        return;
                    }
                    if (!buscar_estado_conservacion_espacio_recreacion())
                    {
                        estadoConservacionEspacioRecreacion_txt_Leave(sender, e);
                        return;
                    }
                    if (!buscar_tipo_espacio_recreacion())
                    {
                        tipoEspacioRecreacion_txt_Leave(sender, e);
                        return;
                    }
                    if (!buscar_estado_llenado_ficha())
                    {
                        estadoLlenadoFicha_txt_Leave(sender, e);
                        return;
                    }

                    if (habilitar_controles_fotografia)
                    {
                        if (aceptarFotografia.Text == "Aceptar" || aceptarFotografia.Text == "Agregar Fotografía")
                        {
                            principal_tc.SelectedTab = formulario_tp;
                            secundario_tc.SelectedTab = tabPage2;
                            fotografia_tc.SelectedTab = tabPage8;
                            aceptarFotografia.ForeColor = Color.Red;
                        }
                    }
                    if (habilitar_controles_calzadas)
                    {
                        if (aceptarCalzadas.Text == "Aceptar" || aceptarCalzadas.Text == "Agregar Calzada")
                        {
                            principal_tc.SelectedTab = formulario_tp;
                            secundario_tc.SelectedTab = tabPage3;
                            calzadas_tc.SelectedTab = tabPage14;
                            aceptarCalzadas.ForeColor = Color.Red;
                        }
                    }
                    if (habilitar_controles_veredas)
                    {
                        if (aceptarVeredas.Text == "Aceptar" || aceptarVeredas.Text == "Agregar Vereda")
                        {
                            principal_tc.SelectedTab = formulario_tp;
                            secundario_tc.SelectedTab = tabPage3;
                            veredas_tc.SelectedTab = tabPage16;
                            aceptarVeredas.ForeColor = Color.Red;
                        }
                    }
                    if (habilitar_controles_componente_urbano)
                    {
                        if (aceptarComponenteUrbano.Text == "Aceptar" || aceptarComponenteUrbano.Text == "Agregar Componente Urbano")
                        {
                            principal_tc.SelectedTab = formulario_tp;
                            secundario_tc.SelectedTab = tabPage5;
                            componente_urbano_tc.SelectedTab = tabPage10;
                            aceptarComponenteUrbano.ForeColor = Color.Red;
                        }
                    }
                    if (habilitar_controles_mobiliario_urbano)
                    {
                        if (aceptarMobiliarioUrbano.Text == "Aceptar" || aceptarMobiliarioUrbano.Text == "Agregar Mobiliario Urbano")
                        {
                            principal_tc.SelectedTab = formulario_tp;
                            secundario_tc.SelectedTab = tabPage6;
                            mobiliario_urbano_tc.SelectedTab = tabPage12;
                            aceptarMobiliarioUrbano.ForeColor = Color.Red;
                        }
                    }

                    if (validar)
                    {
                        habilitar_controles_ficha = true;
                        FICHA_bs.Filter = string.Format("FICHA = {0}", ficha_lbl.Text);
                        buscar_tst.Text = "";
                        if (aceptar_tsb.Text == "&Guardar") guardar();
                        else if (aceptar_tsb.Text == "&Modificar")
                        {
                            base.controles = false;
                            aceptar_tsb.Text = "&Aceptar";
                            aceptar_tsb.Image = null;
                            nuevo_tsb.Enabled = false;
                            eliminar_tsb.Enabled = true;
                            principal_tc.SelectedTab = formulario_tp;
                            secundario_tc.SelectedTab = tabPage1;
                            //Calzadas
                            habilitar_movimiento_calzadas = true;
                            nuevoCalzadas.Enabled = true;
                            aceptarCalzadas.Enabled = (CALZADAS_dgv.RowCount == 0) ? false : true;
                            eliminarCalzadas.Enabled = (CALZADAS_dgv.RowCount == 0) ? false : true;
                            //Veredas
                            habilitar_movimiento_veredas = true;
                            nuevoVeredas.Enabled = true;
                            aceptarVeredas.Enabled = (VEREDAS_dgv.RowCount == 0) ? false : true;
                            eliminarVeredas.Enabled = (VEREDAS_dgv.RowCount == 0) ? false : true;
                            //Fotografía
                            habilitar_movimiento_fotografia = true;
                            nuevoFotografia.Enabled = true;
                            aceptarFotografia.Enabled = (FOTOGRAFIA_dgv.RowCount == 0) ? false : true;
                            eliminarFotografia.Enabled = (FOTOGRAFIA_dgv.RowCount == 0) ? false : true;
                            //Componente Urbano
                            habilitar_movimiento_componente_urbano = true;
                            nuevoComponenteUrbano.Enabled = true;
                            aceptarComponenteUrbano.Enabled = (COMPONENTE_URBANO_dgv.RowCount == 0) ? false : true;
                            eliminarComponenteUrbano.Enabled = (COMPONENTE_URBANO_dgv.RowCount == 0) ? false : true;
                            //Mobiliario Urbano
                            habilitar_movimiento_mobiliario_urbano = true;
                            nuevoMobiliarioUrbano.Enabled = true;
                            aceptarMobiliarioUrbano.Enabled = (MOBILIARIO_URBANO_dgv.RowCount == 0) ? false : true;
                            eliminarMobiliarioUrbano.Enabled = (MOBILIARIO_URBANO_dgv.RowCount == 0) ? false : true;

                            sector_txt.Focus();
                        }
                        else if (aceptar_tsb.Text == "&Aceptar") modificar();
                    }
                }
            }
            catch (Exception ex)
            {
                iniciar();
                MessageBox.Show(ex.Message, "Error - Guardar y/o Modificar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminar_tsb_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea Eliminar la Ficha Nº: " + numero_ficha_lbl.Text + " de la base de Datos?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    if (FICHA_dgv.Rows.Count > 0) eliminar();
            }
            catch (Exception ex)
            {
                iniciar();
                MessageBox.Show(ex.Message, "Error - Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelar_tsb_Click(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                habilitar_controles_ficha = false;
                base.controles = true;
            }
            listar();
        }

        private void vistaPrevia_tsb_Click(object sender, EventArgs e)
        {
            try
            {
                FICHA_ds rpt = (new cFicha_Catastral_Espacio_Recreacion()).reporte();
                if (rpt != null)
                {
                    DataView vista = rpt.VS_REPORTE_FICHA_CATASTRAL_ESPACIO_RECREACION.DefaultView;
                    vista.RowFilter = query;
                    DataTable tabla = vista.ToTable();
                    Reporte reporte = (tabla.Rows.Count > 0) ? new Reporte('3', tabla) : new Reporte('3', rpt);
                    reporte.Text = "Vista Previa, " + this.Text;
                    reporte.ShowDialog();
                }
            }
            catch (Exception ex)
            {               
                MessageBox.Show(ex.Message, "Error - Vista Previa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void cerrar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (i != 0) this.DialogResult = DialogResult.OK;
        }

        private void FICHA_bs_PositionChanged(object sender, EventArgs e)
        {
            supervisor_lbl.Text = supervisor_lbl.Text.Replace('|', (char)Keys.Enter);
            tecnicoCatastral_lbl.Text = tecnicoCatastral_lbl.Text.Replace('|', (char)Keys.Enter);
            digitalizacion_lbl.Text = digitalizacion_lbl.Text.Replace('|', (char)Keys.Enter);
        }

        private void parcialFichas_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (parcialFichas_txt.Text.Length > 0)
                {
                    parcialFichas_lbl.BackColor = Color.LightBlue;
                    parcialFichas_txt.ForeColor = Color.Black;
                }
                else
                {
                    secundario_tc.SelectedTab = tabPage1;
                    parcialFichas_lbl.BackColor = Color.Red;
                    parcialFichas_txt.Focus();
                    parcialFichas_txt.SelectAll();
                    parcialFichas_txt.ForeColor = Color.Red;
                }
            }
        }

        private void totalFichas_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (parcialFichas_txt.Text.Length > 0)
                {
                    totalFichas_lbl.BackColor = Color.LightBlue;
                    totalFichas_txt.ForeColor = Color.Black;
                }
                else
                {
                    secundario_tc.SelectedTab = tabPage1;
                    totalFichas_lbl.BackColor = Color.Red;
                    totalFichas_txt.Focus();
                    totalFichas_txt.SelectAll();
                    totalFichas_txt.ForeColor = Color.Red;
                }
            }
        }

        private void sector_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (sector_txt.Text.Length == 2)
                {
                    sector_lbl.BackColor = Color.LightBlue;
                    sector_txt.ForeColor = Color.Black;
                }
                else
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage1;
                    sector_lbl.BackColor = Color.Red;
                    sector_txt.Focus();
                    sector_txt.SelectAll();
                    sector_txt.ForeColor = Color.Red;
                }
            }
        }

        private void manzana_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (manzana_txt.Text.Length == 3)
                {
                    manzana_lbl.BackColor = Color.LightBlue;
                    manzana_txt.ForeColor = Color.Black;
                }
                else
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage1;
                    manzana_lbl.BackColor = Color.Red;
                    manzana_txt.Focus();
                    manzana_txt.SelectAll();
                    manzana_txt.ForeColor = Color.Red;
                }
            }
            else if (manzana_lbl.BackColor == Color.Red) manzana_lbl.BackColor = Color.LightBlue;
        }

        private void lote_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (lote_txt.Text.Length == 3 || lote_txt.Text.Length == 0)
                {
                    lote_lbl.BackColor = Color.LightBlue;
                    lote_txt.ForeColor = Color.Black;
                }
                else
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage1;
                    lote_lbl.BackColor = Color.Red;
                    lote_txt.Focus();
                    lote_txt.SelectAll();
                    lote_txt.ForeColor = Color.Red;
                }
            }
            else if (lote_lbl.BackColor == Color.Red) lote_lbl.BackColor = Color.LightBlue;
        }

        private void nomenclatura_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (nomenclatura_txt.Text.Length > 0)
                {
                    nomenclatura_lbl.BackColor = Color.LightBlue;
                    nomenclatura_txt.ForeColor = Color.Black;
                }
                else
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage1;
                    nomenclatura_lbl.BackColor = Color.Red;
                    nomenclatura_txt.Focus();
                    nomenclatura_txt.SelectAll();
                    nomenclatura_txt.ForeColor = Color.Red;
                }
            }
            else if (nomenclatura_lbl.BackColor == Color.Red) nomenclatura_lbl.BackColor = Color.LightBlue;
        }

        private void codigoHabilitacionUrbana_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (codigoHabilitacionUrbana_txt.Text.Length != 0)
                {                    
                    int j = (codigoHabilitacionUrbana_txt.Text.IndexOf('-') != -1) ? codigoHabilitacionUrbana_txt.Text.IndexOf('-') : codigoHabilitacionUrbana_txt.Text.Length;
                    codigoHabilitacionUrbana_txt.Text = (codigoHabilitacionUrbana_txt.Text.Length > 0) ? codigoHabilitacionUrbana_txt.Text.Substring(0, j-1) : "";                    
                    DataRow fila = habilitacion_urbana.Buscar(codigoHabilitacionUrbana_txt.Text.Trim());
                    if (fila == null)
                    {
                        principal_tc.SelectedTab = formulario_tp;
                        secundario_tc.SelectedTab = tabPage1;
                        codigoHabilitacionUrbana_lbl.BackColor = Color.Red;
                        codigoHabilitacionUrbana_txt.Focus();
                        codigoHabilitacionUrbana_txt.SelectAll();
                        codigoHabilitacionUrbana_txt.ForeColor = Color.Red;
                        nombreHabitacionUrbana_lbl.Text = "";
                    }
                    else
                    {
                        codigoHabilitacionUrbana_lbl.BackColor = Color.LightBlue;
                        codigoHabilitacionUrbana_txt.ForeColor = Color.Black;
                        nombreHabitacionUrbana_lbl.Text = fila["DESCRIPCION"].ToString();
                    }
                }
                else
                {
                    codigoHabilitacionUrbana_lbl.BackColor = Color.LightBlue;
                    codigoHabilitacionUrbana_txt.ForeColor = Color.Black;
                    nombreHabitacionUrbana_lbl.Text = "";
                }
            }
            else if (codigoHabilitacionUrbana_lbl.BackColor == Color.Red) codigoHabilitacionUrbana_lbl.BackColor = Color.LightBlue;
        }

        private void areaTotalEspacioRecreacion_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (areaTotalEspacioRecreacion_txt.Text.Length > 0)
                {
                    areaTotalEspacioRecreacion_lbl.BackColor = Color.LightBlue;
                    areaTotalEspacioRecreacion_txt.ForeColor = Color.Black;
                }
                else
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage3;
                    areaTotalEspacioRecreacion_lbl.BackColor = Color.Red;
                    areaTotalEspacioRecreacion_txt.Focus();
                    areaTotalEspacioRecreacion_txt.SelectAll();
                    areaTotalEspacioRecreacion_txt.ForeColor = Color.Red;
                }
            }
            else if (areaTotalEspacioRecreacion_lbl.BackColor == Color.Red) areaTotalEspacioRecreacion_lbl.BackColor = Color.LightBlue;
        }

        private void areaVerdeEspacioRecreacion_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (areaVerdeEspacioRecreacion_txt.Text.Length > 0)
                {
                    areaVerdeEspacioRecreacion_lbl.BackColor = Color.LightBlue;
                    areaVerdeEspacioRecreacion_txt.ForeColor = Color.Black;
                }
                else
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage3;
                    areaVerdeEspacioRecreacion_lbl.BackColor = Color.Red;
                    areaVerdeEspacioRecreacion_txt.Focus();
                    areaVerdeEspacioRecreacion_txt.SelectAll();
                    areaVerdeEspacioRecreacion_txt.ForeColor = Color.Red;
                }
            }
            else if (areaVerdeEspacioRecreacion_lbl.BackColor == Color.Red) areaVerdeEspacioRecreacion_lbl.BackColor = Color.LightBlue;
        }

        private void estadoConservacionEspacioRecreacion_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (buscar_estado_conservacion_espacio_recreacion())
                {
                    estadoConservacionEspacioRecreacion_lbl.BackColor = Color.LightBlue;
                    estadoConservacionEspacioRecreacion_txt.ForeColor = Color.Black;
                }
                else
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage3;
                    estadoConservacionEspacioRecreacion_lbl.BackColor = Color.Red;
                    estadoConservacionEspacioRecreacion_txt.Focus();
                    estadoConservacionEspacioRecreacion_txt.SelectAll();
                    estadoConservacionEspacioRecreacion_txt.ForeColor = Color.Red;
                }
            }
            else if (estadoConservacionEspacioRecreacion_lbl.BackColor == Color.Red) estadoConservacionEspacioRecreacion_lbl.BackColor = Color.LightBlue;
        }

        private void tipoEspacioRecreacion_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (buscar_tipo_espacio_recreacion())
                {
                    tipoEspacioRecreacion_lbl.BackColor = Color.LightBlue;
                    tipoEspacioRecreacion_txt.ForeColor = Color.Black;
                }
                else
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage3;
                    tipoEspacioRecreacion_lbl.BackColor = Color.Red;
                    tipoEspacioRecreacion_txt.Focus();
                    tipoEspacioRecreacion_txt.SelectAll();
                    tipoEspacioRecreacion_txt.ForeColor = Color.Red;
                }
            }
            else if (tipoEspacioRecreacion_lbl.BackColor == Color.Red) tipoEspacioRecreacion_lbl.BackColor = Color.LightBlue;
        }

        private void estadoLlenadoFicha_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                estadoLlenadoFicha_txt.Text = (estadoLlenadoFicha_txt.Text.Length > 2) ? estadoLlenadoFicha_txt.Text.Substring(0, 2) : estadoLlenadoFicha_txt.Text;
                if (buscar_estado_llenado_ficha())
                {
                    estadoLlenadoFicha_lbl.BackColor = Color.LightBlue;
                    estadoLlenadoFicha_txt.ForeColor = Color.Black;
                }
                else
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage4;
                    estadoLlenadoFicha_lbl.BackColor = Color.Red;
                    estadoLlenadoFicha_txt.Focus();
                    estadoLlenadoFicha_txt.SelectAll();
                    estadoLlenadoFicha_txt.ForeColor = Color.Red;
                }
            }
            else if (estadoLlenadoFicha_txt.BackColor == Color.Red) estadoLlenadoFicha_txt.BackColor = Color.LightBlue;
        }

        private void supervisor_lbl_BindingContextChanged(object sender, EventArgs e)
        {
            supervisor_lbl.Text = supervisor_lbl.Text.Replace('|', (char)Keys.Enter);
        }

        private void tecnicoCatastral_lbl_BindingContextChanged(object sender, EventArgs e)
        {
            tecnicoCatastral_lbl.Text = tecnicoCatastral_lbl.Text.Replace('|', (char)Keys.Enter);
        }

        private void digitalizacion_lbl_BindingContextChanged(object sender, EventArgs e)
        {
            digitalizacion_lbl.Text = digitalizacion_lbl.Text.Replace('|', (char)Keys.Enter);
        }
        #endregion

        #region [ EVENTOS DE FICHA CATASTRAL DE ESPACIO DE RECREACION - FOTOGRAFIA]
        private void nuevoFotografia_Click(object sender, EventArgs e)
        {
            if (sector_txt.Text.Length == 2 && manzana_txt.Text.Length == 3)
            {
                habilitar_movimiento_fotografia = false;
                habilitar_controles_fotografia = true;
                aceptarFotografia.Enabled = true;
                aceptarFotografia.Text = "Agregar Fotografía";
                aceptarFotografia.Image = (Image)(resources.GetObject("aceptarFotografia.Image"));
                nuevoFotografia.Enabled = false;
                eliminarFotografia.Enabled = false;
                cancelarFotografia.Enabled = true;
                FOTOGRAFIA_bs.AddNew();
                planoUbicacion_pb_Click(sender, e);
            }
        }

        private void eliminarFotografia_Click(object sender, EventArgs e)
        {
            FOTOGRAFIA_bs.RemoveAt(FOTOGRAFIA_bs.Position);
            if (FOTOGRAFIA_dgv.RowCount == 0)
            {
                aceptarFotografia.Enabled = false;
                cancelarFotografia.Enabled = false;
                eliminarFotografia.Enabled = false;
            }
        }

        private void aceptarFotografia_Click(object sender, EventArgs e)
        {
            try
            {
                if (aceptarFotografia.Text == "Agregar Fotografía")
                {
                    FOTOGRAFIA_bs.EndEdit();
                    long id = long.Parse(FOTOGRAFIA_dgv["ID", FOTOGRAFIA_dgv.CurrentRow.Index].Value.ToString());
                    FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACION_FOTOGRAFIARow datos = FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACION_FOTOGRAFIA.FindByID(id);
                    if (datos != null)
                    {
                        datos.BeginEdit();
                        datos.PLANO_DE_UBICACION = (planoUbicacion_pb.Image != null) ? ((planoUbicacion_pb.ImageLocation != null) ? File.ReadAllBytes(planoUbicacion_pb.ImageLocation) : cConfiguracion.toBytes(planoUbicacion_pb.Image)) : null;
                        datos.AÑO_PLANO_DE_UBICACION = (añoPlanoUbicacion_txt.Text.Length == 0) ? DateTime.Now.Year.ToString() : añoPlanoUbicacion_txt.Text.Trim();
                        datos.FOTOGRAFIA_DIGITAL = (fotografiaDigital_pb.Image != null) ? ((fotografiaDigital_pb.ImageLocation != null) ? File.ReadAllBytes(fotografiaDigital_pb.ImageLocation) : cConfiguracion.toBytes(fotografiaDigital_pb.Image)) : null;
                        datos.AÑO_FOTOGRAFIA_DIGITAL = (añoFotografiaDigital_txt.Text.Length == 0) ? DateTime.Now.Year.ToString() : añoFotografiaDigital_txt.Text.Trim();
                        datos.SECTOR = sector_txt.Text;
                        datos.MANZANA = manzana_txt.Text;
                        datos.LOTE = lote_txt.Text;
                        datos.ESTADO = "A";
                        datos.USUARIO_CREA = Usuario;
                        datos.FECHA_DE_CREACION = DateTime.Now;
                        datos.USUARIO_MODIFICA = Usuario;
                        datos.FECHA_DE_MODIFICACION = DateTime.Now;
                        datos.FICHA = ficha_lbl.Text.Trim();
                        datos.EndEdit();
                    }
                    habilitar_movimiento_fotografia = true;
                    habilitar_controles_fotografia = false;
                    iniciar_fotografia = true;
                }
                else if (aceptarFotografia.Text == "Modificar Fotografía")
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage2;
                    fotografia_tc.SelectedTab = tabPage8;
                    habilitar_movimiento_fotografia = false;
                    habilitar_controles_fotografia = true;
                    aceptarFotografia.Text = "Aceptar";
                    aceptarFotografia.Image = null;
                    nuevoFotografia.Enabled = false;
                    eliminarFotografia.Enabled = false;
                    añoPlanoUbicacion_txt.Focus();
                }
                else if (aceptarFotografia.Text == "Aceptar")
                {
                    FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACION_FOTOGRAFIARow datos = FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACION_FOTOGRAFIA.FindByID(long.Parse(IDFotografia_lbl.Text));
                    if (datos != null)
                    {
                        datos.BeginEdit();
                        datos.PLANO_DE_UBICACION = (planoUbicacion_pb.Image != null) ? ((planoUbicacion_pb.ImageLocation != null) ? File.ReadAllBytes(planoUbicacion_pb.ImageLocation) : cConfiguracion.toBytes(planoUbicacion_pb.Image)) : null;
                        datos.AÑO_PLANO_DE_UBICACION = (añoPlanoUbicacion_txt.Text.Length == 0) ? DateTime.Now.Year.ToString() : añoPlanoUbicacion_txt.Text.Trim();
                        datos.FOTOGRAFIA_DIGITAL = (fotografiaDigital_pb.Image != null) ? ((fotografiaDigital_pb.ImageLocation != null) ? File.ReadAllBytes(fotografiaDigital_pb.ImageLocation) : cConfiguracion.toBytes(fotografiaDigital_pb.Image)) : null;
                        datos.AÑO_FOTOGRAFIA_DIGITAL = (añoFotografiaDigital_txt.Text.Length == 0) ? DateTime.Now.Year.ToString() : añoFotografiaDigital_txt.Text.Trim();
                        datos.SECTOR = sector_txt.Text;
                        datos.MANZANA = manzana_txt.Text;
                        datos.LOTE = lote_txt.Text;
                        datos.ESTADO = "A";
                        datos.USUARIO_MODIFICA = Usuario;
                        datos.FECHA_DE_MODIFICACION = DateTime.Now;
                        datos.FICHA = ficha_lbl.Text.Trim();
                        datos.EndEdit();
                    }
                    habilitar_movimiento_fotografia = true;
                    habilitar_controles_fotografia = false;
                    iniciar_fotografia = true;
                }
            }
            catch (Exception ex)
            {
                cancelarFotografia_Click(sender, e);
                MessageBox.Show(ex.Message, "Error Agregar y/o Modificar, Fotografía", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelarFotografia_Click(object sender, EventArgs e)
        {
            fotografia_tc.SelectedTab = tabPage8;
            FOTOGRAFIA_bs.CancelEdit();
            habilitar_controles_fotografia = false;
            habilitar_movimiento_fotografia = true;
            iniciar_fotografia = true;
        }

        private void planoUbicacion_pb_Click(object sender, EventArgs e)
        {
            if (sector_txt.Text.Length > 0 && manzana_txt.Text.Length > 0)
            {
                DialogResult rpta = AbrirFotografia.ShowDialog();
                if (rpta == System.Windows.Forms.DialogResult.OK)
                {
                    planoUbicacion_pb.ImageLocation = AbrirFotografia.FileName;
                    sectorPlanoUbicacion_lbl.Text = sector_txt.Text;
                    manzanaPlanoUbicacion_lbl.Text = manzana_txt.Text;
                    lotePlanoUbicacion_lbl.Text = lote_txt.Text;
                    añoPlanoUbicacion_txt.Text = DateTime.Now.Year.ToString();
                }
                else
                {
                    planoUbicacion_pb.ImageLocation = "";
                    sectorPlanoUbicacion_lbl.Text = "";
                    manzanaPlanoUbicacion_lbl.Text = "";
                    lotePlanoUbicacion_lbl.Text = "";
                    añoPlanoUbicacion_txt.Text = "";
                }
                añoPlanoUbicacion_txt.Focus();
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage1;
                if (sector_txt.Text.Length == 0) sector_txt.Focus();
                if (manzana_txt.Text.Length == 0) manzana_txt.Focus();
            }
        }

        private void añoPlanoUbicacion_txt_Leave(object sender, EventArgs e)
        {
            if (añoPlanoUbicacion_txt.Text.Length == 4 || añoPlanoUbicacion_txt.Text.Length == 0)
            {
                añoPlanoUbicacion_lbl.BackColor = Color.LightBlue;
                añoPlanoUbicacion_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage2;
                fotografia_tc.SelectedTab = tabPage8;
                añoPlanoUbicacion_lbl.BackColor = Color.Red;
                añoPlanoUbicacion_txt.Focus();
                añoPlanoUbicacion_txt.SelectAll();
                añoPlanoUbicacion_txt.ForeColor = Color.Red;
            }
            if (añoPlanoUbicacion_lbl.BackColor == Color.Red && añoPlanoUbicacion_txt.Enabled == false) añoPlanoUbicacion_lbl.BackColor = Color.LightBlue;
        }

        private void fotografiaDigital_pb_Click(object sender, EventArgs e)
        {
            if (sector_txt.Text.Length > 0 && manzana_txt.Text.Length > 0)
            {
                DialogResult rpta = AbrirFotografia.ShowDialog();
                if (rpta == System.Windows.Forms.DialogResult.OK)
                {
                    fotografiaDigital_pb.ImageLocation = AbrirFotografia.FileName;
                    sectorFotografiaDigital_lbl.Text = sector_txt.Text;
                    manzanaFotografiaDigital_lbl.Text = manzana_txt.Text;
                    loteFotografiaDigital_lbl.Text = lote_txt.Text;
                    añoFotografiaDigital_txt.Text = DateTime.Now.Year.ToString();
                }
                else
                {
                    fotografiaDigital_pb.ImageLocation = "";
                    sectorFotografiaDigital_lbl.Text = "";
                    manzanaFotografiaDigital_lbl.Text = "";
                    loteFotografiaDigital_lbl.Text = "";
                    añoFotografiaDigital_txt.Text = "";
                }
                añoFotografiaDigital_txt.Focus();
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage1;
                if (sector_txt.Text.Length == 0) sector_txt.Focus();
                if (manzana_txt.Text.Length == 0) manzana_txt.Focus();
            }
        }

        private void añoFotografiaDigital_txt_Leave(object sender, EventArgs e)
        {
            if (añoFotografiaDigital_txt.Text.Length == 4 || añoFotografiaDigital_txt.Text.Length == 0)
            {
                añoFotografiaDigital_lbl.BackColor = Color.LightBlue;
                añoFotografiaDigital_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage2;
                fotografia_tc.SelectedTab = tabPage8;
                añoFotografiaDigital_lbl.BackColor = Color.Red;
                añoFotografiaDigital_txt.Focus();
                añoFotografiaDigital_txt.SelectAll();
                añoFotografiaDigital_txt.ForeColor = Color.Red;
            }
            if (añoFotografiaDigital_lbl.BackColor == Color.Red && añoFotografiaDigital_txt.Enabled == false) añoFotografiaDigital_lbl.BackColor = Color.LightBlue;
        }

        private void FOTOGRAFIA_dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion

        #region [ EVENTOS DE FICHA CATASTRAL DE ESPACIO DE RECREACION - CALZADAS]
        private void nuevoCalzadas_Click(object sender, EventArgs e)
        {
            habilitar_movimiento_calzadas = false;
            habilitar_controles_calzadas = true;
            aceptarCalzadas.Enabled = true;
            aceptarCalzadas.Text = "Agregar Calzada";
            aceptarCalzadas.Image = (Image)(resources.GetObject("aceptarCalzadas.Image"));
            nuevoCalzadas.Enabled = false;
            eliminarCalzadas.Enabled = false;
            cancelarCalzadas.Enabled = true;
            CALZADAS_bs.AddNew();
            sectorCalzadas_txt.Focus();
        }

        private void eliminarCalzadas_Click(object sender, EventArgs e)
        {
            CALZADAS_bs.RemoveAt(CALZADAS_bs.Position);
            if (CALZADAS_dgv.RowCount == 0)
            {
                aceptarCalzadas.Enabled = false;
                cancelarCalzadas.Enabled = false;
                eliminarCalzadas.Enabled = false;
            }
        }

        private void aceptarCalzadas_Click(object sender, EventArgs e)
        {
            try
            {
                if (sectorCalzadas_txt.Text.Length != 2)
                {
                    sectorCalzadas_txt_Leave(sender, e);
                    return;
                }
                if (codigoViaCalzadas_lbl.BackColor == Color.Red)
                {
                    codigoViaCalzadas_txt_Leave(sender, e);
                    return;
                }
                if (cuadraCalzadas_txt.Text.Length != 2)
                {
                    cuadraCalzadas_txt_Leave(sender, e);
                    return;
                }
                if (largoCalzadas_txt.Text.Length == 0)
                {
                    largoCalzadas_txt_Leave(sender, e); 
                    return;
                }
                if (anchoCalzadas_txt.Text.Length == 0)
                {
                    anchoCalzadas_txt_Leave(sender, e);
                    return;
                }
                if (!buscar_material_calzadas())
                {
                    materialCalzadas_txt_Leave(sender, e);
                    return;
                }
                if (!buscar_estado_conservacion_calzadas())
                {
                    estadoConservacionCalzadas_txt_Leave(sender, e);
                    return;
                }

                if (aceptarCalzadas.Text == "Agregar Calzada")
                {
                    CALZADAS_bs.EndEdit();
                    int id = int.Parse(CALZADAS_dgv["ID", CALZADAS_dgv.CurrentRow.Index].Value.ToString());
                    FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACION_CALZADASRow datos = FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACION_CALZADAS.FindByID(id);
                    if (datos != null)
                    {
                        datos.BeginEdit();                        
                        datos.SECTOR = sectorCalzadas_txt.Text;
                        datos.CODIGO_DE_VIA = codigoViaCalzadas_txt.Text;
                        datos.CUADRA = cuadraCalzadas_txt.Text;
                        datos.LARGO = (largoCalzadas_txt.Text.Length > 0) ? double.Parse(largoCalzadas_txt.Text) : 0;
                        datos.ANCHO = (anchoCalzadas_txt.Text.Length > 0) ? double.Parse(anchoCalzadas_txt.Text) : 0;
                        datos.M = materialCalzadas_txt.Text;
                        datos.ECS = estadoConservacionCalzadas_txt.Text;
                        datos.ESPECIFICACIONES = especificacionesCalzadas_txt.Text;
                        datos.ESTADO = "A";
                        datos.USUARIO_CREA = Usuario;
                        datos.FECHA_DE_CREACION = DateTime.Now;
                        datos.USUARIO_MODIFICA = Usuario;
                        datos.FECHA_DE_MODIFICACION = DateTime.Now;
                        datos.FICHA = ficha_lbl.Text.Trim();
                        datos.EndEdit();
                    }
                    habilitar_movimiento_calzadas = true;
                    habilitar_controles_calzadas = false;
                    iniciar_calzadas = true;
                }
                else if (aceptarCalzadas.Text == "Modificar Calzada")
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage3;
                    calzadas_tc.SelectedTab = tabPage14;
                    habilitar_movimiento_calzadas = false;
                    habilitar_controles_calzadas = true;
                    aceptarCalzadas.Text = "Aceptar";
                    aceptarCalzadas.Image = null;
                    nuevoCalzadas.Enabled = false;
                    eliminarCalzadas.Enabled = false;
                    sectorCalzadas_txt.Focus();
                }
                else if (aceptarCalzadas.Text == "Aceptar")
                {
                    FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACION_CALZADASRow datos = FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACION_CALZADAS.FindByID(int.Parse(IDCalzadas_lbl.Text));
                    if (datos != null)
                    {
                        datos.BeginEdit();
                        datos.SECTOR = sectorCalzadas_txt.Text;
                        datos.CODIGO_DE_VIA = codigoViaCalzadas_txt.Text;
                        datos.CUADRA = cuadraCalzadas_txt.Text;
                        datos.LARGO = (largoCalzadas_txt.Text.Length > 0) ? double.Parse(largoCalzadas_txt.Text) : 0;
                        datos.ANCHO = (anchoCalzadas_txt.Text.Length > 0) ? double.Parse(anchoCalzadas_txt.Text) : 0;
                        datos.M = materialCalzadas_txt.Text;
                        datos.ECS = estadoConservacionCalzadas_txt.Text;
                        datos.ESPECIFICACIONES = especificacionesCalzadas_txt.Text;
                        datos.ESTADO = "A";                        
                        datos.USUARIO_MODIFICA = Usuario;
                        datos.FECHA_DE_MODIFICACION = DateTime.Now;
                        datos.FICHA = ficha_lbl.Text.Trim();
                        datos.EndEdit();
                    }
                    habilitar_movimiento_calzadas = true;
                    habilitar_controles_calzadas = false;
                    iniciar_calzadas = true;
                }
            }
            catch (Exception ex)
            {
                cancelarCalzadas_Click(sender, e);
                MessageBox.Show(ex.Message, "Error Agregar y/o Modificar, Calzadas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelarCalzadas_Click(object sender, EventArgs e)
        {
            calzadas_tc.SelectedTab = tabPage14;
            CALZADAS_bs.CancelEdit();
            habilitar_controles_calzadas = false;
            habilitar_movimiento_calzadas = true;
            iniciar_calzadas = true;
        }

        private void sectorCalzadas_txt_Leave(object sender, EventArgs e)
        {
            if (sectorCalzadas_txt.Text.Length == 2)
            {
                codigoViaCalzadas_lbl.BackColor = Color.LightBlue;
                sectorCalzadas_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage3;
                calzadas_tc.SelectedTab = tabPage14;
                codigoViaCalzadas_lbl.BackColor = Color.Red;
                sectorCalzadas_txt.Focus();
                sectorCalzadas_txt.SelectAll();
                sectorCalzadas_txt.ForeColor = Color.Red;
            }
            if (codigoViaCalzadas_lbl.BackColor == Color.Red && sectorCalzadas_txt.Enabled == false) codigoViaCalzadas_lbl.BackColor = Color.LightBlue;
        }

        private void codigoViaCalzadas_txt_Leave(object sender, EventArgs e)
        {
            int i = (codigoViaCalzadas_txt.Text.IndexOf('-') != -1) ? codigoViaCalzadas_txt.Text.IndexOf('-') : codigoViaCalzadas_txt.Text.Length + 1;
            codigoViaCalzadas_txt.Text = (codigoViaCalzadas_txt.Text.Length > 0) ? codigoViaCalzadas_txt.Text.Substring(0, i - 1) : "";
            DataRow fila = vias.Buscar(codigoViaCalzadas_txt.Text.Trim());
            if (fila == null)
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage3;
                calzadas_tc.SelectedTab = tabPage14;
                codigoViaCalzadas_lbl.BackColor = Color.Red;
                codigoViaCalzadas_txt.Focus();
                codigoViaCalzadas_txt.SelectAll();
                codigoViaCalzadas_txt.ForeColor = Color.Red;
                nombreViasCalzadas_lbl.Text = "";
            }
            else
            {
                codigoViaCalzadas_lbl.BackColor = Color.LightBlue;
                codigoViaCalzadas_txt.ForeColor = Color.Black;                
                nombreViasCalzadas_lbl.Text = fila["NOMBRE DE VIA"].ToString();
            }
            if (codigoViaCalzadas_lbl.BackColor == Color.Red && codigoViaCalzadas_txt.Enabled == false) codigoViaCalzadas_lbl.BackColor = Color.LightBlue;
        }

        private void cuadraCalzadas_txt_Leave(object sender, EventArgs e)
        {
            if (cuadraCalzadas_txt.Text.Length == 2)
            {
                codigoViaCalzadas_lbl.BackColor = Color.LightBlue;
                cuadraCalzadas_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage3;
                calzadas_tc.SelectedTab = tabPage14;
                codigoViaCalzadas_lbl.BackColor = Color.Red;
                cuadraCalzadas_txt.Focus();
                cuadraCalzadas_txt.SelectAll();
                cuadraCalzadas_txt.ForeColor = Color.Red;
            }
            if (codigoViaCalzadas_lbl.BackColor == Color.Red && cuadraCalzadas_txt.Enabled == false) codigoViaCalzadas_lbl.BackColor = Color.LightBlue;
        }

        private void largoCalzadas_txt_Leave(object sender, EventArgs e)
        {
            if (largoCalzadas_txt.Text.Length >0)
            {
                largoCalzadas_lbl.BackColor = Color.LightBlue;
                largoCalzadas_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage3;
                calzadas_tc.SelectedTab = tabPage14;
                largoCalzadas_lbl.BackColor = Color.Red;
                largoCalzadas_txt.Focus();
                largoCalzadas_txt.SelectAll();
                largoCalzadas_txt.ForeColor = Color.Red;
            }
            if (largoCalzadas_lbl.BackColor == Color.Red && largoCalzadas_txt.Enabled == false) largoCalzadas_lbl.BackColor = Color.LightBlue;
        }

        private void anchoCalzadas_txt_Leave(object sender, EventArgs e)
        {
            if (anchoCalzadas_txt.Text.Length > 0)
            {
                anchoCalzadas_lbl.BackColor = Color.LightBlue;
                anchoCalzadas_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage3;
                calzadas_tc.SelectedTab = tabPage14;
                anchoCalzadas_lbl.BackColor = Color.Red;
                anchoCalzadas_txt.Focus();
                anchoCalzadas_txt.SelectAll();
                anchoCalzadas_txt.ForeColor = Color.Red;
            }
            if (anchoCalzadas_lbl.BackColor == Color.Red && anchoCalzadas_txt.Enabled == false) anchoCalzadas_lbl.BackColor = Color.LightBlue;
        }

        private void materialCalzadas_txt_Leave(object sender, EventArgs e)
        {
            materialCalzadas_txt.Text = (materialCalzadas_txt.Text.Length > 2) ? materialCalzadas_txt.Text.Substring(0, 2) : materialCalzadas_txt.Text;
            if (buscar_material_calzadas())
            {
                materialCalzadas_lbl.BackColor = Color.LightBlue;
                materialCalzadas_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage3;
                calzadas_tc.SelectedTab = tabPage14;
                materialCalzadas_lbl.BackColor = Color.Red;
                materialCalzadas_txt.Focus();
                materialCalzadas_txt.SelectAll();
                materialCalzadas_txt.ForeColor = Color.Red;
            }
            if (materialCalzadas_lbl.BackColor == Color.Red && materialCalzadas_txt.Enabled == false) materialCalzadas_lbl.BackColor = Color.LightBlue;
        }

        private void estadoConservacionCalzadas_txt_Leave(object sender, EventArgs e)
        {
            estadoConservacionCalzadas_txt.Text = (estadoConservacionCalzadas_txt.Text.Length > 2) ? estadoConservacionCalzadas_txt.Text.Substring(0, 2) : estadoConservacionCalzadas_txt.Text;
            if (buscar_estado_conservacion_calzadas())
            {
                estadoConservacionCalzadas_lbl.BackColor = Color.LightBlue;
                estadoConservacionCalzadas_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage3;
                calzadas_tc.SelectedTab = tabPage14;
                estadoConservacionCalzadas_lbl.BackColor = Color.Red;
                estadoConservacionCalzadas_txt.Focus();
                estadoConservacionCalzadas_txt.SelectAll();
                estadoConservacionCalzadas_txt.ForeColor = Color.Red;
            }
            if (estadoConservacionCalzadas_lbl.BackColor == Color.Red && estadoConservacionCalzadas_txt.Enabled == false) estadoConservacionCalzadas_lbl.BackColor = Color.LightBlue;
        }        
        
        private void CALZADAS_dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion

        #region [ EVENTOS DE FICHA CATASTRAL DE ESPACIO DE RECREACION - VEREDAS]
        private void nuevoVeredas_Click(object sender, EventArgs e)
        {
            habilitar_movimiento_veredas = false;
            habilitar_controles_veredas = true;
            aceptarVeredas.Enabled = true;
            aceptarVeredas.Text = "Agregar Vereda";
            aceptarVeredas.Image = (Image)(resources.GetObject("aceptarVeredas.Image"));
            nuevoVeredas.Enabled = false;
            eliminarVeredas.Enabled = false;
            cancelarVeredas.Enabled = true;
            VEREDAS_bs.AddNew();
            descripcionVeredas_txt.Text = "VEREDA " + (VEREDAS_bs.Position + 1).ToString();
            descripcionVeredas_txt.Focus();
        }

        private void eliminarVeredas_Click(object sender, EventArgs e)
        {
            VEREDAS_bs.RemoveAt(VEREDAS_bs.Position);
            if (VEREDAS_dgv.RowCount == 0)
            {
                aceptarVeredas.Enabled = false;
                cancelarVeredas.Enabled = false;
                eliminarVeredas.Enabled = false;
            }
        }

        private void aceptarVeredas_Click(object sender, EventArgs e)
        {
            try
            {
                if (descripcionVeredas_txt.Text.Length ==0)
                {
                    descripcionVeredas_txt_Leave(sender, e);
                    return;
                }                
                if (areaVeredas_txt.Text.Length == 0)
                {
                    areaVeredas_txt_Leave(sender, e);
                    return;
                }
                if (!buscar_material_veredas())
                {
                    materialVeredas_txt_Leave(sender, e);
                    return;
                }
                if (!buscar_estado_conservacion_veredas())
                {
                    estadoConservacionVeredas_txt_Leave(sender, e);
                    return;
                }

                if (aceptarVeredas.Text == "Agregar Vereda")
                {
                    VEREDAS_bs.EndEdit();
                    int id = int.Parse(VEREDAS_dgv["ID", VEREDAS_dgv.CurrentRow.Index].Value.ToString());
                    FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACION_VEREDASRow datos = FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACION_VEREDAS.FindByID(id);
                    if (datos != null)
                    {
                        datos.BeginEdit();
                        datos.DESCRIPCION = descripcionVeredas_txt.Text;
                        datos.AREA = (areaVeredas_txt.Text.Length > 0) ? decimal.Parse(areaVeredas_txt.Text) : 0;
                        datos.M = materialVeredas_txt.Text;
                        datos.ECS = estadoConservacionVeredas_txt.Text;
                        datos.ESPECIFICACIONES = especificacionesVeredas_txt.Text;
                        datos.ESTADO = "A";
                        datos.USUARIO_CREA = Usuario;
                        datos.FECHA_DE_CREACION = DateTime.Now;
                        datos.USUARIO_MODIFICA = Usuario;
                        datos.FECHA_DE_MODIFICACION = DateTime.Now;
                        datos.FICHA = ficha_lbl.Text.Trim();
                        datos.EndEdit();
                    }
                    habilitar_movimiento_veredas = true;
                    habilitar_controles_veredas = false;
                    iniciar_veredas = true;
                }
                else if (aceptarVeredas.Text == "Modificar Vereda")
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage3;
                    veredas_tc.SelectedTab = tabPage16;
                    habilitar_movimiento_veredas = false;
                    habilitar_controles_veredas = true;
                    aceptarVeredas.Text = "Aceptar";
                    aceptarVeredas.Image = null;
                    nuevoVeredas.Enabled = false;
                    eliminarVeredas.Enabled = false;
                    descripcionVeredas_txt.Focus();
                }
                else if (aceptarVeredas.Text == "Aceptar")
                {
                    FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACION_VEREDASRow datos = FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACION_VEREDAS.FindByID(int.Parse(IDVeredas_lbl.Text));
                    if (datos != null)
                    {
                        datos.BeginEdit();
                        datos.DESCRIPCION = descripcionVeredas_txt.Text;
                        datos.AREA = (areaVeredas_txt.Text.Length > 0) ? decimal.Parse(areaVeredas_txt.Text) : 0;
                        datos.M = materialVeredas_txt.Text;
                        datos.ECS = estadoConservacionVeredas_txt.Text;
                        datos.ESPECIFICACIONES = especificacionesVeredas_txt.Text;
                        datos.ESTADO = "A";                        
                        datos.USUARIO_MODIFICA = Usuario;
                        datos.FECHA_DE_MODIFICACION = DateTime.Now;
                        datos.FICHA = ficha_lbl.Text.Trim();
                        datos.EndEdit();
                    }
                    habilitar_movimiento_veredas = true;
                    habilitar_controles_veredas = false;
                    iniciar_veredas = true;
                }
            }
            catch (Exception ex)
            {
                cancelarVeredas_Click(sender, e);
                MessageBox.Show(ex.Message, "Error Agregar y/o Modificar, Veredas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }

        private void cancelarVeredas_Click(object sender, EventArgs e)
        {
            veredas_tc.SelectedTab = tabPage16;
            VEREDAS_bs.CancelEdit();
            habilitar_controles_veredas = false;
            habilitar_movimiento_veredas = true;
            iniciar_veredas = true;
        }

        private void descripcionVeredas_txt_Leave(object sender, EventArgs e)
        {
            if (descripcionVeredas_txt.Text.Length > 0)
            {
                descripcionVeredas_lbl.BackColor = Color.LightBlue;
                descripcionVeredas_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage3;
                veredas_tc.SelectedTab = tabPage16;
                descripcionVeredas_lbl.BackColor = Color.Red;
                descripcionVeredas_txt.Focus();
                descripcionVeredas_txt.SelectAll();
                descripcionVeredas_txt.ForeColor = Color.Red;
            }
            if (descripcionVeredas_lbl.BackColor == Color.Red && descripcionVeredas_txt.Enabled == false) descripcionVeredas_lbl.BackColor = Color.LightBlue;
        }

        private void areaVeredas_txt_Leave(object sender, EventArgs e)
        {
            if (areaVeredas_txt.Text.Length > 0)
            {
                areaVeredas_lbl.BackColor = Color.LightBlue;
                areaVeredas_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage3;
                veredas_tc.SelectedTab = tabPage16;
                areaVeredas_lbl.BackColor = Color.Red;
                areaVeredas_txt.Focus();
                areaVeredas_txt.SelectAll();
                areaVeredas_txt.ForeColor = Color.Red;
            }
            if (areaVeredas_lbl.BackColor == Color.Red && areaVeredas_txt.Enabled == false) areaVeredas_lbl.BackColor = Color.LightBlue;
        }

        private void materialVeredas_txt_Leave(object sender, EventArgs e)
        {
            materialVeredas_txt.Text = (materialVeredas_txt.Text.Length > 2) ? materialVeredas_txt.Text.Substring(0, 2) : materialVeredas_txt.Text;
            if (buscar_material_veredas())
            {
                materialVeredas_lbl.BackColor = Color.LightBlue;
                materialVeredas_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage3;
                veredas_tc.SelectedTab = tabPage16;
                materialVeredas_lbl.BackColor = Color.Red;
                materialVeredas_txt.Focus();
                materialVeredas_txt.SelectAll();
                materialVeredas_txt.ForeColor = Color.Red;
            }
            if (materialVeredas_lbl.BackColor == Color.Red && materialVeredas_txt.Enabled == false) materialVeredas_lbl.BackColor = Color.LightBlue;
        }

        private void estadoConservacionVeredas_txt_Leave(object sender, EventArgs e)
        {
            estadoConservacionVeredas_txt.Text = (estadoConservacionVeredas_txt.Text.Length > 2) ? estadoConservacionVeredas_txt.Text.Substring(0, 2) : estadoConservacionVeredas_txt.Text;
            if (buscar_estado_conservacion_veredas())
            {
                estadoConservacionVeredas_lbl.BackColor = Color.LightBlue;
                estadoConservacionVeredas_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage3;
                veredas_tc.SelectedTab = tabPage16;
                estadoConservacionVeredas_lbl.BackColor = Color.Red;
                estadoConservacionVeredas_txt.Focus();
                estadoConservacionVeredas_txt.SelectAll();
                estadoConservacionVeredas_txt.ForeColor = Color.Red;
            }
            if (estadoConservacionVeredas_lbl.BackColor == Color.Red && estadoConservacionVeredas_txt.Enabled == false) estadoConservacionVeredas_lbl.BackColor = Color.LightBlue;
        }
        
        private void VEREDAS_dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion

        #region [ EVENTOS DE FICHA CATASTRAL DE ESPACIO DE RECREACION - COMPONENTE URBANO ]
        private void nuevoComponenteUrbano_Click(object sender, EventArgs e)
        {
            if (sector_txt.Text.Length == 2 && manzana_txt.Text.Length == 3)
            {
                habilitar_movimiento_componente_urbano = false;
                habilitar_controles_componente_urbano = true;
                aceptarComponenteUrbano.Enabled = true;
                aceptarComponenteUrbano.Text = "Agregar Componente Urbano";
                aceptarComponenteUrbano.Image = (Image)(resources.GetObject("aceptarComponenteUrbano.Image"));
                nuevoComponenteUrbano.Enabled = false;
                eliminarComponenteUrbano.Enabled = false;
                cancelarComponenteUrbano.Enabled = true;
                COMPONENTE_URBANO_bs.AddNew();
                fotografiaDigitalComponenteUrbano_pb_Click(sender, e);
            }
        }

        private void eliminarComponenteUrbano_Click(object sender, EventArgs e)
        {
            COMPONENTE_URBANO_bs.RemoveAt(COMPONENTE_URBANO_bs.Position);
            if (COMPONENTE_URBANO_dgv.RowCount == 0)
            {
                aceptarComponenteUrbano.Enabled = false;
                cancelarComponenteUrbano.Enabled = false;
                eliminarComponenteUrbano.Enabled = false;
            }
        }

        private void aceptarComponenteUrbano_Click(object sender, EventArgs e)
        {
            try
            {
                if (!buscar_tipo_componente_urbano())
                {
                    tipoComponenteUrbano_txt_Leave(sender, e);
                    return;
                }
                if (cantidadComponenteUrbano_txt.Text.Length == 0)
                {
                    cantidadComponenteUrbano_txt_Leave(sender, e);
                    return;
                }
                if (!buscar_material_componente_urbano())
                {
                    materialComponenteUrbano_txt_Leave(sender, e);
                    return;
                }
                if (!buscar_estado_conservacion_componente_urbano())
                {
                    estadoConservacionComponenteUrbano_txt_Leave(sender, e);
                    return;
                }

                if (aceptarComponenteUrbano.Text == "Agregar Componente Urbano")
                {
                    COMPONENTE_URBANO_bs.EndEdit();
                    long id = long.Parse(COMPONENTE_URBANO_dgv["ID", COMPONENTE_URBANO_dgv.CurrentRow.Index].Value.ToString());
                    FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACION_COMPONENTE_URBANORow datos = FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACION_COMPONENTE_URBANO.FindByID(id);
                    if (datos != null)
                    {
                        datos.BeginEdit();
                        datos.FOTOGRAFIA_DIGITAL = (fotografiaDigitalComponenteUrbano_pb.Image != null) ? ((fotografiaDigitalComponenteUrbano_pb.ImageLocation != null) ? File.ReadAllBytes(fotografiaDigitalComponenteUrbano_pb.ImageLocation) : cConfiguracion.toBytes(fotografiaDigitalComponenteUrbano_pb.Image)) : null;
                        datos.AÑO = (añoComponenteUrbano_txt.Text.Length == 0) ? DateTime.Now.Year.ToString() : añoComponenteUrbano_txt.Text.Trim();
                        datos.SECTOR = sector_txt.Text;
                        datos.MANZANA = manzana_txt.Text;
                        datos.LOTE = lote_txt.Text;
                        datos.TCU = tipoComponenteUrbano_txt.Text;
                        datos.CANTIDAD = (cantidadComponenteUrbano_txt.Text.Length > 0) ? int.Parse(cantidadComponenteUrbano_txt.Text) : 1;
                        datos.M = materialComponenteUrbano_txt.Text;
                        datos.ECS = estadoConservacionComponenteUrbano_txt.Text;
                        datos.ESPECIFICACIONES = especificacionesComponenteUrbano_txt.Text;
                        datos.ESTADO = "A";
                        datos.USUARIO_CREA = Usuario;
                        datos.FECHA_DE_CREACION = DateTime.Now;
                        datos.USUARIO_MODIFICA = Usuario;
                        datos.FECHA_DE_MODIFICACION = DateTime.Now;
                        datos.FICHA = ficha_lbl.Text.Trim();
                        datos.EndEdit();
                    }
                    habilitar_movimiento_componente_urbano = true;
                    habilitar_controles_componente_urbano = false;
                    iniciar_componente_urbano = true;
                }
                else if (aceptarComponenteUrbano.Text == "Modificar Componente Urbano")
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage5;
                    componente_urbano_tc.SelectedTab = tabPage10;
                    habilitar_movimiento_componente_urbano = false;
                    habilitar_controles_componente_urbano = true;
                    aceptarComponenteUrbano.Text = "Aceptar";
                    aceptarComponenteUrbano.Image = null;
                    nuevoComponenteUrbano.Enabled = false;
                    eliminarComponenteUrbano.Enabled = false;
                    añoComponenteUrbano_txt.Focus();
                }
                else if (aceptarComponenteUrbano.Text == "Aceptar")
                {
                    FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACION_COMPONENTE_URBANORow datos = FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACION_COMPONENTE_URBANO.FindByID(long.Parse(IDComponenteUrbano_lbl.Text));
                    if (datos != null)
                    {
                        datos.BeginEdit();
                        datos.FOTOGRAFIA_DIGITAL = (fotografiaDigitalComponenteUrbano_pb.Image != null) ? ((fotografiaDigitalComponenteUrbano_pb.ImageLocation != null) ? File.ReadAllBytes(fotografiaDigitalComponenteUrbano_pb.ImageLocation) : cConfiguracion.toBytes(fotografiaDigitalComponenteUrbano_pb.Image)) : null;
                        datos.AÑO = (añoComponenteUrbano_txt.Text.Length == 0) ? DateTime.Now.Year.ToString() : añoComponenteUrbano_txt.Text.Trim();
                        datos.SECTOR = sector_txt.Text;
                        datos.MANZANA = manzana_txt.Text;
                        datos.LOTE = lote_txt.Text;
                        datos.TCU = tipoComponenteUrbano_txt.Text;
                        datos.CANTIDAD = (cantidadComponenteUrbano_txt.Text.Length > 0) ? int.Parse(cantidadComponenteUrbano_txt.Text) : 1;
                        datos.M = materialComponenteUrbano_txt.Text;
                        datos.ECS = estadoConservacionComponenteUrbano_txt.Text;
                        datos.ESPECIFICACIONES = especificacionesComponenteUrbano_txt.Text;
                        datos.ESTADO = "A";
                        datos.USUARIO_MODIFICA = Usuario;
                        datos.FECHA_DE_MODIFICACION = DateTime.Now;
                        datos.FICHA = ficha_lbl.Text.Trim();
                        datos.EndEdit();
                    }
                    habilitar_movimiento_componente_urbano = true;
                    habilitar_controles_componente_urbano = false;
                    iniciar_componente_urbano = true;
                }
            }
            catch (Exception ex)
            {
                cancelarComponenteUrbano_Click(sender, e);
                MessageBox.Show(ex.Message, "Error Agregar y/o Modificar, Componente Urbano", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelarComponenteUrbano_Click(object sender, EventArgs e)
        {
            componente_urbano_tc.SelectedTab = tabPage10;
            COMPONENTE_URBANO_bs.CancelEdit();
            habilitar_controles_componente_urbano = false;
            habilitar_movimiento_componente_urbano = true;
            iniciar_componente_urbano = true;
        }

        private void fotografiaDigitalComponenteUrbano_pb_Click(object sender, EventArgs e)
        {
            if (sector_txt.Text.Length == 2 && manzana_txt.Text.Length == 3)
            {
                DialogResult rpta = AbrirFotografia.ShowDialog();
                if (rpta == DialogResult.OK)
                {
                    fotografiaDigitalComponenteUrbano_pb.ImageLocation = AbrirFotografia.FileName;
                    sectorComponenteUrbano_lbl.Text = sector_txt.Text;
                    manzanaComponenteUrbano_lbl.Text = manzana_txt.Text;
                    loteComponenteUrbano_lbl.Text = lote_txt.Text;
                    añoComponenteUrbano_txt.Text = DateTime.Now.Year.ToString();
                }
                else
                {
                    fotografiaDigitalComponenteUrbano_pb.ImageLocation = "";
                    sectorComponenteUrbano_lbl.Text = "";
                    manzanaComponenteUrbano_lbl.Text = "";
                    loteComponenteUrbano_lbl.Text = "";
                    añoComponenteUrbano_txt.Text = "";
                }
                añoComponenteUrbano_txt.Focus();
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage1;
                if (sector_txt.Text.Length == 0) sector_txt.Focus();
                if (manzana_txt.Text.Length == 0) manzana_txt.Focus();                
            }
        }

        private void añoComponenteUrbano_txt_Leave(object sender, EventArgs e)
        {
            if (añoComponenteUrbano_txt.Text.Length == 4 || añoComponenteUrbano_txt.Text.Length == 0)
            {
                añoComponenteUrbano_lbl.BackColor = Color.LightBlue;
                añoComponenteUrbano_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage5;
                componente_urbano_tc.SelectedTab = tabPage10;
                añoComponenteUrbano_lbl.BackColor = Color.Red;
                añoComponenteUrbano_txt.Focus();
                añoComponenteUrbano_txt.SelectAll();
                añoComponenteUrbano_txt.ForeColor = Color.Red;
            }
            if (añoComponenteUrbano_lbl.BackColor == Color.Red && añoComponenteUrbano_txt.Enabled == false) añoComponenteUrbano_lbl.BackColor = Color.LightBlue;
        }

        private void tipoComponenteUrbano_txt_Leave(object sender, EventArgs e)
        {
            tipoComponenteUrbano_txt.Text = (tipoComponenteUrbano_txt.Text.Length > 2) ? tipoComponenteUrbano_txt.Text.Substring(0, 2) : tipoComponenteUrbano_txt.Text;
            if (buscar_tipo_componente_urbano())
            {
                tipoComponenteUrbano_lbl.BackColor = Color.LightBlue;
                tipoComponenteUrbano_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage5;
                componente_urbano_tc.SelectedTab = tabPage10;
                tipoComponenteUrbano_lbl.BackColor = Color.Red;
                tipoComponenteUrbano_txt.Focus();
                tipoComponenteUrbano_txt.SelectAll();
                tipoComponenteUrbano_txt.ForeColor = Color.Red;
            }
            if (tipoComponenteUrbano_lbl.BackColor == Color.Red && tipoComponenteUrbano_txt.Enabled == false) tipoComponenteUrbano_lbl.BackColor = Color.LightBlue;
        }

        private void cantidadComponenteUrbano_txt_Leave(object sender, EventArgs e)
        {
            if (cantidadComponenteUrbano_txt.Text.Length > 0)
            {
                cantidadComponenteUrbano_lbl.BackColor = Color.LightBlue;
                cantidadComponenteUrbano_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage5;
                componente_urbano_tc.SelectedTab = tabPage10;
                cantidadComponenteUrbano_lbl.BackColor = Color.Red;
                cantidadComponenteUrbano_txt.Focus();
                cantidadComponenteUrbano_txt.SelectAll();
                cantidadComponenteUrbano_txt.ForeColor = Color.Red;
            }
            if (cantidadComponenteUrbano_lbl.BackColor == Color.Red && cantidadComponenteUrbano_txt.Enabled == false) cantidadComponenteUrbano_lbl.BackColor = Color.LightBlue;
        }

        private void materialComponenteUrbano_txt_Leave(object sender, EventArgs e)
        {
            materialComponenteUrbano_txt.Text = (materialComponenteUrbano_txt.Text.Length > 2) ? materialComponenteUrbano_txt.Text.Substring(0, 2) : materialComponenteUrbano_txt.Text;
            if (buscar_material_componente_urbano())
            {
                materialComponenteUrbano_lbl.BackColor = Color.LightBlue;
                materialComponenteUrbano_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage5;
                componente_urbano_tc.SelectedTab = tabPage10;
                materialComponenteUrbano_lbl.BackColor = Color.Red;
                materialComponenteUrbano_txt.Focus();
                materialComponenteUrbano_txt.SelectAll();
                materialComponenteUrbano_txt.ForeColor = Color.Red;
            }
            if (materialComponenteUrbano_lbl.BackColor == Color.Red && materialComponenteUrbano_txt.Enabled == false) materialComponenteUrbano_lbl.BackColor = Color.LightBlue;
        }

        private void estadoConservacionComponenteUrbano_txt_Leave(object sender, EventArgs e)
        {
            estadoConservacionComponenteUrbano_txt.Text = (estadoConservacionComponenteUrbano_txt.Text.Length > 2) ? estadoConservacionComponenteUrbano_txt.Text.Substring(0, 2) : estadoConservacionComponenteUrbano_txt.Text;
            if (buscar_estado_conservacion_componente_urbano())
            {
                estadoConservacionComponenteUrbano_lbl.BackColor = Color.LightBlue;
                estadoConservacionComponenteUrbano_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage5;
                componente_urbano_tc.SelectedTab = tabPage10;
                estadoConservacionComponenteUrbano_lbl.BackColor = Color.Red;
                estadoConservacionComponenteUrbano_txt.Focus();
                estadoConservacionComponenteUrbano_txt.SelectAll();
                estadoConservacionComponenteUrbano_txt.ForeColor = Color.Red;
            }
            if (estadoConservacionComponenteUrbano_lbl.BackColor == Color.Red && estadoConservacionComponenteUrbano_txt.Enabled == false) estadoConservacionComponenteUrbano_lbl.BackColor = Color.LightBlue;
        }

        private void COMPONENTE_URBANO_dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion

        #region [ EVENTOS DE FICHA CATASTRAL DE ESPACIO DE RECREACION - COMPONENTE URBANO ]
        private void nuevoMobiliarioUrbano_Click(object sender, EventArgs e)
        {
            if (sector_txt.Text.Length == 2 && manzana_txt.Text.Length == 3)
            {
                habilitar_movimiento_mobiliario_urbano = false;
                habilitar_controles_mobiliario_urbano = true;
                aceptarMobiliarioUrbano.Enabled = true;
                aceptarMobiliarioUrbano.Text = "Agregar Mobiliario Urbano";
                aceptarMobiliarioUrbano.Image = (Image)(resources.GetObject("aceptarMobiliarioUrbano.Image"));
                nuevoMobiliarioUrbano.Enabled = false;
                eliminarMobiliarioUrbano.Enabled = false;
                cancelarMobiliarioUrbano.Enabled = true;
                MOBILIARIO_URBANO_bs.AddNew();
                fotografiaDigitalMobiliarioUrbano_pb_Click(sender, e);
            }
        }

        private void eliminarMobiliarioUrbano_Click(object sender, EventArgs e)
        {
            MOBILIARIO_URBANO_bs.RemoveAt(MOBILIARIO_URBANO_bs.Position);
            if (MOBILIARIO_URBANO_dgv.RowCount == 0)
            {
                aceptarMobiliarioUrbano.Enabled = false;
                cancelarMobiliarioUrbano.Enabled = false;
                eliminarMobiliarioUrbano.Enabled = false;
            }
        }

        private void aceptarMobiliarioUrbano_Click(object sender, EventArgs e)
        {
            try
            {
                if (!buscar_tipo_mobiliario_urbano())
                {
                    tipoMobiliarioUrbano_txt_Leave(sender, e);
                    return;
                }
                if (cantidadMobiliarioUrbano_txt.Text.Length == 0)
                {
                    cantidadMobiliarioUrbano_txt_Leave(sender, e);
                    return;
                }
                if (!buscar_material_mobiliario_urbano())
                {
                    materialMobiliarioUrbano_txt_Leave(sender, e);
                    return;
                }
                if (!buscar_estado_conservacion_mobiliario_urbano())
                {
                    estadoConservacionMobiliarioUrbano_txt_Leave(sender, e);
                    return;
                }

                if (aceptarMobiliarioUrbano.Text == "Agregar Mobiliario Urbano")
                {
                    MOBILIARIO_URBANO_bs.EndEdit();
                    long id = long.Parse(MOBILIARIO_URBANO_dgv["ID", MOBILIARIO_URBANO_dgv.CurrentRow.Index].Value.ToString());
                    FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACION_MOBILIARIO_URBANORow datos = FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACION_MOBILIARIO_URBANO.FindByID(id);
                    if (datos != null)
                    {
                        datos.BeginEdit();
                        datos.FOTOGRAFIA_DIGITAL = (fotografiaDigitalMobiliarioUrbano_pb.Image != null) ? ((fotografiaDigitalMobiliarioUrbano_pb.ImageLocation != null) ? File.ReadAllBytes(fotografiaDigitalMobiliarioUrbano_pb.ImageLocation) : cConfiguracion.toBytes(fotografiaDigitalMobiliarioUrbano_pb.Image)) : null;
                        datos.AÑO = (añoMobiliarioUrbano_txt.Text.Length == 0) ? DateTime.Now.Year.ToString() : añoMobiliarioUrbano_txt.Text.Trim();
                        datos.SECTOR = sector_txt.Text;
                        datos.MANZANA = manzana_txt.Text;
                        datos.LOTE = lote_txt.Text;
                        datos.TMU = tipoMobiliarioUrbano_txt.Text;
                        datos.CANTIDAD = (cantidadMobiliarioUrbano_txt.Text.Length > 0) ? int.Parse(cantidadMobiliarioUrbano_txt.Text) : 1;
                        datos.M = materialMobiliarioUrbano_txt.Text;
                        datos.ECS = estadoConservacionMobiliarioUrbano_txt.Text;
                        datos.ESPECIFICACIONES = especificacionesMobiliarioUrbano_txt.Text;
                        datos.ESTADO = "A";
                        datos.USUARIO_CREA = Usuario;
                        datos.FECHA_DE_CREACION = DateTime.Now;
                        datos.USUARIO_MODIFICA = Usuario;
                        datos.FECHA_DE_MODIFICACION = DateTime.Now;
                        datos.FICHA = ficha_lbl.Text.Trim();
                        datos.EndEdit();
                    }
                    habilitar_movimiento_mobiliario_urbano = true;
                    habilitar_controles_mobiliario_urbano = false;
                    iniciar_mobiliario_urbano = true;
                }
                else if (aceptarMobiliarioUrbano.Text == "Modificar Mobiliario Urbano")
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage6;
                    mobiliario_urbano_tc.SelectedTab = tabPage12;
                    habilitar_movimiento_mobiliario_urbano = false;
                    habilitar_controles_mobiliario_urbano = true;
                    aceptarMobiliarioUrbano.Text = "Aceptar";
                    aceptarMobiliarioUrbano.Image = null;
                    nuevoMobiliarioUrbano.Enabled = false;
                    eliminarMobiliarioUrbano.Enabled = false;
                    añoMobiliarioUrbano_txt.Focus();
                }
                else if (aceptarMobiliarioUrbano.Text == "Aceptar")
                {
                    FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACION_MOBILIARIO_URBANORow datos = FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_ESPACIO_RECREACION_MOBILIARIO_URBANO.FindByID(long.Parse(IDMobiliarioUrbano_lbl.Text));
                    if (datos != null)
                    {
                        datos.BeginEdit();
                        datos.FOTOGRAFIA_DIGITAL = (fotografiaDigitalMobiliarioUrbano_pb.Image != null) ? ((fotografiaDigitalMobiliarioUrbano_pb.ImageLocation != null) ? File.ReadAllBytes(fotografiaDigitalMobiliarioUrbano_pb.ImageLocation) : cConfiguracion.toBytes(fotografiaDigitalMobiliarioUrbano_pb.Image)) : null;
                        datos.AÑO = (añoMobiliarioUrbano_txt.Text.Length == 0) ? DateTime.Now.Year.ToString() : añoMobiliarioUrbano_txt.Text.Trim();
                        datos.SECTOR = sector_txt.Text;
                        datos.MANZANA = manzana_txt.Text;
                        datos.LOTE = lote_txt.Text;
                        datos.TMU = tipoMobiliarioUrbano_txt.Text;
                        datos.CANTIDAD = (cantidadMobiliarioUrbano_txt.Text.Length > 0) ? int.Parse(cantidadMobiliarioUrbano_txt.Text) : 1;
                        datos.M = materialMobiliarioUrbano_txt.Text;
                        datos.ECS = estadoConservacionMobiliarioUrbano_txt.Text;
                        datos.ESPECIFICACIONES = especificacionesMobiliarioUrbano_txt.Text;
                        datos.ESTADO = "A";
                        datos.USUARIO_MODIFICA = Usuario;
                        datos.FECHA_DE_MODIFICACION = DateTime.Now;
                        datos.FICHA = ficha_lbl.Text.Trim();
                        datos.EndEdit();
                    }
                    habilitar_movimiento_mobiliario_urbano = true;
                    habilitar_controles_mobiliario_urbano = false;
                    iniciar_mobiliario_urbano = true;
                }
            }
            catch (Exception ex)
            {
                cancelarMobiliarioUrbano_Click(sender, e);
                MessageBox.Show(ex.Message, "Error Agregar y/o Modificar, Mobiliario Urbano", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelarMobiliarioUrbano_Click(object sender, EventArgs e)
        {
            mobiliario_urbano_tc.SelectedTab = tabPage12;
            MOBILIARIO_URBANO_bs.CancelEdit();
            habilitar_controles_mobiliario_urbano = false;
            habilitar_movimiento_mobiliario_urbano = true;
            iniciar_mobiliario_urbano = true;
        }

        private void fotografiaDigitalMobiliarioUrbano_pb_Click(object sender, EventArgs e)
        {
            if (sector_txt.Text.Length == 2 && manzana_txt.Text.Length == 3)
            {
                DialogResult rpta = AbrirFotografia.ShowDialog();
                if (rpta == DialogResult.OK)
                {
                    fotografiaDigitalMobiliarioUrbano_pb.ImageLocation = AbrirFotografia.FileName;
                    sectorMobiliarioUrbano_lbl.Text = sector_txt.Text;
                    manzanaMobiliarioUrbano_lbl.Text = manzana_txt.Text;
                    loteMobiliarioUrbano_lbl.Text = lote_txt.Text;
                    añoMobiliarioUrbano_txt.Text = DateTime.Now.Year.ToString();
                }
                else
                {
                    fotografiaDigitalMobiliarioUrbano_pb.ImageLocation = "";
                    sectorMobiliarioUrbano_lbl.Text = "";
                    manzanaMobiliarioUrbano_lbl.Text = "";
                    loteMobiliarioUrbano_lbl.Text = "";
                    añoMobiliarioUrbano_txt.Text = "";
                }
                añoMobiliarioUrbano_txt.Focus();
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage1;
                if (sector_txt.Text.Length == 0) sector_txt.Focus();
                if (manzana_txt.Text.Length == 0) manzana_txt.Focus();                
            }
        }

        private void añoMobiliarioUrbano_txt_Leave(object sender, EventArgs e)
        {
            if (añoMobiliarioUrbano_txt.Text.Length == 4 || añoMobiliarioUrbano_txt.Text.Length == 0)
            {
                añoMobiliarioUrbano_lbl.BackColor = Color.LightBlue;
                añoMobiliarioUrbano_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage6;
                mobiliario_urbano_tc.SelectedTab = tabPage12;
                añoMobiliarioUrbano_lbl.BackColor = Color.Red;
                añoMobiliarioUrbano_txt.Focus();
                añoMobiliarioUrbano_txt.SelectAll();
                añoMobiliarioUrbano_txt.ForeColor = Color.Red;
            }
            if (añoMobiliarioUrbano_lbl.BackColor == Color.Red && añoMobiliarioUrbano_txt.Enabled == false) añoMobiliarioUrbano_lbl.BackColor = Color.LightBlue;
        }

        private void tipoMobiliarioUrbano_txt_Leave(object sender, EventArgs e)
        {
            tipoMobiliarioUrbano_txt.Text = (tipoMobiliarioUrbano_txt.Text.Length > 2) ? tipoMobiliarioUrbano_txt.Text.Substring(0, 2) : tipoMobiliarioUrbano_txt.Text;
            if (buscar_tipo_mobiliario_urbano())
            {
                tipoMobiliarioUrbano_lbl.BackColor = Color.LightBlue;
                tipoMobiliarioUrbano_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage6;
                mobiliario_urbano_tc.SelectedTab = tabPage12;
                tipoMobiliarioUrbano_lbl.BackColor = Color.Red;
                tipoMobiliarioUrbano_txt.Focus();
                tipoMobiliarioUrbano_txt.SelectAll();
                tipoMobiliarioUrbano_txt.ForeColor = Color.Red;
            }
            if (tipoMobiliarioUrbano_lbl.BackColor == Color.Red && tipoMobiliarioUrbano_txt.Enabled == false) tipoMobiliarioUrbano_lbl.BackColor = Color.LightBlue;
        }

        private void cantidadMobiliarioUrbano_txt_Leave(object sender, EventArgs e)
        {
            if (cantidadMobiliarioUrbano_txt.Text.Length > 0)
            {
                cantidadMobiliarioUrbano_lbl.BackColor = Color.LightBlue;
                cantidadMobiliarioUrbano_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage6;
                mobiliario_urbano_tc.SelectedTab = tabPage12;
                cantidadMobiliarioUrbano_lbl.BackColor = Color.Red;
                cantidadMobiliarioUrbano_txt.Focus();
                cantidadMobiliarioUrbano_txt.SelectAll();
                cantidadMobiliarioUrbano_txt.ForeColor = Color.Red;
            }
            if (cantidadMobiliarioUrbano_lbl.BackColor == Color.Red && cantidadMobiliarioUrbano_txt.Enabled == false) cantidadMobiliarioUrbano_lbl.BackColor = Color.LightBlue;
        }

        private void materialMobiliarioUrbano_txt_Leave(object sender, EventArgs e)
        {
            materialMobiliarioUrbano_txt.Text = (materialMobiliarioUrbano_txt.Text.Length > 2) ? materialMobiliarioUrbano_txt.Text.Substring(0, 2) : materialMobiliarioUrbano_txt.Text;
            if (buscar_material_mobiliario_urbano())
            {
                materialMobiliarioUrbano_lbl.BackColor = Color.LightBlue;
                materialMobiliarioUrbano_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage6;
                mobiliario_urbano_tc.SelectedTab = tabPage12;
                materialMobiliarioUrbano_lbl.BackColor = Color.Red;
                materialMobiliarioUrbano_txt.Focus();
                materialMobiliarioUrbano_txt.SelectAll();
                materialMobiliarioUrbano_txt.ForeColor = Color.Red;
            }
            if (materialMobiliarioUrbano_lbl.BackColor == Color.Red && materialMobiliarioUrbano_txt.Enabled == false) materialMobiliarioUrbano_lbl.BackColor = Color.LightBlue;
        }

        private void estadoConservacionMobiliarioUrbano_txt_Leave(object sender, EventArgs e)
        {
            estadoConservacionMobiliarioUrbano_txt.Text = (estadoConservacionMobiliarioUrbano_txt.Text.Length > 2) ? estadoConservacionMobiliarioUrbano_txt.Text.Substring(0, 2) : estadoConservacionMobiliarioUrbano_txt.Text;
            if (buscar_estado_conservacion_mobiliario_urbano())
            {
                estadoConservacionMobiliarioUrbano_lbl.BackColor = Color.LightBlue;
                estadoConservacionMobiliarioUrbano_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage6;
                mobiliario_urbano_tc.SelectedTab = tabPage12;
                estadoConservacionMobiliarioUrbano_lbl.BackColor = Color.Red;
                estadoConservacionMobiliarioUrbano_txt.Focus();
                estadoConservacionMobiliarioUrbano_txt.SelectAll();
                estadoConservacionMobiliarioUrbano_txt.ForeColor = Color.Red;
            }
            if (estadoConservacionMobiliarioUrbano_lbl.BackColor == Color.Red && estadoConservacionMobiliarioUrbano_txt.Enabled == false) estadoConservacionMobiliarioUrbano_lbl.BackColor = Color.LightBlue;
        }

        private void MOBILIARIO_URBANO_dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion
        #endregion
    }
}
