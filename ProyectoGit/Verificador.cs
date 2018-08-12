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
    public partial class Verificador : Form
    {
        private string codigo, producto;

        public Verificador()
        {
            InitializeComponent();
        }

        private void Verificador_Load(object sender, EventArgs e)
        {
            lblTitulo.Location = new Point(this.Width / 2 - lblTitulo.Width / 2, 10);
            lblSubtitulo.Location = new Point(this.Width / 2 - lblSubtitulo.Width / 2, lblTitulo.Height+11);
            lblFecha.Text = DateTime.Now.ToString();
            lblFecha.Location = new Point(this.Width / 2 - lblFecha.Width / 2, lblTitulo.Height+lblSubtitulo.Height + 21);
            lblInfoProducto.Location = new Point(this.Width / 2 - lblInfoProducto.Width / 2, lblTitulo.Height + lblSubtitulo.Height + lblFecha.Height + 22);
            btnMenu.Location = new Point(1, this.Height - btnMenu.Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString();
            lblFecha.Location = new Point(this.Width / 2 - lblFecha.Width / 2, lblTitulo.Height + lblSubtitulo.Height + 21);
        }

        private void Buscar(String Valor)
        {
            string[] InfoProdocuto;
            string Line;
            System.IO.StreamReader file = new System.IO.StreamReader("Productos.csv");

            while ((Line = file.ReadLine()) != null)
            {
                InfoProdocuto = Line.Split(',');
                if (Valor == InfoProdocuto[0])
                {
                    lblInfoProducto.Text = "Nombre: " + InfoProdocuto[1]
                        + " Precio: $" + InfoProdocuto[2];
                    lblInfoProducto.Location = new Point(this.Width / 2 - lblInfoProducto.Width / 2, lblTitulo.Height + lblSubtitulo.Height + lblFecha.Height  + 22);
                    btnImg.Location= new Point(this.Width / 2 - lblInfoProducto.Width / 2, lblTitulo.Height + lblSubtitulo.Height + lblFecha.Height + lblInfoProducto.Height + 22);
                    btnImg.BackgroundImage = Image.FromFile(@"C:\Users\Angel Muñoz\source\repos\ProyectoGit\ProyectoGit\img\" + InfoProdocuto[0] + ".jpg");
                    btnImg.BackgroundImageLayout = ImageLayout.Center;
                }
                else
                {
                   // MessageBox.Show("No Existe");
                }
            }

            file.Close();
        }

        private void Verificador_KeyPress(object sender, KeyPressEventArgs e)
        {
            codigo += e.KeyChar;
            if (e.KeyChar == 13)
            {
                Buscar(codigo.Trim());
                codigo = "";
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void btnImg_KeyPress(object sender, KeyPressEventArgs e)
        {
            codigo = "";
            Buscar("1234567891236");
            codigo += e.KeyChar;
            if (e.KeyChar == 13)
            {
                Buscar("1234567891235");
                //Buscar(codigo.Trim());
                
            }
        }
    }
}
