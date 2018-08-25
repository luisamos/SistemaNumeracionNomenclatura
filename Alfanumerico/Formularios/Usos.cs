using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Componentes;

namespace Formularios
{
    /// <summary>
    /// Autor                   : Dunia
    /// Fecha de Creación       : 01 - 02 - 2012
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    internal partial class Usos : SubFicha
    {
       internal Usos()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.listar_Load);
            nuevo_tsb.Click += new EventHandler(nuevo_tsb_Click);
            aceptar_tsb.Click += new EventHandler(aceptar_tsb_Click);
            eliminar_tsb.Click += new EventHandler(eliminar_tsb_Click);
            cancelar_tsb.Click += new EventHandler(cancelar_tsb_Click);
            vistaPrevia_tsb.Click += new EventHandler(vistaPrevia_tsb_Click);
            //this.FormClosing += new EventHandler(cerrar_FormClosing);
            codigo_txt.KeyDown += new KeyEventHandler(base.enter_KeyDown);
        }

       #region Metodos
       void iniciar()
       {
           listar();
           aceptar_tsb.Text = "&Modificar";
           aceptar_tsb.Image = null;
           nuevo_tsb.Enabled = true;
           eliminar_tsb.Enabled = true;
           buscar_tst.Text = "";
           base.habilitar = false;
       }
       void listar()
       {
           FICHA_ds = (new cUsos()).listar_uso1();
           base.refrescar();
           SUBFICHA_bs.DataSource = FICHA_ds;
           SUBFICHA_bs.DataMember = "VS_LISTAR_USO_CODIGO";
       }
       void guardar()
       {
           if (codigo_txt.Text.Length > 0 && descripcion_txt.Text.Length > 0)
           {
               cUsos uso = new cUsos();
               uso.Codigo = codigo_txt.Text;
               uso.Sub_codigo= sub_codigo_txt.Text;
               uso.Descripcion = descripcion_txt.Text;
               uso.Usuario = Usuario;
               i = uso.guardar();
               if (i > 0) MessageBox.Show("Se a Insertando Correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
               else MessageBox.Show("Error, el Uso: '" + codigo_txt.Text + "', ya existe en el base de datos.", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
               iniciar();
           }
       }
       void modificar()
       {
           if (codigo_txt.Text.Length > 0 && descripcion_txt.Text.Length > 0)
           {
               cUsos usos = new cUsos();
               usos.Codigo = codigo_txt.Text;
               usos.Descripcion = descripcion_txt.Text;
               usos.Sub_codigo = sub_codigo_txt.Text;
               usos.Usuario = Usuario;
               i = usos.modificar();
               if (i > 0) MessageBox.Show("Se a Modificado Correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
               else MessageBox.Show("Error, no se a Modificado Correctamente, el Uso esta en uso y/o esta Desabilitada.", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
               iniciar();
           }
       }
       void eliminar()
       {
           cUsos uso = new cUsos();
           uso.Codigo = codigo_txt.Text;
           uso.Usuario = Usuario;
           i = uso.eliminar();
           if (i >= 2) MessageBox.Show("Se a eliminado el Registro", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
           else MessageBox.Show("Error, No se puede eliminar, el Uso esta en uso y/o esta Desabilitada.", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
           iniciar();
       }
       #endregion

       #region Eventos
       private void listar_Load(object sender, EventArgs e)
       {
           try
           {
               listar();
               base.habilitar = false;
               base.listar_busqueda();
               codigo_txt.DataBindings.Add(new Binding("Text", SUBFICHA_bs, "CODIGO", true));
               descripcion_txt.DataBindings.Add(new Binding("Text", SUBFICHA_bs, "DESCRIPCION", true));
               sub_codigo_txt.DataBindings.Add(new Binding("Text", SUBFICHA_bs, "SUB_CODIGO", true));
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message, "Error - Listar");
           }
       }

       private void nuevo_tsb_Click(object sender, EventArgs e)
       {
           if (!habilitar)
           {
               principal_tc.SelectedTab = formulario_tp;
               base.habilitar = true;
               base.controles = false;
               codigo_txt.Focus();
           }
       }

       private void aceptar_tsb_Click(object sender, EventArgs e)
       {
           try
           {
               if (SUBFICHA_dgv.Rows.Count > 0)
               {
                   base.habilitar = true;
                   codigo_txt.Focus();
                   if (aceptar_tsb.Text == "&Guardar") guardar();
                   else if (aceptar_tsb.Text == "&Modificar")
                   {
                       base.controles = false;
                       aceptar_tsb.Text = "&Aceptar";
                       aceptar_tsb.Image = null;
                       nuevo_tsb.Enabled = false;
                       eliminar_tsb.Enabled = true;
                       codigo_txt.Enabled = false;
                       principal_tc.SelectedTab = formulario_tp;
                   }
                   else if (aceptar_tsb.Text == "&Aceptar") modificar();
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message, "Error - Guardar y/o Modificar", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
       }

       private void eliminar_tsb_Click(object sender, EventArgs e)
       {
           try
           {
               if (SUBFICHA_dgv.Rows.Count > 0) eliminar();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message, "Error - Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
       }

       private void cancelar_tsb_Click(object sender, EventArgs e)
       {
           if (habilitar)
           {
               base.habilitar = false;
               base.controles = true;
           }
       }

       private void vistaPrevia_tsb_Click(object sender, EventArgs e)
       {
           //try
           //{
           //    DataView vista = FICHA_ds.VS_LISTAR_USOS.DefaultView;
           //    vista.RowFilter = query;
           //    DataTable tabla = vista.ToTable();
           //    Reporte reporte;
           //    if (tabla.Rows.Count > 0) reporte = new Reporte(new Usos(), tabla);
           //    else reporte = new Reporte(new Usos(), FICHA_ds);
           //    reporte.Text = "Vista Previa, " + this.Text;
           //    reporte.ShowDialog();
           //}
           //catch (Exception ex)
           //{
           //    MessageBox.Show(ex.Message, "Error - Reporte");
           //}
       }

       private void cerrar_FormClosing(object sender, FormClosingEventArgs e)
       {
           if (i != 0) this.DialogResult = DialogResult.OK;
       }
       #endregion


    }
}
