// Función para actualizar el grafo en el Canvas
function dibujarGrafo(jsonGrafo) {
    console.log(jsonGrafo)

    let grafo = jsonGrafo;

    try {
        grafo = JSON.parse(jsonGrafo);
    } catch (error) {
        console.error("Error de conversión de JSON:", error);
        return;
    }

    // Configuración del Canvas
    let grados = 0;
    const inc_grados = 360 / grafo.ListaAdyacencia.length; // Distribuir vértices uniformemente
    const hip = 140;
    const rad = 25;
    const trigo2 = new trigonometria(0, hip);
    const circ = new Circulo();
    let radianes = 0;
    let xxc = 0;
    let yyc = 0;
    let cont_circ = 0;

    // Contexto gráfico
    const canvas = document.getElementById("Canvas1");
    const context = canvas.getContext('2d');

    // Limpiar el canvas antes de dibujar
    context.clearRect(0, 0, canvas.width, canvas.height);

    // Obtener las dimensiones del área de dibujo
    const tx = canvas.width;
    const ty = canvas.height;

    // Variables para el centro
    const xc = tx / 2;
    const yc = ty / 2;

    const posicionesVertices = [];

    // Dibujar los vértices
    for (grados = 0; grados < 360; grados += inc_grados) {
        radianes = (2 * Math.PI * grados) / 360;
        trigo2.angulo = radianes;

        xxc = xc + trigo2.ObtenerAdyacente();
        yyc = yc - trigo2.ObtenerOpuesto();

        circ.posiX = xxc;
        circ.posiY = yyc;
        circ.radio = rad;
        circ.color = 'blue';
        circ.draw(context);

        // Guardar posición del vértice
        posicionesVertices.push({ x: xxc, y: yyc });        

        // Dibujar el texto dentro del círculo
        context.textAlign = "center";
        context.textBaseline = "middle";
        context.font = "14px Arial";
        context.fillText(cont_circ, xxc, yyc);
        cont_circ++;
    }

    // Dibujar las aristas
    grafo.ListaAdyacencia.forEach((vertice, indice) => {
        let actual = vertice.listaEnlaces.inicio;
        while (actual) {
            const destino = actual.numVertices;
            const costo = actual.costo;

            context.strokeStyle = '#000000';
            context.beginPath();
            context.moveTo(posicionesVertices[indice].x, posicionesVertices[indice].y);
            context.lineTo(posicionesVertices[destino].x, posicionesVertices[destino].y);
            context.closePath();
            context.stroke();

            actual = actual.next;
        }
    });
}
