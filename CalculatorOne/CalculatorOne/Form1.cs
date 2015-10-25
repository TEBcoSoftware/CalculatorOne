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
        public float HeldNumber; //The number we are currently inputting/ans
        public float lastHeldNumber; //The last number we inputted
        public bool HeldNumberInDecimal = false; //Have we pressed the decimal button yet on the current held number
        public byte CurOp; //The current opperation we're going to perform  (1 is add, 2 is sub, 3 is mult, 4 is div, 5 will be mod)
        public bool JustEquated = false; //Has the user's last action been an equation

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

        #region buttonInput

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeHeldNumber(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeHeldNumber(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangeHeldNumber(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangeHeldNumber(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChangeHeldNumber(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChangeHeldNumber(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChangeHeldNumber(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ChangeHeldNumber(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ChangeHeldNumber(9);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            ChangeHeldNumber(0);
        }

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            HeldNumberInDecimal = true;
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            PerformOperation(1);
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            PerformOperation(2);
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            PerformOperation(3);
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            PerformOperation(4);
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            Equate();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearDisplay();
        }

        #endregion

        private void ChangeHeldNumber(int number)
        {
            if (JustEquated == true)
            {
                lastHeldNumber = HeldNumber;
                HeldNumber = 0;
                HeldNumberInDecimal = false;
            }
            if (HeldNumberInDecimal == false)
            {
                HeldNumber *= 10f;
                HeldNumber += number;
            }

            RefreshDisplay();
            JustEquated = false;
        }

        private void PerformOperation(byte OperationNum)
        {
            lastHeldNumber = HeldNumber;
            HeldNumber = 0;
            HeldNumberInDecimal = false;
            CurOp = OperationNum;
            RefreshDisplay();
            JustEquated = false;
        }

        private void ClearDisplay()
        {
            lastHeldNumber = HeldNumber;
            HeldNumber = 0;
            HeldNumberInDecimal = false;
            RefreshDisplay();
        }

        private void Equate()
        {
            float tempHold;
            switch (CurOp)
            {
                case 1:
                    tempHold = HeldNumber;
                    HeldNumber = lastHeldNumber + HeldNumber;
                    lastHeldNumber = tempHold;
                    RefreshDisplay();
                    break;
                case 2:
                    tempHold = HeldNumber;
                    HeldNumber = lastHeldNumber - HeldNumber;
                    lastHeldNumber = tempHold;
                    RefreshDisplay();
                    break;
                case 3:
                    tempHold = HeldNumber;
                    HeldNumber = lastHeldNumber * HeldNumber;
                    lastHeldNumber = tempHold;
                    RefreshDisplay();
                    break;
                case 4:
                    tempHold = HeldNumber;
                    HeldNumber = lastHeldNumber / HeldNumber;
                    lastHeldNumber = tempHold;
                    RefreshDisplay();
                    break;
                case 5:
                    tempHold = HeldNumber;
                    HeldNumber = lastHeldNumber % HeldNumber;
                    lastHeldNumber = tempHold;
                    RefreshDisplay();
                    break;
            }
            JustEquated = true;
        }

        private void RefreshDisplay()
        {
            displayTextBox.Text = HeldNumber.ToString();
        }
    }
}
