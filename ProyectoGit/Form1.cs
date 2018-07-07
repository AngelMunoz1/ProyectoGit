using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoGit
{
    public partial class Form1 : Form
    {
        private List<Productos> listaProductos = new List<Productos>();
        Productos[] producto = new Productos[3];
        public Form1()
        {
            InitializeComponent();           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Productos producto = new Productos();
            //producto.pCodigo = 9123456789;
            //producto.pNombre = "Miller";
            //producto.pPrecio = 36.00f;
            //rtb1.Text += producto.pCodigo + Environment.NewLine + producto.pNombre + Environment.NewLine + producto.pPrecio;
            //Comentario nuevo
            producto[0] = new Productos(1, "producto 1", 35.00f);
            producto[1] = new Productos(2, "producto 2", 35.02f);
            producto[2] = new Productos(3, "producto 3", 35.08f);
            cargaProducto();

        }
        private void cargaProducto()
        {
            try
            {
                for (int i = 0; i < producto.Length; i++)
                {
                    dgv1.Rows.Add(producto[i].pCodigo, producto[i].pNombre, producto[i].pPrecio);
                }
            }
            catch (Exception err)
            {

                MessageBox.Show("ERROR:" + Environment.NewLine + err);
            }
        }
    }

    class Productos
    {
        //Propiedades
        public long pCodigo = 0;
        public String pNombre = "";
        public float pPrecio = 0.00f;

        public Productos()
        {
            MessageBox.Show("Me llamaron sin parametros");
        }
        public Productos(long pCodigo, String pNombre, float pPrecio)
        {
            this.pCodigo = pCodigo;
            this.pNombre = pNombre;
            this.pPrecio = pPrecio;
        }
    }
}
