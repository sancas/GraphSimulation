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
        public List<CVertice> desmarcados;//lista de nodos desmarcados
        public bool DiGrafo;

        public CGrafo(bool DiGrafo = true) // Constructor
        {
            nodos = new List<CVertice>();
            desmarcados = new List<CVertice>();
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
                if((origen.ListaAdyacencia.Find(v => v.nDestino == nDestino) == null) && (nDestino.ListaAdyacencia.Find(v => v.nDestino == origen) == null))
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
            foreach (CVertice misNodos in nodos)
            {
                CArco miArco = misNodos.ListaAdyacencia.Find(v => v.nDestino == nDestino);
                if (miArco != null)
                {
                    miArco.color = Color.Black;
                    miArco.grosor_flecha = 2;
                    break;
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

        public void ElimiarArco(string o, string d)//Elimina una arista 
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

        //comprobar si la arista existe arista
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
        public void ColoArista(string o, string d)
        {
           // bool q = false;
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

        public void ColorArista(CVertice o, CVertice d)
        {
            foreach (CArco a in o.ListaAdyacencia)
            {
                if (o.ListaAdyacencia != null && a.nDestino == d)
                {
                    a.color = Color.Red;
                    a.grosor_flecha = 4;
                }
            }
        }


        public void Desmarcar()//funcion que desmarca como visitados todos los nodos del grafo
        {
            foreach (CVertice n in nodos)
            {
                n.Visitado = false;
                n.Padre = null;
                n.distancianodo = 10000;
                n.pesoasignado = false;
            }
        }
        //Funacion que busca nodos sin marcar como visitados
        //devuelve el nodo desmarcado, o null
        public CVertice BuscarDesmarcados()
        {
            CVertice nododes = new CVertice();
            Boolean desmarcado = false;
            foreach (CVertice n in nodos)
            {
                if (n.Visitado != true)
                {
                    desmarcado = true;
                    nododes = n;
                    break;
                }
            }
            if (desmarcado == true)
            {
                return nododes;
            }
            else return null;
        }

        public void LlenarDesmarcados()
        {
            foreach (CVertice n in nodos)
            {
                if (n.Visitado != true)
                {
                    desmarcados.Add(n);
                }
            }
        }
        public void eliminardesmarcado(CVertice nodo)
        {
            desmarcados.Remove(nodo);
        }
        public CVertice nododistanciaminima()
        {
            CVertice v = desmarcados.Find(x => x.distancianodo == desmarcados.Min(s => s.distancianodo));
            return v;
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