using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinControls.ListView;

namespace Componentes
{
    /// <summary>
    /// Base Cartográfica - Capas: Sector, Manzana y Lotes
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    public class cSector_Manzana_Lotes : cConexion
    {
        #region Metodos
        /// <summary>
        /// Carga todos la información Catastral de Sector, Manzana y Lotes        
        /// </summary>
        /// <param name="ubigeo">El ubigeo del Distrito</param>
        public void cargar(string ubigeo)
        {
            try
            {
                tabla = server.ejecutar_vs("VS_CARGAR_SECTOR_MANZANA_LOTE",tabla,"UBIGEO",ubigeo);
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Cargar, Sector - Manzana - Lote", ex);
            }
        }

        TreeListNode nuevo_arbol(string nombre, string tag)
        {
            TreeListNode a = new TreeListNode();
            a.Text = nombre;
            a.Tag = tag;
            return a;
        }

        /// <summary>
        /// Lista todo los Sectores
        /// </summary>
        /// <returns>Un conjunto de Sectores</returns>
        public TreeListNode[] listar_sector()
        {
            TreeListNode[] arreglo = null;
            try
            {
                if (tabla.VS_CARGAR_SECTOR_MANZANA_LOTE != null)
                {
                    IEnumerable<TreeListNode> query = from v in tabla.VS_CARGAR_SECTOR_MANZANA_LOTE                                                      
                                                      group v by v.SECTOR into g
                                                      select new TreeListNode(g.Key);
                    arreglo = query.Select(a => a).ToArray();
                }
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar Arreglo, Sector",ex);
            }
            return arreglo;
        }

        /// <summary>
        /// Lista todo los Sectores
        /// </summary>
        /// <returns>Un conjunto de Sectores</returns>
        public string[] listar_arreglo_sector()
        {
            string[] arreglo = null;
            try
            {
                if (tabla.VS_CARGAR_SECTOR_MANZANA_LOTE != null)
                {
                    IEnumerable<string> query = from v in tabla.VS_CARGAR_SECTOR_MANZANA_LOTE
                                                      group v by v.SECTOR into g
                                                      select g.Key;
                    arreglo = query.Select(a => a).ToArray();                    
                }
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar Arreglo, Sector", ex);
            }
            return arreglo;
        }

        /// <summary>
        /// Lista todo las Manzanas de un Sector
        /// </summary>
        /// <param name="codigo_sector">Código del Sector</param>
        /// <returns>Un conjunto de Manzanas</returns>
        public TreeListNode[] listar_manzana(string codigo_sector)
        {
            TreeListNode[] arreglo = null;
            try
            {                
                if (tabla.VS_CARGAR_SECTOR_MANZANA_LOTE != null)
                {

                    IEnumerable<TreeListNode> query = from v in tabla.VS_CARGAR_SECTOR_MANZANA_LOTE
                                                      where v.SECTOR == codigo_sector && !v.IsMANZANANull()
                                                      group v by v.MANZANA into g
                                                      select nuevo_arbol(g.Key,codigo_sector);
                    arreglo = query.Select(b => b).ToArray();
                }
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar Arreglo, Manzana.",ex);
            }
            return arreglo;
        }

        /// <summary>
        /// Lista todos los Lotes de una Manzana especificada
        /// </summary>
        /// <param name="codigo_manzana">El Código de la Manzana</param>
        /// <returns>Un conjunto de Lotes</returns>
        public TreeListNode[] listar_lote(string codigo_manzana)
        {
            TreeListNode[] arreglo = null;
            try
            {
                TreeListNode lotes = new TreeListNode(string.Format("Sector {0} Manzana {1}", codigo_manzana.Substring(0, 2), codigo_manzana.Substring(2, 3)));
                lotes.Tag = codigo_manzana;
                IEnumerable<TreeListNode> query = from v in tabla.VS_CARGAR_SECTOR_MANZANA_LOTE
                                                  where v.SECTOR == codigo_manzana.Substring(0, 2) && v.MANZANA == codigo_manzana.Substring(2, 3) && !v.IsLOTENull()
                                                  group v by v.LOTE into g
                                                  select nuevo_arbol(codigo_manzana, g.Key).RootNode;
                lotes.Nodes.AddRange(query.Select(b => b).ToArray());
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar Arreglo, Lote.", ex);
            }
            return arreglo;
        }        
        #endregion
    }
}
