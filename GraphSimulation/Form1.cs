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
using System.Diagnostics;

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
        private string recorrido;//variable que guarda el recorrido que se realizo 
        private Stopwatch Duracion; // variable tipo Stopwatch para determinar el tiempo de los algoritmos
        private Eliminarcs eliminarnodo; //Ventana Eliminarcs para varios usos con los algoritmos y recorridos
        private SaveFileDialog VentanaGuardar; //Ventana para seleccionar donde guardar el grafo
        private OpenFileDialog VentanaCargar; //Ventana para seleccionar el grafo a cargar
        private int aristas = 0, nodos = 0; //Enteros para almacenar cantidad de nodos y aristas en el grafo
        private int numeronodos = 0, opc; //Enteros para definir las diferentes opciones y el numero de nodos
        private Label[] arreglo, arreglo2; //Arreglos de Label se usan para la simulacion de la cola, pila y vector
        private List<CVertice> nodosRuta; // Lista de nodos utilizada para almacenar la ruta
        private bool buscarRuta = false; //Auxiliar para el algoritmo de Warshall
        private double peso = 0.0; //Peso minimo para Warshall
        private NuevoGrafo miGrafo; //ventana para crear un nuevo grafo
        private AgregarArcos nuevoArco; //ventana para agregar nuevas aristas
        private bool EsDigrafo; //Booleano para saber si el grafo es digrafo o no
        private bool loading; //Si se esta cargando un archivo
        private bool opening; //Si se esta abriendo un archivo
        private int tiempo; //Tiempo para la simulacion
        private string filePath; //Direccion del archivo a cargar

        public Form1()
        {
            InitializeComponent();
            nuevoNodo = null;
            var_control = 0;
            ventanaVertice = new Vertice();
            ventanaArco = new Arco();
            ventanaRecorrido = new Recorrido();
            Duracion = new Stopwatch();
            miGrafo = new NuevoGrafo();
            nuevoArco = new AgregarArcos();
            loading = false;
            opening = false;
            tiempo = 100;
            recorrido = "";
            VentanaGuardar = new SaveFileDialog();
            VentanaCargar = new OpenFileDialog();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnSaveFile.Enabled = false;
            btnQuickSaveFile.Enabled = false;
            btnDelNode.Enabled = false;
            btnNewNode.Enabled = false;
            rbnEliminarArista.Enabled = false;
            rbnRestaurar.Enabled = false;
            rbnWarshall.Enabled = false;
            rbnDijk.Enabled = false;
            btnRecorridoAnchura.Enabled = false;
            btnRecorridoProfundidad.Enabled = false;
            rbnBAgregarArista.Enabled = false;
            rbnBKruskal.Enabled = false;
            rbnBPrim.Enabled = false;
            rbnWarshallND.Enabled = false;
            splitContainer1.Panel2Collapsed = true;
            lbRecorrido.Text = "";
            label1.Text = "";
            label2.Text = "";
            label4.Text = "";
            if (opening) //Si se esta abriendo desde archivo
            {
                btnLoadFile.PerformClick(); //Simular un click al boton cargar archivo
                opening = false; //Abriendo regresa a ser falso
            }
        }

        public void OpenFile(string filePath)
        {
            opening = true; //Se marca la bandera opening como verdadero
            this.filePath = filePath; //Se guarda la ruta del archivo
        }

        protected void HabilitarControles() //Habilitar controles comunes
        {
            rbnEliminarArista.Enabled = true;
            rbnWarshall.Enabled = true;
            rbnDijk.Enabled = true;
            rbnBPrim.Enabled = true;
            rbnBKruskal.Enabled = true;
            rbnWarshallND.Enabled = true;
            btnRecorridoAnchura.Enabled = true;
            btnRecorridoProfundidad.Enabled = true;
            rbnBAgregarArista.Enabled = true;
        }

        protected void DesHabilitarControles() //Deshabilitar controles comunes
        {
            rbnEliminarArista.Enabled = false;
            rbnWarshall.Enabled = false;
            rbnDijk.Enabled = false;
            rbnBKruskal.Enabled = false;
            rbnBPrim.Enabled = false;
            rbnWarshallND.Enabled = false;
            btnRecorridoAnchura.Enabled = false;
            btnRecorridoProfundidad.Enabled = false;
            rbnBAgregarArista.Enabled = false;
        }

        private void btnNewFile_Click(object sender, EventArgs e)
        {
            if(!loading) //Si no se esta cargando
                miGrafo.ShowDialog(); //Mostrar el dialogo para crear un nuevo grafo
            if (miGrafo.control || loading) //Si el dialogo regreso true o si se esta cargando
            {
                if (loading) //Si se esta cargando
                {
                    if (grafo.DiGrafo) //Si es un grafo dirigido
                    {
                        rbPDigrafos.Visible = true; //Habilitar el panel de Digrafos
                        rbPNoDigrafos.Visible = false; //Deshabilitar el panel de no Digrafos
                        EsDigrafo = true; //Guardar que es digrafo
                    }
                    else //Si no es dirigido
                    {
                        rbPNoDigrafos.Visible = true; //Habilitar el panel de no Digrafos
                        rbPDigrafos.Visible = false; //Deshabilitar el panel de Digrafos
                        EsDigrafo = false; //Guardar que no es digrafo
                    }
                }
                else if (miGrafo.rbtnDigrafo.Checked) //Sino se esta cargando, Si se chequeo que es digrafo
                {
                    grafo = new CGrafo(true); //Crear un grafo digrafo
                    rbPDigrafos.Visible = true;
                    rbPNoDigrafos.Visible = false;
                    EsDigrafo = true;
                }
                else if (miGrafo.rbtnNoDigrafo.Checked) //Sino si se chequeo 
                {
                    grafo = new CGrafo(false); //Crear un grafo no dirigido
                    rbPNoDigrafos.Visible = true;
                    rbPDigrafos.Visible = false;
                    EsDigrafo = false;
                }
                pbCanvas.Dock = DockStyle.Fill; //Le decimos al Canvas que abarque todo el espacio
                pbCanvas.Enabled = true; //Lo habilitamos
                pbCanvas.Visible = true; //Lo hacemos visible
                btnSaveFile.Enabled = true; //Activamos el boton guardar grafo
                btnQuickSaveFile.Enabled = true; //Activamos el boton guardar del QuickMenu
                btnNewNode.Enabled = true; //Habilitamos el boton nuevoNodo
            }
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            SaveAndLoad mySave = new SaveAndLoad(); //Instancia de objeto SaveAndLoad

            VentanaGuardar.InitialDirectory = "c:\\"; //Directorio inicial para el SaveDialog
            VentanaGuardar.Filter = "graph files (*.graph)|*.graph"; //Filtro de archivos
            VentanaGuardar.FilterIndex = 2; //Indice del filtr
            VentanaGuardar.RestoreDirectory = true; //Volver a abrir donde se cerro

            DialogResult result = VentanaGuardar.ShowDialog(); //Mostrar la ventana de guardado
            if (result == DialogResult.OK) // Si fue satisfactorio
            {
                string file = VentanaGuardar.FileName; //Guardamosla direccion del archivo
                mySave.WriteToBinaryFile<CGrafo>(file, grafo, false); //Guardamos un archivo .graph
                // en la direccion que cotiene un objeto tipo CGrafo en binario
            }
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            loading = true; //Se marca la bandera cargando como verdadero
            aristas = 0; //El numero de aristas del grafo se resetea
            nodos = 0; //El numero de nodos del grafo se resetea
            SaveAndLoad myLoad = new SaveAndLoad(); //Instancia de objeto SaveAndLoad

            VentanaCargar.InitialDirectory = "c:\\"; //Directorio inicial para el LoadDialog
            VentanaCargar.Filter = "graph files (*.graph)|*.graph"; //Filtro de archivos
            VentanaCargar.FilterIndex = 2; //Indice del filtro
            VentanaCargar.RestoreDirectory = true; //Volver a abrir donde se cerro

            DialogResult result;
            if (!opening)
                result = VentanaCargar.ShowDialog(); //Mostrar la ventana de carga
            else
                result = DialogResult.OK;
            if (result == DialogResult.OK) // Si fue satisfactorio
            {
                string file;
                if (opening)
                    file = filePath;
                else
                    file = VentanaCargar.FileName; //Guardamos la direccion del archivo
                grafo = myLoad.ReadFromBinaryFile<CGrafo>(file); //Convertimos de binario a CGrafo con la clase SaveAndLoad
                miGrafo.control = true; //Marcamos la varible como true
                btnNewFile.PerformClick(); //Simulamos un click en el boton NewFile
                grafo.DibujarGrafo(pbCanvas.CreateGraphics()); //Dibujamos el grafo cargado en el Canvas
                numeronodos = grafo.nodos.Count; //Actualizamos el numero de nodos
                foreach (CVertice nodo in grafo.nodos)
                {
                    nodos++;
                    foreach (CArco a in nodo.ListaAdyacencia)
                        aristas++;
                }
            }
            if (nodos != 0) //Si el grafo tiene nodos
            {
                btnDelNode.Enabled = true; //Habilitar el boton borrar nodo
                rbnBAgregarArista.Enabled = true; //Habilitar el boton agregar arista
                if (aristas != 0) //Si tiene aristas
                {
                    rbnEliminarArista.Enabled = true; //Habilitar el boton eliminar arista
                    rbnWarshall.Enabled = true; //Habilitar el boton del algoritmo Warshall
                    rbnDijk.Enabled = true; //Habilitar el boton del algoritmo Dijkstra
                    rbnBKruskal.Enabled = true; //Habilitar el boton del algoritmo Kruskal
                    rbnBPrim.Enabled = true; //Habilitar el boton del algoritmo Prim
                    rbnWarshallND.Enabled = true; //Habilitar el boton del algoritmo Warshall no dirigido
                    btnRecorridoAnchura.Enabled = true; //Habilitar recorrido anchura
                    btnRecorridoProfundidad.Enabled = true; //Habilitar recorrido profundidad
                }
            }
            loading = false; //Ya no se esta cargando
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            System.Drawing.Printing.PrintDocument myPrintDocument1 = new System.Drawing.Printing.PrintDocument(); //Se crea un nuevo documento de impresion
            PrintDialog myPrinDialog1 = new PrintDialog(); //Se crea un dialogo para la impresion
            myPrintDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(myPrintDocument1_PrintPage); //Se agrega el evento printpage al documento creado
            myPrinDialog1.Document = myPrintDocument1; //El documento a trabajar con el dialogo es el anterior

            if (myPrinDialog1.ShowDialog() == DialogResult.OK) //Si todo salio bien
            {
                myPrintDocument1.Print(); //Imprimir el documento
            }
        }

        private void myPrintDocument1_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Size Tamanho = new Size(); //Tamaño es igual a un nuevo Size
            Bitmap myBitmap1 = new Bitmap(pbCanvas.Width, pbCanvas.Height); //Creamos un bitmap con las dimensiones del canvas
            pbCanvas.DrawToBitmap(myBitmap1, new Rectangle(0, 0, pbCanvas.Width, pbCanvas.Height)); //Dibujamos hacia el bitmap creado con las proporciones del canvas
            Tamanho = new Size(myBitmap1.Width, myBitmap1.Height); //El tamaño es igual al tamaño del bitmap
            while (Tamanho.Width > 600 || Tamanho.Height > 900) //Mientras el tamaño sobrepasa el de una hoja A4
                Tamanho = new Size(Tamanho.Width / 2, Tamanho.Height / 2); //Se reduce el tamaño a la mitad
            myBitmap1 = ResizeBitmap(myBitmap1, Tamanho.Width, Tamanho.Height); //Se actualiza el tamaño del bitmap al nuevo que quepa en una hoja A4
            e.Graphics.DrawImage(myBitmap1, 0, 0); //Dibujar el graphic en el bitmap;
            myBitmap1.Dispose(); //Se destruye el objeto
        }

        private void txtTime_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (txtTime.TextBoxText.Trim() == "") //Si no hay texto
                tiempo = 0; //No hay simulacion
            else //Sino
            {
                int.TryParse(txtTime.TextBoxText, out tiempo); //Intentar conventir a entero y guardar en tiempo
            }
        }

        private void txtTime_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            //Solo permitir numeros
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private Bitmap ResizeBitmap(Bitmap sourceBMP, int width, int height)
        {
            Bitmap result = new Bitmap(width, height); //Creamos otro bitmap resultado con las nuevas dimensiones
            using (Graphics g = Graphics.FromImage(result)) //Se crea un graphic a partir de una imagen
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor; //Asignamos el modo de interpolacion
                g.DrawImage(sourceBMP, 0, 0, width, height); //Se dibuja el bitmap con el nuevo tamaño
            }
            return result; //Se regresa el bitmap redimensionado
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
            eliminarnodo = new Eliminarcs(1); //eliminarnodo crea una ventana Eliminarcs con el valor de 1
            eliminarnodo.Visible = false; //Se actualiza el dato Visible
            eliminarnodo.control = false; //Se asigna false a control antes de mostrar el form
            eliminarnodo.ShowDialog(); //Muestra el dialogo para eliminar un nodo
            if (eliminarnodo.control)
            {
                if (grafo.BuscarVertice(eliminarnodo.txteliminar.Text.Trim()) != null) //si se encuentra el nodo
                {
                    grafo.ELiminarNodo(eliminarnodo.txteliminar.Text.Trim()); //Elimina un nodo con tener el valor string de este
                    grafo.RestablecerGrafo(pbCanvas.CreateGraphics()); //Se reestablece el grafo y se redibuja para quitar el nodo
                    pbCanvas.Refresh(); //Se refresca el canvas
                }
                else //si no
                {
                    MessageBox.Show("El nodo No se encuentra en el grafo",
                   "Error Nodo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            aristas = 0;
            foreach (CVertice nodo in grafo.nodos)
            {
                foreach (CArco a in nodo.ListaAdyacencia)
                    aristas++;
            }
            if (grafo.nodos.Count == 0)
            {
                DesHabilitarControles();
            }
            if (aristas == 0)
            {
                DesHabilitarControles();
            }
        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality; //Seleccionamos el modo Smoothing
                grafo.DibujarGrafo(e.Graphics); //Dibujamos el grafo desde el metodo de la clase CGrafo enviando el Graphics
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); //Se muestra el error si da error
            }
        }

        private void pbCanvas_MouseLeave(object sender, EventArgs e)
        {
            pbCanvas.Refresh(); //Refrescar el canvas cuando se deja el canvas
            this.Cursor = Cursors.Default; //Se cambia el cursos a default
        }

        private void rbnBAgregarArista_Click(object sender, EventArgs e)
        {
            List<string> miLista = new List<string>(); //Se crea una lista de tipo string
            foreach(CVertice cv in grafo.nodos)
            {
                miLista.Add(cv.Valor.ToString()); //Se agregan los valores de los vertices
            }
            nuevoArco.Refresh(miLista); //Se actualizan los datos en la ventanan Nuevo arco
            nuevoArco.ShowDialog(); //Se muestra la ventana nuevo Arco
            if (nuevoArco.control) //Si todo fue bien
            {
                NodoOrigen = grafo.BuscarVertice(nuevoArco.cmbNodoInicial.Text); //Nodo origen es igual al seleccionado
                NodoDestino = grafo.BuscarVertice(nuevoArco.cmbNodoFinal.Text); //Nodo destino es igual al seleccionado
                if (grafo.AgregarArco(NodoOrigen, NodoDestino)) //Se procede a crear la arista
                {
                    int distancia = int.Parse(nuevoArco.txtValor.Text); //Se guarda el peso de la arista
                    NodoOrigen.ListaAdyacencia.Find(v => v.nDestino == NodoDestino).peso = distancia; //Se busca la arista recien creada y se le asigna el peso anterior
                    if (!EsDigrafo) //Si no es digrafo
                        NodoDestino.ListaAdyacencia.Find(v => v.nDestino == NodoOrigen).peso = distancia; //Se asigna el peso a ambos lados
                    HabilitarControles(); //Se habilitan los controles comunes
                }
            }
            NodoOrigen = null; //NodoOrigen se setea con null
            NodoDestino = null; //NodoDestino se setea con null
            pbCanvas.Refresh(); //Se refresca el Canvas
        }

        private void pbCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            switch (var_control)
            {
                case 1: // Dibujando arco
                    this.Cursor = Cursors.Cross; //Se cambia el cursos a una cruz
                    ventanaArco.Visible = false; //Se actualiza el dato Visible
                    ventanaArco.control = false; //Se setea la variable de control por defecto false
                    if ((NodoDestino = grafo.DetectarPunto(e.Location)) != null && NodoOrigen != NodoDestino) //Si el nodoDestino esta donde se encuentra el mouse y el nodo origen es distinto del nodo destino
                    {
                        ventanaArco.ShowDialog(); //Se muestra la ventana para crear un nuevo arco
                        if (ventanaArco.control) //Si todo fue bien
                        {
                            if (grafo.AgregarArco(NodoOrigen, NodoDestino)) //Se procede a crear la arista
                            {
                                int distancia = int.Parse(ventanaArco.txtArco.Text); //Se guarda el peso de la arista
                                NodoOrigen.ListaAdyacencia.Find(v => v.nDestino == NodoDestino).peso = distancia; //Se busca la arista recien creada y se le aisigna el peso anterior
                                if (!EsDigrafo) //Si no es digrafo
                                    NodoDestino.ListaAdyacencia.Find(v => v.nDestino == NodoOrigen).peso = distancia; //Se asigna el peso a ambos lados
                                HabilitarControles(); //Se habilitan los controles comunes
                            }
                        }
                        
                    }
                    var_control = 0; //Origen set = 0
                    NodoOrigen = null; //NodoORigen se setea con null
                    NodoDestino = null; //NodoDestino se setea con nodo null
                    pbCanvas.Refresh(); //Se refresca el canvas
                    break;
            }
        }

        private void pbCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            switch (var_control)
            {
                case 2: //Creando nuevo nodo
                    if (nuevoNodo != null) //Si el nuevoNodo no es nulo
                    { 
                        int posX = e.Location.X; //PosX es igual a la posicion x del mouse
                        int posY = e.Location.Y; //PosY es igual a la posicion y del mouse
                        if (posX < nuevoNodo.Dimensiones.Width / 2) //Si la posicion en x es menor que las dimensiones del nuevonodo
                            posX = nuevoNodo.Dimensiones.Width / 2; //La nueva posicionX es la anchura del form entre 2
                        else if (posX > pbCanvas.Size.Width - nuevoNodo.Dimensiones.Width / 2) //Sino Si la posicionX es mayor que tamaño del cambas menos el de las nuevas dimensiones
                            posX = pbCanvas.Size.Width - nuevoNodo.Dimensiones.Width / 2; //La nueva posicionX es igual a el tamaño del canvas menos las dimensiones del nodo entre dos
                        if (posY < nuevoNodo.Dimensiones.Height / 2) //Si la posicion en Y es menor que las dimensiones height del nodo
                            posY = nuevoNodo.Dimensiones.Height / 2; //La nueva posicion Y es igual a las dimensiones height del nodo entre dos
                        else if (posY > pbCanvas.Size.Height - nuevoNodo.Dimensiones.Width / 2) //Sino si la posicionY es mayor que tamaño height del canvas menos la dimension width del nodo entre 2
                            posY = pbCanvas.Size.Height - nuevoNodo.Dimensiones.Width / 2; //La nueva posicionY es igual al tamaño height del cambas menos la dimension width del nodo entre dos
                        nuevoNodo.Posicion = new Point(posX, posY); //La posicion del nuevo nodo es igual a un punto (posicionX, posicionY)
                        pbCanvas.Refresh(); //Se refresca el canvas
                        nuevoNodo.DibujarVertice(pbCanvas.CreateGraphics()); //Se dibuja el nuevo vertice
                    }
                    break;
                case 1: // Dibujar arco
                    this.Cursor = Cursors.Cross; //Se cambia el cursor a una cruz
                    AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 4, true); //Crear una flecha
                    bigArrow.BaseCap = System.Drawing.Drawing2D.LineCap.Triangle; //Triangular
                    pbCanvas.Refresh(); //Refrescar en c#
                    pbCanvas.CreateGraphics().DrawLine(new Pen(Brushes.Black, 2) //Crear la linea
                    {
                        CustomEndCap = bigArrow //Con punta rectangular
                    },
                        NodoOrigen.Posicion, e.Location); //La posicion del nodoOrigen
                    //this.Cursor = Cursors.Default;
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
                if (nuevoNodo != null && NodoOrigen == null) //Si hay un nodo origen pero no hay nuevonodo
                {
                    ventanaVertice.Visible = false; //Se marca la propiedad Visible de la venta Vertica como false
                    ventanaVertice.control = false; //La variable de control se inicializa con false
                    grafo.AgregarVertice(nuevoNodo); //Se agrega un nuevo nodo al grafo
                    btnDelNode.Enabled = true; //Se habilita el boton eliminar nodo
                    rbnBAgregarArista.Enabled = true; //Se haabilita el boton agregar arista
                    numeronodos = grafo.nodos.Count;//cuenta cuantos nodos hay en el grafo      
                    ventanaVertice.ShowDialog(); //Se muestra la ventana nuevo nodo
                    if (ventanaVertice.control) //Si todo fue bien
                    {
                        if (grafo.BuscarVertice(ventanaVertice.txtVertice.Text) == null) //Si un nodo con el mismo valor no existe en el grafo
                        {
                            nuevoNodo.Valor = ventanaVertice.txtVertice.Text; //Se agrega el nuevo valor nuevo nodo
                        }
                        else //sino Error
                        {
                            MessageBox.Show("El Nodo " + ventanaVertice.txtVertice.Text + " ya existe en el grafo ", "Error nuevo Nodo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            grafo.ELiminarNodo("");
                        }
                    }
                    else //Si no fue bien
                    {
                        grafo.ELiminarNodo(ventanaArco.txtArco.Text);  //Se elimina el nodo recien creado
                        grafo.RestablecerGrafo(pbCanvas.CreateGraphics()); //Se reestablece el grafo
                        pbCanvas.Refresh(); //Se refresca el canvas
                    }
                    var_control = 0; //variable de control con valor 0
                    nuevoNodo = null; //nuevoNodo se setea con null
                    this.Cursor = Cursors.Default; //Se cambia el cursor al default
                    pbCanvas.Refresh(); //Se refresca el canvas
                }
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right) // Si se ha presionado el botón
            // derecho del mouse
            {
                if (var_control == 0) //Si la variable de control es 0
                {
                    if ((NodoOrigen = grafo.DetectarPunto(e.Location)) != null)
                    {
                        CMSCrearVertice.Text = "Nodo " + NodoOrigen.Valor;
                    }
                    else
                        pbCanvas.ContextMenuStrip = this.CMSCrearVertice; //Se abre el menu strip cmscrear vertice
                }
            }
        }//agrega nodo

        private void nuevoVerticeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnNewNode.PerformClick();
        }

        private void btnRecorridoAnchura_Click(object sender, EventArgs e)
        {
            Graphics graficoTemporal = pbCanvas.CreateGraphics(); //Se guarda el graphic en una variable temporal
            ventanaRecorrido.Visible = false; //Se define el visible de la ventana recorrido como false
            ventanaRecorrido.control = false; //Se define la variable de control de la ventana recorrido como false
            ventanaRecorrido.ShowDialog(); //Se muestra la ventana Recorrido
            if (ventanaRecorrido.control) //Si todo fue bien
            {
                if (grafo.BuscarVertice(ventanaRecorrido.txtNodo.Text) != null) //Si el grafo seleccionado se encuentra
                {
                    splitContainer1.Panel2Collapsed = false; //Decoplar el panel2 del splitcontainer
                    splitContainer1.SplitterDistance = (int)(this.Width * 0.75); //Asiganar una distancia equivalente a la ventana
                    PnSimulador.Refresh(); //Refrescar el simulador
                    PnSimulador.Visible = true; //Hacer visible el panel simulador
                    double t = 0; //Variable t para el tiempo
                    recorrido = ""; //String recorrido que almacena el recorrido del los nodos
                    Duracion.Start(); //Se comienza a contar
                    RecorridoAnchura(grafo.BuscarVertice(ventanaRecorrido.txtNodo.Text)); //Se hace el recorrido en anchura
                    Duracion.Stop(); //Se detiene el tiempo :O
                    t = Duracion.ElapsedMilliseconds / 1000; //El tiempo es lo que duro en milisegundos sobre 1000 o sea en segundos
                    label4.Text = "El tiempo recorrido es de: " + t.ToString() + "seg"; //Se muestra el valor de tiempo
                    MessageBox.Show("El recorrido por anchura fue: " +  recorrido + "\n Y la duracion del recorrido fue de: " + Duracion.ElapsedMilliseconds + " miliSegundos"); //Los datos del recorrido
                    Duracion.Reset(); //Se resetea el cronometro
                }
                else //Sino Error
                {
                    MessageBox.Show("Ese Nodo no se encuentra en el grafo", "Error Nodo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            Thread.Sleep(tiempo); //Dormir un rato
            grafo.RestablecerGrafo(graficoTemporal); //Reestablecer grafo
            pbCanvas.Refresh(); //Refrescar canvas
        }

        private void btnRecorridoProfundidad_Click(object sender, EventArgs e)
        {
            Graphics graficoTemporal = pbCanvas.CreateGraphics(); //Se guarda el graphic en una variable temporal
            ventanaRecorrido.Visible = false; //Se define el visible de la ventana recorrido como false
            ventanaRecorrido.control = false; //Se define la variable de control de la ventana recorrido como false
            ventanaRecorrido.ShowDialog(); //Se muestra la ventana Recorrido
            if (ventanaRecorrido.control) //Si todo fue bien
            {
                if (grafo.BuscarVertice(ventanaRecorrido.txtNodo.Text) != null) //Si el grafo seleccionado se encuentra
                {
                    splitContainer1.Panel2Collapsed = false; //Decoplar el panel2 del splitcontainer
                    splitContainer1.SplitterDistance = (int)(this.Width * 0.75); //Asiganar una distancia equivalente a la ventana
                    PnSimulador.Refresh(); //Refrescar el simulador
                    PnSimulador.Visible = true; //Hacer visible el panel simulador
                    double t = 0; //Variable t para el tiempo
                    recorrido = ""; //String recorrido que almacena el recorrido del los nodos
                    Duracion.Start(); //Se comienza a contar
                    RecorridoProfundidad(grafo.BuscarVertice(ventanaRecorrido.txtNodo.Text));
                    Duracion.Stop(); //Se detiene el tiempo :O
                    t = Duracion.ElapsedMilliseconds / 1000; //El tiempo es lo que duro en milisegundos sobre 1000 o sea en segundos
                    label4.Text = "El tiempo recorrido es de: " + t.ToString() + "seg"; //Se muestra el valor de tiempo               
                    MessageBox.Show("El recorrido por profundidad fue: " + recorrido + "\n Y la duracion del recorrido fue de: " + Duracion.ElapsedMilliseconds + " miliSegundos"); //Los datos del recorrido
                    Duracion.Reset(); //Se resetea el cronometro
                }
                else //Sino error
                {
                    MessageBox.Show("Ese Nodo no se encuentra en el grafo", "Error Nodo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            grafo.RestablecerGrafo(graficoTemporal); //Se reestablece el grafo
            pbCanvas.Refresh(); //Se refresca el canvas
        }

        private void rbnDijk_Click(object sender, EventArgs e)
        {
            ventanaRecorrido.Visible = false;
            ventanaRecorrido.control = false;
            ventanaRecorrido.ShowDialog();
            if (ventanaRecorrido.control)
            {
                if (grafo.BuscarVertice(ventanaRecorrido.txtNodo.Text) != null)
                {
                    double t = 0;
                    splitContainer1.Panel2Collapsed = false;
                    splitContainer1.SplitterDistance = (int)(this.Width * 0.75);
                    PnSimulador.Refresh();
                    PnSimulador.Visible = true;
                    grafo.Desmarcar();
                    recorrido = "";
                    Duracion.Start();
                    dijkstra(grafo.BuscarVertice(ventanaRecorrido.txtNodo.Text));
                    Duracion.Stop();
                    t = Duracion.ElapsedMilliseconds / 1000;
                    label1.Text = "El tiempo recorrido es de: " + t.ToString() + "seg";
                    Duracion.Reset();
                }
                else
                {
                    MessageBox.Show("Ese Nodo no se encuentra en el grafo", "Error Nodo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void rbnEliminarArista_Click(object sender, EventArgs e)
        {
            aristas = 0;
            eliminarnodo = new Eliminarcs(2);
            eliminarnodo.Visible = false;
            eliminarnodo.control = false;
            eliminarnodo.ShowDialog();
            if (eliminarnodo.control)
            {
                if (grafo.BuscarVertice(eliminarnodo.txteliminar.Text.Trim()) != null && grafo.BuscarVertice(eliminarnodo.txtelem.Text.Trim()) != null && grafo.Comprobararista(eliminarnodo.txteliminar.Text.Trim(), eliminarnodo.txtelem.Text.Trim()))
                {
                    grafo.ElimiarArco(eliminarnodo.txteliminar.Text.Trim(), eliminarnodo.txtelem.Text.Trim());
                    if (!EsDigrafo)
                        grafo.ElimiarArco(eliminarnodo.txtelem.Text.Trim(), eliminarnodo.txteliminar.Text.Trim());
                    grafo.RestablecerGrafo(pbCanvas.CreateGraphics());
                    pbCanvas.Refresh();
                }
                else
                {
                    MessageBox.Show("No existe esa arista",
                    "Error Nodo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            foreach (CVertice nodo in grafo.nodos)
            {
                foreach (CArco a in nodo.ListaAdyacencia)
                    aristas++;
            }
            if (aristas == 0)
            {
                rbnEliminarArista.Enabled = false;
                rbnRestaurar.Enabled = false;
                rbnWarshall.Enabled = false;
                rbnDijk.Enabled = false;
                btnRecorridoAnchura.Enabled = false;
                btnRecorridoProfundidad.Enabled = false;
                rbnBKruskal.Enabled = false;
                rbnBPrim.Enabled = false;
            }
        }

        private void rbnWarshall_Click(object sender, EventArgs e)
        {
            eliminarnodo = new Eliminarcs(2);
            eliminarnodo.Visible = false;
            eliminarnodo.control = false;
            eliminarnodo.ShowDialog();
            if (eliminarnodo.control)
            {
                if (grafo.BuscarVertice(eliminarnodo.txteliminar.Text.Trim()) != null && grafo.BuscarVertice(eliminarnodo.txtelem.Text.Trim()) != null)
                {
                    rbnRestaurar.Enabled = true;
                    splitContainer1.Panel2Collapsed = false;
                    splitContainer1.SplitterDistance = (int)(this.Width * 0.75);
                    PnSimulador.Refresh();
                    PnSimulador.Visible = true;
                    opc = 4;
                    LblSimu.Text = "Simulacion: Algortimo de Warshall";
                    double t = 0;
                    Duracion.Restart();
                    calcularMatricesIniciales();
                    algoritmoWarshall();
                    obtenerRutaPesoWarshall(eliminarnodo.txteliminar.Text.Trim(), eliminarnodo.txtelem.Text.Trim());
                    if (buscarRuta)
                    {
                        for (int x = 0; x < nodosRuta.Count; x++)
                        {
                            grafo.Colorear(nodosRuta[x]);
                            pbCanvas.Refresh();
                            if (x + 1 < nodosRuta.Count)
                            {
                                grafo.ColoArista(nodosRuta[x].Valor, nodosRuta[x + 1].Valor);
                                if (!EsDigrafo)
                                    grafo.ColoArista(nodosRuta[x + 1].Valor, nodosRuta[x].Valor);
                            }
                            Thread.Sleep(tiempo);
                        }
                        buscarRuta = false;
                    }
                    pbCanvas.Refresh();
                    Duracion.Stop();
                    t = Duracion.ElapsedMilliseconds / 1000;
                    label2.Text = "El peso minimo entre los nodos es: "+ peso.ToString()+"\nEl tiempo recorrido es de: "+t.ToString()+"seg";
                }
                else
                {
                    MessageBox.Show("El nodo No se encuentra en el grafo",
                    "Error Nodo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private void rbnRestaurar_Click(object sender, EventArgs e)
        {
            LblSimu.Text = "Simulador de Grafos";
            label2.Text = "";
            label1.Text = "";
            label4.Text = "";
            lbRecorrido.Text = "";
            grafo.RestablecerGrafo(pbCanvas.CreateGraphics());
            switch (opc) 
            {
                case 1: limpiar(c); break;
                case 2: limpiar(Pila); break;
                case 3: limpiar(arreglo, arreglo2); break;
                case 4: break;
                default: MessageBox.Show("El grafo Esta resturado"); break;

            }
            rbnRestaurar.Enabled = false;
            splitContainer1.Panel2Collapsed = true;
        }

        /*****************************************************************************/
        /*                                 ALGORITMOS                                */
        /*****************************************************************************/
        //Recorrido en anchura
        private Queue<Label> c = new Queue<Label>();
        private void RecorridoAnchura(CVertice nodo)
        {
            rbnRestaurar.Enabled = true;
            opc = 1;
            LblSimu.Text = "Simulacion: Recorrido en Anchura";
            label2.Text = "COLA:";
            label1.Text = "RECORRIDO:";
            CVertice temp = new CVertice();
            nodo.Visitado = true;
            nodo.Padre = null;
            Queue<CVertice> cola = new Queue<CVertice>();
            cola.Enqueue(nodo);
            grafo.Colorear(nodo);
            pbCanvas.Refresh();
            mostrarCola(cola);
            Thread.Sleep(tiempo);
            recorrido += nodo.Valor + " ";
            lbRecorrido.Text = recorrido;
            while (cola.Count != 0)
            {
                temp = cola.Dequeue();
                foreach (CArco arco in temp.ListaAdyacencia)
                {
                    if (arco.nDestino.Visitado == false)
                    {
                        cola.Enqueue(arco.nDestino);
                    }
                }
                mostrarCola(cola);
                foreach (CArco arco in temp.ListaAdyacencia)
                {

                    if (arco.nDestino.Visitado == false)
                    {
                        recorrido += arco.nDestino.Valor + " ";
                        lbRecorrido.Text = recorrido;
                        arco.nDestino.Visitado = true;
                        arco.nDestino.Padre = temp;
                        grafo.Colorear(arco.nDestino);
                        pbCanvas.Refresh();
                        Thread.Sleep(tiempo);
                    }
                }

            }
        }
        private void mostrarCola(Queue<CVertice> q)
        {
            limpiar(c);
            Point xy = new Point(14, 64);
            Queue<Label> colalabel = new Queue<Label>();
            foreach (CVertice n in q)
            {
                Label l = new Label();
                l.Text = n.Valor;
                colalabel.Enqueue(l);
            }
            foreach (Label l in colalabel)
            {
                l.Width = 25;
                l.Height = 25;
                l.BackColor = Color.White;
                l.ForeColor = Color.Black;
                l.TextAlign = ContentAlignment.MiddleCenter;
                l.Location = xy;
                l.BorderStyle = BorderStyle.FixedSingle;
                PnSimulador.Controls.Add(l);
                xy += new Size(25, 0);
            }
            PnSimulador.Refresh();
            c = colalabel;
        }
        private void limpiar(Queue<Label> labels)
        {
            foreach (Label l in labels)
                PnSimulador.Controls.Remove(l);
        }
        //recorrido en Profundidad
        private Stack<Label> Pila = new Stack<Label>();
        private void RecorridoProfundidad(CVertice nodo)
        {
            rbnRestaurar.Enabled = true;
            opc = 2;
            LblSimu.Text = "Simulacion: Recorrido en Profundidad";
            label2.Text = "Pila:";
            label1.Text = "RECORRIDO:";
            CVertice temp = new CVertice();
            Stack<CVertice> pila = new Stack<CVertice>();
            pila.Push(nodo);
            mostrarPila(pila);
            while (pila.Count != 0)
            {
                mostrarPila(pila);
                temp = pila.Pop();
                if (temp.Visitado == false)
                {
                    recorrido += temp.Valor + " ";
                    lbRecorrido.Text = recorrido;
                    temp.Visitado = true;
                    grafo.Colorear(temp);
                    pbCanvas.Refresh();
                    Thread.Sleep(tiempo);
                    foreach (CArco arco in temp.ListaAdyacencia)
                    {
                        pila.Push(arco.nDestino);
                    }
                }
            }
        }
        private void mostrarPila(Stack<CVertice> p)
        {
            limpiar(Pila);
            Stack<Label> pilaLabels = new Stack<Label>();
            Point xy = new Point(14, 64);
            foreach (CVertice n in p)
            {
                Label l = new Label();
                l.Text = n.Valor;
                pilaLabels.Push(l);
            }
            foreach (Label l in pilaLabels)
            {
                l.Width = 25;
                l.Height = 25;
                l.BackColor = Color.White;
                l.ForeColor = Color.Black;
                l.Location = xy;
                l.TextAlign = ContentAlignment.MiddleCenter;
                l.BorderStyle = BorderStyle.FixedSingle;
                PnSimulador.Controls.Add(l);
                xy += new Size(25, 0);
            }
            PnSimulador.Refresh();
            Pila = pilaLabels;
        }
        private void limpiar(Stack<Label> labels)
        {
            foreach (Label l in labels)
                PnSimulador.Controls.Remove(l);
        }
        // Algortimo de dijkstra   
        private void dijkstra(CVertice inicio)
        {
            if (inicio.ListaAdyacencia.Count != 0)
            {
                rbnRestaurar.Enabled = true;
                opc = 3;
                LblSimu.Text = "Simulacion: Algortimo de Dijkstra";
                label2.Text = "Arreglo de distancias:";
                int n = grafo.nodos.Count;
                arreglo = new Label[numeronodos];
                arreglo2 = new Label[numeronodos];
                foreach (CVertice nodo in grafo.nodos)
                {
                    foreach (CArco a in nodo.ListaAdyacencia)
                    {
                        if (nodo == inicio)
                        {
                            a.nDestino.distancianodo = a.peso;
                            a.nDestino.pesoasignado = true;
                            a.color = Color.LimeGreen;
                            a.grosor_flecha = 4;
                        }
                        else if (nodo != inicio && a.nDestino.pesoasignado == false)
                        {
                            a.nDestino.distancianodo = Int32.MaxValue;
                        }
                    }
                }
                inicio.distancianodo = 0;
                inicio.Visitado = true;
                grafo.Colorear(inicio);
                pbCanvas.Refresh();
                mostrarArreglo(inicio);
                Thread.Sleep(tiempo);
                while (grafo.nododistanciaminima() != null)
                {
                    CVertice nododismin = grafo.nododistanciaminima();
                    nododismin.Visitado = true;
                    grafo.Colorear(nododismin);
                    pbCanvas.Refresh();
                    foreach (CArco arco in nododismin.ListaAdyacencia)
                    {
                        if (arco.nDestino.distancianodo > nododismin.distancianodo + arco.peso)
                        {
                            if (arco.nDestino.pesoasignado)
                            { grafo.DibujarEntrantes(arco.nDestino); }
                            arco.nDestino.distancianodo = nododismin.distancianodo + arco.peso;
                            arco.nDestino.pesoasignado = true;
                            arco.color = Color.LimeGreen;
                            arco.grosor_flecha = 4;
                        }
                    }
                    mostrarArreglo(inicio);
                    Thread.Sleep(tiempo);
                }
            }
            else
            {
                rbnRestaurar.Enabled = true;
                MessageBox.Show("El nodo que ha elegino no tiene nodos adyacentes"
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void mostrarArreglo(CVertice i)
        {
            int m = int.MaxValue;
            limpiar(arreglo, arreglo2);
            Point xy = new Point(14, 64);
            Point xy2 = new Point(14, 94);
            Label[] ArregloNodos = new Label[numeronodos];
            Label[] ArregloDistnacias = new Label[numeronodos];
            for (int j = 0; j < numeronodos; j++)
            {
                Label label = new Label();
                Label label2 = new Label();
                label.Text = grafo.nodos[j].Valor;
                ArregloNodos[j] = label;
                if (grafo.nodos[j].distancianodo == m || grafo.nodos[j].distancianodo == int.MaxValue)
                {
                    label2.Text = "inf";
                }
                else
                { label2.Text = grafo.nodos[j].distancianodo.ToString(); }
                ArregloDistnacias[j] = label2;
            }
            foreach (Label l in ArregloNodos)
            {
                if (l != null)
                {
                    l.Width = 30;
                    l.Height = 30;
                    l.BackColor = Color.White;
                    l.ForeColor = Color.Black;
                    l.TextAlign = ContentAlignment.MiddleCenter;
                    l.Location = xy;
                    l.BorderStyle = BorderStyle.FixedSingle;
                    PnSimulador.Controls.Add(l);
                    xy += new Size(30, 0);
                }
            }
            foreach (Label l in ArregloDistnacias)
            {
                if (l != null)
                {
                    l.Width = 30;
                    l.Height = 30;
                    l.BackColor = Color.White;
                    l.ForeColor = Color.Black;
                    l.TextAlign = ContentAlignment.MiddleCenter;
                    l.Location = xy2;
                    l.BorderStyle = BorderStyle.FixedSingle;
                    PnSimulador.Controls.Add(l);
                    xy2 += new Size(30, 0);
                }
            }
            PnSimulador.Refresh();
            arreglo = ArregloNodos;
            arreglo2 = ArregloDistnacias;
        }
        private void limpiar(Label[] a, Label[] b)
        {
            foreach (Label l in a)
                PnSimulador.Controls.Remove(l);
            foreach (Label l in b)
                PnSimulador.Controls.Remove(l);
        }

        // Algoritmo de Warshall
        private List<List<int>> matrizFord = new List<List<int>>(); // matriz para utilizar algoritmo de ford
        private List<List<int>> matrizDistanciaWarshall = new List<List<int>>(); //matriz de distancias de cada nodo con cada nodo si existe relacion entre ellos
        private List<List<int>> matrizNodosWarshall = new List<List<int>>(); //matriz de nodos
        private Queue<int> Cola = new Queue<int>(); //cola de nodos
        private int totalNodos; //lista de nodos
        int[] parent; // padre del nodo
        bool[] visitados;// variable para comprobar los nodos ya visitados

        private void calcularMatricesIniciales() // se calculan las matrices iniciales de distancia y de nodos
        {
            matrizDistanciaWarshall = new List<List<int>>();
            matrizFord = new List<List<int>>();
            matrizNodosWarshall = new List<List<int>>();
            nodosRuta = new List<CVertice>(); //lista de nodos
            totalNodos = grafo.nodos.Count; //cuenta el numero de nodos en la lista "nodos"
            parent = new int[totalNodos];
            visitados = new bool[totalNodos];
            //calculamos la matriz inicial de distancias
            for (int i = 0; i < totalNodos; i++)
            {
                List<int> filaDistancia = new List<int>();
                for (int j = 0; j < totalNodos; j++)
                {
                    //si el origen = al destino
                    if (i == j)
                    {
                        filaDistancia.Add(0);
                    }
                    else
                    {
                        //buscamos si existe la relacion i,j; de existir obtenemos la distancia
                        int distancia = -1;
                        for (int k = 0; k < grafo.nodos[i].ListaAdyacencia.Count; k++)
                        {
                            if (grafo.nodos[i].ListaAdyacencia[k].nDestino == grafo.nodos[j])
                                distancia = grafo.nodos[i].ListaAdyacencia[k].peso;
                        }
                        filaDistancia.Add(distancia);
                    }
                }
                matrizDistanciaWarshall.Add(filaDistancia);// obtenemos la matriz inicial de distancias
                matrizFord.Add(filaDistancia);
            }
            //calculamos la matriz inicial de nodos
            for (int i = 0; i < totalNodos; i++)
            {
                List<int> puntosIntermedios = new List<int>();
                for (int j = 0; j < totalNodos; j++)
                {
                    puntosIntermedios.Add(j);
                }
                matrizNodosWarshall.Add(puntosIntermedios);// obtenemos la matriz inicial de nodos
            }
        }

        private void algoritmoWarshall() //se declara el metodo de warshall
        {
            for (int k = 0; k < totalNodos; k++)
            {
                for (int i = 0; i < totalNodos; i++)
                {
                    for (int j = 0; j < totalNodos; j++)
                    {
                        //hacemos las operaciones siempre y cuando exista distancia con el intermediario k: [i,k,j]
                        //es decir,debe existir la distancia d(i,k) y d(k,j)
                        if (matrizDistanciaWarshall[i][k] > 0.0 && matrizDistanciaWarshall[k][j] > 0.0)
                        {
                            int distancia = matrizDistanciaWarshall[i][k] + matrizDistanciaWarshall[k][j];

                            if (matrizDistanciaWarshall[i][j] > 0.0)
                            {
                                if (matrizDistanciaWarshall[i][j] > distancia)
                                {
                                    matrizDistanciaWarshall[i][j] = distancia;
                                    matrizNodosWarshall[i][j] = k;
                                }
                            }
                            else
                            {
                                if (matrizDistanciaWarshall[i][j] < 0.0)
                                {
                                    matrizDistanciaWarshall[i][j] = distancia;
                                    matrizNodosWarshall[i][j] = k;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void obtenerRutaPesoWarshall(string nodoOrigen, string nodoDestino)
        {
            int indexNodoOrigen = 0;
            int indexNodoDestino = 0;
            for (int i = 0; i < totalNodos; i++)//para i menor que la cantidad de nodos agregados a la cola
            {
                if (grafo.nodos[i].Valor == nodoOrigen)
                {
                    indexNodoOrigen = i;// el valor i sera el indice del nodo origen
                }
                if (grafo.nodos[i].Valor == nodoDestino)
                {
                    indexNodoDestino = i;// el valor j sera el indice del nodo destino
                }
            }
            List<int> ruta = new List<int>(); // se declara la lista ruta
            ruta.Add(indexNodoOrigen); // se añade el indice origen
            ruta.Add(indexNodoDestino);// se añade el indice destino
            obtenerNodosIntermedios(indexNodoOrigen, indexNodoDestino, ruta, 1); // se obtienen los nodos intermedios

            foreach (int nodo in ruta) // para cada nodo en ruta
            {
                nodosRuta.Add(grafo.nodos[nodo]);// agregara en nodosRuta cada nodo en la cola nodos del grafo
            }
            //obtenemos el peso de la ruta
            peso = matrizDistanciaWarshall[ruta[0]][ruta[ruta.Count - 1]];
            if (peso > -1)
            {
                buscarRuta = true;
            }
            else
            {
                MessageBox.Show("No se puede trazar ruta entre los nodos seleccionados");
            }
        }

        private void obtenerNodosIntermedios(int nodoOrigen, int nodoDestino, List<int> ruta, int indice) //metodo para obtener nodos intermedios
        {
            int intermedio = matrizNodosWarshall[nodoOrigen][nodoDestino];// la variable intermedio tendra el valor de la matriznodoWarshall con los valores de origen y destino
            if (intermedio != nodoDestino) //mientras intermedio sea diferente de nodo destino
            {
                ruta.Insert(indice, intermedio);// insertara en la lista ruta en el indice indicado
                indice++; //indice aumenta
                obtenerNodosIntermedios(intermedio, nodoDestino, ruta, indice); //obtiene nodo intermedio
            }
            else
            {
                indice--; // si intermedio y nodoDestino son iguales indice disminuye
                if (indice - 1 == -1)
                {
                    return;
                }
                nodoOrigen = ruta[indice - 1]; // nodo origen tendra el valor que tiene la ruta en determinado indice -1.
                nodoDestino = ruta[indice];  // nodo destino tendra el valor que tiene la ruta en determinado indice
                obtenerNodosIntermedios(nodoOrigen, nodoDestino, ruta, indice); // obtiene el nodo intermedio 
            }
        }

        /* ALGORITMO DE PRIM */
        private void rbnBPrim_Click(object sender, EventArgs e)
        {
            ventanaRecorrido.Visible = false;
            ventanaRecorrido.control = false;
            ventanaRecorrido.ShowDialog();
            if (ventanaRecorrido.control)
            {
                if (grafo.BuscarVertice(ventanaRecorrido.txtNodo.Text) != null)
                {
                    splitContainer1.Panel2Collapsed = false;
                    splitContainer1.SplitterDistance = (int)(this.Width * 0.75);
                    LblSimu.Text = "Simulacion: Algortimo de Prim";
                    label2.Text = "Matriz de distancias:\n";
                    for (int i = 0; i < grafo.nodos.Count; i++)
                    {
                        label2.Text += "|";
                        for (int j = 0; j < grafo.nodos.Count; j++)
                        {
                            int offset_text = 5;
                            if (j + 1 < grafo.nodos.Count)
                            {
                                if (grafo.FillMatriz()[i, j + 1] > 99)
                                    offset_text = 3;
                                else if (grafo.FillMatriz()[i, j + 1] > 9 || grafo.FillMatriz()[i, j + 1] < 0)
                                    offset_text = 4;
                            }
                            else
                                offset_text = 0;
                            label2.Text += grafo.FillMatriz()[i, j].ToString().PadRight(offset_text);
                        }
                        label2.Text += " |\n";
                    }
                    PnSimulador.Visible = true;
                    PnSimulador.Refresh();
                    rbnRestaurar.Enabled = true;
                    Duracion.Start();
                    string miCadenita;
                    miCadenita = "\nMatriz resultado: \n";
                    int[,] miMatriz = AlgPrim(grafo.BuscarVertice(ventanaRecorrido.txtNodo.Text), grafo.FillMatriz());
                    Duracion.Stop();
                    for (int i = 0; i < grafo.nodos.Count; i++)
                    {
                        miCadenita += "|";
                        for (int j = 0; j < grafo.nodos.Count; j++)
                        {
                            int offset_text = 5;
                            if (j + 1 < grafo.nodos.Count)
                            {
                                if (grafo.FillMatriz()[i, j + 1] > 99)
                                    offset_text = 3;
                                else if (grafo.FillMatriz()[i, j + 1] > 9 || grafo.FillMatriz()[i, j + 1] < 0)
                                    offset_text = 4;
                            }
                            else
                                offset_text = 0;
                            miCadenita += miMatriz[i, j].ToString().PadRight(offset_text);
                        }
                        miCadenita += " |\n";
                    }
                    miCadenita += "Y la duracion del recorrido fue de: " + Duracion.ElapsedMilliseconds + " miliSegundos";
                    label2.Text += miCadenita;
                }
                else
                {
                    MessageBox.Show("El Nodo " + ventanaVertice.txtVertice.Text + " No se encuentra en el grafo", "Error Nodo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private int[,] AlgPrim(CVertice nodoInicial, int[,] Matriz)
        {  //Llega la matriz a la que le vamos a aplicar el algoritmo
            bool[] marcados = new bool[grafo.nodos.Count]; //Creamos un vector booleano, para saber cuales están marcados
            return AlgPrim(Matriz, marcados, nodoInicial, new int[Matriz.GetLength(0), Matriz.GetLength(0)]); //Llamamos al método recursivo mandándole 
        }                                                                                     //un matriz nueva para que en ella nos 
                                                                                              //devuelva el árbol final
        private int[,] AlgPrim(int[,] Matriz, bool[] marcados, CVertice vertice, int[,] Final)
        {
            marcados[grafo.nodos.IndexOf(vertice)] = true;//marcamos el primer nodo
            grafo.Colorear(vertice);
            pbCanvas.Refresh();
            Thread.Sleep(tiempo);
            int aux = -1;
            if (!TodosMarcados(marcados))
            { //Mientras que no todos estén marcados
                for (int i = 0; i < marcados.GetLength(0); i++)
                { //Recorremos sólo las filas de los nodos marcados
                    if (marcados[i])
                    {
                        for (int j = 0; j < Matriz.GetLength(0); j++)
                        {
                            if (Matriz[i, j] != -1)
                            {        //Si la arista existe
                                if (!marcados[j])
                                {         //Si el nodo no ha sido marcado antes
                                    if (aux == -1)
                                    {        //Esto sólo se hace una vez
                                        aux = Matriz[i, j];
                                    }
                                    else
                                    {
                                        aux = Math.Min(aux, Matriz[i, j]); //Encontramos la arista mínima
                                    }
                                }
                            }
                        }
                    }
                }
                //Aquí buscamos el nodo correspondiente a esa arista mínima (aux)
                for (int i = 0; i < marcados.GetLength(0); i++)
                {
                    if (marcados[i])
                    {
                        for (int j = 0; j < Matriz.GetLength(0); j++)
                        {
                            if (Matriz[i, j] == aux)
                            {
                                if (!marcados[j])
                                { //Si no ha sido marcado antes
                                    Final[i, j] = aux; //Se llena la matriz final con el valor
                                    Final[j, i] = aux;//Se llena la matriz final con el valor
                                    grafo.ColoArista(grafo.nodos[i].Valor, grafo.nodos[j].Valor);
                                    grafo.ColoArista(grafo.nodos[j].Valor, grafo.nodos[i].Valor);
                                    return AlgPrim(Matriz, marcados, grafo.nodos[j], Final); //se llama de nuevo al método con
                                                                                             //el nodo a marcar
                                }
                            }
                        }
                    }
                }
                pbCanvas.Refresh();
                Thread.Sleep(tiempo);
            }
            return Final;
        }
        public bool TodosMarcados(bool[] vertice)
        { //Método para saber si todos están marcados
            foreach (bool b in vertice)
            {
                if (!b)
                {
                    return b;
                }
            }
            return true;
        }

        /* FIN ALGORITMO DE PRIM */

        /* ALGORITMO DE KRUSKAL */

        private void rbnBKruskal_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = false;
            splitContainer1.SplitterDistance = (int)(this.Width * 0.75);
            LblSimu.Text = "Simulacion: Algortimo de Kruskal";
            label2.Text = "Matriz de distancias:\n";
            for (int i = 0; i < grafo.nodos.Count; i++)
            {
                label2.Text += "|";
                for (int j = 0; j < grafo.nodos.Count; j++)
                {
                    int offset_text = 5;
                    if (j + 1 < grafo.nodos.Count)
                    {
                        if (grafo.FillMatriz()[i, j + 1] > 99)
                            offset_text = 3;
                        else if (grafo.FillMatriz()[i, j + 1] > 9 || grafo.FillMatriz()[i, j + 1] < 0)
                            offset_text = 4;
                    }
                    else
                        offset_text = 0;
                    label2.Text += grafo.FillMatriz()[i, j].ToString().PadRight(offset_text);
                }
                label2.Text += " |\n";
            }
            PnSimulador.Visible = true;
            PnSimulador.Refresh();
            rbnRestaurar.Enabled = true;
            Duracion.Start();
            int[,] miMatriz = Kruskal();
            Duracion.Stop();
            label2.Text += "\nY la duracion del recorrido fue de: " + Duracion.ElapsedMilliseconds + " miliSegundos";
        }

        public int[,] Kruskal()
        {
            int[,] adyacencia = grafo.FillMatriz(); //Se crea la matriz de adyacencia
            totalNodos = grafo.nodos.Count; //Numero de nodos en el grafo
            int[] p = new int[adyacencia.GetLength(0)]; //Vector P
            int min, sum = 0, ne = 0, i, j, u = 0, v = 0, a = 0, b = 0; //Variables de control
            for (i = 0; i < totalNodos; i++) //Marcamos P
                p[i] = 0; //Con valor inicial de 0
            while (ne < totalNodos - 1) //Mientras el numero de aristas sea menor que el total de nodos menos 1
            {
                min = int.MaxValue; //Min = inf
                for (i = 0; i < totalNodos; i++)
                {
                    for(j = 0; j < totalNodos; j++)
                    {
                        if (adyacencia[i, j] < min && adyacencia[i, j] != -1) //Si el peso de la arista es menor que el minimo
                        {
                            min = adyacencia[i, j]; //El minimo pasa a ser el peso de la arista
                            u = a = i;
                            v = b = j;
                        }
                    }
                }
                while (p[u] != 0)
                    u = p[u];
                while (p[v] != 0)
                    v = p[v];
                if (u != v) //Si no se formara un ciclo al crear la arista
                {
                    ne++; //Aumentamos el numero de aristas
                    sum += min; //Sumamos el costo minimo a la suma de los costos
                    grafo.Colorear(grafo.nodos[a]);
                    pbCanvas.Refresh();
                    Thread.Sleep(tiempo);
                    grafo.ColoArista(grafo.nodos[a].Valor.ToString(), grafo.nodos[b].ToString());
                    grafo.ColoArista(grafo.nodos[b].ToString(), grafo.nodos[a].ToString());
                    pbCanvas.Refresh();
                    Thread.Sleep(tiempo);
                    grafo.Colorear(grafo.nodos[b]);
                    pbCanvas.Refresh();
                    Thread.Sleep(tiempo);
                    p[v] = u; //Guardamos u en p[v]
                }
                adyacencia[a, b] = adyacencia[b, a] = int.MaxValue; //La arista ahora pasa a ser inf
            }
            label2.Text += "\nCosto minimo: " + sum;
            return adyacencia; //Regresamos matriz de adyacencia
        }

        /* FIN ALGORITMO DE KRUSKAL */
    }
}
