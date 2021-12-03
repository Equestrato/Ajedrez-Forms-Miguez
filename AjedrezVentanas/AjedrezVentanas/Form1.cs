using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace AjedrezVentanas
{
    public partial class Form1 : Form
    {
        private bool message;
        private int jugar;
        Form llamar;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            textBox1.BringToFront();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            message = false;
            jugar = 0;
        }
        public Form1(Form llamado, int n)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            textBox1.BringToFront();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            message = false;
            jugar = n;
            llamar = llamado;
        }

        private void Jugar_Click(object sender, EventArgs e)
        {
            if (jugar == 0) {
                Form4 form = new Form4(this);
                form.Show();
                this.Hide();
            } else {
                llamar.Show();
                this.Hide();
            }
            
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            if (Jugar.BackColor == Color.GhostWhite)
            {
                Jugar.BackColor = Color.Gainsboro;
            }
            else
            {
                Jugar.BackColor = Color.GhostWhite;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Timers.Timer aTimer = new System.Timers.Timer(500);

            // Hook up the Elapsed event for the timer.
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

            // Set the Interval to 2 seconds (2000 milliseconds).
            aTimer.Interval = 550;
            aTimer.Enabled = true;            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pdf_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5(this);
            form.Show();
            this.Hide();
        }

        private void calculos_Click(object sender, EventArgs e)
        {
            message = !(message);
            if (message == true)
            {
                textBox1.Text = "Cota superior O((64*8)(n^2))";
                textBox2.Text = "Cota inferior O((64*8*m)(n^2) m es la cantidad de veces que se repita el algortimo";
                textBox1.TextAlign = HorizontalAlignment.Center;
                textBox2.TextAlign = HorizontalAlignment.Center;
            } else {
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

    }
}
