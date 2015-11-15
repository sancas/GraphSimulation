using System;
using System.Collections.Generic;
using System.Drawing; // Librería agregada, para poder dibujar
using System.Drawing.Drawing2D; // Librería agregada, para poder dibujar
using System.Linq;
using System.Text;
using System.Threading.Tasks; // Librería agregada, para el manejo de hilos de ejecución

namespace GraphSimulation
{
    [Serializable]
    public class CVertice {
        // Atributos
        public string Valor; // Valor que almacena (representa) el nodo
        public List < CArco > ListaAdyacencia; // Lista de adyacencia del nodo
        public Boolean Visitado;//variable que sirve para marcar como visto el nodo en un recorrido
        public CVertice Padre;//nodo que sirve en los recorridos como el antecesor 
        public int distancianodo;//guarda la distancia que hay entre el nodo inicio en el algoritmo de Dijkstra
        public Boolean pesoasignado;//variable que sirve se usa en el algoritmo de Dijkstra
        // Propiedades
        public Color Color {
            get {
                return color_nodo;
            }
            set {
                color_nodo = value;
            }
        }
        public Color FontColor {
            get {
                return color_fuente;
            }
            set {
                color_fuente = value;
            }
        }

        public Point Posicion {
            get {
                return _posicion;
            }
            set {
                _posicion = value;
            }
        }
        public Size Dimensiones {
            get {
                return dimensiones;
            }
            set {
                radio = value.Width / 2;
                dimensiones = value;
            }
        }
        static int size = 35; // Tamaño del nodo
        Size dimensiones;
        Color color_nodo; // Color definido para el nodo
        Color color_fuente; // Color definido para la fuente del nombre del nodo
        Point _posicion; // Dónde se dibujará el nodo
        int radio; // Radio del objeto que representa el nodo
        // Métodos
        // Constructor de la clase, recibe como parámetro el nombre del nodo (el valor que tendrá)
        public CVertice(string Valor) {
            this.Valor = Valor;
            this.ListaAdyacencia = new List < CArco > ();
            this.Color = Color.LightSeaGreen; // Definimos el color del nodo
            this.Dimensiones = new Size(size, size); // Definimos las dimensiones del circulo
            this.FontColor = Color.White; // Color de la fuente
        }
        public CVertice(): this("") {} // Constructor por defecto

        // Método para dibujar el nodo
        public void DibujarVertice(Graphics g) {
                SolidBrush b = new SolidBrush(this.color_nodo);

                // Definimos donde dibujaremos el nodo
                Rectangle areaNodo = new Rectangle(this._posicion.X - radio, this._posicion.Y - radio,
                    this.dimensiones.Width, this.dimensiones.Height);
                g.FillEllipse(b, areaNodo);

                g.DrawString(this.Valor, new Font("Arial", 14), new SolidBrush(color_fuente),
                    this._posicion.X, this._posicion.Y,
                    new StringFormat() {
                        Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                    }
                );
                g.DrawEllipse(new Pen(Brushes.Black, (float) 1.0), areaNodo);
                b.Dispose();
            }
            // Método para dibujar los arcos
        public void DibujarArco(Graphics g, bool DiGrafo)
        {
            float distancia;
            int difY, difX;
            foreach (CArco arco in ListaAdyacencia)
            {
                difX = this.Posicion.X - arco.nDestino.Posicion.X;
                difY = this.Posicion.Y - arco.nDestino.Posicion.Y;
                distancia = (float)Math.Sqrt((difX * difX + difY * difY));
                AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 4, true);
                bigArrow.BaseCap = System.Drawing.Drawing2D.LineCap.Triangle;
                if (DiGrafo)
                {
                    g.DrawLine(new Pen(new SolidBrush(arco.color), arco.grosor_flecha)
                    {
                        CustomEndCap = bigArrow,
                        Alignment = PenAlignment.Center
                    },
                        _posicion,
                        new Point(arco.nDestino.Posicion.X + (int)(radio * difX / distancia),
                            arco.nDestino.Posicion.Y + (int)(radio * difY / distancia)
                        )
                    );
                }
                else
                {
                    g.DrawLine(new Pen(new SolidBrush(arco.color), arco.grosor_flecha),
                        _posicion,
                        new Point(arco.nDestino.Posicion.X + (int)(radio * difX / distancia),
                            arco.nDestino.Posicion.Y + (int)(radio * difY / distancia)
                        )
                    );
                }
                g.DrawString(
                    arco.peso.ToString(),
                    new Font("Arial", 12),
                    new SolidBrush(arco.Cfuente),
                    this._posicion.X - (int)((difX / 2)),
                    this._posicion.Y - (int)((difY / 2)),
                    new StringFormat()
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Far
                    }
                );
            }
        }
            // Método para detectar posición en el panel donde se dibujará el nodo
        public bool DetectarPunto(Point p) {
            GraphicsPath posicion = new GraphicsPath();

            posicion.AddEllipse(new Rectangle(this._posicion.X - this.dimensiones.Width / 2,
                this._posicion.Y - this.dimensiones.Height / 2,
                this.dimensiones.Width, this.dimensiones.Height));

            bool retval = posicion.IsVisible(p);
            posicion.Dispose();
            return retval;
        }

        override public string ToString() {
            return this.Valor;
        }

        
    }

    [Serializable]
    public class CArco
    { // Atributos
        public CVertice nDestino;
        public int peso;
        public float grosor_flecha;
        public Color color;
        public Boolean seleccionada= false;
        public Color Cfuente;
         //Métodos
        public CArco(CVertice destino)
            : this(destino, 1)
        {
            this.nDestino = destino;
        }
        public CArco(CVertice destino, int peso)
        {
            this.nDestino = destino;
            this.peso = peso;
            this.grosor_flecha = 2;
            this.color = Color.Black;
            this.Cfuente = Color.Black;
        }
    }
}