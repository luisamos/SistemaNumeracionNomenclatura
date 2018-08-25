using System;
using System.Windows.Forms;
using Clases;
using Componentes;
using WinControls.ListView;

namespace Formularios
{
    /// <summary>
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    internal partial class Cargar_Sectores : Inicio
    {
        internal Cargar_Sectores()
        {
            InitializeComponent();
        }

        #region Variables Globales
        //Conexión SQL Server        
        cSector_Manzana_Lotes Sectores = new cSector_Manzana_Lotes();
        //Auto Cad Map
        internal cAuto_Cad_Map Auto_Cad_Map;
        string UBIGEO = "";
        #endregion

        #region Metodos
        void listar_sector()
        {
            try
            {
                TreeListNode s = sector_tlst.GetItemAt("Todos");
                s.Nodes.Clear();
                Sectores.cargar(UBIGEO);
                s.Nodes.AddRange(Sectores.listar_sector());
                sector_tlst.ExpandAll();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error:  Cargar Sector", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                Auto_Cad_Map.agregar_capa("SECTOR", string.Format("UBIGEO = '{0}'", UBIGEO), false, true);
                                return;
                            }

                            foreach (TreeListNode item in a.ListView.CheckedItems)
                            {
                                query = query + string.Format("CODIGO_SECTOR='{0}' OR ", UBIGEO + item.Text);
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
                MessageBox.Show(ex.Message, "Error: Agregar Sector", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Eventos
        private void cargar_sectores_Load(object sender, EventArgs e)
        {
            Auto_Cad_Map.agregar_evento();            
            UBIGEO = cUbicacion_Geografica.Ubigeo;
            listar_sector();
        }

        private void cargar_btn_Click(object sender, EventArgs e)
        {
            if (UBIGEO != "" || UBIGEO != null)
            {
                Auto_Cad_Map.agregar_capa("DEPARTAMENTO", string.Format("CODIGO_DEPARTAMENTO = '{0}'", UBIGEO.Substring(0, 2)),false,false);
                Auto_Cad_Map.agregar_capa("PROVINCIA", string.Format("CODIGO_PROVINCIA = '{0}'", UBIGEO.Substring(0, 4)),false,false);
                Auto_Cad_Map.agregar_capa("DISTRITO", string.Format("UBIGEO = '{0}'", UBIGEO),false,false);
            }
            agregar_sector();
            this.DialogResult = DialogResult.OK;
        }
        #endregion
    }
}
