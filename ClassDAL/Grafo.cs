using System;
using ClassEntidades;
using System.Collections.Generic;

namespace ClassDAL
{
    public class Grafo
    {
        internal List<Vertice> ListaAdyacencia = new List<Vertice>();

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
        public List<string> MostrarAristasVertice(int posVertice, ref string msj)
        {
            NodoLista temp;
            List<string> salida = new List<string>();

            if (posVertice >= 0 && posVertice <= (ListaAdyacencia.Count -1))
            {
                temp = ListaAdyacencia[posVertice].listaEnlaces.inicio;

                while (temp != null)
                {
                    salida.Add($"Vertice destino: {ListaAdyacencia[temp.numVertices].entidadInfo.Nombre} "
                        +$"posición de enlace a {temp.numVertices} costo {temp.costo}");
                    temp = temp.next;
                }

                msj = "Correcto";
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
            for (cont = 0; cont <= ListaAdyacencia.Count - 1; cont++)
            {
                salida[cont] = ListaAdyacencia[cont].MostrarDatos();
            }
            return salida;
        }
        public List<string> RecorrerDFS(int vertice)
        {
            Boolean[] visitados = new Boolean[ListaAdyacencia.Count];
            Stack<int> pilaResult=new Stack<int>();
            List<string> listaResultados = new List<string>();

            pilaResult.Push(vertice);

            while (pilaResult.Count != 0)
            {
                int v=pilaResult.Pop();
                if (!visitados[v])
                {
                    visitados[v] = true;
                    listaResultados.Add($"{v}: {ListaAdyacencia[v].entidadInfo.Nombre}");
                    foreach(int i in ListaAdyacencia[v].ObtenerVecinos())
                    {
                        if (!visitados[i])
                        {
                            pilaResult.Push(i);
                        }
                    }
                }
            }

            return listaResultados;            
        }
        public List<string> RecorrerBFS(int verticeInicio)
        {
            Boolean[] visitado = new Boolean[ListaAdyacencia.Count];
            Queue<int> colaResultado=new Queue<int>();
            List<string> resultados = new List<string>();

            visitado[verticeInicio] = true;
            colaResultado.Enqueue(verticeInicio);

            while (colaResultado.Count != 0)
            {
                verticeInicio = colaResultado.Dequeue();
                resultados.Add($"{verticeInicio}:{ListaAdyacencia[verticeInicio].entidadInfo.Nombre}");

                foreach(int v in ListaAdyacencia[verticeInicio].ObtenerVecinos())
                {
                    if (!visitado[v])
                    {
                        visitado[v] = true;
                        colaResultado.Enqueue(v);
                    }
                }
            }
            return resultados;
        }
        private void BusquedaTopologicaRecursiva(int vertice, Boolean[] visitados, Stack<int> pilaResults)
        {
            visitados[vertice] = true;
            foreach (int v in ListaAdyacencia[vertice].ObtenerVecinos())
            {
                if (!visitados[v])
                {
                    BusquedaTopologicaRecursiva(v, visitados, pilaResults);
                }
            }
            pilaResults.Push(vertice);
        }
        public List<string> BusquedaTopologica()
        {
            Stack<int> pila = new Stack<int>();
            Boolean[] visitados = new Boolean[ListaAdyacencia.Count];
            List<string> result = new List<string>();

            for (int i = 0; i < ListaAdyacencia.Count; i++)
            {
                if (!visitados[i])
                {
                    BusquedaTopologicaRecursiva(i, visitados, pila);
                }
            }

            while (pila.Count != 0)
            {
                result.Add(pila.Pop().ToString());
            }
            return result;
        }       
    }
}
