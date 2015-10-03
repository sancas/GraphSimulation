using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Threading;

namespace GraphSimulation
{
    public partial class Form1 : Form
    {
        private CGrafo grafo; // instanciamos la clase CGrafo
        private CVertice nuevoNodo; // instanciamos la clase CVertice
        private CVertice NodoOrigen; // instanciamos la clase CVertice
        private CVertice NodoDestino; // instanciamos la clase CVertice
        private int var_control = 0; // la utilizaremos para determinar el estado en la pizarra:
        // 0 -> sin acción, 1 -> Dibujando arco, 2 -> Nuevo vértice
        // variables para el control de ventanas modales
        private Vertice ventanaVertice; // ventana para agregar los vértices
        private Arco ventanaArco; // ventana para agregar los arcos
        private Recorrido ventanaRecorrido; // ventana para seleccionar el nodo inicial del recorrido

        public Form1()
        {
            InitializeComponent();
            grafo = new CGrafo();
            nuevoNodo = null;
            var_control = 0;
            ventanaVertice = new Vertice();
            ventanaArco = new Arco();
            ventanaRecorrido = new Recorrido();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

        }

        private void btnNewFile_Click(object sender, EventArgs e)
        {
            pbCanvas.Width = panel1.Width / 2;
            pbCanvas.Height = panel1.Height;
            pbCanvas.Left = (panel1.Width - pbCanvas.Width) / 2;
            pbCanvas.Enabled = true;
            pbCanvas.Visible = true;
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\"Save File\" Clicked");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\"Print\" Clicked");
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            pbCanvas.Size += new Size(100, 100);
            pbCanvas.Left = (panel1.Width - pbCanvas.Width) / 2;
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            pbCanvas.Size += new Size(-100, -100);
            pbCanvas.Left = (panel1.Width - pbCanvas.Width) / 2;
        }

        private void btnZoomAdjust_Click(object sender, EventArgs e)
        {
            pbCanvas.Width = panel1.Width / 2;
            pbCanvas.Height = panel1.Height;
            pbCanvas.Left = (panel1.Width - pbCanvas.Width) / 2;
        }

        private void btnNewNode_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Cross;
            nuevoNodo = new CVertice();
            var_control = 2; // recordemos que es usado para indicar el estado en la pizarra: 0 ->
            // sin accion, 1 -> Dibujando arco, 2 -> Nuevo vértice
        }

        private void btnDelNode_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\"Delete Node\" Clicked");
        }

        private void btnMoveNode_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\"Move Node\" Clicked");
        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                grafo.DibujarGrafo(e.Graphics);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pbCanvas_MouseLeave(object sender, EventArgs e)
        {
            pbCanvas.Refresh();
        }

        private void pbCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            switch (var_control)
            {
                case 1: // Dibujando arco
                    ventanaArco.Visible = false;
                    ventanaArco.control = false;
                    if ((NodoDestino = grafo.DetectarPunto(e.Location)) != null && NodoOrigen != NodoDestino)
                    {
                        ventanaArco.ShowDialog();
                        if (ventanaArco.control)
                        {
                            if (grafo.AgregarArco(NodoOrigen, NodoDestino)) //Se procede a crear la arista
                            {
                                int distancia = int.Parse(ventanaArco.txtArco.Text); ;
                                NodoOrigen.ListaAdyacencia.Find(v => v.nDestino == NodoDestino).peso = distancia;
                            }
                        }
                    }
                    var_control = 0;
                    NodoOrigen = null;
                    NodoDestino = null;
                    pbCanvas.Refresh();
                    break;
            }
        }

        private void pbCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            switch (var_control)
            {
                case 2: //Creando nuevo nodo
                    if (nuevoNodo != null)
                    {
                        int posX = e.Location.X;
                        int posY = e.Location.Y;
                        if (posX < nuevoNodo.Dimensiones.Width / 2)
                            posX = nuevoNodo.Dimensiones.Width / 2;
                        else if (posX > pbCanvas.Size.Width - nuevoNodo.Dimensiones.Width / 2)
                            posX = pbCanvas.Size.Width - nuevoNodo.Dimensiones.Width / 2;
                        if (posY < nuevoNodo.Dimensiones.Height / 2)
                            posY = nuevoNodo.Dimensiones.Height / 2;
                        else if (posY > pbCanvas.Size.Height - nuevoNodo.Dimensiones.Width / 2)
                            posY = pbCanvas.Size.Height - nuevoNodo.Dimensiones.Width / 2;
                        nuevoNodo.Posicion = new Point(posX, posY);
                        pbCanvas.Refresh();
                        nuevoNodo.DibujarVertice(pbCanvas.CreateGraphics());
                    }
                    break;
                case 1: // Dibujar arco
                    AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 4, true);
                    bigArrow.BaseCap = System.Drawing.Drawing2D.LineCap.Triangle;
                    pbCanvas.Refresh();
                    pbCanvas.CreateGraphics().DrawLine(new Pen(Brushes.Black, 2)
                    {
                        CustomEndCap = bigArrow
                    },
                        NodoOrigen.Posicion, e.Location);
                    break;
            }
        }

        private void pbCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) // Si se ha presionado el botón
            // izquierdo del mouse
            {
                if ((NodoOrigen = grafo.DetectarPunto(e.Location)) != null)
                {
                    var_control = 1; // recordemos que es usado para indicar el estado en la pizarra:
                    // 0 -> sin accion, 1 -> Dibujando arco, 2 -> Nuevo vértice
                }
                if (nuevoNodo != null && NodoOrigen == null)
                {
                    ventanaVertice.Visible = false;
                    ventanaVertice.control = false;
                    grafo.AgregarVertice(nuevoNodo);
                    ventanaVertice.ShowDialog();
                    if (ventanaVertice.control)
                    {
                        if (grafo.BuscarVertice(ventanaVertice.txtVertice.Text) == null)
                        {
                            nuevoNodo.Valor = ventanaVertice.txtVertice.Text;
                        }
                        else
                        {
                            MessageBox.Show("El Nodo " + ventanaVertice.txtVertice.Text + " ya existe en el grafo ", "Error nuevo Nodo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    var_control = 0;
                    nuevoNodo = null;
                    this.Cursor = Cursors.Default;
                    pbCanvas.Refresh();
                }
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right) // Si se ha presionado el botón
            // derecho del mouse
            {
                if (var_control == 0)
                {
                    if ((NodoOrigen = grafo.DetectarPunto(e.Location)) != null)
                    {
                        CMSCrearVertice.Text = "Nodo " + NodoOrigen.Valor;
                    }
                    else
                        pbCanvas.ContextMenuStrip = this.CMSCrearVertice;
                }
            }
        }

        private void nuevoVerticeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnNewNode.PerformClick();
        }

        private void RecorridoAnchura(CVertice nodo)
        {
            CVertice temp = new CVertice();
            nodo.Visitado = true;
            nodo.Padre = null;
            Queue<CVertice> cola = new Queue<CVertice>();
            cola.Enqueue(nodo);
            grafo.Colorear(nodo);
            pbCanvas.Refresh();
            Thread.Sleep(1000);
            while (cola.Count != 0)
            {
                temp = cola.Dequeue();
                foreach (CArco arco in temp.ListaAdyacencia)
                {

                    if (arco.nDestino.Visitado == false)
                    {
                        arco.nDestino.Visitado = true;
                        arco.nDestino.Padre = temp;
                        grafo.Colorear(arco.nDestino);
                        pbCanvas.Refresh();
                        Thread.Sleep(1000);
                        cola.Enqueue(arco.nDestino);
                    }
                }
            }
        }

        private void RecorridoProfundidad(CVertice nodo)
        {
            CVertice temp = new CVertice();
            Stack<CVertice> pila = new Stack<CVertice>();
            pila.Push(nodo);
            while (pila.Count != 0)
            {
                temp = pila.Pop();
                if (temp.Visitado == false)
                {
                    temp.Visitado = true;
                    grafo.Colorear(temp);
                    pbCanvas.Refresh();
                    Thread.Sleep(1000);
                    foreach (CArco arco in temp.ListaAdyacencia)
                    {
                        pila.Push(arco.nDestino);
                    }
                }
            }
        }

        private void btnRecorridoAnchura_Click(object sender, EventArgs e)
        {
            Graphics graficoTemporal = pbCanvas.CreateGraphics();
            ventanaRecorrido.Visible = false;
            ventanaRecorrido.control = false;
            ventanaRecorrido.ShowDialog();
            if (ventanaRecorrido.control)
            {
                if (grafo.BuscarVertice(ventanaRecorrido.txtNodo.Text) != null)
                {
                    RecorridoAnchura(grafo.BuscarVertice(ventanaRecorrido.txtNodo.Text));
                }
                else
                {
                    MessageBox.Show("El Nodo " + ventanaVertice.txtVertice.Text + " No se encuentra en el grafo", "Error Nodo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            grafo.ReestablecerGrafo(graficoTemporal);
            pbCanvas.Refresh();
        }

        private void btnRecorridoProfundidad_Click(object sender, EventArgs e)
        {
            Graphics graficoTemporal = pbCanvas.CreateGraphics();
            ventanaRecorrido.Visible = false;
            ventanaRecorrido.control = false;
            ventanaRecorrido.ShowDialog();
            if (ventanaRecorrido.control)
            {
                if (grafo.BuscarVertice(ventanaRecorrido.txtNodo.Text) != null)
                {
                    RecorridoProfundidad(grafo.BuscarVertice(ventanaRecorrido.txtNodo.Text));
                }
                else
                {
                    MessageBox.Show("El Nodo " + ventanaVertice.txtVertice.Text + " No se encuentra en el grafo", "Error Nodo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            grafo.ReestablecerGrafo(graficoTemporal);
            pbCanvas.Refresh();
        }
    }
}
