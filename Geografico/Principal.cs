using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Componentes;
using Clases;
using Formularios;
//AutoCAD API
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Interop;
using Autodesk.AutoCAD.Runtime;
//Map Platform API
using Autodesk.Gis.Map.Platform;
//Geospatial Platform API
using OSGeo.MapGuide;

[assembly: ExtensionApplication(typeof(Geografico.Menu))]
[assembly: CommandClass(typeof(Geografico.Comandos))]
namespace Geografico
{
    /// <summary>
    /// Menu - Sistema de Numeración y Nomenclatura - Parte Geográfica. © Centro Guaman Poma de Ayala - Área Informática.
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    public class Menu : IExtensionApplication
    {
        /// <summary>
        /// Inicia la construcción del Menu de controles.
        /// </summary>
        public void Initialize()
        {
            try
            {                
                AcadApplication acad_app = (AcadApplication)Autodesk.AutoCAD.ApplicationServices.Application.AcadApplication;
                AcadToolbar acad_toolbar = acad_app.MenuGroups.Item(0).Toolbars.Add("Sistema de Numeración y Nomenclatura");
                AcadToolbarItem buton1 = acad_toolbar.AddToolbarButton(0, "Configuración - Ubicación Geográfica", "Ubicación Geográfica", "ubicacion ");
                buton1.SetBitmaps(cConexion.Ruta + @"\Img\ubicacion.bmp", cConexion.Ruta + @"\Img\ubicacion.bmp");
                AcadToolbarItem buton2 = acad_toolbar.AddToolbarButton(1, "Configuración - Base de Datos", "Base de Datos", "datos ");
                buton2.SetBitmaps(cConexion.Ruta + @"\Img\datos.bmp", cConexion.Ruta + @"\Img\datos.bmp");
                AcadToolbarItem buton3 = acad_toolbar.AddToolbarButton(2, "Sector - Cargar", "Cargar Sectores", "s1 ");
                buton3.SetBitmaps(cConexion.Ruta + @"\Img\cargar_sector.bmp", cConexion.Ruta + @"\Img\cargar_sector.bmp");
                AcadToolbarItem buton4 = acad_toolbar.AddToolbarButton(3, "Sector - Seleccionar", "Seleccionar Sector", "s2 ");
                buton4.SetBitmaps(cConexion.Ruta + @"\Img\seleccionar_sector.bmp", cConexion.Ruta + @"\Img\seleccionar_sector.bmp");
                AcadToolbarItem buton5 = acad_toolbar.AddToolbarButton(4, "Sector - Buscar", "Buscar Sector", "s3 ");
                buton5.SetBitmaps(cConexion.Ruta + @"\Img\buscar_sector.bmp", cConexion.Ruta + @"\Img\buscar_sector.bmp");
                AcadToolbarItem buton6 = acad_toolbar.AddToolbarButton(5, "Manzana - Cargar", "Cargar Manzanas", "m1 ");
                buton6.SetBitmaps(cConexion.Ruta + @"\Img\cargar_manzana.bmp", cConexion.Ruta + @"\Img\cargar_manzana.bmp");
                AcadToolbarItem buton7 = acad_toolbar.AddToolbarButton(6, "Manzana - Seleccionar", "Seleccionar Manzana", "m2 ");
                buton7.SetBitmaps(cConexion.Ruta + @"\Img\seleccionar_manzana.bmp", cConexion.Ruta + @"\Img\seleccionar_manzana.bmp");
                AcadToolbarItem buton8 = acad_toolbar.AddToolbarButton(7, "Manzana - Buscar", "Buscar Manzana", "m3 ");
                buton8.SetBitmaps(cConexion.Ruta + @"\Img\buscar_manzana.bmp", cConexion.Ruta + @"\Img\buscar_manzana.bmp");
                AcadToolbarItem buton9 = acad_toolbar.AddToolbarButton(8, "Ejes de Vias - Cargar", "Cargar Ejes de Vias", "v1 ");
                buton9.SetBitmaps(cConexion.Ruta + @"\Img\cargar_vias.bmp", cConexion.Ruta + @"\Img\cargar_vias.bmp");
                AcadToolbarItem buton10 = acad_toolbar.AddToolbarButton(9, "Ejes de Vias - Seleccionar", "Seleccionar Ejes de Vias", "v2 ");
                buton10.SetBitmaps(cConexion.Ruta + @"\Img\seleccionar_vias.bmp", cConexion.Ruta + @"\Img\seleccionar_vias.bmp");
                AcadToolbarItem buton11 = acad_toolbar.AddToolbarButton(10, "Ejes de Vias - Buscar", "Buscar Ejes de Vias", "v3 ");
                buton11.SetBitmaps(cConexion.Ruta + @"\Img\buscar_vias.bmp", cConexion.Ruta + @"\Img\buscar_vias.bmp");
                AcadToolbarItem buton12 = acad_toolbar.AddToolbarButton(11, "Equipamiento Urbano - Cargar", "Cargar Equipamiento Urbano", "e1 ");
                buton12.SetBitmaps(cConexion.Ruta + @"\Img\cargar_equipamiento_urbano.bmp", cConexion.Ruta + @"\Img\cargar_equipamiento_urbano.bmp");
                AcadToolbarItem buton13 = acad_toolbar.AddToolbarButton(12, "Equipamiento Urbano - Seleccionar", "Seleccionar Equipamiento Urbano", "e2 ");
                buton13.SetBitmaps(cConexion.Ruta + @"\Img\seleccionar_equipamiento_urbano.bmp", cConexion.Ruta + @"\Img\seleccionar_equipamiento_urbano.bmp");
                AcadToolbarItem buton14 = acad_toolbar.AddToolbarButton(13, "Equipamiento Urbano - Buscar", "Buscar Equipamiento Urbano", "e3 ");
                buton14.SetBitmaps(cConexion.Ruta + @"\Img\buscar_equipamiento_urbano.bmp", cConexion.Ruta + @"\Img\buscar_equipamiento_urbano.bmp");
                AcadToolbarItem buton15 = acad_toolbar.AddToolbarButton(14, "Puerta - Cargar", "Cargar Puerta", "p1 ");
                buton15.SetBitmaps(cConexion.Ruta + @"\Img\cargar_puerta.bmp", cConexion.Ruta + @"\Img\cargar_puerta.bmp");
                AcadToolbarItem buton16 = acad_toolbar.AddToolbarButton(15, "Puerta - Seleccionar", "Seleccionar Puerta", "p2 ");
                buton16.SetBitmaps(cConexion.Ruta + @"\Img\seleccionar_puerta.bmp", cConexion.Ruta + @"\Img\seleccionar_puerta.bmp");                
                AcadToolbarItem buton18 = acad_toolbar.AddToolbarButton(17, "Componente Urbano - Cargar", "Cargar Componente Urbano", "c1 ");
                buton18.SetBitmaps(cConexion.Ruta + @"\Img\cargar_componente_urbano.bmp", cConexion.Ruta + @"\Img\cargar_componente_urbano.bmp");
                AcadToolbarItem buton19 = acad_toolbar.AddToolbarButton(18, "Componente Urbano - Seleccionar", "Seleccionar Componente Urbano", "c2 ");
                buton19.SetBitmaps(cConexion.Ruta + @"\Img\seleccionar_componente_urbano.bmp", cConexion.Ruta + @"\Img\seleccionar_componente_urbano.bmp");
                AcadToolbarItem buton20 = acad_toolbar.AddToolbarButton(19, "Mobiliario Urbano - Cargar", "Cargar Mobiliario Urbano", "n1 ");
                buton20.SetBitmaps(cConexion.Ruta + @"\Img\cargar_mobiliario_urbano.bmp", cConexion.Ruta + @"\Img\cargar_mobiliario_urbano.bmp");
                AcadToolbarItem buton21 = acad_toolbar.AddToolbarButton(20, "Mobiliario Urbano - Seleccionar", "Seleccionar Mobiliario Urbano", "n2 ");
                buton21.SetBitmaps(cConexion.Ruta + @"\Img\seleccionar_mobiliario_urbano.bmp", cConexion.Ruta + @"\Img\seleccionar_mobiliario_urbano.bmp");
                AcadToolbarItem buton22 = acad_toolbar.AddToolbarButton(21, "Usos Resaltantes - Cargar", "Cargar Usos Resaltantes", "u1 ");
                buton22.SetBitmaps(cConexion.Ruta + @"\Img\cargar_usos.bmp", cConexion.Ruta + @"\Img\cargar_usos.bmp");
                AcadToolbarItem buton23 = acad_toolbar.AddToolbarButton(22, "Usos Resaltantes - Seleccionar", "Seleccionar Usos Resaltantes", "u2 ");
                buton23.SetBitmaps(cConexion.Ruta + @"\Img\seleccionar_usos.bmp", cConexion.Ruta + @"\Img\seleccionar_usos.bmp");
                AcadToolbarItem buton24 = acad_toolbar.AddToolbarButton(23, "Usos Resaltantes - Buscar", "Buscar Usos Resaltantes", "u3 ");
                buton24.SetBitmaps(cConexion.Ruta + @"\Img\buscar_usos.bmp", cConexion.Ruta + @"\Img\buscar_usos.bmp");
                acad_toolbar.AddSeparator(2);
                acad_toolbar.AddSeparator(6);
                acad_toolbar.AddSeparator(10);
                acad_toolbar.AddSeparator(14);
                acad_toolbar.AddSeparator(18);
                acad_toolbar.AddSeparator(21);
                acad_toolbar.AddSeparator(24);
                acad_toolbar.AddSeparator(27);
                AcadPopupMenu acad_menu = acad_app.MenuGroups.Item(0).Menus.Add("Sistema de Numeración y Nomenclatura");
                AcadPopupMenu menu_configuracion = acad_menu.AddSubMenu(0, "Configuración");
                menu_configuracion.AddMenuItem(1, "Ubicación Geográfica", "ubicacion ");
                menu_configuracion.AddMenuItem(2, "Servidor de Base de Datos", "datos ");
                menu_configuracion.AddMenuItem(3, "Servidor Web", "web ");
                AcadPopupMenu menu_sector = acad_menu.AddSubMenu(1, "Sector");
                menu_sector.AddMenuItem(1, "Cargar", "s1 ");                
                menu_sector.AddMenuItem(2, "Seleccionar", "s2 ");
                menu_sector.AddMenuItem(3, "Buscar", "s3 ");
                AcadPopupMenu menu_manzana = acad_menu.AddSubMenu(2, "Manzana");
                menu_manzana.AddMenuItem(1, "Cargar", "m1 ");
                menu_manzana.AddMenuItem(2, "Seleccionar", "m2 ");
                menu_manzana.AddMenuItem(3, "Buscar", "n3 ");
                AcadPopupMenu menu_vias = acad_menu.AddSubMenu(3, "Eje de Vias");
                menu_vias.AddMenuItem(1, "Cargar", "v1 ");
                menu_vias.AddMenuItem(2, "Seleccionar", "v2 ");
                menu_vias.AddMenuItem(3, "Buscar", "v3 ");
                AcadPopupMenu menu_equipamiento_urbano = acad_menu.AddSubMenu(4, "Equipamiento Urbano");
                menu_equipamiento_urbano.AddMenuItem(1, "Cargar", "e1 ");
                menu_equipamiento_urbano.AddMenuItem(2, "Seleccionar", "e2 ");
                menu_equipamiento_urbano.AddMenuItem(3, "Buscar", "e3 ");
                AcadPopupMenu menu_puerta = acad_menu.AddSubMenu(5, "Puerta");
                menu_puerta.AddMenuItem(1, "Cargar", "p1 ");
                menu_puerta.AddMenuItem(2, "Seleccionar", "p2 ");                
                AcadPopupMenu menu_componente_urbano = acad_menu.AddSubMenu(6, "Componente Urbano");
                menu_componente_urbano.AddMenuItem(1, "Cargar", "c1 ");
                menu_componente_urbano.AddMenuItem(2, "Seleccionar", "c2 ");                
                AcadPopupMenu menu_mobiliario_urbano = acad_menu.AddSubMenu(7, "Mobiliario Urbano");
                menu_mobiliario_urbano.AddMenuItem(1, "Cargar", "n1 ");
                menu_mobiliario_urbano.AddMenuItem(2, "Seleccionar", "n2 ");
                AcadPopupMenu menu_usos_resaltantes = acad_menu.AddSubMenu(8, "Usos Resaltantes");
                menu_usos_resaltantes.AddMenuItem(1, "Cargar", "u1 ");
                menu_usos_resaltantes.AddMenuItem(2, "Seleccionar", "u2 ");
                menu_usos_resaltantes.AddMenuItem(3, "Buscar", "u3 ");
                AcadPopupMenu menu_reportes = acad_menu.AddSubMenu(9, "Reportes");
                menu_reportes.AddMenuItem(1, "Certificado de Numeración", "r1 ");
                menu_reportes.AddMenuItem(2, "Listado de Vias con Ficha y sin Ficha", "r2 ");
                menu_reportes.AddMenuItem(3, "Listado por tipo de Via", "r3 ");
                acad_menu.AddSeparator(1);
                acad_menu.AddSeparator(6);
                acad_menu.AddSeparator(8);
                acad_menu.AddSeparator(11);
                acad_menu.AddSeparator(13);
                acad_menu.InsertInMenuBar(acad_app.MenuBar.Count + 1);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message,"Error:  Barra de Menu",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Termina la construcción del Menu de controles.
        /// </summary>
        public void Terminate()
        {

        }
    }

    /// <summary>
    /// Configuración de los comandos de Acceso.
    /// </summary>
    public class Comandos
    {
        #region [ VARIABLES GLOBALES ]
        static bool habilitado = false;
        static string usuario;
        string Ubigeo = null;
        cAuto_Cad_Map Auto_Cad_Map = new cAuto_Cad_Map();
        #endregion        

        #region [ CONFIGURACION ]
        #region Comandos Configuración
        /// <summary>
        /// Configuración de Ubicación Geográfica.
        /// </summary>
        [CommandMethod("ubicacion")]
        public void cargar_ubicacion_geografica()
        {
            try
            {
                if (!habilitado)
                {
                    Autenticarse autenticarse = new Autenticarse();
                    System.Windows.Forms.DialogResult rpta = Auto_Cad_Map.mostrar_dialogo(autenticarse);
                    usuario = autenticarse.user;
                    Ubigeo = cUbicacion_Geografica.Ubigeo;
                    if (rpta == System.Windows.Forms.DialogResult.OK)
                    {
                        habilitado = true;
                        control_ubicacion_geografica();
                    }
                }
                else control_ubicacion_geografica();
            }
            catch (MgException ex)
            {
                Auto_Cad_Map.imprimir("\nError: " + ex.Message);
            }
        }

        /// <summary>
        /// Configuración del Servidor Base de Datos.
        /// </summary>
        [CommandMethod("datos")]
        public void cargar_base_datos()
        {
            try
            {
                control_servidor_base_datos();
            }
            catch (MgException ex)
            {
                Auto_Cad_Map.imprimir("\nError: " + ex.Message);
            }
        }

        /// <summary>
        /// Configuración de Servidor Web
        /// </summary>
        [CommandMethod("web")]
        public void cargar_web()
        {
            try
            {
                control_servidor_web();
            }
            catch (MgException ex)
            {
                Auto_Cad_Map.imprimir("\nError: " + ex.Message);
            }
        }        
        #endregion

        #region Métodos de configuración
        void control_ubicacion_geografica()
        {
            Configuracion_Ubicacion_Geografica configuracion_ubicacion_geografica = new Configuracion_Ubicacion_Geografica();            
            System.Windows.Forms.DialogResult rpta = Auto_Cad_Map.mostrar_dialogo(configuracion_ubicacion_geografica);
            Ubigeo = cUbicacion_Geografica.Ubigeo;
            Auto_Cad_Map.imprimir("Ubigeo: " + Ubigeo);
        }
        void control_servidor_base_datos()
        {
            Configuracion_Servidor_Base_Datos configuracion_servidor_base_datos = new Configuracion_Servidor_Base_Datos();
            System.Windows.Forms.DialogResult rpta = Auto_Cad_Map.mostrar_dialogo(configuracion_servidor_base_datos);
            Ubigeo = cUbicacion_Geografica.Ubigeo;
            Auto_Cad_Map.imprimir("Ubigeo: " + Ubigeo);
        }
        void control_servidor_web()
        {
            Configuracion_Servidor_Web configuracion_servidor_web = new Configuracion_Servidor_Web();
            System.Windows.Forms.DialogResult rpta = Auto_Cad_Map.mostrar_dialogo(configuracion_servidor_web);
            Ubigeo = cUbicacion_Geografica.Ubigeo;
            Auto_Cad_Map.imprimir("Ubigeo: " + Ubigeo);
        }
        #endregion
        #endregion

        #region [ SECTOR ]
        #region Comandos Sector
        /// <summary>
        /// Cargar Sector.
        /// </summary>
        [CommandMethod("s1")]
        public void cargar_sector()
        {
            if (!habilitado)
            {
                Autenticarse autenticarse = new Autenticarse();
                System.Windows.Forms.DialogResult rpta = Auto_Cad_Map.mostrar_dialogo(autenticarse);
                usuario = autenticarse.user;
                Ubigeo = cUbicacion_Geografica.Ubigeo;
                if (rpta == System.Windows.Forms.DialogResult.OK) control_sector();
            }
            else control_sector();
        }

        /// <summary>
        /// Seleccionar Sector.
        /// </summary>
        [CommandMethod("s2")]
        public void seleccionar_sector()
        {
            try
            {
                if (Auto_Cad_Map.existe_capa("SECTOR"))
                {                    
                    bool estado;
                    PromptEntityOptions poligono = new PromptEntityOptions("\nSeleccionar un Sector: ");
                    PromptEntityResult rpta_poligono = Auto_Cad_Map.Editor.GetEntity(poligono);
                    if (rpta_poligono.Status != PromptStatus.OK) return;
                    ObjectId objeto_id = rpta_poligono.ObjectId;
                    double[,] coordenadas = Auto_Cad_Map.entidad_geometrica_poligono(objeto_id , out estado);
                    if (estado == false) return;
                    if (coordenadas != null)
                    {
                        MgGeometry geom = Auto_Cad_Map.crear_geometria_poligono(coordenadas);
                        if (!geom.IsValid())
                        {
                            Auto_Cad_Map.imprimir("\nInvalidado dato geográfico.");
                            return;
                        }
                        if (geom != null) agregar_sector(geom);
                    }
                }
                else Auto_Cad_Map.imprimir("\nError: No existe la Capa Sector.");
            }
            catch (MgException ex)
            {
                Auto_Cad_Map.imprimir("\nError, Seleccionar Sector: " + ex.Message);
            }
        }

        /// <summary>
        /// Buscar Sector.
        /// </summary>
        [CommandMethod("s3")]
        public void buscar_sector()
        {
            try
            {
                    MgLayerBase capa_sector = Auto_Cad_Map.obtener_capa("SECTOR");
                    if (capa_sector != null)
                    {
                        MgFeatureReader fr = capa_sector.SelectFeatures(new MgFeatureQueryOptions());
                        System.Data.DataTable tabla = new System.Data.DataTable();
                        tabla.Columns.Add("CODIGO SECTOR");
                        tabla.Columns.Add("SECTOR");
                        tabla.Columns.Add("AREA");
                        tabla.Columns.Add("PERIMETRO");
                        tabla.Columns.Add("USUARIO CREA");
                        tabla.Columns.Add("FECHA CREACION");
                        tabla.Columns.Add("USUARIO MODIFICA");
                        tabla.Columns.Add("FECHA MODIFICACION");
                        DataRow fila;
                        while (fr.ReadNext())
                        {
                            fila = tabla.NewRow();
                            fila["CODIGO SECTOR"] = fr.GetString("CODIGO_SECTOR");
                            fila["SECTOR"] = fr.GetString("SECTOR");
                            fila["AREA"] = fr.GetDouble("AREA").ToString();
                            fila["PERIMETRO"] = fr.GetDouble("PERIMETRO").ToString();
                            fila["USUARIO CREA"] = fr.GetString("USUARIO_CREA");
                            fila["FECHA CREACION"] = fr.GetDateTime("FECHA_CREA").ToString().Substring(11, 19);
                            fila["USUARIO MODIFICA"] = fr.GetString("USUARIO_MODIFICA");
                            fila["FECHA MODIFICACION"] = fr.GetDateTime("FECHA_MODIFICA").ToString().Substring(11, 19);
                            tabla.Rows.Add(fila);
                        }
                        fr.Close();
                        Detalles detalles_sector = new Detalles();
                        detalles_sector.Text = "Propiedades - Capa Sectores";
                        System.Windows.Forms.DialogResult rpta;
                        detalles_sector.detalles_dgv.DataSource = tabla;
                        detalles_sector.GEODB_bs.DataSource = tabla;
                        if (tabla.Rows.Count > 0)
                            rpta = Auto_Cad_Map.mostrar_dialogo(detalles_sector);
                        else return;
                        if (rpta == System.Windows.Forms.DialogResult.OK)
                        {
                            Auto_Cad_Map.imprimir(string.Format("\nSector: {0} = {1}", detalles_sector.Columna, detalles_sector.Valor));
                            if (detalles_sector.Columna != "" && detalles_sector.Valor != "")
                            {
                                Auto_Cad_Map.actualizar_capa("SECTOR", string.Format("{0} = '{1}'", detalles_sector.Columna, detalles_sector.Valor),"UBICACION");
                                Auto_Cad_Map.ir("SECTOR", detalles_sector.Columna, detalles_sector.Valor);
                            }
                        }
                        else
                        {
                            detalles_sector.Close();
                            return;
                        }
                    }
                    else Auto_Cad_Map.imprimir("\nError: No existe la Capa Sector.");
            }
            catch (MgException ex)
            {
                Auto_Cad_Map.imprimir("\nError, Buscar Sector: " + ex.Message);
            }
        }
        #endregion

        #region Metodos Sector
        void control_sector()
        {
            try
            {                
                habilitado = true;
                Cargar_Sectores capas_sector = new Cargar_Sectores();
                capas_sector.mensaje_lbl.Text = "Elegir, Sectores:";
                capas_sector.usuario_lbl.Text = usuario.ToUpper();
                capas_sector.Auto_Cad_Map = Auto_Cad_Map;
                DialogResult rpta = Auto_Cad_Map.mostrar_dialogo(capas_sector);
                if (rpta == System.Windows.Forms.DialogResult.OK) Auto_Cad_Map.imprimir("\nCodigo: " + Ubigeo); 
            }
            catch (System.Exception ex)
            {
                Auto_Cad_Map.imprimir("\nError, Cargar Capa Sectores: " + ex.Message);
            }
        }
        void agregar_sector(MgGeometry geom)
        {
            try
            {
                PromptStringOptions valor = new PromptStringOptions("\nIngresar Código del Sector: ");
                PromptResult sector = Auto_Cad_Map.Editor.GetString(valor);

                while (sector.StringResult.Length != 2)
                {
                    valor = new PromptStringOptions("\nError el campo acepta 2 dígitos, ingresar código del Sector: ");
                    sector = Auto_Cad_Map.Editor.GetString(valor);
                }
                if (Ubigeo != "" || Ubigeo != null)
                {                   
                    Auto_Cad_Map.agregar_elemento_capa("SECTOR",
                        new MgStringProperty("UBIGEO", Ubigeo),
                        new MgStringProperty("CODIGO_SECTOR", Ubigeo + sector.StringResult),
                        new MgStringProperty("SECTOR", sector.StringResult),
                        new MgDoubleProperty("AREA", System.Convert.ToDouble(geom.Area.ToString(".000000"))),
                        new MgDoubleProperty("PERIMETRO", System.Convert.ToDouble(geom.Length.ToString(".000000"))),
                        new MgGeometryProperty("GEOM", new MgAgfReaderWriter().Write(geom)),
                        new MgStringProperty("E", "A"),
                        new MgStringProperty("USUARIO_CREA", usuario.ToUpper()),
                        new MgStringProperty("USUARIO_MODIFICA", usuario.ToUpper()));
                }
                else Auto_Cad_Map.imprimir("\nError, no existe la capa Distrito.");

            }
            catch (MgException ex)
            {
                Auto_Cad_Map.imprimir("\nError: Agregar Sector: " + ex.Message);
            }
        }
        #endregion
        #endregion

        #region [ MANZANA ]
        #region Comandos Manzana
        /// <summary>
        /// Cargar Manzanas.
        /// </summary>
        [CommandMethod("m1")]
        public void cargar_manzana()
        {
            if (!habilitado)
            {
                Autenticarse autenticarse = new Autenticarse();
                System.Windows.Forms.DialogResult rpta = Auto_Cad_Map.mostrar_dialogo(autenticarse);
                usuario = autenticarse.user;
                Ubigeo = cUbicacion_Geografica.Ubigeo;
                if (rpta == System.Windows.Forms.DialogResult.OK) control_manzana();
            }
            else control_manzana();
        }

        /// <summary>
        /// Seleccionar Manzanas.
        /// </summary>
        [CommandMethod("m2")]
        public void seleccionar_manzana()
        {
            try
            {
                if (Auto_Cad_Map.existe_capa("MANZANA"))
                {                    
                    bool estado;
                    PromptEntityOptions poligono = new PromptEntityOptions("\nSeleccionar la manzana: ");
                    PromptEntityResult rptaPoligono = Auto_Cad_Map.Editor.GetEntity(poligono);
                    if (rptaPoligono.Status != PromptStatus.OK) return;
                    ObjectId objeto_id = rptaPoligono.ObjectId;
                    double[,] coordenadas =Auto_Cad_Map.entidad_geometrica_poligono(objeto_id, out estado);
                    if (estado == false) return;
                    if (coordenadas != null)
                    {                        
                        MgGeometry geom = Auto_Cad_Map.crear_geometria_poligono(coordenadas);
                        if (!geom.IsValid())
                        {
                            Auto_Cad_Map.imprimir("\nInvalidado dato geográfico.");
                            return;
                        }
                        if (geom != null) agregar_manzana(geom);
                    }
                }
                else Auto_Cad_Map.imprimir("\nError: No existe la capa Manzana.");
            }
            catch (MgException ex)
            {
                Auto_Cad_Map.imprimir("\nError, Seleccionar Manzana: " + ex.Message);
            }
        }

        /// <summary>
        /// Buscar Manzanas.
        /// </summary>
        [CommandMethod("m3")]
        public void buscar_manzana()
        {
            try
            {
                MgLayerBase capa_manzanas = Auto_Cad_Map.obtener_capa("MANZANA");
                if (capa_manzanas != null)
                {
                    MgFeatureReader fr = capa_manzanas.SelectFeatures(new MgFeatureQueryOptions());
                    System.Data.DataTable tabla = new System.Data.DataTable();
                    tabla.Columns.Add("CODIGO MANZANA");
                    tabla.Columns.Add("SECTOR");
                    tabla.Columns.Add("MANZANA");
                    tabla.Columns.Add("AREA");
                    tabla.Columns.Add("PERIMETRO");
                    tabla.Columns.Add("USUARIO CREA");
                    tabla.Columns.Add("FECHA CREACION");
                    tabla.Columns.Add("USUARIO MODIFICA");
                    tabla.Columns.Add("FECHA MODIFICACION");
                    DataRow fila;
                    while (fr.ReadNext())
                    {
                        fila = tabla.NewRow();
                        fila["CODIGO MANZANA"] = fr.GetString("CODIGO_MANZANA");
                        fila["SECTOR"] = fr.GetString("CODIGO_SECTOR").Substring(6);
                        fila["MANZANA"] = fr.GetString("MANZANA");
                        fila["AREA"] = fr.GetDouble("AREA").ToString();
                        fila["PERIMETRO"] = fr.GetDouble("PERIMETRO").ToString();
                        fila["USUARIO CREA"] = fr.GetString("USUARIO_CREA");
                        fila["FECHA CREACION"] = fr.GetDateTime("FECHA_CREA").ToString().Substring(11, 19);
                        fila["USUARIO MODIFICA"] = fr.GetString("USUARIO_MODIFICA");
                        fila["FECHA MODIFICACION"] = fr.GetDateTime("FECHA_MODIFICA").ToString().Substring(11, 19);
                        tabla.Rows.Add(fila);
                    }
                    fr.Close();
                    Detalles_Manzana detalles_manzana = new Detalles_Manzana();
                    detalles_manzana.Text = "Propiedades - Capa Manzanas";
                    System.Windows.Forms.DialogResult rpta;
                    detalles_manzana.detalles_dgv.DataSource = tabla;
                    detalles_manzana.GEODB_bs.DataSource = tabla;
                    if (tabla.Rows.Count > 0)
                        rpta = Auto_Cad_Map.mostrar_dialogo(detalles_manzana);
                    else return;
                    if (rpta == System.Windows.Forms.DialogResult.OK)
                    {
                        Auto_Cad_Map.imprimir(string.Format("\nManzana: {0} = {1}", detalles_manzana.Columna, detalles_manzana.Valor));
                        if (detalles_manzana.Columna != "" && detalles_manzana.Valor != "")
                        {
                            MgLayerBase capa_sector = Auto_Cad_Map.obtener_capa("SECTOR");
                            capa_sector.SetVisible(true);
                            if (detalles_manzana.Columna != "" && detalles_manzana.Valor != "")
                            {
                                Auto_Cad_Map.actualizar_capa("MANZANA", string.Format("{0} = '{1}'", detalles_manzana.Columna, detalles_manzana.Valor), "UBICACION");
                                Auto_Cad_Map.ir("MANZANA", detalles_manzana.Columna, detalles_manzana.Valor);
                            }
                        }
                    }
                    else
                    {
                        detalles_manzana.Close();
                        return;
                    }
                }
                else Auto_Cad_Map.imprimir("\nError: No existe la capa Manzana.");
            }
            catch (MgException ex)
            {
                Auto_Cad_Map.imprimir("\nError, Buscar Manzana: " + ex.Message);
            }
        }
        #endregion

        #region Metodos Manzana
        void control_manzana()
        {
            try
            {                
                habilitado = true;
                Cargar_Manzanas capas_manzanas = new Cargar_Manzanas();
                capas_manzanas.mensaje_lbl.Text = "Elegir, Manzanas:";
                capas_manzanas.usuario_lbl.Text = usuario.ToUpper();
                capas_manzanas.Auto_Cad_Map = Auto_Cad_Map;
                System.Windows.Forms.DialogResult rpta = Auto_Cad_Map.mostrar_dialogo(capas_manzanas);
                if (rpta == System.Windows.Forms.DialogResult.OK) Auto_Cad_Map.imprimir("\nCodigo: " + Ubigeo);
            }
            catch (System.Exception ex)
            {
                Auto_Cad_Map.imprimir("\nError: No existe la capa Manzana. " + ex.Message);
            }
        }
        void agregar_manzana(MgGeometry geom)
        {
            try
            {                
                List<string> lista_codigo_sector  = Auto_Cad_Map.buscar("SECTOR", geom, "CODIGO_SECTOR");
                if (lista_codigo_sector.Count>0)
                {
                    string codigo_sector = lista_codigo_sector[0];
                    Auto_Cad_Map.imprimir(string.Format("Sector Intersectado: {0}\n",codigo_sector.Substring(6,2)));                
                    PromptStringOptions v2 = new PromptStringOptions("\nIngresar Código de la Manzana: ");
                    PromptResult manzana = Auto_Cad_Map.Editor.GetString(v2);

                    while (manzana.StringResult.Length != 3)
                    {
                        v2 = new PromptStringOptions("\nERROR el campo acepta 3 dígitos, Ingresar Código de la Manzana: ");
                        manzana = Auto_Cad_Map.Editor.GetString(v2);
                    }
                    if (Ubigeo != "" || Ubigeo != null)
                    {
                        Auto_Cad_Map.agregar_elemento_capa("MANZANA",
                        new MgStringProperty("CODIGO_SECTOR", codigo_sector),
                        new MgStringProperty("CODIGO_MANZANA", codigo_sector + manzana.StringResult),
                        new MgStringProperty("MANZANA", manzana.StringResult),
                        new MgDoubleProperty("AREA", System.Convert.ToDouble(geom.Area.ToString(".000000"))),
                        new MgDoubleProperty("PERIMETRO", System.Convert.ToDouble(geom.Length.ToString(".000000"))),
                        new MgGeometryProperty("GEOM", new MgAgfReaderWriter().Write(geom)),
                        new MgStringProperty("E", "A"),
                        new MgStringProperty("USUARIO_CREA", usuario.ToUpper()),
                        new MgStringProperty("USUARIO_MODIFICA", usuario.ToUpper()));
                    }
                }
            }
            catch (MgException ex)
            {
                Auto_Cad_Map.imprimir("\nError, Agregar Manzana: " + ex.Message);
            }
        }
        #endregion  
        #endregion

        #region [ EJE DE VIAS ]
        #region Comandos Vias
        /// <summary>
        /// Cargar Eje de Vias.
        /// </summary>
        [CommandMethod("v1")]        
        public void cargar_eje_via()
        {
            if (!habilitado)
            {
                Autenticarse autenticarse = new Autenticarse();
                System.Windows.Forms.DialogResult rpta = Auto_Cad_Map.mostrar_dialogo(autenticarse);
                usuario = autenticarse.user;
                Ubigeo = cUbicacion_Geografica.Ubigeo;
                if (rpta == System.Windows.Forms.DialogResult.OK)control_vias();
            }
            else control_vias();
        }

        /// <summary>
        /// Seleccionar Eje de Vias.
        /// </summary>
        [CommandMethod("v2")]
        public void seleccionar_eje_via()
        {
            try
            {
                if (!habilitado)
                {
                    Autenticarse autenticarse = new Autenticarse();
                    System.Windows.Forms.DialogResult rpta = autenticarse.ShowDialog();
                    usuario = autenticarse.user;
                    Ubigeo = cUbicacion_Geografica.Ubigeo;
                    if (rpta == System.Windows.Forms.DialogResult.OK) control_vias();                    
                }
                else
                {
                    if (Auto_Cad_Map.existe_capa("VIAS"))
                    {
                        double[,] coordenadas = null;
                        PromptEntityOptions linea = new PromptEntityOptions("\nSeleccionar una Via: ");
                        PromptEntityResult rpta_linea = Auto_Cad_Map.Editor.GetEntity(linea);
                        if (rpta_linea.Status != PromptStatus.OK) return;
                        ObjectId objeto_id = rpta_linea.ObjectId;
                        coordenadas = Auto_Cad_Map.entidad_geometrica_polilinea(objeto_id);
                        if (coordenadas == null) return;
                        MgGeometry geom = Auto_Cad_Map.crear_geometria_linea(coordenadas);
                        if (!geom.IsValid())
                        {
                            Auto_Cad_Map.imprimir("\nInvalidado dato geográfico.");
                            return;
                        }
                        if (geom != null) agregar_vias(geom);
                    }
                    else Auto_Cad_Map.imprimir("\nError: No existe la capa Vias.");
                }
            }
            catch (MgException ex)
            {
                Auto_Cad_Map.imprimir("\nError, Seleccionar Eje de Via: " + ex.Message);
            }
        }

        /// <summary>
        /// Buscar Eje de Vias.
        /// </summary>
        [CommandMethod("v3")]
        public void buscar_eje_via()
        {
            try
            {
                if (!habilitado)
                {
                    Autenticarse autenticarse = new Autenticarse();
                    System.Windows.Forms.DialogResult rpta = autenticarse.ShowDialog();
                    usuario = autenticarse.user;
                    Ubigeo = cUbicacion_Geografica.Ubigeo;
                    if (rpta == System.Windows.Forms.DialogResult.OK) control_vias();
                    else if (rpta == System.Windows.Forms.DialogResult.Cancel) System.Windows.Forms.Application.Exit();
                }
                else
                {
                    Detalles detalles_vias = new Detalles();
                    detalles_vias.Text = "Propiedades - Capa Eje de Via";                    
                    MgLayerBase capa_vias = (MgLayerBase)Auto_Cad_Map.obtener_capa("VIAS");
                    if (capa_vias != null)
                    {
                        MgFeatureReader fr = capa_vias.SelectFeatures(new MgFeatureQueryOptions());
                        System.Data.DataTable tabla = new System.Data.DataTable();
                        tabla.Columns.Add("ID");
                        tabla.Columns.Add("SECTOR");
                        tabla.Columns.Add("CODIGO VIA");
                        tabla.Columns.Add("CUADRA");
                        tabla.Columns.Add("DIRECCION");                                                
                        tabla.Columns.Add("USUARIO CREA");
                        tabla.Columns.Add("FECHA CREACION");
                        tabla.Columns.Add("USUARIO MODIFICA");
                        tabla.Columns.Add("FECHA MODIFICACION");
                        DataRow fila;                        
                        while (fr.ReadNext())
                        {
                            fila = tabla.NewRow();
                            fila["ID"] = fr.GetInt32("ID");
                            fila["SECTOR"] = fr.GetString("SECTOR");
                            fila["CODIGO VIA"] = fr.GetString("CODIGO_VIA");
                            fila["CUADRA"] = fr.GetString("CUADRA");                                                 
                            fila["DIRECCION"] = fr.GetString("DIRECCION");                           
                            fila["USUARIO CREA"] = fr.GetString("USUARIO_CREA");
                            fila["FECHA CREACION"] = fr.GetDateTime("FECHA_CREA").ToString().Substring(11, 19);
                            fila["USUARIO MODIFICA"] = fr.GetString("USUARIO_MODIFICA");
                            fila["FECHA MODIFICACION"] = fr.GetDateTime("FECHA_MODIFICA").ToString().Substring(11, 19);
                            tabla.Rows.Add(fila);
                        }
                        fr.Close();

                        detalles_vias.detalles_dgv.DataSource = tabla;
                        detalles_vias.GEODB_bs.DataSource = tabla;
                        detalles_vias.detalles_dgv.ScrollBars = System.Windows.Forms.ScrollBars.Both;
                        //foreach (System.Windows.Forms.DataGridViewColumn item in Detalles_Vias.detalles_dgv.Columns)
                        //{
                        //    if (item is System.Windows.Forms.DataGridViewImageColumn)
                        //    {
                        //        System.Windows.Forms.DataGridViewImageColumn a = (System.Windows.Forms.DataGridViewImageColumn)item;
                        //        a.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
                        //    }
                        //}                        
                        System.Windows.Forms.DialogResult rpta = Auto_Cad_Map.mostrar_dialogo(detalles_vias);
                        if (rpta == System.Windows.Forms.DialogResult.OK)
                        {
                            if (detalles_vias.Columna != "" && detalles_vias.Valor != "")
                            {
                                Auto_Cad_Map.actualizar_capa("VIAS", string.Format("{0} = {1}", detalles_vias.Columna, detalles_vias.Valor), "UBICACION");
                                Auto_Cad_Map.ir("VIAS", detalles_vias.Columna, detalles_vias.Valor);
                            }
                        }
                        else
                        {
                            detalles_vias.Close();
                            return;
                        }
                    }
                    else Auto_Cad_Map.imprimir("\nError: No existe la Capa Vias.");
                }
            }
            catch (MgException ex)
            {
                Auto_Cad_Map.imprimir("\nError, buscar Eje de Via: " + ex.Message);
            }
        }

        /// <summary>
        /// Lista todos las vias con Ficha o sin Ficha
        /// </summary>
        [CommandMethod("r2")]
        public void reporte_con_ficha_vias()
        {
            try
            {
                if (!habilitado)
                {
                    Autenticarse autenticarse = new Autenticarse();
                    System.Windows.Forms.DialogResult rpta = autenticarse.ShowDialog();
                    usuario = autenticarse.user;
                    Ubigeo = cUbicacion_Geografica.Ubigeo;
                    if (rpta == System.Windows.Forms.DialogResult.OK)control_vias();                        
                    else if (rpta == System.Windows.Forms.DialogResult.Cancel) System.Windows.Forms.Application.Exit();
                }
                else
                {
                    if (Auto_Cad_Map.existe_capa("VIAS"))Auto_Cad_Map.actualizar_capa("VIAS", "HASH <> ''", "FICHA");
                    else Auto_Cad_Map.imprimir("\nError: No existe la Capa Vias ");
                }
            }
            catch (MgException ex)
            {
                Auto_Cad_Map.imprimir("\nError, Reporte de Eje de Via: " + ex.Message);
            }
        }

        /// <summary>
        /// Lista todos las vias con Ficha o sin Ficha
        /// </summary>
        [CommandMethod("r3")]
        public void reporte_por_tipo_vias()
        {
            try
            {
                if (!habilitado)
                {
                    Autenticarse autenticarse = new Autenticarse();
                    System.Windows.Forms.DialogResult rpta = autenticarse.ShowDialog();
                    usuario = autenticarse.user;
                    Ubigeo = cUbicacion_Geografica.Ubigeo;
                    if (rpta == System.Windows.Forms.DialogResult.OK) control_vias();
                    else if (rpta == System.Windows.Forms.DialogResult.Cancel) System.Windows.Forms.Application.Exit();
                }
                else
                {
                    if (Auto_Cad_Map.existe_capa("VIAS")) Auto_Cad_Map.actualizar_capa("VIAS","TIPO");
                    else Auto_Cad_Map.imprimir("\nError: No existe la Capa Vias ");
                }
            }
            catch (MgException ex)
            {
                Auto_Cad_Map.imprimir("\nError, Reporte de Tipo de Via: " + ex.Message);
            }
        }
        #endregion

        #region Metodos Vias
        void control_vias()
        {
            try
            {
                habilitado = true;
                Cargar_Vias capas_vias = new Cargar_Vias();
                capas_vias.mensaje_lbl.Text = "Elegir, Eje de Via:";
                capas_vias.usuario_lbl.Text = usuario.ToUpper();
                capas_vias.Auto_Cad_Map = Auto_Cad_Map;
                System.Windows.Forms.DialogResult rpta = Auto_Cad_Map.mostrar_dialogo(capas_vias);
                if (rpta == System.Windows.Forms.DialogResult.OK) Auto_Cad_Map.imprimir("\nCodigo: " + Ubigeo);
            }
            catch (System.Exception ex)
            {
                Auto_Cad_Map.imprimir("\nError, Control de Vias: " + ex.Message);
            }
        }
        void agregar_vias(MgGeometry geom)
        {
            try
            {
                Vias Vias= new Vias();
                Vias.Usuario = usuario;
                List<string> query = Auto_Cad_Map.buscar("SECTOR", geom, "SECTOR");
                if (query.Count > 0)
                {
                    Vias.sector_cbo.Items.AddRange(query.ToArray());
                    System.Windows.Forms.DialogResult rpta = Auto_Cad_Map.mostrar_dialogo(Vias);
                    if (rpta == System.Windows.Forms.DialogResult.OK)
                    {
                        if (Ubigeo != "" || Ubigeo != null)
                        {
                            string hash="";
                            do
                            {
                                hash = Guid.NewGuid().ToString().ToUpper();
                                Auto_Cad_Map.imprimir(string.Format("\nHASH = {0}", hash));
                            } while (Auto_Cad_Map.buscar("VIAS","HASH",hash,'L'));                         
                            
                            string sector = Vias.sector_cbo.SelectedItem.ToString();
                            string codigo_via = Vias.codigoVias_txt.Text;
                            string direccion = Vias.direccion_lbl.Text;
                            string cuadra = Vias.cuadra_txt.Text;
                            Auto_Cad_Map.agregar_elemento_capa("VIAS",
                                new MgStringProperty("UBIGEO", Ubigeo),
                                new MgStringProperty("SECTOR", sector),
                                new MgStringProperty("CODIGO_VIA", codigo_via),
                                new MgStringProperty("DIRECCION", direccion),
                                new MgStringProperty("CUADRA", cuadra),
                                new MgGeometryProperty("GEOM", new MgAgfReaderWriter().Write(geom)),
                                new MgStringProperty("HASH", hash),
                                new MgStringProperty("E", "A"),
                                new MgStringProperty("USUARIO_CREA", usuario.ToUpper()),
                                new MgStringProperty("USUARIO_MODIFICA", usuario.ToUpper()));

                            rpta = System.Windows.Forms.MessageBox.Show("Desea ingresar la Ficha Catastral de Vias Urbanas", "Pregunta", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);
                            if (rpta == System.Windows.Forms.DialogResult.Yes)
                            {
                                Ficha_Catastral_Vias_Urbanas Ficha_Catastral_Vias_Urbanas = new Ficha_Catastral_Vias_Urbanas();
                                List<string> listar_coordenadas = Auto_Cad_Map.buscar_coordenadas("VIAS",string.Format("HASH = '{0}'",hash));
                                if (listar_coordenadas.Count > 0)
                                {                                    
                                    Ficha_Catastral_Vias_Urbanas.departamento_lbl.Text = Ubigeo.Substring(0, 2);
                                    Ficha_Catastral_Vias_Urbanas.provincia_lbl.Text = Ubigeo.Substring(2, 2);
                                    Ficha_Catastral_Vias_Urbanas.distrito_lbl.Text = Ubigeo.Substring(4, 2);
                                    Ficha_Catastral_Vias_Urbanas.sector_lbl.Text = sector;
                                    Ficha_Catastral_Vias_Urbanas.codigoVias_lbl.Text = codigo_via;
                                    Ficha_Catastral_Vias_Urbanas.cuadra_lbl.Text = cuadra;
                                    Ficha_Catastral_Vias_Urbanas.puntoXInicial_lbl.Text = listar_coordenadas[0];
                                    Ficha_Catastral_Vias_Urbanas.puntoYInicial_lbl.Text = listar_coordenadas[1];
                                    Ficha_Catastral_Vias_Urbanas.puntoXFinal_lbl.Text = listar_coordenadas[2];
                                    Ficha_Catastral_Vias_Urbanas.puntoYFinal_lbl.Text = listar_coordenadas[3];
                                    Ficha_Catastral_Vias_Urbanas.Hash = hash;
                                    Ficha_Catastral_Vias_Urbanas.Usuario = usuario;
                                    Ficha_Catastral_Vias_Urbanas.Show();
                                }
                            }
                        }
                        else Auto_Cad_Map.imprimir("\nError: No existe la capa Distrito");
                    }
                }
            }
            catch (MgException ex)
            {
                Auto_Cad_Map.imprimir("\nError, Agregar Eje de Vias: " + ex.Message);
            }
        }
        #endregion 
        #endregion

        #region [ EQUIPAMIENTO URBANO ]
        #region Comandos Equipamiento Urbano
        /// <summary>
        /// Cargar Equipamiento Urbano.
        /// </summary>
        [CommandMethod("e1")]
        public void cargar_equipamiento_urbano()
        {
            if (!habilitado)
            {
                Autenticarse autenticarse = new Autenticarse();
                System.Windows.Forms.DialogResult rpta = Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(autenticarse);
                usuario = autenticarse.user;
                Ubigeo = cUbicacion_Geografica.Ubigeo;
                if (rpta == System.Windows.Forms.DialogResult.OK)
                {
                    control_equipamiento_urbano();
                }
            }
            else control_equipamiento_urbano();
        }

        /// <summary>
        /// Seleccionar Equipamiento Urbano.
        /// </summary>
        [CommandMethod("e2")]
        public void seleccionar_equipamiento_urbano()
        {            
            try
            {
                if (Auto_Cad_Map.existe_capa("EQUIPAMIENTO_URBANO"))
                {
                double[,] coordenadas;                
                PromptEntityOptions opciones = new PromptEntityOptions("\nSeleccionar una linea: ");
                PromptEntityResult rpta_equipamiento = Auto_Cad_Map.Editor.GetEntity(opciones);
                if (rpta_equipamiento.Status != PromptStatus.OK) return;
                ObjectId objeto_id = rpta_equipamiento.ObjectId;
                coordenadas =Auto_Cad_Map.entidad_geometrica_polilinea(objeto_id);                
                MgGeometry geom =Auto_Cad_Map.crear_geometria_linea(coordenadas);
                if (!geom.IsValid())
                {
                   Auto_Cad_Map.Editor.WriteMessage("\nInvalidado dato geográfico");
                    return;
                }
                if (geom != null)agregar_equipamiento_urbano(geom);
               }
               else Auto_Cad_Map.imprimir("\nError: No existe la capa Equipamiento Urbano");
            }
            catch (MgException ex)
            {
               Auto_Cad_Map.Editor.WriteMessage("\nError, Seleccionar Equipamiento Urbano: " + ex.Message);
            }
        }

        /// <summary>
        /// Buscar Equipamiento Urbano.
        /// </summary>
        [CommandMethod("e3")]        
        public void buscar_equipamiento_urbano()
        {
            try
            {
                if (!habilitado)
                {
                    Autenticarse autenticarse = new Autenticarse();
                    System.Windows.Forms.DialogResult rpta = autenticarse.ShowDialog();
                    usuario = autenticarse.user;
                    Ubigeo = cUbicacion_Geografica.Ubigeo;
                    if (rpta == System.Windows.Forms.DialogResult.OK) control_equipamiento_urbano();
                    else if (rpta == System.Windows.Forms.DialogResult.Cancel) System.Windows.Forms.Application.Exit();
                }
                else
                {
                    Detalles detalles_equipamiento_urbano = new Detalles();
                    detalles_equipamiento_urbano.Text = "Propiedades - Capa Equipamiento Urbano";
                    MgLayerBase capa_vias = (MgLayerBase)Auto_Cad_Map.obtener_capa("EQUIPAMIENTO_URBANO");
                    if (capa_vias != null)
                    {
                        MgFeatureReader fr = capa_vias.SelectFeatures(new MgFeatureQueryOptions());
                        System.Data.DataTable tabla = new System.Data.DataTable();
                        
                        tabla.Columns.Add("ID");
                        tabla.Columns.Add("EQUIPAMIENTO URBANO");
                        tabla.Columns.Add("TIPO EQUIPAMIENTO URBANO");
                        tabla.Columns.Add("CODIGO USO");
                        tabla.Columns.Add("DESCRIPCION");                        
                        tabla.Columns.Add("USUARIO CREA");
                        tabla.Columns.Add("FECHA CREACION");
                        tabla.Columns.Add("USUARIO MODIFICA");
                        tabla.Columns.Add("FECHA MODIFICACION");
                        DataRow fila,row1,row2;
                        cTipo_Equipamiento_Urbano Tipo_Equipamiento_Urbano = new cTipo_Equipamiento_Urbano();
                        cUsos Usos = new cUsos();
                        while (fr.ReadNext())
                        {
                            fila = tabla.NewRow();
                            fila["ID"] = fr.GetInt32("ID");
                            fila["EQUIPAMIENTO URBANO"] = fr.GetString("NOMBRE_EQUIPAMIENTO_URBANO");
                            row1 =Tipo_Equipamiento_Urbano.Buscar(fr.GetString("TIPO_EQUIPAMIENTO_URBANO"));
                            fila["TIPO EQUIPAMIENTO URBANO"] = (row1 != null) ?row1["LISTA"].ToString().Substring(5):"";                            
                            row2 = Usos.Buscar(fr.GetString("USOS"));
                            if (row2 != null)
                            {
                                fila["CODIGO USO"] = row2["CODIGO"];
                                fila["DESCRIPCION"] = row2["LISTA"].ToString().Substring(9);
                            }
                            else
                            {
                                fila["CODIGO USO"] = "";
                                fila["DESCRIPCION"] = "";
                            }                            
                            fila["USUARIO CREA"] = fr.GetString("USUARIO_CREA").ToString();
                            fila["FECHA CREACION"] = fr.GetDateTime("FECHA_CREA").ToString().Substring(11, 19);
                            fila["USUARIO MODIFICA"] = fr.GetString("USUARIO_MODIFICA").ToString();
                            fila["FECHA MODIFICACION"] = fr.GetDateTime("FECHA_MODIFICA").ToString().Substring(11, 19);                            
                            tabla.Rows.Add(fila);
                        }
                        fr.Close();

                        detalles_equipamiento_urbano.detalles_dgv.DataSource = tabla;
                        detalles_equipamiento_urbano.GEODB_bs.DataSource = tabla;
                        detalles_equipamiento_urbano.detalles_dgv.ScrollBars = System.Windows.Forms.ScrollBars.Both;
                        System.Windows.Forms.DialogResult rpta = Auto_Cad_Map.mostrar_dialogo(detalles_equipamiento_urbano);
                        if (rpta == System.Windows.Forms.DialogResult.OK)
                        {
                            if (detalles_equipamiento_urbano.Columna != "" && detalles_equipamiento_urbano.Valor != "")
                            {
                                MgGeometry geom_equipamiento_urbano = Auto_Cad_Map.buscar_geometrico("EQUIPAMIENTO_URBANO", string.Format("ID={0}", detalles_equipamiento_urbano.Valor));
                                List<string> lista_manzana = Auto_Cad_Map.buscar("MANZANA", geom_equipamiento_urbano, "CODIGO_MANZANA");
                                if (lista_manzana.Count > 0) Auto_Cad_Map.ir("MANZANA", "CODIGO_MANZANA", lista_manzana[0]);
                            }
                        }
                        else
                        {
                            detalles_equipamiento_urbano.Close();
                            return;
                        }
                    }
                    else Auto_Cad_Map.imprimir("\nError: No existe la Capa Equipamiento Urbano.");
                }
            }
            catch (MgException ex)
            {
                Auto_Cad_Map.imprimir("\nError, Buscar Equipamiento Urbano: " + ex.Message);
            }
        }        
        #endregion

        #region Metodos Equipamiento Urbano
        void control_equipamiento_urbano()
        {
            habilitado = true;
            if (Ubigeo != "" || Ubigeo != null)
            {
                Auto_Cad_Map.agregar_capa("DEPARTAMENTO", string.Format("CODIGO_DEPARTAMENTO = '{0}'", Ubigeo.Substring(0, 2)), false,false);
                Auto_Cad_Map.agregar_capa("PROVINCIA", string.Format("CODIGO_PROVINCIA = '{0}'", Ubigeo.Substring(0, 4)), false,false);
                Auto_Cad_Map.agregar_capa("DISTRITO", string.Format("UBIGEO = '{0}'", Ubigeo),false,false);
                Auto_Cad_Map.agregar_capa("SECTOR", string.Format("UBIGEO = '{0}'", Ubigeo),false,true);
                Auto_Cad_Map.agregar_capa("MANZANA", string.Format("CODIGO_SECTOR LIKE ('{0}%')", Ubigeo),false,true);
                Auto_Cad_Map.agregar_capa("VIAS", string.Format("UBIGEO = '{0}'", Ubigeo),false,true);
                Auto_Cad_Map.agregar_capa("EQUIPAMIENTO_URBANO", string.Format("UBIGEO = '{0}'", Ubigeo),false,true);
            }
        }
        void agregar_equipamiento_urbano(MgGeometry geom)
        {
            try
            {
                Equipamiento_Urbano Equipamiento_Urbano = new Equipamiento_Urbano();
                List<string> lista_manzana = new List<string>();

                lista_manzana = Auto_Cad_Map.buscar("MANZANA", geom, "CODIGO_MANZANA");

                if (lista_manzana.Count > 0)
                {
                    Equipamiento_Urbano.sector_lbl.Text = lista_manzana[0].Substring(6, 2);
                    Equipamiento_Urbano.manzana_lbl.Text = lista_manzana[0].Substring(8, 3);
                    Equipamiento_Urbano.Usuario = usuario;

                    System.Windows.Forms.DialogResult rpta = Auto_Cad_Map.mostrar_dialogo(Equipamiento_Urbano);
                    if (rpta == System.Windows.Forms.DialogResult.OK)
                    {
                        if (Ubigeo != "" || Ubigeo != null)
                        {
                            string hash = "";
                            do
                            {
                                hash = Guid.NewGuid().ToString().ToUpper();
                                Auto_Cad_Map.imprimir(string.Format("\nHASH = {0}", hash));
                            } while (Auto_Cad_Map.buscar("EQUIPAMIENTO_URBANO", "HASH", hash, 'L'));

                            string sector = Equipamiento_Urbano.sector_lbl.Text;
                            string manzana = Equipamiento_Urbano.manzana_lbl.Text;
                            string lote = Equipamiento_Urbano.lote_txt.Text;
                            string edifica = Equipamiento_Urbano.edifica_txt.Text;
                            string nombre = Equipamiento_Urbano.nombreEquipamientoUrbano_txt.Text;
                            string tipo = Equipamiento_Urbano.tipoEquipamientoUrbano_txt.Text;
                            string usos = Equipamiento_Urbano.codigoUsos_txt.Text;
                            string descripcion = Equipamiento_Urbano.descripcionUsos_lbl.Text;

                            geom = Auto_Cad_Map.interseccion_linea("MANZANA", geom, string.Format("CODIGO_MANZANA='{0}'", lista_manzana[0]));
                            if (geom != null)
                            {
                                Auto_Cad_Map.agregar_elemento_capa("EQUIPAMIENTO_URBANO",
                                new MgStringProperty("UBIGEO", Ubigeo),
                                new MgStringProperty("SECTOR", sector),
                                new MgStringProperty("MANZANA", manzana),
                                new MgStringProperty("LOTE", lote),
                                new MgStringProperty("NOMBRE_EQUIPAMIENTO_URBANO", nombre),
                                new MgStringProperty("TIPO_EQUIPAMIENTO_URBANO", tipo),
                                new MgStringProperty("USOS", usos),
                                new MgStringProperty("HASH", hash),
                                new MgGeometryProperty("GEOM", new MgAgfReaderWriter().Write(geom)),
                                new MgStringProperty("E", "A"),
                                new MgStringProperty("USUARIO_CREA", usuario.ToUpper()),
                                new MgStringProperty("USUARIO_MODIFICA", usuario.ToUpper()));

                                rpta = System.Windows.Forms.MessageBox.Show("Desea ingresar la Ficha Catastral de Equipamiento Urbano", "Pregunta", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);
                                if (rpta == System.Windows.Forms.DialogResult.Yes)
                                {
                                    List<string> listar_coordenadas = Auto_Cad_Map.buscar_coordenadas("EQUIPAMIENTO_URBANO", geom, string.Format("HASH = '{0}'", hash));
                                    if (listar_coordenadas.Count > 0)
                                    {
                                        Ficha_Catastral_Equipamiento_Urbano Ficha_Catastral_Equipamiento_Urbano = new Ficha_Catastral_Equipamiento_Urbano();

                                        Ficha_Catastral_Equipamiento_Urbano.departamento_lbl.Text = Ubigeo.Substring(0, 2);
                                        Ficha_Catastral_Equipamiento_Urbano.provincia_lbl.Text = Ubigeo.Substring(2, 2);
                                        Ficha_Catastral_Equipamiento_Urbano.distrito_lbl.Text = Ubigeo.Substring(4, 2);
                                        Ficha_Catastral_Equipamiento_Urbano.sector_lbl.Text = sector;
                                        Ficha_Catastral_Equipamiento_Urbano.manzana_lbl.Text = manzana;
                                        Ficha_Catastral_Equipamiento_Urbano.lote_lbl.Text = lote;
                                        Ficha_Catastral_Equipamiento_Urbano.edifica_lbl.Text = edifica;
                                        Ficha_Catastral_Equipamiento_Urbano.nombreEquipamientoUrbano_lbl.Text = nombre;
                                        Ficha_Catastral_Equipamiento_Urbano.tipoEquipamientoUrbano_lbl.Text = tipo;
                                        Ficha_Catastral_Equipamiento_Urbano.usos_lbl.Text = usos;
                                        Ficha_Catastral_Equipamiento_Urbano.descripcion_lbl.Text = descripcion;
                                        Ficha_Catastral_Equipamiento_Urbano.puntoX_lbl.Text = listar_coordenadas[0];
                                        Ficha_Catastral_Equipamiento_Urbano.puntoY_lbl.Text = listar_coordenadas[1];
                                        Ficha_Catastral_Equipamiento_Urbano.Hash = hash;
                                        Ficha_Catastral_Equipamiento_Urbano.Usuario = usuario;
                                        Ficha_Catastral_Equipamiento_Urbano.Show();
                                    }
                                }
                            }
                        }
                        else Auto_Cad_Map.imprimir("\nError: no existe la capa Distrito");
                    }
                }
            }
            catch (MgException ex)
            {
                Auto_Cad_Map.imprimir("\nError, Agregar Equipamiento Urbano: " + ex.Message);
            }
        }
        #endregion
        #endregion

        #region [ PUERTA ]
        #region Comandos Puerta
        /// <summary>
        /// Cargar Puertas.
        /// </summary>
        [CommandMethod("p1")]
        public void cargar_puerta()
        {
            if (!habilitado)
            {
                Autenticarse autenticarse = new Autenticarse();
                System.Windows.Forms.DialogResult rpta = Auto_Cad_Map.mostrar_dialogo(autenticarse);
                usuario = autenticarse.user;
                Ubigeo = cUbicacion_Geografica.Ubigeo;
                if (rpta == System.Windows.Forms.DialogResult.OK) control_puerta();
            }
            else control_puerta();           
        }

        /// <summary>
        /// Seleccionar Puerta.
        /// </summary>
        [CommandMethod("p2")]
        public void seleccionar_puerta()
        {
            try
            {
                if (Auto_Cad_Map.existe_capa("PUERTA"))
                {
                    double[,] coordenadas;
                    //bool estado;
                    PromptEntityOptions puerta = new PromptEntityOptions("\nSeleccionar la Linea: ");
                    PromptEntityResult rpta_punto = Auto_Cad_Map.Editor.GetEntity(puerta);
                    if (rpta_punto.Status != PromptStatus.OK) return;
                    ObjectId objeto_id = rpta_punto.ObjectId;
                    coordenadas = Auto_Cad_Map.entidad_geometrica_polilinea(objeto_id);
                    MgGeometry geom = Auto_Cad_Map.crear_geometria_linea(coordenadas);
                    if (!geom.IsValid())
                    {
                        Auto_Cad_Map.imprimir("\nInvalidado dato geográfico");
                        return;
                    }
                    if (geom != null) agregar_puerta(geom);
                }
                else Auto_Cad_Map.imprimir("\nError: No existe la capa Puertas");
            }
            catch (MgException ex)
            {
                Auto_Cad_Map.imprimir("\nError, Seleccionar Eje de Puerta: " + ex.Message);
            }
        }

        /// <summary>
        /// Buscar Puerta.
        /// </summary>
        [CommandMethod("r1")]
        public void buscar_puerta()
        {
            try
            {                
                MgLayerBase capa_puerta = Auto_Cad_Map.obtener_capa("PUERTA");
                if (capa_puerta != null)
                {
                    MgFeatureReader fr = capa_puerta.SelectFeatures(new MgFeatureQueryOptions());
                    System.Data.DataTable tabla = new System.Data.DataTable();
                    tabla.Columns.Add("ID");
                    tabla.Columns.Add("MANZANA");
                    tabla.Columns.Add("CODIGO DE VIA");                    
                    tabla.Columns.Add("DIRECCION");
                    tabla.Columns.Add("CUADRA");
                    tabla.Columns.Add("TIPO DE PUERTA");
                    tabla.Columns.Add("NUMERO OFICIAL");
                    tabla.Columns.Add("AÑO");
                    tabla.Columns.Add("USUARIO CREA");
                    tabla.Columns.Add("FECHA CREACION");
                    tabla.Columns.Add("USUARIO MODIFICA");
                    tabla.Columns.Add("FECHA MODIFICACION");
                    DataRow fila;
                    fr.ReadNext();
                    while (fr.ReadNext())
                    {
                        fila = tabla.NewRow();
                        fila["ID"] = fr.GetInt32("ID");
                        fila["MANZANA"] =fr.GetString("MANZANA");
                        fila["CODIGO DE VIA"] = fr.GetString("CODIGO_VIA");
                        fila["DIRECCION"] = fr.GetString("DIRECCION");
                        fila["CUADRA"] = fr.GetString("CUADRA");
                        fila["TIPO DE PUERTA"] = fr.GetString("TIPO_PUERTA");
                        fila["NUMERO OFICIAL"] = fr.GetString("NUMERO_OFICIAL");
                        fila["AÑO"] = fr.GetString("AÑO");
                        fila["USUARIO CREA"] = fr.GetString("USUARIO_CREA");
                        fila["FECHA CREACION"] = fr.GetDateTime("FECHA_CREA").ToString().Substring(11, 19);
                        fila["USUARIO MODIFICA"] = fr.GetString("USUARIO_MODIFICA");
                        fila["FECHA MODIFICACION"] = fr.GetDateTime("FECHA_MODIFICA").ToString().Substring(11, 19);
                        tabla.Rows.Add(fila);                        
                    }
                    fr.Close();
                    Detalles detalles_puerta = new Detalles();
                    detalles_puerta.detalles_dgv.ScrollBars = System.Windows.Forms.ScrollBars.Both;
                    detalles_puerta.Text = "Propiedades - Capa Puerta";
                    System.Windows.Forms.DialogResult rpta;
                    detalles_puerta.detalles_dgv.DataSource = tabla;
                    detalles_puerta.GEODB_bs.DataSource = tabla;
                    if (tabla.Rows.Count > 0)
                        rpta = Auto_Cad_Map.mostrar_dialogo(detalles_puerta);
                    else return;

                    if (rpta == System.Windows.Forms.DialogResult.OK)
                    {
                        Auto_Cad_Map.imprimir(string.Format("\nPuerta: {0} = {1}", detalles_puerta.Columna, detalles_puerta.Valor));
                        if (detalles_puerta.Columna != "" && detalles_puerta.Valor != "")
                        {
                            MgFeatureQueryOptions consulta = new MgFeatureQueryOptions();
                            consulta.SetFilter(string.Format("{0} = {1}", detalles_puerta.Columna, detalles_puerta.Valor));                                
                            MgFeatureReader fr_puerta = capa_puerta.SelectFeatures(consulta);
                            Detalles_Certificado_Numeracion detalle_certificado_numeracion = new Detalles_Certificado_Numeracion();
                            while (fr_puerta.ReadNext())
                            {
                                detalle_certificado_numeracion.codigo_puerta = fr_puerta.GetInt32("ID");
                                detalle_certificado_numeracion.codigo_via = fr_puerta.GetString("CODIGO_VIA");
                                detalle_certificado_numeracion.direccion  = fr_puerta.GetString("DIRECCION");
                                detalle_certificado_numeracion.tipo_puerta = fr_puerta.GetString("TIPO_PUERTA");
                            }
                            fr_puerta.Close();
                            detalle_certificado_numeracion.Usuario = usuario;
                            detalle_certificado_numeracion.ShowDialog();
                        }
                    }
                    else
                    {
                        detalles_puerta.Close();
                        return;
                    }
                }
                else Auto_Cad_Map.imprimir("\nError: No existe la Capa Puerta.");
            }
            catch (MgException ex)
            {
                Auto_Cad_Map.imprimir("\nError: Buscar Puerta, " + ex.Message);
            }
        }
        #endregion

        #region Metodos Puerta
        void control_puerta()
        {
            habilitado = true;
            if (Ubigeo != "" || Ubigeo != null)
            {
                Auto_Cad_Map.agregar_capa("DEPARTAMENTO", string.Format("CODIGO_DEPARTAMENTO = '{0}'", Ubigeo.Substring(0, 2)), false,false);
                Auto_Cad_Map.agregar_capa("PROVINCIA", string.Format("CODIGO_PROVINCIA = '{0}'", Ubigeo.Substring(0, 4)), false,false);
                Auto_Cad_Map.agregar_capa("DISTRITO", string.Format("UBIGEO = '{0}'", Ubigeo), false,false);
                Auto_Cad_Map.agregar_capa("SECTOR", string.Format("UBIGEO = '{0}'", Ubigeo), false,true);
                Auto_Cad_Map.agregar_capa("MANZANA", string.Format("CODIGO_SECTOR LIKE ('{0}%')", Ubigeo), false,true);
                Auto_Cad_Map.agregar_capa("VIAS", string.Format("UBIGEO = '{0}'", Ubigeo), false,true);
                Auto_Cad_Map.agregar_capa("EQUIPAMIENTO_URBANO", string.Format("UBIGEO = '{0}'", Ubigeo), false,true);
                Auto_Cad_Map.agregar_capa("PUERTA", string.Format("UBIGEO = '{0}'", Ubigeo), false, true);
            }
        }
        void agregar_puerta(MgGeometry geom)
        {
            try
            {
                MgGeometry geom_interseccion = null;
                double[,] coordenadas = null;                
                List<string> lista_codigo_via = Auto_Cad_Map.buscar("VIAS", geom, "CODIGO_VIA");
                List<string> lista_manzana = Auto_Cad_Map.buscar("MANZANA", geom, "CODIGO_MANZANA");
                List<string> lista_direccion = new List<string>();
                List<string> lista_cuadra = new List<string>();

                if (lista_codigo_via.Count > 0)
                {
                    lista_direccion = Auto_Cad_Map.buscar("VIAS", geom, "DIRECCION", string.Format("CODIGO_VIA = '{0}'", lista_codigo_via[0]));
                    lista_cuadra = Auto_Cad_Map.buscar("VIAS", geom, "CUADRA", string.Format("CODIGO_VIA = '{0}'", lista_codigo_via[0]));

                    if (lista_manzana.Count > 0 && lista_direccion.Count > 0 && lista_cuadra.Count > 0)
                    {
                        Auto_Cad_Map.imprimir(string.Format("\n Intersección: Sector = {0} \t Manzana = {1}", lista_manzana[0].Substring(6, 2), lista_manzana[0].Substring(8, 3)));
                        coordenadas = (new cFicha_Catastral_Vias_Urbanas()).listar(Ubigeo, lista_codigo_via[0], lista_cuadra[0]);

                        if (coordenadas != null)
                        {
                            AcMapLayer capa_puerta = (AcMapLayer)Auto_Cad_Map.obtener_capa("PUERTA");
                            if (capa_puerta != null)
                            {
                                geom_interseccion = Auto_Cad_Map.interseccion_punto("MANZANA", geom, string.Format("CODIGO_MANZANA = '{0}'", lista_manzana[0]));
                                char lado;
                                if (geom_interseccion != null)
                                {
                                    string numero_oficial = Auto_Cad_Map.distancia("VIAS", geom, lista_cuadra[0], string.Format("CODIGO_VIA = '{0}'", lista_codigo_via[0]), geom_interseccion, coordenadas, out lado);
                                    Puerta puerta = new Puerta();
                                    puerta.Usuario = usuario;
                                    puerta.sector_lbl.Text = lista_manzana[0].Substring(6, 2);
                                    puerta.manzana_lbl.Text = lista_manzana[0].Substring(8, 3);
                                    puerta.codigoVias_lbl.Text = lista_codigo_via[0];
                                    puerta.direccion_lbl.Text = lista_direccion[0];
                                    puerta.cuadra_lbl.Text = lista_cuadra[0];

                                    puerta.puntoInicialX_lbl.Text = coordenadas[0, 0].ToString();
                                    puerta.puntoInicialY_lbl.Text = coordenadas[0, 1].ToString();
                                    puerta.puntoFinalX_lbl.Text = coordenadas[1, 0].ToString();
                                    puerta.puntoFinalY_lbl.Text = coordenadas[1, 1].ToString();

                                    puerta.numero_oficial_txt.Text = numero_oficial;
                                    puerta.sentido_txt.Text = (lado == 'D') ? "DERECHA" : "IZQUIERDA";
                                    System.Windows.Forms.DialogResult rpta = Auto_Cad_Map.mostrar_dialogo(puerta);
                                    if (rpta == System.Windows.Forms.DialogResult.OK)
                                    {
                                        Auto_Cad_Map.agregar_elemento_capa("PUERTA",
                                        new MgStringProperty("UBIGEO", Ubigeo),
                                        new MgStringProperty("CODIGO_VIA", lista_codigo_via[0]),
                                        new MgStringProperty("DIRECCION", lista_direccion[0]),
                                        new MgStringProperty("SECTOR", puerta.sector_lbl.Text),
                                        new MgStringProperty("MANZANA", puerta.manzana_lbl.Text),
                                        new MgStringProperty("LOTE", ""),
                                        new MgStringProperty("CUADRA", lista_cuadra[0]),
                                        new MgStringProperty("SENTIDO", lado.ToString()),
                                        new MgStringProperty("TIPO_PUERTA", puerta.tipoPuerta_txt.Text),
                                        new MgStringProperty("NUMERO_OFICIAL", puerta.numero_oficial_txt.Text),
                                        new MgStringProperty("NUMERO_ACTUAL", puerta.numeroActual_txt.Text),
                                        new MgStringProperty("AÑO", DateTime.Today.Year.ToString()),
                                        new MgGeometryProperty("GEOM", new MgAgfReaderWriter().Write(geom_interseccion)),
                                        new MgStringProperty("E", "A"),
                                        new MgStringProperty("USUARIO_CREA", usuario.ToUpper()),
                                        new MgStringProperty("USUARIO_MODIFICA", usuario.ToUpper()));
                                    }
                                }
                                else Auto_Cad_Map.imprimir("\nError: no existe intersección con la Capa Manzanas.");
                            }
                            else Auto_Cad_Map.imprimir("\nError: no existe Capa Puerta.");
                        }
                        else Auto_Cad_Map.imprimir("\nError: no existe registrado la Ficha Catastral de Vias Urbanas");
                    }
                    else Auto_Cad_Map.imprimir("\nError: no existe Código de Via y/o Código de Manzana.");
                }                
            }
            catch (System.Exception e)
            {
                Auto_Cad_Map.imprimir("\nError, Agregar Puerta: " + e.Message);
            }
        }        
        #endregion
        #endregion       
     
        #region [ TIPO DE COMPONENTE URBANO ]
        #region Comandos Tipo de Componente Urbano
        /// <summary>
        /// Cargar Componente Urbanos - Vias y Espacios de Recreación.
        /// </summary>
        [CommandMethod("c1")]
        public void cargar_tipo_componente_urbano()
        {
            if (!habilitado)
            {
                Autenticarse autenticarse = new Autenticarse();
                System.Windows.Forms.DialogResult rpta = Auto_Cad_Map.mostrar_dialogo(autenticarse);
                usuario = autenticarse.user;
                Ubigeo = cUbicacion_Geografica.Ubigeo;
                if (rpta == System.Windows.Forms.DialogResult.OK) control_tipo_componente_urbano();
            }
            else control_tipo_componente_urbano();
        }

        /// <summary>
        /// Seleccionar Componente Urbanos - Vias y Espacios de Recreación.
        /// </summary>
        [CommandMethod("c2", CommandFlags.UsePickSet)]
        public void seleccionar_tipo_componente_urbano()
        {
            try
            {
                PromptSelectionResult rpta = Auto_Cad_Map.Editor.SelectImplied();
                if (rpta.Status == PromptStatus.Error) return;
                Autodesk.AutoCAD.EditorInput.SelectionSet seleccion = rpta.Value;
                ObjectId[] objetos = seleccion.GetObjectIds();
                Database db = Auto_Cad_Map.DB;
                TransactionManager tm = db.TransactionManager;
                Transaction t = tm.StartTransaction();
                Modulo modulo = new Modulo();
                modulo.t = 'C';
                System.Windows.Forms.DialogResult rpta_modulo = Auto_Cad_Map.mostrar_dialogo(modulo);
                string capa = modulo.capa;
                string tipo = modulo.tipo;
                string material = modulo.material;
                if (rpta_modulo == System.Windows.Forms.DialogResult.OK)
                {
                    double[,] coordenadas = null;
                    MgGeometry geom = null;
                    List<MgGeometry> lista_geom = new List<MgGeometry>();
                    Auto_Cad_Map.imprimir(string.Format("\n Capa: {0} \tTipo de Componente Urbano: {1}\tMaterial: {2}", capa, tipo, material));
                    foreach (ObjectId id in objetos)
                    {
                        Entity entidad = (Entity)tm.GetObject(id, OpenMode.ForWrite, true);
                        if (entidad.GetType().FullName == "Autodesk.AutoCAD.DatabaseServices.BlockReference")
                        {
                            coordenadas = Auto_Cad_Map.entidad_geometrica_block_referencia(id);
                            geom = Auto_Cad_Map.crear_geometria_punto(coordenadas);
                        }
                        else if (entidad.GetType().FullName == "Autodesk.AutoCAD.DatabaseServices.DBPoint")
                        {
                            coordenadas = Auto_Cad_Map.entidad_geometrica_punto(id);
                            geom = Auto_Cad_Map.crear_geometria_punto(coordenadas);
                        }
                        else if (entidad.GetType().FullName == "Autodesk.AutoCAD.DatabaseServices.Line" || entidad.GetType().FullName == "Autodesk.AutoCAD.DatabaseServices.Polyline")
                        {
                            coordenadas = Auto_Cad_Map.entidad_geometrica_polilinea(id);
                            geom = Auto_Cad_Map.crear_geometria_linea(coordenadas);
                        }
                        Auto_Cad_Map.imprimir("\n Objeto: " + entidad.GetType().FullName);
                        if (coordenadas != null)
                        {
                            if (!geom.IsValid())
                            {
                                Auto_Cad_Map.imprimir("\nInvalidado dato geográfico");
                                return;
                            }
                            if (geom != null) lista_geom.Add(geom);
                        }
                    }
                    t.Dispose();
                    if (lista_geom.Count > 0) agregar_tipo_componente_urbano(lista_geom, tipo, material,(capa == "0")?"VU":"ER");
                }
            }
            catch (System.Exception e)
            {
                Auto_Cad_Map.imprimir("\nError, Seleccionar Tipo de Componente Urbano: " + e.Message);
            }
        }
        #endregion

        #region Metodos Tipo de Componente Urbano
        void control_tipo_componente_urbano()
        {
            habilitado = true;
            if (Ubigeo != "" || Ubigeo != null)
            {
                Auto_Cad_Map.agregar_capa("DEPARTAMENTO", string.Format("CODIGO_DEPARTAMENTO = '{0}'", Ubigeo.Substring(0, 2)), false, false);
                Auto_Cad_Map.agregar_capa("PROVINCIA", string.Format("CODIGO_PROVINCIA = '{0}'", Ubigeo.Substring(0, 4)), false, false);
                Auto_Cad_Map.agregar_capa("DISTRITO", string.Format("UBIGEO = '{0}'", Ubigeo), false, false);
                Auto_Cad_Map.agregar_capa("SECTOR", string.Format("UBIGEO = '{0}'", Ubigeo), false, false);
                Auto_Cad_Map.agregar_capa("MANZANA", string.Format("CODIGO_SECTOR LIKE ('{0}%')", Ubigeo), false, false);
                Auto_Cad_Map.agregar_capa("VIAS", string.Format("UBIGEO = '{0}'", Ubigeo), false, false);
                Auto_Cad_Map.agregar_capa("EQUIPAMIENTO_URBANO", string.Format("UBIGEO = '{0}'", Ubigeo), false, false);
                Auto_Cad_Map.agregar_capa("PUERTA", string.Format("UBIGEO = '{0}'", Ubigeo), false, false);
                Auto_Cad_Map.agregar_capa("TIPO_COMPONENTE_URBANO", string.Format("UBIGEO = '{0}'", Ubigeo), false, true);               
            }
        }
        void agregar_tipo_componente_urbano(List<MgGeometry> lista_geom, string tipo, string material,string t)
        {
            try
            {
                MgPropertyCollection[] conjunto_propiedades = new MgPropertyCollection[lista_geom.Count];
                string sector="";
                string codigo_via="";
                string cuadra="";
                string manzana = "";                

                if (t == "VU")
                {
                    Modulo_Componente_Urbano_Mobiliario_Urbano modulo = new Modulo_Componente_Urbano_Mobiliario_Urbano();
                    modulo.Text = "Tipo de Componente Urbano";
                    System.Windows.Forms.DialogResult rpta = Auto_Cad_Map.mostrar_dialogo(modulo);
                    if (rpta == System.Windows.Forms.DialogResult.OK)
                    {
                        List<string> lista_sector = Auto_Cad_Map.buscar("SECTOR", lista_geom[0], "SECTOR");
                        if(lista_sector.Count>0) sector = lista_sector[0];
                        codigo_via = modulo.codigoVias_txt.Text.Trim();
                        cuadra = modulo.cuadra_txt.Text.Trim();

                        for (int i = 0; i < lista_geom.Count; i++)
                        {
                            conjunto_propiedades[i] = Auto_Cad_Map.conjunto_propiedades(new MgStringProperty("UBIGEO", Ubigeo),
                                        new MgStringProperty("SECTOR", sector),
                                        new MgStringProperty("CODIGO_VIA_MANZANA", codigo_via),
                                        new MgStringProperty("CUADRA_LOTE",cuadra),
                                        new MgStringProperty("AÑO", DateTime.Today.Year.ToString()),
                                        new MgStringProperty("TIPO_COMPONENTE_URBANO", tipo),
                                        new MgStringProperty("OTRO_TIPO_COMPONENTE_URBANO", ""),
                                        new MgStringProperty("MATERIAL", material),
                                        new MgStringProperty("OTRO_MATERIAL", ""),
                                        new MgStringProperty("TIPO", t),
                                        new MgGeometryProperty("GEOM", new MgAgfReaderWriter().Write(lista_geom[i])),
                                        new MgStringProperty("E", "A"),
                                        new MgStringProperty("USUARIO_CREA", usuario.ToUpper()),
                                        new MgStringProperty("USUARIO_MODIFICA", usuario.ToUpper()));
                        }
                        Auto_Cad_Map.agregar_elemento_capa("TIPO_COMPONENTE_URBANO", conjunto_propiedades);
                    }
                }
                else if (t == "ER")
                {
                    List<string> lista_manzana = Auto_Cad_Map.buscar("MANZANA", lista_geom[0], "CODIGO_MANZANA");
                    if (lista_manzana.Count > 0)
                    {
                        sector = lista_manzana[0].Substring(6, 2);
                        manzana = lista_manzana[0].Substring(8, 3);
                    
                        for (int i = 0; i < lista_geom.Count; i++)
                        {
                            conjunto_propiedades[i] = Auto_Cad_Map.conjunto_propiedades(new MgStringProperty("UBIGEO", Ubigeo),
                                        new MgStringProperty("SECTOR", sector),
                                        new MgStringProperty("CODIGO_VIA_MANZANA", manzana),
                                        new MgStringProperty("CUADRA_LOTE", ""),
                                        new MgStringProperty("AÑO", DateTime.Today.Year.ToString()),
                                        new MgStringProperty("TIPO_COMPONENTE_URBANO", tipo),
                                        new MgStringProperty("OTRO_TIPO_COMPONENTE_URBANO", ""),
                                        new MgStringProperty("MATERIAL", material),
                                        new MgStringProperty("OTRO_MATERIAL", ""),
                                        new MgStringProperty("TIPO", t),
                                        new MgGeometryProperty("GEOM", new MgAgfReaderWriter().Write(lista_geom[i])),
                                        new MgStringProperty("E", "A"),
                                        new MgStringProperty("USUARIO_CREA", usuario.ToUpper()),
                                        new MgStringProperty("USUARIO_MODIFICA", usuario.ToUpper()));
                        }
                        Auto_Cad_Map.agregar_elemento_capa("TIPO_COMPONENTE_URBANO", conjunto_propiedades);
                    }
                }
            }
            catch (System.Exception e)
            {
                Auto_Cad_Map.imprimir("\nError, Agregar Tipo de Componente Urbano: " + e.Message);
            }
        }        
        #endregion
        #endregion

        #region [ TIPO DE MOBILIARIO URBANO ]
        #region Comandos Tipo de Mobiliario Urbano
        /// <summary>
        ///  Cargar Mobiliario Urbanos - Vias y Espacios de Recreación.
        /// </summary>
        [CommandMethod("n1")]
        public void cargar_tipo_mobiliario_urbano()
        {
            if (!habilitado)
            {
                Autenticarse autenticarse = new Autenticarse();
                System.Windows.Forms.DialogResult rpta = Auto_Cad_Map.mostrar_dialogo(autenticarse);
                usuario = autenticarse.user;
                Ubigeo = cUbicacion_Geografica.Ubigeo;
                if (rpta == System.Windows.Forms.DialogResult.OK) control_tipo_mobiliario_urbano();
            }
            else control_tipo_mobiliario_urbano();
        }

        /// <summary>
        /// Seleccionar Mobiliario Urbanos - Vias y Espacios de Recreación.
        /// </summary>
        [CommandMethod("n2", CommandFlags.UsePickSet)]
        public void seleccionar_tipo_mobiliario_urbano()
        {
            try
            {
                PromptSelectionResult rpta = Auto_Cad_Map.Editor.SelectImplied();
                if (rpta.Status == PromptStatus.Error) return;
                Autodesk.AutoCAD.EditorInput.SelectionSet seleccion = rpta.Value;
                ObjectId[] objetos = seleccion.GetObjectIds();
                Database db = Auto_Cad_Map.DB;
                TransactionManager tm = db.TransactionManager;
                Transaction t = tm.StartTransaction();
                Modulo modulo = new Modulo();
                modulo.t = 'M';
                System.Windows.Forms.DialogResult rpta_modulo = Auto_Cad_Map.mostrar_dialogo(modulo);
                string capa = modulo.capa;
                string tipo = modulo.tipo;
                string material = modulo.material;
                if (rpta_modulo == System.Windows.Forms.DialogResult.OK)
                {
                    double[,] coordenadas = null;
                    MgGeometry geom = null;
                    List<MgGeometry> lista_geom = new List<MgGeometry>();
                    Auto_Cad_Map.imprimir(string.Format("\n Capa: {0} \tTipo de Mobiliario Urbano: {1}\tMaterial: {2}", capa, tipo, material));

                    foreach (ObjectId id in objetos)
                    {
                        Entity entidad = (Entity)tm.GetObject(id, OpenMode.ForWrite, true);
                        if (entidad.GetType().FullName == "Autodesk.AutoCAD.DatabaseServices.BlockReference")
                        {
                            coordenadas = Auto_Cad_Map.entidad_geometrica_block_referencia(id);
                            geom = Auto_Cad_Map.crear_geometria_punto(coordenadas);
                        }
                        else if (entidad.GetType().FullName == "Autodesk.AutoCAD.DatabaseServices.DBPoint")
                        {
                            coordenadas = Auto_Cad_Map.entidad_geometrica_punto(id);
                            geom = Auto_Cad_Map.crear_geometria_punto(coordenadas);
                        }
                        else if (entidad.GetType().FullName == "Autodesk.AutoCAD.DatabaseServices.Line" || entidad.GetType().FullName == "Autodesk.AutoCAD.DatabaseServices.Polyline")
                        {
                            coordenadas = Auto_Cad_Map.entidad_geometrica_polilinea(id);
                            geom = Auto_Cad_Map.crear_geometria_linea(coordenadas);
                        }
                        Auto_Cad_Map.imprimir("\n Objeto: " + entidad.GetType().FullName);
                        if (coordenadas != null)
                        {
                            if (!geom.IsValid())
                            {
                                Auto_Cad_Map.imprimir("\nInvalidado dato geográfico");
                                return;
                            }
                            if (geom != null) lista_geom.Add(geom);
                        }
                    }
                    t.Dispose();
                    if (lista_geom.Count > 0) agregar_tipo_mobiliario_urbano(lista_geom, tipo, material, (capa == "0") ? "VU" : "ER");
                }
            }
            catch (System.Exception e)
            {
                Auto_Cad_Map.imprimir("\nError, Seleccionar Tipo de Mobiliario Urbano: " + e.Message);
            }
        }
        #endregion

        #region Metodos Tipo de Mobiliario Urbano
        void control_tipo_mobiliario_urbano()
        {
            habilitado = true;
            if (Ubigeo != "" || Ubigeo != null)
            {
                Auto_Cad_Map.agregar_capa("DEPARTAMENTO", string.Format("CODIGO_DEPARTAMENTO = '{0}'", Ubigeo.Substring(0, 2)), false, false);
                Auto_Cad_Map.agregar_capa("PROVINCIA", string.Format("CODIGO_PROVINCIA = '{0}'", Ubigeo.Substring(0, 4)), false, false);
                Auto_Cad_Map.agregar_capa("DISTRITO", string.Format("UBIGEO = '{0}'", Ubigeo), false, false);
                Auto_Cad_Map.agregar_capa("SECTOR", string.Format("UBIGEO = '{0}'", Ubigeo), false, false);
                Auto_Cad_Map.agregar_capa("MANZANA", string.Format("CODIGO_SECTOR LIKE ('{0}%')", Ubigeo), false, false);
                Auto_Cad_Map.agregar_capa("VIAS", string.Format("UBIGEO = '{0}'", Ubigeo), false, false);
                Auto_Cad_Map.agregar_capa("EQUIPAMIENTO_URBANO", string.Format("UBIGEO = '{0}'", Ubigeo), false, false);
                Auto_Cad_Map.agregar_capa("PUERTA", string.Format("UBIGEO = '{0}'", Ubigeo), false, false);
                Auto_Cad_Map.agregar_capa("TIPO_COMPONENTE_URBANO", string.Format("UBIGEO = '{0}'", Ubigeo), false, false); 
                Auto_Cad_Map.agregar_capa("TIPO_MOBILIARIO_URBANO", string.Format("UBIGEO = '{0}'", Ubigeo),false, true);                
            }
        }
        void agregar_tipo_mobiliario_urbano(List<MgGeometry> lista_geom, string tipo, string material, string t)
        {
            try
            {
                MgPropertyCollection[] conjunto_propiedades = new MgPropertyCollection[lista_geom.Count];
                string sector = "";
                string codigo_via = "";
                string cuadra = "";
                string manzana = "";

                if (t == "VU")
                {
                    Modulo_Componente_Urbano_Mobiliario_Urbano modulo = new Modulo_Componente_Urbano_Mobiliario_Urbano();
                    modulo.Text = "Tipo de Componente Urbano";
                    System.Windows.Forms.DialogResult rpta = Auto_Cad_Map.mostrar_dialogo(modulo);
                    if (rpta == System.Windows.Forms.DialogResult.OK)
                    {
                        List<string> lista_sector = Auto_Cad_Map.buscar("SECTOR", lista_geom[0], "SECTOR");
                        if (lista_sector.Count > 0) sector = lista_sector[0];
                        codigo_via = modulo.codigoVias_txt.Text.Trim();
                        cuadra = modulo.cuadra_txt.Text.Trim();

                        for (int i = 0; i < lista_geom.Count; i++)
                        {
                            conjunto_propiedades[i] = Auto_Cad_Map.conjunto_propiedades(new MgStringProperty("UBIGEO", Ubigeo),
                                        new MgStringProperty("SECTOR", sector),
                                        new MgStringProperty("CODIGO_VIA_MANZANA", codigo_via),
                                        new MgStringProperty("CUADRA_LOTE",cuadra),
                                        new MgStringProperty("AÑO", DateTime.Today.Year.ToString()),
                                        new MgStringProperty("TIPO_MOBILIARIO_URBANO", tipo),
                                        new MgStringProperty("OTRO_TIPO_MOBILIARIO_URBANO", ""),
                                        new MgStringProperty("MATERIAL", material),
                                        new MgStringProperty("OTRO_MATERIAL", ""),
                                        new MgStringProperty("TIPO", t),
                                        new MgGeometryProperty("GEOM", new MgAgfReaderWriter().Write(lista_geom[i])),
                                        new MgStringProperty("E", "A"),
                                        new MgStringProperty("USUARIO_CREA", usuario.ToUpper()),
                                        new MgStringProperty("USUARIO_MODIFICA", usuario.ToUpper()));
                        }
                        Auto_Cad_Map.agregar_elemento_capa("TIPO_MOBILIARIO_URBANO", conjunto_propiedades);
                    }
                }
                else if (t == "ER")
                {
                    List<string> lista_manzana = Auto_Cad_Map.buscar("MANZANA", lista_geom[0], "CODIGO_MANZANA");
                    if (lista_manzana.Count > 0)
                    {
                        sector = lista_manzana[0].Substring(6, 2);
                        manzana = lista_manzana[0].Substring(8, 3);

                        for (int i = 0; i < lista_geom.Count; i++)
                        {
                            conjunto_propiedades[i] = Auto_Cad_Map.conjunto_propiedades(new MgStringProperty("UBIGEO", Ubigeo),
                                        new MgStringProperty("SECTOR", sector),
                                        new MgStringProperty("CODIGO_VIA_MANZANA",manzana),
                                        new MgStringProperty("CUADRA_LOTE",  ""),
                                        new MgStringProperty("AÑO", DateTime.Today.Year.ToString()),
                                        new MgStringProperty("TIPO_MOBILIARIO_URBANO", tipo),
                                        new MgStringProperty("OTRO_TIPO_MOBILIARIO_URBANO", ""),
                                        new MgStringProperty("MATERIAL", material),
                                        new MgStringProperty("OTRO_MATERIAL", ""),
                                        new MgStringProperty("TIPO", t),
                                        new MgGeometryProperty("GEOM", new MgAgfReaderWriter().Write(lista_geom[i])),
                                        new MgStringProperty("E", "A"),
                                        new MgStringProperty("USUARIO_CREA", usuario.ToUpper()),
                                        new MgStringProperty("USUARIO_MODIFICA", usuario.ToUpper()));
                        }
                        Auto_Cad_Map.agregar_elemento_capa("TIPO_MOBILIARIO_URBANO", conjunto_propiedades);
                    }
                }
            }
            catch (System.Exception e)
            {
                Auto_Cad_Map.imprimir("\nError, Agregar Tipo de Mobiliario Urbano: " + e.Message);
            }
        }        
        #endregion
        #endregion       

        #region [ USO RESALTANTE ]
        #region Comandos de Usos Resaltantes
        /// <summary>
        /// Cargar Uso Resaltante
        /// </summary>
        [CommandMethod("u1")]
        public void cargar_uso_resaltante()
        {
            if (!habilitado)
            {
                Autenticarse autenticarse = new Autenticarse();
                System.Windows.Forms.DialogResult rpta = Auto_Cad_Map.mostrar_dialogo(autenticarse);
                usuario = autenticarse.user;
                Ubigeo = cUbicacion_Geografica.Ubigeo;
                if (rpta == System.Windows.Forms.DialogResult.OK) control_uso_resaltante();
            }
            else control_uso_resaltante();
        }

        /// <summary>
        /// Seleccionar Uso Resaltante
        /// </summary>
        [CommandMethod("u2")]
        public void seleccionar_uso_resaltante()
        {
            try
            {
                if (Auto_Cad_Map.existe_capa("USO_RESALTANTE"))
                {
                    double[,] coordenadas;
                    PromptEntityOptions opciones = new PromptEntityOptions("\nSeleccionar una linea: ");
                    PromptEntityResult rpta_equipamiento = Auto_Cad_Map.Editor.GetEntity(opciones);
                    if (rpta_equipamiento.Status != PromptStatus.OK) return;
                    ObjectId objeto_id = rpta_equipamiento.ObjectId;
                    coordenadas = Auto_Cad_Map.entidad_geometrica_polilinea(objeto_id);
                    MgGeometry geom = Auto_Cad_Map.crear_geometria_linea(coordenadas);
                    if (!geom.IsValid())
                    {
                        Auto_Cad_Map.Editor.WriteMessage("\nInvalidado dato geográfico");
                        return;
                    }
                    if (geom != null) agregar_uso_resaltante(geom);
                }
                else Auto_Cad_Map.imprimir("\nError: No existe la capa Uso Resaltante");
            }
            catch (MgException ex)
            {
                Auto_Cad_Map.Editor.WriteMessage("\nError, Seleccionar Uso Resaltante: " + ex.Message);
            }
        }

        /// <summary>
        /// Busca Uso Resaltante
        /// </summary>
        [CommandMethod("u3")]
        public void buscar_uso_resaltante()
        {
            try
            {
                if (!habilitado)
                {
                    Autenticarse autenticarse = new Autenticarse();
                    System.Windows.Forms.DialogResult rpta = autenticarse.ShowDialog();
                    usuario = autenticarse.user;
                    Ubigeo = cUbicacion_Geografica.Ubigeo;
                    if (rpta == System.Windows.Forms.DialogResult.OK) control_uso_resaltante();
                    else if (rpta == System.Windows.Forms.DialogResult.Cancel) System.Windows.Forms.Application.Exit();
                }
                else
                {
                    Detalles detalles_usos_resaltantes = new Detalles();
                    detalles_usos_resaltantes.Text = "Propiedades - Capa Usos Resaltantes";
                    MgLayerBase capa_vias = (MgLayerBase)Auto_Cad_Map.obtener_capa("USO_RESALTANTE");
                    if (capa_vias != null)
                    {
                        MgFeatureReader fr = capa_vias.SelectFeatures(new MgFeatureQueryOptions());
                        System.Data.DataTable tabla = new System.Data.DataTable();

                        tabla.Columns.Add("ID");
                        tabla.Columns.Add("CODIGO DE VIA - MANZANA");
                        tabla.Columns.Add("CUADRA - LOTE");
                        tabla.Columns.Add("DIRECCION");
                        tabla.Columns.Add("AÑO");
                        tabla.Columns.Add("TIPO USO RESALTANTE");
                        tabla.Columns.Add("CLASIFICACION USO RESALTANTE");
                        tabla.Columns.Add("USUARIO CREA");
                        tabla.Columns.Add("FECHA CREACION");
                        tabla.Columns.Add("USUARIO MODIFICA");
                        tabla.Columns.Add("FECHA MODIFICACION");
                        DataRow fila, row1;
                        string[] row2;
                        cTipo_Uso_Resaltante Tipo_Uso_Resaltante = new cTipo_Uso_Resaltante();
                        cClasificacion_Uso_Resaltante Clasificacion_Uso_Resaltante = new cClasificacion_Uso_Resaltante();
                        fr.ReadNext();
                        while (fr.ReadNext())
                        {
                            fila = tabla.NewRow();
                            fila["ID"] = fr.GetInt32("ID");
                            fila["CODIGO DE VIA - MANZANA"] = fr.GetString("CODIGO_VIA_MANZANA");
                            fila["CUADRA - LOTE"] = fr.GetString("CUADRA_LOTE");
                            fila["DIRECCION"] = fr.GetString("DIRECCION");
                            fila["AÑO"] = fr.GetString("AÑO");
                            row1 = Tipo_Uso_Resaltante.Buscar(fr.GetString("TIPO_USO_RESALTANTE"));
                            fila["TIPO USO RESALTANTE"] = (row1 != null) ? row1["LISTA"].ToString().Substring(5) : "";
                            row2 = Clasificacion_Uso_Resaltante.Buscar(fr.GetString("TIPO_USO_RESALTANTE"),fr.GetString("CLASIFICACION_USO_RESALTANTE"));                            
                            fila["CLASIFICACION USO RESALTANTE"] = (row2.Length > 0) ? row2[0].Substring(5) : "";
                            fila["USUARIO CREA"] = fr.GetString("USUARIO_CREA").ToString();
                            fila["FECHA CREACION"] = fr.GetDateTime("FECHA_CREA").ToString().Substring(11, 19);
                            fila["USUARIO MODIFICA"] = fr.GetString("USUARIO_MODIFICA").ToString();
                            fila["FECHA MODIFICACION"] = fr.GetDateTime("FECHA_MODIFICA").ToString().Substring(11, 19);
                            tabla.Rows.Add(fila);
                        }
                        fr.Close();

                        detalles_usos_resaltantes.detalles_dgv.DataSource = tabla;
                        detalles_usos_resaltantes.GEODB_bs.DataSource = tabla;
                        detalles_usos_resaltantes.detalles_dgv.ScrollBars = System.Windows.Forms.ScrollBars.Both;
                        System.Windows.Forms.DialogResult rpta = Auto_Cad_Map.mostrar_dialogo(detalles_usos_resaltantes);
                        if (rpta == DialogResult.OK)
                        {
                            if (detalles_usos_resaltantes.Columna != "" && detalles_usos_resaltantes.Valor != "")
                            {
                                MgGeometry geom_uso_resaltante = Auto_Cad_Map.buscar_geometrico("USO_RESALTANTE", string.Format("ID={0}", detalles_usos_resaltantes.Valor));
                                List<string> lista_manzana = Auto_Cad_Map.buscar("MANZANA", geom_uso_resaltante, "CODIGO_MANZANA");
                                if (lista_manzana.Count > 0) Auto_Cad_Map.ir("MANZANA", "CODIGO_MANZANA", lista_manzana[0]);
                            }
                        }
                        else
                        {
                            detalles_usos_resaltantes.Close();
                            return;
                        }
                    }
                    else Auto_Cad_Map.imprimir("\nError: No existe la Capa Uso Resaltante.");
                }
            }
            catch (MgException ex)
            {
                Auto_Cad_Map.imprimir("\nError, Buscar Uso Resaltante: " + ex.Message);
            }
        }
        #endregion

        #region Metodos de Uso Resaltante
        void control_uso_resaltante()
        {
            habilitado = true;
            if (Ubigeo != "" || Ubigeo != null)
            {
                Auto_Cad_Map.agregar_capa("DEPARTAMENTO", string.Format("CODIGO_DEPARTAMENTO = '{0}'", Ubigeo.Substring(0, 2)), false, true);
                Auto_Cad_Map.agregar_capa("PROVINCIA", string.Format("CODIGO_PROVINCIA = '{0}'", Ubigeo.Substring(0, 4)), false, true);
                Auto_Cad_Map.agregar_capa("DISTRITO", string.Format("UBIGEO = '{0}'", Ubigeo), false, true);
                Auto_Cad_Map.agregar_capa("SECTOR", string.Format("UBIGEO = '{0}'", Ubigeo), false, true);
                Auto_Cad_Map.agregar_capa("MANZANA", string.Format("CODIGO_SECTOR LIKE ('{0}%')", Ubigeo), false, true);
                Auto_Cad_Map.agregar_capa("VIAS", string.Format("UBIGEO = '{0}'", Ubigeo), false, true);
                Auto_Cad_Map.agregar_capa("EQUIPAMIENTO_URBANO", string.Format("UBIGEO = '{0}'", Ubigeo), false, true);
                Auto_Cad_Map.agregar_capa("PUERTA", string.Format("UBIGEO = '{0}'", Ubigeo), false, true);
                Auto_Cad_Map.agregar_capa("TIPO_COMPONENTE_URBANO", string.Format("UBIGEO = '{0}'", Ubigeo), false, false);
                Auto_Cad_Map.agregar_capa("TIPO_MOBILIARIO_URBANO", string.Format("UBIGEO = '{0}'", Ubigeo), false, false);
                Auto_Cad_Map.agregar_capa("USO_RESALTANTE", string.Format("UBIGEO = '{0}'", Ubigeo), false, true);
            }
        }
        void agregar_uso_resaltante(MgGeometry geom)
        {
            try
            {
                Modulo_Usos_Resaltantes modulo_usos_resaltantes = new Modulo_Usos_Resaltantes();
                Uso_Resaltante uso_resaltante = new Uso_Resaltante();
                System.Windows.Forms.DialogResult rpta = Auto_Cad_Map.mostrar_dialogo(modulo_usos_resaltantes);
                string capa = modulo_usos_resaltantes.capa;
                if (rpta == System.Windows.Forms.DialogResult.OK)
                {
                    List<string> lista_manzana = Auto_Cad_Map.buscar("MANZANA", geom, "CODIGO_MANZANA");
                    List<string> lista_vias = Auto_Cad_Map.buscar("VIAS", geom, "CODIGO_VIA");
                    List<string> lista_cuadra = Auto_Cad_Map.buscar("VIAS", geom, "CUADRA");
                    List<string> lista_direccion = Auto_Cad_Map.buscar("VIAS", geom, "DIRECCION");
                    if (lista_manzana.Count > 0)
                    {
                        uso_resaltante.Capa = capa;
                        uso_resaltante.departamento_lbl.Text = Ubigeo.Substring(0, 2);
                        uso_resaltante.provincia_lbl.Text = Ubigeo.Substring(2, 2);
                        uso_resaltante.distrito_lbl.Text = Ubigeo.Substring(4, 2);
                        uso_resaltante.sector_lbl.Text = lista_manzana[0].Substring(6, 2);
                        uso_resaltante.codigoVia_manzana_txt.Text = (capa == "0") ? lista_vias[0] : lista_manzana[0].Substring(8, 3);
                        uso_resaltante.cuadra_lote_txt.Text = (capa == "0") ? lista_cuadra[0] : "";
                        uso_resaltante.direccion_txt.Text = lista_direccion[0];
                        uso_resaltante.puntoX_lbl.Text = geom.Centroid.Coordinate.X.ToString();
                        uso_resaltante.puntoY_lbl.Text = geom.Centroid.Coordinate.Y.ToString();
                        uso_resaltante.Usuario = usuario;
                        System.Windows.Forms.DialogResult rpta1 = Auto_Cad_Map.mostrar_dialogo(uso_resaltante);
                        if (rpta1 == System.Windows.Forms.DialogResult.OK)
                        {
                            string tipo_uso_resaltante = uso_resaltante.tipoUsoResaltante_txt.Text;
                            string clasificacion_uso_resaltante = uso_resaltante.clasificacionUsoResaltante_txt.Text;
                            if (Ubigeo != "" || Ubigeo != null)
                            {
                                string hash = "";
                                do
                                {
                                    hash = Guid.NewGuid().ToString().ToUpper();
                                    Auto_Cad_Map.imprimir(string.Format("\nHASH = {0}", hash));
                                } while (Auto_Cad_Map.buscar("USO_RESALTANTE", "HASH", hash, 'L'));
                                
                                geom = Auto_Cad_Map.interseccion_linea("MANZANA", geom, string.Format("CODIGO_MANZANA='{0}'", lista_manzana[0]));
                                if (geom != null)
                                {
                                    Auto_Cad_Map.agregar_elemento_capa("USO_RESALTANTE",
                                    new MgStringProperty("UBIGEO", Ubigeo),
                                    new MgStringProperty("SECTOR", uso_resaltante.sector_lbl.Text),
                                    new MgStringProperty("CODIGO_VIA_MANZANA", uso_resaltante.codigoVia_manzana_txt.Text),
                                    new MgStringProperty("CUADRA_LOTE", uso_resaltante.cuadra_lote_txt.Text),
                                    new MgStringProperty("DIRECCION", uso_resaltante.direccion_txt.Text),
                                    new MgStringProperty("AÑO", DateTime.Now.Year.ToString()),
                                    new MgStringProperty("TIPO_USO_RESALTANTE", tipo_uso_resaltante),
                                    new MgStringProperty("CLASIFICACION_USO_RESALTANTE", clasificacion_uso_resaltante),
                                    new MgStringProperty("ESPECIFICACIONES", uso_resaltante.especificaciones_txt.Text),
                                    new MgStringProperty("HASH", hash),
                                    new MgGeometryProperty("GEOM", new MgAgfReaderWriter().Write(geom)),
                                    new MgStringProperty("E", "A"),
                                    new MgStringProperty("USUARIO_CREA", usuario.ToUpper()),
                                    new MgStringProperty("USUARIO_MODIFICA", usuario.ToUpper()));
                                }
                            }
                            else Auto_Cad_Map.imprimir("\nError: no existe la capa Distrito");
                        }
                    }
                }
            }
            catch (MgException ex)
            {
                Auto_Cad_Map.imprimir("\nError, Agregar Uso Resaltante: " + ex.Message);
            }
        }        
        #endregion
        #endregion
    }
}
