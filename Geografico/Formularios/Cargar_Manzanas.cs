using System;
using System.Windows.Forms;
using Componentes;
using Clases;
using WinControls.ListView;
using WinControls.ListView.EventArgClasses;

namespace Formularios
{
    /// <summary>
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    internal partial class Cargar_Manzanas : Inicio
    {
        internal Cargar_Manzanas()
        {
            InitializeComponent();
        }

        #region Variables Globales
        //Conexión SQL Server        
        cSector_Manzana_Lotes Sector_Manzana = new cSector_Manzana_Lotes();
        //Auto Cad Map
        internal cAuto_Cad_Map Auto_Cad_Map = null;
        string ubigeo = "";
        #endregion

        #region Metodos
        void listar_sector()
        {
            try
            {
                TreeListNode s = sector_tlst.GetItemAt("Todos");
                s.Nodes.Clear();
                Sector_Manzana.cargar(ubigeo);
                s.Nodes.AddRange(Sector_Manzana.listar_sector());
                sector_tlst.ExpandAll();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error:  Cargar Sector", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void listar_manzana(string codigo_sector)
        {
            try
            {
                TreeListNode Manzana = new TreeListNode("Sector " + codigo_sector);
                Manzana.Tag = codigo_sector;
                Manzana.Nodes.AddRange(Sector_Manzana.listar_manzana(codigo_sector));
                if (Manzana.Nodes.Count > 0)
                {
                    TreeListNode a = manzana_tlst.GetItemAt("Todos");
                    a.Nodes.Add(Manzana);
                    a.Nodes.Sort();
                    manzana_tlst.ExpandAll();
                    expandirManzana_btn.Text = "+";
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: Listar Manzana", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }    

        void agregar_sector()
        {
            try
            {
                TreeListNode a = sector_tlst.GetItemAt("Todos");
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
                                Auto_Cad_Map.agregar_capa("SECTOR", string.Format("UBIGEO = '{0}'", ubigeo), false, true);
                                return;
                            }

                            foreach (TreeListNode item in a.ListView.CheckedItems)
                            {
                                query = query + string.Format("CODIGO_SECTOR='{0}' OR ", ubigeo + item.Text);
                            }                            
                            if (query.Substring(query.Length - 3).Equals("OR "))
                                query = query.Substring(0, query.Length - 3);
                            Auto_Cad_Map.agregar_capa("SECTOR", query, false, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error:  Agregar Sector", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void agregar_manzana()
        {
            try
            {
                TreeListNode a = manzana_tlst.GetItemAt("Todos");
                if (a != null)
                {
                    if (a.Checked != false || a.Checked != null)
                    {
                        int j = a.ListView.CheckedItems.Count;
                        if (j > 0)
                        {
                            string query = "";                            
                            if (a.Checked == true && sector_tlst.GetItemAt("Todos").ListView.CheckedItems.Count == sector_tlst.GetItemAt("Todos").Nodes.Count+1)
                            {
                                Auto_Cad_Map.agregar_capa("MANZANA", string.Format("CODIGO_SECTOR LIKE ('{0}%')", ubigeo),false,true);
                                return;
                            }

                            foreach (TreeListNode x in a.ListView.CheckedItems)
                            {
                                if (x.Text != "Todos")
                                    if (x.Text.Equals(string.Format("Sector {0}", x.Tag)))
                                        query = query + string.Format("CODIGO_SECTOR ='{0}' OR ", ubigeo + x.Tag);
                            }

                            foreach (TreeListNode x in a.ListView.CheckedItems)
                            {
                                if (x.Text != "Todos")
                                    if (!x.Text.Equals(string.Format("Sector {0}", x.Tag)))
                                        if (query.IndexOf(string.Format("CODIGO_SECTOR ='{0}'", ubigeo + x.Tag)) == -1)
                                            query = query + string.Format("CODIGO_MANZANA='{0}' OR ", ubigeo + x.Tag + x.Text);
                            }                           
                            if (query.Substring(query.Length - 3).Equals("OR "))
                                query = query.Substring(0, query.Length - 3);
                            Auto_Cad_Map.agregar_capa("MANZANA", query,false,true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error:  Agregar Manzana", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        
        #endregion

        #region Eventos
        private void cargar_manzanas_Load(object sender, EventArgs e)
        {
            Auto_Cad_Map.agregar_evento();            
            ubigeo = cUbicacion_Geografica.Ubigeo;
            listar_sector();
        }

        private void expandirManzana_btn_Click(object sender, EventArgs e)
        {
            if (expandirManzana_btn.Text == "+")
            {
                manzana_tlst.CollapseAll();
                expandirManzana_btn.Text = "-";
            }
            else
            {
                manzana_tlst.ExpandAll();
                expandirManzana_btn.Text = "+";
            }
            manzana_tlst.GetItemAt("Todos").Expand();   
        }

        private void cargar_btn_Click(object sender, EventArgs e)
        {
            if (ubigeo != "" || ubigeo != null) 
            {
                Auto_Cad_Map.agregar_capa("DEPARTAMENTO", string.Format("CODIGO_DEPARTAMENTO = '{0}'", ubigeo.Substring(0, 2)),false,false);
                Auto_Cad_Map.agregar_capa("PROVINCIA", string.Format("CODIGO_PROVINCIA = '{0}'", ubigeo.Substring(0, 4)), false,false);
                Auto_Cad_Map.agregar_capa("DISTRITO", string.Format("UBIGEO = '{0}'", ubigeo), false,false);
                agregar_sector();
            }            
            agregar_manzana();
            this.DialogResult = DialogResult.OK;
        }

        private void sector_BeforeCheckStateChanged(object sender, ContainerListViewCancelEventArgs e)
        {
            try
            {
                if (e.Item.Text != "Todos")
                {
                    if (e.Item.Checked.Value) //Desactivado
                    {
                        TreeListNode a = manzana_tlst.GetItemAt("Todos");
                        if (a != null)
                        {
                            foreach (TreeListNode item in a.Nodes)
                            {
                                if (item.Text == "Sector " + e.Item)
                                {
                                    foreach (TreeListNode i in item.Nodes)
                                    {
                                        if (i.Checked.Value)
                                        {
                                            i.Checked = false;
                                        }
                                    }
                                    item.Nodes.Clear();
                                    a.Nodes.Remove(item);
                                    break;
                                }
                            }
                            a.Nodes.Sort();
                            manzana_tlst.CollapseAll();
                            a.Expand();
                            expandirManzana_btn.Text = "-";
                            if (a.Nodes.Count == 0) a.Checked = false;
                        }
                    }
                    else //Activado
                    {
                        listar_manzana(e.Item.Text);
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: Seleccionar Elementos Sector", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
