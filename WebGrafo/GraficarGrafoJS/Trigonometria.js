class trigonometria
{
    constructor(angulo, hipo)
    {
        this.angulo=angulo;
        this.hipotenusa=hipo;
    }

    ObtenerAdyacente()
    {
        let adyacente=Math.cos(this.angulo)*this.hipotenusa;
        return adyacente;
    }

    ObtenerOpuesto()
    {
        let opuesto=Math.sin(this.angulo)*this.hipotenusa;
        return opuesto;
    }
}
