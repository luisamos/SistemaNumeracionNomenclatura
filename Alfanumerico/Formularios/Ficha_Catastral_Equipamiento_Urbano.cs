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
    internal partial class Ficha_Catastral_Equipamiento_Urbano : Ficha
    {
        internal Ficha_Catastral_Equipamiento_Urbano()
        {
            InitializeComponent();
            //Ficha Catastral de Equipamiento Urbano
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
            edifica_txt.Leave += new EventHandler(edifica_txt_Leave);
            entrada_txt.Leave += new EventHandler(entrada_txt_Leave);
            piso_txt.Leave += new EventHandler(piso_txt_Leave);
            unidad_txt.Leave += new EventHandler(unidad_txt_Leave);
            nombreEquipamientoUrbano_txt.Leave += new EventHandler(nombreEquipamientoUrbano_txt_Leave);
            tipoEquipamientoUrbano_txt.Leave += new EventHandler(tipoEquipamientoUrbano_txt_Leave);
            codigoHabilitacionUrbana_txt.Leave += new EventHandler(codigoHabilitacionUrbana_txt_Leave);
            codigoUsos_txt.Leave += new EventHandler(codigoUsos_txt_Leave);
            estadoLlenadoFicha_txt.Leave += new EventHandler(estadoLlenadoFicha_txt_Leave);   
            //Ubicación          
            nuevoUbicacion.Click += new EventHandler(nuevoUbicacion_Click);
            eliminarUbicacion.Click += new EventHandler(eliminarUbicacion_Click);
            aceptarUbicacion.Click += new EventHandler(aceptarUbicacion_Click);
            cancelarUbicacion.Click += new EventHandler(cancelarUbicacion_Click);
            sectorUbicacion_txt.Leave += new EventHandler(sectorUbicacion_txt_Leave);
            codigoViaUbicacion_txt.Leave += new EventHandler(codigoViaUbicacion_txt_Leave);
            cuadraUbicacion_txt.Leave += new EventHandler(cuadraUbicacion_txt_Leave);
            tipoPuertaUbicacion_txt.Leave += new EventHandler(tipoPuertaUbicacion_txt_Leave);
            condicionNumeracionUbicacion_txt.Leave += new EventHandler(condicionNumeracionUbicacion_txt_Leave);
            UBICACION_dgv.DataError += new DataGridViewDataErrorEventHandler(UBICACION_dgv_DataError);
            //Fotografía
            nuevoFotografia.Click += new EventHandler(nuevoFotografia_Click);
            eliminarFotografia.Click += new EventHandler(eliminarFotografia_Click);
            aceptarFotografia.Click += new EventHandler(aceptarFotografia_Click);
            cancelarFotografia.Click += new EventHandler(cancelarFotografia_Click);
            planoUbicacion_pb.Click += new EventHandler(planoUbicacion_pb_Click);
            añoPlanoUbicacion_txt.Leave += new EventHandler(añoPlanoUbicacion_txt_Leave);
            fotografiaDigital_pb.Click += new EventHandler(fotografiaDigital_pb_Click);
            añoFotografiaDigital_txt.Leave += new EventHandler(añoFotografiaDigital_txt_Leave);
            FOTOGRAFIA_dgv.DataError += new DataGridViewDataErrorEventHandler(FOTOGRAFIA_dgv_DataError);             
        }

        #region Variables Globales
        ComponentResourceManager resources = new ComponentResourceManager(typeof(Ficha_Catastral_Equipamiento_Urbano));   
        //Ficha Catastral de Equipamiento Urbano
        cTipo_Equipamiento_Urbano tipo_equipamiento_urbano = new cTipo_Equipamiento_Urbano();
        cHabilitacion_Urbana habilitacion_urbana = new cHabilitacion_Urbana();
        cUsos usos = new cUsos();
        cEstado_Llenado_Ficha estado_llenado_ficha = new cEstado_Llenado_Ficha();        
        cPersonal supervisor = new cPersonal();
        cPersonal tecnico_catastral = new cPersonal();
        cPersonal digitacion = new cPersonal();        
        //Ubicación
        cVias vias = new cVias();
        cTipo_Puerta tipo_puerta = new cTipo_Puerta();
        cCondicion_Numeracion condicion_numeracion = new cCondicion_Numeracion();
        #endregion

        #region Propiedades
        #region [ PROPIEDADES DE FICHA CATASTRAL DE EQUIPAMIENTO URBANO ]
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
                coleccionControles.ForEach(a => a.Enabled = value);

                FICHA_dgv.Enabled = !value;
                categoria_tsc.Enabled = !value;
                buscar_tst.Enabled = !value;                
                //Ubicacion                
                iniciar_ubicacion = false;
                habilitar_movimiento_ubicacion = !value;
                habilitar_controles_ubicacion = false;                
                //Fotografia
                iniciar_fotografia = false;
                habilitar_movimiento_fotografia = !value;
                habilitar_controles_fotografia = false;
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
                int total = labelCantidad1.Count() + labelCantidad3.Count();                
                return total == 0 && sector_txt.Text.Length == 2 && manzana_txt.Text.Length == 3 && nombreEquipamientoUrbano_txt.Text.Length > 0 && tipoEquipamientoUrbano_txt.Text.Length == 2 && estadoLlenadoFicha_txt.Text.Length ==2 &&
                    ((aceptarUbicacion.ForeColor != Color.Red) ? true : false) && ((aceptarFotografia.ForeColor != Color.Red) ? true : false);
            }
        }
        #endregion

        #region [ PROPIEDADES DE FICHA CATASTRAL DE EQUIPAMIENTO URBANO - UBICACION ]
        bool habilitar_movimiento_ubicacion
        {
            set
            {
                inicioUbicacion.Enabled = (posicionUbicacion.Text == "0" || posicionUbicacion.Text == "1") ? false : value;
                anteriorUbicacion.Enabled = (posicionUbicacion.Text == "0" || posicionUbicacion.Text == "1") ? false : value;
                posicionUbicacion.Enabled = (UBICACION_dgv.RowCount==0) ? false : value;
                siguienteUbicacion.Enabled = (posicionUbicacion.Text == contadorUbicacion.Text.Substring(3)) ? false : value;
                finUbicacion.Enabled = (posicionUbicacion.Text == contadorUbicacion.Text.Substring(3)) ? false : value;
                nuevoUbicacion.Enabled = !value;
                aceptarUbicacion.Enabled = !value;
                eliminarUbicacion.Enabled = !value;
                cancelarUbicacion.Enabled = !value;
            }
        }
        bool habilitar_controles_ubicacion
        {
            get { return sectorUbicacion_txt.Enabled; }
            set 
            {
                sectorUbicacion_txt.Enabled = value;
                codigoViaUbicacion_txt.Enabled = value;
                cuadraUbicacion_txt.Enabled = value;
                tipoViaUbicacion_lbl.Enabled = value;
                nombreViaUbicacion_lbl.Enabled = value;
                tipoPuertaUbicacion_txt.Enabled = value;
                numeroMunicipalUbicacion_txt.Enabled = value;
                condicionNumeracionUbicacion_txt.Enabled = value;
                numeroCertificadoNumeracionUbicacion_txt.Enabled = value;
                UBICACION_dgv.Enabled = !value;
            }
        }
        bool iniciar_ubicacion
        {
            set
            {
                ubicacion_tc.SelectedTab = tabPage5;
                nuevoUbicacion.Enabled = value;
                aceptarUbicacion.ForeColor = Color.Black;
                aceptarUbicacion.Enabled = false;
                eliminarUbicacion.Enabled = false;
                cancelarUbicacion.Enabled = false;
                if (UBICACION_dgv.RowCount > 0)
                {
                    aceptarUbicacion.Enabled = value;
                    aceptarUbicacion.Text = "Modificar Ubicación";
                    aceptarUbicacion.Image = null;
                    eliminarUbicacion.Enabled = value;
                }                
            }
        }
        #endregion

        #region [ PROPIEDADES DE FICHA CATASTRAL DE EQUIPAMIENTO URBANO - FOTOGRAFIA ]
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
            set {
                planoUbicacion_pb.Enabled = value;
                sectorPlanoUbicacion_lbl.Enabled = value;
                manzanaPlanoUbicacion_lbl.Enabled = value;
                lotePlanoUbicacion_lbl.Enabled = value;
                edificaPlanoUbicacion_lbl.Enabled = value;
                añoPlanoUbicacion_txt.Enabled = value;
                fotografiaDigital_pb.Enabled = value;
                sectorFotografiaDigital_lbl.Enabled = value;
                manzanaFotografiaDigital_lbl.Enabled = value;
                loteFotografiaDigital_lbl.Enabled = value;
                edificaFotografiaDigital_lbl.Enabled = value;
                añoFotografiaDigital_txt.Enabled = value;
                FOTOGRAFIA_dgv.Enabled = !value;               
            }
        }
        bool iniciar_fotografia
        {
            set
            {
                fotografia_tc.SelectedTab = tabPage7;
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
        #endregion

        #region Metodos
        #region [ METODOS DE FICHA CATASTRAL DE EQUIPAMIENTO URBANO ]
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
            //Ficha Catastral de Equipamiento Urbano
            cFicha_Catastral_Equipamiento_Urbano ficha_catastral_equipamiento_urbano = new cFicha_Catastral_Equipamiento_Urbano();
            FICHA_ds = ficha_catastral_equipamiento_urbano.listar();
            base.refrescar();            
                        
            this.FICHA_bs.DataMember = "VS_LISTAR_FICHA_CATASTRAL_EQUIPAMIENTO_URBANO";
            this.FICHA_bs.DataSource = FICHA_ds;

            //Ubicación
            this.UBICACION_bn.BindingSource = UBICACION_bs;
            this.UBICACION_dgv.DataSource = UBICACION_bs;
            this.UBICACION_bs.DataMember = "EQUIPAMIENTO_URBANO_FK_UBICACION";
            this.UBICACION_bs.DataSource = FICHA_bs;

            //Fotografía Digital
            this.FOTOGRAFIA_bn.BindingSource = FOTOGRAFIA_bs;
            this.FOTOGRAFIA_dgv.DataSource = FOTOGRAFIA_bs;
            this.FOTOGRAFIA_bs.DataMember = "EQUIPAMIENTO_URBANO_FK_FOTOGRAFIA";
            this.FOTOGRAFIA_bs.DataSource = FICHA_bs;
        }
        void guardar()
        {
            if (validar)
            {
                cFicha_Catastral_Equipamiento_Urbano ficha_catastral_equipamiento_urbano = new cFicha_Catastral_Equipamiento_Urbano();
                ficha_catastral_equipamiento_urbano.Ficha = ficha_lbl.Text.Trim();
                ficha_catastral_equipamiento_urbano.Parcial_Ficha = parcialFichas_txt.Text;
                ficha_catastral_equipamiento_urbano.Total_Fichas = totalFichas_txt.Text;
                ficha_catastral_equipamiento_urbano.Codigo_Unico_Catastral = codigoUnicoCatastral_txt.Text;
                ficha_catastral_equipamiento_urbano.Codigo_Hoja_Catastral = codigoHojaCatastral_txt.Text;
                ficha_catastral_equipamiento_urbano.Departamento = departamento_lbl.Text;
                ficha_catastral_equipamiento_urbano.Provincia = provincia_lbl.Text;
                ficha_catastral_equipamiento_urbano.Distrito = distrito_lbl.Text;
                ficha_catastral_equipamiento_urbano.Sector = sector_txt.Text;
                ficha_catastral_equipamiento_urbano.Manzana = manzana_txt.Text;
                ficha_catastral_equipamiento_urbano.Lote = lote_txt.Text;
                ficha_catastral_equipamiento_urbano.Edifica = edifica_txt.Text;
                ficha_catastral_equipamiento_urbano.Entrada = entrada_txt.Text;
                ficha_catastral_equipamiento_urbano.Piso = piso_txt.Text;
                ficha_catastral_equipamiento_urbano.Unidad = unidad_txt.Text;
                ficha_catastral_equipamiento_urbano.Nombre_Equipamiento_Urbano = nombreEquipamientoUrbano_txt.Text;
                tipo_equipamiento_urbano.Codigo = tipoEquipamientoUrbano_txt.Text;
                ficha_catastral_equipamiento_urbano.Tipo_Equipamiento_Urbano = tipo_equipamiento_urbano;
                ficha_catastral_equipamiento_urbano.Punto_X = puntoX_txt.Text;
                ficha_catastral_equipamiento_urbano.Punto_Y = puntoY_txt.Text;
                ficha_catastral_equipamiento_urbano.Punto_Z = "0";
                //Habilitación Urbana
                habilitacion_urbana.Codigo = (codigoHabilitacionUrbana_txt.Text.Length > 0) ? codigoHabilitacionUrbana_txt.Text : null;
                ficha_catastral_equipamiento_urbano.Habilitacion_Urbana = habilitacion_urbana;
                //
                ficha_catastral_equipamiento_urbano.Zona_Sector_Etapa = zonaSectorEtapa_txt.Text;
                ficha_catastral_equipamiento_urbano.Manzana1 = manzana1_txt.Text;
                ficha_catastral_equipamiento_urbano.Lote1 = lote1_txt.Text;
                ficha_catastral_equipamiento_urbano.Sub_Lote = subLote_txt.Text;
                //Usos
                usos.Codigo =codigoUsos_txt.Text;
                ficha_catastral_equipamiento_urbano.Usos = usos;
                //
                ficha_catastral_equipamiento_urbano.Observaciones = observaciones_txt.Text;
                //Estado de Llenado de la Ficha
                estado_llenado_ficha.Codigo =estadoLlenadoFicha_txt.Text;
                ficha_catastral_equipamiento_urbano.Estado_Llenado_Ficha = estado_llenado_ficha;
                supervisor.DNI = cPersonal.DNI_Supervisor;
                ficha_catastral_equipamiento_urbano.Supervisor = supervisor;
                ficha_catastral_equipamiento_urbano.Fecha_Supervisor = fechaSupervisor_txt.Value;
                tecnico_catastral.DNI = cPersonal.DNI_Tecnico_Catastral;
                ficha_catastral_equipamiento_urbano.Tecnico_Catastral = tecnico_catastral;
                ficha_catastral_equipamiento_urbano.Fecha_Tecnico_Catastral = fechaTecnicoCatastral_txt.Value;
                digitacion.DNI = cPersonal.DNI_Digitacion;
                ficha_catastral_equipamiento_urbano.Digitacion = digitacion;
                ficha_catastral_equipamiento_urbano.Fecha_Digitacion = fechaDigitacion_txt.Value;                
                ficha_catastral_equipamiento_urbano.Usuario = Usuario;
                i = ficha_catastral_equipamiento_urbano.guardar();
                if (i > 0)
                {
                    if (FICHA_dgv.RowCount > 0)
                    {
                        (new cFicha_Catastral_Equipamiento_Urbano_Ubicacion()).actualizar(FICHA_ds);
                        (new cFicha_Catastral_Equipamiento_Urbano_Fotografia()).actualizar(FICHA_ds);
                        MessageBox.Show("Se a Insertando Correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);  
                    }
                }
                else MessageBox.Show("Error Guardar, Ficha Catastral de Equipamiento Urbano", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                iniciar();
            }
        }
        void modificar()
        {            
            if (codigoUsos_txt.Text.Length == 0)
            {
                secundario_tc.SelectedTab = tabPage3;
                secundario_tc.SelectedTab = tabPage1;
            }
            if (validar)
            {
                cFicha_Catastral_Equipamiento_Urbano ficha_catastral_equipamiento_urbano = new cFicha_Catastral_Equipamiento_Urbano();
                ficha_catastral_equipamiento_urbano.Ficha = ficha_lbl.Text.Trim();
                ficha_catastral_equipamiento_urbano.Parcial_Ficha = parcialFichas_txt.Text;
                ficha_catastral_equipamiento_urbano.Total_Fichas = totalFichas_txt.Text;
                ficha_catastral_equipamiento_urbano.Codigo_Unico_Catastral = codigoUnicoCatastral_txt.Text;
                ficha_catastral_equipamiento_urbano.Codigo_Hoja_Catastral = codigoHojaCatastral_txt.Text;
                ficha_catastral_equipamiento_urbano.Departamento = departamento_lbl.Text;
                ficha_catastral_equipamiento_urbano.Provincia = provincia_lbl.Text;
                ficha_catastral_equipamiento_urbano.Distrito = distrito_lbl.Text;
                ficha_catastral_equipamiento_urbano.Sector = sector_txt.Text;
                ficha_catastral_equipamiento_urbano.Manzana = manzana_txt.Text;
                ficha_catastral_equipamiento_urbano.Lote = lote_txt.Text;
                ficha_catastral_equipamiento_urbano.Edifica = edifica_txt.Text;
                ficha_catastral_equipamiento_urbano.Entrada = entrada_txt.Text;
                ficha_catastral_equipamiento_urbano.Piso = piso_txt.Text;
                ficha_catastral_equipamiento_urbano.Unidad = unidad_txt.Text;
                ficha_catastral_equipamiento_urbano.Nombre_Equipamiento_Urbano = nombreEquipamientoUrbano_txt.Text;
                tipo_equipamiento_urbano.Codigo = tipoEquipamientoUrbano_txt.Text;
                ficha_catastral_equipamiento_urbano.Tipo_Equipamiento_Urbano = tipo_equipamiento_urbano;
                ficha_catastral_equipamiento_urbano.Punto_X = puntoX_txt.Text;
                ficha_catastral_equipamiento_urbano.Punto_Y = puntoY_txt.Text;
                ficha_catastral_equipamiento_urbano.Punto_Z = "";
                //Habilitación Urbana
                habilitacion_urbana.Codigo = (codigoHabilitacionUrbana_txt.Text.Length > 0) ? codigoHabilitacionUrbana_txt.Text : null;
                ficha_catastral_equipamiento_urbano.Habilitacion_Urbana = habilitacion_urbana;
                //
                ficha_catastral_equipamiento_urbano.Zona_Sector_Etapa = zonaSectorEtapa_txt.Text;
                ficha_catastral_equipamiento_urbano.Manzana1 = manzana1_txt.Text;
                ficha_catastral_equipamiento_urbano.Lote1 = lote1_txt.Text;
                ficha_catastral_equipamiento_urbano.Sub_Lote = subLote_txt.Text;
                //Usos
                usos.Codigo = codigoUsos_txt.Text;
                ficha_catastral_equipamiento_urbano.Usos = usos;
                //
                ficha_catastral_equipamiento_urbano.Observaciones = observaciones_txt.Text;
                //Estado Llenado de la Ficha
                estado_llenado_ficha.Codigo =estadoLlenadoFicha_txt.Text;
                ficha_catastral_equipamiento_urbano.Estado_Llenado_Ficha = estado_llenado_ficha;
                //
                supervisor.DNI = cPersonal.DNI_Supervisor;
                ficha_catastral_equipamiento_urbano.Supervisor = supervisor;
                ficha_catastral_equipamiento_urbano.Fecha_Supervisor = fechaSupervisor_txt.Value;
                tecnico_catastral.DNI = cPersonal.DNI_Tecnico_Catastral;
                ficha_catastral_equipamiento_urbano.Tecnico_Catastral = tecnico_catastral;
                ficha_catastral_equipamiento_urbano.Fecha_Tecnico_Catastral = fechaTecnicoCatastral_txt.Value;
                digitacion.DNI = cPersonal.DNI_Digitacion;
                ficha_catastral_equipamiento_urbano.Digitacion = digitacion;
                ficha_catastral_equipamiento_urbano.Fecha_Digitacion = fechaDigitacion_txt.Value;               
                ficha_catastral_equipamiento_urbano.Usuario = Usuario;
                i = ficha_catastral_equipamiento_urbano.modificar();
                if (i > 0)
                {
                    if (FICHA_dgv.RowCount > 0)
                    {
                        (new cFicha_Catastral_Equipamiento_Urbano_Ubicacion()).actualizar(FICHA_ds);
                        (new cFicha_Catastral_Equipamiento_Urbano_Fotografia()).actualizar(FICHA_ds);
                        MessageBox.Show("Se a Modificado Correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);                                              
                    }
                }
                else MessageBox.Show("Error Modificar, Ficha Catastral de Equipamiento Urbano.", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                iniciar();  
            }
        }
        void eliminar()
        {
            cFicha_Catastral_Equipamiento_Urbano ficha_catastral_equipamiento_urbano = new cFicha_Catastral_Equipamiento_Urbano();
            ficha_catastral_equipamiento_urbano.Ficha = ficha_lbl.Text.Trim();           
            ficha_catastral_equipamiento_urbano.Usuario = Usuario;
            i = ficha_catastral_equipamiento_urbano.eliminar();
            if (i >=2)
            {
                if (FICHA_dgv.RowCount > 0) MessageBox.Show("Se a Eliminado Correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }
            else MessageBox.Show("Error Eliminar, Ficha Catastral de Equipamiento Urbano.", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            iniciar(); 
        }        
        internal void listar_tipo_equipamiento_urbano()
        {
            tipoEquipamientoUrbano_txt.AutoCompleteCustomSource.AddRange(tipo_equipamiento_urbano.listar_arreglo());
        }        
        internal void listar_habilitacion_urbana()
        {
            codigoHabilitacionUrbana_txt.AutoCompleteCustomSource.AddRange(habilitacion_urbana.listar_arreglo());
        }
        internal void listar_usos()
        {
            codigoUsos_txt.AutoCompleteCustomSource.AddRange(usos.listar_arreglo());
        }
        internal void listar_estado_llenado_ficha()
        {
            estadoLlenadoFicha_txt.AutoCompleteCustomSource.AddRange(estado_llenado_ficha.listar_arreglo());
        }
        bool buscar_tipo_equipamiento_urbano()
        {
            return tipo_equipamiento_urbano.buscar(tipoEquipamientoUrbano_txt.Text);
        }       
        bool buscar_estado_llenado_ficha()
        {
            return estado_llenado_ficha.buscar(estadoLlenadoFicha_txt.Text);
        }
        #endregion

        #region [ METODOS DE FICHA CATASTRAL DE EQUIPAMIENTO URBANO - UBICACION ]
        internal void listar_vias()
        {
            codigoViaUbicacion_txt.AutoCompleteCustomSource.AddRange(vias.listar_arreglo());
        }
        internal void listar_tipo_puerta()
        {
            tipoPuertaUbicacion_txt.AutoCompleteCustomSource.AddRange(tipo_puerta.listar_arreglo());
        }
        internal void listar_condicion_numeracion()
        {
            condicionNumeracionUbicacion_txt.AutoCompleteCustomSource.AddRange(condicion_numeracion.listar_arreglo());
        }
        bool buscar_tipo_puerta()
        {
            return tipo_puerta.buscar(tipoPuertaUbicacion_txt.Text.Trim());
        }
        bool buscar_condicion_numeracion()
        {
            return condicion_numeracion.buscar(condicionNumeracionUbicacion_txt.Text.Trim());
        }
        #endregion
        #endregion

        #region Eventos
        #region [ EVENTOS DE FICHA CATASTRAL DE EQUIPAMIENTO URBANO ]
        private void listar_Load(object sender, EventArgs e)
        {
            try
            {
                listar();
                habilitar_controles_ficha = false;
                listar_tipo_equipamiento_urbano();
                listar_habilitacion_urbana();
                listar_usos();
                listar_estado_llenado_ficha();
                //Ubicación
                listar_vias();
                listar_tipo_puerta();
                listar_condicion_numeracion();

                #region Bindings - Ficha Catastral de Equipamiento Urbano
                FICHA_dgv.Columns["TEU"].Visible = false;
                FICHA_dgv.Columns["PUNTO Z"].Visible = false;
                FICHA_dgv.Columns["ELLF"].Visible = false;
                FICHA_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                ficha_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "FICHA", true));
                numero_ficha_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "NUMERO DE FICHA", true));
                numeroFicha_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "NUMERO DE FICHA", true));
                parcialFichas_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "PARCIAL DE FICHAS", true));
                totalFichas_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "TOTAL DE FICHAS", true));
                codigoUnicoCatastral_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CODIGO UNICO CATASTRAL", true));
                codigoHojaCatastral_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CODIGO HOJA CATASTRAL", true));
                departamento_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "DPTO", true));
                provincia_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "PROV", true));
                distrito_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "DIST", true));
                sector_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "SECTOR", true));
                manzana_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "MANZANA", true));
                lote_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "LOTE", true));
                edifica_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "EDIFICA", true));
                entrada_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "ENTRADA", true));
                piso_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "PISO", true));
                unidad_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "UNIDAD", true));
                digitoControl_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "DIGITO DE CONTROL", true));
                nombreEquipamientoUrbano_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "NOMBRE DEL EQUIPAMIENTO URBANO", true));
                tipoEquipamientoUrbano_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "TEU", true));
                puntoX_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "PUNTO X", true));
                puntoY_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "PUNTO Y", true));
                codigoHabilitacionUrbana_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CODIGO HABILITACION URBANA", true));
                nombreHabitacionUrbana_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "NOMBRE DE LA HABILITACION URBANA", true));
                zonaSectorEtapa_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "ZONA / SECTOR / ETAPA", true));
                manzana1_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "MANZANA1", true));
                lote1_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "LOTE1", true));
                subLote_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "SUB-LOTE", true));
                codigoUsos_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CODIGO DE USO", true));
                nombreUsos_lbl.DataBindings.Add(new Binding("Text", FICHA_bs, "DESCRIPCION DE USO", true));
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

                #region Bindings - Ubicación
                UBICACION_dgv.Columns["ID"].Visible = false;
                UBICACION_dgv.Columns["TV"].Visible = false;
                UBICACION_dgv.Columns["TP"].Visible = false;
                UBICACION_dgv.Columns["CN"].Visible = false;
                UBICACION_dgv.Columns["ESTADO"].Visible = false;
                UBICACION_dgv.Columns["USUARIO CREA"].Visible = false;
                UBICACION_dgv.Columns["FECHA DE CREACION"].Visible = false;
                UBICACION_dgv.Columns["USUARIO MODIFICA"].Visible = false;
                UBICACION_dgv.Columns["FECHA DE MODIFICACION"].Visible = false;
                UBICACION_dgv.Columns["FICHA"].Visible = false;
                UBICACION_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                IDUbicacion_lbl.DataBindings.Add(new Binding("Text", UBICACION_bs, "ID", true));
                sectorUbicacion_txt.DataBindings.Add(new Binding("Text", UBICACION_bs, "SECTOR", true));
                codigoViaUbicacion_txt.DataBindings.Add(new Binding("Text", UBICACION_bs, "CODIGO DE VIA", true));
                cuadraUbicacion_txt.DataBindings.Add(new Binding("Text", UBICACION_bs, "CUADRA", true));
                tipoViaUbicacion_lbl.DataBindings.Add(new Binding("Text", UBICACION_bs, "TV", true));
                nombreViaUbicacion_lbl.DataBindings.Add(new Binding("Text", UBICACION_bs, "NOMBRE DE VIA", true));
                tipoPuertaUbicacion_txt.DataBindings.Add(new Binding("Text", UBICACION_bs, "TP", true));
                numeroMunicipalUbicacion_txt.DataBindings.Add(new Binding("Text", UBICACION_bs, "NUMERO MUNICIPAL", true));
                condicionNumeracionUbicacion_txt.DataBindings.Add(new Binding("Text", UBICACION_bs, "CN", true));
                numeroCertificadoNumeracionUbicacion_txt.DataBindings.Add(new Binding("Text", UBICACION_bs, "NUMERO CERTIFICADO DE NUMERACION", true));
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
                edificaPlanoUbicacion_lbl.DataBindings.Add(new Binding("Text", FOTOGRAFIA_bs, "EDIFICA", true));
                añoPlanoUbicacion_txt.DataBindings.Add(new Binding("Text", FOTOGRAFIA_bs, "AÑO PLANO DE UBICACION", true));
                fotografiaDigital_pb.DataBindings.Add(new Binding("Image", FOTOGRAFIA_bs, "FOTOGRAFIA DIGITAL", true));
                sectorFotografiaDigital_lbl.DataBindings.Add(new Binding("Text", FOTOGRAFIA_bs, "SECTOR", true));
                manzanaFotografiaDigital_lbl.DataBindings.Add(new Binding("Text", FOTOGRAFIA_bs, "MANZANA", true));
                loteFotografiaDigital_lbl.DataBindings.Add(new Binding("Text", FOTOGRAFIA_bs, "LOTE", true));
                edificaFotografiaDigital_lbl.DataBindings.Add(new Binding("Text", FOTOGRAFIA_bs, "EDIFICA", true));
                añoFotografiaDigital_txt.DataBindings.Add(new Binding("Text", FOTOGRAFIA_bs, "AÑO FOTOGRAFIA DIGITAL", true));
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
                //ubicación   
                iniciar_ubicacion = true;
                aceptarUbicacion.Enabled = false;
                //Fotografía
                iniciar_fotografia = true;
                aceptarFotografia.Enabled = false;

                FICHA_bs.EndEdit();
                FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_EQUIPAMIENTO_URBANORow datos = FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_EQUIPAMIENTO_URBANO.FindByFICHA("0000000000");
                if (datos != null)
                {
                    datos.BeginEdit();
                    ficha_lbl.Text = (new cFicha_Catastral_Equipamiento_Urbano()).nuevo_codigo();
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
                if (codigoUsos_txt.Text.Length == 0)
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage3;
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
                    if (manzana_txt.Text.Length != 3)
                    {
                        manzana_txt_Leave(sender, e);
                        return;
                    }
                    if (nombreEquipamientoUrbano_txt.Text.Length == 0)
                    {
                        nombreEquipamientoUrbano_txt_Leave(sender, e);
                        return;
                    }
                    if (!buscar_tipo_equipamiento_urbano())
                    {
                        tipoEquipamientoUrbano_txt_Leave(sender, e);
                        return;
                    }
                    if (codigoUsos_txt.Text.Length == 0)
                    {
                        codigoUsos_txt_Leave(sender, e);
                        return;
                    }
                    if (!buscar_estado_llenado_ficha())
                    {
                        estadoLlenadoFicha_txt_Leave(sender, e);
                        return;
                    }
                    //Ubicación
                    if (habilitar_controles_ubicacion)
                    {
                        if (aceptarUbicacion.Text == "Aceptar" || aceptarUbicacion.Text == "Agregar Ubicación")
                        {
                            principal_tc.SelectedTab = formulario_tp;
                            secundario_tc.SelectedTab = tabPage1;
                            ubicacion_tc.SelectedTab = tabPage5;
                            aceptarUbicacion.ForeColor = Color.Red;
                        }
                    }
                    //Fotografía
                    if (habilitar_controles_fotografia)
                    {
                        if (aceptarFotografia.Text == "Aceptar" || aceptarFotografia.Text == "Agregar Fotografía")
                        {
                            principal_tc.SelectedTab = formulario_tp;
                            secundario_tc.SelectedTab = tabPage2;
                            fotografia_tc.SelectedTab = tabPage7;
                            aceptarFotografia.ForeColor = Color.Red;
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
                            //Ubicación
                            habilitar_movimiento_ubicacion = true;
                            nuevoUbicacion.Enabled = true;
                            aceptarUbicacion.Enabled = (UBICACION_dgv.RowCount == 0) ? false : true;
                            eliminarUbicacion.Enabled = (UBICACION_dgv.RowCount == 0) ? false : true;
                            //Fotografía
                            habilitar_movimiento_fotografia = true;
                            nuevoFotografia.Enabled = true;
                            aceptarFotografia.Enabled = (FOTOGRAFIA_dgv.RowCount == 0) ? false : true;
                            eliminarFotografia.Enabled = (FOTOGRAFIA_dgv.RowCount == 0) ? false : true;

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
                FICHA_ds rpt = (new cFicha_Catastral_Equipamiento_Urbano()).reporte();
                if (rpt != null)
                {
                    DataView vista = rpt.VS_REPORTE_FICHA_CATASTRAL_EQUIPAMIENTO_URBANO.DefaultView;
                    vista.RowFilter = query;
                    DataTable tabla = vista.ToTable();
                    Reporte reporte = (tabla.Rows.Count > 0) ? new Reporte('4', tabla) : new Reporte('4', rpt);
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
                    parcialFichas_lbl.BackColor = Color.LavenderBlush;
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
            else if (parcialFichas_lbl.BackColor == Color.Red) parcialFichas_lbl.BackColor = Color.LavenderBlush;
        }

        private void totalFichas_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (totalFichas_txt.Text.Length > 0)
                {
                    totalFichas_lbl.BackColor = Color.LavenderBlush;
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
            else if (totalFichas_lbl.BackColor == Color.Red) totalFichas_lbl.BackColor = Color.LavenderBlush;
        }

        private void sector_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (sector_txt.Text.Length == 2)
                {
                    sector_lbl.BackColor = Color.LavenderBlush;
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
            else if (sector_lbl.BackColor == Color.Red) sector_lbl.BackColor = Color.LavenderBlush;
        }

        private void manzana_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (manzana_txt.Text.Length == 3)
                {
                    manzana_lbl.BackColor = Color.LavenderBlush;
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
            else if (manzana_lbl.BackColor == Color.Red) manzana_lbl.BackColor = Color.LavenderBlush;
        }

        private void lote_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (lote_txt.Text.Length == 3 || lote_txt.Text.Length == 0)
                {
                    lote_lbl.BackColor = Color.LavenderBlush;
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
            else if (lote_lbl.BackColor == Color.Red) lote_lbl.BackColor = Color.LavenderBlush;
        }

        private void edifica_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (edifica_txt.Text.Length == 2 || edifica_txt.Text.Length == 0)
                {
                    edifica_lbl.BackColor = Color.LavenderBlush;
                    edifica_txt.ForeColor = Color.Black;
                }
                else
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage1;
                    edifica_lbl.BackColor = Color.Red;
                    edifica_txt.Focus();
                    edifica_txt.SelectAll();
                    edifica_txt.ForeColor = Color.Red;
                }
            }
            else if (edifica_lbl.BackColor == Color.Red) edifica_lbl.BackColor = Color.LavenderBlush;
        }

        private void entrada_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (entrada_txt.Text.Length == 2 || entrada_txt.Text.Length == 0)
                {
                    entrada_lbl.BackColor = Color.LavenderBlush;
                    entrada_txt.ForeColor = Color.Black;
                }
                else
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage1;
                    entrada_lbl.BackColor = Color.Red;
                    entrada_txt.Focus();
                    entrada_txt.SelectAll();
                    entrada_txt.ForeColor = Color.Red;
                }
            }
            else if (entrada_lbl.BackColor == Color.Red) entrada_lbl.BackColor = Color.LavenderBlush;
        }

        private void piso_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (piso_txt.Text.Length == 2 || piso_txt.Text.Length == 0)
                {
                    piso_lbl.BackColor = Color.LavenderBlush;
                    piso_txt.ForeColor = Color.Black;
                }
                else
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage1;
                    piso_lbl.BackColor = Color.Red;
                    piso_txt.Focus();
                    piso_txt.SelectAll();
                    piso_txt.ForeColor = Color.Red;
                }
            }
            else if (piso_lbl.BackColor == Color.Red) piso_lbl.BackColor = Color.LavenderBlush;
        }

        private void unidad_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (unidad_txt.Text.Length == 3 || unidad_txt.Text.Length == 0)
                {
                    unidad_lbl.BackColor = Color.LavenderBlush;
                    unidad_txt.ForeColor = Color.Black;
                }
                else
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage1;
                    unidad_lbl.BackColor = Color.Red;
                    unidad_txt.Focus();
                    unidad_txt.SelectAll();
                    unidad_txt.ForeColor = Color.Red;
                }
            }
            else if (unidad_lbl.BackColor == Color.Red) unidad_lbl.BackColor = Color.LavenderBlush;
        }

        private void nombreEquipamientoUrbano_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (aceptarUbicacion.Text != "Agregar Ubicación" || aceptarFotografia.Text != "Agregar Fotografía")
                {
                    if (nombreEquipamientoUrbano_txt.Text.Length > 0)
                    {
                        nombreEquipamientoUrbano_lbl.BackColor = Color.LavenderBlush;
                        nombreEquipamientoUrbano_txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        principal_tc.SelectedTab = formulario_tp;
                        secundario_tc.SelectedTab = tabPage1;
                        nombreEquipamientoUrbano_lbl.BackColor = Color.Red;
                        nombreEquipamientoUrbano_txt.Focus();
                        nombreEquipamientoUrbano_txt.SelectAll();
                        nombreEquipamientoUrbano_txt.ForeColor = Color.Red;
                    }
                }
            }
            else if (nombreEquipamientoUrbano_lbl.BackColor == Color.Red) nombreEquipamientoUrbano_lbl.BackColor = Color.LavenderBlush;
        }

        private void tipoEquipamientoUrbano_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                tipoEquipamientoUrbano_txt.Text = (tipoEquipamientoUrbano_txt.Text.Length > 2) ? tipoEquipamientoUrbano_txt.Text.Substring(0, 2) : tipoEquipamientoUrbano_txt.Text;
                if (buscar_tipo_equipamiento_urbano())
                {
                    tipoEquipamientoUrbano_lbl.BackColor = Color.LavenderBlush;
                    tipoEquipamientoUrbano_txt.ForeColor = Color.Black;
                }
                else
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage1;
                    tipoEquipamientoUrbano_lbl.BackColor = Color.Red;
                    tipoEquipamientoUrbano_txt.ForeColor = Color.Red;
                    tipoEquipamientoUrbano_txt.Focus();
                    tipoEquipamientoUrbano_txt.SelectAll();
                }
            }
            else if (tipoEquipamientoUrbano_lbl.BackColor == Color.Red) tipoEquipamientoUrbano_lbl.BackColor = Color.LavenderBlush;
        }

        private void codigoHabilitacionUrbana_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (codigoHabilitacionUrbana_txt.Text.Length != 0)
                {
                    int j = (codigoHabilitacionUrbana_txt.Text.IndexOf('-') != -1) ? codigoHabilitacionUrbana_txt.Text.IndexOf('-') : codigoHabilitacionUrbana_txt.Text.Length;
                    codigoHabilitacionUrbana_txt.Text = (codigoHabilitacionUrbana_txt.Text.Length > 0) ? codigoHabilitacionUrbana_txt.Text.Substring(0, j - 1) : ""; 
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
                        codigoHabilitacionUrbana_lbl.BackColor = Color.LavenderBlush;
                        codigoHabilitacionUrbana_txt.ForeColor = Color.Black;
                        nombreHabitacionUrbana_lbl.Text = fila["DESCRIPCION"].ToString();
                    }
                }
                else
                {
                    codigoHabilitacionUrbana_lbl.BackColor = Color.LavenderBlush;
                    codigoHabilitacionUrbana_txt.ForeColor = Color.Black;
                    codigoHabilitacionUrbana_txt.Text = "";
                    nombreHabitacionUrbana_lbl.Text = "";
                }
            }
            else if (codigoHabilitacionUrbana_lbl.BackColor == Color.Red) codigoHabilitacionUrbana_lbl.BackColor = Color.LavenderBlush;
        }

        private void codigoUsos_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                int i = (codigoUsos_txt.Text.IndexOf('-') != -1) ? codigoUsos_txt.Text.IndexOf('-') : codigoUsos_txt.Text.Length + 1;
                codigoUsos_txt.Text = (codigoUsos_txt.Text.Length > 0) ? codigoUsos_txt.Text.Substring(0, i - 1) : "";
                DataRow fila = usos.Buscar(codigoUsos_txt.Text.Trim());
                if (fila == null)
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage3;
                    codigoUsos_lbl.BackColor = Color.Red;
                    codigoUsos_txt.Focus();
                    codigoUsos_txt.SelectAll();
                    codigoUsos_txt.ForeColor = Color.Red;
                    codigoUsos_txt.Text = "";
                    nombreUsos_lbl.Text = "";
                }
                else
                {
                    codigoUsos_lbl.BackColor = Color.LavenderBlush;
                    codigoUsos_txt.ForeColor = Color.Black;
                    nombreUsos_lbl.Text = fila["LISTA"].ToString().Substring(i + 2);
                }
            }
            else if (codigoUsos_lbl.BackColor == Color.Red) codigoUsos_lbl.BackColor = Color.LavenderBlush;
        }

        private void estadoLlenadoFicha_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                estadoLlenadoFicha_txt.Text = (estadoLlenadoFicha_txt.Text.Length > 2) ? estadoLlenadoFicha_txt.Text.Substring(0, 2) : estadoLlenadoFicha_txt.Text;
                if (buscar_estado_llenado_ficha())
                {
                    estadoLlenadoFicha_lbl.BackColor = Color.LavenderBlush;
                    estadoLlenadoFicha_txt.ForeColor = Color.Black;
                }
                else
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage3;
                    estadoLlenadoFicha_lbl.BackColor = Color.Red;
                    estadoLlenadoFicha_txt.Focus();
                    estadoLlenadoFicha_txt.SelectAll();
                    estadoLlenadoFicha_txt.ForeColor = Color.Red;
                }
            }
            else if (estadoLlenadoFicha_txt.BackColor == Color.Red) estadoLlenadoFicha_txt.BackColor = Color.LavenderBlush;
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

        #region [ EVENTOS DE FICHA CATASTRAL DE EQUIPAMIENTO URBANO - UBICACION ]
        private void nuevoUbicacion_Click(object sender, EventArgs e)
        {
            if (sector_txt.Text.Length == 2 && manzana_txt.Text.Length == 3)
            {
                habilitar_movimiento_ubicacion = false;
                habilitar_controles_ubicacion = true;
                aceptarUbicacion.Enabled = true;
                aceptarUbicacion.Text = "Agregar Ubicación";
                aceptarUbicacion.Image = (Image)(resources.GetObject("aceptarUbicacion.Image"));
                nuevoUbicacion.Enabled = false;
                eliminarUbicacion.Enabled = false;
                cancelarUbicacion.Enabled = true;
                UBICACION_bs.AddNew();
                sectorUbicacion_txt.Focus();
            }
        }

        private void eliminarUbicacion_Click(object sender, EventArgs e)
        {
            UBICACION_bs.RemoveAt(UBICACION_bs.Position);
            if (UBICACION_dgv.RowCount == 0)
            {
                aceptarUbicacion.Enabled = false;
                cancelarUbicacion.Enabled = false;
                eliminarFotografia.Enabled = false;
            }
        }

        private void aceptarUbicacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (sectorUbicacion_txt.Text.Length == 0)
                {
                    sectorUbicacion_txt_Leave(sender, e);
                    return;
                }
                if (codigoViaUbicacion_txt.Text.Length == 0)
                {
                    codigoViaUbicacion_txt_Leave(sender, e);
                    return;
                }
                if (cuadraUbicacion_txt.Text.Length == 0)
                {
                    cuadraUbicacion_txt_Leave(sender, e);
                    return;
                }
                if (!buscar_tipo_puerta())
                {
                    tipoPuertaUbicacion_txt_Leave(sender, e);
                    return;
                }
                if (!buscar_condicion_numeracion())
                {
                    condicionNumeracionUbicacion_txt_Leave(sender, e);
                    return;
                }

                if (aceptarUbicacion.Text == "Agregar Ubicación")
                {
                    UBICACION_bs.EndEdit();
                    long id = Convert.ToInt64(UBICACION_dgv["ID", UBICACION_dgv.CurrentRow.Index].Value);
                    FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_EQUIPAMIENTO_URBANO_UBICACIONRow datos = FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_EQUIPAMIENTO_URBANO_UBICACION.FindByID(id);
                    if (datos != null)
                    {
                        datos.BeginEdit();
                        datos.SECTOR = sectorUbicacion_txt.Text;
                        datos.CODIGO_DE_VIA = codigoViaUbicacion_txt.Text;
                        datos.CUADRA = cuadraUbicacion_txt.Text;
                        datos.TV = tipoViaUbicacion_lbl.Text;
                        datos.TIPO_DE_VIA = datos.TV;
                        datos.NOMBRE_DE_VIA = nombreViaUbicacion_lbl.Text;
                        datos.TP = (tipoPuertaUbicacion_txt.Text.Length > 0) ? tipoPuertaUbicacion_txt.Text : null;
                        datos.TIPO_DE_PUERTA = datos.TP;
                        datos.NUMERO_MUNICIPAL = (numeroMunicipalUbicacion_txt.Text.Length > 0) ? Convert.ToInt32(numeroMunicipalUbicacion_txt.Text) : 0;
                        datos.CN = (condicionNumeracionUbicacion_txt.Text.Length > 0) ? condicionNumeracionUbicacion_txt.Text : null;
                        datos.CONDICION_NUMERACION = datos.CN;
                        datos.NUMERO_CERTIFICADO_DE_NUMERACION = numeroCertificadoNumeracionUbicacion_txt.Text;
                        datos.ESTADO = "A";
                        datos.USUARIO_CREA = Usuario;
                        datos.FECHA_DE_CREACION = DateTime.Now;
                        datos.USUARIO_MODIFICA = Usuario;
                        datos.FECHA_DE_MODIFICACION = DateTime.Now;
                        datos.FICHA = ficha_lbl.Text.Trim();
                        datos.EndEdit();
                    }
                    habilitar_movimiento_ubicacion = true;
                    habilitar_controles_ubicacion = false;
                    iniciar_ubicacion = true;
                }
                else if (aceptarUbicacion.Text == "Modificar Ubicación")
                {
                    principal_tc.SelectedTab = formulario_tp;
                    ubicacion_tc.SelectedTab = tabPage5;
                    habilitar_movimiento_ubicacion = false;
                    habilitar_controles_ubicacion = true;
                    aceptarUbicacion.Text = "Aceptar";
                    aceptarUbicacion.Image = null;
                    nuevoUbicacion.Enabled = false;
                    eliminarUbicacion.Enabled = false;
                    sectorUbicacion_txt.Focus();
                }
                else if (aceptarUbicacion.Text == "Aceptar")
                {
                    FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_EQUIPAMIENTO_URBANO_UBICACIONRow datos = FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_EQUIPAMIENTO_URBANO_UBICACION.FindByID(Convert.ToInt64(IDUbicacion_lbl.Text));
                    if (datos != null)
                    {
                        datos.BeginEdit();
                        datos.SECTOR = sectorUbicacion_txt.Text;
                        datos.CODIGO_DE_VIA = codigoViaUbicacion_txt.Text;
                        datos.CUADRA = cuadraUbicacion_txt.Text;
                        datos.TV = tipoViaUbicacion_lbl.Text;
                        datos.TIPO_DE_VIA = datos.TV;
                        datos.NOMBRE_DE_VIA = nombreViaUbicacion_lbl.Text;
                        datos.TP = (tipoPuertaUbicacion_txt.Text.Length > 0) ? tipoPuertaUbicacion_txt.Text : null;
                        datos.TIPO_DE_PUERTA = datos.TP;
                        datos.NUMERO_MUNICIPAL = (numeroMunicipalUbicacion_txt.Text.Length > 0) ? Convert.ToInt32(numeroMunicipalUbicacion_txt.Text) : 0;
                        datos.CN = (condicionNumeracionUbicacion_txt.Text.Length > 0) ? condicionNumeracionUbicacion_txt.Text : null;
                        datos.CONDICION_NUMERACION = datos.CN;
                        datos.NUMERO_CERTIFICADO_DE_NUMERACION = numeroCertificadoNumeracionUbicacion_txt.Text;
                        datos.ESTADO = "A";
                        datos.USUARIO_MODIFICA = Usuario;
                        datos.FECHA_DE_MODIFICACION = DateTime.Now;
                        datos.FICHA = ficha_lbl.Text.Trim();
                        datos.EndEdit();
                    }
                    habilitar_movimiento_ubicacion = true;
                    habilitar_controles_ubicacion = false;
                    iniciar_ubicacion = true;
                }

            }
            catch (Exception ex)
            {
                cancelarUbicacion_Click(sender, e);
                MessageBox.Show(ex.Message, "Error Agregar y/o Modificar, Ubicación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelarUbicacion_Click(object sender, EventArgs e)
        {
            ubicacion_tc.SelectedTab = tabPage5;
            UBICACION_bs.CancelEdit();
            habilitar_controles_ubicacion = false;
            habilitar_movimiento_ubicacion = true;
            iniciar_ubicacion = true;
            if (codigoViaUbicacion_lbl.BackColor == Color.Red) codigoViaUbicacion_lbl.BackColor = Color.LavenderBlush;
            if (tipoPuertaUbicacion_lbl.BackColor == Color.Red) tipoPuertaUbicacion_lbl.BackColor = Color.LavenderBlush;
            if (condicionNumeracionUbicacion_lbl.BackColor == Color.Red) condicionNumeracionUbicacion_lbl.BackColor = Color.LavenderBlush;
        }

        private void sectorUbicacion_txt_Leave(object sender, EventArgs e)
        {
            if (sectorUbicacion_txt.Text.Length == 2)
            {
                codigoViaUbicacion_lbl.BackColor = Color.LavenderBlush;
                sectorUbicacion_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage1;
                ubicacion_tc.SelectedTab = tabPage5;
                codigoViaUbicacion_lbl.BackColor = Color.Red;
                sectorUbicacion_txt.Focus();
                sectorUbicacion_txt.SelectAll();
                sectorUbicacion_txt.ForeColor = Color.Red;
            }
            if (codigoViaUbicacion_lbl.BackColor == Color.Red && sectorUbicacion_txt.Enabled == false) codigoViaUbicacion_lbl.BackColor = Color.LavenderBlush;
        }

        private void codigoViaUbicacion_txt_Leave(object sender, EventArgs e)
        {
            int i = (codigoViaUbicacion_txt.Text.IndexOf('-') != -1) ? codigoViaUbicacion_txt.Text.IndexOf('-') : codigoViaUbicacion_txt.Text.Length + 1;
            codigoViaUbicacion_txt.Text = (codigoViaUbicacion_txt.Text.Length > 0) ? codigoViaUbicacion_txt.Text.Substring(0, i - 1) : "";
            DataRow fila = vias.Buscar(codigoViaUbicacion_txt.Text.Trim());
            if (fila == null)
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage1;
                ubicacion_tc.SelectedTab = tabPage5;
                codigoViaUbicacion_lbl.BackColor = Color.Red;
                codigoViaUbicacion_txt.Focus();
                codigoViaUbicacion_txt.SelectAll();
                codigoViaUbicacion_txt.ForeColor = Color.Red;
                tipoViaUbicacion_lbl.Text = "";
                nombreViaUbicacion_lbl.Text = "";
            }
            else
            {
                codigoViaUbicacion_lbl.BackColor = Color.LavenderBlush;
                codigoViaUbicacion_txt.ForeColor = Color.Black;
                tipoViaUbicacion_lbl.Text = fila["TV"].ToString();
                nombreViaUbicacion_lbl.Text = fila["NOMBRE DE VIA"].ToString();
            }
            if (codigoViaUbicacion_lbl.BackColor == Color.Red && codigoViaUbicacion_txt.Enabled == false) codigoViaUbicacion_lbl.BackColor = Color.LavenderBlush;
        }

        private void cuadraUbicacion_txt_Leave(object sender, EventArgs e)
        {
            if (cuadraUbicacion_txt.Text.Length == 2)
            {
                codigoViaUbicacion_lbl.BackColor = Color.LavenderBlush;
                cuadraUbicacion_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage1;
                ubicacion_tc.SelectedTab = tabPage5;
                codigoViaUbicacion_lbl.BackColor = Color.Red;
                cuadraUbicacion_txt.Focus();
                cuadraUbicacion_txt.SelectAll();
                cuadraUbicacion_txt.ForeColor = Color.Red;
            }
            if (codigoViaUbicacion_lbl.BackColor == Color.Red && cuadraUbicacion_txt.Enabled == false) codigoViaUbicacion_lbl.BackColor = Color.LavenderBlush;
        }

        private void tipoPuertaUbicacion_txt_Leave(object sender, EventArgs e)
        {
            tipoPuertaUbicacion_txt.Text = (tipoPuertaUbicacion_txt.Text.Length > 1) ? tipoPuertaUbicacion_txt.Text.Substring(0, 1) : tipoPuertaUbicacion_txt.Text;
            if (buscar_tipo_puerta())
            {
                tipoPuertaUbicacion_lbl.BackColor = Color.LavenderBlush;
                tipoPuertaUbicacion_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage1;
                ubicacion_tc.SelectedTab = tabPage5;
                tipoPuertaUbicacion_lbl.BackColor = Color.Red;
                tipoPuertaUbicacion_txt.Focus();
                tipoPuertaUbicacion_txt.SelectAll();
                tipoPuertaUbicacion_txt.ForeColor = Color.Red;
            }
            if (tipoPuertaUbicacion_lbl.BackColor == Color.Red && tipoPuertaUbicacion_txt.Enabled == false) tipoPuertaUbicacion_lbl.BackColor = Color.LavenderBlush;
        }

        private void condicionNumeracionUbicacion_txt_Leave(object sender, EventArgs e)
        {
            condicionNumeracionUbicacion_txt.Text = (condicionNumeracionUbicacion_txt.Text.Length > 2) ? condicionNumeracionUbicacion_txt.Text.Substring(0, 2) : condicionNumeracionUbicacion_txt.Text;
            if (buscar_condicion_numeracion())
            {
                condicionNumeracionUbicacion_lbl.BackColor = Color.LavenderBlush;
                condicionNumeracionUbicacion_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage1;
                ubicacion_tc.SelectedTab = tabPage5;
                condicionNumeracionUbicacion_lbl.BackColor = Color.Red;
                condicionNumeracionUbicacion_txt.Focus();
                condicionNumeracionUbicacion_txt.SelectAll();
                condicionNumeracionUbicacion_txt.ForeColor = Color.Red;
            }
            if (condicionNumeracionUbicacion_lbl.BackColor == Color.Red && condicionNumeracionUbicacion_txt.Enabled == false) condicionNumeracionUbicacion_lbl.BackColor = Color.LavenderBlush;
        }

        private void UBICACION_dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion

        #region [ EVENTOS DE FICHA CATASTRAL DE EQUIPAMIENTO URBANO - FOTOGRAFIA ]
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
                    FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_EQUIPAMIENTO_URBANO_FOTOGRAFIARow datos = FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_EQUIPAMIENTO_URBANO_FOTOGRAFIA.FindByID(id);
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
                        datos.EDIFICA = edifica_txt.Text;
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
                    fotografia_tc.SelectedTab = tabPage7;
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
                    FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_EQUIPAMIENTO_URBANO_FOTOGRAFIARow datos = FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_EQUIPAMIENTO_URBANO_FOTOGRAFIA.FindByID(long.Parse(IDFotografia_lbl.Text));
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
                        datos.EDIFICA = edifica_txt.Text;
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
            fotografia_tc.SelectedTab = tabPage7;
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
                    edificaPlanoUbicacion_lbl.Text = edifica_txt.Text;
                    añoPlanoUbicacion_txt.Text = DateTime.Now.Year.ToString();
                }
                else
                {
                    planoUbicacion_pb.ImageLocation = "";
                    sectorPlanoUbicacion_lbl.Text = "";
                    manzanaPlanoUbicacion_lbl.Text = "";
                    lotePlanoUbicacion_lbl.Text = "";
                    edificaPlanoUbicacion_lbl.Text = "";
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
                añoPlanoUbicacion_lbl.BackColor = Color.LavenderBlush;
                añoPlanoUbicacion_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage2;
                fotografia_tc.SelectedTab = tabPage7;
                añoPlanoUbicacion_lbl.BackColor = Color.Red;
                añoPlanoUbicacion_txt.Focus();
                añoPlanoUbicacion_txt.SelectAll();
                añoPlanoUbicacion_txt.ForeColor = Color.Red;
            }
            if (añoPlanoUbicacion_lbl.BackColor == Color.Red && añoPlanoUbicacion_txt.Enabled == false) añoPlanoUbicacion_lbl.BackColor = Color.LavenderBlush;
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
                    edificaFotografiaDigital_lbl.Text = edifica_txt.Text;
                    añoFotografiaDigital_txt.Text = DateTime.Now.Year.ToString();
                }
                else
                {
                    fotografiaDigital_pb.ImageLocation = "";
                    sectorFotografiaDigital_lbl.Text = "";
                    manzanaFotografiaDigital_lbl.Text = "";
                    loteFotografiaDigital_lbl.Text = "";
                    edificaFotografiaDigital_lbl.Text = "";
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
                añoFotografiaDigital_lbl.BackColor = Color.LavenderBlush;
                añoFotografiaDigital_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage2;
                fotografia_tc.SelectedTab = tabPage7;
                añoFotografiaDigital_lbl.BackColor = Color.Red;
                añoFotografiaDigital_txt.Focus();
                añoFotografiaDigital_txt.SelectAll();
                añoFotografiaDigital_txt.ForeColor = Color.Red;
            }
            if (añoFotografiaDigital_lbl.BackColor == Color.Red && añoFotografiaDigital_txt.Enabled == false) añoFotografiaDigital_lbl.BackColor = Color.LavenderBlush;
        }

        private void FOTOGRAFIA_dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion
        #endregion
    }
}