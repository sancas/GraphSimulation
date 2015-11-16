using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.Threading;

namespace GraphSimulation
{
    class Algoritmos
    {
        public string recorrido, distancias; 
        Stopwatch Duracion;
        
        
          public Algoritmos() // Constructor
        {
            Duracion= new Stopwatch();            
            recorrido = "";
            distancias = "";
           
        }

        //Algortimo de dijkstra
        public void dijkstra(CVertice inicio, CGrafo grafo)
        {
            foreach (CVertice nodo in grafo.nodos)
            {
                foreach (CArco a in nodo.ListaAdyacencia)
                {
                    if (nodo == inicio)
                    {
                        a.nDestino.distancianodo = a.peso;
                        a.nDestino.pesoasignado = true;
                        //a.color = Color.Red;
                       
                    }
                    else if (nodo != inicio && a.nDestino.pesoasignado == false)
                    {
                        a.nDestino.distancianodo = Int32.MaxValue;

                    }
                }
            }
            inicio.distancianodo = 0;
            inicio.Visitado = true;
            recorrido = "|" + inicio.Valor + "|";
            distancias = "|" + inicio.distancianodo.ToString() + "|";

            while (grafo.BuscarDesmarcados() != null)
            {
                grafo.LlenarDesmarcados();
                CVertice nododismin = grafo.nododistanciaminima();
                nododismin.Visitado = true;
                grafo.eliminardesmarcado(nododismin);

                foreach (CArco arco in nododismin.ListaAdyacencia)
                {
                    if (arco.nDestino.distancianodo > nododismin.distancianodo + arco.peso)
                    {

                        arco.nDestino.distancianodo = nododismin.distancianodo + arco.peso;

                    }
                }
            } 
            int n = grafo.nodos.Count;
            for (int j = 0; j < n; j++)
            {
                if (grafo.nodos[j].Valor != inicio.Valor)
                {
                    recorrido += grafo.nodos[j].Valor + "|";
                    distancias += grafo.nodos[j].distancianodo.ToString() + "|";
                }
            }
        }


        /***************************************************************************/
        /***************************************************************************/
        /***************************PRUEBAS DE ALGORITMOS***************************/
        /***************************************************************************/
        /***************************************************************************/
        public void di(CVertice inicio, CGrafo grafo)
        {
            foreach (CVertice nodo in grafo.nodos)
            {
                foreach (CArco a in nodo.ListaAdyacencia)
                {
                    if (nodo == inicio)
                    {
                        a.nDestino.distancianodo = a.peso;
                        a.nDestino.pesoasignado = true;
                        a.color = Color.Red;
                        grafo.Aristasdeexpancion.Add(a);
                    }
                    else if (nodo != inicio && a.nDestino.pesoasignado == false)
                    {
                        a.nDestino.distancianodo = Int32.MaxValue;

                    }
                }
            }
            inicio.distancianodo = 0;
            inicio.Visitado = true;
            recorrido = "|" + inicio.Valor + "|";
            distancias = "|" + inicio.distancianodo.ToString() + "|";

            while (grafo.BuscarDesmarcados() != null)
            {
                grafo.LlenarDesmarcados();
                CVertice nododismin = grafo.nododistanciaminima();
                nododismin.Visitado = true;
                grafo.eliminardesmarcado(nododismin);

                foreach (CArco arco in nododismin.ListaAdyacencia)
                {
                    if (arco.nDestino.distancianodo > nododismin.distancianodo + arco.peso)
                    {
                        arco.nDestino.distancianodo = nododismin.distancianodo + arco.peso;
                    }
                }
            }
            int n = grafo.nodos.Count;
            for (int j = 0; j < n; j++)
            {
                if (grafo.nodos[j].Valor != inicio.Valor)
                {
                    recorrido += grafo.nodos[j].Valor + "|";
                    distancias += grafo.nodos[j].distancianodo.ToString() + "|";
                }
            }

            foreach (CArco a in grafo.Aristasdeexpancion)
            {
                a.color = Color.Red;
            }
        }
    }
}
