using LibPrintTicket;
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
    public partial class Punto_Venta : Form
    {
        private double Total = 0, Monedas=0, cambio=0, subtotal=0;
        private string[] CantidadProducto;
        bool Existe = false;
        public Punto_Venta()
        {
            InitializeComponent();
        }

        private void Punto_Venta_Load(object sender, EventArgs e)
        {
            lblTitulo.Location = new Point(this.Width / 2 - lblTitulo.Width / 2, 10);
            lblSubtitulo.Location = new Point(this.Width / 2 - lblSubtitulo.Width / 2, lblTitulo.Height + 11);

            lblFecha.Text = DateTime.Now.ToString();
            lblFecha.Location = new Point(this.Width / 2 - lblFecha.Width / 2, lblTitulo.Height + lblSubtitulo.Height + 21);

            dataGridView1.Width = this.Width - 2;
            dataGridView1.Height = int.Parse(this.Height * 0.75 + "");
            dataGridView1.Location = new Point(1, lblTitulo.Height + lblSubtitulo.Height + lblFecha.Height + 21);

            textBox1.Location = new Point(1, this.Height - textBox1.Height);
            textBox1.Width = this.Width - 1;

            lblTotal.Location = new Point(this.Width - lblTotal.Width + 2, this.Height - textBox1.Height - lblTotal.Height);
            estilosdg();

            textBox1.Focus();
        }

        private void estilosdg()
        {            
            dataGridView1.Columns[0].Width = Convert.ToInt32(this.Width * 0.15f);
            dataGridView1.Columns[1].Width = Convert.ToInt32(this.Width * 0.44f);
            dataGridView1.Columns[2].Width = Convert.ToInt32(this.Width * 0.20f);
            dataGridView1.Columns[3].Width = Convert.ToInt32(this.Width * 0.20f);

            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                c.HeaderCell.Style.Font = new Font("Tahoma", 10, FontStyle.Bold);
                c.DefaultCellStyle.Font = new Font("Tahoma",10  , FontStyle.Regular);
            }            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString();
            lblFecha.Location = new Point(this.Width / 2 - lblFecha.Width / 2, lblTitulo.Height + lblSubtitulo.Height + 20);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (textBox1.Text.IndexOf("*") == -1)
                {
                    BuscarProducto(1, textBox1.Text);
                }
                else if (textBox1.Text.ToLower() == "menu")
                {
                    Menu menu = new Menu();
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    CantidadProducto = textBox1.Text.Split('*');
                    BuscarProducto(int.Parse(CantidadProducto[0]), CantidadProducto[1]);
                }
                textBox1.Clear();
                textBox1.Focus();

            }
            if (e.KeyChar == 27)
            {
                EliminarUltimoProducto();
                GenerarTotal();
            }

            if (e.KeyChar == 9)
            {
                DuplicarUltimoProd();
                GenerarTotal();
            }

            if (e.KeyChar.ToString() == "p")
            {
                Pago();
                GenerarTotal();
            }
        }

        private void Pago()
        {
            Monedas = Convert.ToDouble(textBox1.Text);
            subtotal += this.Total;


            this.Total = Convert.ToDouble(textBox1.Text) - this.Total;
            cambio = Total;
            lblTotal.Text = "Cambio: $" + Total;
            lblTotal.Location = new Point(this.Width - 120, this.Height - lblTotal.Height - 60);
            textBox1.Clear();

            Imprimir();
            dataGridView1.Rows.Clear();
            textBox1.Clear();
        }

        private void DuplicarUltimoProd()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Add(dataGridView1[0, dataGridView1.Rows.Count - 1].Value.ToString(),
                    dataGridView1[1, dataGridView1.Rows.Count - 1].Value.ToString(),
                    dataGridView1[2, dataGridView1.Rows.Count - 1].Value.ToString(),
                    dataGridView1[3, dataGridView1.Rows.Count - 1].Value.ToString());
            }
        }
        private void EliminarUltimoProducto()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
            }
        }

        private void GenerarTotal()
        {
            double total = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                total += Convert.ToDouble(dataGridView1[3, i].Value.ToString());
            }
            lblTotal.Text = "Total: $ " + total.ToString("n");

            

            lblTotal.Location = new Point(this.Width - lblTotal.Width + 2,
                this.Height - textBox1.Height - lblTotal.Height);
        }

        private void BuscarProducto(int cantidad, string producto)
        {
            String[] infoProducto;
            string line;
 
            System.IO.StreamReader file = new System.IO.StreamReader("Productos.csv");
            while ((line = file.ReadLine()) != null)
            {
                infoProducto = line.Split(',');
                if (producto == infoProducto[0])
                {
                    dataGridView1.Rows.Add(cantidad, infoProducto[1], infoProducto[2], cantidad * double.Parse(infoProducto[2]));

                    Total = Total + cantidad * Convert.ToDouble(infoProducto[2]);

                    GenerarTotal();
                    Existe = true;
                }
            }
            if (Existe == false)
            {
                //MessageBox.Show("Producto no registrado, favor de verificarlo.");
            }
            file.Close();
        }

        private void Imprimir()
        {
            Ticket ticket = new Ticket();            
            ticket.HeaderImage = Image.FromFile(@"C:\Users\Angel Muñoz\source\repos\ProyectoGit\ProyectoGit\img\Fondo.bmp");
            ticket.AddSubHeaderLine(DateTime.Now.ToShortDateString()+""+ DateTime.Now.ToShortTimeString());
            
           

            for (int i = 0; i < dataGridView1.RowCount-1;  i++)
            {
                ticket.AddItem(dataGridView1[0,i].Value.ToString(), dataGridView1[1,i].Value.ToString(),dataGridView1[3,i].Value.ToString());
            }

            ticket.AddFooterLine("TOTAL: $"+subtotal.ToString("n"));
            ticket.AddFooterLine("PAGO: $" + Monedas.ToString("n"));
            ticket.AddFooterLine("CAMBIO: $" + Total.ToString("n"));
            ticket.AddFooterLine("Gracias por su compra");
            ticket.AddFooterLine("Vuelve pronto");
            ticket.AddFooterLine("EC-PM-5890X");
            ticket.PrintTicket("EC-PM-5890X");
        }
    }
}
