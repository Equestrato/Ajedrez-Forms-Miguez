using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AjedrezVentanas
{
    public partial class Form2 : Form
    {
        Form llamar;
        public Form2(Form llamado)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            llamar = llamado;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private const int CP_DISABLE_CLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = cp.ClassStyle | CP_DISABLE_CLOSE_BUTTON;
                return cp;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void solution_Click(object sender, EventArgs e)
        {

        }

        private void volver_Click(object sender, EventArgs e)
        {
            llamar.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

    }
}


