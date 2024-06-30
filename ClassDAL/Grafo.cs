using System;
using ClassEntidades;
using System.Collections.Generic;

namespace ClassDAL
{
    public class Grafo
    {
        public List<Vertice> ListaAdyacencia = new List<Vertice>();

        public string AgregarVertice(Entidad obj)
        {
            string msj = $"Vertice {obj.MostrarDatos()} agregado";
            ListaAdyacencia.Add(new Vertice(obj));
            return msj;
        }
        public string AgregarArista(int origen, int dest,float costo)
        {
            string msj = "";
            if (origen >= 0 && origen <= (ListaAdyacencia.Count - 1))
            {
                if(dest>=0 && dest <= (ListaAdyacencia.Count - 1))
                {
                    ListaAdyacencia[origen].AgregarArista(dest, costo);
                    msj = "Arista agregada";
                }
                else
                {
                    msj = "La posición del vertice destino no existe en la lista de adyacencia";
                }
            }
            else
            {
                msj = "La posición del vertice origen no existe en la lista de adyacencia";
            }
            return msj;
        }
        public string[] MostrarAristasVertice(int posVertice, ref string msj)
        {
            string[] salida = null;
            if (posVertice >= 0 && posVertice < ListaAdyacencia.Count)
            {
                salida = ListaAdyacencia[posVertice].MostrarAristas();
                msj = "Arista agregada";
            }
            else
            {
                msj = "La posición del vertice destino no existe en la lista de adyacencia";
            }
            return salida;
        }
        public string[] MostrarVertices()
        {
            string[] salida = new string[ListaAdyacencia.Count];
            int cont;
            for (cont = 0; cont < ListaAdyacencia.Count; cont++)
            {
                salida[cont] = ListaAdyacencia[cont].MostrarDatos();
            }
            return salida;
        }
        private void DFSRecursivo(int visita,Boolean[] visitado,int [] resultados, ref int indice)
        {
            visitado[visita]=true;
            resultados[indice] = visita;

            foreach(int vecino in ListaAdyacencia[visita].ObtenerVecinos())
            {
                if (!visitado[vecino]) DFSRecursivo(vecino, visitado,resultados,ref indice);
            }
        }
        public int[] DFS(int vertice)
        {
            Boolean[] visitado = new Boolean[ListaAdyacencia.Count];
            int[] resultado = new int[ListaAdyacencia.Count];
            int indice = 0;

            DFSRecursivo(vertice, visitado, resultado,ref indice);
            return resultado;
        }
        public string BFS(int verticeInicio)
        {
            Boolean[] visitado = new Boolean[ListaAdyacencia.Count];
            Queue<int> colaResultado=new Queue<int>();
            string res="";

            visitado[verticeInicio] = true;
            colaResultado.Enqueue(verticeInicio);

            while (colaResultado.Count != 0)
            {
                verticeInicio = colaResultado.Dequeue();
                res += $"{verticeInicio} ";

                foreach(int v in ListaAdyacencia[verticeInicio].ObtenerVecinos())
                {
                    if (!visitado[v])
                    {
                        visitado[v] = true;
                        colaResultado.Enqueue(v);
                    }
                }
            }
            return res;
        }
    }
}
