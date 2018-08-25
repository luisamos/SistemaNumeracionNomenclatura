using System;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Componentes;
using Alfanumerico.Rpt;

namespace Formularios
{
    /// <summary>
    /// Autor                   : Dunia
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    internal partial class Principal : Form
    {
        internal Principal()
        {
            InitializeComponent();
        }

        #region Atributos y Propiedades
        protected string Usuario;
        protected string clave;        
        protected cUsuario Usuarios = new cUsuario();
        protected string Administrador;
        int i = 0;
        #endregion

        #region Metodos
        void sub_proceso()
        {
            Thread th = new Thread(new ThreadStart(cuadro));
            th.IsBackground = true;
            th.Start();
            Thread.Sleep(1000);
            th.Abort();
            Thread.Sleep(500);
        }
        void cuadro()
        {
            (new Ayuda()).ShowDialog();
        }
        internal void formularios(Form hijo)
        {
            IEnumerable<Form> f = from c in MdiChildren
                                  where c.Name == hijo.Name
                                  select c;
            if (f.Count() > 0)
            {
                f.First().Activate();
                f.First().WindowState = FormWindowState.Normal;
                return;
            }
            hijo.MdiParent = this;
            hijo.Show();
        }
        void autenticarse()
        {
            if (i == 3) salir();
            WindowState = FormWindowState.Minimized;
            menuPrincipal.Enabled = false;
            Autenticarse a = new Autenticarse();
            if (i > 0) a.mensaje_lbl.Text = "Usuario y/o Contraseña incorrecta";
            DialogResult respuesta = a.ShowDialog();
            Usuario = a.usuario_txt.Text.Trim();
            clave = a.contraseña_txt.Text.Trim();
            if (respuesta == DialogResult.OK)
            {
                Administrador = Usuarios.autenticar(Usuario, clave);
                if (Administrador != "No Existe")
                {
                    menuPrincipal.Enabled = true;
                    sub_proceso();
                    WindowState = FormWindowState.Normal;
                    usuario_tslbl.Text = string.Format("    {0}: {1}", Administrador, Usuario.ToUpper());
                    baseDatos_tslbl.Text = string.Format("  |   Base de Datos: {0}", cConexion.BaseDatos);
                    fecha_tslbl.Text = string.Format("  |    Fecha: {0}", DateTime.Now.ToLongDateString());
                }
                else
                {
                    i++;
                    autenticarse();
                }
            }
            else if (respuesta == DialogResult.Cancel)
            {
                salir();
            }
        }
        
        void salir()
        {
            Application.Exit();
        }
        #endregion

        #region Eventos
        private void principal_Load(object sender, EventArgs e)
        {
            //autenticarse();
            this.Controls[2].BackColor = Color.White;            
            this.Controls[2].BackgroundImage = global::Alfanumerico.Properties.Resources.fondo;            
        }

        #region [ MENU CONFIGURACION ]
        private void mConfiguracionBaseDatos_Click(object sender, EventArgs e)
        {
            (new Configuracion_Base_Datos()).ShowDialog();
        }
        
        private void mSistemaConfiguracionUbicacionGeografica_Click(object sender, EventArgs e)
        {
            (new Configuracion_Ubicacion_Geografica()).ShowDialog();
        }

        private void mSistemaConfiguracionSupervisorTecnicoCatastralDigitacion_Click(object sender, EventArgs e)
        {
            (new Configuracion_Supervisor_Tecnico_Catastral_Digitacion()).ShowDialog();
        }

        private void mSistemaConfiguracionUsuario_Click(object sender, EventArgs e)
        {
            if (Administrador == "Administrador")
            {
                Administrador adm = new Administrador();
                adm.Text = "Cuentas de Usuario";                
                adm.Usuario = Usuario;
                adm.ShowDialog();
            }
            else if(Administrador == "Usuario") (new Usuario(Usuario)).ShowDialog();           
        }

        private void mSistemaConfiguraciónDelSistema_Click(object sender, EventArgs e)
        {
            (new Configuracion_Sistema()).ShowDialog();
        }

        private void mSistemaCerrarSesion_Click(object sender, EventArgs e)
        {
            Usuario = "";
            clave = "";
            i = 0;
            autenticarse();
        }

        private void mSalir_Click(object sender, EventArgs e)
        {
            salir();
        }
        #endregion

        #region [ MENU FICHAS ]
        private void mFichaCatastralViasUrbanas_Click(object sender, EventArgs e)
        {
            Ficha_Catastral_Vias_Urbanas Ficha_Catastral_Vias_Urbanas = new Ficha_Catastral_Vias_Urbanas();
            Ficha_Catastral_Vias_Urbanas.Usuario = Usuario;
            formularios(Ficha_Catastral_Vias_Urbanas);
        }

        private void mFichaCatastralEspecifica_Click(object sender, EventArgs e)
        {
            Ficha_Catastral_Especifica Ficha_Catastral_Especifica = new Ficha_Catastral_Especifica();
            Ficha_Catastral_Especifica.Usuario = Usuario;
            formularios(Ficha_Catastral_Especifica);
        }

        private void mFichaCatastralEspacioRecreacion_Click(object sender, EventArgs e)
        {
            Ficha_Catastral_Espacio_Recreacion Ficha_Catastral_Espacio_Recreacion = new Ficha_Catastral_Espacio_Recreacion();
            Ficha_Catastral_Espacio_Recreacion.Usuario = Usuario;
            formularios(Ficha_Catastral_Espacio_Recreacion);
        }

        private void mFichaCatastralEquipamientoUrbano_Click(object sender, EventArgs e)
        {
            Ficha_Catastral_Equipamiento_Urbano Ficha_Catastral_Equipamiento_Urbano = new Ficha_Catastral_Equipamiento_Urbano();
            Ficha_Catastral_Equipamiento_Urbano.Usuario = Usuario;
            formularios(Ficha_Catastral_Equipamiento_Urbano);
        }
        #endregion

        #region [ MENU MANTENIMIENTOS ]
        //Fichas Catastral de Vias Urbanas
        private void mMantenimientoSubFichaViasEstadoGeneralVia_Click(object sender, EventArgs e)
        {
            Estado_General_Via Estado_General_Via = new Estado_General_Via();
            Estado_General_Via.Text = "Ficha Catastral de Vías Urbanas - Estado General de la Vía";
            Estado_General_Via.Usuario = Usuario;
            Estado_General_Via.ShowDialog();            
        }

        private void mMantenimientoSubFichaViasLimite_Click(object sender, EventArgs e)
        {
            Limite Limite = new Limite();
            Limite.Text = "Ficha Catastral de Vías Urbanas - Limite";
            Limite.Usuario = Usuario;
            Limite.ShowDialog();
        }

        private void mMantenimientoSubFichaViasCondicionDeLimite_Click(object sender, EventArgs e)
        {
            Condicion_Limite Condicion_Limite = new Condicion_Limite();
            Condicion_Limite.Text = "Ficha Catastral de Vías Urbanas - Condición de Limite";
            Condicion_Limite.Usuario = Usuario;
            Condicion_Limite.ShowDialog();
        }

        private void mMantenimientoSubFichaViasHabilitacionUrbana_Click(object sender, EventArgs e)
        {
            Habilitacion_Urbana Habilitacion_Urbana = new Habilitacion_Urbana();
            Habilitacion_Urbana.Text = "Ficha Catastral de Vías Urbanas - Habilitación Urbana";
            Habilitacion_Urbana.Usuario = Usuario;
            Habilitacion_Urbana.ShowDialog();
        }

        private void mMantenimientoSubFichaViasMaterial_Click(object sender, EventArgs e)
        {
            Material_Ficha Material_Ficha = new Material_Ficha();
            Material_Ficha.Text = "Ficha Catastral de Vías Urbanas - Material";
            Material_Ficha.Usuario = Usuario;
            Material_Ficha.ShowDialog();
        }
        
        //Ficha Catastral de Espacios de Recreación
        private void mMantenimientoSubFichaEspacioRecreacionTipo_Click(object sender, EventArgs e)
        {
            Tipo_Espacio_Recreacion Tipo_Espacio_Recreacion = new Tipo_Espacio_Recreacion();
            Tipo_Espacio_Recreacion.Text = "Ficha Catastral de Espacios de Recreación - Tipo de Espacio de Recreación";
            Tipo_Espacio_Recreacion.Usuario = Usuario;
            Tipo_Espacio_Recreacion.ShowDialog();
        }

        private void mMantenimientoSubFichaEspacioRecreacionMaterial_Click(object sender, EventArgs e)
        {
            Material_Ficha Material_Ficha = new Material_Ficha();
            Material_Ficha.Text = "Ficha Catastral de Espacios de Recreación - Material";
            Material_Ficha.Usuario = Usuario;
            Material_Ficha.ShowDialog();
        }

        //Ficha Catastral Específica
        private void mMantenimientoSubFichaTipoUsoResaltante_Click(object sender, EventArgs e)
        {
            Tipo_Uso_Resaltante Tipo_Uso_Resaltante = new Tipo_Uso_Resaltante();
            Tipo_Uso_Resaltante.Text = "Ficha Catastral de Específica - Tipo de Uso Resaltante";
            Tipo_Uso_Resaltante.Usuario = Usuario;
            Tipo_Uso_Resaltante.ShowDialog();
        }

        private void mMantenimientoSubFichaClasificacionUsoResaltante_Click(object sender, EventArgs e)
        {
            Clasificacion_Uso_Resaltante Clasificacion_Uso_Resaltante = new Clasificacion_Uso_Resaltante();
            Clasificacion_Uso_Resaltante.Text = "Ficha Catastral de Específica - Clasificación de Uso Resaltante";
            Clasificacion_Uso_Resaltante.Usuario = Usuario;
            Clasificacion_Uso_Resaltante.ShowDialog();
        }

        //Ficha Catastral de Equipamiento Urbano
        private void mMantenimientoSubFichaEquipamientoUrbanoTipo_Click(object sender, EventArgs e)
        {
            Tipo_Equipamiento_Urbano Tipo_Equipamiento_Urbano = new Tipo_Equipamiento_Urbano();
            Tipo_Equipamiento_Urbano.Text = "Ficha Catastral de Equipamiento Urbano - Tipo de Equipamiento Urbano";
            Tipo_Equipamiento_Urbano.Usuario = Usuario;
            Tipo_Equipamiento_Urbano.ShowDialog();
        }

        private void mMantenimientoSubFichaEquipamientoUrbanoTipoDePuerta_Click(object sender, EventArgs e)
        {
            Tipo_Puerta Tipo_Puerta = new Tipo_Puerta();
            Tipo_Puerta.Text = "Ficha Catastral de Equipamiento Urbano - Tipo de Puerta";
            Tipo_Puerta.Usuario = Usuario;
            Tipo_Puerta.ShowDialog();
        }

        private void mMantenimientoSubFichaEquipamientoUrbanoCondicionDeNumeracion_Click(object sender, EventArgs e)
        {
            Condicion_Numeracion Condicion_Numeracion = new Condicion_Numeracion();
            Condicion_Numeracion.Text = "Ficha Catastral de Equipamiento Urbano - Condición de Numeración";
            Condicion_Numeracion.Usuario = Usuario;
            Condicion_Numeracion.ShowDialog();
        }

        private void mMantenimientoSubFichaEquipamientoUrbanoHabilitacionUrbana_Click(object sender, EventArgs e)
        {
            Habilitacion_Urbana Habilitacion_Urbana = new Habilitacion_Urbana();
            Habilitacion_Urbana.Text = "Ficha Catastral de Equipamiento Urbano - Habilitación Urbana";
            Habilitacion_Urbana.Usuario = Usuario;
            Habilitacion_Urbana.ShowDialog();
        }        

        //Vias
        private void mMantenimientoViasCondicionDeNombreDeLaVia_Click(object sender, EventArgs e)
        {
            Condicion_Nombre_Via Condicion_Nombre_Via = new Condicion_Nombre_Via();
            Condicion_Nombre_Via.Text = "Mantenimiento - Condición de Nombre de Vía";
            Condicion_Nombre_Via.Usuario = Usuario;
            Condicion_Nombre_Via.ShowDialog();
        }

        private void mMantenimientoViasClasificacionDeLaVia_Click(object sender, EventArgs e)
        {
            Clasificacion_Via Clasificacion_Via = new Clasificacion_Via();
            Clasificacion_Via.Text = "Mantenimiento - Clasificación de la Vía";
            Clasificacion_Via.Usuario = Usuario;
            Clasificacion_Via.ShowDialog();
        }
        private void mUsosSubFichaViasUsos_Click(object sender, EventArgs e)
        {
            Usos usos = new Usos();
            usos.Text = "Mantenimiento - Usos";
            usos.Usuario = Usuario;
            usos.ShowDialog();
        }
        
        private void mMantenimientoViasTipoDeVias_Click(object sender, EventArgs e)
        {
            Tipo_Via Tipo_Via = new Tipo_Via();
            Tipo_Via.Text = "Mantenimiento - Tipo de Vía";
            Tipo_Via.Usuario = Usuario;
            Tipo_Via.ShowDialog();
        }

        private void mMantenimientoVia_Click(object sender, EventArgs e)
        {
            Vias Vias = new Vias();
            Vias.Text = "Mantenimiento - Vías";
            Vias.Usuario = Usuario;
            Vias.ShowDialog();
        }

        // Otros
        private void mMantenimientoTipoDeComponentesUrbano_Click(object sender, EventArgs e)
        {
            Tipo_Componente_Urbano Tipo_Componente_Urbano = new Tipo_Componente_Urbano();
            Tipo_Componente_Urbano.Text = "Mantenimiento - Tipo de Componente Urbano";
            Tipo_Componente_Urbano.Usuario = Usuario;
            Tipo_Componente_Urbano.ShowDialog();
        }

        private void mMantenimientoTipoDeMobiliarioUrbano_Click(object sender, EventArgs e)
        {
            Tipo_Mobiliario_Urbano Tipo_Mobiliario_Urbano = new Tipo_Mobiliario_Urbano();
            Tipo_Mobiliario_Urbano.Text = "Mantenimiento - Tipo de Mobiliario Urbano";
            Tipo_Mobiliario_Urbano.Usuario = Usuario;
            Tipo_Mobiliario_Urbano.ShowDialog();
        }

        private void mMantenimientoMaterialComponenteMobiliarioUrbano_Click(object sender, EventArgs e)
        {
            Material Material = new Material();
            Material.Text = "Mantenimiento - Material Componente Urbano y/o Mobiliario Urbano";
            Material.Usuario = Usuario;
            Material.ShowDialog();
        }

        private void mMantenimientoEstadoDeConservación_Click(object sender, EventArgs e)
        {
            Estado_Conservacion Estado_Conservacion = new Estado_Conservacion();
            Estado_Conservacion.Text = "Mantenimiento - Estado de Conservación";
            Estado_Conservacion.Usuario = Usuario;
            Estado_Conservacion.ShowDialog();
        }

        private void mMantenimientoEstadoDeLlenadoDeLaFicha_Click(object sender, EventArgs e)
        {
            Estado_Llenado_Ficha Estado_Llenado_Ficha = new Estado_Llenado_Ficha();
            Estado_Llenado_Ficha.Text = "Mantenimiento - Estado de Llenado de Ficha";
            Estado_Llenado_Ficha.Usuario = Usuario;
            Estado_Llenado_Ficha.ShowDialog();
        }                

        private void mMantenimientoPersonal_Click(object sender, EventArgs e)
        {
            Personal Personal = new Personal();
            Personal.Text = "Mantenimiento - Personal";
            Personal.Usuario = Usuario;
            Personal.ShowDialog();
        }

        private void mUsosSubFichaEquipamientoUrbanoUsos_Click(object sender, EventArgs e)
        {
            Usos usos = new Usos();
            usos.Text = "Mantenimiento - Usos";
            usos.Usuario = Usuario;
            usos.ShowDialog();
        }
        private void mSubCodigoUsoSubFichaEquipamientoUrbano_Click(object sender, EventArgs e)
        {
            Uso_Sub_Codigo uso_sub_codigo = new Uso_Sub_Codigo();
            uso_sub_codigo.Text = "Mantenimiento -Sub Codigo Usos";
            uso_sub_codigo.Usuario = Usuario;
            uso_sub_codigo.ShowDialog();
        }

        private void mCodigoGeneralUsoSubFichaEquipamientoUrbano_Click(object sender, EventArgs e)
        {
            Uso_Codigo_General uso_general = new Uso_Codigo_General();
            uso_general.Text = "Mantenimiento - Codigo General";
            uso_general.Usuario = Usuario;
            uso_general.ShowDialog();
        }
        #endregion

        #region [ MENU REPORTES ]

        private void mReportesHabilitacionesUrbanas_Click(object sender, EventArgs e)
        {
            Reporte reporte = new Reporte(new habilitacion_urbana(), new cHabilitacion_Urbana().listar());
            reporte.Text = "Vista Previa, Habilitaciones Urbanas";
            reporte.ShowDialog();
        }

        private void mReportesVias_Click(object sender, EventArgs e)
        {
            Reporte reporte = new Reporte(new vias(), new cVias().listar());
            reporte.Text = "Vista Previa, Vías";
            reporte.ShowDialog();
        }

        private void reporteFichaCatastralViasUrbanas_Click(object sender, EventArgs e)
        {
            FICHA_ds rpt = (new cFicha_Catastral_Vias_Urbanas()).reporte();
            if (rpt != null)
            {
                Reporte reporte = new Reporte('1', rpt);
                reporte.Text = "Vista Previa, Ficha Catastral de Vias Urbanas";
                reporte.ShowDialog();
            }
        }

        private void reporteFichaCatastralEspecifica_Click(object sender, EventArgs e)
        {
            FICHA_ds rpt = (new cFicha_Catastral_Especifica()).reporte();
            if (rpt != null)
            {
                Reporte reporte = new Reporte('2', rpt);
                reporte.Text = "Vista Previa, Ficha Catastral Especifica";
                reporte.ShowDialog();
            }
        }

        private void reporteFichaCatastralEspacioRecreacion_Click(object sender, EventArgs e)
        {
            FICHA_ds rpt = (new cFicha_Catastral_Espacio_Recreacion()).reporte();
            if (rpt != null)
            {
                Reporte reporte = new Reporte('3', rpt);
                reporte.Text = "Vista Previa, Ficha Catastral Espacio de Recreación";
                reporte.ShowDialog();
            }
        }

        private void reporteFichaCatastralEquipamientoUrbano_Click(object sender, EventArgs e)
        {
            FICHA_ds rpt = (new cFicha_Catastral_Equipamiento_Urbano()).reporte();
            if (rpt != null)
            {
                Reporte reporte = new Reporte('4', rpt);
                reporte.Text = "Vista Previa, Ficha Catastral Equipamiento Urbano";
                reporte.ShowDialog();
            }
        }            
        #endregion

        #region [ MENU AYUDA ]
        private void m01_Click(object sender, EventArgs e)
        {
            cConfiguracion.abrir(string.Format(@"{0}\Manuales\m01.pdf",cConfiguracion.Ruta));
        }

        private void m02_Click(object sender, EventArgs e)
        {
            cConfiguracion.abrir(string.Format(@"{0}\Manuales\m02.pdf", cConfiguracion.Ruta));
        }

        private void m03_Click(object sender, EventArgs e)
        {
            cConfiguracion.abrir(string.Format(@"{0}\Manuales\m03.pdf", cConfiguracion.Ruta));
        }

        private void m04_Click(object sender, EventArgs e)
        {
            cConfiguracion.abrir(string.Format(@"{0}\Manuales\m04.pdf", cConfiguracion.Ruta));
        }

        private void m05_Click(object sender, EventArgs e)
        {
            cConfiguracion.abrir(string.Format(@"{0}\Manuales\m05.pdf", cConfiguracion.Ruta));
        }

        private void m06_Click(object sender, EventArgs e)
        {
            cConfiguracion.abrir(string.Format(@"{0}\Manuales\m06.pdf", cConfiguracion.Ruta));
        }

        private void acercaDe_Click(object sender, EventArgs e)
        {
            (new Ayuda()).ShowDialog();
        }
        #endregion


      
        #endregion

 
    }
}
 
