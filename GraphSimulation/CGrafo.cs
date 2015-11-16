using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GraphSimulation
{
    [Serializable]
    public class CGrafo
    {
        public List<CVertice> nodos; // Lista de nodos del grafo
        public bool DiGrafo;

        public CGrafo(bool DiGrafo = true) // Constructor
        {
            nodos = new List<CVertice>();
            this.DiGrafo = DiGrafo;
        }

        //Agrega un nodo a la lista de nodos del grafo
        public void AgregarVertice(CVertice nuevonodo)
        {
            nodos.Add(nuevonodo);
        }
        //Busca un nodo en la lista de nodos del grafo

        public CVertice BuscarVertice(string valor)
        {
            return nodos.Find(v => v.Valor == valor);
        }

        // Crea la arista a partir de los nodos de origen y de destino

        public bool AgregarArco(CVertice origen, CVertice nDestino)
        {
            if (DiGrafo)
            {
                if (origen.ListaAdyacencia.Find(v => v.nDestino == nDestino) == null)
                {
                    origen.ListaAdyacencia.Add(new CArco(nDestino));
                    return true;
                }
                return false;
            }
            else
            {
                if ((origen.ListaAdyacencia.Find(v => v.nDestino == nDestino) == null) &&
                    (nDestino.ListaAdyacencia.Find(v => v.nDestino == origen) == null))
                {
                    origen.ListaAdyacencia.Add(new CArco(nDestino));
                    nDestino.ListaAdyacencia.Add(new CArco(origen));
                    return true;
                }
                return false;
            }
        }

        //Funcion para re-dibujar los arcos que llegan a un nodo
        public void DibujarEntrantes(CVertice nDestino)
        {
            foreach (CVertice nodo in nodos)
            {
                foreach (CArco a in nodo.ListaAdyacencia)
                {
                    if (nodo.ListaAdyacencia != null && nodo != nDestino)
                    {
                        if (a.nDestino == nDestino)
                        {
                            a.color = Color.Black;
                            a.grosor_flecha = 2;
                            break;
                        }
                    }
                }
            }
        }

        // Método para dibujar el grafo
        public void DibujarGrafo(Graphics g)
        {

            foreach (CVertice nodo in nodos)
                nodo.DibujarArco(g, DiGrafo);


            foreach (CVertice nodo in nodos)
                nodo.DibujarVertice(g);
        }

        // Método para detectar si se ha posicionado sobre algún nodo y lo devuelve
        public CVertice DetectarPunto(Point posicionMouse)
        {
            foreach (CVertice nodoActual in nodos)
                if (nodoActual.DetectarPunto(posicionMouse)) return nodoActual;
            return null;
        }

        // Método para regresar al estado original
        public void RestablecerGrafo(Graphics g)
        {
            foreach (CVertice nodo in nodos)
            {
                nodo.Color = Color.LightSeaGreen;
                nodo.FontColor = Color.White;
                nodo.Visitado = false;
                nodo.Padre = null;
                foreach (CArco arco in nodo.ListaAdyacencia)
                {
                    arco.grosor_flecha = 2;
                    arco.color = Color.Black;
                }
            }
            DibujarGrafo(g);
        }

        //Metodo para resaltar nodos del grafo
        public void Colorear(CVertice nodo)
        {
            nodo.Color = Color.AliceBlue;
            nodo.FontColor = Color.Black;
        }

        //Funcion para eliminar nodos
        public void ELiminarNodo(string v)
        {
            foreach (CVertice nodo in nodos)
            {
                foreach (CArco a in nodo.ListaAdyacencia)
                {
                    if (nodo.ListaAdyacencia != null && nodo.Valor != v)
                    {
                        if (a.nDestino.Valor == v)
                        {
                            nodo.ListaAdyacencia.Remove(a);
                            break;
                        }
                    }
                }
            }
            foreach (CVertice nodo in nodos)
            {
                if (nodo.Valor == v)
                {
                    nodos.Remove(nodo);
                    break;
                }
            }
        }

        //Funcion para eliminar una arista 
        public void ElimiarArco(string o, string d)
        {
            foreach (CVertice nodo in nodos)
            {
                foreach (CArco a in nodo.ListaAdyacencia)
                {
                    if (nodo.ListaAdyacencia != null && nodo.Valor == o && a.nDestino.Valor == d)
                    {
                        nodo.ListaAdyacencia.Remove(a);
                        break;
                    }
                }
            }
        }

        //comprobar si la arista existe
        public bool Comprobararista(string o, string d)
        {
            bool q = false;
            foreach (CVertice nodo in nodos)
            {
                foreach (CArco a in nodo.ListaAdyacencia)
                {
                    if (nodo.ListaAdyacencia != null && nodo.Valor == o && a.nDestino.Valor == d)
                    {
                        q = true;
                    }
                }
            }
            return q;
        }

        //Funcion para colorear y resaltar una arista
        public void ColoArista(string o, string d)
        {
            foreach (CVertice nodo in nodos)
            {
                foreach (CArco a in nodo.ListaAdyacencia)
                {
                    if (nodo.ListaAdyacencia != null && nodo.Valor == o && a.nDestino.Valor == d)
                    {
                        a.color = Color.Red;
                        a.grosor_flecha = 4;
                    }
                }
            }
        }

        //funcion que desmarca como visitados todos los nodos del grafo
        public void Desmarcar()
        {
            foreach (CVertice n in nodos)
            {
                n.Visitado = false;
                n.Padre = null;
                n.distancianodo = int.MaxValue;
                n.pesoasignado = false;
            }
        }

        public CVertice nododistanciaminima()
        {
            int min = int.MaxValue;
            CVertice temp = null;
            foreach (CVertice origen in nodos)
            {
                if (origen.Visitado)
                {
                    foreach (CVertice destino in nodos)
                    {
                        if (!destino.Visitado)
                        {
                            foreach (CArco a in origen.ListaAdyacencia)
                            {
                                if (a.nDestino == destino && min > a.peso)
                                {
                                    min = a.peso;
                                    temp = destino;
                                }
                            }
                        }
                    }
                }
            }
            return temp;
        }

        // Funcion para contruir la matriz de adyacencia
        public int[,] FillMatriz()
        {
            int[,] Matriz = new int[nodos.Count(), nodos.Count()];
            int j = 0;
            foreach (var item in nodos)
            {
                List<CVertice> Ady = new List<CVertice>();
                foreach (var ady in item.ListaAdyacencia)
                {
                    Ady.Add(ady.nDestino);
                }
                int i = 0;
                foreach (var Pesos in nodos)
                {
                    if (Ady.Contains(Pesos))
                    {
                        Matriz[j, i] = item.ListaAdyacencia[(Ady.IndexOf(Pesos))].peso;
                    }
                    else
                    {
                        Matriz[j, i] = -1;
                    }
                    i++;
                }
                j++;
            }
            return Matriz;
        }//Fin Funcion
    }
}