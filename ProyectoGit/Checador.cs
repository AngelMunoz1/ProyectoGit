using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoGit
{
    public partial class Checador : Form
    {
        string ruta = Application.StartupPath;
        string Empleado = "";
        bool Existe = false;
        int Contador = 0;

        public Checador()
        {
            InitializeComponent();
        }

        private void Checador_Load(object sender, EventArgs e)
        {
            lblTitulo.Location = new Point(this.Width / 2 - lblTitulo.Width / 2, 10);
            lblSubtitulo.Location = new Point(this.Width / 2 - lblSubtitulo.Width / 2, lblTitulo.Height + 11);

            lblFecha.Text = DateTime.Now.ToString();
            lblFecha.Location = new Point(this.Width / 2 - lblFecha.Width / 2, lblTitulo.Height + lblSubtitulo.Height + 21);

            lblBienvenido.Location = new Point(this.Width / 2 - lblFecha.Width / 2, lblTitulo.Height + lblSubtitulo.Height + lblFecha.Height + 300);
            lblInfo.Location = new Point(this.Width / 2 - lblFecha.Width / 2, lblTitulo.Height + lblSubtitulo.Height + lblFecha.Height + lblBienvenido.Height + 30);

            

            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString();
            lblFecha.Location = new Point(this.Width / 2 - lblFecha.Width / 2, lblTitulo.Height + lblSubtitulo.Height + 20);
        }

        private void Checador_KeyPress(object sender, KeyPressEventArgs e)
        {
            Empleado += e.KeyChar;
            if (e.KeyChar == 13)
            {   
                if (Empleado.Trim() == "menu" || Empleado.Trim() == "MENU")
                {
                    Menu menu = new Menu();
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    BuscarEmpleado(Empleado);
                    Empleado = "";
                    Contador = 0;
                }
                
            }
         
        }

        private void BuscarEmpleado(string Empleado)
        {
            String[] InfoEmpleado;
            string line;
         
            System.IO.StreamReader file = new System.IO.StreamReader("Empleados.csv");
            while ((line = file.ReadLine()) != null)
            {
                InfoEmpleado = line.Split(',');
                if (Empleado.Trim() == InfoEmpleado[0])
                {
                    ruta = ruta.Replace("bin\\Debug", "");    

                    lblBienvenido.Text = (InfoEmpleado[0] + "\n" + InfoEmpleado[1] +"\n Esta Checando Su: "+InfoEmpleado[4] +" \n "+ lblFecha.Text);
                    pictureBox1.Image = Image.FromFile(ruta + "img\\" +InfoEmpleado[2]);
                    file.Close();

                    if (InfoEmpleado[4] == "Salida")
                    {
                        lineChanger(InfoEmpleado[0] + "," + InfoEmpleado[1] + "," + InfoEmpleado[2] + "," + InfoEmpleado[3] + ",Entrada", Contador);
                        
                    }
                    else
                    {
                        lineChanger(InfoEmpleado[0] + "," + InfoEmpleado[1] + "," + InfoEmpleado[2] + "," + InfoEmpleado[3] + ",Salida", Contador);
                    }
                    //MandarCorreo(lblBienvenido.Text, InfoEmpleado[3]);

                    lblBienvenido.Update();
                    pictureBox1.Update();
                    System.Threading.Thread.Sleep(1000);//Son 5 segundos 

                    lblBienvenido.Text = "Bienvenido a su trabajo!!";
                    pictureBox1.Image = Image.FromFile(ruta + "img\\perfil.jpg" );

                    Existe = true;

                    break;
                }
                Contador++;
            }
           if (Existe == false)
           {
               //MessageBox.Show("Empleado no registrado, favor de verificarlo.");
           }           
            file.Close();
        }

        private void MandarCorreo(string Mensaje, string correo)
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            try
            {
                msg.To.Add(correo);
                //msg.To.Add("ebarnett57@gmail.com");
                msg.DeliveryNotificationOptions =
               DeliveryNotificationOptions.OnSuccess;
                msg.Priority = MailPriority.High;
                msg.From = new MailAddress("angel_181207@hotmail.com", "Angel",
               System.Text.Encoding.UTF8);
                msg.Subject = "Checador";
                msg.SubjectEncoding = System.Text.Encoding.UTF8;
                msg.Body = Mensaje;
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                msg.IsBodyHtml = false;
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.live.com";
                client.Port = 587;
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = new
               System.Net.NetworkCredential("angel_181207@hotmail.com", "Contraseña");
                client.Send(msg);
                MessageBox.Show("ya mande el correo!!!");
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK,
               MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK,
               MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        static void lineChanger(string newText, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines("Empleados.csv");
            arrLine[line_to_edit] = newText;
            File.WriteAllLines("Empleados.csv", arrLine);            
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }
    }
}
