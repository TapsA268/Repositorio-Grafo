using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassBLL;
using ClassEntidades;

namespace WebGrafo
{
    public partial class FormPresentacion : System.Web.UI.Page
    {
        ClassBL objBL;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                objBL = new ClassBL();
                Session["objBL"] = objBL;
            }
            else
            {
                objBL = (ClassBL)Session["objBL"];
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == string.Empty || TextBox2.Text == string.Empty) TextBox6.Text = "Ingresa datos válidos";
            else
            {
                Entidad objEntidad = new Entidad()
                {
                    Nombre = TextBox1.Text,
                    Edad = int.Parse(TextBox2.Text)
                };
                TextBox6.Text = objBL.AgregarVerticeBL(objEntidad);
                TextBox1.Text = "";
                TextBox2.Text = "";
            }

            string[] arrayTemp = objBL.MostrarVerticesBL();

            DropDownList1.Items.Clear();

            foreach (string cadena in arrayTemp)
            {
                DropDownList1.Items.Add(cadena);
            };
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox3.Text == string.Empty || TextBox4.Text == string.Empty || TextBox5.Text == string.Empty) TextBox6.Text = "Ingresa datos válidos";
            else
            {
                int origen = int.Parse(TextBox3.Text);
                int destino = int.Parse(TextBox4.Text);
                float costo = float.Parse(TextBox5.Text);

                TextBox6.Text = objBL.AgregarAristaBL(origen, destino, costo);
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
            } 
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            List<string> listTemp;
            int Pos_vertice = -5;
            string msj = "";

            if (DropDownList1.SelectedIndex != -1)
            {
                Pos_vertice = DropDownList1.SelectedIndex;
                listTemp = objBL.MostrarVerticesAristas(Pos_vertice, ref msj);

                DropDownList2.Items.Clear();

                foreach (string cadena in listTemp)
                {
                    DropDownList2.Items.Add(cadena);
                };
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            List<string> temp;
            int vertice = -5;

            if (DropDownList1.SelectedIndex != -1)
            {
                DropDownList3.Items.Clear();
                vertice = DropDownList1.SelectedIndex;
                temp = objBL.RecorrerDFS_BL(vertice);

                foreach (string cad in temp)
                {
                    DropDownList3.Items.Add(cad);
                }
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            List<string> temp;
            int vertice = -5;

            if (DropDownList1.SelectedIndex != -1)
            {
                DropDownList3.Items.Clear();
                vertice = DropDownList1.SelectedIndex;
                temp = objBL.RecorrerBFS_BL(vertice);

                foreach (string cad in temp)
                {
                    DropDownList3.Items.Add(cad);
                }
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            List<string> temp;
            DropDownList3.Items.Clear();

            temp = objBL.BusquedaTopologicaBL();

            foreach (string cad in temp)
            {
                DropDownList3.Items.Add(cad);
            }
        }
    }
}