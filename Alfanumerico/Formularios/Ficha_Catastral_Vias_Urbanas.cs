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

namespace Formularios
{
    /// <summary>
    /// Autor                   : Luis Amos - Dunia
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    internal partial class Ficha_Catastral_Vias_Urbanas : Ficha
    {
        internal Ficha_Catastral_Vias_Urbanas()
        {
            InitializeComponent();
            //Ficha Catastral de Vías Urbanas
            this.Load += new System.EventHandler(this.listar_Load);
            nuevo_tsb.Click += new EventHandler(nuevo_tsb_Click);
            aceptar_tsb.Click += new EventHandler(aceptar_tsb_Click);
            eliminar_tsb.Click += new EventHandler(eliminar_tsb_Click);
            cancelar_tsb.Click += new EventHandler(cancelar_tsb_Click);
            vistaPrevia_tsb.Click += new EventHandler(vistaPrevia_tsb_Click);
            this.FormClosing += new FormClosingEventHandler(cerrar_FormClosing);
            FICHA_bs.DataSourceChanged += new EventHandler(FICHA_bs_PositionChanged);
            FICHA_bs.PositionChanged += new EventHandler(FICHA_bs_PositionChanged);
            invertir_btn.Click += new EventHandler(invertir_btn_Click);
            supervisor_lbl.BindingContextChanged += new EventHandler(this.supervisor_lbl_BindingContextChanged);
            tecnicoCatastral_lbl.BindingContextChanged += new EventHandler(tecnicoCatastral_lbl_BindingContextChanged);
            digitalizacion_lbl.BindingContextChanged += new EventHandler(digitalizacion_lbl_BindingContextChanged);
            parcialFichas_txt.Leave += new EventHandler(parcialFichas_txt_Leave);
            totalFichas_txt.Leave += new EventHandler(totalFichas_txt_Leave);
            sector_txt.Leave += new EventHandler(sector_txt_Leave);
            codigoVia_txt.Leave += new EventHandler(codigoVia_txt_Leave);
            cuadra_txt.Leave += new EventHandler(cuadra_txt_Leave);
            numeroCuadras_txt.Leave += new EventHandler(numeroCuadras_txt_Leave);
            estadoGeneralVia_txt.Leave += new EventHandler(estadoGeneralVia_txt_Leave);
            limite_txt.Leave += new EventHandler(limite_txt_Leave);
            condicionLimite_txt.Leave += new EventHandler(condicionLimite_txt_Leave);
            codigoHabilitacionUrbana_txt.Leave += new EventHandler(codigoHabilitacionUrbana_txt_Leave);
            //Calzada
            calzadaCarril1Material_txt.Leave += new EventHandler(material_Leave);
            calzadaCarril2Material_txt.Leave += new EventHandler(material_Leave);
            calzadaCarril3Material_txt.Leave += new EventHandler(material_Leave);
            calzadaCarril4Material_txt.Leave += new EventHandler(material_Leave);
            calzadaCarril1EstadoConservacion_txt.Leave += new EventHandler(estadoConservacion_Leave);
            calzadaCarril2EstadoConservacion_txt.Leave += new EventHandler(estadoConservacion_Leave);
            calzadaCarril3EstadoConservacion_txt.Leave += new EventHandler(estadoConservacion_Leave);
            calzadaCarril4EstadoConservacion_txt.Leave += new EventHandler(estadoConservacion_Leave);
            //Vereda
            veredaDerechaMaterial_txt.Leave += new EventHandler(material_Leave);
            veredaIzquierdaMaterial_txt.Leave += new EventHandler(material_Leave);
            veredaCentralMaterial_txt.Leave += new EventHandler(material_Leave);
            veredaDerechaEstadoConservacion_txt.Leave += new EventHandler(estadoConservacion_Leave);
            veredaIzquierdaEstadoConservacion_txt.Leave += new EventHandler(estadoConservacion_Leave);
            veredaCentralEstadoConservacion_txt.Leave += new EventHandler(estadoConservacion_Leave);
            //Ciclo Via
            cicloViaDerechaMaterial_txt.Leave += new EventHandler(material_Leave);
            cicloViaIzquierdaMaterial_txt.Leave += new EventHandler(material_Leave);
            cicloViaCentralMaterial_txt.Leave += new EventHandler(material_Leave);
            cicloViaDerechaEstadoConservacion_txt.Leave += new EventHandler(estadoConservacion_Leave);
            cicloViaIzquierdaEstadoConservacion_txt.Leave += new EventHandler(estadoConservacion_Leave);
            cicloViaCentralEstadoConservacion_txt.Leave += new EventHandler(estadoConservacion_Leave);
            //Via Ferrea
            viaFerreaDerechaMaterial_txt.Leave += new EventHandler(material_Leave);
            viaFerreaIzquierdaMaterial_txt.Leave += new EventHandler(material_Leave);
            viaFerreaCentralMaterial_txt.Leave += new EventHandler(material_Leave);
            viaFerreaDerechaEstadoConservacion_txt.Leave += new EventHandler(estadoConservacion_Leave);
            viaFerreaIzquierdaEstadoConservacion_txt.Leave += new EventHandler(estadoConservacion_Leave);
            viaFerreaCentralEstadoConservacion_txt.Leave += new EventHandler(estadoConservacion_Leave);
            //Berma
            bermaDerechaEstadoConservacion_txt.Leave += new EventHandler(estadoConservacion_Leave);
            bermaIzquierdaEstadoConservacion_txt.Leave += new EventHandler(estadoConservacion_Leave);
            bermaCentralEstadoConservacion_txt.Leave += new EventHandler(estadoConservacion_Leave);
            //Estado de Conservación
            estadoLlenadoFicha_txt.Leave += new EventHandler(estadoLlenadoFicha_txt_Leave);

            //Fotografía
            nuevoFotografia.Click += new EventHandler(nuevoFotografia_Click);
            eliminarFotografia.Click += new EventHandler(eliminarFotografia_Click);
            aceptarFotografia.Click += new EventHandler(aceptarFotografia_Click);
            cancelarFotografia.Click += new EventHandler(cancelarFotografia_Click);
            planoVia_pb.Click += new EventHandler(planoVia_pb_Click);
            añoPlanoVia_txt.Leave += new EventHandler(añoPlanoVia_txt_Leave);
            seccionTipicaVia_pb.Click += new EventHandler(seccionTipicaVia_pb_Click);
            seccion_txt.Leave += new EventHandler(seccion_txt_Leave);
            fotografiaDigital_pb.Click += new EventHandler(fotografiaDigital_pb_Click);
            añoFotografiaDigital_txt.Leave += new EventHandler(añoFotografiaDigital_txt_Leave);
            FOTOGRAFIA_dgv.DataError += new DataGridViewDataErrorEventHandler(FOTOGRAFIA_dgv_DataError);

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
        ComponentResourceManager resources = new ComponentResourceManager(typeof(Ficha_Catastral_Vias_Urbanas));
        cSector_Manzana_Lotes sector_manzana_lote = new cSector_Manzana_Lotes();
        //Ficha Catastral de Vías Urbanas
        cVias vias = new cVias();
        cEstado_General_Via estado_general_via = new cEstado_General_Via();
        cLimite limite = new cLimite();
        cCondicion_Limite condicion_limite = new cCondicion_Limite();
        cHabilitacion_Urbana habilitacion_urbana = new cHabilitacion_Urbana();
        cMaterial material = new cMaterial();
        cEstado_Conservacion estado_conservacion = new cEstado_Conservacion();
        cEstado_Llenado_Ficha estado_llenado_ficha = new cEstado_Llenado_Ficha();
        cPersonal supervisor = new cPersonal();
        cPersonal tecnico_catastral = new cPersonal();
        cPersonal digitacion = new cPersonal();
        //Mobiliario y Componente Urbano
        cTipo_Componente_Urbano tipo_componente_urbano = new cTipo_Componente_Urbano();
        cTipo_Mobiliario_Urbano tipo_mobiliario_urbano = new cTipo_Mobiliario_Urbano();
        cMaterial_Componente_Urbano_Mobiliario_Urbano material_componente_urbano_mobiliario_urbano = new cMaterial_Componente_Urbano_Mobiliario_Urbano();
        #endregion

        #region Propiedades
        #region [ PROPIEDADES DE FICHA CATASTRAL DE VIAS URBANAS ]
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
                FICHA_dgv.Enabled = !value;
                categoria_tsc.Enabled = !value;
                buscar_tst.Enabled = !value;

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
                return total == 0 && sector_txt.Text.Length == 2 && codigoVia_txt.Text.Length == 3 && cuadra_txt.Text.Length == 2
                 && ((aceptarFotografia.ForeColor != Color.Red) ? true : false) && ((aceptarComponenteUrbano.ForeColor != Color.Red) ? true : false) && ((aceptarMobiliarioUrbano.ForeColor != Color.Red) ? true : false);
            }
        }
        #endregion

