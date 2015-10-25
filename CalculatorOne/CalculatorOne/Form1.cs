using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorOne
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Event for if Help/About is clicked
        private void menuItem4_Click(object sender, EventArgs e)
        {
            //Creates a local About Box Form
            AboutBox1 AboutBox = new AboutBox1();
            //Makes the About Box Appear
            AboutBox.Show();
        }

        //Event for form being loaded
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Event for Help/Help being clicked
        private void menuItem6_Click(object sender, EventArgs e)
        {
            //Creates a local Help Form
            HelpForm HelpForm = new HelpForm();
            //Makes the Help Form Appear
            HelpForm.Show();
        }
    }
}
