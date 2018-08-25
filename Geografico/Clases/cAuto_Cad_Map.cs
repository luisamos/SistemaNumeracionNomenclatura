using System;
using System.Text;
using System.Xml;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using Componentes;
//AutoCAD API
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
//Map Platform API
using Autodesk.Gis.Map.Platform;
using Autodesk.Gis.Map.Platform.Interop;
//Geospatial Platform API
using OSGeo.MapGuide;

namespace Clases
{
    /// <summary>
    /// Clase Auto Cad Map 3D    
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>    
    internal class cAuto_Cad_Map
    {
        #region Atributos y Propiedades
        string ruta = "";

        //AutoCad Map 
        AcMapMap map = AcMapMap.GetCurrentMap();
        AcMapResourceService rs = AcMapServiceFactory.GetService(MgServiceType.ResourceService) as AcMapResourceService;
        AcMapFeatureService fs = (AcMapFeatureService)AcMapServiceFactory.GetService(MgServiceType.FeatureService) as AcMapFeatureService;        
        Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
        Database db = Application.DocumentManager.MdiActiveDocument.Database;        
        internal Editor Editor
        {
            get { return editor; }
            set { editor = value; }
        }

        internal AcMapFeatureService FS
        {
            get { return fs; }
            set { fs = value; }
        }

        internal Database DB
        {
            get { return db; }
            set { db = value; }
        }

