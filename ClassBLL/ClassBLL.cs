using ClassDAL;
using ClassEntidades;

namespace ClassBLL
{
    public class ClassBL
    {
        Grafo grafo = new Grafo();        
        public string AgregarVerticeBL(Entidad obj)
        {
            string temp = grafo.AgregarVertice(obj);
            return temp;
        }
        public string AgregarAristaBL(int origen,int destino,float costo)
        {
            string temp = grafo.AgregarArista(origen, destino, costo);
            return temp;
        }
        public string[] MostrarVerticesAristas(int pVertice, ref string msj)
        {
            return grafo.MostrarAristasVertice(pVertice, ref msj);
        }
        public string[] MostrarVerticesBL()
        {
            return grafo.MostrarVertices();
        }
    }
}
