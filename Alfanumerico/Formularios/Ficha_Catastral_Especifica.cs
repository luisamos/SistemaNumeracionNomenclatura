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
    internal partial class Ficha_Catastral_Especifica : Ficha
    {
        internal Ficha_Catastral_Especifica()
        {
            InitializeComponent();
            //Ficha Catastral Específica
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
            sectorVia_txt.Leave += new EventHandler(sectorVia_txt_Leave);
            codigoVia_txt.Leave += new EventHandler(codigoVia_txt_Leave);
            cuadraVia_txt.Leave += new EventHandler(cuadraVia_txt_Leave);            
            manzanaEspacioRecreacion_txt.Leave += new EventHandler(manzanaEspacioRecreacion_txt_Leave);
            loteEspacioRecreacion_txt.Leave += new EventHandler(loteEspacioRecreacion_txt_Leave);
            estadoLlenadoFicha_txt.Leave += new EventHandler(estadoLlenadoFicha_txt_Leave);            
            //Uso Resaltante
            nuevoUsoResaltante.Click += new EventHandler(nuevoUsoResaltante_Click);
            eliminarUsoResaltante.Click += new EventHandler(eliminarUsoResaltante_Click);
            aceptarUsoResaltante.Click += new EventHandler(aceptarUsoResaltante_Click);
            cancelarUsoResaltante.Click += new EventHandler(cancelarUsoResaltante_Click);
            fotografiaDigitalUsoResaltante_pb.Click += new EventHandler(fotografiaDigitalUsoResaltante_pb_Click);
            añoFotografiaDigitalUsoResaltante_txt.Leave += new EventHandler(añoFotografiaDigitalUsoResaltante_txt_Leave);
            tipoUsoResaltante_txt.Leave += new EventHandler(tipoUsoResaltante_txt_Leave);
            clasificacionUsoResaltante_txt.Leave += new EventHandler(clasificacionUsoResaltante_txt_Leave);            
            USO_RESALTANTE_dgv.DataError += new DataGridViewDataErrorEventHandler(USO_RESALTANTE_dgv_DataError);
        }        

        #region Variables Globales
        ComponentResourceManager resources = new ComponentResourceManager(typeof(Ficha_Catastral_Especifica));
        //Ficha Catastral Especifica
        cVias vias = new cVias();
        cEstado_Llenado_Ficha estado_llenado_ficha = new cEstado_Llenado_Ficha();
        cPersonal supervisor = new cPersonal();
        cPersonal tecnico_catastral = new cPersonal();
        cPersonal digitacion = new cPersonal();
        //Uso Resaltante
        cTipo_Uso_Resaltante tipo_uso_resaltante = new cTipo_Uso_Resaltante();
        cClasificacion_Uso_Resaltante clasificacion_uso_resaltante = new cClasificacion_Uso_Resaltante();        
        #endregion

        #region Propiedades
        #region [ PROPIEDEADES DE FICHA CATASTRAL ESPECIFICA ]
        bool habilitar_controles_ficha
        {
            get { return parcialFichas_txt.Enabled; }
            set
            {
                IEnumerable<Control> controles1 = from Control x1 in tabPage1.Controls
                                                  where x1 is FormattedTextBox || x1 is TextBox || x1 is DateTimePicker || (x1 is Label && x1.BackColor == Color.White)
                                                  select x1;
                List<Control> coleccionControles = controles1.ToList();
                IEnumerable<Control> controles2 = from Control x2 in tabPage2.Controls
                                                  where x2 is FormattedTextBox || x2 is TextBox || x2 is DateTimePicker || (x2 is Label && x2.BackColor == Color.White)
                                                  select x2;
                coleccionControles.AddRange(controles2.ToList());
                coleccionControles.ForEach(a => a.Enabled = value);

                //Ficha Catastral Especifica
                FICHA_dgv.Enabled = !value;
                categoria_tsc.Enabled = !value;
                buscar_tst.Enabled = !value;                
                //Uso Resaltante
                iniciar_uso_resaltante = false;
                habilitar_movimiento_uso_resaltante = !value;
                habilitar_controles_uso_resaltante = false;
            }
        }
        bool validar
        {
            get
            {
                IEnumerable<int> labelCantidad1 = from Control x in tabPage1.Controls
                                                  where x is Label && x.BackColor == Color.Red
                                                  select x.Controls.Count;
                IEnumerable<int> labelCantidad2 = from Control x in tabPage2.Controls
                                                  where x is Label && x.BackColor == Color.Red
                                                  select x.Controls.Count;
                int total = labelCantidad1.Count() + labelCantidad2.Count();
                return total == 0 && estadoLlenadoFicha_txt.Text.Length == 2 && ((aceptarUsoResaltante.ForeColor != Color.Red) ? true : false);
            }
        }
        #endregion

        #region [ PROPIEDADES DE USO RESALTANTE ]
        bool habilitar_movimiento_uso_resaltante
        {
            set
            {
                inicioUsoResaltante.Enabled = (posicionUsoResaltante.Text == "0" || posicionUsoResaltante.Text == "1") ? false : value;
                anteriorUsoResaltante.Enabled = (posicionUsoResaltante.Text == "0" || posicionUsoResaltante.Text == "1") ? false : value;
                posicionUsoResaltante.Enabled = (USO_RESALTANTE_dgv.RowCount == 0) ? false : value;
                siguienteUsoResaltante.Enabled = (posicionUsoResaltante.Text == contadorUsoResaltante.Text.Substring(3)) ? false : value;
                finUsoResaltante.Enabled = (posicionUsoResaltante.Text == contadorUsoResaltante.Text.Substring(3)) ? false : value;
                nuevoUsoResaltante.Enabled = !value;
                aceptarUsoResaltante.Enabled = !value;
                eliminarUsoResaltante.Enabled = !value;
                cancelarUsoResaltante.Enabled = !value;
            }
        }
        bool habilitar_controles_uso_resaltante
        {
            get { return añoFotografiaDigitalUsoResaltante_txt.Enabled; }
            set
            {
                fotografiaDigitalUsoResaltante_pb.Enabled = value;
                sectorUsoResaltante_lbl.Enabled = value;
                manzanaCodigoViaUsoResaltante_lbl.Enabled = value;
                loteCuadraUsoResaltante_lbl.Enabled = value;
                añoFotografiaDigitalUsoResaltante_txt.Enabled = value;
                direccionUsoResaltante_txt.Enabled = value;
                tipoUsoResaltante_txt.Enabled = value;
                clasificacionUsoResaltante_txt.Enabled = value;
                puntoXUsoResaltante_txt.Enabled = value;
                puntoYUsoResaltante_txt.Enabled = value;
                especificacionesUsoResaltante_txt.Enabled = value;
                USO_RESALTANTE_dgv.Enabled = !value;
            }
        }
        bool iniciar_uso_resaltante
        {
            set
            {
                uso_resaltante_tc.SelectedTab = tabPage4;
                nuevoUsoResaltante.Enabled = value;
                aceptarUsoResaltante.ForeColor = Color.Black;
                aceptarUsoResaltante.Enabled = false;
                eliminarUsoResaltante.Enabled = false;
                cancelarUsoResaltante.Enabled = false;
                if (USO_RESALTANTE_dgv.RowCount > 0)
                {
                    aceptarUsoResaltante.Enabled = value;
                    aceptarUsoResaltante.Text = "Modificar Uso Resaltante";
                    aceptarUsoResaltante.Image = null;
                    eliminarUsoResaltante.Enabled = value;
                }
            }
        }
        #endregion
        #endregion

        #region Metodos
        #region [ METODOS FICHA CATASTRAL ESPECIFICA ]
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
            cFicha_Catastral_Especifica ficha_catastral_especifica = new cFicha_Catastral_Especifica();
            FICHA_ds = ficha_catastral_especifica.listar();            

            base.refrescar();

            this.FICHA_bs.DataMember = "VS_LISTAR_FICHA_CATASTRAL_ESPECIFICA";
            this.FICHA_bs.DataSource = FICHA_ds;

            this.USO_RESALTANTE_bn.BindingSource = USO_RESALTANTE_bs;
            this.USO_RESALTANTE_dgv.DataSource = USO_RESALTANTE_bs;
            this.USO_RESALTANTE_bs.DataMember = "ESPECIFICA_FK_USO_RESALTANTE";
            this.USO_RESALTANTE_bs.DataSource = FICHA_bs;
        }
        void guardar()
        {
            if (validar)
            {
                cFicha_Catastral_Especifica ficha_catastral_especifica = new cFicha_Catastral_Especifica();
                ficha_catastral_especifica.Ficha = ficha_lbl.Text.Trim();
                ficha_catastral_especifica.Parcial_Ficha = parcialFichas_txt.Text;
                ficha_catastral_especifica.Total_Fichas = totalFichas_txt.Text;
                ficha_catastral_especifica.Departamento = departamento_lbl.Text;
                ficha_catastral_especifica.Provincia = provincia_lbl.Text;
                ficha_catastral_especifica.Distrito = distrito_lbl.Text;
                ficha_catastral_especifica.Sector = (sectorVia_txt.Text.Length>0)?sectorVia_txt.Text: sectorEspacioRecreacion_txt.Text;
                vias.Codigo = (codigoVia_txt.Text.Length > 0) ? codigoVia_txt.Text : null;
                ficha_catastral_especifica.Vias = vias;
                ficha_catastral_especifica.Cuadra = cuadraVia_txt.Text;
                ficha_catastral_especifica.Manzana = manzanaEspacioRecreacion_txt.Text;
                ficha_catastral_especifica.Lote = loteEspacioRecreacion_txt.Text;  
                //
                ficha_catastral_especifica.Observaciones = observaciones_txt.Text;
                //Estado de Llenado de la Ficha
                estado_llenado_ficha.Codigo = (estadoLlenadoFicha_txt.Text.Length > 0) ? estadoLlenadoFicha_txt.Text : null;
                ficha_catastral_especifica.Estado_Llenado_Ficha = estado_llenado_ficha;
                supervisor.DNI = cPersonal.DNI_Supervisor;
                ficha_catastral_especifica.Supervisor = supervisor;
                ficha_catastral_especifica.Fecha_Supervisor = fechaSupervisor_txt.Value;
                tecnico_catastral.DNI = cPersonal.DNI_Tecnico_Catastral;
                ficha_catastral_especifica.Tecnico_Catastral = tecnico_catastral;
                ficha_catastral_especifica.Fecha_Tecnico_Catastral = fechaTecnicoCatastral_txt.Value;
                digitacion.DNI = cPersonal.DNI_Digitacion;
                ficha_catastral_especifica.Digitacion = digitacion;
                ficha_catastral_especifica.Fecha_Digitacion = fechaDigitacion_txt.Value;                
                ficha_catastral_especifica.Usuario = Usuario;
                i = ficha_catastral_especifica.guardar();
                if (i > 0)
                {
                    if (FICHA_dgv.RowCount > 0)
                    { 
                        (new cFicha_Catastral_Especifica_Uso_Resaltante()).actualizar(FICHA_ds);                         
                        MessageBox.Show("Se a Insertando Correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    }
                }
                else MessageBox.Show("Error Guardar, Ficha Catastral Específica.", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                iniciar();
            }
        }
        void modificar()
        {            
            if (validar)
            {
                cFicha_Catastral_Especifica ficha_catastral_especifica = new cFicha_Catastral_Especifica();
                ficha_catastral_especifica.Ficha = ficha_lbl.Text.Trim();
                ficha_catastral_especifica.Parcial_Ficha = parcialFichas_txt.Text;
                ficha_catastral_especifica.Total_Fichas = totalFichas_txt.Text;
                ficha_catastral_especifica.Departamento = departamento_lbl.Text;
                ficha_catastral_especifica.Provincia = provincia_lbl.Text;
                ficha_catastral_especifica.Distrito = distrito_lbl.Text;
                ficha_catastral_especifica.Sector = (sectorVia_txt.Text.Length > 0) ? sectorVia_txt.Text : sectorEspacioRecreacion_txt.Text;
                vias.Codigo = (codigoVia_txt.Text.Length > 0) ? codigoVia_txt.Text : null;
                ficha_catastral_especifica.Vias = vias;
                ficha_catastral_especifica.Cuadra = cuadraVia_txt.Text;
                ficha_catastral_especifica.Manzana = manzanaEspacioRecreacion_txt.Text;
                ficha_catastral_especifica.Lote = loteEspacioRecreacion_txt.Text;
                //
                ficha_catastral_especifica.Observaciones = observaciones_txt.Text;
                //Estado de Llenado de la Ficha
                estado_llenado_ficha.Codigo = (estadoLlenadoFicha_txt.Text.Length > 0) ? estadoLlenadoFicha_txt.Text : null;
                ficha_catastral_especifica.Estado_Llenado_Ficha = estado_llenado_ficha;
                supervisor.DNI = cPersonal.DNI_Supervisor;
                ficha_catastral_especifica.Supervisor = supervisor;
                ficha_catastral_especifica.Fecha_Supervisor = fechaSupervisor_txt.Value;
                tecnico_catastral.DNI = cPersonal.DNI_Tecnico_Catastral;
                ficha_catastral_especifica.Tecnico_Catastral = tecnico_catastral;
                ficha_catastral_especifica.Fecha_Tecnico_Catastral = fechaTecnicoCatastral_txt.Value;
                digitacion.DNI = cPersonal.DNI_Digitacion;
                ficha_catastral_especifica.Digitacion = digitacion;
                ficha_catastral_especifica.Fecha_Digitacion = fechaDigitacion_txt.Value;
                ficha_catastral_especifica.Usuario = Usuario;
                i = ficha_catastral_especifica.modificar();
                if (i > 0)
                {
                    if (FICHA_dgv.RowCount > 0)
                    {
                        (new cFicha_Catastral_Especifica_Uso_Resaltante()).actualizar(FICHA_ds);                         
                        MessageBox.Show("Se a Modificado Correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    }
                }
                else MessageBox.Show("Error Modificar, Ficha Catastral de Específica.", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                iniciar();
            }
        }
        void eliminar()
        {
            cFicha_Catastral_Especifica ficha_catastral_especifica = new cFicha_Catastral_Especifica();
            ficha_catastral_especifica.Ficha = ficha_lbl.Text.Trim();
            ficha_catastral_especifica.Usuario = Usuario;
            i = ficha_catastral_especifica.eliminar();
            if (i >= 2)
            {
                if (FICHA_dgv.RowCount > 0) MessageBox.Show("Se a Eliminado Correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);                                    
            }
            else MessageBox.Show("Error Eliminar, Ficha Catastral Específica", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            iniciar();
        }
        internal void listar_codigo_vias()
        {
            codigoVia_txt.AutoCompleteCustomSource.AddRange(vias.listar_arreglo());
        }        
        internal void listar_estado_llenado_ficha()
        {
            estadoLlenadoFicha_txt.AutoCompleteCustomSource.AddRange(estado_llenado_ficha.listar_arreglo());
        }
        bool buscar_codigo_vias()
        {
            return vias.buscar(codigoVia_txt.Text);
        }
        bool buscar_estado_llenado_ficha()
        {
            return estado_llenado_ficha.buscar(estadoLlenadoFicha_txt.Text);
        }
        #endregion

        #region [ METODOS FICHA CATASTRAL ESPECIFICA - USO RESALTANTE ]
        internal void listar_tipo_uso_resaltante()
        {
            tipoUsoResaltante_txt.AutoCompleteCustomSource.AddRange(tipo_uso_resaltante.listar_arreglo());
        }
        void listar_clasificacion_uso_resaltante()
        {
            clasificacionUsoResaltante_txt.AutoCompleteCustomSource.Clear();
            clasificacionUsoResaltante_txt.Text = "";
            clasificacionUsoResaltante_txt.AutoCompleteCustomSource.AddRange(clasificacion_uso_resaltante.listar_arreglo(tipoUsoResaltante_txt.Text));
            clasificacionUsoResaltante_txt.Enabled = (clasificacionUsoResaltante_txt.AutoCompleteCustomSource.Count > 0) ? true : false;
            if (clasificacionUsoResaltante_txt.Enabled) clasificacionUsoResaltante_txt.Focus();
            else
            {
                clasificacionUsoResaltante_txt.Text = "";
                puntoXUsoResaltante_txt.Focus();                
            }
        }
        bool buscar_tipo_uso_resaltante()
        {
            return tipo_uso_resaltante.buscar(tipoUsoResaltante_txt.Text);
        }
        bool buscar_clasificacion_uso_resaltante()
        {            
            return clasificacion_uso_resaltante.buscar(tipoUsoResaltante_txt.Text,clasificacionUsoResaltante_txt.Text);
        }
        #endregion
        #endregion        

        #region Eventos
        #region [ EVENTOS FICHA CATASTRAL ESPECIFICA ]
        private void listar_Load(object sender, EventArgs e)
        {
            try
            {
                //Ficha Catastal Específica
                listar();
                habilitar_controles_ficha = false;
                listar_codigo_vias();                
                listar_estado_llenado_ficha();

                //Uso Resaltante
                listar_tipo_uso_resaltante();
                clasificacionUsoResaltante_txt.AutoCompleteCustomSource.AddRange(clasificacion_uso_resaltante.listar_arreglo(tipoUsoResaltante_txt.Text));
                
                #region Bindings - Ficha Catastral de Especifica
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
                sectorVia_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "SECTOR", true));
                codigoVia_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CODIGO DE VIA", true));
                cuadraVia_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "CUADRA", true));
                sectorEspacioRecreacion_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "SECTOR", true));
                manzanaEspacioRecreacion_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "MANZANA", true));
                loteEspacioRecreacion_txt.DataBindings.Add(new Binding("Text", FICHA_bs, "LOTE", true));                
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

                #region Bindings - Uso Resaltante
                USO_RESALTANTE_dgv.Columns["ID"].Visible = false;
                USO_RESALTANTE_dgv.Columns["ORDEN"].Visible = false;
                USO_RESALTANTE_dgv.Columns["TUR"].Visible = false;
                USO_RESALTANTE_dgv.Columns["CUR"].Visible = false;
                USO_RESALTANTE_dgv.Columns["PUNTO Z"].Visible = false;
                USO_RESALTANTE_dgv.Columns["ESTADO"].Visible = false;
                USO_RESALTANTE_dgv.Columns["USUARIO CREA"].Visible = false;
                USO_RESALTANTE_dgv.Columns["FECHA DE CREACION"].Visible = false;
                USO_RESALTANTE_dgv.Columns["USUARIO MODIFICA"].Visible = false;
                USO_RESALTANTE_dgv.Columns["FECHA DE MODIFICACION"].Visible = false;
                USO_RESALTANTE_dgv.Columns["FICHA"].Visible = false;                
                ((DataGridViewImageColumn)USO_RESALTANTE_dgv.Columns["FOTOGRAFIA DIGITAL"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                USO_RESALTANTE_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
                USO_RESALTANTE_dgv.RowTemplate.Height = 100;
                IDUsoResaltante_lbl.DataBindings.Add(new Binding("Text", USO_RESALTANTE_bs, "ID", true));
                fotografiaDigitalUsoResaltante_pb.DataBindings.Add(new Binding("Image", USO_RESALTANTE_bs, "FOTOGRAFIA DIGITAL", true));
                sectorUsoResaltante_lbl.DataBindings.Add(new Binding("Text", USO_RESALTANTE_bs, "SECTOR", true));
                manzanaCodigoViaUsoResaltante_lbl.DataBindings.Add(new Binding("Text", USO_RESALTANTE_bs, "CODIGO DE VIA / MANZANA", true));
                loteCuadraUsoResaltante_lbl.DataBindings.Add(new Binding("Text", USO_RESALTANTE_bs, "CUADRA / LOTE", true));
                añoFotografiaDigitalUsoResaltante_txt.DataBindings.Add(new Binding("Text", USO_RESALTANTE_bs, "AÑO", true));
                direccionUsoResaltante_txt.DataBindings.Add(new Binding("Text", USO_RESALTANTE_bs, "DIRECCION", true));
                tipoUsoResaltante_txt.DataBindings.Add(new Binding("Text", USO_RESALTANTE_bs, "TUR", true));
                clasificacionUsoResaltante_txt.DataBindings.Add(new Binding("Text", USO_RESALTANTE_bs, "CUR", true));
                puntoXUsoResaltante_txt.DataBindings.Add(new Binding("Text", USO_RESALTANTE_bs, "PUNTO X", true));
                puntoYUsoResaltante_txt.DataBindings.Add(new Binding("Text", USO_RESALTANTE_bs, "PUNTO Y", true));
                especificacionesUsoResaltante_txt.DataBindings.Add(new Binding("Text", USO_RESALTANTE_bs, "ESPECIFICACIONES", true));
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
                //Uso Resaltante
                iniciar_uso_resaltante = true;
                aceptarUsoResaltante.Enabled = false;

                FICHA_bs.EndEdit();
                FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_ESPECIFICARow datos = FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_ESPECIFICA.FindByFICHA("0000000000");
                if (datos != null)
                {
                    datos.BeginEdit();
                    ficha_lbl.Text = (new cFicha_Catastral_Especifica()).nuevo_codigo();
                    datos.FICHA = ficha_lbl.Text.Trim();
                    datos.FECHA_SUPERVISOR = DateTime.Now;
                    datos.FECHA_TECNICO_CATASTRAL = DateTime.Now;
                    datos.FECHA_VB_DIGITACION = DateTime.Now;
                    datos.EndEdit();
                    FICHA_bs.Filter = string.Format("FICHA = {0}", ficha_lbl.Text);
                    buscar_tst.Text = "";
                }
                sectorVia_txt.Focus();
            }
        }

        private void aceptar_tsb_Click(object sender, EventArgs e)
        {
            try
            {
                if (estadoLlenadoFicha_txt.Text.Length == 0)
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage2;
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
                    
                    if (!buscar_estado_llenado_ficha())
                    {
                        estadoLlenadoFicha_txt_Leave(sender, e);
                        return;
                    }                    

                    if (habilitar_controles_uso_resaltante)
                    {
                        if (aceptarUsoResaltante.Text == "Aceptar" || aceptarUsoResaltante.Text == "Agregar Uso Resaltante")
                        {
                            principal_tc.SelectedTab = formulario_tp;
                            secundario_tc.SelectedTab = tabPage1;
                            uso_resaltante_tc.SelectedTab = tabPage4;
                            aceptarUsoResaltante.ForeColor = Color.Red;
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
                            //Uso Resaltante
                            habilitar_movimiento_uso_resaltante = true;
                            nuevoUsoResaltante.Enabled = true;
                            aceptarUsoResaltante.Enabled = (USO_RESALTANTE_dgv.RowCount == 0) ? false : true;
                            eliminarUsoResaltante.Enabled = (USO_RESALTANTE_dgv.RowCount == 0) ? false : true;

                            sectorVia_txt.Focus();
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
                FICHA_ds rpt = (new cFicha_Catastral_Especifica()).reporte();
                if (rpt != null)
                {
                    DataView vista = rpt.VS_REPORTE_FICHA_CATASTRAL_ESPECIFICA.DefaultView;
                    vista.RowFilter = query;
                    DataTable tabla = vista.ToTable();
                    Reporte reporte = (tabla.Rows.Count > 0) ? new Reporte('2', tabla) : new Reporte('2', rpt);
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
                    parcialFichas_lbl.BackColor = Color.LemonChiffon;
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
            else if (parcialFichas_lbl.BackColor == Color.Red) parcialFichas_lbl.BackColor = Color.LemonChiffon;
        }

        private void totalFichas_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (totalFichas_txt.Text.Length > 0)
                {
                    totalFichas_lbl.BackColor = Color.LemonChiffon;
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
            else if (totalFichas_lbl.BackColor == Color.Red) totalFichas_lbl.BackColor = Color.LemonChiffon;
        }

        private void sectorVia_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (sectorVia_txt.Text.Length == 2)
                {
                    sectorVia_lbl.BackColor = Color.LemonChiffon;
                    sectorVia_txt.ForeColor = Color.Black;
                    sectorEspacioRecreacion_txt.Text = sectorVia_txt.Text;                    
                }
                else
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage1;
                    sectorVia_lbl.BackColor = Color.Red;
                    sectorVia_txt.Focus();
                    sectorVia_txt.SelectAll();
                    sectorVia_txt.ForeColor = Color.Red;
                    sectorEspacioRecreacion_txt.Text = "";
                }
            }
            else if (sectorVia_lbl.BackColor == Color.Red) sectorVia_lbl.BackColor = Color.LemonChiffon;
        }

        private void codigoVia_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (codigoVia_txt.Text != "")
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
                    }
                    else
                    {
                        codigoVia_lbl.BackColor = Color.LemonChiffon;
                        codigoVia_txt.ForeColor = Color.Black;                         
                    }
                }  
            }
            else if (codigoVia_lbl.BackColor == Color.Red) codigoVia_lbl.BackColor = Color.LemonChiffon;
        }

        private void cuadraVia_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (codigoVia_txt.Text.Length == 3)
                {
                    if (cuadraVia_txt.Text.Length == 2) 
                    {
                        cuadraVia_lbl.BackColor = Color.LemonChiffon;
                        cuadraVia_txt.ForeColor = Color.Black;                        
                    }
                    else
                    {
                        principal_tc.SelectedTab = formulario_tp;
                        secundario_tc.SelectedTab = tabPage1;
                        cuadraVia_lbl.BackColor = Color.Red;
                        cuadraVia_txt.Focus();
                        cuadraVia_txt.SelectAll();
                        cuadraVia_txt.ForeColor = Color.Red;
                    }
                }
            }
            else if (cuadraVia_lbl.BackColor == Color.Red) cuadraVia_lbl.BackColor = Color.LemonChiffon;
        }        

        private void manzanaEspacioRecreacion_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (manzanaEspacioRecreacion_txt.Text != "")
                {
                    if (manzanaEspacioRecreacion_txt.Text.Length == 3 || manzanaEspacioRecreacion_txt.Text.Length == 0)
                    {
                        manzanaEspacioRecreacion_lbl.BackColor = Color.LemonChiffon;
                        manzanaEspacioRecreacion_txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        principal_tc.SelectedTab = formulario_tp;
                        secundario_tc.SelectedTab = tabPage1;
                        manzanaEspacioRecreacion_lbl.BackColor = Color.Red;
                        manzanaEspacioRecreacion_txt.Focus();
                        manzanaEspacioRecreacion_txt.SelectAll();
                        manzanaEspacioRecreacion_txt.ForeColor = Color.Red;
                    }
                }                
            }
            else if (manzanaEspacioRecreacion_lbl.BackColor == Color.Red) manzanaEspacioRecreacion_lbl.BackColor = Color.LemonChiffon;
        }

        private void loteEspacioRecreacion_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                if (loteEspacioRecreacion_txt.Text.Length == 3 || loteEspacioRecreacion_txt.Text.Length == 0)
                {
                    loteEspacioRecreacion_lbl.BackColor = Color.LemonChiffon;
                    loteEspacioRecreacion_txt.ForeColor = Color.Black;
                }
                else
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage1;
                    loteEspacioRecreacion_lbl.BackColor = Color.Red;
                    loteEspacioRecreacion_txt.Focus();
                    loteEspacioRecreacion_txt.SelectAll();
                    loteEspacioRecreacion_txt.ForeColor = Color.Red;
                }
            }
            else if (loteEspacioRecreacion_lbl.BackColor == Color.Red) loteEspacioRecreacion_lbl.BackColor = Color.LemonChiffon;
        }       

        private void estadoLlenadoFicha_txt_Leave(object sender, EventArgs e)
        {
            if (habilitar_controles_ficha)
            {
                estadoLlenadoFicha_txt.Text = (estadoLlenadoFicha_txt.Text.Length > 2) ? estadoLlenadoFicha_txt.Text.Substring(0, 2) : estadoLlenadoFicha_txt.Text;
                if (buscar_estado_llenado_ficha())                                
                {
                    estadoLlenadoFicha_lbl.BackColor = Color.LemonChiffon;
                    estadoLlenadoFicha_txt.ForeColor = Color.Black;
                }
                else
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage2;
                    estadoLlenadoFicha_lbl.BackColor = Color.Red;
                    estadoLlenadoFicha_txt.Focus();
                    estadoLlenadoFicha_txt.SelectAll();
                    estadoLlenadoFicha_txt.ForeColor = Color.Red;
                }
            }
            else if (estadoLlenadoFicha_txt.BackColor == Color.Red) estadoLlenadoFicha_txt.BackColor = Color.LemonChiffon;
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

        #region [ EVENTOS FICHA CATASTRAL ESPECIFICA - USO RESALTANTE ]
        private void nuevoUsoResaltante_Click(object sender, EventArgs e)
        {
            if ((sectorVia_txt.Text.Length == 2 && codigoVia_txt.Text.Length == 3 && cuadraVia_txt.Text.Length == 2) || manzanaEspacioRecreacion_txt.Text.Length == 3)
            {
                habilitar_movimiento_uso_resaltante = false;
                habilitar_controles_uso_resaltante = true;
                aceptarUsoResaltante.Enabled = true;
                aceptarUsoResaltante.Text = "Agregar Uso Resaltante";
                aceptarUsoResaltante.Image = (Image)(resources.GetObject("aceptarUsoResaltante.Image"));
                nuevoUsoResaltante.Enabled = false;
                eliminarUsoResaltante.Enabled = false;
                cancelarUsoResaltante.Enabled = true;                
                USO_RESALTANTE_bs.AddNew();
                fotografiaDigitalUsoResaltante_pb_Click(sender, e);
            }
        }

        private void eliminarUsoResaltante_Click(object sender, EventArgs e)
        {
            USO_RESALTANTE_bs.RemoveAt(USO_RESALTANTE_bs.Position);
            if (USO_RESALTANTE_dgv.RowCount == 0)
            {
                aceptarUsoResaltante.Enabled = false;
                cancelarUsoResaltante.Enabled = false;
                eliminarUsoResaltante.Enabled = false;
            }
        }

        private void aceptarUsoResaltante_Click(object sender, EventArgs e)
        {
            try
            {
                if (tipoUsoResaltante_txt.Text.Length != 2) 
                {
                    tipoUsoResaltante_txt_Leave(sender, e);
                    return;
                }
                if (clasificacionUsoResaltante_txt.AutoCompleteCustomSource.Count>0)
                {
                    clasificacionUsoResaltante_txt_Leave(sender, e);                    
                }
                if (clasificacionUsoResaltante_lbl.BackColor == Color.Red)
                {
                    clasificacionUsoResaltante_txt.Focus();
                    return;
                }                

                if (aceptarUsoResaltante.Text == "Agregar Uso Resaltante")
                {
                    USO_RESALTANTE_bs.EndEdit();
                    long id = long.Parse(USO_RESALTANTE_dgv["ID", USO_RESALTANTE_dgv.CurrentRow.Index].Value.ToString());
                    FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_ESPECIFICA_USO_RESALTANTERow datos = FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_ESPECIFICA_USO_RESALTANTE.FindByID(id);
                    if (datos != null)
                    {
                        datos.BeginEdit();
                        datos.FOTOGRAFIA_DIGITAL = (fotografiaDigitalUsoResaltante_pb.Image != null) ? ((fotografiaDigitalUsoResaltante_pb.ImageLocation != null) ? File.ReadAllBytes(fotografiaDigitalUsoResaltante_pb.ImageLocation) : cConfiguracion.toBytes(fotografiaDigitalUsoResaltante_pb.Image)) : null;                        
                        datos.AÑO = (añoFotografiaDigitalUsoResaltante_txt.Text.Length == 0) ? DateTime.Now.Year.ToString() : añoFotografiaDigitalUsoResaltante_txt.Text.Trim();
                        datos.SECTOR = sectorUsoResaltante_lbl.Text;
                        datos._CODIGO_DE_VIA___MANZANA = manzanaCodigoViaUsoResaltante_lbl.Text;
                        datos._CUADRA___LOTE = loteCuadraUsoResaltante_lbl.Text;
                        datos.DIRECCION = direccionUsoResaltante_txt.Text;
                        datos.TUR = tipoUsoResaltante_txt.Text;
                        datos.CUR = clasificacionUsoResaltante_txt.Text;
                        datos.PUNTO_X = (puntoXUsoResaltante_txt.Text.Length >0)? double.Parse(puntoXUsoResaltante_txt.Text):0;
                        datos.PUNTO_Y = (puntoYUsoResaltante_txt.Text.Length >0)? double.Parse(puntoYUsoResaltante_txt.Text):0;
                        datos.PUNTO_Z = 0;
                        datos.ESPECIFICACIONES = especificacionesUsoResaltante_txt.Text;
                        datos.ESTADO = "A";
                        datos.USUARIO_CREA = Usuario;
                        datos.FECHA_DE_CREACION = DateTime.Now;
                        datos.USUARIO_MODIFICA = Usuario;
                        datos.FECHA_DE_MODIFICACION = DateTime.Now;
                        datos.FICHA = ficha_lbl.Text.Trim();
                        datos.EndEdit();                     
                    }
                    habilitar_movimiento_uso_resaltante = true;
                    habilitar_controles_uso_resaltante = false;
                    iniciar_uso_resaltante = true;
                }
                else if (aceptarUsoResaltante.Text == "Modificar Uso Resaltante")
                {
                    principal_tc.SelectedTab = formulario_tp;
                    uso_resaltante_tc.SelectedTab = tabPage4;
                    habilitar_movimiento_uso_resaltante = false;
                    habilitar_controles_uso_resaltante = true;
                    aceptarUsoResaltante.Text = "Aceptar";
                    aceptarUsoResaltante.Image = null;
                    nuevoUsoResaltante.Enabled = false;
                    eliminarUsoResaltante.Enabled = false;
                    tipoUsoResaltante_txt_Leave(sender, e);                    
                    añoFotografiaDigitalUsoResaltante_txt.Focus();
                }
                else if (aceptarUsoResaltante.Text == "Aceptar")
                {
                    FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_ESPECIFICA_USO_RESALTANTERow datos = FICHA_ds.VS_LISTAR_FICHA_CATASTRAL_ESPECIFICA_USO_RESALTANTE.FindByID(long.Parse(IDUsoResaltante_lbl.Text));
                    if (datos != null)
                    {
                        datos.BeginEdit();
                        datos.FOTOGRAFIA_DIGITAL = (fotografiaDigitalUsoResaltante_pb.Image != null) ? ((fotografiaDigitalUsoResaltante_pb.ImageLocation != null) ? File.ReadAllBytes(fotografiaDigitalUsoResaltante_pb.ImageLocation) : cConfiguracion.toBytes(fotografiaDigitalUsoResaltante_pb.Image)) : null;                        
                        datos.AÑO = (añoFotografiaDigitalUsoResaltante_txt.Text.Length == 0) ? DateTime.Now.Year.ToString() : añoFotografiaDigitalUsoResaltante_txt.Text.Trim();
                        datos.SECTOR = sectorUsoResaltante_lbl.Text;
                        datos._CODIGO_DE_VIA___MANZANA = manzanaCodigoViaUsoResaltante_lbl.Text;
                        datos._CUADRA___LOTE = loteCuadraUsoResaltante_lbl.Text;
                        datos.DIRECCION = direccionUsoResaltante_txt.Text;
                        datos.TUR = tipoUsoResaltante_txt.Text;
                        datos.CUR = clasificacionUsoResaltante_txt.Text;
                        datos.PUNTO_X = (puntoXUsoResaltante_txt.Text.Length > 0) ? double.Parse(puntoXUsoResaltante_txt.Text) : 0;
                        datos.PUNTO_Y = (puntoYUsoResaltante_txt.Text.Length > 0) ? double.Parse(puntoYUsoResaltante_txt.Text) : 0;
                        datos.PUNTO_Z = 0;
                        datos.ESPECIFICACIONES = especificacionesUsoResaltante_txt.Text;
                        datos.ESTADO = "A";                        
                        datos.USUARIO_MODIFICA = Usuario;
                        datos.FECHA_DE_MODIFICACION = DateTime.Now;
                        datos.FICHA = ficha_lbl.Text.Trim();
                        datos.EndEdit();                        
                    }
                    habilitar_movimiento_uso_resaltante = true;
                    habilitar_controles_uso_resaltante = false;
                    iniciar_uso_resaltante = true;
                }
            }
            catch (Exception ex)
            {
                cancelarUsoResaltante_Click(sender, e);
                MessageBox.Show(ex.Message, "Error Agregar y/o Modificar, Uso Resaltante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelarUsoResaltante_Click(object sender, EventArgs e)
        {
            uso_resaltante_tc.SelectedTab = tabPage4;
            USO_RESALTANTE_bs.CancelEdit();
            habilitar_controles_uso_resaltante = false;
            habilitar_movimiento_uso_resaltante = true;
            iniciar_uso_resaltante = true;
        }

        private void fotografiaDigitalUsoResaltante_pb_Click(object sender, EventArgs e)
        {
            if (sectorVia_txt.Text.Length == 2 && buscar_codigo_vias() && cuadraVia_txt.Text.Length == 2) 
            {
                DialogResult rpta = AbrirFotografia.ShowDialog();
                if (rpta == System.Windows.Forms.DialogResult.OK)
                {
                    fotografiaDigitalUsoResaltante_pb.ImageLocation = AbrirFotografia.FileName;
                    sectorUsoResaltante_lbl.Text = sectorVia_txt.Text;
                    manzanaCodigoViaUsoResaltante_lbl.Text = codigoVia_txt.Text;
                    loteCuadraUsoResaltante_lbl.Text = cuadraVia_txt.Text;                    
                    añoFotografiaDigitalUsoResaltante_txt.Text = DateTime.Now.Year.ToString();
                    DataRow fila = vias.Buscar(codigoVia_txt.Text.Trim());
                    if (fila != null) direccionUsoResaltante_txt.Text = fila["TIPO DE VIA"].ToString() + " " + fila["NOMBRE DE VIA"].ToString(); ;
                  
                }
                else
                {
                    fotografiaDigitalUsoResaltante_pb.ImageLocation = "";
                    sectorUsoResaltante_lbl.Text = "";
                    manzanaCodigoViaUsoResaltante_lbl.Text = "";
                    loteCuadraUsoResaltante_lbl.Text = "";                    
                    añoFotografiaDigitalUsoResaltante_txt.Text = "";
                  
                }
                añoFotografiaDigitalUsoResaltante_txt.Focus();
            }            
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage1;
                uso_resaltante_tc.SelectedTab  = tabPage4;
                if (sectorVia_txt.Text.Length == 0) sectorVia_txt.Focus();
                if (codigoVia_txt.Text.Length == 0) codigoVia_txt.Focus();
                if (cuadraVia_txt.Text.Length == 0) cuadraVia_txt.Focus();              
            }
            
            if(sectorEspacioRecreacion_txt.Text.Length == 2 && manzanaEspacioRecreacion_txt.Text.Length == 3)
            {
                DialogResult rpta = AbrirFotografia.ShowDialog();
                if (rpta == System.Windows.Forms.DialogResult.OK)
                {
                    fotografiaDigitalUsoResaltante_pb.ImageLocation = AbrirFotografia.FileName;
                    sectorUsoResaltante_lbl.Text = sectorEspacioRecreacion_txt.Text;
                    manzanaCodigoViaUsoResaltante_lbl.Text = manzanaEspacioRecreacion_txt.Text;
                    loteCuadraUsoResaltante_lbl.Text = loteEspacioRecreacion_txt.Text;
                    añoFotografiaDigitalUsoResaltante_txt.Text = DateTime.Now.Year.ToString();
                    direccionUsoResaltante_txt.Text = "";
                  
                }
                else
                {
                    fotografiaDigitalUsoResaltante_pb.ImageLocation = (AbrirFotografia.FileName != "") ? AbrirFotografia.FileName : "";
                    sectorUsoResaltante_lbl.Text = "";
                    manzanaCodigoViaUsoResaltante_lbl.Text = "";
                    loteCuadraUsoResaltante_lbl.Text = "";
                    añoFotografiaDigitalUsoResaltante_txt.Text = "";

                }
                añoFotografiaDigitalUsoResaltante_txt.Focus();
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage1;
                if (sectorEspacioRecreacion_txt.Text.Length == 0) sectorEspacioRecreacion_txt.Focus();
                if (manzanaEspacioRecreacion_txt.Text.Length == 0) manzanaEspacioRecreacion_txt.Focus();
              
            }
        }

        private void añoFotografiaDigitalUsoResaltante_txt_Leave(object sender, EventArgs e)
        {
            if (añoFotografiaDigitalUsoResaltante_txt.Text.Length == 4 || añoFotografiaDigitalUsoResaltante_txt.Text.Length == 0)
            {
                añoFotografiaDigitalUsoResaltante_lbl.BackColor = Color.LemonChiffon;
                añoFotografiaDigitalUsoResaltante_txt.ForeColor = Color.Black;
            }
            else
            {
                principal_tc.SelectedTab = formulario_tp;
                secundario_tc.SelectedTab = tabPage1;
                uso_resaltante_tc.SelectedTab = tabPage4;
                añoFotografiaDigitalUsoResaltante_lbl.BackColor = Color.Red;
                añoFotografiaDigitalUsoResaltante_txt.Focus();
                añoFotografiaDigitalUsoResaltante_txt.SelectAll();
                añoFotografiaDigitalUsoResaltante_txt.ForeColor = Color.Red;
            }
            if (añoFotografiaDigitalUsoResaltante_lbl.BackColor == Color.Red && añoFotografiaDigitalUsoResaltante_txt.Enabled == false) añoFotografiaDigitalUsoResaltante_lbl.BackColor = Color.LemonChiffon;
        }

        private void tipoUsoResaltante_txt_Leave(object sender, EventArgs e)
        {
            if (añoFotografiaDigitalUsoResaltante_txt.Enabled)
            {
                tipoUsoResaltante_txt.Text = (tipoUsoResaltante_txt.Text.Length > 2) ? tipoUsoResaltante_txt.Text.Substring(0, 2) : tipoUsoResaltante_txt.Text;
                if (buscar_tipo_uso_resaltante())
                {
                    tipoUsoResaltante_lbl.BackColor = Color.LemonChiffon;
                    tipoUsoResaltante_txt.ForeColor = Color.Black;
                    listar_clasificacion_uso_resaltante();
                }
                else
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage1;
                    uso_resaltante_tc.SelectedTab = tabPage4;
                    tipoUsoResaltante_lbl.BackColor = Color.Red;
                    tipoUsoResaltante_txt.Focus();
                    tipoUsoResaltante_txt.SelectAll();
                    tipoUsoResaltante_txt.ForeColor = Color.Red;
                }
                if (tipoUsoResaltante_lbl.BackColor == Color.Red && tipoUsoResaltante_txt.Enabled == false) tipoUsoResaltante_lbl.BackColor = Color.LemonChiffon;
            }
        }

        private void clasificacionUsoResaltante_txt_Leave(object sender, EventArgs e)
        {
            if (clasificacionUsoResaltante_txt.AutoCompleteCustomSource.Count > 0)
            {
                clasificacionUsoResaltante_txt.Text = (clasificacionUsoResaltante_txt.Text.Length > 2) ? clasificacionUsoResaltante_txt.Text.Substring(0, 2) : clasificacionUsoResaltante_txt.Text;
                if (buscar_clasificacion_uso_resaltante())
                {
                    clasificacionUsoResaltante_lbl.BackColor = Color.LemonChiffon;
                    clasificacionUsoResaltante_txt.ForeColor = Color.Black;                    
                }
                else
                {
                    principal_tc.SelectedTab = formulario_tp;
                    secundario_tc.SelectedTab = tabPage1;
                    uso_resaltante_tc.SelectedTab = tabPage4;
                    clasificacionUsoResaltante_lbl.BackColor = Color.Red;                    
                    clasificacionUsoResaltante_txt.Focus();
                    clasificacionUsoResaltante_txt.SelectAll();
                    clasificacionUsoResaltante_txt.ForeColor = Color.Red;
                }
            }
            if (clasificacionUsoResaltante_lbl.BackColor == Color.Red && clasificacionUsoResaltante_txt.Enabled == false) clasificacionUsoResaltante_lbl.BackColor = Color.LemonChiffon;
        }

        private void USO_RESALTANTE_dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion
        #endregion
    }
}
