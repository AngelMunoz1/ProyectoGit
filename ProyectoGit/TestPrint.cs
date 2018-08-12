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
    public partial class TestPrint : Form
    {
        public TestPrint()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Ticket ticket = new Ticket();
                ticket.HeaderImage = Image.FromFile(@"C:\Users\Angel Muñoz\source\repos\ProyectoGit\ProyectoGit\img\Fondo.bmp");
                ticket.AddSubHeaderLine(DateTime.Now.ToShortDateString());
                ticket.AddSubHeaderLine(DateTime.Now.ToShortTimeString());
                ticket.AddSubHeaderLine("Gracias por su compra");
                ticket.AddSubHeaderLine("Vuelve pronto");
                ticket.AddSubHeaderLine("EC-PM-5890X");
            }
            catch (Exception)
            {

                throw;
            }

            
        }
        
    }
}
