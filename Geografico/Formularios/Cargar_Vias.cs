using System;
using System.Windows.Forms;
using WinControls.ListView;
using Clases;
using Componentes;

namespace Formularios
{
    /// <summary>
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    internal partial class Cargar_Vias : Inicio
    {
        internal Cargar_Vias()
        {
            InitializeComponent();
        }

        #region Variables Globales
        //Conexión SQL Server        
        cVias vias = new cVias();
        //Auto Cad Map       
        internal cAuto_Cad_Map Auto_Cad_Map = null;
        string UBIGEO = "";
        #endregion  

        #region Metodos
        void listar_vias()
        {
            try
            {
                TreeListNode s = vias_tlst.GetItemAt("Todos");
                s.Nodes.Clear();                
                s.Nodes.AddRange(vias.cargar_eje_vias_arreglo());
                vias_tlst.ExpandAll();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: Listar Sector", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void agregar_vias()
        {
            try
            {
                TreeListNode a = vias_tlst.GetItemAt("Todos");
                if (a != null)
                {
                    if (a.Checked != false || a.Checked != null)
                    {
                        int j = a.ListView.CheckedItems.Count;
                        if (j > 0)
                        {
                            string query = "";
                            if (a.Checked == true)
                            {
                                query = string.Format("UBIGEO = '{0}'", UBIGEO);
                                Auto_Cad_Map.agregar_capa("VIAS", query, false,true);
                                return;
                            }

                            foreach (TreeListNode item in a.ListView.CheckedItems)
                            {
                                query = query + string.Format("ID={0} OR ", item.Tag);
                            }
                            if (query.Substring(query.Length - 3).Equals("OR "))
                                query = query.Substring(0, query.Length - 3);
                            Auto_Cad_Map.agregar_capa("VIAS", query,false,true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error:  Cargar Vias", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Eventos
        private void cargar_vias_Load(object sender, EventArgs e)
        {
            Auto_Cad_Map.agregar_evento();            
            UBIGEO = cUbicacion_Geografica.Ubigeo;
            listar_vias();
        }

        private void cargar_btn_Click(object sender, EventArgs e)
        {
            if (UBIGEO != "" || UBIGEO != null)
            {
                Auto_Cad_Map.agregar_capa("DEPARTAMENTO", string.Format("CODIGO_DEPARTAMENTO = '{0}'", UBIGEO.Substring(0, 2)),false,false);
                Auto_Cad_Map.agregar_capa("PROVINCIA", string.Format("CODIGO_PROVINCIA = '{0}'", UBIGEO.Substring(0, 4)), false,false);
                Auto_Cad_Map.agregar_capa("DISTRITO", string.Format("UBIGEO = '{0}'", UBIGEO),false,false);
                Auto_Cad_Map.agregar_capa("SECTOR", string.Format("UBIGEO = '{0}'", UBIGEO), false, true);
                Auto_Cad_Map.agregar_capa("MANZANA", string.Format("CODIGO_SECTOR LIKE ('{0}%')", UBIGEO), false, true);
            }
            agregar_vias();
            this.DialogResult = DialogResult.OK;
        }
        #endregion
    }
}
