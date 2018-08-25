using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Componentes;

namespace Formularios
{
    /// <summary>
    /// Formulario para Capturar una area Seleccionada.
    /// </summary>
    internal partial class Fondo : Form
    {
        #region Variables Globales
        
        Point origen;
        /// <summary>
        /// Esquina inferior derecha del rectangulo
        /// </summary>
        Point destino;
        /// <summary>
        /// Punto actual donde damos clic
        /// </summary>
        Point actual;
        /// <summary>
        /// Dibuja el Area que estamos seleccionando para copiar
        /// </summary>
        Graphics area_seleccionada;
        /// <summary>
        /// Objeto necesario para dibujar el rectangulo actual en la pantalla
        /// </summary>
        Pen lapiz_actual = new Pen(Color.OrangeRed, 1);
        /// <summary>
        /// Objeto necesario para borrar el rectangulo anterior en la pantalla
        /// </summary>
        Pen lapiz_anterior = new Pen(Color.WhiteSmoke, 1);
        /// <summary>
        /// Indica si fue presionado el botón Izquierda del ratón
        /// </summary>
        bool boton_izq;
        internal Image imagen_seleccionada = null;
        #endregion
        
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        internal Fondo()
        {
            InitializeComponent();            
            this.Bounds = Screen.GetBounds(this.ClientRectangle);            
            origen = new Point(0, 0);
            destino = new Point(0, 0);
            actual = new Point(0, 0);           
            area_seleccionada = this.CreateGraphics();            
            lapiz_actual.DashStyle = DashStyle.Dot;            
            boton_izq = false;            
            this.MouseDown += new MouseEventHandler(mouse_Click);
            this.MouseUp += new MouseEventHandler(mouse_Up);
            this.MouseMove += new MouseEventHandler(mouse_Move);
        }

        #region Metodos
        private void captura_area_seleccionada()
        {
            try
            {
                Rectangle seleccion = new Rectangle(origen.X, origen.Y, destino.X - origen.X, destino.Y - origen.Y);
                using (Bitmap b = new Bitmap(seleccion.Width, seleccion.Height))
                {
                    using (Graphics g = Graphics.FromImage(b))
                    {
                        g.CopyFromScreen(origen, Point.Empty, seleccion.Size);
                        b.Save(string.Format(@"{0}\temp.png", cConexion.Ruta), ImageFormat.Png);
                    }
                }
            }
            catch (InvalidEnumArgumentException ieae)
            {
                MessageBox.Show(ieae.ToString());
            }
            catch (Win32Exception we)
            {
                MessageBox.Show(we.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.Show();
            }
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Captura el punto en el cual se hace la selección tanto del origen como del destino.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mouse_Click(object sender, MouseEventArgs e)
        {            
            if (e.Button == MouseButtons.Left)
            {                
                boton_izq = true;                
                actual = e.Location;
                area_seleccionada.Clear(Color.WhiteSmoke);
            }
        }

        /// <summary>
        /// Mediante este evento podemos realizar la selección del Area a copiar.
        /// 
        /// Es necesario borrar primero el rectangulo anterior y posteriormente se dibuja el rectangulo nuevo; 
        /// en caso de que no realicemos el borrado anterior se va quedando el rectangulo previamente dibujado
        /// y da un efecto de sombra y para el efecto que necesitamos no es funcional de esta manera.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mouse_Move(object sender, MouseEventArgs e)
        {
            if (boton_izq)
            {                
                area_seleccionada.DrawRectangle(lapiz_anterior, origen.X, origen.Y, destino.X - origen.X, destino.Y - origen.Y);
                if (Cursor.Position.X < actual.X)
                {
                    origen.X = Cursor.Position.X;
                    destino.X = actual.X;
                }
                else
                {
                    origen.X = actual.X;
                    destino.X = Cursor.Position.X;
                }

                if (Cursor.Position.Y < actual.Y)
                {
                    origen.Y = Cursor.Position.Y;
                    destino.Y = actual.Y;
                }
                else
                {
                    origen.Y = actual.Y;
                    destino.Y = Cursor.Position.Y;
                }                
                area_seleccionada.DrawRectangle(lapiz_actual, origen.X, origen.Y, destino.X - origen.X, destino.Y - origen.Y);
            }
        }

        /// <summary>
        /// Detecta el momento en el que el botón izquierdo es liberado; es decir, la selección del Area a copiar es finalizada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mouse_Up(object sender, MouseEventArgs e)
        {           
            if (e.Button == MouseButtons.Left)
            {                
                boton_izq = false;                
                this.Hide();
                this.captura_area_seleccionada();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
        #endregion     
    }
}
