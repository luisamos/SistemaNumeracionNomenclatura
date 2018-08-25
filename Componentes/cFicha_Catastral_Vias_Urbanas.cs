using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Componentes
{
    /// <summary>
    /// Ficha Catastral de Vías Urbanas
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    public class cFicha_Catastral_Vias_Urbanas : cFicha
    {
        #region Atributos y Propiedades
        string sector;

        /// <summary>
        /// Código del Sector
        /// </summary>
        public string Sector
        {
            get { return sector; }
            set { sector = value; }
        }
        cVias vias;

        /// <summary>
        /// Clase : Vías
        /// </summary>
        public cVias Vias
        {
            get { return vias; }
            set { vias = value; }
        }
        string cuadra;

        /// <summary>
        /// Código de la Cuadra
        /// </summary>
        public string Cuadra
        {
            get { return cuadra; }
            set { cuadra = value; }
        }
        object numero_cuadras;

        /// <summary>
        /// Número de Cuadras
        /// </summary>
        public object Numero_Cuadras
        {
          get { return (numero_cuadras.Equals(""))? DBNull.Value: numero_cuadras; }
          set { numero_cuadras = value; }
        }
        cEstado_General_Via estado_general_via;

        /// <summary>
        /// Clase: Estado Genaral de la Via
        /// </summary>
        public cEstado_General_Via Estado_General_Via
        {
            get { return estado_general_via; }
            set { estado_general_via = value; }
        }
        cLimite limite;

        /// <summary>
        /// Clase: Límite
        /// </summary>
        public cLimite Limite
        {
            get { return limite; }
            set { limite = value; }
        }
        cCondicion_Limite condicion_limite;

        /// <summary>
        /// Clase: Condición del Límite
        /// </summary>
        public cCondicion_Limite Condicion_Limite
        {
            get { return condicion_limite; }
            set { condicion_limite = value; }
        }
        object punto_inicial_x;

        /// <summary>
        /// Punto Inicial Coordenadas X
        /// </summary>
        public object Punto_Inicial_X
        {
            get { return (punto_inicial_x.Equals("")) ? DBNull.Value : punto_inicial_x; }
            set { punto_inicial_x = value; }
        }
        object punto_inicial_y;

        /// <summary>
        /// Punto Inicial Coordenadas Y
        /// </summary>
        public object Punto_Inicial_Y
        {
            get { return (punto_inicial_y.Equals("")) ? DBNull.Value : punto_inicial_y; }
            set { punto_inicial_y = value; }
        }
        object punto_inicial_z;

        /// <summary>
        /// Punto Inicial Coordenadas Z
        /// </summary>
        public object Punto_Inicial_Z
        {
            get { return (punto_inicial_z.Equals("")) ? DBNull.Value : punto_inicial_z; }
            set { punto_inicial_z = value; }
        }
        object punto_final_x;

        /// <summary>
        /// Punto Final Coordenadas X
        /// </summary>
        public object Punto_Final_X
        {
            get { return (punto_final_x.Equals("")) ? DBNull.Value : punto_final_x; }
            set { punto_final_x = value; }
        }
        object punto_final_y;

        /// <summary>
        /// Punto Final Coordenadas Y
        /// </summary>
        public object Punto_Final_Y
        {
            get { return (punto_final_y.Equals("")) ? DBNull.Value : punto_final_y; }
            set { punto_final_y = value; }
        }
        object punto_final_z;

        /// <summary>
        /// Punto Final Coordenadas Z
        /// </summary>
        public object Punto_Final_Z
        {
            get { return (punto_final_z.Equals("")) ? DBNull.Value : punto_final_z; }
            set { punto_final_z = value; }
        }
        cHabilitacion_Urbana habilitacion_urbana;

        /// <summary>
        /// Clase: Habilitaciones Urbanas
        /// </summary>
        public cHabilitacion_Urbana Habilitacion_Urbana
        {
            get { return habilitacion_urbana; }
            set { habilitacion_urbana = value; }
        }
        string zona_sector_etapa;

        /// <summary>
        /// Zona, Sector, Etapa
        /// </summary>
        public string Zona_Sector_Etapa
        {
            get { return zona_sector_etapa; }
            set { zona_sector_etapa = value; }
        }
        object calzada_carril1_largo;

        /// <summary>
        /// Calzada Carril 1: Largo
        /// </summary>
        public object Calzada_Carril1_Largo
        {
            get { return (calzada_carril1_largo.Equals(""))? DBNull.Value:calzada_carril1_largo; }
            set { calzada_carril1_largo = value; }
        }
        object calzada_carril1_ancho;

        /// <summary>
        /// Calzada Carril 1: Ancho
        /// </summary>
        public object Calzada_Carril1_Ancho
        {
            get { return (calzada_carril1_ancho.Equals("")) ? DBNull.Value : calzada_carril1_ancho; }
            set { calzada_carril1_ancho = value; }
        }
        cMaterial calzada_carril1_material;

        /// <summary>
        /// Clase: Material
        /// Calzada Carril 1: Material
        /// </summary>
        public cMaterial Calzada_Carril1_Material
        {
            get { return calzada_carril1_material; }
            set { calzada_carril1_material = value; }
        }
        cEstado_Conservacion calzada_carril1_estado_conservacion;

        /// <summary>
        /// Clase: Estado de Conservación
        /// Calzada Carril 1: Estado de Conservación
        /// </summary>
        public cEstado_Conservacion Calzada_Carril1_Estado_Conservacion
        {
            get { return calzada_carril1_estado_conservacion; }
            set { calzada_carril1_estado_conservacion = value; }
        }
        string calzada_carril1_especificaciones;

        /// <summary>
        /// Calzada Carril 1: Especificaciones
        /// </summary>
        public string Calzada_Carril1_Especificaciones
        {
            get { return calzada_carril1_especificaciones; }
            set { calzada_carril1_especificaciones = value; }
        }
        object calzada_carril2_largo;

        /// <summary>
        /// Calzada Carril 2: Largo
        /// </summary>
        public object Calzada_Carril2_Largo
        {
            get { return (calzada_carril2_largo.Equals("")) ? DBNull.Value : calzada_carril2_largo; }
            set { calzada_carril2_largo = value; }
        }
        object calzada_carril2_ancho;

        /// <summary>
        /// Calzada Carril 2: Ancho
        /// </summary>
        public object Calzada_Carril2_Ancho
        {
            get { return (calzada_carril2_ancho.Equals("")) ? DBNull.Value : calzada_carril2_ancho; }
            set { calzada_carril2_ancho = value; }
        }
        cMaterial calzada_carril2_material;

        /// <summary>
        /// Clase: Material
        /// Calzada Carril 2: Material
        /// </summary>
        public cMaterial Calzada_Carril2_Material
        {
            get { return calzada_carril2_material; }
            set { calzada_carril2_material = value; }
        }
        cEstado_Conservacion calzada_carril2_estado_conservacion;

        /// <summary>
        /// Clase: Estado de Conservación
        /// Calzada Carril 2: Estado de Conservación
        /// </summary>
        public cEstado_Conservacion Calzada_Carril2_Estado_Conservacion
        {
            get { return calzada_carril2_estado_conservacion; }
            set { calzada_carril2_estado_conservacion = value; }
        }
        string calzada_carril2_especificaciones;

        /// <summary>
        /// Calzada Carril 2: Especificaciones
        /// </summary>
        public string Calzada_Carril2_Especificaciones
        {
            get { return calzada_carril2_especificaciones; }
            set { calzada_carril2_especificaciones = value; }
        }
        object calzada_carril3_largo;

        /// <summary>
        /// Calzada Carril 3: Largo
        /// </summary>
        public object Calzada_Carril3_Largo
        {
            get { return (calzada_carril3_largo.Equals("")) ? DBNull.Value : calzada_carril3_largo; }
            set { calzada_carril3_largo = value; }
        }
        object calzada_carril3_ancho;

        /// <summary>
        /// Calzada Carril 3: Ancho
        /// </summary>
        public object Calzada_Carril3_Ancho
        {
            get { return (calzada_carril3_ancho.Equals("")) ? DBNull.Value : calzada_carril3_ancho; }
            set { calzada_carril3_ancho = value; }
        }
        cMaterial calzada_carril3_material;

        /// <summary>
        /// Clase: Material
        /// Calzada Carril 3: Material
        /// </summary>
        public cMaterial Calzada_Carril3_Material
        {
            get { return calzada_carril3_material; }
            set { calzada_carril3_material = value; }
        }
        cEstado_Conservacion calzada_carril3_estado_conservacion;

        /// <summary>
        /// Clase: Estado de Conservación
        /// Calzada Carril 3: Estado de Conservación
        /// </summary>
        public cEstado_Conservacion Calzada_Carril3_Estado_Conservacion
        {
            get { return calzada_carril3_estado_conservacion; }
            set { calzada_carril3_estado_conservacion = value; }
        }
        string calzada_carril3_especificaciones;

        /// <summary>
        /// Calzada Carril 3: Especificaciones
        /// </summary>
        public string Calzada_Carril3_Especificaciones
        {
            get { return calzada_carril3_especificaciones; }
            set { calzada_carril3_especificaciones = value; }
        }
        object calzada_carril4_largo;

        /// <summary>
        /// Calzada Carril 4: Largo
        /// </summary>
        public object Calzada_Carril4_Largo
        {
            get { return (calzada_carril4_largo.Equals("")) ? DBNull.Value : calzada_carril4_largo; }
            set { calzada_carril4_largo = value; }
        }
        object calzada_carril4_ancho;

        /// <summary>
        /// Calzada Carril 4: Ancho
        /// </summary>
        public object Calzada_Carril4_Ancho
        {
            get { return (calzada_carril4_ancho.Equals("")) ? DBNull.Value : calzada_carril4_ancho; }
            set { calzada_carril4_ancho = value; }
        }
        cMaterial calzada_carril4_material;

        /// <summary>
        /// Clase: Material
        /// Calzada Carril 4: Material
        /// </summary>
        public cMaterial Calzada_Carril4_Material
        {
            get { return calzada_carril4_material; }
            set { calzada_carril4_material = value; }
        }
        cEstado_Conservacion calzada_carril4_estado_conservacion;

        /// <summary>
        /// Clase Estado de Conservación
        /// Calzada Carril 4: Estado de Conservación
        /// </summary>
        public cEstado_Conservacion Calzada_Carril4_Estado_Conservacion
        {
            get { return calzada_carril4_estado_conservacion; }
            set { calzada_carril4_estado_conservacion = value; }
        }
        string calzada_carril4_especificaciones;

        /// <summary>
        /// Calzada Carril 4: Especificaciones
        /// </summary>
        public string Calzada_Carril4_Especificaciones
        {
            get { return calzada_carril4_especificaciones; }
            set { calzada_carril4_especificaciones = value; }
        }
        object veredas_derecha_largo;

        /// <summary>
        /// Vereda Derecha: Largo
        /// </summary>
        public object Veredas_Derecha_Largo
        {
            get { return (veredas_derecha_largo.Equals("")) ? DBNull.Value : veredas_derecha_largo; }
            set { veredas_derecha_largo = value; }
        }
        object veredas_derecha_ancho;

        /// <summary>
        /// Vereda Derecha: Ancho
        /// </summary>
        public object Veredas_Derecha_Ancho
        {
            get { return (veredas_derecha_ancho.Equals("")) ? DBNull.Value : veredas_derecha_ancho; }
            set { veredas_derecha_ancho = value; }
        }
        cMaterial veredas_derecha_material;

        /// <summary>
        /// Clase Material
        /// Vereda Derecha: Material
        /// </summary>
        public cMaterial Veredas_Derecha_Material
        {
            get { return veredas_derecha_material; }
            set { veredas_derecha_material = value; }
        }
        cEstado_Conservacion veredas_derecha_estado_conservacion;
        
        /// <summary>
        /// Clase Estado de Conservación
        /// Vereda Derecha: Estado de Conservación
        /// </summary>
        public cEstado_Conservacion Veredas_Derecha_Estado_Conservacion
        {
            get { return veredas_derecha_estado_conservacion; }
            set { veredas_derecha_estado_conservacion = value; }
        }
        string veredas_derecha_especificaciones;

        /// <summary>
        /// Vereda Derecha: Especificaciones
        /// </summary>
        public string Veredas_Derecha_Especificaciones
        {
            get { return veredas_derecha_especificaciones; }
            set { veredas_derecha_especificaciones = value; }
        }
        object veredas_izquierda_largo;

        /// <summary>
        /// Vereda Izquierda: Largo
        /// </summary>
        public object Veredas_Izquierda_Largo
        {
            get { return (veredas_izquierda_largo.Equals("")) ? DBNull.Value : veredas_izquierda_largo; }
            set { veredas_izquierda_largo = value; }
        }
        object veredas_izquierda_ancho;

        /// <summary>
        /// Vereda Izquierda: Ancho
        /// </summary>
        public object Veredas_Izquierda_Ancho
        {
            get { return (veredas_izquierda_ancho.Equals("")) ? DBNull.Value : veredas_izquierda_ancho; }
            set { veredas_izquierda_ancho = value; }
        }
        cMaterial veredas_izquierda_material;

        /// <summary>
        /// Clase: Material
        /// Vereda Izquierda: Material
        /// </summary>
        public cMaterial Veredas_Izquierda_Material
        {
            get { return veredas_izquierda_material; }
            set { veredas_izquierda_material = value; }
        }
        cEstado_Conservacion veredas_izquierda_estado_conservacion;

        /// <summary>
        /// Clase: Estado de Conservación
        /// Vereda Izquierda: Estado de Conservación
        /// </summary>
        public cEstado_Conservacion Veredas_Izquierda_Estado_Conservacion
        {
            get { return veredas_izquierda_estado_conservacion; }
            set { veredas_izquierda_estado_conservacion = value; }
        }
        string veredas_izquierda_especificaciones;

        /// <summary>
        /// Vereda Izquierda: Izquierda
        /// </summary>
        public string Veredas_Izquierda_Especificaciones
        {
            get { return veredas_izquierda_especificaciones; }
            set { veredas_izquierda_especificaciones = value; }
        }
        object veredas_central_largo;

        /// <summary>
        /// Vereda Central: Largo
        /// </summary>
        public object Veredas_Central_Largo
        {
            get { return (veredas_central_largo.Equals("")) ? DBNull.Value : veredas_central_largo; }
            set { veredas_central_largo = value; }
        }
        object veredas_central_ancho;

        /// <summary>
        /// Vereda Central: Ancho
        /// </summary>
        public object Veredas_Central_Ancho
        {
            get { return (veredas_central_ancho.Equals(""))?DBNull.Value: veredas_central_ancho; }
            set { veredas_central_ancho = value; }
        }
        cMaterial veredas_central_material;

        /// <summary>
        /// Clase: Material
        /// Vereda Central: Material
        /// </summary>
        public cMaterial Veredas_Central_Material
        {
            get { return veredas_central_material; }
            set { veredas_central_material = value; }
        }
        cEstado_Conservacion veredas_central_estado_conservacion;

        /// <summary>
        /// Clase: Estado de Conservación
        /// Vereda Central: Estado de Conservación
        /// </summary>
        public cEstado_Conservacion Veredas_Central_Estado_Conservacion
        {
            get { return veredas_central_estado_conservacion; }
            set { veredas_central_estado_conservacion = value; }
        }
        string veredas_central_especificaciones;

        /// <summary>
        /// Vereda Central: Especificaciones
        /// </summary>
        public string Veredas_Central_Especificaciones
        {
            get { return veredas_central_especificaciones; }
            set { veredas_central_especificaciones = value; }
        }
        object ciclo_via_derecha_largo;

        /// <summary>
        /// Ciclo Via Derecha: Largo
        /// </summary>
        public object Ciclo_Via_Derecha_Largo
        {
            get { return (ciclo_via_derecha_largo.Equals("")) ? DBNull.Value : ciclo_via_derecha_largo; }
            set { ciclo_via_derecha_largo = value; }
        }
        object ciclo_via_derecha_ancho;

        /// <summary>
        /// Ciclo Via Derecha: Ancho
        /// </summary>
        public object Ciclo_Via_Derecha_Ancho
        {
            get { return (ciclo_via_derecha_ancho.Equals("")) ? DBNull.Value : ciclo_via_derecha_ancho; }
            set { ciclo_via_derecha_ancho = value; }
        }
        cMaterial ciclo_via_derecha_material;

        /// <summary>
        /// Clase: Material
        /// Ciclo Via Derecha: Material
        /// </summary>
        public cMaterial Ciclo_Via_Derecha_Material
        {
            get { return ciclo_via_derecha_material; }
            set { ciclo_via_derecha_material = value; }
        }
        cEstado_Conservacion ciclo_via_derecha_estado_conservacion;

        /// <summary>
        /// Clase: Estado de Conservación
        /// Ciclo Via Derecha: Estado de Conservación
        /// </summary>
        public cEstado_Conservacion Ciclo_Via_Derecha_Estado_Conservacion
        {
            get { return ciclo_via_derecha_estado_conservacion; }
            set { ciclo_via_derecha_estado_conservacion = value; }
        }
        string ciclo_via_derecha_especificaciones;

        /// <summary>
        /// Ciclo Via Derecha: Especificaciones
        /// </summary>
        public string Ciclo_Via_Derecha_Especificaciones
        {
            get { return ciclo_via_derecha_especificaciones; }
            set { ciclo_via_derecha_especificaciones = value; }
        }
        object ciclo_via_izquierda_largo;

        /// <summary>
        /// Ciclo Via Izquierda: Largo
        /// </summary>
        public object Ciclo_Via_Izquierda_Largo
        {
            get { return (ciclo_via_izquierda_largo.Equals("")) ? DBNull.Value : ciclo_via_izquierda_largo; }
            set { ciclo_via_izquierda_largo = value; }
        }
        object ciclo_via_izquierda_ancho;

        /// <summary>
        /// Ciclo Via Izquierda: Ancho
        /// </summary>
        public object Ciclo_Via_Izquierda_Ancho
        {
            get { return (ciclo_via_izquierda_ancho.Equals("")) ? DBNull.Value : ciclo_via_izquierda_ancho; }
            set { ciclo_via_izquierda_ancho = value; }
        }
        cMaterial ciclo_via_izquierda_material;

        /// <summary>
        /// Clase: Material
        /// Ciclo Via Izquierda: Material
        /// </summary>
        public cMaterial Ciclo_Via_Izquierda_Material
        {
            get { return ciclo_via_izquierda_material; }
            set { ciclo_via_izquierda_material = value; }
        }
        cEstado_Conservacion ciclo_via_izquierda_estado_conservacion;

        /// <summary>
        /// Clase: Estado de Conservación
        /// Ciclo Via Izquierda: Estado de Conservación
        /// </summary>
        public cEstado_Conservacion Ciclo_Via_Izquierda_Estado_Conservacion
        {
            get { return ciclo_via_izquierda_estado_conservacion; }
            set { ciclo_via_izquierda_estado_conservacion = value; }
        }
        string ciclo_via_izquierda_especificaciones;

        /// <summary>
        /// Ciclo Via Izquierda: Especificaciones
        /// </summary>
        public string Ciclo_Via_Izquierda_Especificaciones
        {
            get { return ciclo_via_izquierda_especificaciones; }
            set { ciclo_via_izquierda_especificaciones = value; }
        }
        object ciclo_via_central_largo;

        /// <summary>
        /// Ciclo Via Central: Largo
        /// </summary>
        public object Ciclo_Via_Central_Largo
        {
            get { return (ciclo_via_central_largo.Equals("")) ? DBNull.Value : ciclo_via_central_largo; }
            set { ciclo_via_central_largo = value; }
        }
        object ciclo_via_central_ancho;

        /// <summary>
        /// Ciclo Via Central: Ancho
        /// </summary>
        public object Ciclo_Via_Central_Ancho
        {
            get { return (ciclo_via_central_ancho.Equals("")) ? DBNull.Value : ciclo_via_central_ancho; }
            set { ciclo_via_central_ancho = value; }
        }
        cMaterial ciclo_via_central_material;

        /// <summary>
        /// Clase: Material
        /// Ciclo Via Central: Material
        /// </summary>
        public cMaterial Ciclo_Via_Central_Material
        {
            get { return ciclo_via_central_material; }
            set { ciclo_via_central_material = value; }
        }
        cEstado_Conservacion ciclo_via_central_estado_conservacion;

        /// <summary>
        /// Clase: Estado de Conservación
        /// Ciclo Via Central: Estado de Conservación
        /// </summary>
        public cEstado_Conservacion Ciclo_Via_Central_Estado_Conservacion
        {
            get { return ciclo_via_central_estado_conservacion; }
            set { ciclo_via_central_estado_conservacion = value; }
        }
        string ciclo_via_central_especificaciones;

        /// <summary>
        /// Ciclo Via Central: Especificaciones
        /// </summary>
        public string Ciclo_Via_Central_Especificaciones
        {
            get { return ciclo_via_central_especificaciones; }
            set { ciclo_via_central_especificaciones = value; }
        }
        object via_ferrea_derecha_largo;

        /// <summary>
        /// Via Ferrea Derecha: Largo
        /// </summary>
        public object Via_Ferrea_Derecha_Largo
        {
            get { return (via_ferrea_derecha_largo.Equals("")) ? DBNull.Value : via_ferrea_derecha_largo; }
            set { via_ferrea_derecha_largo = value; }
        }
        object via_ferrea_derecha_ancho;

        /// <summary>
        /// Via Ferrea Derecha: Ancho
        /// </summary>
        public object Via_Ferrea_Derecha_Ancho
        {
            get { return (via_ferrea_derecha_ancho.Equals("")) ? DBNull.Value : via_ferrea_derecha_ancho; }
            set { via_ferrea_derecha_ancho = value; }
        }
        cMaterial via_ferrea_derecha_material;

        /// <summary>
        /// Clase: Material
        /// Via Ferrea Derecha: Material
        /// </summary>
        public cMaterial Via_Ferrea_Derecha_Material
        {
            get { return via_ferrea_derecha_material; }
            set { via_ferrea_derecha_material = value; }
        }
        cEstado_Conservacion via_ferrea_derecha_estado_conservacion;

        /// <summary>
        /// Clase: Estado de Conservación
        /// Via Ferrea Derecha: Estado de Conservación
        /// </summary>
        public cEstado_Conservacion Via_Ferrea_Derecha_Estado_Conservacion
        {
            get { return via_ferrea_derecha_estado_conservacion; }
            set { via_ferrea_derecha_estado_conservacion = value; }
        }
        string via_ferrea_derecha_especificaciones;

        /// <summary>
        /// Via Ferrea Derecha: Especificaciones
        /// </summary>
        public string Via_Ferrea_Derecha_Especificaciones
        {
            get { return via_ferrea_derecha_especificaciones; }
            set { via_ferrea_derecha_especificaciones = value; }
        }
        object via_ferrea_izquierda_largo;

        /// <summary>
        /// Via Ferrea Izquierda: Largo
        /// </summary>
        public object Via_Ferrea_Izquierda_Largo
        {
            get { return (via_ferrea_izquierda_largo.Equals("")) ? DBNull.Value : via_ferrea_izquierda_largo; }
            set { via_ferrea_izquierda_largo = value; }
        }
        object via_ferrea_izquierda_ancho;

        /// <summary>
        /// Via Ferrea Izquierda: Ancho
        /// </summary>
        public object Via_Ferrea_Izquierda_Ancho
        {
            get { return (via_ferrea_izquierda_ancho.Equals("")) ? DBNull.Value : via_ferrea_izquierda_ancho; }
            set { via_ferrea_izquierda_ancho = value; }
        }
        cMaterial via_ferrea_izquierda_material;

        /// <summary>
        /// Clase: Material
        /// Via Ferrea Izquierda: Material
        /// </summary>
        public cMaterial Via_Ferrea_Izquierda_Material
        {
            get { return via_ferrea_izquierda_material; }
            set { via_ferrea_izquierda_material = value; }
        }
        cEstado_Conservacion via_ferrea_izquierda_estado_conservacion;

        /// <summary>
        /// Clase: Estado de Conservación
        /// Via Ferrea Izquierda: Estado de Conservación
        /// </summary>
        public cEstado_Conservacion Via_Ferrea_Izquierda_Estado_Conservacion
        {
            get { return via_ferrea_izquierda_estado_conservacion; }
            set { via_ferrea_izquierda_estado_conservacion = value; }
        }
        string via_ferrea_izquierda_especificaciones;

        /// <summary>
        /// Via Ferrea Izquierda: Especificaciones
        /// </summary>
        public string Via_Ferrea_Izquierda_Especificaciones
        {
            get { return via_ferrea_izquierda_especificaciones; }
            set { via_ferrea_izquierda_especificaciones = value; }
        }
        object via_ferrea_central_largo;

        /// <summary>
        /// Via Ferrea Central: Largo
        /// </summary>
        public object Via_Ferrea_Central_Largo
        {
            get { return (via_ferrea_central_largo.Equals("")) ? DBNull.Value : via_ferrea_central_largo; }
            set { via_ferrea_central_largo = value; }
        }
        object via_ferrea_central_ancho;

        /// <summary>
        /// Via Ferrea Central: Ancho
        /// </summary>
        public object Via_Ferrea_Central_Ancho
        {
            get { return (via_ferrea_central_ancho.Equals("")) ? DBNull.Value : via_ferrea_central_ancho; }
            set { via_ferrea_central_ancho = value; }
        }
        cMaterial via_ferrea_central_material;

        /// <summary>
        /// Clase: Material
        /// Via Ferrea Central: Material
        /// </summary>
        public cMaterial Via_Ferrea_Central_Material
        {
            get { return via_ferrea_central_material; }
            set { via_ferrea_central_material = value; }
        }
        cEstado_Conservacion via_ferrea_central_estado_conservacion;

        /// <summary>
        /// Clase: Estado de Conservación
        /// Via Ferrea Central: Estado de Conservación
        /// </summary>
        public cEstado_Conservacion Via_Ferrea_Central_Estado_Conservacion
        {
            get { return via_ferrea_central_estado_conservacion; }
            set { via_ferrea_central_estado_conservacion = value; }
        }
        string via_ferrea_central_especificaciones;

        /// <summary>
        /// Via Ferrea Central: Especificaciones
        /// </summary>
        public string Via_Ferrea_Central_Especificaciones
        {
            get { return via_ferrea_central_especificaciones; }
            set { via_ferrea_central_especificaciones = value; }
        }
        object berma_derecha_largo;

        /// <summary>
        /// Berma Derecha: Largo
        /// </summary>
        public object Berma_Derecha_Largo
        {
            get { return (berma_derecha_largo.Equals("")) ? DBNull.Value : berma_derecha_largo; }
            set { berma_derecha_largo = value; }
        }
        object berma_derecha_ancho;

        /// <summary>
        /// Berma Derecha: Ancho
        /// </summary>
        public object Berma_Derecha_Ancho
        {
            get { return (berma_derecha_ancho.Equals("")) ? DBNull.Value : berma_derecha_ancho; }
            set { berma_derecha_ancho = value; }
        }        
        cEstado_Conservacion berma_derecha_estado_conservacion;

        /// <summary>
        /// Clase: Estado de Conservación
        /// Berma Derecha: Estado de Conservación
        /// </summary>
        public cEstado_Conservacion Berma_Derecha_Estado_Conservacion
        {
            get { return berma_derecha_estado_conservacion; }
            set { berma_derecha_estado_conservacion = value; }
        }
        string berma_derecha_especificaciones;

        /// <summary>
        /// Berma Derecha: Especificaciones
        /// </summary>
        public string Berma_Derecha_Especificaciones
        {
            get { return berma_derecha_especificaciones; }
            set { berma_derecha_especificaciones = value; }
        }
        object berma_izquierda_largo;

        /// <summary>
        /// Berma Izquierda: Largo
        /// </summary>
        public object Berma_Izquierda_Largo
        {
            get { return (berma_izquierda_largo.Equals("")) ? DBNull.Value : berma_izquierda_largo; }
            set { berma_izquierda_largo = value; }
        }
        object berma_izquierda_ancho;

        /// <summary>
        /// Berma Izquierda: Ancho
        /// </summary>
        public object Berma_Izquierda_Ancho
        {
            get { return (berma_izquierda_ancho.Equals("")) ? DBNull.Value : berma_izquierda_ancho; }
            set { berma_izquierda_ancho = value; }
        }
        cEstado_Conservacion berma_izquierda_estado_conservacion;

        /// <summary>
        /// Clase: Estado de Conservación
        /// Berma Izquierda: Estado de Conservación
        /// </summary>
        public cEstado_Conservacion Berma_Izquierda_Estado_Conservacion
        {
            get { return berma_izquierda_estado_conservacion; }
            set { berma_izquierda_estado_conservacion = value; }
        }
        string berma_izquierda_especificaciones;

        /// <summary>
        /// Berma Izquierda: Especificaciones
        /// </summary>
        public string Berma_Izquierda_Especificaciones
        {
            get { return berma_izquierda_especificaciones; }
            set { berma_izquierda_especificaciones = value; }
        }
        object berma_central_largo;

        /// <summary>
        /// Berma Central: Largo
        /// </summary>
        public object Berma_Central_Largo
        {
            get { return (berma_central_largo.Equals("")) ? DBNull.Value : berma_central_largo; }
            set { berma_central_largo = value; }
        }
        object berma_central_ancho;

        /// <summary>
        /// Berma Central: Ancho
        /// </summary>
        public object Berma_Central_Ancho
        {
            get { return (berma_central_ancho.Equals("")) ? DBNull.Value : berma_central_ancho; }
            set { berma_central_ancho = value; }
        }        
        cEstado_Conservacion berma_central_estado_conservacion;

        /// <summary>
        /// Clase: Estado de Conservación
        /// Berma Central: Estado de Conservación
        /// </summary>
        public cEstado_Conservacion Berma_Central_Estado_Conservacion
        {
            get { return berma_central_estado_conservacion; }
            set { berma_central_estado_conservacion = value; }
        }
        string berma_central_especificaciones;

        /// <summary>
        /// Berma Central: Especificaciones
        /// </summary>
        public string Berma_Central_Especificaciones
        {
            get { return berma_central_especificaciones; }
            set { berma_central_especificaciones = value; }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Asinga un Código Nuevo 
        /// </summary>
        /// <returns>El Código Siguiente de la Ficha Vías Urbanas</returns>
        public string nuevo_codigo()
        {
            string c = "";
            try
            {
                c = server.ejecutar_sp("GENERAR_SIGUIENTE_CODIGO",
                    server.parametro("@DOCUMENTO", SqlDbType.VarChar, 20, "VIAS"),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, "ADMIN")).ToString();
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Nuevo Código, Ficha Catastral de Vías Urbanas.", ex);
            }
            return c;
        }

        /// <summary>
        /// Lista todos los registros
        /// </summary>
        /// <returns>Un conjunto de datos</returns>
        public FICHA_ds listar()
        {
            try
            {
                tabla = server.ejecutar_vs("VS_LISTAR_FICHA_CATASTRAL_VIAS_URBANAS", tabla, "NUMERO DE FICHA", true);
                tabla = server.ejecutar_vs("VS_LISTAR_FICHA_CATASTRAL_VIAS_URBANAS_FOTOGRAFIA", tabla);
                tabla = server.ejecutar_vs("VS_LISTAR_FICHA_CATASTRAL_VIAS_URBANAS_COMPONENTE_URBANO", tabla);
                tabla = server.ejecutar_vs("VS_LISTAR_FICHA_CATASTRAL_VIAS_URBANAS_MOBILIARIO_URBANO", tabla);
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar, Ficha Catastral de Vías Urbanas. ", ex);
            }
            return tabla;
        }

        /// <summary>
        /// Lista todos las coordenadas registradas en la Ficha Catastral de Vías Urbanas
        /// </summary>
        /// <param name="pUbigeo">Ubigeo</param>               
        /// <param name="pCodigo_Via">Código de la Via</param>
        /// <param name="pCuadra">Cuadra</param>
        /// <returns>Un arreglo bidimencional</returns>
        public double[,] listar(string pUbigeo, string pCodigo_Via, string pCuadra)
        {
            double[,] coordenadas = null;
            try
            {
                tabla = server.ejecutar_vs("VS_LISTAR_FICHA_CATASTRAL_VIAS_URBANAS", tabla, "FICHA", true);
                
                if (tabla.VS_LISTAR_FICHA_CATASTRAL_VIAS_URBANAS != null)
                {                    
                    var query = from v in tabla.VS_LISTAR_FICHA_CATASTRAL_VIAS_URBANAS.AsEnumerable()
                                where v.DPTO == pUbigeo.Substring(0, 2) && v.PROV == pUbigeo.Substring(2, 2) && v.DIST == pUbigeo.Substring(4, 2) && v.CODIGO_DE_VIA == pCodigo_Via && v.CUADRA == pCuadra
                                select new {v.PUNTO_INICIAL_X,v.PUNTO_INICIAL_Y,v.PUNTO_FINAL_X,v.PUNTO_FINAL_Y };
                    if (query.Count() > 0)
                    {
                        coordenadas = new double[,] { { 0, 0 }, { 0, 0 } }; 
                        foreach (var item in query)
                        {                          
                            coordenadas[0, 0] = item.PUNTO_INICIAL_X;
                            coordenadas[0, 1] = item.PUNTO_INICIAL_Y;
                            coordenadas[1, 0] = item.PUNTO_FINAL_X;
                            coordenadas[1, 1] = item.PUNTO_FINAL_Y;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar, Ficha Catastral de Vías Urbanas. ", ex);
            }
            return coordenadas;
        }

        /// <summary>
        /// Guarda un Registro
        /// </summary>
        /// <param name="planoUbicacion">Fotografía del Plano de Ubicación</param>
        /// <param name="añoPlanoUbicacion">Año del registro del Plano de Ubicación</param>
        /// <param name="seccionTipica">Fotografía de la Sección Típica de la Via</param>
        /// <param name="seccion">Descripción de la Via</param>
        /// <param name="fotografia">Fotografía de la Via</param>
        /// <param name="añoFotografia">Año del registro de la Fotografía</param>
        /// <returns>El número de Filas Afectadas</returns>
        public string guardar(Image planoUbicacion, string añoPlanoUbicacion,Image seccionTipica,string seccion,string fotografia,string añoFotografia)
        {
            string rpta;
            try
            {
                rpta = server.ejecutar_sp("GUARDAR_RESUMIDO_FICHA_CATASTRAL_VIAS_URBANAS",                
                server.parametro("@DEPARTAMENTO", SqlDbType.VarChar, 2, Departamento),
                server.parametro("@PROVINCIA", SqlDbType.VarChar, 2, Provincia),
                server.parametro("@DISTRITO", SqlDbType.VarChar, 2, Distrito),
                server.parametro("@SECTOR", SqlDbType.VarChar, 2, Sector),
                server.parametro("@CODIGO_VIA", SqlDbType.VarChar, 3, Vias.Codigo),
                server.parametro("@CUADRA", SqlDbType.VarChar, 2, Cuadra),
                server.parametro("@PUNTO_INICIAL_X", SqlDbType.Decimal, Punto_Inicial_X),
                server.parametro("@PUNTO_INICIAL_Y", SqlDbType.Decimal, Punto_Inicial_Y),
                server.parametro("@PUNTO_INICIAL_Z", SqlDbType.Decimal, Punto_Inicial_Z),
                server.parametro("@PUNTO_FINAL_X", SqlDbType.Decimal, Punto_Final_X),
                server.parametro("@PUNTO_FINAL_Y", SqlDbType.Decimal, Punto_Final_Y),
                server.parametro("@PUNTO_FINAL_Z", SqlDbType.Decimal, Punto_Final_Z),
                server.parametro("@PLANO_VIA", SqlDbType.VarBinary, (planoUbicacion != null) ? cConfiguracion.toBytes(planoUbicacion) : null),
                server.parametro("@AÑO_PLANO_VIA", SqlDbType.VarChar, 4, añoPlanoUbicacion),
                server.parametro("@SECCION_TIPICA", SqlDbType.VarBinary, (seccionTipica != null) ? cConfiguracion.toBytes(seccionTipica) : null),
                server.parametro("@SECCION", SqlDbType.VarChar, 50, seccion),
                server.parametro("@FOTOGRAFIA", SqlDbType.VarBinary, (fotografia != "") ? File.ReadAllBytes(fotografia) : null),
                server.parametro("@AÑO_FOTOGRAFIA", SqlDbType.VarChar, 4, añoFotografia),
                server.parametro("@HASH",SqlDbType.VarChar,36,Hash),
                server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario)).ToString();   
            }
            catch (Exception ex)
            {
                rpta= "";
                throw new sqlServerException("Error Guardar Resumido, ficha Catastral de Vías Urbanas. ", ex);
            }
            return rpta;
        }

        /// <summary>
        /// Guarda un Registro
        /// </summary>
        /// <returns>El número de Filas Afectadas</returns>
        public int guardar()
        {
            try
            {
                i = server.ejecutar("GUARDAR_FICHA_CATASTRAL_VIAS_URBANAS",
                    server.parametro("@FICHA", SqlDbType.VarChar, 10, Ficha),
                    server.parametro("@PARCIAL_FICHAS", SqlDbType.BigInt, Parcial_Ficha),
                    server.parametro("@TOTAL_FICHAS", SqlDbType.Int, Total_Fichas),                    
                    server.parametro("@DEPARTAMENTO", SqlDbType.VarChar, 2, Departamento),
                    server.parametro("@PROVINCIA", SqlDbType.VarChar, 2, Provincia),
                    server.parametro("@DISTRITO", SqlDbType.VarChar, 2, Distrito),
                    server.parametro("@SECTOR", SqlDbType.VarChar, 2, Sector),
                    server.parametro("@CODIGO_VIA", SqlDbType.VarChar, 3, Vias.Codigo),
                    server.parametro("@CUADRA", SqlDbType.VarChar,2,Cuadra),
                    server.parametro("@NUMERO_CUADRAS", SqlDbType.Int,Numero_Cuadras),
                    server.parametro("@ESTADO_GENERAL_VIA", SqlDbType.VarChar,2,Estado_General_Via.Codigo),
                    server.parametro("@LIMITE", SqlDbType.VarChar,2,Limite.Codigo),
                    server.parametro("@CONDICION_LIMITE", SqlDbType.VarChar,2,Condicion_Limite.Codigo),
                    server.parametro("@PUNTO_INICIAL_X", SqlDbType.Decimal,Punto_Inicial_X),
                    server.parametro("@PUNTO_INICIAL_Y", SqlDbType.Decimal,Punto_Inicial_Y),
                    server.parametro("@PUNTO_INICIAL_Z", SqlDbType.Decimal,Punto_Inicial_Z),
                    server.parametro("@PUNTO_FINAL_X", SqlDbType.Decimal,Punto_Final_X),
                    server.parametro("@PUNTO_FINAL_Y", SqlDbType.Decimal,Punto_Final_Y),
                    server.parametro("@PUNTO_FINAL_Z", SqlDbType.Decimal,Punto_Final_Z),
                    server.parametro("@HABILITACION_URBANA", SqlDbType.VarChar,6,Habilitacion_Urbana.Codigo),
                    server.parametro("@ZONA_SECTOR_ETAPA", SqlDbType.VarChar,100,Zona_Sector_Etapa),
                    server.parametro("@CALZADA_CARRIL1_LARGO", SqlDbType.Decimal,Calzada_Carril1_Largo),
                    server.parametro("@CALZADA_CARRIL1_ANCHO", SqlDbType.Decimal,Calzada_Carril1_Ancho),
                    server.parametro("@CALZADA_CARRIL1_MATERIAL", SqlDbType.VarChar,2,Calzada_Carril1_Material.Codigo),
                    server.parametro("@CALZADA_CARRIL1_ESTADO_CONSERVACION", SqlDbType.VarChar,2,Calzada_Carril1_Estado_Conservacion.Codigo),
                    server.parametro("@CALZADA_CARRIL1_ESPECIFICACIONES", SqlDbType.Text,Calzada_Carril1_Especificaciones),
                    server.parametro("@CALZADA_CARRIL2_LARGO", SqlDbType.Decimal,Calzada_Carril2_Largo),
                    server.parametro("@CALZADA_CARRIL2_ANCHO", SqlDbType.Decimal,Calzada_Carril2_Ancho),
                    server.parametro("@CALZADA_CARRIL2_MATERIAL", SqlDbType.VarChar, 2, Calzada_Carril2_Material.Codigo),
                    server.parametro("@CALZADA_CARRIL2_ESTADO_CONSERVACION", SqlDbType.VarChar,2,Calzada_Carril2_Estado_Conservacion.Codigo),
                    server.parametro("@CALZADA_CARRIL2_ESPECIFICACIONES", SqlDbType.Text,Calzada_Carril2_Especificaciones),
                    server.parametro("@CALZADA_CARRIL3_LARGO", SqlDbType.Decimal,Calzada_Carril3_Largo),
                    server.parametro("@CALZADA_CARRIL3_ANCHO", SqlDbType.Decimal,Calzada_Carril3_Ancho),
                    server.parametro("@CALZADA_CARRIL3_MATERIAL", SqlDbType.VarChar, 2, Calzada_Carril3_Material.Codigo),
                    server.parametro("@CALZADA_CARRIL3_ESTADO_CONSERVACION", SqlDbType.VarChar,2,Calzada_Carril3_Estado_Conservacion.Codigo),
                    server.parametro("@CALZADA_CARRIL3_ESPECIFICACIONES", SqlDbType.Text,Calzada_Carril3_Especificaciones),
                    server.parametro("@CALZADA_CARRIL4_LARGO", SqlDbType.Decimal,Calzada_Carril4_Largo),
                    server.parametro("@CALZADA_CARRIL4_ANCHO", SqlDbType.Decimal,Calzada_Carril4_Ancho),
                    server.parametro("@CALZADA_CARRIL4_MATERIAL", SqlDbType.VarChar, 2, Calzada_Carril4_Material.Codigo),
                    server.parametro("@CALZADA_CARRIL4_ESTADO_CONSERVACION", SqlDbType.VarChar,2,Calzada_Carril4_Estado_Conservacion.Codigo),
                    server.parametro("@CALZADA_CARRIL4_ESPECIFICACIONES", SqlDbType.Text,Calzada_Carril4_Especificaciones),
                    server.parametro("@VEREDAS_DERECHA_LARGO", SqlDbType.Decimal,Veredas_Derecha_Largo),
                    server.parametro("@VEREDAS_DERECHA_ANCHO", SqlDbType.Decimal,Veredas_Derecha_Ancho),
                    server.parametro("@VEREDAS_DERECHA_MATERIAL", SqlDbType.VarChar, 2, Veredas_Derecha_Material.Codigo),
                    server.parametro("@VEREDAS_DERECHA_ESTADO_CONSERVACION", SqlDbType.VarChar,2,Veredas_Derecha_Estado_Conservacion.Codigo),
                    server.parametro("@VEREDAS_DERECHA_ESPECIFICACIONES", SqlDbType.Text,Veredas_Derecha_Especificaciones),
                    server.parametro("@VEREDAS_IZQUIERDA_LARGO", SqlDbType.Decimal,Veredas_Izquierda_Largo),
                    server.parametro("@VEREDAS_IZQUIERDA_ANCHO", SqlDbType.Decimal,Veredas_Izquierda_Ancho),
                    server.parametro("@VEREDAS_IZQUIERDA_MATERIAL", SqlDbType.VarChar, 2, Veredas_Izquierda_Material.Codigo),
                    server.parametro("@VEREDAS_IZQUIERDA_ESTADO_CONSERVACION", SqlDbType.VarChar,2,Veredas_Izquierda_Estado_Conservacion.Codigo),
                    server.parametro("@VEREDAS_IZQUIERDA_ESPECIFICACIONES", SqlDbType.Text,Veredas_Izquierda_Especificaciones),
                    server.parametro("@VEREDAS_CENTRAL_LARGO", SqlDbType.Decimal,Veredas_Central_Largo),
                    server.parametro("@VEREDAS_CENTRAL_ANCHO", SqlDbType.Decimal,Veredas_Central_Ancho),
                    server.parametro("@VEREDAS_CENTRAL_MATERIAL", SqlDbType.VarChar, 2, Veredas_Central_Material.Codigo),
                    server.parametro("@VEREDAS_CENTRAL_ESTADO_CONSERVACION", SqlDbType.VarChar,2,Veredas_Central_Estado_Conservacion.Codigo),
                    server.parametro("@VEREDAS_CENTRAL_ESPECIFICACIONES", SqlDbType.Text,Veredas_Central_Especificaciones),
                    server.parametro("@CICLO_VIA_DERECHA_LARGO", SqlDbType.Decimal,Ciclo_Via_Derecha_Largo),
                    server.parametro("@CICLO_VIA_DERECHA_ANCHO", SqlDbType.Decimal,Ciclo_Via_Derecha_Ancho),
                    server.parametro("@CICLO_VIA_DERECHA_MATERIAL", SqlDbType.VarChar, 2, Ciclo_Via_Derecha_Material.Codigo),
                    server.parametro("@CICLO_VIA_DERECHA_ESTADO_CONSERVACION", SqlDbType.VarChar,2,Ciclo_Via_Derecha_Estado_Conservacion.Codigo),
                    server.parametro("@CICLO_VIA_DERECHA_ESPECIFICACIONES", SqlDbType.Text,Ciclo_Via_Derecha_Especificaciones),
                    server.parametro("@CICLO_VIA_IZQUIERDA_LARGO", SqlDbType.Decimal,Ciclo_Via_Izquierda_Largo),
                    server.parametro("@CICLO_VIA_IZQUIERDA_ANCHO", SqlDbType.Decimal,Ciclo_Via_Izquierda_Ancho),
                    server.parametro("@CICLO_VIA_IZQUIERDA_MATERIAL", SqlDbType.VarChar, 2, Ciclo_Via_Izquierda_Material.Codigo),
                    server.parametro("@CICLO_VIA_IZQUIERDA_ESTADO_CONSERVACION", SqlDbType.VarChar,2,Ciclo_Via_Izquierda_Estado_Conservacion.Codigo),
                    server.parametro("@CICLO_VIA_IZQUIERDA_ESPECIFICACIONES", SqlDbType.Text,Ciclo_Via_Izquierda_Especificaciones),
                    server.parametro("@CICLO_VIA_CENTRAL_LARGO", SqlDbType.Decimal,Ciclo_Via_Central_Largo),
                    server.parametro("@CICLO_VIA_CENTRAL_ANCHO", SqlDbType.Decimal,Ciclo_Via_Central_Ancho),
                    server.parametro("@CICLO_VIA_CENTRAL_MATERIAL", SqlDbType.VarChar, 2, Ciclo_Via_Central_Material.Codigo),
                    server.parametro("@CICLO_VIA_CENTRAL_ESTADO_CONSERVACION", SqlDbType.VarChar,2,Ciclo_Via_Central_Estado_Conservacion.Codigo),
                    server.parametro("@CICLO_VIA_CENTRAL_ESPECIFICACIONES", SqlDbType.Text,Ciclo_Via_Central_Especificaciones),
                    server.parametro("@VIA_FERREA_DERECHA_LARGO", SqlDbType.Decimal,Via_Ferrea_Derecha_Largo),
                    server.parametro("@VIA_FERREA_DERECHA_ANCHO", SqlDbType.Decimal,Via_Ferrea_Derecha_Ancho),
                    server.parametro("@VIA_FERREA_DERECHA_MATERIAL", SqlDbType.VarChar, 2, Via_Ferrea_Derecha_Material.Codigo),
                    server.parametro("@VIA_FERREA_DERECHA_ESTADO_CONSERVACION", SqlDbType.VarChar,2,Via_Ferrea_Derecha_Estado_Conservacion.Codigo),
                    server.parametro("@VIA_FERREA_DERECHA_ESPECIFICACIONES", SqlDbType.Text,Via_Ferrea_Derecha_Especificaciones),
                    server.parametro("@VIA_FERREA_IZQUIERDA_LARGO", SqlDbType.Decimal,Via_Ferrea_Izquierda_Largo),
                    server.parametro("@VIA_FERREA_IZQUIERDA_ANCHO", SqlDbType.Decimal,Via_Ferrea_Izquierda_Ancho),
                    server.parametro("@VIA_FERREA_IZQUIERDA_MATERIAL", SqlDbType.VarChar, 2, Via_Ferrea_Izquierda_Material.Codigo),
                    server.parametro("@VIA_FERREA_IZQUIERDA_ESTADO_CONSERVACION", SqlDbType.VarChar,2,Via_Ferrea_Izquierda_Estado_Conservacion.Codigo),
                    server.parametro("@VIA_FERREA_IZQUIERDA_ESPECIFICACIONES", SqlDbType.Text,Via_Ferrea_Izquierda_Especificaciones),
                    server.parametro("@VIA_FERREA_CENTRAL_LARGO", SqlDbType.Decimal,Via_Ferrea_Central_Largo),
                    server.parametro("@VIA_FERREA_CENTRAL_ANCHO", SqlDbType.Decimal,Via_Ferrea_Central_Ancho),
                    server.parametro("@VIA_FERREA_CENTRAL_MATERIAL", SqlDbType.VarChar, 2, Via_Ferrea_Central_Material.Codigo),
                    server.parametro("@VIA_FERREA_CENTRAL_ESTADO_CONSERVACION", SqlDbType.VarChar,2,Via_Ferrea_Central_Estado_Conservacion.Codigo),
                    server.parametro("@VIA_FERREA_CENTRAL_ESPECIFICACIONES", SqlDbType.Text,Via_Ferrea_Central_Especificaciones),
                    server.parametro("@BERMA_DERECHA_LARGO", SqlDbType.Decimal,Berma_Derecha_Largo),
                    server.parametro("@BERMA_DERECHA_ANCHO", SqlDbType.Decimal,Berma_Derecha_Ancho),
                    server.parametro("@BERMA_DERECHA_ESTADO_CONSERVACION", SqlDbType.VarChar,2,Berma_Derecha_Estado_Conservacion.Codigo),
                    server.parametro("@BERMA_DERECHA_ESPECIFICACIONES", SqlDbType.Text,Berma_Derecha_Especificaciones),
                    server.parametro("@BERMA_IZQUIERDA_LARGO", SqlDbType.Decimal,Berma_Izquierda_Largo),
                    server.parametro("@BERMA_IZQUIERDA_ANCHO", SqlDbType.Decimal,Berma_Izquierda_Ancho),
                    server.parametro("@BERMA_IZQUIERDA_ESTADO_CONSERVACION", SqlDbType.VarChar,2,Berma_Izquierda_Estado_Conservacion.Codigo),
                    server.parametro("@BERMA_IZQUIERDA_ESPECIFICACIONES", SqlDbType.Text,Berma_Izquierda_Especificaciones),
                    server.parametro("@BERMA_CENTRAL_LARGO", SqlDbType.Decimal,Berma_Central_Largo),
                    server.parametro("@BERMA_CENTRAL_ANCHO", SqlDbType.Decimal,Berma_Central_Ancho),
                    server.parametro("@BERMA_CENTRAL_ESTADO_CONSERVACION", SqlDbType.VarChar,2,Berma_Central_Estado_Conservacion.Codigo),
                    server.parametro("@BERMA_CENTRAL_ESPECIFICACIONES", SqlDbType.Text, Berma_Central_Especificaciones),
                    server.parametro("@OBSERVACIONES", SqlDbType.Text, Observaciones),
                    server.parametro("@ESTADO_LLENADO_FICHA", SqlDbType.VarChar, 2, Estado_Llenado_Ficha.Codigo),
                    server.parametro("@SUPERVISOR", SqlDbType.VarChar, 8, Supervisor.DNI),
                    server.parametro("@FECHA_SUPERVISOR", SqlDbType.DateTime, Fecha_Supervisor),
                    server.parametro("@TECNICO_CATASTRAL", SqlDbType.VarChar, 8, Tecnico_Catastral.DNI),
                    server.parametro("@FECHA_TECNICO_CATASTRAL", SqlDbType.DateTime, Fecha_Tecnico_Catastral),
                    server.parametro("@VB_DIGITACION", SqlDbType.VarChar, 8, Digitacion.DNI),
                    server.parametro("@FECHA_VB_DIGITACION", SqlDbType.DateTime, Fecha_Digitacion),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Guardar, Ficha Catastral de Vías Urbanas. ", ex);
            }
            return i;
        }

        /// <summary>
        /// Modifica un Registro
        /// </summary>
        /// <returns>El número de filas Afectadas</returns>
        public int modificar()
        {
            try
            {
                i = server.ejecutar("MODIFICAR_FICHA_CATASTRAL_VIAS_URBANAS",
                    server.parametro("@FICHA", SqlDbType.VarChar, 10, Ficha),
                    server.parametro("@PARCIAL_FICHAS", SqlDbType.BigInt, Parcial_Ficha),
                    server.parametro("@TOTAL_FICHAS", SqlDbType.Int, Total_Fichas),                    
                    server.parametro("@DEPARTAMENTO", SqlDbType.VarChar, 2, Departamento),
                    server.parametro("@PROVINCIA", SqlDbType.VarChar, 2, Provincia),
                    server.parametro("@DISTRITO", SqlDbType.VarChar, 2, Distrito),
                    server.parametro("@SECTOR", SqlDbType.VarChar, 2, Sector),
                    server.parametro("@CODIGO_VIA", SqlDbType.VarChar, 3, Vias.Codigo),
                    server.parametro("@CUADRA", SqlDbType.VarChar, 2, Cuadra),
                    server.parametro("@NUMERO_CUADRAS", SqlDbType.Int, Numero_Cuadras),
                    server.parametro("@ESTADO_GENERAL_VIA", SqlDbType.VarChar, 2, Estado_General_Via.Codigo),
                    server.parametro("@LIMITE", SqlDbType.VarChar, 2, Limite.Codigo),
                    server.parametro("@CONDICION_LIMITE", SqlDbType.VarChar, 2, Condicion_Limite.Codigo),
                    server.parametro("@PUNTO_INICIAL_X", SqlDbType.Decimal, Punto_Inicial_X),
                    server.parametro("@PUNTO_INICIAL_Y", SqlDbType.Decimal, Punto_Inicial_Y),
                    server.parametro("@PUNTO_INICIAL_Z", SqlDbType.Decimal, Punto_Inicial_Z),
                    server.parametro("@PUNTO_FINAL_X", SqlDbType.Decimal, Punto_Final_X),
                    server.parametro("@PUNTO_FINAL_Y", SqlDbType.Decimal, Punto_Final_Y),
                    server.parametro("@PUNTO_FINAL_Z", SqlDbType.Decimal, Punto_Final_Z),
                    server.parametro("@HABILITACION_URBANA", SqlDbType.VarChar, 6, Habilitacion_Urbana.Codigo),
                    server.parametro("@ZONA_SECTOR_ETAPA", SqlDbType.VarChar, 100, Zona_Sector_Etapa),
                    server.parametro("@CALZADA_CARRIL1_LARGO", SqlDbType.Decimal, Calzada_Carril1_Largo),
                    server.parametro("@CALZADA_CARRIL1_ANCHO", SqlDbType.Decimal, Calzada_Carril1_Ancho),
                    server.parametro("@CALZADA_CARRIL1_MATERIAL", SqlDbType.VarChar, 2, Calzada_Carril1_Material.Codigo),
                    server.parametro("@CALZADA_CARRIL1_ESTADO_CONSERVACION", SqlDbType.VarChar, 2, Calzada_Carril1_Estado_Conservacion.Codigo),
                    server.parametro("@CALZADA_CARRIL1_ESPECIFICACIONES", SqlDbType.Text, Calzada_Carril1_Especificaciones),
                    server.parametro("@CALZADA_CARRIL2_LARGO", SqlDbType.Decimal, Calzada_Carril2_Largo),
                    server.parametro("@CALZADA_CARRIL2_ANCHO", SqlDbType.Decimal, Calzada_Carril2_Ancho),
                    server.parametro("@CALZADA_CARRIL2_MATERIAL", SqlDbType.VarChar, 2, Calzada_Carril2_Material.Codigo),
                    server.parametro("@CALZADA_CARRIL2_ESTADO_CONSERVACION", SqlDbType.VarChar, 2, Calzada_Carril2_Estado_Conservacion.Codigo),
                    server.parametro("@CALZADA_CARRIL2_ESPECIFICACIONES", SqlDbType.Text, Calzada_Carril2_Especificaciones),
                    server.parametro("@CALZADA_CARRIL3_LARGO", SqlDbType.Decimal, Calzada_Carril3_Largo),
                    server.parametro("@CALZADA_CARRIL3_ANCHO", SqlDbType.Decimal, Calzada_Carril3_Ancho),
                    server.parametro("@CALZADA_CARRIL3_MATERIAL", SqlDbType.VarChar, 2, Calzada_Carril3_Material.Codigo),
                    server.parametro("@CALZADA_CARRIL3_ESTADO_CONSERVACION", SqlDbType.VarChar, 2, Calzada_Carril3_Estado_Conservacion.Codigo),
                    server.parametro("@CALZADA_CARRIL3_ESPECIFICACIONES", SqlDbType.Text, Calzada_Carril3_Especificaciones),
                    server.parametro("@CALZADA_CARRIL4_LARGO", SqlDbType.Decimal, Calzada_Carril4_Largo),
                    server.parametro("@CALZADA_CARRIL4_ANCHO", SqlDbType.Decimal, Calzada_Carril4_Ancho),
                    server.parametro("@CALZADA_CARRIL4_MATERIAL", SqlDbType.VarChar, 2, Calzada_Carril4_Material.Codigo),
                    server.parametro("@CALZADA_CARRIL4_ESTADO_CONSERVACION", SqlDbType.VarChar, 2, Calzada_Carril4_Estado_Conservacion.Codigo),
                    server.parametro("@CALZADA_CARRIL4_ESPECIFICACIONES", SqlDbType.Text, Calzada_Carril4_Especificaciones),
                    server.parametro("@VEREDAS_DERECHA_LARGO", SqlDbType.Decimal, Veredas_Derecha_Largo),
                    server.parametro("@VEREDAS_DERECHA_ANCHO", SqlDbType.Decimal, Veredas_Derecha_Ancho),
                    server.parametro("@VEREDAS_DERECHA_MATERIAL", SqlDbType.VarChar, 2, Veredas_Derecha_Material.Codigo),
                    server.parametro("@VEREDAS_DERECHA_ESTADO_CONSERVACION", SqlDbType.VarChar, 2, Veredas_Derecha_Estado_Conservacion.Codigo),
                    server.parametro("@VEREDAS_DERECHA_ESPECIFICACIONES", SqlDbType.Text, Veredas_Derecha_Especificaciones),
                    server.parametro("@VEREDAS_IZQUIERDA_LARGO", SqlDbType.Decimal, Veredas_Izquierda_Largo),
                    server.parametro("@VEREDAS_IZQUIERDA_ANCHO", SqlDbType.Decimal, Veredas_Izquierda_Ancho),
                    server.parametro("@VEREDAS_IZQUIERDA_MATERIAL", SqlDbType.VarChar, 2, Veredas_Izquierda_Material.Codigo),
                    server.parametro("@VEREDAS_IZQUIERDA_ESTADO_CONSERVACION", SqlDbType.VarChar, 2, Veredas_Izquierda_Estado_Conservacion.Codigo),
                    server.parametro("@VEREDAS_IZQUIERDA_ESPECIFICACIONES", SqlDbType.Text, Veredas_Izquierda_Especificaciones),
                    server.parametro("@VEREDAS_CENTRAL_LARGO", SqlDbType.Decimal, Veredas_Central_Largo),
                    server.parametro("@VEREDAS_CENTRAL_ANCHO", SqlDbType.Decimal, Veredas_Central_Ancho),
                    server.parametro("@VEREDAS_CENTRAL_MATERIAL", SqlDbType.VarChar, 2, Veredas_Central_Material.Codigo),
                    server.parametro("@VEREDAS_CENTRAL_ESTADO_CONSERVACION", SqlDbType.VarChar, 2, Veredas_Central_Estado_Conservacion.Codigo),
                    server.parametro("@VEREDAS_CENTRAL_ESPECIFICACIONES", SqlDbType.Text, Veredas_Central_Especificaciones),
                    server.parametro("@CICLO_VIA_DERECHA_LARGO", SqlDbType.Decimal, Ciclo_Via_Derecha_Largo),
                    server.parametro("@CICLO_VIA_DERECHA_ANCHO", SqlDbType.Decimal, Ciclo_Via_Derecha_Ancho),
                    server.parametro("@CICLO_VIA_DERECHA_MATERIAL", SqlDbType.VarChar, 2, Ciclo_Via_Derecha_Material.Codigo),
                    server.parametro("@CICLO_VIA_DERECHA_ESTADO_CONSERVACION", SqlDbType.VarChar, 2, Ciclo_Via_Derecha_Estado_Conservacion.Codigo),
                    server.parametro("@CICLO_VIA_DERECHA_ESPECIFICACIONES", SqlDbType.Text, Ciclo_Via_Derecha_Especificaciones),
                    server.parametro("@CICLO_VIA_IZQUIERDA_LARGO", SqlDbType.Decimal, Ciclo_Via_Izquierda_Largo),
                    server.parametro("@CICLO_VIA_IZQUIERDA_ANCHO", SqlDbType.Decimal, Ciclo_Via_Izquierda_Ancho),
                    server.parametro("@CICLO_VIA_IZQUIERDA_MATERIAL", SqlDbType.VarChar, 2, Ciclo_Via_Izquierda_Material.Codigo),
                    server.parametro("@CICLO_VIA_IZQUIERDA_ESTADO_CONSERVACION", SqlDbType.VarChar, 2, Ciclo_Via_Izquierda_Estado_Conservacion.Codigo),
                    server.parametro("@CICLO_VIA_IZQUIERDA_ESPECIFICACIONES", SqlDbType.Text, Ciclo_Via_Izquierda_Especificaciones),
                    server.parametro("@CICLO_VIA_CENTRAL_LARGO", SqlDbType.Decimal, Ciclo_Via_Central_Largo),
                    server.parametro("@CICLO_VIA_CENTRAL_ANCHO", SqlDbType.Decimal, Ciclo_Via_Central_Ancho),
                    server.parametro("@CICLO_VIA_CENTRAL_MATERIAL", SqlDbType.VarChar, 2, Ciclo_Via_Central_Material.Codigo),
                    server.parametro("@CICLO_VIA_CENTRAL_ESTADO_CONSERVACION", SqlDbType.VarChar, 2, Ciclo_Via_Central_Estado_Conservacion.Codigo),
                    server.parametro("@CICLO_VIA_CENTRAL_ESPECIFICACIONES", SqlDbType.Text, Ciclo_Via_Central_Especificaciones),
                    server.parametro("@VIA_FERREA_DERECHA_LARGO", SqlDbType.Decimal, Via_Ferrea_Derecha_Largo),
                    server.parametro("@VIA_FERREA_DERECHA_ANCHO", SqlDbType.Decimal, Via_Ferrea_Derecha_Ancho),
                    server.parametro("@VIA_FERREA_DERECHA_MATERIAL", SqlDbType.VarChar, 2, Via_Ferrea_Derecha_Material.Codigo),
                    server.parametro("@VIA_FERREA_DERECHA_ESTADO_CONSERVACION", SqlDbType.VarChar, 2, Via_Ferrea_Derecha_Estado_Conservacion.Codigo),
                    server.parametro("@VIA_FERREA_DERECHA_ESPECIFICACIONES", SqlDbType.Text, Via_Ferrea_Derecha_Especificaciones),
                    server.parametro("@VIA_FERREA_IZQUIERDA_LARGO", SqlDbType.Decimal, Via_Ferrea_Izquierda_Largo),
                    server.parametro("@VIA_FERREA_IZQUIERDA_ANCHO", SqlDbType.Decimal, Via_Ferrea_Izquierda_Ancho),
                    server.parametro("@VIA_FERREA_IZQUIERDA_MATERIAL", SqlDbType.VarChar, 2, Via_Ferrea_Izquierda_Material.Codigo),
                    server.parametro("@VIA_FERREA_IZQUIERDA_ESTADO_CONSERVACION", SqlDbType.VarChar, 2, Via_Ferrea_Izquierda_Estado_Conservacion.Codigo),
                    server.parametro("@VIA_FERREA_IZQUIERDA_ESPECIFICACIONES", SqlDbType.Text, Via_Ferrea_Izquierda_Especificaciones),
                    server.parametro("@VIA_FERREA_CENTRAL_LARGO", SqlDbType.Decimal, Via_Ferrea_Central_Largo),
                    server.parametro("@VIA_FERREA_CENTRAL_ANCHO", SqlDbType.Decimal, Via_Ferrea_Central_Ancho),
                    server.parametro("@VIA_FERREA_CENTRAL_MATERIAL", SqlDbType.VarChar, 2, Via_Ferrea_Central_Material.Codigo),
                    server.parametro("@VIA_FERREA_CENTRAL_ESTADO_CONSERVACION", SqlDbType.VarChar, 2, Via_Ferrea_Central_Estado_Conservacion.Codigo),
                    server.parametro("@VIA_FERREA_CENTRAL_ESPECIFICACIONES", SqlDbType.Text, Via_Ferrea_Central_Especificaciones),
                    server.parametro("@BERMA_DERECHA_LARGO", SqlDbType.Decimal, Berma_Derecha_Largo),
                    server.parametro("@BERMA_DERECHA_ANCHO", SqlDbType.Decimal, Berma_Derecha_Ancho),
                    server.parametro("@BERMA_DERECHA_ESTADO_CONSERVACION", SqlDbType.VarChar, 2, Berma_Derecha_Estado_Conservacion.Codigo),
                    server.parametro("@BERMA_DERECHA_ESPECIFICACIONES", SqlDbType.Text, Berma_Derecha_Especificaciones),
                    server.parametro("@BERMA_IZQUIERDA_LARGO", SqlDbType.Decimal, Berma_Izquierda_Largo),
                    server.parametro("@BERMA_IZQUIERDA_ANCHO", SqlDbType.Decimal, Berma_Izquierda_Ancho),
                    server.parametro("@BERMA_IZQUIERDA_ESTADO_CONSERVACION", SqlDbType.VarChar, 2, Berma_Izquierda_Estado_Conservacion.Codigo),
                    server.parametro("@BERMA_IZQUIERDA_ESPECIFICACIONES", SqlDbType.Text, Berma_Izquierda_Especificaciones),
                    server.parametro("@BERMA_CENTRAL_LARGO", SqlDbType.Decimal, Berma_Central_Largo),
                    server.parametro("@BERMA_CENTRAL_ANCHO", SqlDbType.Decimal, Berma_Central_Ancho),
                    server.parametro("@BERMA_CENTRAL_ESTADO_CONSERVACION", SqlDbType.VarChar, 2, Berma_Central_Estado_Conservacion.Codigo),
                    server.parametro("@BERMA_CENTRAL_ESPECIFICACIONES", SqlDbType.Text, Berma_Central_Especificaciones),
                    server.parametro("@OBSERVACIONES", SqlDbType.Text, Observaciones),
                    server.parametro("@ESTADO_LLENADO_FICHA", SqlDbType.VarChar, 2, Estado_Llenado_Ficha.Codigo),
                    server.parametro("@SUPERVISOR", SqlDbType.VarChar, 8, Supervisor.DNI),
                    server.parametro("@FECHA_SUPERVISOR", SqlDbType.DateTime, Fecha_Supervisor),
                    server.parametro("@TECNICO_CATASTRAL", SqlDbType.VarChar, 8, Tecnico_Catastral.DNI),
                    server.parametro("@FECHA_TECNICO_CATASTRAL", SqlDbType.DateTime, Fecha_Tecnico_Catastral),
                    server.parametro("@VB_DIGITACION", SqlDbType.VarChar, 8, Digitacion.DNI),
                    server.parametro("@FECHA_VB_DIGITACION", SqlDbType.DateTime, Fecha_Digitacion),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Modificar, Ficha Catastral de Vías Urbanas. ", ex);
            }
            return i;
        }

        /// <summary>
        /// Elimina un Registro
        /// </summary>
        /// <returns>El número de filas Afectadas</returns>
        public int eliminar()
        {
            try
            {
                i = server.ejecutar("ELIMINAR_FICHA_CATASTRAL_VIAS_URBANAS",
                    server.parametro("@FICHA", SqlDbType.VarChar, 10, Ficha),
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Eliminar, Ficha Catastral de Vías Urbanas. ", ex);

            }
            return i;
        }

        /// <summary>
        /// Reporte
        /// </summary>
        /// <returns>Un conjunto de datos</returns>
        public FICHA_ds reporte()
        {
            try
            {
                tabla = server.ejecutar_vs("VS_REPORTE_FICHA_CATASTRAL_VIAS_URBANAS", tabla, "FICHA", true);
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Reporte, Ficha Catastral de Vías Urbanas.", ex);
            }
            return tabla;
        }
        #endregion
    }
}