        #region [ PROPIEDADES DE FICHA CATASTRAL DE VIAS URBANAS - FOTOGRAFIA ]
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
            get { return añoPlanoVia_txt.Enabled; }
            set
            {
                planoVia_pb.Enabled = value;
                sectorPlanoVia_lbl.Enabled = value;
                codigoViaPlanoVia_lbl.Enabled = value;
                cuadraPlanoVia_lbl.Enabled = value;
                añoPlanoVia_txt.Enabled = value;
                seccionTipicaVia_pb.Enabled = value;
                seccion_txt.Enabled = value;
                fotografiaDigital_pb.Enabled = value;
                sectorFotografiaDigital_lbl.Enabled = value;
                codigoViaFotografiaDigital_lbl.Enabled = value;
                cuadraFotografiaDigital_lbl.Enabled = value;
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

        #region [ PROPIEDADES DE FICHA CATASTRAL DE VIAS URBANAS - COMPONENTE URBANO ]
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
                codigoViaComponenteUrbano_lbl.Enabled = value;
                cuadraComponenteUrbano_lbl.Enabled = value;
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

        #region [ PROPIEDADES DE FICHA CATASTRAL DE VIAS URBANAS - MOBILIARIO URBANO ]
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
                codigoViaMobiliarioUrbano_lbl.Enabled = value;
                cuadraMobiliarioUrbano_lbl.Enabled = value;
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
        #region [ METODOS DE FICHA CATASTRAL DE VIAS URBANAS ]
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
            //Ficha Catastral de Vías Urbanas
            cFicha_Catastral_Vias_Urbanas ficha_catastral_vias_urbanas = new cFicha_Catastral_Vias_Urbanas();
            FICHA_ds = ficha_catastral_vias_urbanas.listar();
            base.refrescar();
            this.FICHA_bs.DataMember = "VS_LISTAR_FICHA_CATASTRAL_VIAS_URBANAS";
            this.FICHA_bs.DataSource = FICHA_ds;

            //Fotografia
            this.FOTOGRAFIA_bn.BindingSource = FOTOGRAFIA_bs;
            this.FOTOGRAFIA_dgv.DataSource = FOTOGRAFIA_bs;
            this.FOTOGRAFIA_bs.DataMember = "VIAS_URBANAS_FK_FOTOGRAFIA";
            this.FOTOGRAFIA_bs.DataSource = FICHA_bs;

            //Componente Urbano
            this.COMPONENTE_URBANO_bn.BindingSource = COMPONENTE_URBANO_bs;
            this.COMPONENTE_URBANO_dgv.DataSource = COMPONENTE_URBANO_bs;
            this.COMPONENTE_URBANO_bs.DataMember = "VIAS_URBANAS_FK_COMPONENTE_URBANO";
            this.COMPONENTE_URBANO_bs.DataSource = FICHA_bs;

            //Mobiliario Urbano
            this.MOBILIARIO_URBANO_bn.BindingSource = MOBILIARIO_URBANO_bs;
            this.MOBILIARIO_URBANO_dgv.DataSource = MOBILIARIO_URBANO_bs;
            this.MOBILIARIO_URBANO_bs.DataMember = "VIAS_URBANAS_FK_MOBILIARIO_URBANO";
            this.MOBILIARIO_URBANO_bs.DataSource = FICHA_bs;
        }
        void guardar()
        {
            if (validar)
            {
                cFicha_Catastral_Vias_Urbanas ficha_catastral_vias_urbanas = new cFicha_Catastral_Vias_Urbanas();
                ficha_catastral_vias_urbanas.Ficha = ficha_lbl.Text.Trim();
                ficha_catastral_vias_urbanas.Parcial_Ficha = parcialFichas_txt.Text;
                ficha_catastral_vias_urbanas.Total_Fichas = totalFichas_txt.Text;
                ficha_catastral_vias_urbanas.Departamento = departamento_lbl.Text;
                ficha_catastral_vias_urbanas.Provincia = provincia_lbl.Text;
                ficha_catastral_vias_urbanas.Distrito = distrito_lbl.Text;
                ficha_catastral_vias_urbanas.Sector = sector_txt.Text;
                //Vias
                vias.Codigo = codigoVia_txt.Text;
                ficha_catastral_vias_urbanas.Vias = vias;
                //
                ficha_catastral_vias_urbanas.Cuadra = cuadra_txt.Text;
                ficha_catastral_vias_urbanas.Numero_Cuadras = numeroCuadras_txt.Text;
                //Estado General de la Via
                estado_general_via.Codigo = (estadoGeneralVia_txt.Text.Length > 0) ? estadoGeneralVia_txt.Text : null;
                ficha_catastral_vias_urbanas.Estado_General_Via = estado_general_via;
                //Limite
                limite.Codigo = (limite_txt.Text.Length > 0) ? limite_txt.Text : null;
                ficha_catastral_vias_urbanas.Limite = limite;
                //Condición de Limite
                condicion_limite.Codigo = (condicionLimite_txt.Text.Length > 0) ? condicionLimite_txt.Text : null;
                ficha_catastral_vias_urbanas.Condicion_Limite = condicion_limite;
                //Ubicación Geográfica
                ficha_catastral_vias_urbanas.Punto_Inicial_X = puntoInicialX_txt.Text;
                ficha_catastral_vias_urbanas.Punto_Inicial_Y = puntoInicialY_txt.Text;
                ficha_catastral_vias_urbanas.Punto_Inicial_Z = puntoInicialZ_txt.Text;
                ficha_catastral_vias_urbanas.Punto_Final_X = puntoFinalX_txt.Text;
                ficha_catastral_vias_urbanas.Punto_Final_Y = puntoFinalY_txt.Text;
                ficha_catastral_vias_urbanas.Punto_Final_Z = puntoFinalZ_txt.Text;
                //Habilitacion Urbana
                habilitacion_urbana.Codigo = (codigoHabilitacionUrbana_txt.Text.Length > 0) ? codigoHabilitacionUrbana_txt.Text : null;
                ficha_catastral_vias_urbanas.Habilitacion_Urbana = habilitacion_urbana;
                //
                ficha_catastral_vias_urbanas.Zona_Sector_Etapa = zonaSectorEtapa_txt.Text;
                //Calzada Carril
                //1
                ficha_catastral_vias_urbanas.Calzada_Carril1_Largo = calzadaCarril1Largo_txt.Text;
                ficha_catastral_vias_urbanas.Calzada_Carril1_Ancho = calzadaCarril1Ancho_txt.Text;
                cMaterial calzada_carril1_material = new cMaterial();
                calzada_carril1_material.Codigo = (calzadaCarril1Material_txt.Text.Length > 0) ? calzadaCarril1Material_txt.Text : null;
                cEstado_Conservacion calzada_carril1_estado_conservacion = new cEstado_Conservacion();
                calzada_carril1_estado_conservacion.Codigo = (calzadaCarril1EstadoConservacion_txt.Text.Length > 0) ? calzadaCarril1EstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Calzada_Carril1_Material = calzada_carril1_material;
                ficha_catastral_vias_urbanas.Calzada_Carril1_Estado_Conservacion = calzada_carril1_estado_conservacion;
                ficha_catastral_vias_urbanas.Calzada_Carril1_Especificaciones = calzadaCarril1Especificaciones_txt.Text;
                //2
                ficha_catastral_vias_urbanas.Calzada_Carril2_Largo = calzadaCarril2Largo_txt.Text;
                ficha_catastral_vias_urbanas.Calzada_Carril2_Ancho = calzadaCarril2Ancho_txt.Text;
                cMaterial calzada_carril2_material = new cMaterial();
                calzada_carril2_material.Codigo = (calzadaCarril2Material_txt.Text.Length > 0) ? calzadaCarril2Material_txt.Text : null;
                cEstado_Conservacion calzada_carril2_estado_conservacion = new cEstado_Conservacion();
                calzada_carril2_estado_conservacion.Codigo = (calzadaCarril2EstadoConservacion_txt.Text.Length > 0) ? calzadaCarril2EstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Calzada_Carril2_Material = calzada_carril2_material;
                ficha_catastral_vias_urbanas.Calzada_Carril2_Estado_Conservacion = calzada_carril2_estado_conservacion;
                ficha_catastral_vias_urbanas.Calzada_Carril2_Especificaciones = calzadaCarril2Especificaciones_txt.Text;
                //3
                ficha_catastral_vias_urbanas.Calzada_Carril3_Largo = calzadaCarril3Largo_txt.Text;
                ficha_catastral_vias_urbanas.Calzada_Carril3_Ancho = calzadaCarril3Ancho_txt.Text;
                cMaterial calzada_carril3_material = new cMaterial();
                calzada_carril3_material.Codigo = (calzadaCarril3Material_txt.Text.Length > 0) ? calzadaCarril3Material_txt.Text : null;
                cEstado_Conservacion calzada_carril3_estado_conservacion = new cEstado_Conservacion();
                calzada_carril3_estado_conservacion.Codigo = (calzadaCarril3EstadoConservacion_txt.Text.Length > 0) ? calzadaCarril3EstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Calzada_Carril3_Material = calzada_carril3_material;
                ficha_catastral_vias_urbanas.Calzada_Carril3_Estado_Conservacion = calzada_carril3_estado_conservacion;
                ficha_catastral_vias_urbanas.Calzada_Carril3_Especificaciones = calzadaCarril3Especificaciones_txt.Text;
                //4
                ficha_catastral_vias_urbanas.Calzada_Carril4_Largo = calzadaCarril4Largo_txt.Text;
                ficha_catastral_vias_urbanas.Calzada_Carril4_Ancho = calzadaCarril4Ancho_txt.Text;
                cMaterial calzada_carril4_material = new cMaterial();
                calzada_carril4_material.Codigo = (calzadaCarril4Material_txt.Text.Length > 0) ? calzadaCarril4Material_txt.Text : null;
                cEstado_Conservacion calzada_carril4_estado_conservacion = new cEstado_Conservacion();
                calzada_carril4_estado_conservacion.Codigo = (calzadaCarril4EstadoConservacion_txt.Text.Length > 0) ? calzadaCarril4EstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Calzada_Carril4_Material = calzada_carril4_material;
                ficha_catastral_vias_urbanas.Calzada_Carril4_Estado_Conservacion = calzada_carril4_estado_conservacion;
                ficha_catastral_vias_urbanas.Calzada_Carril4_Especificaciones = calzadaCarril4Especificaciones_txt.Text;
                //Veredas
                //Derecha
                ficha_catastral_vias_urbanas.Veredas_Derecha_Largo = veredaDerechaLargo_txt.Text;
                ficha_catastral_vias_urbanas.Veredas_Derecha_Ancho = veredaDerechaAncho_txt.Text;
                cMaterial vereda_derecha_material = new cMaterial();
                vereda_derecha_material.Codigo = (veredaDerechaMaterial_txt.Text.Length > 0) ? veredaDerechaMaterial_txt.Text : null;
                cEstado_Conservacion vereda_derecha_estado_conservacion = new cEstado_Conservacion();
                vereda_derecha_estado_conservacion.Codigo = (veredaDerechaEstadoConservacion_txt.Text.Length > 0) ? veredaDerechaEstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Veredas_Derecha_Material = vereda_derecha_material;
                ficha_catastral_vias_urbanas.Veredas_Derecha_Estado_Conservacion = vereda_derecha_estado_conservacion;
                ficha_catastral_vias_urbanas.Veredas_Derecha_Especificaciones = veredaDerechaEspecificaciones_txt.Text;
                //Izquierda
                ficha_catastral_vias_urbanas.Veredas_Izquierda_Largo = veredaIzquierdaLargo_txt.Text;
                ficha_catastral_vias_urbanas.Veredas_Izquierda_Ancho = veredaIzquierdaAncho_txt.Text;
                cMaterial vereda_izquierda_material = new cMaterial();
                vereda_izquierda_material.Codigo = (veredaIzquierdaMaterial_txt.Text.Length > 0) ? veredaIzquierdaMaterial_txt.Text : null;
                cEstado_Conservacion vereda_izquierda_estado_conservacion = new cEstado_Conservacion();
                vereda_izquierda_estado_conservacion.Codigo = (veredaIzquierdaEstadoConservacion_txt.Text.Length > 0) ? veredaIzquierdaEstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Veredas_Izquierda_Material = vereda_izquierda_material;
                ficha_catastral_vias_urbanas.Veredas_Izquierda_Estado_Conservacion = vereda_izquierda_estado_conservacion;
                ficha_catastral_vias_urbanas.Veredas_Izquierda_Especificaciones = veredaIzquierdaEspecificaciones_txt.Text;
                //Central
                ficha_catastral_vias_urbanas.Veredas_Central_Largo = veredaCentralLargo_txt.Text;
                ficha_catastral_vias_urbanas.Veredas_Central_Ancho = veredaCentralAncho_txt.Text;
                cMaterial vereda_central_material = new cMaterial();
                vereda_central_material.Codigo = (veredaCentralMaterial_txt.Text.Length > 0) ? veredaCentralMaterial_txt.Text : null;
                cEstado_Conservacion vereda_central_estado_conservacion = new cEstado_Conservacion();
                vereda_central_estado_conservacion.Codigo = (veredaCentralEstadoConservacion_txt.Text.Length > 0) ? veredaCentralEstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Veredas_Central_Material = vereda_central_material;
                ficha_catastral_vias_urbanas.Veredas_Central_Estado_Conservacion = vereda_central_estado_conservacion;
                ficha_catastral_vias_urbanas.Veredas_Central_Especificaciones = veredaCentralEspecificaciones_txt.Text;
                //Ciclo Via
                //Derecha
                ficha_catastral_vias_urbanas.Ciclo_Via_Derecha_Largo = cicloViaDerechaLargo_txt.Text;
                ficha_catastral_vias_urbanas.Ciclo_Via_Derecha_Ancho = cicloViaDerechaAncho_txt.Text;
                cMaterial ciclo_via_derecha_material = new cMaterial();
                ciclo_via_derecha_material.Codigo = (cicloViaDerechaMaterial_txt.Text.Length > 0) ? cicloViaDerechaMaterial_txt.Text : null;
                cEstado_Conservacion ciclo_via_derecha_estado_conservacion = new cEstado_Conservacion();
                ciclo_via_derecha_estado_conservacion.Codigo = (cicloViaDerechaEstadoConservacion_txt.Text.Length > 0) ? cicloViaDerechaEstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Ciclo_Via_Derecha_Material = ciclo_via_derecha_material;
                ficha_catastral_vias_urbanas.Ciclo_Via_Derecha_Estado_Conservacion = ciclo_via_derecha_estado_conservacion;
                ficha_catastral_vias_urbanas.Ciclo_Via_Derecha_Especificaciones = cicloViaDerechaEspecificaciones_txt.Text;
                //Izquierda
                ficha_catastral_vias_urbanas.Ciclo_Via_Izquierda_Largo = cicloViaIzquierdaLargo_txt.Text;
                ficha_catastral_vias_urbanas.Ciclo_Via_Izquierda_Ancho = cicloViaIzquierdaAncho_txt.Text;
                cMaterial ciclo_via_izquierda_material = new cMaterial();
                ciclo_via_izquierda_material.Codigo = (cicloViaIzquierdaMaterial_txt.Text.Length > 0) ? cicloViaIzquierdaMaterial_txt.Text : null;
                cEstado_Conservacion ciclo_via_izquierda_estado_conservacion = new cEstado_Conservacion();
                ciclo_via_izquierda_estado_conservacion.Codigo = (cicloViaIzquierdaEstadoConservacion_txt.Text.Length > 0) ? cicloViaIzquierdaEstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Ciclo_Via_Izquierda_Material = ciclo_via_izquierda_material;
                ficha_catastral_vias_urbanas.Ciclo_Via_Izquierda_Estado_Conservacion = ciclo_via_izquierda_estado_conservacion;
                ficha_catastral_vias_urbanas.Ciclo_Via_Izquierda_Especificaciones = cicloViaIzquierdaEspecificaciones_txt.Text;
                //Central
                ficha_catastral_vias_urbanas.Ciclo_Via_Central_Largo = cicloViaCentralLargo_txt.Text;
                ficha_catastral_vias_urbanas.Ciclo_Via_Central_Ancho = cicloViaCentralAncho_txt.Text;
                cMaterial ciclo_via_central_material = new cMaterial();
                ciclo_via_central_material.Codigo = (cicloViaCentralMaterial_txt.Text.Length > 0) ? cicloViaCentralMaterial_txt.Text : null;
                cEstado_Conservacion ciclo_via_central_estado_conservacion = new cEstado_Conservacion();
                ciclo_via_central_estado_conservacion.Codigo = (cicloViaCentralEstadoConservacion_txt.Text.Length > 0) ? cicloViaCentralEstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Ciclo_Via_Central_Material = ciclo_via_central_material;
                ficha_catastral_vias_urbanas.Ciclo_Via_Central_Estado_Conservacion = ciclo_via_central_estado_conservacion;
                ficha_catastral_vias_urbanas.Ciclo_Via_Central_Especificaciones = cicloViaCentralEspecificaciones_txt.Text;
                //Via Ferrea
                //Derecha
                ficha_catastral_vias_urbanas.Via_Ferrea_Derecha_Largo = viaFerreaDerechaLargo_txt.Text;
                ficha_catastral_vias_urbanas.Via_Ferrea_Derecha_Ancho = viaFerreaDerechaAncho_txt.Text;
                cMaterial via_ferrea_derecha_material = new cMaterial();
                via_ferrea_derecha_material.Codigo = (viaFerreaDerechaMaterial_txt.Text.Length > 0) ? viaFerreaDerechaMaterial_txt.Text : null;
                cEstado_Conservacion via_ferrea_derecha_estado_conservacion = new cEstado_Conservacion();
                via_ferrea_derecha_estado_conservacion.Codigo = (viaFerreaDerechaEstadoConservacion_txt.Text.Length > 0) ? viaFerreaDerechaEstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Via_Ferrea_Derecha_Material = via_ferrea_derecha_material;
                ficha_catastral_vias_urbanas.Via_Ferrea_Derecha_Estado_Conservacion = via_ferrea_derecha_estado_conservacion;
                ficha_catastral_vias_urbanas.Via_Ferrea_Derecha_Especificaciones = viaFerreaDerechaEspecificaciones_txt.Text;
                //Izquierda
                ficha_catastral_vias_urbanas.Via_Ferrea_Izquierda_Largo = viaFerreaIzquierdaLargo_txt.Text;
                ficha_catastral_vias_urbanas.Via_Ferrea_Izquierda_Ancho = viaFerreaIzquierdaAncho_txt.Text;
                cMaterial via_ferrea_izquierda_material = new cMaterial();
                via_ferrea_izquierda_material.Codigo = (viaFerreaIzquierdaMaterial_txt.Text.Length > 0) ? viaFerreaIzquierdaMaterial_txt.Text : null;
                cEstado_Conservacion via_ferrea_izquierda_estado_conservacion = new cEstado_Conservacion();
                via_ferrea_izquierda_estado_conservacion.Codigo = (viaFerreaIzquierdaEstadoConservacion_txt.Text.Length > 0) ? viaFerreaIzquierdaEstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Via_Ferrea_Izquierda_Material = via_ferrea_izquierda_material;
                ficha_catastral_vias_urbanas.Via_Ferrea_Izquierda_Estado_Conservacion = via_ferrea_izquierda_estado_conservacion;
                ficha_catastral_vias_urbanas.Via_Ferrea_Izquierda_Especificaciones = viaFerreaIzquierdaEspecificaciones_txt.Text;
                //Central
                ficha_catastral_vias_urbanas.Via_Ferrea_Central_Largo = viaFerreaCentralLargo_txt.Text;
                ficha_catastral_vias_urbanas.Via_Ferrea_Central_Ancho = viaFerreaCentralAncho_txt.Text;
                cMaterial via_ferrea_central_material = new cMaterial();
                via_ferrea_central_material.Codigo = (viaFerreaCentralMaterial_txt.Text.Length > 0) ? viaFerreaCentralMaterial_txt.Text : null;
                cEstado_Conservacion via_ferrea_central_estado_conservacion = new cEstado_Conservacion();
                via_ferrea_central_estado_conservacion.Codigo = (viaFerreaCentralEstadoConservacion_txt.Text.Length > 0) ? viaFerreaCentralEstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Via_Ferrea_Central_Material = via_ferrea_central_material;
                ficha_catastral_vias_urbanas.Via_Ferrea_Central_Estado_Conservacion = via_ferrea_central_estado_conservacion;
                ficha_catastral_vias_urbanas.Via_Ferrea_Central_Especificaciones = viaFerreaCentralEspecificaciones_txt.Text;
                //Berma
                //Derecha
                ficha_catastral_vias_urbanas.Berma_Derecha_Largo = bermaDerechaLargo_txt.Text;
                ficha_catastral_vias_urbanas.Berma_Derecha_Ancho = bermaDerechaAncho_txt.Text;
                cEstado_Conservacion berma_derecha_estado_conservacion = new cEstado_Conservacion();
                berma_derecha_estado_conservacion.Codigo = (bermaDerechaEstadoConservacion_txt.Text.Length > 0) ? bermaDerechaEstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Berma_Derecha_Estado_Conservacion = berma_derecha_estado_conservacion;
                ficha_catastral_vias_urbanas.Berma_Derecha_Especificaciones = bermaDerechaEspecificaciones_txt.Text;
                //Izquierda
                ficha_catastral_vias_urbanas.Berma_Izquierda_Largo = bermaIzquierdaLargo_txt.Text;
                ficha_catastral_vias_urbanas.Berma_Izquierda_Ancho = bermaIzquierdaAncho_txt.Text;
                cEstado_Conservacion berma_izquierda_estado_conservacion = new cEstado_Conservacion();
                berma_izquierda_estado_conservacion.Codigo = (bermaIzquierdaEstadoConservacion_txt.Text.Length > 0) ? bermaIzquierdaEstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Berma_Izquierda_Estado_Conservacion = berma_izquierda_estado_conservacion;
                ficha_catastral_vias_urbanas.Berma_Izquierda_Especificaciones = bermaIzquierdaEspecificaciones_txt.Text;
                //Central
                ficha_catastral_vias_urbanas.Berma_Central_Largo = bermaCentralLargo_txt.Text;
                ficha_catastral_vias_urbanas.Berma_Central_Ancho = bermaCentralAncho_txt.Text;
                cEstado_Conservacion berma_central_estado_conservacion = new cEstado_Conservacion();
                berma_central_estado_conservacion.Codigo = (bermaCentralEstadoConservacion_txt.Text.Length > 0) ? bermaCentralEstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Berma_Central_Estado_Conservacion = berma_central_estado_conservacion;
                ficha_catastral_vias_urbanas.Berma_Central_Especificaciones = bermaCentralEspecificaciones_txt.Text;
                //
                ficha_catastral_vias_urbanas.Observaciones = observaciones_txt.Text;
                //Estado de Llenado de la Ficha
                estado_llenado_ficha.Codigo = (estadoLlenadoFicha_txt.Text.Length > 0) ? estadoLlenadoFicha_txt.Text : null;
                ficha_catastral_vias_urbanas.Estado_Llenado_Ficha = estado_llenado_ficha;
                //
                supervisor.DNI = cPersonal.DNI_Supervisor;
                ficha_catastral_vias_urbanas.Supervisor = supervisor;
                ficha_catastral_vias_urbanas.Fecha_Supervisor = fechaSupervisor_txt.Value;
                tecnico_catastral.DNI = cPersonal.DNI_Tecnico_Catastral;
                ficha_catastral_vias_urbanas.Tecnico_Catastral = tecnico_catastral;
                ficha_catastral_vias_urbanas.Fecha_Tecnico_Catastral = fechaTecnicoCatastral_txt.Value;
                digitacion.DNI = cPersonal.DNI_Digitacion;
                ficha_catastral_vias_urbanas.Digitacion = digitacion;
                ficha_catastral_vias_urbanas.Fecha_Digitacion = fechaDigitacion_txt.Value;
                ficha_catastral_vias_urbanas.Usuario = Usuario;
                i = ficha_catastral_vias_urbanas.guardar();
                if (i > 0)
                {
                    if (FICHA_dgv.RowCount > 0)
                    {
                        (new cFicha_Catastral_Vias_Urbanas_Fotografia()).actualizar(FICHA_ds);
                        (new cFicha_Catastral_Vias_Urbanas_Componente_Urbano()).actualizar(FICHA_ds);
                        (new cFicha_Catastral_Vias_Urbanas_Mobiliario_Urbano()).actualizar(FICHA_ds);
                        MessageBox.Show("Se a Insertando Correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else MessageBox.Show("Error Guardar, Ficha Catastral de Vías Urbanas.", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                iniciar();
            }
        }
        void modificar()
        {
            if (estadoLlenadoFicha_txt.Text.Length == 0)
            {
                secundario_tc.SelectedTab = tabPage3;
                secundario_tc.SelectedTab = tabPage4;
                secundario_tc.SelectedTab = tabPage1;
            }
            if (validar)
            {
                cFicha_Catastral_Vias_Urbanas ficha_catastral_vias_urbanas = new cFicha_Catastral_Vias_Urbanas();
                ficha_catastral_vias_urbanas.Ficha = ficha_lbl.Text.Trim();
                ficha_catastral_vias_urbanas.Parcial_Ficha = parcialFichas_txt.Text;
                ficha_catastral_vias_urbanas.Total_Fichas = totalFichas_txt.Text;
                ficha_catastral_vias_urbanas.Departamento = departamento_lbl.Text;
                ficha_catastral_vias_urbanas.Provincia = provincia_lbl.Text;
                ficha_catastral_vias_urbanas.Distrito = distrito_lbl.Text;
                ficha_catastral_vias_urbanas.Sector = sector_txt.Text;
                //Vias
                vias.Codigo = codigoVia_txt.Text;
                ficha_catastral_vias_urbanas.Vias = vias;
                //
                ficha_catastral_vias_urbanas.Cuadra = cuadra_txt.Text;
                ficha_catastral_vias_urbanas.Numero_Cuadras = numeroCuadras_txt.Text;
                //Estado General de la Via
                estado_general_via.Codigo = (estadoGeneralVia_txt.Text.Length > 0) ? estadoGeneralVia_txt.Text : null;
                ficha_catastral_vias_urbanas.Estado_General_Via = estado_general_via;
                //Limite
                limite.Codigo = (limite_txt.Text.Length > 0) ? limite_txt.Text : null;
                ficha_catastral_vias_urbanas.Limite = limite;
                //Condición de Limite
                condicion_limite.Codigo = (condicionLimite_txt.Text.Length > 0) ? condicionLimite_txt.Text : null;
                ficha_catastral_vias_urbanas.Condicion_Limite = condicion_limite;
                //Ubicación Geográfica
                ficha_catastral_vias_urbanas.Punto_Inicial_X = puntoInicialX_txt.Text;
                ficha_catastral_vias_urbanas.Punto_Inicial_Y = puntoInicialY_txt.Text;
                ficha_catastral_vias_urbanas.Punto_Inicial_Z = puntoInicialZ_txt.Text;
                ficha_catastral_vias_urbanas.Punto_Final_X = puntoFinalX_txt.Text;
                ficha_catastral_vias_urbanas.Punto_Final_Y = puntoFinalY_txt.Text;
                ficha_catastral_vias_urbanas.Punto_Final_Z = puntoFinalZ_txt.Text;
                //Habilitacion Urbana
                habilitacion_urbana.Codigo = (codigoHabilitacionUrbana_txt.Text.Length > 0) ? codigoHabilitacionUrbana_txt.Text : null;
                ficha_catastral_vias_urbanas.Habilitacion_Urbana = habilitacion_urbana;
                //
                ficha_catastral_vias_urbanas.Zona_Sector_Etapa = zonaSectorEtapa_txt.Text;
                //Calzada Carril
                //1
                ficha_catastral_vias_urbanas.Calzada_Carril1_Largo = calzadaCarril1Largo_txt.Text;
                ficha_catastral_vias_urbanas.Calzada_Carril1_Ancho = calzadaCarril1Ancho_txt.Text;
                cMaterial calzada_carril1_material = new cMaterial();
                calzada_carril1_material.Codigo = (calzadaCarril1Material_txt.Text.Length > 0) ? calzadaCarril1Material_txt.Text : null;
                cEstado_Conservacion calzada_carril1_estado_conservacion = new cEstado_Conservacion();
                calzada_carril1_estado_conservacion.Codigo = (calzadaCarril1EstadoConservacion_txt.Text.Length > 0) ? calzadaCarril1EstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Calzada_Carril1_Material = calzada_carril1_material;
                ficha_catastral_vias_urbanas.Calzada_Carril1_Estado_Conservacion = calzada_carril1_estado_conservacion;
                ficha_catastral_vias_urbanas.Calzada_Carril1_Especificaciones = calzadaCarril1Especificaciones_txt.Text;
                //2
                ficha_catastral_vias_urbanas.Calzada_Carril2_Largo = calzadaCarril2Largo_txt.Text;
                ficha_catastral_vias_urbanas.Calzada_Carril2_Ancho = calzadaCarril2Ancho_txt.Text;
                cMaterial calzada_carril2_material = new cMaterial();
                calzada_carril2_material.Codigo = (calzadaCarril2Material_txt.Text.Length > 0) ? calzadaCarril2Material_txt.Text : null;
                cEstado_Conservacion calzada_carril2_estado_conservacion = new cEstado_Conservacion();
                calzada_carril2_estado_conservacion.Codigo = (calzadaCarril2EstadoConservacion_txt.Text.Length > 0) ? calzadaCarril2EstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Calzada_Carril2_Material = calzada_carril2_material;
                ficha_catastral_vias_urbanas.Calzada_Carril2_Estado_Conservacion = calzada_carril2_estado_conservacion;
                ficha_catastral_vias_urbanas.Calzada_Carril2_Especificaciones = calzadaCarril2Especificaciones_txt.Text;
                //3
                ficha_catastral_vias_urbanas.Calzada_Carril3_Largo = calzadaCarril3Largo_txt.Text;
                ficha_catastral_vias_urbanas.Calzada_Carril3_Ancho = calzadaCarril3Ancho_txt.Text;
                cMaterial calzada_carril3_material = new cMaterial();
                calzada_carril3_material.Codigo = (calzadaCarril3Material_txt.Text.Length > 0) ? calzadaCarril3Material_txt.Text : null;
                cEstado_Conservacion calzada_carril3_estado_conservacion = new cEstado_Conservacion();
                calzada_carril3_estado_conservacion.Codigo = (calzadaCarril3EstadoConservacion_txt.Text.Length > 0) ? calzadaCarril3EstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Calzada_Carril3_Material = calzada_carril3_material;
                ficha_catastral_vias_urbanas.Calzada_Carril3_Estado_Conservacion = calzada_carril3_estado_conservacion;
                ficha_catastral_vias_urbanas.Calzada_Carril3_Especificaciones = calzadaCarril3Especificaciones_txt.Text;
                //4
                ficha_catastral_vias_urbanas.Calzada_Carril4_Largo = calzadaCarril4Largo_txt.Text;
                ficha_catastral_vias_urbanas.Calzada_Carril4_Ancho = calzadaCarril4Ancho_txt.Text;
                cMaterial calzada_carril4_material = new cMaterial();
                calzada_carril4_material.Codigo = (calzadaCarril4Material_txt.Text.Length > 0) ? calzadaCarril4Material_txt.Text : null;
                cEstado_Conservacion calzada_carril4_estado_conservacion = new cEstado_Conservacion();
                calzada_carril4_estado_conservacion.Codigo = (calzadaCarril4EstadoConservacion_txt.Text.Length > 0) ? calzadaCarril4EstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Calzada_Carril4_Material = calzada_carril4_material;
                ficha_catastral_vias_urbanas.Calzada_Carril4_Estado_Conservacion = calzada_carril4_estado_conservacion;
                ficha_catastral_vias_urbanas.Calzada_Carril4_Especificaciones = calzadaCarril4Especificaciones_txt.Text;
                //Veredas
                //Derecha
                ficha_catastral_vias_urbanas.Veredas_Derecha_Largo = veredaDerechaLargo_txt.Text;
                ficha_catastral_vias_urbanas.Veredas_Derecha_Ancho = veredaDerechaAncho_txt.Text;
                cMaterial vereda_derecha_material = new cMaterial();
                vereda_derecha_material.Codigo = (veredaDerechaMaterial_txt.Text.Length > 0) ? veredaDerechaMaterial_txt.Text : null;
                cEstado_Conservacion vereda_derecha_estado_conservacion = new cEstado_Conservacion();
                vereda_derecha_estado_conservacion.Codigo = (veredaDerechaEstadoConservacion_txt.Text.Length > 0) ? veredaDerechaEstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Veredas_Derecha_Material = vereda_derecha_material;
                ficha_catastral_vias_urbanas.Veredas_Derecha_Estado_Conservacion = vereda_derecha_estado_conservacion;
                ficha_catastral_vias_urbanas.Veredas_Derecha_Especificaciones = veredaDerechaEspecificaciones_txt.Text;
                //Izquierda
                ficha_catastral_vias_urbanas.Veredas_Izquierda_Largo = veredaIzquierdaLargo_txt.Text;
                ficha_catastral_vias_urbanas.Veredas_Izquierda_Ancho = veredaIzquierdaAncho_txt.Text;
                cMaterial vereda_izquierda_material = new cMaterial();
                vereda_izquierda_material.Codigo = (veredaIzquierdaMaterial_txt.Text.Length > 0) ? veredaIzquierdaMaterial_txt.Text : null;
                cEstado_Conservacion vereda_izquierda_estado_conservacion = new cEstado_Conservacion();
                vereda_izquierda_estado_conservacion.Codigo = (veredaIzquierdaEstadoConservacion_txt.Text.Length > 0) ? veredaIzquierdaEstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Veredas_Izquierda_Material = vereda_izquierda_material;
                ficha_catastral_vias_urbanas.Veredas_Izquierda_Estado_Conservacion = vereda_izquierda_estado_conservacion;
                ficha_catastral_vias_urbanas.Veredas_Izquierda_Especificaciones = veredaIzquierdaEspecificaciones_txt.Text;
                //Central
                ficha_catastral_vias_urbanas.Veredas_Central_Largo = veredaCentralLargo_txt.Text;
                ficha_catastral_vias_urbanas.Veredas_Central_Ancho = veredaCentralAncho_txt.Text;
                cMaterial vereda_central_material = new cMaterial();
                vereda_central_material.Codigo = (veredaCentralMaterial_txt.Text.Length > 0) ? veredaCentralMaterial_txt.Text : null;
                cEstado_Conservacion vereda_central_estado_conservacion = new cEstado_Conservacion();
                vereda_central_estado_conservacion.Codigo = (veredaCentralEstadoConservacion_txt.Text.Length > 0) ? veredaCentralEstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Veredas_Central_Material = vereda_central_material;
                ficha_catastral_vias_urbanas.Veredas_Central_Estado_Conservacion = vereda_central_estado_conservacion;
                ficha_catastral_vias_urbanas.Veredas_Central_Especificaciones = veredaCentralEspecificaciones_txt.Text;
                //Ciclo Via
                //Derecha
                ficha_catastral_vias_urbanas.Ciclo_Via_Derecha_Largo = cicloViaDerechaLargo_txt.Text;
                ficha_catastral_vias_urbanas.Ciclo_Via_Derecha_Ancho = cicloViaDerechaAncho_txt.Text;
                cMaterial ciclo_via_derecha_material = new cMaterial();
                ciclo_via_derecha_material.Codigo = (cicloViaDerechaMaterial_txt.Text.Length > 0) ? cicloViaDerechaMaterial_txt.Text : null;
                cEstado_Conservacion ciclo_via_derecha_estado_conservacion = new cEstado_Conservacion();
                ciclo_via_derecha_estado_conservacion.Codigo = (cicloViaDerechaEstadoConservacion_txt.Text.Length > 0) ? cicloViaDerechaEstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Ciclo_Via_Derecha_Material = ciclo_via_derecha_material;
                ficha_catastral_vias_urbanas.Ciclo_Via_Derecha_Estado_Conservacion = ciclo_via_derecha_estado_conservacion;
                ficha_catastral_vias_urbanas.Ciclo_Via_Derecha_Especificaciones = cicloViaDerechaEspecificaciones_txt.Text;
                //Izquierda
                ficha_catastral_vias_urbanas.Ciclo_Via_Izquierda_Largo = cicloViaIzquierdaLargo_txt.Text;
                ficha_catastral_vias_urbanas.Ciclo_Via_Izquierda_Ancho = cicloViaIzquierdaAncho_txt.Text;
                cMaterial ciclo_via_izquierda_material = new cMaterial();
                ciclo_via_izquierda_material.Codigo = (cicloViaIzquierdaMaterial_txt.Text.Length > 0) ? cicloViaIzquierdaMaterial_txt.Text : null;
                cEstado_Conservacion ciclo_via_izquierda_estado_conservacion = new cEstado_Conservacion();
                ciclo_via_izquierda_estado_conservacion.Codigo = (cicloViaIzquierdaEstadoConservacion_txt.Text.Length > 0) ? cicloViaIzquierdaEstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Ciclo_Via_Izquierda_Material = ciclo_via_izquierda_material;
                ficha_catastral_vias_urbanas.Ciclo_Via_Izquierda_Estado_Conservacion = ciclo_via_izquierda_estado_conservacion;
                ficha_catastral_vias_urbanas.Ciclo_Via_Izquierda_Especificaciones = cicloViaIzquierdaEspecificaciones_txt.Text;
                //Central
                ficha_catastral_vias_urbanas.Ciclo_Via_Central_Largo = cicloViaCentralLargo_txt.Text;
                ficha_catastral_vias_urbanas.Ciclo_Via_Central_Ancho = cicloViaCentralAncho_txt.Text;
                cMaterial ciclo_via_central_material = new cMaterial();
                ciclo_via_central_material.Codigo = (cicloViaCentralMaterial_txt.Text.Length > 0) ? cicloViaCentralMaterial_txt.Text : null;
                cEstado_Conservacion ciclo_via_central_estado_conservacion = new cEstado_Conservacion();
                ciclo_via_central_estado_conservacion.Codigo = (cicloViaCentralEstadoConservacion_txt.Text.Length > 0) ? cicloViaCentralEstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Ciclo_Via_Central_Material = ciclo_via_central_material;
                ficha_catastral_vias_urbanas.Ciclo_Via_Central_Estado_Conservacion = ciclo_via_central_estado_conservacion;
                ficha_catastral_vias_urbanas.Ciclo_Via_Central_Especificaciones = cicloViaCentralEspecificaciones_txt.Text;
                //Via Ferrea
                //Derecha
                ficha_catastral_vias_urbanas.Via_Ferrea_Derecha_Largo = viaFerreaDerechaLargo_txt.Text;
                ficha_catastral_vias_urbanas.Via_Ferrea_Derecha_Ancho = viaFerreaDerechaAncho_txt.Text;
                cMaterial via_ferrea_derecha_material = new cMaterial();
                via_ferrea_derecha_material.Codigo = (viaFerreaDerechaMaterial_txt.Text.Length > 0) ? viaFerreaDerechaMaterial_txt.Text : null;
                cEstado_Conservacion via_ferrea_derecha_estado_conservacion = new cEstado_Conservacion();
                via_ferrea_derecha_estado_conservacion.Codigo = (viaFerreaDerechaEstadoConservacion_txt.Text.Length > 0) ? viaFerreaDerechaEstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Via_Ferrea_Derecha_Material = via_ferrea_derecha_material;
                ficha_catastral_vias_urbanas.Via_Ferrea_Derecha_Estado_Conservacion = via_ferrea_derecha_estado_conservacion;
                ficha_catastral_vias_urbanas.Via_Ferrea_Derecha_Especificaciones = viaFerreaDerechaEspecificaciones_txt.Text;
                //Izquierda
                ficha_catastral_vias_urbanas.Via_Ferrea_Izquierda_Largo = viaFerreaIzquierdaLargo_txt.Text;
                ficha_catastral_vias_urbanas.Via_Ferrea_Izquierda_Ancho = viaFerreaIzquierdaAncho_txt.Text;
                cMaterial via_ferrea_izquierda_material = new cMaterial();
                via_ferrea_izquierda_material.Codigo = (viaFerreaIzquierdaMaterial_txt.Text.Length > 0) ? viaFerreaIzquierdaMaterial_txt.Text : null;
                cEstado_Conservacion via_ferrea_izquierda_estado_conservacion = new cEstado_Conservacion();
                via_ferrea_izquierda_estado_conservacion.Codigo = (viaFerreaIzquierdaEstadoConservacion_txt.Text.Length > 0) ? viaFerreaIzquierdaEstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Via_Ferrea_Izquierda_Material = via_ferrea_izquierda_material;
                ficha_catastral_vias_urbanas.Via_Ferrea_Izquierda_Estado_Conservacion = via_ferrea_izquierda_estado_conservacion;
                ficha_catastral_vias_urbanas.Via_Ferrea_Izquierda_Especificaciones = viaFerreaIzquierdaEspecificaciones_txt.Text;
                //Central
                ficha_catastral_vias_urbanas.Via_Ferrea_Central_Largo = viaFerreaCentralLargo_txt.Text;
                ficha_catastral_vias_urbanas.Via_Ferrea_Central_Ancho = viaFerreaCentralAncho_txt.Text;
                cMaterial via_ferrea_central_material = new cMaterial();
                via_ferrea_central_material.Codigo = (viaFerreaCentralMaterial_txt.Text.Length > 0) ? viaFerreaCentralMaterial_txt.Text : null;
                cEstado_Conservacion via_ferrea_central_estado_conservacion = new cEstado_Conservacion();
                via_ferrea_central_estado_conservacion.Codigo = (viaFerreaCentralEstadoConservacion_txt.Text.Length > 0) ? viaFerreaCentralEstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Via_Ferrea_Central_Material = via_ferrea_central_material;
                ficha_catastral_vias_urbanas.Via_Ferrea_Central_Estado_Conservacion = via_ferrea_central_estado_conservacion;
                ficha_catastral_vias_urbanas.Via_Ferrea_Central_Especificaciones = viaFerreaCentralEspecificaciones_txt.Text;
                //Berma
                //Derecha
                ficha_catastral_vias_urbanas.Berma_Derecha_Largo = bermaDerechaLargo_txt.Text;
                ficha_catastral_vias_urbanas.Berma_Derecha_Ancho = bermaDerechaAncho_txt.Text;
                cEstado_Conservacion berma_derecha_estado_conservacion = new cEstado_Conservacion();
                berma_derecha_estado_conservacion.Codigo = (bermaDerechaEstadoConservacion_txt.Text.Length > 0) ? bermaDerechaEstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Berma_Derecha_Estado_Conservacion = berma_derecha_estado_conservacion;
                ficha_catastral_vias_urbanas.Berma_Derecha_Especificaciones = bermaDerechaEspecificaciones_txt.Text;
                //Izquierda
                ficha_catastral_vias_urbanas.Berma_Izquierda_Largo = bermaIzquierdaLargo_txt.Text;
                ficha_catastral_vias_urbanas.Berma_Izquierda_Ancho = bermaIzquierdaAncho_txt.Text;
                cEstado_Conservacion berma_izquierda_estado_conservacion = new cEstado_Conservacion();
                berma_izquierda_estado_conservacion.Codigo = (bermaIzquierdaEstadoConservacion_txt.Text.Length > 0) ? bermaIzquierdaEstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Berma_Izquierda_Estado_Conservacion = berma_izquierda_estado_conservacion;
                ficha_catastral_vias_urbanas.Berma_Izquierda_Especificaciones = bermaIzquierdaEspecificaciones_txt.Text;
                //Central
                ficha_catastral_vias_urbanas.Berma_Central_Largo = bermaCentralLargo_txt.Text;
                ficha_catastral_vias_urbanas.Berma_Central_Ancho = bermaCentralAncho_txt.Text;
                cEstado_Conservacion berma_central_estado_conservacion = new cEstado_Conservacion();
                berma_central_estado_conservacion.Codigo = (bermaCentralEstadoConservacion_txt.Text.Length > 0) ? bermaCentralEstadoConservacion_txt.Text : null;
                ficha_catastral_vias_urbanas.Berma_Central_Estado_Conservacion = berma_central_estado_conservacion;
                ficha_catastral_vias_urbanas.Berma_Central_Especificaciones = bermaCentralEspecificaciones_txt.Text;
                //
                ficha_catastral_vias_urbanas.Observaciones = observaciones_txt.Text;
                //Estado de Llenado de la Ficha
                estado_llenado_ficha.Codigo = (estadoLlenadoFicha_txt.Text.Length > 0) ? estadoLlenadoFicha_txt.Text : null;
                ficha_catastral_vias_urbanas.Estado_Llenado_Ficha = estado_llenado_ficha;
                //
                supervisor.DNI = cPersonal.DNI_Supervisor;
                ficha_catastral_vias_urbanas.Supervisor = supervisor;
                ficha_catastral_vias_urbanas.Fecha_Supervisor = fechaSupervisor_txt.Value;
                tecnico_catastral.DNI = cPersonal.DNI_Tecnico_Catastral;
                ficha_catastral_vias_urbanas.Tecnico_Catastral = tecnico_catastral;
                ficha_catastral_vias_urbanas.Fecha_Tecnico_Catastral = fechaTecnicoCatastral_txt.Value;
                digitacion.DNI = cPersonal.DNI_Digitacion;
                ficha_catastral_vias_urbanas.Digitacion = digitacion;
                ficha_catastral_vias_urbanas.Fecha_Digitacion = fechaDigitacion_txt.Value;
                ficha_catastral_vias_urbanas.Usuario = Usuario;
                i = ficha_catastral_vias_urbanas.modificar();
                if (i > 0)
                {
                    if (FICHA_dgv.RowCount > 0)
                    {
                        (new cFicha_Catastral_Vias_Urbanas_Fotografia()).actualizar(FICHA_ds);
                        (new cFicha_Catastral_Vias_Urbanas_Componente_Urbano()).actualizar(FICHA_ds);
                        (new cFicha_Catastral_Vias_Urbanas_Mobiliario_Urbano()).actualizar(FICHA_ds);
                        MessageBox.Show("Se a Insertando Correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else MessageBox.Show("Error Modificar, Ficha Catastral de Vías Urbanas.", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                iniciar();
            }
        }
        void eliminar()
        {
            cFicha_Catastral_Vias_Urbanas ficha_catastral_vias_urbanas = new cFicha_Catastral_Vias_Urbanas();
            ficha_catastral_vias_urbanas.Ficha = ficha_lbl.Text.Trim();
            ficha_catastral_vias_urbanas.Usuario = Usuario;
            i = ficha_catastral_vias_urbanas.eliminar();
            if (i >= 2)
            {
                if (FICHA_dgv.RowCount > 0) MessageBox.Show("Se a Eliminado Correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Error Eliminar, Ficha Catastral de Vías Urbanas.", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            iniciar();
        }
        internal void listar_sector()
        {
            sector_manzana_lote.cargar(cUbicacion_Geografica.Ubigeo);
            sector_txt.AutoCompleteCustomSource.AddRange(sector_manzana_lote.listar_arreglo_sector());
        }
        internal void listar_codigo_vias()
        {
            codigoVia_txt.AutoCompleteCustomSource.AddRange(vias.listar_arreglo());
        }
        internal void listar_estado_general_via()
        {
            estadoGeneralVia_txt.AutoCompleteCustomSource.AddRange(estado_general_via.listar_arreglo());
        }
        internal void listar_limite()
        {
            limite_txt.AutoCompleteCustomSource.AddRange(limite.listar_arreglo());
        }
        internal void listar_condicion_limite()
        {
            condicionLimite_txt.AutoCompleteCustomSource.AddRange(condicion_limite.listar_arreglo());
        }
        internal void listar_material()
        {
            //Calzada
            calzadaCarril1Material_txt.AutoCompleteCustomSource.AddRange(material.listar_arreglo());
            calzadaCarril2Material_txt.AutoCompleteCustomSource.AddRange(material.listar_arreglo());
            calzadaCarril3Material_txt.AutoCompleteCustomSource.AddRange(material.listar_arreglo());
            calzadaCarril4Material_txt.AutoCompleteCustomSource.AddRange(material.listar_arreglo());
            //Vereda
            veredaDerechaMaterial_txt.AutoCompleteCustomSource.AddRange(material.listar_arreglo());
            veredaIzquierdaMaterial_txt.AutoCompleteCustomSource.AddRange(material.listar_arreglo());
            veredaCentralMaterial_txt.AutoCompleteCustomSource.AddRange(material.listar_arreglo());
            //Ciclo Via
            cicloViaDerechaMaterial_txt.AutoCompleteCustomSource.AddRange(material.listar_arreglo());
            cicloViaIzquierdaMaterial_txt.AutoCompleteCustomSource.AddRange(material.listar_arreglo());
            cicloViaCentralMaterial_txt.AutoCompleteCustomSource.AddRange(material.listar_arreglo());
            //Via Ferrea
            viaFerreaDerechaMaterial_txt.AutoCompleteCustomSource.AddRange(material.listar_arreglo());
            viaFerreaIzquierdaMaterial_txt.AutoCompleteCustomSource.AddRange(material.listar_arreglo());
            viaFerreaCentralMaterial_txt.AutoCompleteCustomSource.AddRange(material.listar_arreglo());
        }
        internal void listar_estado_conservacion()
        {
            //Calzada
            calzadaCarril1EstadoConservacion_txt.AutoCompleteCustomSource.AddRange(estado_conservacion.listar_arreglo());
            calzadaCarril2EstadoConservacion_txt.AutoCompleteCustomSource.AddRange(estado_conservacion.listar_arreglo());
            calzadaCarril3EstadoConservacion_txt.AutoCompleteCustomSource.AddRange(estado_conservacion.listar_arreglo());
            calzadaCarril4EstadoConservacion_txt.AutoCompleteCustomSource.AddRange(estado_conservacion.listar_arreglo());
            //Vereda
            veredaDerechaEstadoConservacion_txt.AutoCompleteCustomSource.AddRange(estado_conservacion.listar_arreglo());
            veredaIzquierdaEstadoConservacion_txt.AutoCompleteCustomSource.AddRange(estado_conservacion.listar_arreglo());
            veredaCentralEstadoConservacion_txt.AutoCompleteCustomSource.AddRange(estado_conservacion.listar_arreglo());
            //Ciclo Via
            cicloViaDerechaEstadoConservacion_txt.AutoCompleteCustomSource.AddRange(estado_conservacion.listar_arreglo());
            cicloViaIzquierdaEstadoConservacion_txt.AutoCompleteCustomSource.AddRange(estado_conservacion.listar_arreglo());
            cicloViaCentralEstadoConservacion_txt.AutoCompleteCustomSource.AddRange(estado_conservacion.listar_arreglo());
            //Via Ferrea
            viaFerreaDerechaEstadoConservacion_txt.AutoCompleteCustomSource.AddRange(estado_conservacion.listar_arreglo());
            viaFerreaIzquierdaEstadoConservacion_txt.AutoCompleteCustomSource.AddRange(estado_conservacion.listar_arreglo());
            viaFerreaCentralEstadoConservacion_txt.AutoCompleteCustomSource.AddRange(estado_conservacion.listar_arreglo());
            //Berma
            bermaDerechaEstadoConservacion_txt.AutoCompleteCustomSource.AddRange(estado_conservacion.listar_arreglo());
            bermaIzquierdaEstadoConservacion_txt.AutoCompleteCustomSource.AddRange(estado_conservacion.listar_arreglo());
            bermaCentralEstadoConservacion_txt.AutoCompleteCustomSource.AddRange(estado_conservacion.listar_arreglo());
        }
        internal void listar_habilitacion_urbana()
        {
            codigoHabilitacionUrbana_txt.AutoCompleteCustomSource.AddRange(habilitacion_urbana.listar_arreglo());
        }
        internal void listar_estado_llenado_ficha()
        {
            estadoLlenadoFicha_txt.AutoCompleteCustomSource.AddRange(estado_llenado_ficha.listar_arreglo());
        }
        bool buscar_sector()
        {
            return sector_txt.AutoCompleteCustomSource.Contains(sector_txt.Text);            
        }
        bool buscar_estado_general_via()
        {
            return (estado_general_via.buscar(estadoGeneralVia_txt.Text));
        }
        bool buscar_limite()
        {
            return (limite.buscar(limite_txt.Text));
        }
        bool buscar_condicion_limite()
        {
            return (condicion_limite.buscar(condicionLimite_txt.Text));
        }
        bool buscar_material(string m)
        {
            return (m == "") ? true : material.buscar(m);
        }
        bool buscar_estado_conservacion(string estadoConservacion)
        {
            return (estadoConservacion == "") ? true : estado_conservacion.buscar(estadoConservacion);
        }
        bool buscar_estado_llenado_ficha()
        {
            return estado_llenado_ficha.buscar(estadoLlenadoFicha_txt.Text);
        }
        #endregion

        #region [ METODOS DE FICHA CATASTRAL DE VIAS URBANAS - COMPONENTE URBANO ]
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

        #region [ METODOS DE FICHA CATASTRAL DE VIAS URBANAS - MOBILIARIO URBANO ]
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
        #region [ EVENTOS DE FICHA CATASTRAL DE VIAS URBANAS ]
        private void listar_Load(object sender, EventArgs e)
        {
            try
            {
                listar();
                //Ficha Catastral de Vías Urbanas
                habilitar_controles_ficha = false;
                listar_sector();
                listar_codigo_vias();
                listar_estado_general_via();
                listar_limite();
                listar_condicion_limite();
                listar_habilitacion_urbana();
                listar_material();
                listar_estado_conservacion();
                listar_estado_llenado_ficha();
                //Componente Urbano 
                listar_tipo_componente_urbano();
                listar_material_componente_urbano();
                listar_estado_conservacion_componente_urbano();
                //Mobiliario Urbano
                listar_tipo_mobiliario_urbano();
                listar_material_mobiliario_urbano();
                listar_estado_conservacion_mobiliario_urbano();

                #region Bindings - Ficha Catastral de Vias Urbanas
                FICHA_dgv.Columns["TV"].Visible = false;
                FICHA_dgv.Columns["EGV"].Visible = false;
                FICHA_dgv.Columns["L"].Visible = false;
                FICHA_dgv.Columns["CL"].Visible = false;
                FICHA_dgv.Columns["CNV"].Visible = false;
                FICHA_dgv.Columns["CV"].Visible = false;
                //Calzada Carril
                FICHA_dgv.Columns["CC1M"].Visible = false;
                FICHA_dgv.Columns["CC1ECS"].Visible = false;
                FICHA_dgv.Columns["CC2M"].Visible = false;
                FICHA_dgv.Columns["CC2ECS"].Visible = false;
                FICHA_dgv.Columns["CC3M"].Visible = false;
                FICHA_dgv.Columns["CC3ECS"].Visible = false;
                FICHA_dgv.Columns["CC4M"].Visible = false;
                FICHA_dgv.Columns["CC4ECS"].Visible = false;
                //Veredas
                FICHA_dgv.Columns["VDM"].Visible = false;
                FICHA_dgv.Columns["VDECS"].Visible = false;
                FICHA_dgv.Columns["VIM"].Visible = false;
                FICHA_dgv.Columns["VIECS"].Visible = false;
                FICHA_dgv.Columns["VCM"].Visible = false;
                FICHA_dgv.Columns["VCECS"].Visible = false;
                //Ciclo Via
                FICHA_dgv.Columns["CVDM"].Visible = false;
                FICHA_dgv.Columns["CVDECS"].Visible = false;
                FICHA_dgv.Columns["CVIM"].Visible = false;
                FICHA_dgv.Columns["CVIECS"].Visible = false;
                FICHA_dgv.Columns["CVCM"].Visible = false;
                FICHA_dgv.Columns["CVCECS"].Visible = false;
                //Via Ferrea
                FICHA_dgv.Columns["VFDM"].Visible = false;
                FICHA_dgv.Columns["VFDECS"].Visible = false;
                FICHA_dgv.Columns["VFIM"].Visible = false;
                FICHA_dgv.Columns["VFIECS"].Visible = false;
                FICHA_dgv.Columns["VFCM"].Visible = false;
                FICHA_dgv.Columns["VFCECS"].Visible = false;
                //Berma        
                FICHA_dgv.Columns["BDECS"].Visible = false;
                FICHA_dgv.Columns["BIECS"].Visible = false;
                FICHA_dgv.Columns["BCECS"].Visible = false;
                //
                FICHA_dgv.Columns["ELLF"].Visible = false;
                FICHA_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                ficha_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "FICHA", false));
                numero_ficha_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "NUMERO DE FICHA", true));
                numeroFicha_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "NUMERO DE FICHA", true));
                parcialFichas_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "PARCIAL DE FICHAS", true));
                totalFichas_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "TOTAL DE FICHAS", true));
                departamento_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "DPTO", true));
                provincia_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "PROV", true));
                distrito_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "DIST", true));
                sector_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "SECTOR", true));
                codigoVia_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CODIGO DE VIA", true));
                cuadra_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CUADRA", true));
                tipoVia_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "TV", true));
                numeroCuadras_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "NUMERO DE CUADRAS", true));
                estadoGeneralVia_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "EGV", true));
                nombreVia_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "NOMBRE DE VIA", true));
                limite_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "L", true));
                condicionLimite_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CL", true));
                toponimo_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "TOPONIMO", true));
                condicionNombreVia_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "CNV", true));
                clasificacionVia_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "CV", true));
                codigoViaMTC_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "CODIGO VIA MTC", true));

                puntoInicialX_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "PUNTO INICIAL X", true));
                puntoInicialY_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "PUNTO INICIAL Y", true));
                puntoInicialZ_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "PUNTO INICIAL Z", true));
                puntoFinalX_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "PUNTO FINAL X", true));
                puntoFinalY_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "PUNTO FINAL Y", true));
                puntoFinalZ_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "PUNTO FINAL Z", true));
                codigoHabilitacionUrbana_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CODIGO HABILITACION URBANA", true));
                nombreHabitacionUrbana_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "NOMBRE DE LA HABILITACION URBANA", true));
                zonaSectorEtapa_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "ZONA / SECTOR / ETAPA", true));
                //Calzada Carril
                //1
                calzadaCarril1Largo_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CALZADA CARRIL 1 LARGO", true));
                calzadaCarril1Ancho_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CALZADA CARRIL 1 ANCHO", true));
                calzadaCarril1Material_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CC1M", true));
                calzadaCarril1EstadoConservacion_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CC1ECS", true));
                calzadaCarril1Especificaciones_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CALZADA CARRIL 1 ESPECIFICACIONES", true));
                //2
                calzadaCarril2Largo_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CALZADA CARRIL 2 LARGO", true));
                calzadaCarril2Ancho_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CALZADA CARRIL 2 ANCHO", true));
                calzadaCarril2Material_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CC2M", true));
                calzadaCarril2EstadoConservacion_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CC2ECS", true));
                calzadaCarril2Especificaciones_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CALZADA CARRIL 2 ESPECIFICACIONES", true));
                //3
                calzadaCarril3Largo_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CALZADA CARRIL 3 LARGO", true));
                calzadaCarril3Ancho_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CALZADA CARRIL 3 ANCHO", true));
                calzadaCarril3Material_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CC3M", true));
                calzadaCarril3EstadoConservacion_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CC3ECS", true));
                calzadaCarril3Especificaciones_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CALZADA CARRIL 3 ESPECIFICACIONES", true));
                //4
                calzadaCarril4Largo_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CALZADA CARRIL 4 LARGO", true));
                calzadaCarril4Ancho_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CALZADA CARRIL 4 ANCHO", true));
                calzadaCarril4Material_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CC4M", true));
                calzadaCarril4EstadoConservacion_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CC4ECS", true));
                calzadaCarril4Especificaciones_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CALZADA CARRIL 4 ESPECIFICACIONES", true));
                //Veredas        
                //Derecha
                veredaDerechaLargo_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "VEREDAS DERECHA LARGO", true));
                veredaDerechaAncho_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "VEREDAS DERECHA ANCHO", true));
                veredaDerechaMaterial_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "VDM", true));
                veredaDerechaEstadoConservacion_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "VDECS", true));
                veredaDerechaEspecificaciones_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "VEREDAS DERECHA ESPECIFICACIONES", true));
                //Izquierda
                veredaIzquierdaLargo_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "VEREDAS IZQUIERDA LARGO", true));
                veredaIzquierdaAncho_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "VEREDAS IZQUIERDA ANCHO", true));
                veredaIzquierdaMaterial_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "VIM", true));
                veredaIzquierdaEstadoConservacion_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "VIECS", true));
                veredaIzquierdaEspecificaciones_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "VEREDAS IZQUIERDA ESPECIFICACIONES", true));
                //Central
                veredaCentralLargo_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "VEREDAS CENTRAL LARGO", true));
                veredaCentralAncho_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "VEREDAS CENTRAL ANCHO", true));
                veredaCentralMaterial_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "VCM", true));
                veredaCentralEstadoConservacion_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "VCECS", true));
                veredaCentralEspecificaciones_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "VEREDAS CENTRAL ESPECIFICACIONES", true));
                //Ciclo Via
                //Derecha
                cicloViaDerechaLargo_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CICLO VIA DERECHA LARGO", true));
                cicloViaDerechaAncho_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CICLO VIA DERECHA ANCHO", true));
                cicloViaDerechaMaterial_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CVDM", true));
                cicloViaDerechaEstadoConservacion_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CVDECS", true));
                cicloViaDerechaEspecificaciones_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CICLO VIA DERECHA ESPECIFICACIONES", true));
                //Izquierda
                cicloViaIzquierdaLargo_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CICLO VIA IZQUIERDA LARGO", true));
                cicloViaIzquierdaAncho_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CICLO VIA IZQUIERDA ANCHO", true));
                cicloViaIzquierdaMaterial_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CVIM", true));
                cicloViaIzquierdaEstadoConservacion_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CVIECS", true));
                cicloViaIzquierdaEspecificaciones_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CICLO VIA IZQUIERDA ESPECIFICACIONES", true));
                //Central
                cicloViaCentralLargo_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CICLO VIA CENTRAL LARGO", true));
                cicloViaCentralAncho_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CICLO VIA CENTRAL ANCHO", true));
                cicloViaCentralMaterial_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CVCM", true));
                cicloViaCentralEstadoConservacion_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CVCECS", true));
                cicloViaCentralEspecificaciones_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CICLO VIA CENTRAL ESPECIFICACIONES", true));
                //Via Ferea
                //Derecha
                viaFerreaDerechaLargo_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "VIA FERREA DERECHA LARGO", true));
                viaFerreaDerechaAncho_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "VIA FERREA DERECHA ANCHO", true));
                viaFerreaDerechaMaterial_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "VFDM", true));
                viaFerreaDerechaEstadoConservacion_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "VFDECS", true));
                viaFerreaDerechaEspecificaciones_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "VIA FERREA DERECHA ESPECIFICACIONES", true));
                //Izquierda
                viaFerreaIzquierdaLargo_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "VIA FERREA IZQUIERDA LARGO", true));
                viaFerreaIzquierdaAncho_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "VIA FERREA IZQUIERDA ANCHO", true));
                viaFerreaIzquierdaMaterial_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "VFIM", true));
                viaFerreaIzquierdaEstadoConservacion_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "VFIECS", true));
                viaFerreaIzquierdaEspecificaciones_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "VIA FERREA IZQUIERDA ESPECIFICACIONES", true));
                //Central
                viaFerreaCentralLargo_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "VIA FERREA CENTRAL LARGO", true));
                viaFerreaCentralAncho_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "VIA FERREA CENTRAL ANCHO", true));
                viaFerreaCentralMaterial_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "VFCM", true));
                viaFerreaCentralEstadoConservacion_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "VFCECS", true));
                viaFerreaCentralEspecificaciones_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "VIA FERREA CENTRAL ESPECIFICACIONES", true));
                //Berma
                //Derecha
                bermaDerechaLargo_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "BERMA DERECHA LARGO", true));
                bermaDerechaAncho_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "BERMA DERECHA ANCHO", true));
                bermaDerechaEstadoConservacion_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "BDECS", true));
                bermaDerechaEspecificaciones_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "BERMA DERECHA ESPECIFICACIONES", true));
                //Izquierda
                bermaIzquierdaLargo_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "BERMA IZQUIERDA LARGO", true));
                bermaIzquierdaAncho_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "BERMA IZQUIERDA ANCHO", true));
                bermaIzquierdaEstadoConservacion_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "BIECS", true));
                bermaIzquierdaEspecificaciones_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "BERMA IZQUIERDA ESPECIFICACIONES", true));
                //Central
                bermaCentralLargo_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "BERMA CENTRAL LARGO", true));
                bermaCentralAncho_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "BERMA CENTRAL ANCHO", true));
                bermaCentralEstadoConservacion_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "BCECS", true));
                bermaCentralEspecificaciones_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "BERMA CENTRAL ESPECIFICACIONES", true));
                //Observaciones
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

                #region Bindings - Fotografia
                FOTOGRAFIA_dgv.Columns["ID"].Visible = false;
                FOTOGRAFIA_dgv.Columns["ESTADO"].Visible = false;
                FOTOGRAFIA_dgv.Columns["USUARIO CREA"].Visible = false;
                FOTOGRAFIA_dgv.Columns["FECHA DE CREACION"].Visible = false;
                FOTOGRAFIA_dgv.Columns["USUARIO MODIFICA"].Visible = false;
                FOTOGRAFIA_dgv.Columns["FECHA DE MODIFICACION"].Visible = false;
                FOTOGRAFIA_dgv.Columns["FICHA"].Visible = false;
                ((DataGridViewImageColumn)FOTOGRAFIA_dgv.Columns["PLANO DE VIA"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                ((DataGridViewImageColumn)FOTOGRAFIA_dgv.Columns["SECCION TIPICA DE VIA"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                ((DataGridViewImageColumn)FOTOGRAFIA_dgv.Columns["FOTOGRAFIA DIGITAL"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                FOTOGRAFIA_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
                FOTOGRAFIA_dgv.RowTemplate.Height = 100;
                FOTOGRAFIA_dgv.ScrollBars = ScrollBars.Both;
                IDFotografia_lbl.DataBindings.Add(new Binding("Text", FOTOGRAFIA_bs, "ID", true));
                planoVia_pb.DataBindings.Add(new Binding("Image", FOTOGRAFIA_bs, "PLANO DE VIA", true));
                sectorPlanoVia_lbl.DataBindings.Add(new Binding("Text", FOTOGRAFIA_bs, "SECTOR", true));
                codigoViaPlanoVia_lbl.DataBindings.Add(new Binding("Text", FOTOGRAFIA_bs, "CODIGO DE VIA", true));
                cuadraPlanoVia_lbl.DataBindings.Add(new Binding("Text", FOTOGRAFIA_bs, "CUADRA", true));
                añoPlanoVia_txt.DataBindings.Add(new Binding("Text", FOTOGRAFIA_bs, "AÑO PLANO DE VIA", true));
                seccionTipicaVia_pb.DataBindings.Add(new Binding("Image", FOTOGRAFIA_bs, "SECCION TIPICA DE VIA", true));
                seccion_txt.DataBindings.Add(new Binding("Text", FOTOGRAFIA_bs, "SECCION", true));
                fotografiaDigital_pb.DataBindings.Add(new Binding("Image", FOTOGRAFIA_bs, "FOTOGRAFIA DIGITAL", true));
                sectorFotografiaDigital_lbl.DataBindings.Add(new Binding("Text", FOTOGRAFIA_bs, "SECTOR", true));
                codigoViaFotografiaDigital_lbl.DataBindings.Add(new Binding("Text", FOTOGRAFIA_bs, "CODIGO DE VIA", true));
                cuadraFotografiaDigital_lbl.DataBindings.Add(new Binding("Text", FOTOGRAFIA_bs, "CUADRA", true));
                añoFotografiaDigital_txt.DataBindings.Add(new Binding("Text", FOTOGRAFIA_bs, "AÑO FOTOGRAFIA DIGITAL", true));
                #endregion

                #region Bindings - Componente Urbano
                COMPONENTE_URBANO_dgv.Columns["ID"].Visible = false;
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
                COMPONENTE_URBANO_dgv.ScrollBars = ScrollBars.Both;
                IDComponenteUrbano_lbl.DataBindings.Add(new Binding("Text", COMPONENTE_URBANO_bs, "ID", true));
                fotografiaDigitalComponenteUrbano_pb.DataBindings.Add(new Binding("Image", COMPONENTE_URBANO_bs, "FOTOGRAFIA DIGITAL", true));
                sectorComponenteUrbano_lbl.DataBindings.Add(new Binding("Text", COMPONENTE_URBANO_bs, "SECTOR", true));
                codigoViaComponenteUrbano_lbl.DataBindings.Add(new Binding("Text", COMPONENTE_URBANO_bs, "CODIGO DE VIA", true));
                cuadraComponenteUrbano_lbl.DataBindings.Add(new Binding("Text", COMPONENTE_URBANO_bs, "CUADRA", true));
                añoComponenteUrbano_txt.DataBindings.Add(new Binding("Text", COMPONENTE_URBANO_bs, "AÑO", true));
                tipoComponenteUrbano_txt.DataBindings.Add(new Binding("Text", COMPONENTE_URBANO_bs, "TCU", true));
                cantidadComponenteUrbano_txt.DataBindings.Add(new Binding("Text", COMPONENTE_URBANO_bs, "CANTIDAD", true));
                materialComponenteUrbano_txt.DataBindings.Add(new Binding("Text", COMPONENTE_URBANO_bs, "M", true));
                estadoConservacionComponenteUrbano_txt.DataBindings.Add(new Binding("Text", COMPONENTE_URBANO_bs, "ECS", true));
                especificacionesComponenteUrbano_txt.DataBindings.Add(new Binding("Text", COMPONENTE_URBANO_bs, "ESPECIFICACIONES", true));
                #endregion

                #region Bindings - Mobiliario Urbano
                MOBILIARIO_URBANO_dgv.Columns["ID"].Visible = false;
                MOBILIARIO_URBANO_dgv.Columns["TMU"].Visible = false;
                MOBILIARIO_URBANO_dgv.Columns["M"].Visible = false;
                MOBILIARIO_URBANO_dgv.Columns["ECS"].Visible = false;
                MOBILIARIO_URBANO_dgv.Columns["ESTADO"].Visible = false;
                MOBILIARIO_URBANO_dgv.Columns["USUARIO CREA"].Visible = false;
                MOBILIARIO_URBANO_dgv.Columns["FECHA DE CREACION"].Visible = false;
                MOBILIARIO_URBANO_dgv.Columns["USUARIO MODIFICA"].Visible = false;
                MOBILIARIO_URBANO_dgv.Columns["FECHA DE MODIFICACION"].Visible = false;
                MOBILIARIO_URBANO_dgv.Columns["FICHA"].Visible = false;
                ((DataGridViewImageColumn)MOBILIARIO_URBANO_dgv.Columns["FOTOGRAFIA DIGITAL"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                MOBILIARIO_URBANO_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
                MOBILIARIO_URBANO_dgv.RowTemplate.Height = 100;
                MOBILIARIO_URBANO_dgv.ScrollBars = ScrollBars.Both;
                IDMobiliarioUrbano_lbl.DataBindings.Add(new Binding("Text", MOBILIARIO_URBANO_bs, "ID", true));
                fotografiaDigitalMobiliarioUrbano_pb.DataBindings.Add(new Binding("Image", MOBILIARIO_URBANO_bs, "FOTOGRAFIA DIGITAL", true));
                sectorMobiliarioUrbano_lbl.DataBindings.Add(new Binding("Text", MOBILIARIO_URBANO_bs, "SECTOR", true));
                codigoViaMobiliarioUrbano_lbl.DataBindings.Add(new Binding("Text", MOBILIARIO_URBANO_bs, "CODIGO DE VIA", true));
                cuadraMobiliarioUrbano_lbl.DataBindings.Add(new Binding("Text", MOBILIARIO_URBANO_bs, "CUADRA", true));
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

                //Fotografía
                iniciar_fotografia = true;
                aceptarFotografia.Enabled = false;

                //Componente Urbano        
                iniciar_componente_urbano = true;
                aceptarComponenteUrbano.Enabled = false;

                //Mobiliario Urbano        
                iniciar_componente_urbano = true;
                aceptarComponenteUrbano.Enabled = false;

                FICHA_bs.EndEdit();
                FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_VIAS_URBANASRow datos = FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_VIAS_URBANAS.FindByFICHA("0000000000");
                if (datos != null)
                {
                    datos.BeginEdit();
                    ficha_lbl.Text = (new cFicha_Catastral_Vias_Urbanas()).nuevo_codigo();
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
                    if (sector_txt.Text.Length != 2)
                    {
                        sector_txt_Leave(sender, e);
                        return;
                    }
                    if (codigoVia_txt.Text.Length != 3)
                    {
                        codigoVia_txt_Leave(sender, e);
                        return;
                    }
                    if (cuadra_txt.Text.Length != 2)
                    {
                        cuadra_txt_Leave(sender, e);
                        return;
                    }
                    if (numeroCuadras_txt.Text.Length == 0)
                    {
                        numeroCuadras_txt_Leave(sender, e);
                        return;
                    }

                    if (!buscar_estado_general_via())
                    {
                        estadoGeneralVia_txt_Leave(sender, e);
                        return;
                    }
                    if (!buscar_estado_llenado_ficha())
                    {
                        estadoLlenadoFicha_txt_Leave(sender, e);
                        return;
                    }
                    //Fotografía
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
                    //Componente Urbano
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
                    //Mobiliario Urbano
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
                FICHA_ds rpt = (new cFicha_Catastral_Vias_Urbanas()).reporte();
                if (rpt != null)
                {
                    DataView vista = rpt.VS_REPORTE_FICHA_CATASTRAL_VIAS_URBANAS.DefaultView;
                    vista.RowFilter = query;
                    DataTable tabla = vista.ToTable();
                    Reporte reporte = (tabla.Rows.Count > 0) ? new Reporte('1', tabla) : new Reporte('1', rpt);
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

        private void invertir_btn_Click(object sender, EventArgs e)
        {
            string tempA1, tempA2, tempA3;
            tempA1 = puntoFinalX_txt.Text;
            tempA2 = puntoFinalY_txt.Text;
            tempA3 = puntoFinalZ_txt.Text;

            puntoFinalX_txt.Text = puntoInicialX_txt.Text;
            puntoFinalY_txt.Text = puntoInicialY_txt.Text;
            puntoFinalZ_txt.Text = puntoInicialZ_txt.Text;

            puntoInicialX_txt.Text = tempA1;
            puntoInicialY_txt.Text = tempA2;
            puntoInicialZ_txt.Text = tempA3;

            invertir_btn.Text = (invertir_btn.Text == "<<") ? ">>" : "<<";
        }

        private void parcialFichas_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (parcialFichas_txt.Text.Length > 0)
                {
                    parcialFichas_lbl.BackColor = Color.DarkSeaGreen;
                    parcialFichas_txt.ForeColor = Color.Black;
                }
                else
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage1;
                    parcialFichas_lbl.BackColor = Color.Red;
                    parcialFichas_txt.Focus();
                    parcialFichas_txt.SelectAll();
                    parcialFichas_txt.ForeColor = Color.Red;
                }
            }
            else if (parcialFichas_lbl.BackColor == Color.Red) parcialFichas_lbl.BackColor = Color.DarkSeaGreen;
        }

        private void totalFichas_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (totalFichas_txt.Text.Length > 0)
                {
                    totalFichas_lbl.BackColor = Color.DarkSeaGreen;
                    totalFichas_txt.ForeColor = Color.Black;
                }
                else
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage1;
                    totalFichas_lbl.BackColor = Color.Red;
                    totalFichas_txt.Focus();
                    totalFichas_txt.SelectAll();
                    totalFichas_txt.ForeColor = Color.Red;
                }
            }
            else if (totalFichas_lbl.BackColor == Color.Red) totalFichas_lbl.BackColor = Color.DarkSeaGreen;
        }

        private void sector_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                //if (sector_txt.Text.Length == 2)
                if(buscar_sector())
                {
                    sector_lbl.BackColor = Color.DarkSeaGreen;
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
            else if (sector_lbl.BackColor == Color.Red) sector_lbl.BackColor = Color.DarkSeaGreen;
        }

        private void codigoVia_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                int i = (codigoVia_txt.Text.IndexOf('-') != -1) ? codigoVia_txt.Text.IndexOf('-') : codigoVia_txt.Text.Length + 1;
                codigoVia_txt.Text = (codigoVia_txt.Text.Length > 0) ? codigoVia_txt.Text.Substring(0, i - 1) : "";
                DataRow fila = vias.Buscar(codigoVia_txt.Text.Trim());
                if (fila == null)
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage1;
                    codigoVia_lbl.BackColor = Color.Red;
                    codigoVia_txt.Focus();
                    codigoVia_txt.SelectAll();
                    codigoVia_txt.ForeColor = Color.Red;
                    nombreHabitacionUrbana_lbl.Text = "";
                    nombreVia_lbl.Text = "";
                    tipoVia_lbl.Text = "";
                    toponimo_lbl.Text = "";
                    condicionNombreVia_lbl.Text = "";
                    numeroAcuerdo_lbl.Text = "";
                    clasificacionVia_lbl.Text = "";
                    codigoViaMTC_lbl.Text = "";
                }
                else
                {
                    codigoVia_lbl.BackColor = Color.DarkSeaGreen;
                    codigoVia_txt.ForeColor = Color.Black;
                    nombreVia_lbl.Text = fila["NOMBRE DE VIA"].ToString();
                    tipoVia_lbl.Text = fila["TV"].ToString();
                    toponimo_lbl.Text = fila["TOPONIMO"].ToString();
                    condicionNombreVia_lbl.Text = fila["CNV"].ToString();
                    numeroAcuerdo_lbl.Text = fila["NUMERO DE ACUERDO"].ToString();
                    clasificacionVia_lbl.Text = fila["CV"].ToString();
                    codigoViaMTC_lbl.Text = fila["CODIGO VIA MTC"].ToString();
                }
            }
            else if (codigoVia_lbl.BackColor == Color.Red) codigoVia_lbl.BackColor = Color.DarkSeaGreen;
        }

        private void cuadra_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (cuadra_txt.Text.Length == 2)
                {
                    cuadra_lbl.BackColor = Color.DarkSeaGreen;
                    cuadra_txt.ForeColor = Color.Black;
                }
                else
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage1;
                    cuadra_lbl.BackColor = Color.Red;
                    cuadra_txt.Focus();
                    cuadra_txt.SelectAll();
                    cuadra_txt.ForeColor = Color.Red;
                }
            }
            else if (cuadra_lbl.BackColor == Color.Red) cuadra_lbl.BackColor = Color.DarkSeaGreen;
        }

        private void numeroCuadras_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (numeroCuadras_txt.Text.Length > 0)
                {
                    numeroCuadras_lbl.BackColor = Color.DarkSeaGreen;
                    numeroCuadras_txt.ForeColor = Color.Black;
                }
                else
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage1;
                    numeroCuadras_lbl.BackColor = Color.Red;
                    numeroCuadras_txt.Focus();
                    numeroCuadras_txt.SelectAll();
                    numeroCuadras_txt.ForeColor = Color.Red;
                }
            }
            else if (numeroCuadras_lbl.BackColor == Color.Red) numeroCuadras_lbl.BackColor = Color.DarkSeaGreen;
        }

        private void estadoGeneralVia_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                estadoGeneralVia_txt.Text = (estadoGeneralVia_txt.Text.Length > 2) ? estadoGeneralVia_txt.Text.Substring(0, 2) : estadoGeneralVia_txt.Text;
                if (buscar_estado_general_via())
                {
                    estadoGeneralVia_lbl.BackColor = Color.DarkSeaGreen;
                    estadoGeneralVia_txt.ForeColor = Color.Black;
                }
                else
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage1;
                    estadoGeneralVia_lbl.BackColor = Color.Red;
                    estadoGeneralVia_txt.Focus();
                    estadoGeneralVia_txt.SelectAll();
                    estadoGeneralVia_txt.ForeColor = Color.Red;
                }
            }
            else if (estadoGeneralVia_lbl.BackColor == Color.Red) estadoGeneralVia_lbl.BackColor = Color.DarkSeaGreen;
        }

        private void limite_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                limite_txt.Text = (limite_txt.Text.Length > 2) ? limite_txt.Text.Substring(0, 2) : limite_txt.Text;
                if (buscar_limite())
                {
                    limite_lbl.BackColor = Color.DarkSeaGreen;
                    limite_txt.ForeColor = Color.Black;
                }
                else
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage1;
                    limite_lbl.BackColor = Color.Red;
                    limite_txt.Focus();
                    limite_txt.SelectAll();
                    limite_txt.ForeColor = Color.Red;

                }
            }
            else if (limite_lbl.BackColor == Color.Red) limite_lbl.BackColor = Color.DarkSeaGreen;
        }

        private void condicionLimite_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                condicionLimite_txt.Text = (condicionLimite_txt.Text.Length > 2) ? condicionLimite_txt.Text.Substring(0, 2) : condicionLimite_txt.Text;
                if (!buscar_condicion_limite())
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage1;
                    condicionLimite_lbl.BackColor = Color.Red;
                    condicionLimite_txt.Focus();
                    condicionLimite_txt.SelectAll();
                    condicionLimite_txt.ForeColor = Color.Red;
                }
                else
                {
                    condicionLimite_lbl.BackColor = Color.DarkSeaGreen;
                    condicionLimite_txt.ForeColor = Color.Black;
                }
            }
            else if (condicionLimite_lbl.BackColor == Color.Red) condicionLimite_lbl.BackColor = Color.DarkSeaGreen;
        }

        private void codigoHabilitacionUrbana_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (codigoHabilitacionUrbana_txt.Text.Length != 0)
                {
                    int i = (codigoHabilitacionUrbana_txt.Text.IndexOf('-') != -1) ? codigoHabilitacionUrbana_txt.Text.IndexOf('-') : codigoHabilitacionUrbana_txt.Text.Length;
                    codigoHabilitacionUrbana_txt.Text = (codigoHabilitacionUrbana_txt.Text.Length > 0) ? codigoHabilitacionUrbana_txt.Text.Substring(0, 2) : "";
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
                        codigoHabilitacionUrbana_lbl.BackColor = Color.DarkSeaGreen;
                        codigoHabilitacionUrbana_txt.ForeColor = Color.Black;
                        nombreHabitacionUrbana_lbl.Text = fila["DESCRIPCION"].ToString();
                    }
                }
                else
                {
                    codigoHabilitacionUrbana_lbl.BackColor = Color.DarkSeaGreen;
                    codigoHabilitacionUrbana_txt.ForeColor = Color.Black;
                    codigoHabilitacionUrbana_txt.Text = "";
                    nombreHabitacionUrbana_lbl.Text = "";
                }
            }
            else if (codigoHabilitacionUrbana_lbl.BackColor == Color.Red) codigoHabilitacionUrbana_lbl.BackColor = Color.DarkSeaGreen;
        }

        private void material_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                FormattedTextBox a = (FormattedTextBox)sender;
                a.Text = (a.Text.Length > 2) ? a.Text.Substring(0, 2) : a.Text;

                if (buscar_material(a.Text))
                {
                    material_lbl.BackColor = Color.DarkSeaGreen;
                    a.ForeColor = Color.Black;
                }
                else
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage3;
                    material_lbl.BackColor = Color.Red;
                    a.Focus();
                    a.SelectAll();
                    a.ForeColor = Color.Red;
                }
            }
            else if (material_lbl.BackColor == Color.Red) material_lbl.BackColor = Color.DarkSeaGreen;
        }

        private void estadoConservacion_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                FormattedTextBox a = (FormattedTextBox)sender;
                a.Text = (a.Text.Length > 2) ? a.Text.Substring(0, 2) : a.Text;
                if (buscar_estado_conservacion(a.Text))
                {
                    estadoConservacion_lbl.BackColor = Color.DarkSeaGreen;
                    a.ForeColor = Color.Black;
                }
                else
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage3;
                    estadoConservacion_lbl.BackColor = Color.Red;
                    a.Focus();
                    a.SelectAll();
                    a.ForeColor = Color.Red;
                }
            }
            else if (estadoConservacion_lbl.BackColor == Color.Red) estadoConservacion_lbl.BackColor = Color.DarkSeaGreen;
        }

        private void estadoLlenadoFicha_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                estadoLlenadoFicha_txt.Text = (estadoLlenadoFicha_txt.Text.Length > 2) ? estadoLlenadoFicha_txt.Text.Substring(0, 2) : estadoLlenadoFicha_txt.Text;
                if (buscar_estado_llenado_ficha())
                {
                    estadoLlenadoFicha_lbl.BackColor = Color.DarkSeaGreen;
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
            else if (estadoLlenadoFicha_lbl.BackColor == Color.Red) estadoLlenadoFicha_lbl.BackColor = Color.DarkSeaGreen;
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

        #region [ EVENTOS DE FICHA CATASTRAL DE VIAS URBANAS - FOTOGRAFIA ]
        private void nuevoFotografia_Click(object sender, EventArgs e)
        {
            if (sector_txt.Text.Length == 2 && codigoVia_txt.Text.Length == 3 && cuadra_txt.Text.Length == 2)
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
                planoVia_pb_Click(sender, e);
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
                if (seccion_txt.Text.Length == 0)
                {
                    seccion_txt_Leave(sender, e);
                    return;
                }

                if (aceptarFotografia.Text == "Agregar Fotografía")
                {
                    FOTOGRAFIA_bs.EndEdit();
                    long id = long.Parse(FOTOGRAFIA_dgv["ID", FOTOGRAFIA_dgv.CurrentRow.Index].Value.ToString());
                    FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_VIAS_URBANAS_FOTOGRAFIARow datos = FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_VIAS_URBANAS_FOTOGRAFIA.FindByID(id);
                    if (datos != null)
                    {
                        datos.BeginEdit();
                        datos.PLANO_DE_VIA = (planoVia_pb.Image != null) ? ((planoVia_pb.ImageLocation != null) ? File.ReadAllBytes(planoVia_pb.ImageLocation) : cConfiguracion.toBytes(planoVia_pb.Image)) : null;
                        datos.AÑO_PLANO_DE_VIA = (añoPlanoVia_txt.Text.Length == 0) ? DateTime.Now.Year.ToString() : añoPlanoVia_txt.Text.Trim();
                        datos.SECCION_TIPICA_DE_VIA = (seccionTipicaVia_pb.Image != null) ? ((seccionTipicaVia_pb.ImageLocation != null) ? File.ReadAllBytes(seccionTipicaVia_pb.ImageLocation) : cConfiguracion.toBytes(seccionTipicaVia_pb.Image)) : null;
                        datos.SECCION = seccion_txt.Text;
                        datos.FOTOGRAFIA_DIGITAL = (fotografiaDigital_pb.Image != null) ? ((fotografiaDigital_pb.ImageLocation != null) ? File.ReadAllBytes(fotografiaDigital_pb.ImageLocation) : cConfiguracion.toBytes(fotografiaDigital_pb.Image)) : null;
                        datos.AÑO_FOTOGRAFIA_DIGITAL = (añoFotografiaDigital_txt.Text.Length == 0) ? DateTime.Now.Year.ToString() : añoFotografiaDigital_txt.Text.Trim();
                        datos.SECTOR = sector_txt.Text;
                        datos.CODIGO_DE_VIA = codigoVia_txt.Text;
                        datos.CUADRA = cuadra_txt.Text;
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
                    fotografia_tc.SelectedTab = tabPage8;
                    habilitar_movimiento_fotografia = false;
                    habilitar_controles_fotografia = true;
                    aceptarFotografia.Text = "Aceptar";
                    aceptarFotografia.Image = null;
                    nuevoFotografia.Enabled = false;
                    eliminarFotografia.Enabled = false;
                    añoPlanoVia_txt.Focus();
                }
                else if (aceptarFotografia.Text == "Aceptar")
                {
                    FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_VIAS_URBANAS_FOTOGRAFIARow datos = FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_VIAS_URBANAS_FOTOGRAFIA.FindByID(long.Parse(IDFotografia_lbl.Text));
                    if (datos != null)
                    {
                        datos.BeginEdit();
                        datos.PLANO_DE_VIA = (planoVia_pb.Image != null) ? ((planoVia_pb.ImageLocation != null) ? File.ReadAllBytes(planoVia_pb.ImageLocation) : cConfiguracion.toBytes(planoVia_pb.Image)) : null;
                        datos.AÑO_PLANO_DE_VIA = (añoPlanoVia_txt.Text.Length == 0) ? DateTime.Now.Year.ToString() : añoPlanoVia_txt.Text.Trim();
                        datos.SECCION_TIPICA_DE_VIA = (seccionTipicaVia_pb.Image != null) ? ((seccionTipicaVia_pb.ImageLocation != null) ? File.ReadAllBytes(seccionTipicaVia_pb.ImageLocation) : cConfiguracion.toBytes(seccionTipicaVia_pb.Image)) : null;
                        datos.SECCION = seccion_txt.Text;
                        datos.FOTOGRAFIA_DIGITAL = (fotografiaDigital_pb.Image != null) ? ((fotografiaDigital_pb.ImageLocation != null) ? File.ReadAllBytes(fotografiaDigital_pb.ImageLocation) : cConfiguracion.toBytes(fotografiaDigital_pb.Image)) : null;
                        datos.AÑO_FOTOGRAFIA_DIGITAL = (añoFotografiaDigital_txt.Text.Length == 0) ? DateTime.Now.Year.ToString() : añoFotografiaDigital_txt.Text.Trim();
                        datos.SECTOR = sector_txt.Text;
                        datos.CODIGO_DE_VIA = codigoVia_txt.Text;
                        datos.CUADRA = cuadra_txt.Text;
                        datos.ESTADO = "A";
                        datos.USUARIO_CREA = Usuario;
                        datos.FECHA_DE_MODIFICACION = DateTime.Now;
                        datos.FICHA = ficha_lbl.Text.Trim();
                        datos.USUARIO_CREA = Usuario;
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

        private void planoVia_pb_Click(object sender, EventArgs e)
        {
            if (sector_txt.Text.Length == 2 && codigoVia_txt.Text.Length == 3 && cuadra_txt.Text.Length == 2)
            {
                DialogResult rpta = AbrirFotografia.ShowDialog();
                if (rpta == DialogResult.OK)
                {
                    planoVia_pb.ImageLocation = AbrirFotografia.FileName;
                    sectorPlanoVia_lbl.Text = sector_txt.Text;
                    codigoViaPlanoVia_lbl.Text = codigoVia_txt.Text;
                    cuadraPlanoVia_lbl.Text = cuadra_txt.Text;
                    añoPlanoVia_txt.Text = DateTime.Now.Year.ToString();
                }
                else
                {
                    planoVia_pb.ImageLocation = "";
                    sectorPlanoVia_lbl.Text = "";
                    codigoViaPlanoVia_lbl.Text = "";
                    cuadraPlanoVia_lbl.Text = "";
                    añoPlanoVia_txt.Text = "";
                }
                añoPlanoVia_txt.Focus();
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage1;
                fotografia_tc.SelectedTab = tabPage8;
                if (sector_txt.Text.Length == 0) sector_txt.Focus();
                if (codigoVia_txt.Text.Length == 0) codigoVia_txt.Focus();
                if (cuadra_txt.Text.Length == 0) cuadra_txt.Focus();
            }
        }

        private void añoPlanoVia_txt_Leave(object sender, EventArgs e)
        {
            if (añoPlanoVia_txt.Text.Length == 4 || añoPlanoVia_txt.Text.Length == 0)
            {
                añoPlanoVia_lbl.BackColor = Color.DarkSeaGreen;
                añoPlanoVia_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage2;
                fotografia_tc.SelectedTab = tabPage8;
                añoPlanoVia_lbl.BackColor = Color.Red;
                añoPlanoVia_txt.Focus();
                añoPlanoVia_txt.SelectAll();
                añoPlanoVia_txt.ForeColor = Color.Red;
            }
            if (añoPlanoVia_lbl.BackColor == Color.Red && añoPlanoVia_txt.Enabled == false) añoPlanoVia_lbl.BackColor = Color.DarkSeaGreen;
        }

        private void seccionTipicaVia_pb_Click(object sender, EventArgs e)
        {
            DialogResult rpta = AbrirFotografia.ShowDialog();
            if (rpta == DialogResult.OK) seccionTipicaVia_pb.ImageLocation = AbrirFotografia.FileName;
            else
            {
                seccionTipicaVia_pb.ImageLocation = "";
                seccion_txt.Text = "";
            }
            seccion_txt.Focus();
        }

        private void seccion_txt_Leave(object sender, EventArgs e)
        {
            if (seccion_txt.Text.Length > 0)
            {
                seccion_lbl.BackColor = Color.DarkSeaGreen;
                seccion_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage2;
                fotografia_tc.SelectedTab = tabPage8;
                seccion_lbl.BackColor = Color.Red;
                seccion_txt.Focus();
                seccion_txt.SelectAll();
                seccion_txt.ForeColor = Color.Red;
            }
            if (seccion_lbl.BackColor == Color.Red && seccion_txt.Enabled == false) seccion_lbl.BackColor = Color.DarkSeaGreen;
        }

        private void fotografiaDigital_pb_Click(object sender, EventArgs e)
        {
            if (sector_txt.Text.Length == 2 && codigoVia_txt.Text.Length == 3 && cuadra_txt.Text.Length == 2)
            {
                DialogResult rpta = AbrirFotografia.ShowDialog();
                if (rpta == DialogResult.OK)
                {
                    fotografiaDigital_pb.ImageLocation = AbrirFotografia.FileName;
                    sectorFotografiaDigital_lbl.Text = sector_txt.Text;
                    codigoViaFotografiaDigital_lbl.Text = codigoVia_txt.Text;
                    cuadraFotografiaDigital_lbl.Text = cuadra_txt.Text;
                    añoFotografiaDigital_txt.Text = DateTime.Now.Year.ToString();
                }
                else
                {
                    fotografiaDigital_pb.ImageLocation = (AbrirFotografia.FileName != "") ? AbrirFotografia.FileName : "";
                    sectorFotografiaDigital_lbl.Text = "";
                    codigoViaFotografiaDigital_lbl.Text = "";
                    cuadraFotografiaDigital_lbl.Text = "";
                    añoFotografiaDigital_txt.Text = "";
                }
                añoFotografiaDigital_txt.Focus();
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage1;
                if (sector_txt.Text.Length == 0) sector_txt.Focus();
                if (codigoVia_txt.Text.Length == 0) codigoVia_txt.Focus();
                if (cuadra_txt.Text.Length == 0) cuadra_txt.Focus();
            }
        }

        private void añoFotografiaDigital_txt_Leave(object sender, EventArgs e)
        {
            if (añoFotografiaDigital_txt.Text.Length == 4 || añoFotografiaDigital_txt.Text.Length == 0)
            {
                añoFotografiaDigital_lbl.BackColor = Color.DarkSeaGreen;
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
            if (añoFotografiaDigital_lbl.BackColor == Color.Red && añoFotografiaDigital_txt.Enabled == false) añoFotografiaDigital_lbl.BackColor = Color.DarkSeaGreen;
        }

        private void FOTOGRAFIA_dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion

        #region [ EVENTOS DE FICHA CATASTRAL DE VIAS URBANAS - COMPONENTE URBANO ]
        private void nuevoComponenteUrbano_Click(object sender, EventArgs e)
        {
            if (sector_txt.Text.Length == 2 && codigoVia_txt.Text.Length == 3 && cuadra_txt.Text.Length == 2)
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
                    FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_VIAS_URBANAS_COMPONENTE_URBANORow datos = FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_VIAS_URBANAS_COMPONENTE_URBANO.FindByID(id);
                    if (datos != null)
                    {
                        datos.BeginEdit();
                        datos.FOTOGRAFIA_DIGITAL = (fotografiaDigitalComponenteUrbano_pb.Image != null) ? ((fotografiaDigitalComponenteUrbano_pb.ImageLocation != null) ? File.ReadAllBytes(fotografiaDigitalComponenteUrbano_pb.ImageLocation) : cConfiguracion.toBytes(fotografiaDigitalComponenteUrbano_pb.Image)) : null;
                        datos.AÑO = (añoComponenteUrbano_txt.Text.Length == 0) ? DateTime.Now.Year.ToString() : añoComponenteUrbano_txt.Text.Trim();
                        datos.SECTOR = sector_txt.Text;
                        datos.CODIGO_DE_VIA = codigoVia_txt.Text;
                        datos.CUADRA = cuadra_txt.Text;
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
                    FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_VIAS_URBANAS_COMPONENTE_URBANORow datos = FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_VIAS_URBANAS_COMPONENTE_URBANO.FindByID(long.Parse(IDComponenteUrbano_lbl.Text));
                    if (datos != null)
                    {
                        datos.BeginEdit();
                        datos.FOTOGRAFIA_DIGITAL = (fotografiaDigitalComponenteUrbano_pb.Image != null) ? ((fotografiaDigitalComponenteUrbano_pb.ImageLocation != null) ? File.ReadAllBytes(fotografiaDigitalComponenteUrbano_pb.ImageLocation) : cConfiguracion.toBytes(fotografiaDigitalComponenteUrbano_pb.Image)) : null;
                        datos.AÑO = (añoComponenteUrbano_txt.Text.Length == 0) ? DateTime.Now.Year.ToString() : añoComponenteUrbano_txt.Text.Trim();
                        datos.SECTOR = sector_txt.Text;
                        datos.CODIGO_DE_VIA = codigoVia_txt.Text;
                        datos.CUADRA = cuadra_txt.Text;
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
            if (sector_txt.Text.Length == 2 && codigoVia_txt.Text.Length == 3 && cuadra_txt.Text.Length == 2)
            {
                DialogResult rpta = AbrirFotografia.ShowDialog();
                if (rpta == DialogResult.OK)
                {
                    fotografiaDigitalComponenteUrbano_pb.ImageLocation = AbrirFotografia.FileName;
                    sectorComponenteUrbano_lbl.Text = sector_txt.Text;
                    codigoViaComponenteUrbano_lbl.Text = codigoVia_txt.Text;
                    cuadraComponenteUrbano_lbl.Text = cuadra_txt.Text;
                    añoComponenteUrbano_txt.Text = DateTime.Now.Year.ToString();
                }
                else
                {
                    fotografiaDigitalComponenteUrbano_pb.ImageLocation = "";
                    sectorComponenteUrbano_lbl.Text = "";
                    codigoViaComponenteUrbano_lbl.Text = "";
                    cuadraComponenteUrbano_lbl.Text = "";
                    añoComponenteUrbano_txt.Text = "";
                }
                añoComponenteUrbano_txt.Focus();
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage1;
                if (sector_txt.Text.Length == 0) sector_txt.Focus();
                if (codigoVia_txt.Text.Length == 0) codigoVia_txt.Focus();
                if (cuadra_txt.Text.Length == 0) cuadra_txt.Focus();
            }
        }

        private void añoComponenteUrbano_txt_Leave(object sender, EventArgs e)
        {
            if (añoComponenteUrbano_txt.Text.Length == 4 || añoComponenteUrbano_txt.Text.Length == 0)
            {
                añoComponenteUrbano_lbl.BackColor = Color.DarkSeaGreen;
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
            if (añoComponenteUrbano_lbl.BackColor == Color.Red && añoComponenteUrbano_txt.Enabled == false) añoComponenteUrbano_lbl.BackColor = Color.DarkSeaGreen;
        }

        private void tipoComponenteUrbano_txt_Leave(object sender, EventArgs e)
        {
            tipoComponenteUrbano_txt.Text = (tipoComponenteUrbano_txt.Text.Length > 2) ? tipoComponenteUrbano_txt.Text.Substring(0, 2) : tipoComponenteUrbano_txt.Text;
            if (buscar_tipo_componente_urbano())
            {
                tipoComponenteUrbano_lbl.BackColor = Color.DarkSeaGreen;
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
            if (tipoComponenteUrbano_lbl.BackColor == Color.Red && tipoComponenteUrbano_txt.Enabled == false) tipoComponenteUrbano_lbl.BackColor = Color.DarkSeaGreen;
        }

        private void cantidadComponenteUrbano_txt_Leave(object sender, EventArgs e)
        {
            if (cantidadComponenteUrbano_txt.Text.Length > 0)
            {
                cantidadComponenteUrbano_lbl.BackColor = Color.DarkSeaGreen;
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
            if (cantidadComponenteUrbano_lbl.BackColor == Color.Red && cantidadComponenteUrbano_txt.Enabled == false) cantidadComponenteUrbano_lbl.BackColor = Color.DarkSeaGreen;
        }

        private void materialComponenteUrbano_txt_Leave(object sender, EventArgs e)
        {
            materialComponenteUrbano_txt.Text = (materialComponenteUrbano_txt.Text.Length > 2) ? materialComponenteUrbano_txt.Text.Substring(0, 2) : materialComponenteUrbano_txt.Text;
            if (buscar_material_componente_urbano())
            {
                materialComponenteUrbano_lbl.BackColor = Color.DarkSeaGreen;
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
            if (materialComponenteUrbano_lbl.BackColor == Color.Red && materialComponenteUrbano_txt.Enabled == false) materialComponenteUrbano_lbl.BackColor = Color.DarkSeaGreen;
        }

        private void estadoConservacionComponenteUrbano_txt_Leave(object sender, EventArgs e)
        {
            estadoConservacionComponenteUrbano_txt.Text = (estadoConservacionComponenteUrbano_txt.Text.Length > 2) ? estadoConservacionComponenteUrbano_txt.Text.Substring(0, 2) : estadoConservacionComponenteUrbano_txt.Text;
            if (buscar_estado_conservacion_componente_urbano())
            {
                estadoConservacionComponenteUrbano_lbl.BackColor = Color.DarkSeaGreen;
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
            if (estadoConservacionComponenteUrbano_lbl.BackColor == Color.Red && estadoConservacionComponenteUrbano_txt.Enabled == false) estadoConservacionComponenteUrbano_lbl.BackColor = Color.DarkSeaGreen;
        }

        private void COMPONENTE_URBANO_dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion

        #region [ EVENTOS DE FICHA CATASTRAL DE VIAS URBANAS - COMPONENTE URBANO ]
        private void nuevoMobiliarioUrbano_Click(object sender, EventArgs e)
        {
            if (sector_txt.Text.Length == 2 && codigoVia_txt.Text.Length == 3 && cuadra_txt.Text.Length == 2)
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
                    FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_VIAS_URBANAS_MOBILIARIO_URBANORow datos = FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_VIAS_URBANAS_MOBILIARIO_URBANO.FindByID(id);
                    if (datos != null)
                    {
                        datos.BeginEdit();
                        datos.FOTOGRAFIA_DIGITAL = (fotografiaDigitalMobiliarioUrbano_pb.Image != null) ? ((fotografiaDigitalMobiliarioUrbano_pb.ImageLocation != null) ? File.ReadAllBytes(fotografiaDigitalMobiliarioUrbano_pb.ImageLocation) : cConfiguracion.toBytes(fotografiaDigitalMobiliarioUrbano_pb.Image)) : null;
                        datos.AÑO = (añoMobiliarioUrbano_txt.Text.Length == 0) ? DateTime.Now.Year.ToString() : añoMobiliarioUrbano_txt.Text.Trim();
                        datos.SECTOR = sector_txt.Text;
                        datos.CODIGO_DE_VIA = codigoVia_txt.Text;
                        datos.CUADRA = cuadra_txt.Text;
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
                    FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_VIAS_URBANAS_MOBILIARIO_URBANORow datos = FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_VIAS_URBANAS_MOBILIARIO_URBANO.FindByID(long.Parse(IDMobiliarioUrbano_lbl.Text));
                    if (datos != null)
                    {
                        datos.BeginEdit();
                        datos.FOTOGRAFIA_DIGITAL = (fotografiaDigitalMobiliarioUrbano_pb.Image != null) ? ((fotografiaDigitalMobiliarioUrbano_pb.ImageLocation != null) ? File.ReadAllBytes(fotografiaDigitalMobiliarioUrbano_pb.ImageLocation) : cConfiguracion.toBytes(fotografiaDigitalMobiliarioUrbano_pb.Image)) : null;
                        datos.AÑO = (añoMobiliarioUrbano_txt.Text.Length == 0) ? DateTime.Now.Year.ToString() : añoMobiliarioUrbano_txt.Text.Trim();
                        datos.SECTOR = sector_txt.Text;
                        datos.CODIGO_DE_VIA = codigoVia_txt.Text;
                        datos.CUADRA = cuadra_txt.Text;
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
            if (sector_txt.Text.Length == 2 && codigoVia_txt.Text.Length == 3 && cuadra_txt.Text.Length == 2)
            {
                DialogResult rpta = AbrirFotografia.ShowDialog();
                if (rpta == DialogResult.OK)
                {
                    fotografiaDigitalMobiliarioUrbano_pb.ImageLocation = AbrirFotografia.FileName;
                    sectorMobiliarioUrbano_lbl.Text = sector_txt.Text;
                    codigoViaMobiliarioUrbano_lbl.Text = codigoVia_txt.Text;
                    cuadraMobiliarioUrbano_lbl.Text = cuadra_txt.Text;
                    añoMobiliarioUrbano_txt.Text = DateTime.Now.Year.ToString();
                }
                else
                {
                    fotografiaDigitalMobiliarioUrbano_pb.ImageLocation = "";
                    sectorMobiliarioUrbano_lbl.Text = "";
                    codigoViaMobiliarioUrbano_lbl.Text = "";
                    cuadraMobiliarioUrbano_lbl.Text = "";
                    añoMobiliarioUrbano_txt.Text = "";
                }
                añoMobiliarioUrbano_txt.Focus();
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage1;
                if (sector_txt.Text.Length == 0) sector_txt.Focus();
                if (codigoVia_txt.Text.Length == 0) codigoVia_txt.Focus();
                if (cuadra_txt.Text.Length == 0) cuadra_txt.Focus();
            }
        }

        private void añoMobiliarioUrbano_txt_Leave(object sender, EventArgs e)
        {
            if (añoMobiliarioUrbano_txt.Text.Length == 4 || añoMobiliarioUrbano_txt.Text.Length == 0)
            {
                añoMobiliarioUrbano_lbl.BackColor = Color.DarkSeaGreen;
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
            if (añoMobiliarioUrbano_lbl.BackColor == Color.Red && añoMobiliarioUrbano_txt.Enabled == false) añoMobiliarioUrbano_lbl.BackColor = Color.DarkSeaGreen;
        }

        private void tipoMobiliarioUrbano_txt_Leave(object sender, EventArgs e)
        {
            tipoMobiliarioUrbano_txt.Text = (tipoMobiliarioUrbano_txt.Text.Length > 2) ? tipoMobiliarioUrbano_txt.Text.Substring(0, 2) : tipoMobiliarioUrbano_txt.Text;
            if (buscar_tipo_mobiliario_urbano())
            {
                tipoMobiliarioUrbano_lbl.BackColor = Color.DarkSeaGreen;
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
            if (tipoMobiliarioUrbano_lbl.BackColor == Color.Red && tipoMobiliarioUrbano_txt.Enabled == false) tipoMobiliarioUrbano_lbl.BackColor = Color.DarkSeaGreen;
        }

        private void cantidadMobiliarioUrbano_txt_Leave(object sender, EventArgs e)
        {
            if (cantidadMobiliarioUrbano_txt.Text.Length > 0)
            {
                cantidadMobiliarioUrbano_lbl.BackColor = Color.DarkSeaGreen;
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
            if (cantidadMobiliarioUrbano_lbl.BackColor == Color.Red && cantidadMobiliarioUrbano_txt.Enabled == false) cantidadMobiliarioUrbano_lbl.BackColor = Color.DarkSeaGreen;
        }

        private void materialMobiliarioUrbano_txt_Leave(object sender, EventArgs e)
        {
            materialMobiliarioUrbano_txt.Text = (materialMobiliarioUrbano_txt.Text.Length > 2) ? materialMobiliarioUrbano_txt.Text.Substring(0, 2) : materialMobiliarioUrbano_txt.Text;
            if (buscar_material_mobiliario_urbano())
            {
                materialMobiliarioUrbano_lbl.BackColor = Color.DarkSeaGreen;
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
            if (materialMobiliarioUrbano_lbl.BackColor == Color.Red && materialMobiliarioUrbano_txt.Enabled == false) materialMobiliarioUrbano_lbl.BackColor = Color.DarkSeaGreen;
        }

        private void estadoConservacionMobiliarioUrbano_txt_Leave(object sender, EventArgs e)
        {
            estadoConservacionMobiliarioUrbano_txt.Text = (estadoConservacionMobiliarioUrbano_txt.Text.Length > 2) ? estadoConservacionMobiliarioUrbano_txt.Text.Substring(0, 2) : estadoConservacionMobiliarioUrbano_txt.Text;
            if (buscar_estado_conservacion_mobiliario_urbano())
            {
                estadoConservacionMobiliarioUrbano_lbl.BackColor = Color.DarkSeaGreen;
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
            if (estadoConservacionMobiliarioUrbano_lbl.BackColor == Color.Red && estadoConservacionMobiliarioUrbano_txt.Enabled == false) estadoConservacionMobiliarioUrbano_lbl.BackColor = Color.DarkSeaGreen;
        }

        private void MOBILIARIO_URBANO_dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion
        #endregion
    }
}