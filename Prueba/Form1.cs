using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassEntidades;
using ClassBLL;

namespace Prueba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ClassBL objBL = new ClassBL();
        private void button1_Click(object sender, EventArgs e)
        {
            Entidad obj = new Entidad()
            {
                Nombre=textBox1.Text,
                Edad=int.Parse(textBox2.Text)
            };
            comboBox1.Text = objBL.AgregarVerticeBL(obj);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int origen = int.Parse(textBox3.Text);
            int destino = int.Parse(textBox4.Text);
            float costo = float.Parse(textBox5.Text);

            comboBox1.Text = objBL.AgregarAristaBL(origen, destino, costo);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int Pos_vertice = int.Parse(textBox6.Text);
            string msj = "";
            string[] arrayTemp = objBL.MostrarVerticesAristas(Pos_vertice, ref msj);

            comboBox1.Items.Clear();

            foreach(string cadena in arrayTemp)
            {
                comboBox1.Items.Add(cadena);
            };
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] arrayTemp = objBL.MostrarVerticesBL();

            comboBox1.Items.Clear();

            foreach (string cadena in arrayTemp)
            {
                comboBox1.Items.Add(cadena);
            };
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int vertice = int.Parse(textBox6.Text);
            textBox7.Text = objBL.BFS(vertice);
        }
    }
}
