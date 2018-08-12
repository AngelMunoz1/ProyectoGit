using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace ProyectoGit
{
    public partial class Form1 : Form
    {
        //Varible de clase que se utiliza para poder utilizar en el metodo de ultimo producto selecionado
        private int lastSelected;
        public Form1()
        {
            InitializeComponent();           
        }

        //Manda llamar el metodo CargaProductos, para inicializar el programa con los productos ya especificados
        private void Form1_Load(object sender, EventArgs e)
        {
            btnMenu.Location = new Point(1, this.Height - btnMenu.Height);
            CargaProductos();
        }

        //Carga los productos al dataGridView
        private void CargaProductos()
        {
            //agrega 2 posicisiones despues del . en el precio 
            dataGridView1.Columns["Column3"].DefaultCellStyle.Format = "N2";

            try
            {
                int counter = 0;
                string line;

                // Read the file and display it line by line.  
                System.IO.StreamReader file =
                    new System.IO.StreamReader("Productos.csv");
                while ((line = file.ReadLine()) != null)
                {
                    dataGridView1.Rows.Add(line.Split(','));
                    dataGridView1.Rows[counter].HeaderCell.Value = (counter + 1).ToString();
                    counter++;
                }
                dataGridView1_Numerar();
                file.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("" + err);
            }
        }

        //Agrega nuevo producto al dataGridView
        private void btnAdd_Click(object sender, EventArgs e)
        {

            bool existe = false;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1[0, i].Value.ToString() == txtIdProductos.Text)
                {
                    existe = true;
                    break;
                }
            }

            if (existe == false)
            {
                dataGridView1.Rows.Add(txtIdProductos.Text, txtNombre.Text, txtPrecio.Text);
                dataGridView1_Numerar();
            }
            else
            {
                MessageBox.Show("No puede agregarse productos con codigo repetido", (MessageBoxButtons.OK).ToString());
                Limpiar();
            }

        }

        //Llena la informacion en los textboxs con el ultimo producto seleccionado
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // indice -1 = a los row headers
            if (e.RowIndex != -1)
            {
                txtIdProductos.Text = dataGridView1[0, e.RowIndex].Value.ToString();
                txtNombre.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                txtPrecio.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                lastSelected = e.RowIndex;
                txtIdProductos.Enabled = false;
            }

        }

        //Elimina productos del DataGridView
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea eliminar " + dataGridView1[1,
                lastSelected].Value.ToString() + " con Precio de : "
                + dataGridView1[2, lastSelected].Value.ToString(), "Titulo de la ventana",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dataGridView1.Rows.RemoveAt(lastSelected);
            }
            Limpiar();
            dataGridView1_Numerar();
        }

        //limpia los textboxs
        private void Limpiar()
        {
            txtIdProductos.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            txtIdProductos.Focus();
        }

        //Vuelve a enumarar los productos
        private void dataGridView1_Numerar()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value
                    = (i + 1).ToString();

            }
        }

        //modifica los productos ya existentes
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea modificar " + dataGridView1[1,
                lastSelected].Value.ToString() + " con Precio de : "
                + txtPrecio.Text, "Titulo de la ventana",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dataGridView1[1, lastSelected].Value = txtNombre.Text;
                dataGridView1[2, lastSelected].Value = txtPrecio.Text;
            }
            Limpiar();
        }

        //Guarda los datos del dataGridView en el archivo CSV especificado
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            dataGridView1.SelectAll();
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            DataObject dataObject = dataGridView1.GetClipboardContent();
            File.WriteAllText("Productos.csv", dataObject.GetText(TextDataFormat.CommaSeparatedValue));

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }
    }

    //Clase de productos
    class Productos
    {
        //propiedades
        public long producto_codigo = 0;
        public String producto_nombre = "";
        public float producto_precio = 0.00f;


        //Constructor vacio
        public Productos()
        {
            //MessageBox.Show("Me llamaron vacio");
        }

        //Constructor sobre cargado
        public Productos(long producto_codigo, String producto_nombre, float producto_precio)
        {
            //MessageBox.Show("Me llamaron con parametros");
            this.producto_codigo = producto_codigo;
            this.producto_nombre = producto_nombre;
            this.producto_precio = producto_precio;
        }

        //Constructor sobre cargado
        public Productos(long producto_codigo, String producto_nombre, double producto_precio)
        {
            //MessageBox.Show("Me llamaron con parametros");
            this.producto_codigo = producto_codigo;
            this.producto_nombre = producto_nombre;
            this.producto_precio = float.Parse(producto_precio.ToString());
        }

    }
}
