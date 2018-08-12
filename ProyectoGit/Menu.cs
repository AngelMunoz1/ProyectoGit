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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnCrud_Click(object sender, EventArgs e)
        {
            Form1 crud = new Form1();
            crud.Show();
            this.Hide();
        }

        private void btnPuntoDeVenta_Click(object sender, EventArgs e)
        {
            Punto_Venta venta = new Punto_Venta();
            venta.Show();
            this.Hide();
        }

        private void btnChecador_Click(object sender, EventArgs e)
        {
            Checador che = new Checador();
            che.Show();
            this.Hide();
        }

        private void btnVerificador_Click(object sender, EventArgs e)
        {
            Verificador ve = new Verificador();
            ve.Show();
            this.Hide();
        }
    }
}