        //Atributos - Eventos   
        static ResourceAddedHandler datos_EventHandler = null;
        static LayerAddedHandler capa_EventHandler = null;
        //Propiedades       
        string Ruta
        {
            get
            {
                if (string.IsNullOrEmpty(ruta))
                {
                    Assembly asm = Assembly.GetExecutingAssembly();
                    FileInfo info = new FileInfo(asm.Location);
                    ruta = info.DirectoryName;
                }
                return ruta;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Agrega un Evento
        /// </summary>
        internal void agregar_evento()
        {
            if (capa_EventHandler == null)
            {
                capa_EventHandler = new LayerAddedHandler(evento_capa_agregado);
                map.LayerAdded += capa_EventHandler;
            }
        }

        /// <summary>
        /// Elimina un Evento
        /// </summary>
        internal void eliminar_evento()
        {
            map = AcMapMap.GetCurrentMap();
            if (datos_EventHandler != null)
            {
                rs.ResourceAdded -= datos_EventHandler;
                datos_EventHandler = null;
            }

            if (capa_EventHandler != null)
            {
                map.LayerAdded -= capa_EventHandler;
                capa_EventHandler = null;
            }
        }

        /// <summary>
        /// Agrega el acceso a la base de datos
        /// </summary>
        /// <param name="nombre_capa">Nombre de la Capa</param>
        /// <returns>Reporta el Identificador de la Capa de acceso</returns> 
        internal string agregar_acceso(string nombre_capa)
        {
            string url_data = null;
            try
            {
                url_data = string.Format(@"Library://{0}.SqlServerSpatial.FeatureSource", nombre_capa);
                MgResourceIdentifier id = new MgResourceIdentifier(url_data);
                XmlDocument xml = new XmlDocument();                
                xml.Load(string.Format(@"{0}\Xml\ACCESO.xml", Ruta));
                XmlNodeList lista_nodos = xml.DocumentElement.SelectNodes("Parameter");
                lista_nodos = xml.DocumentElement.SelectNodes("Parameter");
                foreach (XmlNode nodo in lista_nodos)
                {
                    if (nodo.SelectSingleNode("Name").InnerText == "Password") nodo.SelectSingleNode("Value").InnerText = cConexion.Password;
                    else if (nodo.SelectSingleNode("Name").InnerText == "Service") nodo.SelectSingleNode("Value").InnerText = cConexion.Servidor_Base_Datos;
                    else if (nodo.SelectSingleNode("Name").InnerText == "Username") nodo.SelectSingleNode("Value").InnerText = cConexion.User;
                    else if (nodo.SelectSingleNode("Name").InnerText == "DataStore") nodo.SelectSingleNode("Value").InnerText = cConexion.BaseDatos;                    
                }                
                
                byte[] bytes = Encoding.Convert(Encoding.Unicode, Encoding.UTF8, Encoding.Unicode.GetBytes(xml.OuterXml));
                MgByteSource datos_bytes = new MgByteSource(bytes, bytes.Length);
                if (rs.ResourceExists(id)) rs.DeleteResource(id);
                rs.SetResource(id, datos_bytes.GetReader(),null);
                
            }
            catch (MgException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error:  agregar acceso datos. ", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return url_data;
        }

        /// <summary>
        /// Obtiene una capa Existente
        /// </summary>
        /// <param name="nombre_capa">Nombre de la capa</param>
        /// <returns>Layer Nombre de la Capa</returns>
        internal MgLayerBase obtener_capa(string nombre_capa)
        {
            MgLayerBase selecionar_capa = null;
            if (existe_capa(nombre_capa)) selecionar_capa = (MgLayerBase)map.GetLayers().GetItem(nombre_capa);
            return selecionar_capa;
        }

        /// <summary>
        /// Si existe la Capa especificada
        /// </summary>
        /// <param name="nombre_capa">Nombre de la capa</param>
        /// <returns>un valor boleano</returns>
        internal bool existe_capa(string nombre_capa)
        {
            return (map.GetLayers().IndexOf(nombre_capa) != -1);
        }

        /// <summary>
        /// Agrega una capa a mostrarse
        /// </summary>
        /// <param name="nombre_capa">Nombre de la capa</param>
        /// <param name="query">Filtro a cargar</param>
        /// <param name="eliminar_filtro">Si se elimina el campo filtro de la capa</param>
        /// <param name="editable">Si se puede editar la Capa especificada</param>
        internal void agregar_capa(string nombre_capa, string query, bool eliminar_filtro,bool editable)
        {
            try
            {                
                if (existe_capa(nombre_capa)) eliminar_capa(nombre_capa);
                string url_data = agregar_acceso(nombre_capa);
                string url_capa = string.Format(@"Library://{0}.SqlServerSpatial.LayerDefinition", nombre_capa);

                XmlDocument xml = new XmlDocument();
                xml.Load(string.Format(@"{0}\Xml\CAPA_{1}.xml", Ruta, nombre_capa));

                MgResourceIdentifier definicion_capa = new MgResourceIdentifier(url_capa);

                XmlNode id_recurso = xml.DocumentElement.SelectSingleNode("//ResourceId");
                id_recurso.InnerText = url_data;
                XmlNode buscar = xml.DocumentElement.SelectSingleNode("//Filter");
                buscar.InnerText = query;
                if (eliminar_filtro) buscar.RemoveAll();

                XmlNodeList archivo = xml.DocumentElement.SelectNodes("//DrawingName");
                foreach (XmlNode item in archivo)
                {
                    item.InnerText= string.Format(@"{0}\Dwg\{1}",Ruta,item.InnerText);
                }                 

                byte[] unicode_bytes = Encoding.Unicode.GetBytes(xml.OuterXml);
                byte[] bytes = Encoding.Convert(Encoding.Unicode, Encoding.UTF8, unicode_bytes);
                MgByteSource datos_bytes = new MgByteSource(bytes, bytes.Length);

                rs.SetResource(definicion_capa, datos_bytes.GetReader(), null);

                AcMapLayer capa = AcMapLayer.Create(definicion_capa, rs);
                capa.SetName(nombre_capa);
                map.GetLayers().Add(capa);
                capa.SetSelectable(editable);
                capa.ZoomToLayer();            
            }
            catch (MgException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error:  cargar capa " + nombre_capa + ". ", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Actualizar la Capa existente
        /// </summary>
        /// <param name="nombre_capa">Nombre de la capa</param>
        /// <param name="query">Consulta a establecer en la capa</param>
        /// <param name="comodin">El Comodin a enlazar</param>
        internal void actualizar_capa(string nombre_capa, string query,string comodin)
        {
            try
            {
                string url_data = string.Format(@"Library://{0}.SqlServerSpatial.FeatureSource", nombre_capa);
                string url_capa = string.Format(@"Library://{0}.SqlServerSpatial.LayerDefinition", nombre_capa);

                XmlDocument xml = new XmlDocument();
                xml.Load(string.Format(@"{0}\Xml\CAPA_{1}_{2}.xml", Ruta,comodin,nombre_capa));

                MgResourceIdentifier definicion_capa = new MgResourceIdentifier(url_capa);

                XmlNode id_recurso = xml.DocumentElement.SelectSingleNode("//ResourceId");
                id_recurso.InnerText = url_data;
                XmlNodeList buscar_lista = xml.DocumentElement.SelectNodes("//Filter");
                XmlNode buscar = buscar_lista.Item(1);
                buscar.InnerText = query;

                byte[] unicode_bytes = Encoding.Unicode.GetBytes(xml.OuterXml);
                byte[] bytes = Encoding.Convert(Encoding.Unicode, Encoding.UTF8, unicode_bytes);
                MgByteSource datos_bytes = new MgByteSource(bytes, bytes.Length);

                rs.SetResource(definicion_capa, datos_bytes.GetReader(), null);

                MgLayerBase selecionar_capa = (MgLayerBase)map.GetLayers().GetItem(nombre_capa);
                selecionar_capa.SetLayerDefinition(definicion_capa, rs);
            }
            catch (MgException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error:  cargar capa " + nombre_capa + ". ", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Actualizar la Capa existente
        /// </summary>
        /// <param name="nombre_capa">Nombre de la capa</param>        
        /// <param name="comodin">El Comodin a enlazar</param>
        internal void actualizar_capa(string nombre_capa,string comodin)
        {
            try
            {
                string url_data = string.Format(@"Library://{0}.SqlServerSpatial.FeatureSource", nombre_capa);
                string url_capa = string.Format(@"Library://{0}.SqlServerSpatial.LayerDefinition", nombre_capa);

                XmlDocument xml = new XmlDocument();
                xml.Load(string.Format(@"{0}\Xml\CAPA_{1}_{2}.xml", Ruta, comodin, nombre_capa));

                MgResourceIdentifier definicion_capa = new MgResourceIdentifier(url_capa);

                XmlNode id_recurso = xml.DocumentElement.SelectSingleNode("//ResourceId");
                id_recurso.InnerText = url_data;               

                byte[] unicode_bytes = Encoding.Unicode.GetBytes(xml.OuterXml);
                byte[] bytes = Encoding.Convert(Encoding.Unicode, Encoding.UTF8, unicode_bytes);
                MgByteSource datos_bytes = new MgByteSource(bytes, bytes.Length);

                rs.SetResource(definicion_capa, datos_bytes.GetReader(), null);

                MgLayerBase selecionar_capa = (MgLayerBase)map.GetLayers().GetItem(nombre_capa);
                selecionar_capa.SetLayerDefinition(definicion_capa, rs);
            }
            catch (MgException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error:  cargar capa " + nombre_capa + ". ", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }       

        /// <summary>
        /// Elimina una capa existe
        /// </summary>
        /// <param name="nombre_capa">Nombre de la capa</param>
        internal void eliminar_capa(string nombre_capa)
        {
            try
            {
                MgResourceIdentifier id = new MgResourceIdentifier(string.Format(@"Library://{0}.SqlServerSpatial.FeatureSource", nombre_capa));
                if (rs.ResourceExists(id))
                {
                    MgLayerCollection capas = map.GetLayers();
                    capas.Remove(obtener_capa(nombre_capa));
                    rs.DeleteResource(id);
                    capas.Clear();
                }
            }
            catch (MgException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error:  eliminar capa. ", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Se acerca a un fila especificada
        /// </summary>
        /// <param name="nombre_capa">Nombre de la capa.</param>
        /// <param name="columna">Nombre de la columna</param>
        /// <param name="valor">Valor de la columna a optener</param>
        internal void ir(string nombre_capa, string columna, string valor)
        {
            MgFeatureQueryOptions buscar = new MgFeatureQueryOptions();
            if (columna == "ID") buscar.SetFilter(string.Format("{0} = {1}", columna, valor));
            else buscar.SetFilter(string.Format("{0} = '{1}'", columna, valor));

            AcMapLayer capa = (AcMapLayer)map.GetLayers().GetItem(nombre_capa);
            MgFeatureReader fr = capa.SelectFeatures(buscar);
            MgSelectionBase seleccion_base = new MgSelectionBase(map);
            while (fr.ReadNext())
            {
                MgByteReader leer_byte = fr.GetGeometry(capa.GetFeatureGeometryName());
                MgAgfReaderWriter leer_escribir = new MgAgfReaderWriter();
                MgGeometry geom = leer_escribir.Read(leer_byte);                
                map.ZoomToExtent(geom.Envelope());
            }
            seleccion_base.AddFeatures(capa, fr, 0);
            AcMapFeatureEntityService.HighlightFeatures(seleccion_base);
            editor.UpdateScreen();
        }

        /// <summary>
        /// Busca un Elemento especificado
        /// </summary>
        /// <param name="nombre_capa">Nombre de la capa</param>        
        /// <param name="nombre_columna">Columna a devolver en la intersección</param>  
        /// <param name="valor">El valor a buscar</param>
        /// <param name="tipo">El tipo de Columna a buscar | N: Numerico , L: Letra, F: Fecha</param>
        /// <returns>Si existe o no</returns>
        internal bool buscar(string nombre_capa,string nombre_columna,string valor,char tipo)
        {
            bool rpta = false;
            object elemento="";
            if (existe_capa(nombre_capa))
            {                
                 MgLayerBase capa_vias = (MgLayerBase)obtener_capa(nombre_capa);
                 if (capa_vias != null)
                 {
                     MgFeatureReader fr = capa_vias.SelectFeatures(new MgFeatureQueryOptions());

                     while (fr.ReadNext())
                     {
                         switch (tipo)
                         {
                             case 'N':
                                 elemento = fr.GetInt32(nombre_columna);
                                 break;
                             case 'L':
                                 elemento = fr.GetString(nombre_columna);
                                 break;
                             case 'F':
                                 elemento = fr.GetDateTime(nombre_columna);
                                 break;
                         }
                         if (valor.Equals(elemento)) rpta = true;
                         else rpta = false;
                     }
                     fr.Close();
                 }
            }
            else imprimir("\nError: no existe la capa " + nombre_capa + ". ");
            return rpta;
        }

        /// <summary>
        /// Busca un Elemento especificado
        /// </summary>
        /// <param name="nombre_capa">Nombre de la capa</param>
        /// <param name="geometrico">Geometrica a intersectar</param>
        /// <param name="nombre_columna">Columna a devolver en la intersección</param>        
        /// <returns>un Conjunto de datos</returns>
        internal List<string> buscar(string nombre_capa, MgGeometry geometrico, string nombre_columna)
        {
            List<string> lista = new List<string>();
            if (existe_capa(nombre_capa))
            {
                MgLayerBase selecionar_capa = (MgLayerBase)map.GetLayers().GetItem(nombre_capa);
                MgFeatureReader fr = selecionar_capa.SelectFeatures(new MgFeatureQueryOptions());
                while (fr.ReadNext())
                {
                    MgByteReader leer_byte = fr.GetGeometry(selecionar_capa.GetFeatureGeometryName());
                    MgGeometry geom = (new MgAgfReaderWriter()).Read(leer_byte);
                    if (geom.Intersects(geometrico))
                    {
                        if (nombre_columna == "ID") lista.Add(fr.GetInt32(nombre_columna).ToString());
                        else lista.Add(fr.GetString(nombre_columna));
                    }
                }
                fr.Close();
            }
            else imprimir("\nError: no existe la capa " + nombre_capa +". ");
            return lista;
        }       

        /// <summary>
        /// Busca un Elemento especificado
        /// </summary>
        /// <param name="nombre_capa">Nombre de la capa</param>
        /// <param name="geometrico">Geometrica a intersectar</param>
        /// <param name="nombre_columna">Columna a devolver en la intersección</param>
        /// <param name="query">Filtro a buscar</param>
        /// <returns>un Conjunto de datos</returns>
        internal List<string> buscar(string nombre_capa, MgGeometry geometrico, string nombre_columna,string query)
        {
            List<string> lista = new List<string>();
            if (existe_capa(nombre_capa))
            {
                MgLayerBase selecionar_capa = (MgLayerBase)map.GetLayers().GetItem(nombre_capa);
                MgFeatureQueryOptions consulta = new MgFeatureQueryOptions();
                consulta.SetFilter(query);                
                MgFeatureReader fr = selecionar_capa.SelectFeatures(consulta);
                while (fr.ReadNext())
                {
                    MgByteReader leer_byte = fr.GetGeometry(selecionar_capa.GetFeatureGeometryName());
                    MgGeometry geom = (new MgAgfReaderWriter()).Read(leer_byte);
                    if (geom.Intersects(geometrico))
                    {
                        if (nombre_columna == "ID") lista.Add(fr.GetInt32(nombre_columna).ToString());
                        else lista.Add(fr.GetString(nombre_columna));
                    }
                }
                fr.Close();
            }
            else imprimir("\nError: no existe la capa " + nombre_capa + ". ");
            return lista;
        }

        /// <summary>
        /// Busca un Elemento especificado
        /// </summary>
        /// <param name="nombre_capa">Nombre de la capa</param>
        /// <param name="geometrico">Geometrica a intersectar</param>
        /// <returns>un Conjunto de datos</returns>
        internal List<string> buscar_coordenadas(string nombre_capa, MgGeometry geometrico)
        {
            List<string> lista = new List<string>();
            if (existe_capa(nombre_capa))
            {
                MgLayerBase selecionar_capa = (MgLayerBase)map.GetLayers().GetItem(nombre_capa);                
                MgFeatureReader fr = selecionar_capa.SelectFeatures(new MgFeatureQueryOptions());
                while (fr.ReadNext())
                {
                    MgByteReader leer_byte = fr.GetGeometry(selecionar_capa.GetFeatureGeometryName());
                    MgGeometry geom = (new MgAgfReaderWriter()).Read(leer_byte);
                    if (geom.Intersects(geometrico))
                    {
                        if (geom is MgLineString)
                        {
                            MgLineString linea = (MgLineString)geom;
                            lista.Add(linea.StartCoordinate.X.ToString());
                            lista.Add(linea.StartCoordinate.Y.ToString());
                            lista.Add(linea.EndCoordinate.X.ToString());
                            lista.Add(linea.EndCoordinate.Y.ToString());
                        }
                        if (geom is MgPoint)
                        {
                            MgPoint p = (MgPoint)geom;
                            lista.Add(p.Coordinate.X.ToString());
                            lista.Add(p.Coordinate.Y.ToString());
                        }
                    }
                }
                fr.Close();
            }
            else imprimir("\nError: no existe la capa " + nombre_capa + ". ");
            return lista;
        }

        /// <summary>
        /// Busca un Elemento especificado
        /// </summary>
        /// <param name="nombre_capa">Nombre de la capa</param>
        /// <param name="geometrico">Geometrica a intersectar</param>        
        /// <param name="query">Filtro a buscar</param>
        /// <returns>un Conjunto de datos</returns>
        internal List<string> buscar_coordenadas(string nombre_capa, MgGeometry geometrico, string query)
        {            
            List<string> lista = new List<string>();
            if (existe_capa(nombre_capa))
            {
                MgLayerBase selecionar_capa = (MgLayerBase)map.GetLayers().GetItem(nombre_capa);
                MgFeatureQueryOptions consulta = new MgFeatureQueryOptions();
                consulta.SetFilter(query);
                MgFeatureReader fr = selecionar_capa.SelectFeatures(consulta);
                while (fr.ReadNext())
                {
                    MgByteReader leer_byte = fr.GetGeometry(selecionar_capa.GetFeatureGeometryName());
                    MgGeometry geom = (new MgAgfReaderWriter()).Read(leer_byte);
                    if (geom.Intersects(geometrico))
                    {
                        if (geom is MgLineString)
                        {
                            MgLineString linea = (MgLineString)geom;
                            lista.Add(linea.StartCoordinate.X.ToString());
                            lista.Add(linea.StartCoordinate.Y.ToString());
                            lista.Add(linea.EndCoordinate.X.ToString());
                            lista.Add(linea.EndCoordinate.Y.ToString());
                        }
                        if (geom is MgPoint)
                        {
                            MgPoint p = (MgPoint)geom;
                            lista.Add(p.Coordinate.X.ToString());
                            lista.Add(p.Coordinate.Y.ToString());
                        }
                    }
                }
                fr.Close();
            }
            else imprimir("\nError: no existe la capa " + nombre_capa + ". ");
            return lista;
        }

        /// <summary>
        /// Busca un Elemento especificado
        /// </summary>
        /// <param name="nombre_capa">Nombre de la capa</param>              
        /// <param name="query">Filtro a buscar</param>
        /// <returns>un Conjunto de datos</returns>
        internal List<string> buscar_coordenadas(string nombre_capa, string query)
        {
            List<string> lista = new List<string>();
            if (existe_capa(nombre_capa))
            {
                MgLayerBase selecionar_capa = (MgLayerBase)map.GetLayers().GetItem(nombre_capa);
                MgFeatureQueryOptions consulta = new MgFeatureQueryOptions();
                consulta.SetFilter(query);
                MgFeatureReader fr = selecionar_capa.SelectFeatures(consulta);
                while (fr.ReadNext())
                {
                    MgByteReader leer_byte = fr.GetGeometry(selecionar_capa.GetFeatureGeometryName());
                    MgGeometry geom = (new MgAgfReaderWriter()).Read(leer_byte);
                    if (geom is MgLineString)
                    {
                        MgLineString linea = (MgLineString)geom;
                        lista.Add(linea.StartCoordinate.X.ToString());
                        lista.Add(linea.StartCoordinate.Y.ToString());
                        lista.Add(linea.EndCoordinate.X.ToString());
                        lista.Add(linea.EndCoordinate.Y.ToString());
                    }
                }                
                fr.Close();
            }
            else imprimir("\nError: no existe la capa " + nombre_capa + ". ");
            return lista;
        }

        /// <summary>
        /// Busca un Elemento especificado
        /// </summary>
        /// <param name="nombre_capa">Nombre de la Capa</param>
        /// <param name="query">Filtro a buscar</param>
        /// <returns>Un campo Geometrico</returns>
        internal MgGeometry buscar_geometrico(string nombre_capa,string query)
        {
            MgGeometry geom= null;
            if (existe_capa(nombre_capa))
            {
                MgLayerBase selecionar_capa = (MgLayerBase)map.GetLayers().GetItem(nombre_capa);
                MgFeatureQueryOptions consulta = new MgFeatureQueryOptions();
                consulta.SetFilter(query);
                MgFeatureReader fr = selecionar_capa.SelectFeatures(consulta);
                while (fr.ReadNext())
                {
                    MgByteReader leer_byte = fr.GetGeometry(selecionar_capa.GetFeatureGeometryName());
                    geom = (new MgAgfReaderWriter()).Read(leer_byte);
                    break;
                }                
                fr.Close();
            }
            else imprimir("\nError: no existe la capa " + nombre_capa + ". ");
            return geom;
        }
        
        /// <summary>
        /// Calcula la Distancia de una Polilinea y/o Linea especificada
        /// </summary>
        /// <param name="nombre_capa">Nombre de la Capa</param>
        /// <param name="linea_puerta">Campo Geometrico Lineal, puerta </param>
        /// <param name="cuadra">Cuadra mencionada</param>        
        /// <param name="query">Filtro a Buscar</param>
        /// <param name="punto_puerta">Campo Geométrico Punto, puerta</param>
        /// <param name="coordenadas">Coordenadas del eje de Via de la Ficha Catastral de Vías Urbanas</param>
        /// <param name="lado">El lado de Numeración que pertenece : Derecha - Izquierda</param>
        /// <returns>Un número decimal</returns>
        internal string distancia(string nombre_capa, MgGeometry linea_puerta,string cuadra,string query,MgGeometry punto_puerta,double[,] coordenadas,out char lado)
        {             
            double distancia = 0;
            lado = 'A';
            if (existe_capa(nombre_capa))
            {
                MgLayerBase selecionar_capa = (MgLayerBase)map.GetLayers().GetItem(nombre_capa);
                MgFeatureQueryOptions consulta= new MgFeatureQueryOptions();
                consulta.SetFilter(query);
                MgFeatureReader fr = selecionar_capa.SelectFeatures(consulta);
                while (fr.ReadNext())
                {
                    MgByteReader leer_byte = fr.GetGeometry(selecionar_capa.GetFeatureGeometryName());
                    MgGeometry geom = (new MgAgfReaderWriter()).Read(leer_byte);
                    if (geom.Intersects(linea_puerta))
                    {
                        MgPoint punto_interseccion_via_puerta = geom.Intersection(linea_puerta).Centroid;

                        imprimir(string.Format("\nPunto Intersección Eje de Vía - Puerta: X = {0} , Y={1}\n", punto_interseccion_via_puerta.Coordinate.X, punto_interseccion_via_puerta.Coordinate.Y));
                        imprimir(string.Format("\nPunto Inicial: X = {0} , Y={1}\n", coordenadas[0, 0], coordenadas[0, 1]));
                        imprimir(string.Format("\nPunto Final: X = {0} , Y={1}\n", coordenadas[1, 0], coordenadas[1, 1]));

                        MgPoint punto = punto_puerta.Centroid;
                        double x_final, x_inicial, y_final, y_inicial, x_interseccion, y_interseccion, dX, dY;
                        bool sentido = false;
                        x_inicial = coordenadas[0, 0];
                        y_inicial = coordenadas[0, 1];
                        x_final = coordenadas[1, 0];
                        y_final = coordenadas[1, 1];
                        x_interseccion = punto_interseccion_via_puerta.Coordinate.X;
                        y_interseccion = punto_interseccion_via_puerta.Coordinate.Y;

                        if (x_final > x_inicial && y_final > y_inicial )
                        {
                            sentido = true;
                            if (x_interseccion > punto.Coordinate.X && y_interseccion < punto.Coordinate.Y) lado = 'I';
                            else if (x_interseccion < punto.Coordinate.X && y_interseccion > punto.Coordinate.Y) lado = 'D';
                            imprimir("\nCondicion 1");
                        }
                        else if (x_final < x_inicial && y_final < y_inicial)
                        {
                            sentido = false;
                            if (x_interseccion > punto.Coordinate.X && y_interseccion < punto.Coordinate.Y) lado = 'D';
                            else if (x_interseccion < punto.Coordinate.X && y_interseccion > punto.Coordinate.Y) lado = 'I';
                            imprimir("\nCondicion 2");
                        }
                        else if (x_final == x_inicial && y_final > y_inicial )
                        {
                            sentido = true;
                            if (x_interseccion > punto.Coordinate.X && y_interseccion == punto.Coordinate.Y) lado = 'I';
                            else if (x_interseccion < punto.Coordinate.X && y_interseccion == punto.Coordinate.Y) lado = 'D';
                            imprimir("\nCondicion 3");
                        }
                        else if (x_final == x_inicial && y_final < y_inicial)
                        {
                            sentido = false;
                            if (x_interseccion > punto.Coordinate.X && y_interseccion == punto.Coordinate.Y) lado = 'D';
                            else if (x_interseccion < punto.Coordinate.X && y_interseccion == punto.Coordinate.Y) lado = 'I';
                            imprimir("\nCondicion 4");
                        }
                        else if (x_final > x_inicial && y_final == y_inicial)
                        {
                            sentido = true;
                            if (x_interseccion == punto.Coordinate.X && y_interseccion < punto.Coordinate.Y) lado = 'I';
                            else if (x_interseccion == punto.Coordinate.X && y_interseccion > punto.Coordinate.Y) lado = 'D';
                            imprimir("\nCondicion 5");
                        }
                        else if (x_final < x_inicial && y_final == y_inicial)
                        {
                            sentido = false;
                            if (x_interseccion == punto.Coordinate.X && y_interseccion < punto.Coordinate.Y) lado = 'D';
                            else if (x_interseccion == punto.Coordinate.X && y_interseccion > punto.Coordinate.Y) lado = 'I';
                            imprimir("\nCondicion 6");
                        }
                        else if (x_final > x_inicial && y_final < y_inicial)
                        {
                            sentido = true;
                            if (x_interseccion < punto.Coordinate.X && y_interseccion < punto.Coordinate.Y) lado = 'I';
                            else if (x_interseccion > punto.Coordinate.X && y_interseccion > punto.Coordinate.Y) lado = 'D';
                            imprimir("\nCondicion 7");
                        }
                        else if (x_final < x_inicial && y_final > y_inicial)
                        {
                            sentido = false;
                            if (x_interseccion < punto.Coordinate.X && y_interseccion < punto.Coordinate.Y) lado = 'D';
                            else if (x_interseccion > punto.Coordinate.X && y_interseccion > punto.Coordinate.Y) lado = 'I';
                            imprimir("\nCondicion 8");
                        }

                        if (sentido)
                        {
                            dX = (x_inicial - punto_interseccion_via_puerta.Coordinate.X);
                            dY = (y_inicial - punto_interseccion_via_puerta.Coordinate.Y);
                        }
                        else
                        {
                            dX = (x_final - punto_interseccion_via_puerta.Coordinate.X);
                            dY = (y_final - punto_interseccion_via_puerta.Coordinate.Y);
                        }
                        
                        distancia = Math.Sqrt((dX * dX) + (dY * dY));
                        distancia = Math.Round(distancia + (int.Parse(cuadra) * 100), 0);
                        if (lado == 'D') distancia = (distancia % 2 == 0) ? distancia : distancia + 1;
                        else if (lado == 'I') distancia = (distancia % 2 == 0) ? distancia + 1 : distancia;
                    }
                }
                fr.Close();                
            }
            else imprimir("\nError: no existe la capa " + nombre_capa + ". ");            
            return distancia.ToString();

        }    

        /// <summary>
        /// Intersecta 2 capas especificadas
        /// </summary>
        /// <param name="nombre_capa">Nombre de la Capa</param>
        /// <param name="geometrico">Campo Geometrico a intersectarse</param>
        /// <param name="query">Filtro a buscar</param>
        /// <returns>Retorna un Objeto Geometrico Punto</returns>
        internal MgGeometry interseccion_punto(string nombre_capa, MgGeometry geometrico, string query)
        {
            MgGeometry punto = null;
            if (existe_capa(nombre_capa))
            {
                MgLayerBase selecionar_capa = (MgLayerBase)map.GetLayers().GetItem(nombre_capa);
                MgFeatureQueryOptions consulta = new MgFeatureQueryOptions();
                consulta.SetFilter(query);
                MgFeatureReader fr = selecionar_capa.SelectFeatures(consulta);
                while (fr.ReadNext())
                {
                    MgByteReader leer_byte = fr.GetGeometry(selecionar_capa.GetFeatureGeometryName());
                    MgGeometry geom = (new MgAgfReaderWriter()).Read(leer_byte);
                    List<double> lista_puntos = new List<double>();
                    MgLineString ll = (MgLineString)geometrico;

                    lista_puntos.Add(ll.StartCoordinate.X);
                    lista_puntos.Add(ll.EndCoordinate.X);                    
                    if (geom.Intersects(geometrico))
                    {
                        MgLineString l = (MgLineString)geom.Intersection(geometrico);
                        double[,] coordenadas = new double[,] { { 0, 0 } };
                        double x1, x2;
                        x1 = l.StartCoordinate.X;
                        x2 = l.EndCoordinate.X;

                        if (!lista_puntos.Exists(a => a == x1))
                        {
                            coordenadas[0, 0] = l.StartCoordinate.X;
                            coordenadas[0, 1] = l.StartCoordinate.Y;

                        }
                        else if (!lista_puntos.Exists(b => b == x2))
                        {
                            coordenadas[0, 0] = l.EndCoordinate.X;
                            coordenadas[0, 1] = l.EndCoordinate.Y;
                        }
                        imprimir(string.Format("Punto Intersección: X = {0} , Y={1}\n", coordenadas[0, 0], coordenadas[0, 1]));
                        punto = crear_geometria_punto(coordenadas);
                    }
                }
                fr.Close();
            }
            else imprimir("\nError: no existe la capa " + nombre_capa + ". ");
            return punto;
        }

        /// <summary>
        /// Intersecta 2 capas especificadas
        /// </summary>
        /// <param name="nombre_capa">Nombre de la Capa</param>
        /// <param name="geometrico">Campo Geometrico a intersectarse</param>
        /// <param name="query">Filtro a buscar</param>
        /// <returns>Retorna un Objeto Geometrico Linea</returns>
        internal MgGeometry interseccion_linea(string nombre_capa, MgGeometry geometrico, string query)
        {
            MgGeometry l = null;
            if (existe_capa(nombre_capa))
            {
                MgLayerBase selecionar_capa = (MgLayerBase)map.GetLayers().GetItem(nombre_capa);
                MgFeatureQueryOptions consulta = new MgFeatureQueryOptions();
                consulta.SetFilter(query);
                MgFeatureReader fr = selecionar_capa.SelectFeatures(consulta);
                while (fr.ReadNext())
                {
                    MgByteReader leer_byte = fr.GetGeometry(selecionar_capa.GetFeatureGeometryName());
                    MgGeometry geom = (new MgAgfReaderWriter()).Read(leer_byte);
                    if (geom.Intersects(geometrico))
                    {
                        l = (MgLineString)geom.Intersection(geometrico);                        
                    }
                }
                fr.Close();
            }
            else imprimir("\nError: no existe la capa " + nombre_capa + ". ");
            return l;
        }

        /// <summary>
        /// Obtiene las coordenadas del Poligono especificado
        /// </summary>
        /// <param name="entidad">Entidad del objeto Poligono</param>
        /// <param name="estado">variable de salida del estado del poligono</param>
        /// <returns>Retonar el conjunto de coordenadas del Poligono</returns>
        internal double[,] entidad_geometrica_poligono(ObjectId entidad, out bool estado)
        {
            double[,] coordenadas = null;
            estado = false;
            int dimension;
            bool se_cierra = false;
            try
            {
                int nro_vertices = 0;                
                Autodesk.AutoCAD.DatabaseServices.TransactionManager transaccion = db.TransactionManager;
                using (Transaction t = transaccion.StartTransaction())
                {
                    Entity e = (Entity)transaccion.GetObject(entidad, OpenMode.ForWrite, false);
                    Polyline poli_linea = e as Polyline;                    
                    if (poli_linea == null)
                    {
                        imprimir("\nUsted no ha seleccionado una poli línea. ");
                        return null;
                    }
                    else
                    {
                        nro_vertices = poli_linea.NumberOfVertices;
                        if (nro_vertices < 3)
                        {
                            imprimir("\nLa Poli línea  debe tener al menos 2 lados. ");
                            t.Abort();
                            return null;
                        }

                        if (poli_linea.GetPoint2dAt(0).IsEqualTo(poli_linea.GetPoint2dAt(nro_vertices - 1)))
                        {
                            dimension = nro_vertices;
                            se_cierra = true;
                            coordenadas = new double[nro_vertices, 2];
                        }
                        else
                        {
                            imprimir("\nLa Poli Línea no esta cerrada. Se cerrará de forma automática. ");
                            coordenadas = new double[nro_vertices + 1, 2];
                        }
                        for (int i = 0; i < nro_vertices; i++)
                        {
                            Point2d punto = poli_linea.GetPoint2dAt(i);
                            coordenadas[i, 0] = punto.X;
                            coordenadas[i, 1] = punto.Y;
                            imprimir(string.Format( "\n X{0}= {1} , Y{0}={2}", i, punto.X, punto.Y));
                        }
                        imprimir("\n");
                        if (!se_cierra)
                        {
                            coordenadas[nro_vertices, 0] = coordenadas[0, 0];
                            coordenadas[nro_vertices, 1] = coordenadas[0, 1];
                        }
                        estado = true;
                        poli_linea.Erase();
                        editor.UpdateScreen();
                        t.Commit();
                    }
                }
            }
            catch (System.Exception ex)
            {
                imprimir("\n" + ex.Message);
            }
            return coordenadas;
        }       

        /// <summary>
        /// Obtiene las coordenadas del Polilinea especificado
        /// </summary>
        /// <param name="entidad">Entidad del objeto polilinea</param>        
        /// <returns>Retonar el conjunto de coordenadas de la Polilinea</returns>
        internal double[,] entidad_geometrica_polilinea(ObjectId entidad)
        {
            double[,] coordenadas = new double[,] { { 0, 0 }, { 0, 0 } };
            try
            {
                int nro_vertices = 0;                
                Autodesk.AutoCAD.DatabaseServices.TransactionManager transaccion = db.TransactionManager;
                using (Transaction t = transaccion.StartTransaction())
                {
                    Entity e = (Entity)transaccion.GetObject(entidad, OpenMode.ForWrite, false);
                    Line linea = null;
                    Polyline poli_linea = null;

                    if (e is Line)
                    {
                        linea = e as Line;

                        Point3d p0 = linea.StartPoint;
                        Point3d p1 = linea.EndPoint;
                        double dX = (p1.X - p0.X);
                        double dY = (p1.Y - p0.Y);
                        double distancia = Math.Sqrt((dX * dX) + (dY * dY));

                        coordenadas[0, 0] = p0.X;
                        coordenadas[0, 1] = p0.Y;
                        imprimir(string.Format("\n X= {0} , Y={1}", p0.X, p0.Y));
                        coordenadas[1, 0] = p1.X;
                        coordenadas[1, 1] = p1.Y;
                        imprimir(string.Format("\n X= {0} , Y={1}", p1.X, p1.Y));

                        imprimir(string.Format("\n DX= {0} , DY= {1}", dX, dY));

                        imprimir(string.Format("\n Distancia = {0}", distancia));
                        imprimir("\n");
                        linea.Erase();
                        editor.UpdateScreen();
                        t.Commit();
                    }
                    else if (e is Polyline)
                    {
                        poli_linea = e as Polyline;

                        nro_vertices = poli_linea.NumberOfVertices;
                        coordenadas = new double[nro_vertices, 2];
                        for (int i = 0; i < nro_vertices; i++)
                        {
                            Point2d punto = poli_linea.GetPoint2dAt(i);
                            coordenadas[i, 0] = punto.X;
                            coordenadas[i, 1] = punto.Y;
                            imprimir(string.Format( "\n X{0}= {1} , Y{0}={2}", i, punto.X, punto.Y));
                        }

                        poli_linea.Erase();
                        editor.UpdateScreen();
                        t.Commit();
                    }

                    if (linea == null && poli_linea == null)
                    {
                        imprimir("\nUsted no ha seleccionado una línea y/o Poli línea. ");
                        return null;
                    }
                }
            }
            catch (System.Exception ex)
            {
                imprimir("\n" + ex.Message);
                return null;
            }
            return coordenadas;
        }

        /// <summary>
        /// Obtiene las coordenadas del punto especificado
        /// </summary>
        /// <param name="entidad">Entidad del objeto punto</param>
        /// <returns>Retorna el conjunto de coordenadas del Punto</returns>
        internal double[,] entidad_geometrica_punto(ObjectId entidad)
        {
            double[,] coordenadas = new double[,] { { 0, 0 } };
            try
            {                
                Autodesk.AutoCAD.DatabaseServices.TransactionManager transaccion = db.TransactionManager;
                using (Transaction t = transaccion.StartTransaction())
                {
                    Entity e = (Entity)transaccion.GetObject(entidad, OpenMode.ForWrite, false);
                    DBPoint p = e as DBPoint;
                    Point2d punto = new Point2d(p.Position.X, p.Position.Y);
                    if (punto == null)
                    {
                        imprimir("\nUsted no ha seleccionado una Punto");
                        return null;
                    }

                    coordenadas[0, 0] = punto.X;
                    coordenadas[0, 1] = punto.Y;
                    imprimir(string.Format("\n X= {0} , Y={1}\n", punto.X, punto.Y));
                    imprimir("\n");
                    p.Erase();
                    editor.UpdateScreen();
                    t.Commit();
                    return coordenadas;
                }
            }
            catch (System.Exception ex)
            {
                imprimir("\n" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Obtiene las coordenadas del Block de Reference
        /// </summary>
        /// <param name="entidad">Entidad del objeto Block Reference</param>
        /// <returns>Retorna el conjunto de coordenadas del Block Reference</returns>
        internal double[,] entidad_geometrica_block_referencia(ObjectId entidad)
        {
            double[,] coordenadas = new double[,] { { 0, 0 }, { 0, 0 } };
            try
            {                
                Autodesk.AutoCAD.DatabaseServices.TransactionManager transaccion = db.TransactionManager;
                using (Transaction t = transaccion.StartTransaction())
                {
                    Entity e = (Entity)transaccion.GetObject(entidad, OpenMode.ForWrite, false);
                    BlockReference br = e as BlockReference;
                    Point2d punto = new Point2d(br.Position.X,br.Position.Y);
                    if (punto == null)
                    {
                        imprimir("\nUsted no ha seleccionado una Punto");
                        return null;
                    }

                    coordenadas[0, 0] = punto.X;
                    coordenadas[0, 1] = punto.Y;
                    imprimir(string.Format("\n X= {0} , Y={1}\n", punto.X, punto.Y));
                    imprimir("\n");
                    br.Erase();
                    editor.UpdateScreen();
                    t.Commit();
                    return coordenadas;
                }
            }
            catch (System.Exception ex)
            {
                imprimir("\n" + ex.Message);
                return null;
            }        
        }

        /// <summary>
        /// Crea la geometrica del Poligono
        /// </summary>
        /// <param name="coordenadas">Coordenadas del Poligono</param>
        /// <returns>Retorna el objecto Poligono</returns>
        internal MgGeometry crear_geometria_poligono(double[,] coordenadas)
        {
            MgGeometryFactory geomFactory = new MgGeometryFactory();

            int u = coordenadas.GetUpperBound(0);
            int l = coordenadas.GetLowerBound(0);

            MgCoordinate punto = null;
            MgCoordinateCollection lista_puntos = new MgCoordinateCollection();

            for (int j = 0; j <= u; j++)
            {
                punto = geomFactory.CreateCoordinateXY(coordenadas[j, 0], coordenadas[j, 1]);
                lista_puntos.Add(punto);
            }
            MgLinearRing linea = geomFactory.CreateLinearRing(lista_puntos);
            MgGeometry poligono = geomFactory.CreatePolygon(linea, null);
            return poligono;
        }

        /// <summary>
        /// Crea la geometrica del Poli linea
        /// </summary>
        /// <param name="coordenadas">Coordenadas del Poli linea</param>
        /// <returns>Retorna el objecto Poli linea</returns>
        internal MgGeometry crear_geometria_linea(double[,] coordenadas)
        {
            MgGeometryFactory geomFactory = new MgGeometryFactory();
            int u = coordenadas.GetUpperBound(0);
            int l = coordenadas.GetLowerBound(0);
            MgCoordinate puntos = null;
            MgCoordinateCollection lista_puntos = new MgCoordinateCollection();

            for (int j = 0; j <= u; j++)
            {
                puntos = geomFactory.CreateCoordinateXY(coordenadas[j, 0], coordenadas[j, 1]);
                lista_puntos.Add(puntos);
            }
            MgLineString linea = geomFactory.CreateLineString(lista_puntos);
            return linea;
        }

        /// <summary>
        /// Crea la geometrica del Punto
        /// </summary>
        /// <param name="coordenadas">Coordenadas del Punto</param>
        /// <returns>Retorna el objecto Punto</returns>
        internal MgGeometry crear_geometria_punto(double[,] coordenadas)
        {
            MgGeometryFactory geomFactory = new MgGeometryFactory();
            MgCoordinate c = geomFactory.CreateCoordinateXY(coordenadas[0, 0], coordenadas[0, 1]);
            MgPoint punto = geomFactory.CreatePoint(c);
            return punto;
        }

        /// <summary>
        /// Inserta un registro en la capa Especificada
        /// </summary>
        /// <param name="nombre_capa">Nombre de la capa</param>        
        /// <param name="propiedades">Arreglo de Atributos</param>
        internal void agregar_elemento_capa(string nombre_capa, params MgProperty[] propiedades)
        {
            AcMapLayer capa = (AcMapLayer)obtener_capa(nombre_capa);
            if (capa != null)
            {
                MgPropertyCollection coleccion_propiedades = new MgPropertyCollection();
                foreach (MgProperty item in propiedades)
                {
                    coleccion_propiedades.Add(item);
                }
                MgFeatureCommandCollection comando = new MgFeatureCommandCollection();
                comando.Add(new MgInsertFeatures(string.Format("dbo:{0}",nombre_capa), coleccion_propiedades));
                MgResourceIdentifier resource_id = new MgResourceIdentifier(capa.GetFeatureSourceId());
                fs.UpdateFeatures(resource_id, comando, false);
                capa.ForceRefresh();
            }
            else imprimir(string.Format("\nError: no existe la capa {0}. ",nombre_capa));
        }

        /// <summary>
        /// Inserta un registro en la capa Especificada
        /// </summary>
        /// <param name="nombre_capa">Nombre de la capa</param>        
        /// <param name="coleccion_propiedades">Arreglo de Atributos de propiedades</param>
        internal void agregar_elemento_capa(string nombre_capa, params MgPropertyCollection[] coleccion_propiedades)
        {
            AcMapLayer capa = (AcMapLayer)obtener_capa(nombre_capa);
            if (capa != null)
            {                
                MgFeatureCommandCollection comando = new MgFeatureCommandCollection();
                foreach (MgPropertyCollection item in coleccion_propiedades)
                {
                    comando.Add(new MgInsertFeatures(string.Format("dbo:{0}", nombre_capa), item));
                }                
                MgResourceIdentifier resource_id = new MgResourceIdentifier(capa.GetFeatureSourceId());
                fs.UpdateFeatures(resource_id, comando, false);
                capa.ForceRefresh();
            }
            else imprimir(string.Format("\nError: no existe la capa {0}. ", nombre_capa));
        }

        /// <summary>
        /// Devuelve el conjunto de Propiedades
        /// </summary>
        /// <param name="propiedades">Tipo de Propiedades</param>
        /// <returns></returns>
        internal MgPropertyCollection conjunto_propiedades(params MgProperty[] propiedades)
        {
            MgPropertyCollection coleccion_propiedades = new MgPropertyCollection();
            foreach (MgProperty item in propiedades)
            {
                coleccion_propiedades.Add(item);
            }
            return coleccion_propiedades;
        }

        /// <summary>
        /// Actualiza el registro de la capa Especificada
        /// </summary>
        /// <param name="nombre_capa">Nombre de la Capa</param>
        /// /// <param name="id">Identificador de la fila a actualizar</param>
        /// <param name="propiedades">Arreglo de Atributos</param>        
        internal void actualizar_elemento_capa(string nombre_capa,string id,params MgProperty[] propiedades)
        {
            AcMapLayer capa = (AcMapLayer)obtener_capa(nombre_capa);
            if (capa != null)
            {
                MgPropertyCollection coleccion_propiedades = new MgPropertyCollection();
                foreach (MgProperty item in propiedades)
                {
                    coleccion_propiedades.Add(item);
                }
                MgFeatureCommandCollection comando = new MgFeatureCommandCollection();
                comando.Add(new MgUpdateFeatures(string.Format("dbo:{0}", nombre_capa), coleccion_propiedades,id));
                MgResourceIdentifier resource_id = new MgResourceIdentifier(capa.GetFeatureSourceId());
                fs.UpdateFeatures(resource_id, comando, false);
                capa.ForceRefresh();
            }
            else imprimir(string.Format("\nError: no existe la capa {0}. ", nombre_capa));
        }

        /// <summary>
        /// Muestra el mensaje en la bandeja de Consola
        /// </summary>
        /// <param name="mensaje">El mensaje a indicar</param>
        internal void imprimir(string mensaje)
        {
            editor.WriteMessage(mensaje);
        }

        /// <summary>
        /// Muestra un formulario Modal heredado de las mismas caracteristicas de Auto Cad Map 3D
        /// </summary>
        /// <param name="frm">Formulario a heredar</param>
        /// <returns>Formulario heredado</returns>
        internal System.Windows.Forms.DialogResult mostrar_dialogo(System.Windows.Forms.Form frm)
        {
            return Application.ShowModalDialog(frm);
        }
        #endregion

        #region Eventos
        private void evento_capa_agregado(object sender, AcMapMappingEventArgs e)
        {
            imprimir(string.Format( "\nCapa {0}, agregado en el Mapa\n. ", e.Name));
        }
        #endregion
    }
}