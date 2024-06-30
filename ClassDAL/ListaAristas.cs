using System.Collections.Generic;
namespace ClassDAL
{
    public class ListaAristas
    {
        internal NodoLista inicio;
        int contadorElmnts = 0;

        public string Insertar(int NumV, float costo)
        {
            NodoLista nuevoNodo = new NodoLista();
            nuevoNodo.numVertices = NumV;
            nuevoNodo.costo = costo;
            string msj;
            if (inicio == null)
            {
                inicio = nuevoNodo;
                contadorElmnts++;
                msj = "Elemento de inicio agregado";
            }
            else
            {
                //hay que recorrer esos objetos y dejar una referencia
                NodoLista t = null;
                t = inicio;
                while (t.next != null)
                {
                    t = t.next;
                }
                //cuando llego aqui estoy seguro que t está en el último
                t.next = nuevoNodo;
                contadorElmnts++;
                msj = "Ya no es el primer elemento";
            }
            return msj;
        }    
        public string[] MostrarDatosLista()
        {
            string[] cadenas = new string[contadorElmnts];
            NodoLista temp = null;
            temp = inicio;
            int contArray = 0;
            while (temp != null)
            {
                cadenas[contArray] = $"Enlace a {temp.numVertices} costo: {temp.costo}";
                temp = temp.next;
                contArray++;
            }
            return cadenas;
        }
        public List<int> ObtenerVecinos()
        {
            List<int> vecinos = new List<int>();
            NodoLista temp = inicio;
            while (temp != null)
            {
                vecinos.Add(temp.numVertices);
                temp = temp.next;
            }
            return vecinos;
        }
    }
}
